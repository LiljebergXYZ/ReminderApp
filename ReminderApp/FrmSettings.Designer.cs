namespace ReminderApp
{
  partial class FrmSettings
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
      if (disposing && (components != null)) {
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
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmSettings));
      this.groupBox1 = new System.Windows.Forms.GroupBox();
      this.checkMBox = new System.Windows.Forms.CheckBox();
      this.checkBubble = new System.Windows.Forms.CheckBox();
      this.button1 = new System.Windows.Forms.Button();
      this.button2 = new System.Windows.Forms.Button();
      this.checkAutostart = new System.Windows.Forms.CheckBox();
      this.groupBox1.SuspendLayout();
      this.SuspendLayout();
      // 
      // groupBox1
      // 
      this.groupBox1.Controls.Add(this.checkAutostart);
      this.groupBox1.Controls.Add(this.checkMBox);
      this.groupBox1.Controls.Add(this.checkBubble);
      this.groupBox1.Location = new System.Drawing.Point(12, 12);
      this.groupBox1.Name = "groupBox1";
      this.groupBox1.Size = new System.Drawing.Size(260, 86);
      this.groupBox1.TabIndex = 1;
      this.groupBox1.TabStop = false;
      this.groupBox1.Text = "Reminder settings";
      // 
      // checkMBox
      // 
      this.checkMBox.AutoSize = true;
      this.checkMBox.Location = new System.Drawing.Point(6, 64);
      this.checkMBox.Name = "checkMBox";
      this.checkMBox.Size = new System.Drawing.Size(86, 17);
      this.checkMBox.TabIndex = 1;
      this.checkMBox.Text = "Messagebox";
      this.checkMBox.UseVisualStyleBackColor = true;
      this.checkMBox.CheckedChanged += new System.EventHandler(this.checkBox2_CheckedChanged);
      // 
      // checkBubble
      // 
      this.checkBubble.AutoSize = true;
      this.checkBubble.Location = new System.Drawing.Point(6, 41);
      this.checkBubble.Name = "checkBubble";
      this.checkBubble.Size = new System.Drawing.Size(114, 17);
      this.checkBubble.TabIndex = 0;
      this.checkBubble.Text = "Notification bubble";
      this.checkBubble.UseVisualStyleBackColor = true;
      this.checkBubble.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
      // 
      // button1
      // 
      this.button1.Enabled = false;
      this.button1.Location = new System.Drawing.Point(116, 104);
      this.button1.Name = "button1";
      this.button1.Size = new System.Drawing.Size(75, 23);
      this.button1.TabIndex = 2;
      this.button1.Text = "Save";
      this.button1.UseVisualStyleBackColor = true;
      this.button1.Click += new System.EventHandler(this.button1_Click);
      // 
      // button2
      // 
      this.button2.Location = new System.Drawing.Point(197, 104);
      this.button2.Name = "button2";
      this.button2.Size = new System.Drawing.Size(75, 23);
      this.button2.TabIndex = 3;
      this.button2.Text = "Cancel";
      this.button2.UseVisualStyleBackColor = true;
      this.button2.Click += new System.EventHandler(this.button2_Click);
      // 
      // checkAutostart
      // 
      this.checkAutostart.AutoSize = true;
      this.checkAutostart.Location = new System.Drawing.Point(6, 19);
      this.checkAutostart.Name = "checkAutostart";
      this.checkAutostart.Size = new System.Drawing.Size(117, 17);
      this.checkAutostart.TabIndex = 2;
      this.checkAutostart.Text = "Start with Windows";
      this.checkAutostart.UseVisualStyleBackColor = true;
      this.checkAutostart.CheckedChanged += new System.EventHandler(this.checkAutostart_CheckedChanged);
      // 
      // FrmSettings
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(284, 139);
      this.Controls.Add(this.button2);
      this.Controls.Add(this.button1);
      this.Controls.Add(this.groupBox1);
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
      this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = "FrmSettings";
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
      this.Text = "Settings";
      this.Load += new System.EventHandler(this.FrmSettings_Load);
      this.groupBox1.ResumeLayout(false);
      this.groupBox1.PerformLayout();
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.GroupBox groupBox1;
    private System.Windows.Forms.CheckBox checkMBox;
    private System.Windows.Forms.CheckBox checkBubble;
    private System.Windows.Forms.Button button1;
    private System.Windows.Forms.Button button2;
    private System.Windows.Forms.CheckBox checkAutostart;
  }
}