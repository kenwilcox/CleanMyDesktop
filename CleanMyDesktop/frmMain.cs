using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.IO;
using System.Text;
using System.Windows.Forms;


namespace CleanMyDesktop
{
  public partial class frmMain : Form
  {
    private DataHandler _dh;

    public frmMain()
    {
      InitializeComponent();
    }

    private void HandleExistingFiles()
    {
      // Get a list of files
      // Check the file age
      // If it's old - take care of it
    }

    private void frmMain_Load(object sender, EventArgs e)
    {
      _dh = new DataHandler();
      
      TimeSpan s = _dh.Settings.IgnoreTime;
      // Add a minute each time - test settings
      s = s.Add(new TimeSpan(0, 1, 0));
      _dh.Settings.IgnoreTime = s;

      MessageBox.Show(s.ToString());

      HandleExistingFiles();

      watcher.Path = _dh.Settings.WatchPath;
      watcher.EnableRaisingEvents = true;
    }

    private void watcher_Event(object sender, FileSystemEventArgs e)
    {
      lbFiles.Items.Add(e.ChangeType.ToString() + ": " + e.Name);
    }

    private void watcher_Renamed(object sender, System.IO.RenamedEventArgs e)
    {
      lbFiles.Items.Add("Renamed: " + e.OldName + " to " + e.Name);
    }

    private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
    {
      // Check to make sure we won't crash
      _dh.Settings.WatchPath = "nothing"; 
    }
  }
}
