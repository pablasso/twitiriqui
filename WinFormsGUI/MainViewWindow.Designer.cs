namespace Twitiriqui.WinFormsGUI
{
    partial class MainViewWindow
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
            this.roster = new System.Windows.Forms.WebBrowser();
            this.input = new System.Windows.Forms.RichTextBox();
            this.send = new System.Windows.Forms.Button();
            this.mainView = new System.Windows.Forms.WebBrowser();
            this.SuspendLayout();
            // 
            // roster
            // 
            this.roster.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.roster.Location = new System.Drawing.Point(295, -2);
            this.roster.MinimumSize = new System.Drawing.Size(20, 20);
            this.roster.Name = "roster";
            this.roster.Size = new System.Drawing.Size(169, 444);
            this.roster.TabIndex = 0;
            this.roster.DocumentCompleted += new System.Windows.Forms.WebBrowserDocumentCompletedEventHandler(this.roster_DocumentCompleted);
            // 
            // input
            // 
            this.input.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.input.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.input.Location = new System.Drawing.Point(0, 448);
            this.input.Name = "input";
            this.input.Size = new System.Drawing.Size(355, 29);
            this.input.TabIndex = 1;
            this.input.Text = "";
            // 
            // send
            // 
            this.send.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.send.Location = new System.Drawing.Point(399, 445);
            this.send.Name = "send";
            this.send.Size = new System.Drawing.Size(65, 32);
            this.send.TabIndex = 2;
            this.send.Text = "Send";
            this.send.UseVisualStyleBackColor = true;
            // 
            // mainView
            // 
            this.mainView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.mainView.Location = new System.Drawing.Point(0, -2);
            this.mainView.MinimumSize = new System.Drawing.Size(20, 20);
            this.mainView.Name = "mainView";
            this.mainView.Size = new System.Drawing.Size(289, 444);
            this.mainView.TabIndex = 3;
            this.mainView.Navigating += new System.Windows.Forms.WebBrowserNavigatingEventHandler(this.mainView_Navigating);
            this.mainView.DocumentCompleted += new System.Windows.Forms.WebBrowserDocumentCompletedEventHandler(this.mainView_DocumentCompleted);
            // 
            // MainViewWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(464, 475);
            this.Controls.Add(this.mainView);
            this.Controls.Add(this.send);
            this.Controls.Add(this.input);
            this.Controls.Add(this.roster);
            this.Name = "MainViewWindow";
            this.Text = "MainViewWindow";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainViewWindow_FormClosed);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.WebBrowser roster;
        private System.Windows.Forms.RichTextBox input;
        private System.Windows.Forms.Button send;
        private System.Windows.Forms.WebBrowser mainView;

    }
}