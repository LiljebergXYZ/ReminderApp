﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using System.Net;
using System.Windows.Forms;
using System.Threading;
using System.Diagnostics;
using IrrKlang;

namespace ReminderApp
{
  public partial class FrmMain : Form
  {

    public List<String> reminders = new List<String>();
    public string filename = Application.StartupPath + "\\remind.txt";
    public string settingFilename = Application.StartupPath + "\\settings.ini";
    public string version = "1.13";

    ISoundEngine soundEngine = new ISoundEngine();
    ISound currentlyPlayingSound;

    public Settings settings;

    public FrmMain()
    {
      InitializeComponent();
    }

    private void FrmMain_Load(object sender, EventArgs e)
    {
      //Set title
      this.Text = "Reminder app " + version;

      Thread updateThread = new Thread(CheckUpdate);
      updateThread.Start();

      //Create settings file if not exist
      if (!File.Exists(settingFilename)) {
        File.WriteAllText(settingFilename, Properties.Resources.settings);
      }

      //Load settings
      settings = new Settings(settingFilename);

      //Set all the default values for the listview
      listView1.View = View.Details;
      listView1.GridLines = true;
      listView1.FullRowSelect = true;
      listView1.MultiSelect = false;

      //Add the columns needed to the listview
      listView1.Columns.Add("Day(s)", 70);
      listView1.Columns.Add("Time", 70);
      listView1.Columns.Add("Message", 125);
      listView1.Columns.Add("Recurring", 60);
      listView1.Columns.Add("Active", 55);
      listView1.Columns.Add("Alert Signal", -2);

      AddReminders();

      //Make a mouseeventhandler for the listview
      listView1.MouseClick += new MouseEventHandler(listView1_MouseClick);
      
    }

    void listView1_MouseClick(object sender, MouseEventArgs e)
    {
      //If the right mouse button is pressed show the context menu
      if (e.Button == MouseButtons.Right) {
        listViewMenu.Show(new Point(MousePosition.X, MousePosition.Y));
      }
    }

    //Prevent the application from exiting when pressing the X
    protected override void OnFormClosing(FormClosingEventArgs e)
    {
      base.OnFormClosing(e);

      //Close application for real if windows is shutting down
      if (e.CloseReason == CloseReason.WindowsShutDown)
        return;

      //If user close the window minimize
      if (e.CloseReason == CloseReason.UserClosing) {
        e.Cancel = true;
        this.Hide();
      }
    }

    private void exitBtn_Click(object sender, EventArgs e)
    {
      Application.Exit();
    }

    private void notifyIcon_MouseDoubleClick(object sender, MouseEventArgs e)
    {
      this.Show();
    }

    private void showToolStripMenuItem_Click(object sender, EventArgs e)
    {
      this.Show();
    }

    private void exitToolStripMenuItem_Click(object sender, EventArgs e)
    {
      Application.Exit();
    }

