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

    private Dictionary<String, string> settings = new Dictionary<String, string>();
    private string filename = "settings.txt";

    FrmMain frm;

    public FrmSettings(FrmMain frm)
    {
      InitializeComponent();
      this.frm = frm;
    }

    private void FrmSettings_Load(object sender, EventArgs e)
    {
      //Read settings and set the check boxes to right state
      ReadSettings();
      if(settings["Bubble"] == "true")
        checkBox1.Checked = true;

      if (settings["Messagebox"] == "true")
        checkBox2.Checked = true;

      button1.Enabled = false;
    }

    public void ReadSettings()
    {
      try {
        using (StreamReader sr = new StreamReader(filename)) {

          string line;

          while ((line = sr.ReadLine()) != null) {
            String[] keyPair = line.Split('=');

            settings.Add(keyPair[0], keyPair[1]);
          }

        }
      }
      catch (Exception ex) {
        MessageBox.Show("Error: " + ex);
      }
    }

    private void button1_Click(object sender, EventArgs e)
    {

      //Set the values in dictionary
      if (checkBox1.Checked)
        settings["Bubble"] = "true";
      else
        settings["Bubble"] = "false";

      if (checkBox2.Checked)
        settings["Messagebox"] = "true";
      else
        settings["Messagebox"] = "false";

      try {
        //Write the new settings to file
        File.WriteAllLines(filename, new string[] { "Bubble=" + settings["Bubble"], "Messagebox=" + settings["Messagebox"] });

      }
      catch (Exception ex) {
        MessageBox.Show("Error: " + ex);
      }

      //Re read the settings in the main program
      frm.ReadSettings();
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
