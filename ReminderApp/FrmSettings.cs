using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using Microsoft.Win32;
using System.Windows.Forms;

namespace ReminderApp
{
  public partial class FrmSettings : Form
  {
    FrmMain frm;

    RegistryKey autostartRegKey;

    public FrmSettings(FrmMain frm)
    {
      InitializeComponent();

      autostartRegKey = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);

      this.frm = frm;
    }

    private void FrmSettings_Load(object sender, EventArgs e)
    {
      //Read settings and set the check boxes to right state
      checkAutostart.Checked = autostartRegKey.GetValue("ReminderApp") != null;

      if(frm.settings.GetBool("Bubble"))
        checkBubble.Checked = true;

      if (frm.settings.GetBool("Messagebox"))
        checkMBox.Checked = true;

      button1.Enabled = false;
    }

    private void button1_Click(object sender, EventArgs e)
    {
      //Autostart check
      if (checkAutostart.Checked)
        autostartRegKey.SetValue("ReminderApp", Application.ExecutablePath);
      else
        autostartRegKey.DeleteValue("ReminderApp", false);

      //Set the values in dictionary
      try {
        if (checkBubble.Checked)
          frm.settings.SetBool("Bubble", true);
        else
          frm.settings.SetBool("Bubble", false);

        if (checkMBox.Checked)
          frm.settings.SetBool("Messagebox", true);
        else
          frm.settings.SetBool("Messagebox", false);

        frm.settings.Save();
      }
      catch (Exception ex) {
        MessageBox.Show("Error: " + ex);
      }

      this.Close();
    }

    private void button2_Click(object sender, EventArgs e)
    {
      this.Close();
    }

    private void checkBox1_CheckedChanged(object sender, EventArgs e)
    {
      button1.Enabled = true;
    }

    private void checkBox2_CheckedChanged(object sender, EventArgs e)
    {
      button1.Enabled = true;
    }

    private void checkAutostart_CheckedChanged(object sender, EventArgs e)
    {
      button1.Enabled = true;
    }
  }
}
