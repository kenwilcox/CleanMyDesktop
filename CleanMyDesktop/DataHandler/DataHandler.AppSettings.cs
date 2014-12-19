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
      private DataHandler _dh;
      private SQLiteCommand _selCmd;
      private SQLiteCommand _insCmd;
      private SQLiteCommand _updCmd;
     
      public AppSettings(DataHandler dh)
      {
        _dh = dh;

        if (!_dh.TableExists("_settings"))
          CreateSettingsTable();

        // Create the settings table if necessary
        _selCmd = dh._con.CreateCommand();
        _selCmd.CommandText = "select value from _settings where key = @key";
        _selCmd.Parameters.Add("key", DbType.String);

        _insCmd = _dh._con.CreateCommand();
        _insCmd.CommandText = "insert into _settings(key, value) values (@key, @value)";
        _insCmd.Parameters.Add("key", DbType.String);
        _insCmd.Parameters.Add("value", DbType.String);

        _updCmd = _dh._con.CreateCommand();
        _updCmd.CommandText = "update _settings set value = @value where key = @key";
        _updCmd.Parameters.Add("key", System.Data.DbType.String);
        _updCmd.Parameters.Add("value", System.Data.DbType.String);
      }

      private void CreateSettingsTable()
      {
        SQLiteCommand cmd = _dh._con.CreateCommand();
        cmd.CommandText = "create table _settings(key varchar(20), value varchar(50))";
        cmd.ExecuteNonQuery();

        cmd.CommandText = "create unique index uniq_name on _info (key);";
        cmd.ExecuteNonQuery();
      }

      private bool KeyExists(string key)
      {
        _selCmd.Parameters["key"].Value = key;
        object obj = _selCmd.ExecuteScalar();
        return obj != null;
      }

      private object _get(string key, object defaultValue)
      {
        object ret = defaultValue;
        _selCmd.Parameters["key"].Value = key;
        object temp = _selCmd.ExecuteScalar();
        if (temp != null)
          ret = temp;
        return ret;
      }

      private void _set(string key, object value)
      {
        if (KeyExists(key))
        {
          _updCmd.Parameters["key"].Value = key;
          _updCmd.Parameters["value"].Value = value;
          _updCmd.ExecuteNonQuery();
        }
        else
        {
          _insCmd.Parameters["key"].Value = key;
          _insCmd.Parameters["value"].Value = value;
          _insCmd.ExecuteNonQuery();
        }
      }

      public TimeSpan IgnoreTime
      {
        get
        {
          // Default to 30 minutes
          object data = _get("ignoreTime", null);
          if (data != null)
          {
            long ticks;
            Int64.TryParse(data.ToString(), out ticks);
            return new TimeSpan(ticks);
          }
          else
          {
            return new TimeSpan(0, 30, 0);
          }
        }
        set
        {
          _set("ignoreTime", value.Ticks);
        }
      }
    }
  }
}
