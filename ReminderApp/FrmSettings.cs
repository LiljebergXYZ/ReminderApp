using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;

namespace ReminderApp
{
  public partial class FrmSettings : Form
  {
    FrmMain frm;

    public FrmSettings(FrmMain frm)
    {
      InitializeComponent();
      this.frm = frm;
    }

    private void FrmSettings_Load(object sender, EventArgs e)
    {
      //Read settings and set the check boxes to right state
      if(frm.settings.GetBool("Bubble"))
        checkBox1.Checked = true;

      if (frm.settings.GetBool("Messagebox"))
        checkBox2.Checked = true;

      button1.Enabled = false;
    }

    private void button1_Click(object sender, EventArgs e)
    {

      //Set the values in dictionary
      try {
        if (checkBox1.Checked)
          frm.settings.SetBool("Bubble", true);
        else
          frm.settings.SetBool("Bubble", false);

        if (checkBox2.Checked)
          frm.settings.SetBool("Messagebox", true);
        else
          frm.settings.SetBool("Messagebox", false);

        frm.settings.Save();
      }
      catch (Exception ex) {
        MessageBox.Show("Error: " + ex);
      }

      this.Hide();
    }

    private void button2_Click(object sender, EventArgs e)
    {
      this.Hide();
    }

    private void checkBox1_CheckedChanged(object sender, EventArgs e)
    {
      button1.Enabled = true;
    }

    private void checkBox2_CheckedChanged(object sender, EventArgs e)
    {
      button1.Enabled = true;
    }
  }
}
