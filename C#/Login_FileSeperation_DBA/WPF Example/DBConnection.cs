/***************************************************
 * CLASS NAME: DBConnection
 * CREATED BY: Marc Robinson
 * 
 * A class to abstract a bit of the Database Connection functionality
 * away. This gives us a generic interface to connect to SQL
 * databases. The internal logic of this class can be changed to
 * use different database systems, but the overlaying classes and code
 * that uses this abstraction will not need to change significantly.
 * 
 * PUBLIC METHODS AVAILABLE:
 * Constructor (string filename): Opens a SQLite Database connection to the given filename.
 * Open (): Opens the connection established by the Constructor.
 * Query (string query): performs the SQL query in the given string and returns a DataSet object containing the results.
 * ***************************************************/


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
            Open();

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
