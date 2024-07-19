using System;
using System.Diagnostics;
using System.Security.Principal;
using System.Windows.Forms;

namespace Crowd
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            // Re-Run the app as Admin (If needed)
            if (!IsAdministrator())
            {
                // Restart the application with administrative privileges
                var exeName = Process.GetCurrentProcess().MainModule.FileName;
                ProcessStartInfo startInfo = new ProcessStartInfo(exeName)
                {
                    Verb = "runas",
                    Arguments = "1"
                };
                Process.Start(startInfo);
                Environment.Exit(0);
                return;
            }

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new main());
        }

        // Function to make sure that current process is running as ADMIN
        private static bool IsAdministrator()
        {
            using (WindowsIdentity identity = WindowsIdentity.GetCurrent())
            {
                WindowsPrincipal principal = new WindowsPrincipal(identity);
                return principal.IsInRole(WindowsBuiltInRole.Administrator);
            }
        }
    }
}
