using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.Data;

namespace WPF_Example
{
    public class DBConnection
    {
        private static SQLiteConnection connection;
        private static bool open;
        private static string dbname;

        public DBConnection()
        {

        }

        public DBConnection(string filename)
        {
            if (connection == null || dbname != filename)
            {
                connection = new SQLiteConnection("Data Source=" + filename + ";Version=3;");
                dbname = filename;
            }
        }

        public bool Open()
        {
            if (connection != null)
            {
                if (open == false)
                {
                    connection.Open();
                    open = true;
                }
                return true;
            }
            else
            {
                throw new ConnectionNotSetException("ERROR: Please initiate the connection before trying to use it");
            }
        }

        public DataSet Query(string querystring)
        {
            if (connection != null && open == true)
            {
                DataSet data = new DataSet();
                SQLiteDataAdapter adaptor = new SQLiteDataAdapter(querystring, connection);

                adaptor.Fill(data);

                return data;
            }
            else
            {
                throw new ConnectionNotSetException("ERROR: Please initiate the connection before trying to use it");
            }
        }
    }
}
