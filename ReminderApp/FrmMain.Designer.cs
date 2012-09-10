namespace ReminderApp
{
  partial class FrmMain
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
      this.components = new System.ComponentModel.Container();
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMain));
      this.notifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
      this.notifyIconMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
      this.showToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.listView1 = new System.Windows.Forms.ListView();
      this.addBtn = new System.Windows.Forms.Button();
      this.exitBtn = new System.Windows.Forms.Button();
      this.listViewMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
      this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.removeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.activateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.timer1 = new System.Windows.Forms.Timer(this.components);
      this.okBtn = new System.Windows.Forms.Button();
      this.settingsBtn = new System.Windows.Forms.Button();
      this.updateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.notifyIconMenu.SuspendLayout();
      this.listViewMenu.SuspendLayout();
      this.SuspendLayout();
      // 
      // notifyIcon
      // 
      this.notifyIcon.ContextMenuStrip = this.notifyIconMenu;
      this.notifyIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon.Icon")));
      this.notifyIcon.Text = "Reminder app";
      this.notifyIcon.Visible = true;
      this.notifyIcon.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon_MouseDoubleClick);
      // 
      // notifyIconMenu
      // 
      this.notifyIconMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.updateToolStripMenuItem,
            this.showToolStripMenuItem,
            this.exitToolStripMenuItem});
      this.notifyIconMenu.Name = "notifyIconMenu";
      this.notifyIconMenu.Size = new System.Drawing.Size(153, 92);
      // 
      // showToolStripMenuItem
      // 
      this.showToolStripMenuItem.Image = global::ReminderApp.Properties.Resources.settings_16;
      this.showToolStripMenuItem.Name = "showToolStripMenuItem";
      this.showToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
      this.showToolStripMenuItem.Text = "Settings";
      this.showToolStripMenuItem.Click += new System.EventHandler(this.showToolStripMenuItem_Click);
      // 
      // exitToolStripMenuItem
      // 
      this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
      this.exitToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
      this.exitToolStripMenuItem.Text = "Exit";
      this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
      // 
      // listView1
      // 
      this.listView1.Location = new System.Drawing.Point(12, 12);
      this.listView1.Name = "listView1";
      this.listView1.Size = new System.Drawing.Size(391, 265);
      this.listView1.TabIndex = 1;
      this.listView1.UseCompatibleStateImageBehavior = false;
      this.listView1.View = System.Windows.Forms.View.List;
      // 
      // addBtn
      // 
      this.addBtn.Location = new System.Drawing.Point(12, 283);
      this.addBtn.Name = "addBtn";
      this.addBtn.Size = new System.Drawing.Size(71, 23);
      this.addBtn.TabIndex = 2;
      this.addBtn.Text = "Add";
      this.addBtn.UseVisualStyleBackColor = true;
      this.addBtn.Click += new System.EventHandler(this.button1_Click);
      // 
      // exitBtn
      // 
      this.exitBtn.Location = new System.Drawing.Point(328, 283);
      this.exitBtn.Name = "exitBtn";
      this.exitBtn.Size = new System.Drawing.Size(75, 23);
      this.exitBtn.TabIndex = 3;
      this.exitBtn.Text = "Exit";
      this.exitBtn.UseVisualStyleBackColor = true;
      this.exitBtn.Click += new System.EventHandler(this.exitBtn_Click);
      // 
      // listViewMenu
      // 
      this.listViewMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.editToolStripMenuItem,
            this.removeToolStripMenuItem,
            this.activateToolStripMenuItem});
      this.listViewMenu.Name = "contextMenuStrip1";
      this.listViewMenu.Size = new System.Drawing.Size(118, 70);
      // 
      // editToolStripMenuItem
      // 
      this.editToolStripMenuItem.Name = "editToolStripMenuItem";
      this.editToolStripMenuItem.Size = new System.Drawing.Size(117, 22);
      this.editToolStripMenuItem.Text = "Edit";
      this.editToolStripMenuItem.Click += new System.EventHandler(this.editToolStripMenuItem_Click);
      // 
      // removeToolStripMenuItem
      // 
      this.removeToolStripMenuItem.Name = "removeToolStripMenuItem";
      this.removeToolStripMenuItem.Size = new System.Drawing.Size(117, 22);
      this.removeToolStripMenuItem.Text = "Remove";
      this.removeToolStripMenuItem.Click += new System.EventHandler(this.removeToolStripMenuItem_Click);
      // 
      // activateToolStripMenuItem
      // 
      this.activateToolStripMenuItem.Name = "activateToolStripMenuItem";
      this.activateToolStripMenuItem.Size = new System.Drawing.Size(117, 22);
      this.activateToolStripMenuItem.Text = "Activate";
      this.activateToolStripMenuItem.Click += new System.EventHandler(this.activateToolStripMenuItem_Click);
      // 
      // timer1
      // 
      this.timer1.Enabled = true;
      this.timer1.Interval = 60000;
      this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
      // 
      // okBtn
      // 
      this.okBtn.Location = new System.Drawing.Point(247, 283);
      this.okBtn.Name = "okBtn";
      this.okBtn.Size = new System.Drawing.Size(75, 23);
      this.okBtn.TabIndex = 5;
      this.okBtn.Text = "OK";
      this.okBtn.UseVisualStyleBackColor = true;
      this.okBtn.Click += new System.EventHandler(this.button2_Click);
      // 
      // settingsBtn
      // 
      this.settingsBtn.Location = new System.Drawing.Point(89, 283);
      this.settingsBtn.Name = "settingsBtn";
      this.settingsBtn.Size = new System.Drawing.Size(75, 23);
      this.settingsBtn.TabIndex = 6;
      this.settingsBtn.Text = "Settings";
      this.settingsBtn.UseVisualStyleBackColor = true;
      this.settingsBtn.Click += new System.EventHandler(this.settingsBtn_Click);
      // 
      // updateToolStripMenuItem
      // 
      this.updateToolStripMenuItem.Image = global::ReminderApp.Properties.Resources.reload_16;
      this.updateToolStripMenuItem.Name = "updateToolStripMenuItem";
      this.updateToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
      this.updateToolStripMenuItem.Text = "Update";
      this.updateToolStripMenuItem.Visible = false;
      this.updateToolStripMenuItem.Click += new System.EventHandler(this.updateToolStripMenuItem_Click);
      // 
      // FrmMain
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(415, 313);
      this.Controls.Add(this.settingsBtn);
      this.Controls.Add(this.okBtn);
      this.Controls.Add(this.exitBtn);
      this.Controls.Add(this.addBtn);
      this.Controls.Add(this.listView1);
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
      this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
      this.MaximizeBox = false;
      this.Name = "FrmMain";
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
      this.Text = "Reminder App";
      this.Load += new System.EventHandler(this.FrmMain_Load);
      this.notifyIconMenu.ResumeLayout(false);
      this.listViewMenu.ResumeLayout(false);
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.NotifyIcon notifyIcon;
    private System.Windows.Forms.ListView listView1;
    private System.Windows.Forms.Button addBtn;
    private System.Windows.Forms.Button exitBtn;
    private System.Windows.Forms.ContextMenuStrip listViewMenu;
    private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem removeToolStripMenuItem;
    private System.Windows.Forms.ContextMenuStrip notifyIconMenu;
    private System.Windows.Forms.ToolStripMenuItem showToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
    private System.Windows.Forms.Timer timer1;
    private System.Windows.Forms.Button okBtn;
    private System.Windows.Forms.Button settingsBtn;
    private System.Windows.Forms.ToolStripMenuItem activateToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem updateToolStripMenuItem;
  }
}

