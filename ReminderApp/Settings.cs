using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace ReminderApp
{
  public class Settings
  {
    private Dictionary<string, string> keys = new Dictionary<string, string>();
    private string filename;

    public Settings(string Filename)
    {
      this.filename = Filename;

      LoadFile();
    }

    private void LoadFile()
    {

      if (File.Exists(filename)) {
        //Clear settings dictionary
        keys.Clear();
        try {
          using (StreamReader sr = new StreamReader(filename)) {

            string line;

            while ((line = sr.ReadLine()) != null) {
              String[] keyPair = line.Split('=');

              keys.Add(keyPair[0], keyPair[1]);
            }

          }
        }
        catch (Exception ex) {
          Console.WriteLine("Error: " + ex);
        }
      }

    }

    public string GetFilename()
    {
      return filename;
    }

    public string GetString(string key)
    {
      if (keys.ContainsKey(key))
        return keys[key];
      return "";
    }

    public bool GetBool(string key)
    {
      try {
        if (keys.ContainsKey(key))
          return bool.Parse(keys[key]);
      }
      catch { }
      return false;
    }

    public int GetInt(string key)
    {
      try {
        if (keys.ContainsKey(key))
          return int.Parse(keys[key]);
      }
      catch { }
      return 0;
    }

    public void SetString(string key, string value)
    {
      keys[key] = value;
    }

    public void SetBool(string key, bool value)
    {
      keys[key] = value.ToString();
    }

    public void SetInt(string key, int value)
    {
      keys[key] = value.ToString();
    }

    public void Save()
    {
      string[] output = new string[keys.Count];
      int i = 0;
      foreach (KeyValuePair<string, string> entry in keys) {
        output[i] = entry.Key + "=" + entry.Value;
        i++;
      }
      File.WriteAllLines(filename, output);
    }

  }
}