    private void timer1_Tick(object sender, EventArgs e)
    {
      //Set variables for the current time
      DateTime dt = DateTime.Now;
      String timeNow = dt.ToString("HH:mm");
      String day = dt.ToString("dddd", new CultureInfo("en-US"));

      //For loop to check all the reminders if it's time to remind.
      for (int i = 0; i < reminders.Count; i++) {
        String[] info = reminders[i].Split(';');

        //Checks if the reminder is active
        if (info[4] != "No") {

          //If the time contains AM or PM convert to 24h time
          if (info[1].Contains("AM") || info[1].Contains("PM")) {
            DateTime nwdt = new DateTime();
            nwdt = Convert.ToDateTime(info[1]);
            info[1] = nwdt.ToString("HH:mm");
          }

          //If the time and day is correct
          if (timeNow == info[1] &&
            (day == info[0] ||
            info[0].ToUpper() == "EVERYDAY" ||
            (day == "Monday" || day == "Tuesday" || day == "Wednesday" || day == "Thursday" || day == "Friday") &&
            info[0].ToUpper() == "WORKDAYS") ||
            (day == "Saturday" || day == "Sunday") && info[0].ToUpper() == "WEEKEND") {

            //If it's not going to recurr set active to "No"
            if (info[3] != "Yes") {

              List<String> remindList = new List<String>();

              using (StreamReader sr = new StreamReader(filename)) {
                string line;

                while ((line = sr.ReadLine()) != null) {
                  remindList.Add(line);
                }
              }

              String[] remind = remindList[i].Split(';');
              remind[4] = "No";
              string reminder = remind[0] + ";" + remind[1] + ";" + remind[2] + ";" + remind[3] + ";" + remind[4] + ";" + remind[5];
              remindList[i] = reminder;

              File.WriteAllLines(filename, remindList.ToArray());
              AddReminders();

            }

            //Show the message for the reminder
            if (settings.GetBool("Bubble")) {
              notifyIcon.BalloonTipIcon = ToolTipIcon.Warning;
              notifyIcon.BalloonTipTitle = "Reminder";
              notifyIcon.BalloonTipText = info[2];
              notifyIcon.ShowBalloonTip(2000);
            }
            if (info[5] != null)
              currentlyPlayingSound = soundEngine.Play2D(@"./signals/" + info[5]);
            if (settings.GetBool("Messagebox")) {
              MessageBox.Show(info[2]);
            }

          }
          else {
            string[] days = info[0].Split(',');
            foreach(string str in days){
              if (day == str) {

                //If it's not going to recurr set active to "No"
                if (info[3] != "Yes") {

                  List<String> remindList = new List<String>();

                  using (StreamReader sr = new StreamReader(filename)) {
                    string line;

                    while ((line = sr.ReadLine()) != null) {
                      remindList.Add(line);
                    }
                  }

                  String[] remind = remindList[i].Split(';');
                  remind[4] = "No";
                  string reminder = remind[0] + ";" + remind[1] + ";" + remind[2] + ";" + remind[3] + ";" + remind[4];
                  remindList[i] = reminder;

                  File.WriteAllLines(filename, remindList.ToArray());
                  AddReminders();

                }

                //Show the message for the reminder
                if (settings.GetBool("Bubble")) {
                  notifyIcon.BalloonTipIcon = ToolTipIcon.Warning;
                  notifyIcon.BalloonTipTitle = "Reminder";
                  notifyIcon.BalloonTipText = info[2];
                  notifyIcon.ShowBalloonTip(2000);
                }
                if (settings.GetBool("Messagebox")) {
                  MessageBox.Show(info[2]);
                }

              }
            }
          }

        }
      }

    }

    //Check for update
    private void CheckUpdate()
    {
      try {
        WebClient wc = new WebClient();
        string latest = wc.DownloadString("http://dan-l.net/reminder/version.txt");
        if (version != latest) {
          notifyIcon.BalloonTipIcon = ToolTipIcon.Info;
          notifyIcon.BalloonTipTitle = "Reminder";
          notifyIcon.BalloonTipText = "There's an update available. The latest version is v" + latest;
          notifyIcon.ShowBalloonTip(2000);

          updateToolStripMenuItem.Visible = true;
        }
      }catch{ }
    }

    //Function returning a list of the reminders in reminder.txt
    private List<String> ReadReminders()
    {
      List<String> reminders = new List<String>();
      try {

        //If the remind.txt file don't exist, create it
        if (!File.Exists(filename)) {
          var remindtxt = File.Create("remind.txt");
          remindtxt.Close();
        }

        //Open the remind.txt file and read all the reminders
        using (StreamReader sr = new StreamReader(filename)) {
          string line;

          while ((line = sr.ReadLine()) != null) {
            //Add the reminders to the list of reminders
            reminders.Add(line);
          }

        }
      }
      catch (Exception ex) {
        MessageBox.Show("Error: " + ex);
      }

      //Return the list of reminders
      return reminders;
    }

    //Adds the reminbers to the listview
    public void AddReminders()
    {
      try {
        //Clear the reminders list so we don't get doubles
        reminders.Clear();

        //Read and add all the reminders to the list
        reminders = ReadReminders();

        //Clear the listview to prevent doubles
        listView1.Items.Clear();

        //Split and add all the reminders to the listview
        for (int i = 0; i < reminders.Count; i++) {
          String[] info = reminders[i].Split(';');
          listView1.Items.Add(new ListViewItem(new string[] { info[0], info[1], info[2], info[3], info[4], info[5] }));
        }
      }
      catch (Exception ex) {
        MessageBox.Show("Error: " + ex);
      }
    }

    private void button1_Click(object sender, EventArgs e)
    {
      //Open the form for adding reminders
      FrmAddReminder frmAddReminder = new FrmAddReminder(this, false, 0);
      frmAddReminder.Show();
    }

