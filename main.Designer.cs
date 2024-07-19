namespace Crowd
{
    partial class main
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(main));
            this.richInfo = new System.Windows.Forms.RichTextBox();
            this.lblTitle = new System.Windows.Forms.Label();
            this.btnFix = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // richInfo
            // 
            this.richInfo.BackColor = System.Drawing.Color.FloralWhite;
            this.richInfo.Font = new System.Drawing.Font("Microsoft YaHei", 9F);
            this.richInfo.Location = new System.Drawing.Point(15, 31);
            this.richInfo.Name = "richInfo";
            this.richInfo.ReadOnly = true;
            this.richInfo.Size = new System.Drawing.Size(411, 227);
            this.richInfo.TabIndex = 0;
            this.richInfo.Text = "Welcome to the faster CrowdStrike solution coded By Starlyn1232";
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Microsoft YaHei", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.Location = new System.Drawing.Point(12, 9);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(104, 19);
            this.lblTitle.TabIndex = 1;
            this.lblTitle.Text = "Information:";
            // 
            // btnFix
            // 
            this.btnFix.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnFix.Font = new System.Drawing.Font("Microsoft YaHei", 11.25F);
            this.btnFix.Image = ((System.Drawing.Image)(resources.GetObject("btnFix.Image")));
            this.btnFix.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnFix.Location = new System.Drawing.Point(15, 264);
            this.btnFix.Name = "btnFix";
            this.btnFix.Size = new System.Drawing.Size(411, 73);
            this.btnFix.TabIndex = 2;
            this.btnFix.Text = "Fix CrowStrike Error";
            this.btnFix.UseVisualStyleBackColor = true;
            this.btnFix.Click += new System.EventHandler(this.btnFix_Click);
            // 
            // main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.MintCream;
            this.ClientSize = new System.Drawing.Size(438, 348);
            this.Controls.Add(this.btnFix);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.richInfo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Window CrowdStrike Fixer By Starlyn1232";
            this.Load += new System.EventHandler(this.main_Load);
            this.Shown += new System.EventHandler(this.main_Shown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox richInfo;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Button btnFix;
    }
}

