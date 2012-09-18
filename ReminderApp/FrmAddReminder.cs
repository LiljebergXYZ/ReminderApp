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

      string[] daysArr = { "Monday", "Tuesday", "Wednesday",
                              "Thursday", "Friday", "Saturday",
                              "Sunday", "Workdays", "Weekend", 
                              "Everyday" };

      for (int i = 0; i < daysArr.Length; i++) {
        string item = daysArr[i];
          dayBox.Items.Add(item);
      }

      comboBox1.Items.Clear();
      DirectoryInfo dinfo = new DirectoryInfo("./signals/");
      FileInfo[] files = dinfo.GetFiles("*.ogg");
      comboBox1.Items.Add("None");
      comboBox1.SelectedIndex = 0;
      foreach (FileInfo file in files) {
        comboBox1.Items.Add(file.Name);
      }
    }

    private void button1_Click(object sender, EventArgs e)
    {
      //Get the short time of the timepicker
      DateTime dt = timePicker.Value;
      String timeNow = dt.ToShortTimeString();

      //If not edit mode just add the reminder to the end of remind.txt
      if(dayBox.Text != null)
      if (!edit) {
        if (!textBox1.Text.Contains(";")) {
          try {
            using (StreamWriter sw = File.AppendText(filename)) {

              string recurr;
              string active;
              string sound = "";

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

              if (comboBox1.SelectedItem.ToString() != "None")
                sound = comboBox1.SelectedItem.ToString();

              //Write the new reminder to the remind.txt
              sw.WriteLine(dayBox.Text + ";" + timeNow + ";" + textBox1.Text + ";" + recurr + ";" + active + ";" + sound);
              sw.Close();
            }
          }
          catch (Exception ex) {
            MessageBox.Show("Error: " + ex);
          }

          //Reload the reminders in the main form and application
          frm.AddReminders();
          this.Close();
        }
        else {
          MessageBox.Show("No ; sign is allowed in message");
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
          string sound = "";

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

          if (comboBox1.SelectedItem.ToString() != "None")
            sound = comboBox1.SelectedItem.ToString();

          //Split and change the information for remind with index
          String[] remind = remindList[index].Split(';');
          remind[0] = dayBox.Text;
          remind[1] = timeNow;
          remind[2] = textBox1.Text;
          remind[3] = recurr;
          remind[4] = active;
          string reminder = remind[0] + ";" + remind[1] + ";" + remind[2] + ";" + remind[3] + ";" + remind[4] + ";" + sound;
          remindList[index] = reminder;

          //Rewrite the remind.txt file with changes
          File.WriteAllLines(filename, remindList.ToArray());
        }
        catch (Exception ex) {
          MessageBox.Show("Error: " + ex);
        }
        frm.AddReminders();
        this.Close();
      }
    }

    private void button2_Click(object sender, EventArgs e)
    {
      this.Close();
    }

  }
}
