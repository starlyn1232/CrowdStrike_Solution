using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace Crowd
{
    // Main form class
    public partial class main : Form
    {
        // CrowdStrike driver path
        private readonly string driver =
            Environment.Is64BitOperatingSystem ?
            // 64bits path
            @"C:\Windows\SysNative\drivers\CrowdStrike\C-00000291.sys" :
            // 32bits path
            @"C:\Windows\System32\drivers\CrowdStrike\C-00000291.sys";

        // Error message
        private const string ERROR = "We cannot solve the problem, please try again." +
            "\n\n[Remember to run as administrator]";

        // Success message
        private const string SUCCESS = "Problem solved!\n\nGive this saved you, a coffee cup " +
            "is very welcomed!\n\n" +
            "E-Mail: starlyn1232@gmail.com\n" +
            "USDT: TNztPkuGkXsjw1z81aVrMuv1Z72Ah6xm7Y (TRC20)";

        // Safe mode messages
        private const string SAFE = "Safe mode detected, do you want to disable it now?";
        private const string SAFE_CMD_F = "bcdedit /deletevalue {current} safeboot";
        private const string SAFE_CMD_T = "bcdedit /set {current} safeboot minimal";
        private const string SAFE_DISABLED = "Safe Mode has been disabled. Please restart your computer.";
        private const string SAFE_ENABLED = "Safe Mode has been enabled. Please restart your computer.";
        private const string SAFE_FAILED = "Cannot apply the changes, please do it manually.";
        private const string SAFE_ASK = "Safe mode NOT detected, do you want to enabled it now?";

        // Title text
        private const string title = "Window CrowdStrike Fixer By Starlyn1232";

        // Constructors
        public main()
        {
            InitializeComponent();
        }

        // Form load event
        private void main_Load(object sender, EventArgs e)
        {
            // Make size static
            this.MaximumSize = this.Size;
        }

        // RichBox handlers

        /// <summary>
        /// Clear RichText
        /// </summary>
        private void Info()
        {
            richInfo.Clear();
        }

        /// <summary>
        /// Let's append some text with this function
        /// </summary>
        /// <param name="txt">The text to be appended to RichBox</param>
        /// <param name="color">The text color value</param>
        private void Info(string txt, Color color)
        {
            richInfo.SelectionColor = color;
            richInfo.AppendText(txt);
        }

        private void Info(string txt)
        {
            Info(txt, Color.Black);
        }

        // UI Manager

        /// <summary>
        /// Disable / Enable the fix button
        /// </summary>
        /// <param name="enabled"></param>
        private void UI(bool enabled)
        {
            this.btnFix.Enabled = enabled;
        }

        // Message Box wrapper
        private enum _type
        {
            inf,
            err,
            ask
        }

        private DialogResult Msg(string txt, _type type)
        {
            // We use 'this' (which is the current form pointer actually)
            // so we make sure that notifications will get on this
            // form top
            return MessageBox.Show(this, txt, title,
                // Define buttons
                type == _type.ask ? 
                MessageBoxButtons.YesNo : 
                MessageBoxButtons.OK,
                // Define icon
                type == _type.inf ? MessageBoxIcon.Information : 
                type == _type.err ? MessageBoxIcon.Error :
                MessageBoxIcon.Question);
        }

        private void Msg(string txt)
        {
            Msg(txt, _type.inf);
        }

        // Check if your PC is in Safe Mode
        private static bool IsInSafeMode()
        {
            string safeBoot = Environment.GetEnvironmentVariable("SAFEBOOT_OPTION");
            return !string.IsNullOrEmpty(safeBoot);
        }

        // Disable SafeMode
        private bool SwitchSafeMode(bool enable)
        {
            var result = RunCmd(enable ? SAFE_CMD_T : SAFE_CMD_F);

            if (result)
                Msg(enable ? SAFE_ENABLED : SAFE_DISABLED);

            else
                Msg(SAFE_FAILED, _type.err);

            return result;
        }

        private static bool RunCmd(string command)
        {
            ProcessStartInfo processInfo = new ProcessStartInfo("cmd.exe", "/c " + command)
            {
                CreateNoWindow = true,
                UseShellExecute = false,
                RedirectStandardError = true,
                Verb = "runas" // Ensure the command is run with administrative privileges
            };

            Process process = Process.Start(processInfo);
            process.WaitForExit();

            string error = process.StandardError.ReadToEnd();

            return string.IsNullOrEmpty(error);
        }

        // Fix CrowStrike event
        // (The process is ran at the same App thread because it's
        // so fast that we actually won't need to create another
        // thread
        private void btnFix_Click(object sender, EventArgs e)
        {
            try
            {
                UI(false);

                Info();
                Info("\nFixing CrowdStrike error...");

                // Check if affected driver really exists
                if (!File.Exists(driver))
                {
                    Info("\n\nYour Windows PC is NOT affected!", Color.Blue);
                    return;
                }

                File.Delete(driver);
                Info("\n\nCrowdStrike driver problem fixed!", Color.Green);
                Msg(SUCCESS);

                // Disable safe mode
                if (IsInSafeMode() && Msg(SAFE, _type.ask) == DialogResult.Yes)
                    SwitchSafeMode(false);
            }
            catch (Exception ex)
            {
                Info("Failed!", Color.Red);
                Msg($"\n\n{ERROR}\n\nError information:\n\n{ex.Message}", _type.err);
            }
            finally
            {
                UI(true);
            }
        }

        private void main_Shown(object sender, EventArgs e)
        {
            if (!IsInSafeMode() && Msg(SAFE_ASK, _type.ask) == DialogResult.Yes)
            {
                SwitchSafeMode(true);
                Close();
            }
        }
    }
}
