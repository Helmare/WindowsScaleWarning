namespace WSW
{
    partial class WarningBox
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
            this.btnIgnore = new System.Windows.Forms.Button();
            this.btnKill = new System.Windows.Forms.Button();
            this.lblTitle = new System.Windows.Forms.Label();
            this.message = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnIgnore
            // 
            this.btnIgnore.BackColor = System.Drawing.Color.Silver;
            this.btnIgnore.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnIgnore.Location = new System.Drawing.Point(533, 283);
            this.btnIgnore.Name = "btnIgnore";
            this.btnIgnore.Size = new System.Drawing.Size(165, 41);
            this.btnIgnore.TabIndex = 0;
            this.btnIgnore.Text = "Ignore";
            this.btnIgnore.UseVisualStyleBackColor = false;
            this.btnIgnore.Click += new System.EventHandler(this.btnIgnore_Click);
            // 
            // btnKill
            // 
            this.btnKill.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.btnKill.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnKill.Location = new System.Drawing.Point(362, 283);
            this.btnKill.Name = "btnKill";
            this.btnKill.Size = new System.Drawing.Size(165, 41);
            this.btnKill.TabIndex = 1;
            this.btnKill.Text = "Kill";
            this.btnKill.UseVisualStyleBackColor = false;
            this.btnKill.Click += new System.EventHandler(this.btnKill_Click);
            // 
            // lblTitle
            // 
            this.lblTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.lblTitle.Location = new System.Drawing.Point(0, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(710, 54);
            this.lblTitle.TabIndex = 2;
            this.lblTitle.Text = "WINDOWS SCALE WARNING";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // message
            // 
            this.message.Dock = System.Windows.Forms.DockStyle.Top;
            this.message.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.message.ForeColor = System.Drawing.Color.White;
            this.message.Location = new System.Drawing.Point(0, 54);
            this.message.Name = "message";
            this.message.Size = new System.Drawing.Size(710, 226);
            this.message.TabIndex = 3;
            this.message.Text = "{name} is opening without scaling set to 100%.\r\nThis could result in a degraded e" +
    "xperience while using the application.";
            this.message.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // WarningBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.ClientSize = new System.Drawing.Size(710, 336);
            this.Controls.Add(this.message);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.btnKill);
            this.Controls.Add(this.btnIgnore);
            this.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "WarningBox";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Window Scale Warning";
            this.TopMost = true;
            this.ResumeLayout(false);

        }

        #endregion

        private Button btnIgnore;
        private Button btnKill;
        private Label lblTitle;
        private Label message;
    }
}