namespace CleanMyDesktop
{
  partial class frmMain
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
      if (disposing && (components != null))
      {
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
      this.watcher = new System.IO.FileSystemWatcher();
      this.lbFiles = new System.Windows.Forms.ListBox();
      ((System.ComponentModel.ISupportInitialize)(this.watcher)).BeginInit();
      this.SuspendLayout();
      // 
      // watcher
      // 
      this.watcher.EnableRaisingEvents = true;
      this.watcher.IncludeSubdirectories = true;
      this.watcher.SynchronizingObject = this;
      this.watcher.Changed += new System.IO.FileSystemEventHandler(this.watcher_Event);
      this.watcher.Created += new System.IO.FileSystemEventHandler(this.watcher_Event);
      this.watcher.Deleted += new System.IO.FileSystemEventHandler(this.watcher_Event);
      this.watcher.Renamed += new System.IO.RenamedEventHandler(this.watcher_Renamed);
      // 
      // lbFiles
      // 
      this.lbFiles.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.lbFiles.FormattingEnabled = true;
      this.lbFiles.Location = new System.Drawing.Point(12, 12);
      this.lbFiles.Name = "lbFiles";
      this.lbFiles.Size = new System.Drawing.Size(260, 225);
      this.lbFiles.TabIndex = 0;
      // 
      // frmMain
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(284, 262);
      this.Controls.Add(this.lbFiles);
      this.Name = "frmMain";
      this.Text = "frmMain";
      this.Load += new System.EventHandler(this.frmMain_Load);
      ((System.ComponentModel.ISupportInitialize)(this.watcher)).EndInit();
      this.ResumeLayout(false);

    }

    #endregion

    private System.IO.FileSystemWatcher watcher;
    private System.Windows.Forms.ListBox lbFiles;

  }
}

