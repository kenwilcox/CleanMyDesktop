using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SQLite;

namespace CleanMyDesktop
{
  internal class DataHandler
  {
    private SQLiteConnection _con;

    public DataHandler()
    {
      _con = new SQLiteConnection("Data Source=CleanMyDesktop.db; Version=3");
      _con.Open();
      SQLiteCommand cmd = _con.CreateCommand();
      if (!TableExists("_info"))
      {
        cmd.CommandText = "create table _info(key varchar(20), value varchar(50))";
        cmd.ExecuteNonQuery();

        cmd.CommandText = "insert into _info(key, value) values (@key, @value)";
        cmd.Parameters.Add("key", DbType.String);
        cmd.Parameters.Add("value", DbType.Int32);

        for (int i = 0; i < 100; i++)
        {
          cmd.Parameters["key"].Value = "Key" + i.ToString();
          cmd.Parameters["value"].Value = i;
          cmd.ExecuteNonQuery();
        }
      }
    }

    public DataTable GetInfoTable()
    {
      return GetTable("_info");
    }

    private DataTable GetTable(string tableName)
    {
      SQLiteCommand command = _con.CreateCommand();
      command.CommandText = "select * from " + tableName;
      SQLiteDataReader reader = command.ExecuteReader();
      DataTable table = new DataTable();
      table.Load(reader);
      return table;
    }

    private bool TableExists(string tableName)
    {
      bool ret = false;
      SQLiteCommand cmd = _con.CreateCommand();
      cmd.CommandText = "select name from sqlite_master where type='table' and name = '" + tableName + "'";
      object name = cmd.ExecuteScalar();
      ret = ((null != name) & (tableName.Equals((string)name)));
      return ret;
    }
  }
}
