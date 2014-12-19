using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SQLite;

namespace CleanMyDesktop
{
  internal partial class DataHandler
  {
    private  AppSettings _settings;

    public AppSettings Settings
    {
      get
      {
        if (_settings == null)
        {
          _settings = new AppSettings(this);
        }
        return _settings;
      }
    }
    
    internal class AppSettings
    {
      public AppSettings(DataHandler dh)
      {
        // All app settings will be handled here... at some point
      }

      public TimeSpan IgnoreTime
      {
        get;
        set;
      }
    }
  }
}
