using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace WPF_Example
{
    public static class LoginSystem
    {
        private static DBConnection database;
        private const string dbname = @"C:\Users\Administrator\Documents\GitHub\CodeSamples\C#\WPF Example\WPF Example\example1.sqlite";

        public static bool login(string username, string password)
        {
            if(database == null)
            {
                database = new DBConnection(dbname);
            }

            database.Open();

            //Note: In reality, passwords would be hashed and encrypted when stored, and thus a straight text comparison
            // such as the one below would not work. STORING PASSWORDS IN PLAIN TEXT IS BAD.
            string query = "select * from users join users_passwords where username = '" + username + "' and password = '" + password +"'";

            DataSet result = database.Query(query);

            if (result.Tables[0].Rows.Count > 0) 
                return true;
            else 
                return false;
        }
    }
}
