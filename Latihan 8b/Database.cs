using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.OleDb;

namespace Latihan_8b
{
    class Database
    {
        OleDbConnection kon;

        public Database()
        {
            string srt = "Provider=Microsoft.Ace.OleDB.12.0;Data Source=Database.accdb";
            kon = new OleDbConnection(srt);
            kon.Open();
        }

        public void Exe(string sql)
        {
            OleDbCommand cmd = new OleDbCommand();
            cmd.Connection = kon;
            cmd.CommandText = sql;
            cmd.ExecuteNonQuery();
        }

        public DataTable GetData(string sql)
        {
            OleDbCommand cmd = new OleDbCommand();
            cmd.Connection = kon;
            cmd.CommandText = sql;

            OleDbDataReader read = cmd.ExecuteReader();
            DataTable rs = new DataTable();
            rs.Load(read);

            return rs;
        }

            
    }
}
