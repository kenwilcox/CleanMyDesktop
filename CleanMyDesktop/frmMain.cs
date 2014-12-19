using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;


namespace CleanMyDesktop
{
  public partial class frmMain : Form
  {
    public frmMain()
    {
      InitializeComponent();
    }

    private void frmMain_Load(object sender, EventArgs e)
    {
      watcher.Path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
    }

    private void watcher_Created(object sender, System.IO.FileSystemEventArgs e)
    {
      lbFiles.Items.Add("Created: " + e.Name);
    }

    private void watcher_Renamed(object sender, System.IO.RenamedEventArgs e)
    {
      lbFiles.Items.Add("Renamed: " + e.OldName + " to " + e.Name);
    }
  }
}
