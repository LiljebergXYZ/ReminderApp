﻿namespace ReminderApp
{
  partial class FrmAddReminder
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
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmAddReminder));
      this.timePicker = new System.Windows.Forms.DateTimePicker();
      this.label1 = new System.Windows.Forms.Label();
      this.label2 = new System.Windows.Forms.Label();
      this.textBox1 = new System.Windows.Forms.TextBox();
      this.label3 = new System.Windows.Forms.Label();
      this.button1 = new System.Windows.Forms.Button();
      this.activeBox = new System.Windows.Forms.CheckBox();
      this.recurringBox = new System.Windows.Forms.CheckBox();
      this.button2 = new System.Windows.Forms.Button();
      this.dayBox = new CheckComboBoxTest.CheckedComboBox();
      this.SuspendLayout();
      // 
      // timePicker
      // 
      this.timePicker.Format = System.Windows.Forms.DateTimePickerFormat.Time;
      this.timePicker.Location = new System.Drawing.Point(61, 43);
      this.timePicker.Name = "timePicker";
      this.timePicker.Size = new System.Drawing.Size(152, 20);
      this.timePicker.TabIndex = 0;
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Location = new System.Drawing.Point(26, 46);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(33, 13);
      this.label1.TabIndex = 1;
      this.label1.Text = "Time:";
      // 
      // label2
      // 
      this.label2.AutoSize = true;
      this.label2.Location = new System.Drawing.Point(30, 19);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(29, 13);
      this.label2.TabIndex = 3;
      this.label2.Text = "Day:";
      // 
      // textBox1
      // 
      this.textBox1.Location = new System.Drawing.Point(61, 69);
      this.textBox1.Name = "textBox1";
      this.textBox1.Size = new System.Drawing.Size(152, 20);
      this.textBox1.TabIndex = 4;
      // 
      // label3
      // 
      this.label3.AutoSize = true;
      this.label3.Location = new System.Drawing.Point(6, 72);
      this.label3.Name = "label3";
      this.label3.Size = new System.Drawing.Size(53, 13);
      this.label3.TabIndex = 5;
      this.label3.Text = "Message:";
      // 
      // button1
      // 
      this.button1.Location = new System.Drawing.Point(73, 149);
      this.button1.Name = "button1";
      this.button1.Size = new System.Drawing.Size(75, 23);
      this.button1.TabIndex = 10;
      this.button1.Text = "Save";
      this.button1.UseVisualStyleBackColor = true;
      this.button1.Click += new System.EventHandler(this.button1_Click);
      // 
      // activeBox
      // 
      this.activeBox.AutoSize = true;
      this.activeBox.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
      this.activeBox.Location = new System.Drawing.Point(18, 114);
      this.activeBox.Name = "activeBox";
      this.activeBox.Size = new System.Drawing.Size(59, 17);
      this.activeBox.TabIndex = 11;
      this.activeBox.Text = "Active:";
      this.activeBox.UseVisualStyleBackColor = true;
      // 
      // recurringBox
      // 
      this.recurringBox.AutoSize = true;
      this.recurringBox.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
      this.recurringBox.Location = new System.Drawing.Point(2, 95);
      this.recurringBox.Name = "recurringBox";
      this.recurringBox.Size = new System.Drawing.Size(75, 17);
      this.recurringBox.TabIndex = 12;
      this.recurringBox.Text = "Recurring:";
      this.recurringBox.UseVisualStyleBackColor = true;
      // 
      // button2
      // 
      this.button2.Location = new System.Drawing.Point(154, 149);
      this.button2.Name = "button2";
      this.button2.Size = new System.Drawing.Size(75, 23);
      this.button2.TabIndex = 13;
      this.button2.Text = "Cancel";
      this.button2.UseVisualStyleBackColor = true;
      this.button2.Click += new System.EventHandler(this.button2_Click);
      // 
      // dayBox
      // 
      this.dayBox.CheckOnClick = true;
      this.dayBox.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
      this.dayBox.DropDownHeight = 1;
      this.dayBox.FormattingEnabled = true;
      this.dayBox.IntegralHeight = false;
      this.dayBox.Location = new System.Drawing.Point(61, 16);
      this.dayBox.Name = "dayBox";
      this.dayBox.Size = new System.Drawing.Size(152, 21);
      this.dayBox.TabIndex = 14;
      this.dayBox.ValueSeparator = ",";
      // 
      // FrmAddReminder
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(236, 186);
      this.Controls.Add(this.dayBox);
      this.Controls.Add(this.button2);
      this.Controls.Add(this.recurringBox);
      this.Controls.Add(this.activeBox);
      this.Controls.Add(this.button1);
      this.Controls.Add(this.label3);
      this.Controls.Add(this.textBox1);
      this.Controls.Add(this.label2);
      this.Controls.Add(this.label1);
      this.Controls.Add(this.timePicker);
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
      this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
      this.MaximizeBox = false;
      this.MinimumSize = new System.Drawing.Size(242, 215);
      this.Name = "FrmAddReminder";
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
      this.Text = "Add/Edit";
      this.Load += new System.EventHandler(this.FrmAddReminder_Load);
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    public System.Windows.Forms.DateTimePicker timePicker;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.Label label2;
    public System.Windows.Forms.TextBox textBox1;
    private System.Windows.Forms.Label label3;
    private System.Windows.Forms.Button button1;
    public System.Windows.Forms.CheckBox activeBox;
    public System.Windows.Forms.CheckBox recurringBox;
    private System.Windows.Forms.Button button2;
    public CheckComboBoxTest.CheckedComboBox dayBox;
  }
}