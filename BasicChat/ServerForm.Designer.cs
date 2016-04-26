namespace BasicChatServer
{
    partial class ServerForm
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
            this.btnSend = new System.Windows.Forms.Button();
            this.txBoxMsg = new System.Windows.Forms.TextBox();
            this.txBoxLog = new System.Windows.Forms.TextBox();
            this.lstBoxUsers = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // btnSend
            // 
            this.btnSend.Location = new System.Drawing.Point(278, 228);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(120, 23);
            this.btnSend.TabIndex = 4;
            this.btnSend.Text = "Send";
            this.btnSend.UseVisualStyleBackColor = true;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // txBoxMsg
            // 
            this.txBoxMsg.Location = new System.Drawing.Point(13, 230);
            this.txBoxMsg.Name = "txBoxMsg";
            this.txBoxMsg.Size = new System.Drawing.Size(259, 20);
            this.txBoxMsg.TabIndex = 3;
            this.txBoxMsg.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txBoxMsg_KeyUp);
            // 
            // txBoxLog
            // 
            this.txBoxLog.BackColor = System.Drawing.SystemColors.Window;
            this.txBoxLog.Location = new System.Drawing.Point(12, 12);
            this.txBoxLog.Multiline = true;
            this.txBoxLog.Name = "txBoxLog";
            this.txBoxLog.ReadOnly = true;
            this.txBoxLog.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txBoxLog.Size = new System.Drawing.Size(260, 212);
            this.txBoxLog.TabIndex = 5;
            // 
            // lstBoxUsers
            // 
            this.lstBoxUsers.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lstBoxUsers.FormattingEnabled = true;
            this.lstBoxUsers.Location = new System.Drawing.Point(278, 12);
            this.lstBoxUsers.Name = "lstBoxUsers";
            this.lstBoxUsers.Size = new System.Drawing.Size(120, 210);
            this.lstBoxUsers.TabIndex = 6;
            // 
            // ServerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(410, 263);
            this.Controls.Add(this.lstBoxUsers);
            this.Controls.Add(this.txBoxLog);
            this.Controls.Add(this.btnSend);
            this.Controls.Add(this.txBoxMsg);
            this.Name = "ServerForm";
            this.Text = "Server";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ServerForm_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.TextBox txBoxMsg;
        private System.Windows.Forms.TextBox txBoxLog;
        private System.Windows.Forms.ListBox lstBoxUsers;
    }
}

