namespace DataGridViewPractice
{
    partial class NotificationTemplate
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.notificationHeaderLabel = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.notificationDateTimeLabel = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.notificationMessageLabel = new System.Windows.Forms.Label();
            this.closeButton2 = new DataGridViewPractice.CloseButton();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.Controls.Add(this.closeButton2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel1.Location = new System.Drawing.Point(364, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(36, 175);
            this.panel1.TabIndex = 1;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Transparent;
            this.panel2.Controls.Add(this.notificationHeaderLabel);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.panel2.Size = new System.Drawing.Size(364, 51);
            this.panel2.TabIndex = 2;
            // 
            // notificationHeaderLabel
            // 
            this.notificationHeaderLabel.BackColor = System.Drawing.Color.Transparent;
            this.notificationHeaderLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.notificationHeaderLabel.Font = new System.Drawing.Font("Microsoft YaHei", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.notificationHeaderLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(104)))), ((int)(((byte)(192)))));
            this.notificationHeaderLabel.Location = new System.Drawing.Point(5, 0);
            this.notificationHeaderLabel.Name = "notificationHeaderLabel";
            this.notificationHeaderLabel.Size = new System.Drawing.Size(359, 51);
            this.notificationHeaderLabel.TabIndex = 0;
            this.notificationHeaderLabel.Text = "Header";
            this.notificationHeaderLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.Transparent;
            this.panel3.Controls.Add(this.notificationDateTimeLabel);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(0, 151);
            this.panel3.Name = "panel3";
            this.panel3.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.panel3.Size = new System.Drawing.Size(364, 24);
            this.panel3.TabIndex = 3;
            // 
            // notificationDateTimeLabel
            // 
            this.notificationDateTimeLabel.BackColor = System.Drawing.Color.Transparent;
            this.notificationDateTimeLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.notificationDateTimeLabel.Font = new System.Drawing.Font("Microsoft PhagsPa", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.notificationDateTimeLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(104)))), ((int)(((byte)(192)))));
            this.notificationDateTimeLabel.Location = new System.Drawing.Point(5, 0);
            this.notificationDateTimeLabel.Name = "notificationDateTimeLabel";
            this.notificationDateTimeLabel.Size = new System.Drawing.Size(359, 24);
            this.notificationDateTimeLabel.TabIndex = 1;
            this.notificationDateTimeLabel.Text = "Date Time";
            this.notificationDateTimeLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.Transparent;
            this.panel4.Controls.Add(this.notificationMessageLabel);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(0, 51);
            this.panel4.Name = "panel4";
            this.panel4.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.panel4.Size = new System.Drawing.Size(364, 100);
            this.panel4.TabIndex = 4;
            // 
            // notificationMessageLabel
            // 
            this.notificationMessageLabel.BackColor = System.Drawing.Color.Transparent;
            this.notificationMessageLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.notificationMessageLabel.Font = new System.Drawing.Font("Microsoft PhagsPa", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.notificationMessageLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(104)))), ((int)(((byte)(192)))));
            this.notificationMessageLabel.Location = new System.Drawing.Point(5, 0);
            this.notificationMessageLabel.Name = "notificationMessageLabel";
            this.notificationMessageLabel.Size = new System.Drawing.Size(359, 100);
            this.notificationMessageLabel.TabIndex = 1;
            this.notificationMessageLabel.Text = "Message";
            this.notificationMessageLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // closeButton2
            // 
            this.closeButton2.BackColor = System.Drawing.Color.Transparent;
            this.closeButton2.Dock = System.Windows.Forms.DockStyle.Top;
            this.closeButton2.Location = new System.Drawing.Point(0, 0);
            this.closeButton2.Name = "closeButton2";
            this.closeButton2.Size = new System.Drawing.Size(34, 34);
            this.closeButton2.TabIndex = 2;
            this.closeButton2.Click += new System.EventHandler(this.OnNotificationClosed);
            // 
            // NotificationTemplate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(400, 175);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "NotificationTemplate";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "NotificationTemplate";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmFadeClose_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.NotificationTemplate_FormClosed);
            this.Load += new System.EventHandler(this.NotificationTemplate_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.NotificationTemplate_Paint);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private CloseButton closeButton1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label notificationHeaderLabel;
        private System.Windows.Forms.Label notificationDateTimeLabel;
        private System.Windows.Forms.Label notificationMessageLabel;
        private CloseButton closeButton2;
    }
}