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
  public partial class FrmAddReminder : Form
  {

    FrmMain frm;
    bool edit;
    int index;
    string filename = "remind.txt";

    public FrmAddReminder(FrmMain main, bool edit, int index)
    {
      InitializeComponent();
      frm = main;
      this.edit = edit;
      this.index = index;
    }

    private void FrmAddReminder_Load(object sender, EventArgs e)
    {
      //Disblae the dropdown
      timePicker.ShowUpDown = true;

      //If not in edit mode set timepicker value to current time
      if (!edit) {
        timePicker.Value = DateTime.Now;
      }
    }

    private void button1_Click(object sender, EventArgs e)
    {
      //Get the short time of the timepicker
      DateTime dt = timePicker.Value;
      String timeNow = dt.ToShortTimeString();

      //If not edit mode just add the reminder to the end of remind.txt
      if(dayBox.SelectedItem != null)
      if (!edit) {
        if (!textBox1.Text.Contains(",")) {
          try {
            using (StreamWriter sw = File.AppendText(filename)) {

              string recurr;
              string active;

              if (recurringBox.Checked) {
                recurr = "Yes";
              }
              else {
                recurr = "No";
              }

              if (activeBox.Checked) {
                active = "Yes";
              }
              else {
                active = "No";
              }

              //Write the new reminder to the remind.txt
              sw.WriteLine(dayBox.SelectedItem.ToString() + "," + timeNow + "," + textBox1.Text + "," + recurr + "," + active);
              sw.Close();
            }
          }
          catch (Exception ex) {
            MessageBox.Show("Error: " + ex);
          }

          //Reload the reminders in the main form and application
          frm.AddReminders();
          this.Hide();
        }
        else {
          MessageBox.Show("No , sign is allowed in message");
        }
      }
      else {
        //Re read all the reminders into memory
        List<String> remindList = new List<String>();
        try {
          using (StreamReader sr = new StreamReader(filename)) {
            string line;

            while ((line = sr.ReadLine()) != null) {
              remindList.Add(line);
            }
          }

          string recurr;
          string active;

          if (recurringBox.Checked) {
            recurr = "Yes";
          }
          else {
            recurr = "No";
          }

          if (activeBox.Checked) {
            active = "Yes";
          }
          else {
            active = "No";
          }

          //Split and change the information for remind with index
          String[] remind = remindList[index].Split(',');
          remind[0] = dayBox.SelectedItem.ToString();
          remind[1] = timeNow;
          remind[2] = textBox1.Text;
          remind[3] = recurr;
          remind[4] = active;
          string reminder = remind[0] + "," + remind[1] + "," + remind[2] + "," + remind[3] + "," + remind[4];
          remindList[index] = reminder;

          //Rewrite the remind.txt file with changes
          File.WriteAllLines(filename, remindList.ToArray());
        }
        catch (Exception ex) {
          MessageBox.Show("Error: " + ex);
        }
        frm.AddReminders();
        this.Hide();
      }
    }

    private void button2_Click(object sender, EventArgs e)
    {
      this.Hide();
    }

    private void dayBox_SelectedIndexChanged(object sender, EventArgs e)
    {
      button1.Enabled = true;
    }
  }
}