    private void removeToolStripMenuItem_Click(object sender, EventArgs e)
    {
      try {
        //Get the index of the reminder
        int index = 0;
        if (listView1.SelectedItems.Count > 0)
          index = listView1.SelectedIndices[0];

        //Open and read all the lines in the reminder.txt
        List<string> lst = File.ReadAllLines(filename).ToList();

        //Remove the reminder with index
        lst.RemoveAt(index);

        //Rewrite everything to the reminder.txt file
        File.WriteAllLines(filename, lst.ToArray());

        //Remove it from the listview
        listView1.Items.RemoveAt(index);

        //Add reminders
        AddReminders();
      }
      catch (Exception ex) {
        MessageBox.Show("Error: " + ex);
      }
    }

    private void editToolStripMenuItem_Click(object sender, EventArgs e)
    {
      //Get the index of the reminder
      int index = 0;
      if (listView1.SelectedItems.Count > 0)
        index = listView1.SelectedIndices[0];

      //Open the form for adding/editing reminders
      FrmAddReminder frmAddReminder = new FrmAddReminder(this, true, index);

      //Split the reminder with index to get all info
      String[] info = reminders[index].Split(';');

      //Convert the time to DateTime for use in datetimepicker
      DateTime nwdt = new DateTime();
      nwdt = Convert.ToDateTime(info[1]);

      //Set all the values in the form to edit
      frmAddReminder.Show();
      List<int> days = dayToInt(info[0]);
      for (int i = 0; i < days.Count; i++) {
        frmAddReminder.dayBox.SetItemChecked(days[i], true);
      }
      frmAddReminder.timePicker.Value = nwdt;
      frmAddReminder.textBox1.Text = info[2];
      if (info[3] == "Yes") {
        frmAddReminder.recurringBox.Checked = true;
      }
      else {
        frmAddReminder.recurringBox.Checked = false;
      }
      if (info[4] == "Yes") {
        frmAddReminder.activeBox.Checked = true;
      }
      else {
        frmAddReminder.activeBox.Checked = false;
      }
      frmAddReminder.comboBox1.SelectedItem = info[5];

      //Show the form
      //frmAddReminder.Show();
    }

    private void button2_Click(object sender, EventArgs e)
    {
      this.Hide();
    }

    private void settingsBtn_Click(object sender, EventArgs e)
    {
      FrmSettings frmSettings = new FrmSettings(this);
      frmSettings.Show();
    }

    private void activateToolStripMenuItem_Click(object sender, EventArgs e)
    {
      try {
        //Get the index of the reminder
        int index = 0;
        if (listView1.SelectedItems.Count > 0)
          index = listView1.SelectedIndices[0];

        //Open and read all the lines in the reminder.txt
        List<string> lst = File.ReadAllLines(filename).ToList();

        //Remove the reminder with index
        String[] info = lst[index].Split(';');

        String fullInfo = info[0] + ";" + info[1] + ";" + info[2] + ";" + info[3] + ";Yes";

        lst[index] = fullInfo;

        //Rewrite everything to the reminder.txt file
        File.WriteAllLines(filename, lst.ToArray());

        //Reload reminders
        AddReminders();
      }
      catch (Exception ex) {
        MessageBox.Show("Error: " + ex);
      }
    }

    private List<int> dayToInt(string day)
    {
      List<int> days = new List<int>();
      string[] dayArr = day.Split(',');
      for (int i = 0; i < dayArr.Length; i++) {
        switch (dayArr[i].ToLower()) {
          case "monday":
            days.Add(0);
            break;
          case "tuesday":
            days.Add(1);
            break;
          case "wednesday":
            days.Add(2);
            break;
          case "thursday":
            days.Add(3);
            break;
          case "friday":
            days.Add(4);
            break;
          case "saturday":
            days.Add(5);
            break;
          case "sunday":
            days.Add(6);
            break;
          case "workdays":
            days.Add(7);
            break;
          case "weekend":
            days.Add(8);
            break;
          case "everyday":
            days.Add(9);
            break;
        }
      }
      return days;
    }

    private void updateToolStripMenuItem_Click(object sender, EventArgs e)
    {
      Process.Start("http://dan-l.net/reminder/");
    }
  }
}
