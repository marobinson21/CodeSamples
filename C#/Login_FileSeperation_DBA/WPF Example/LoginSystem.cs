/***************************************************
 * CLASS NAME: LoginSystem
 * CREATED BY: Marc Robinson
 * 
 * The LoginSystem class is a static class designed to
 * facilitate logging a user into the system. It checks
 * the username/password against the database, and then 
 * creates a User object and gives it to the App to keep track of.
 * 
 * PUBLIC METHODS AVAILABLE:
 * (STATIC) login(string username, string password)
 * ***************************************************/


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

        /*************************************
         * METHOD NAME: login
         * INPUTS: username (string), password (string)
         * OUTPUT: (int) UserID is user is logged in, 0 otherwise.
         * 
         * PURPOSE: The login method validates a given username and password
         * against the database. If the user exists, and the password matches,
         * it creates a User object and gives it to the App to track.
         * ************************************/
        public static int login(string username, string password)
        {
            //Only create a new DBConnection if there isn't already one active for the LoginSystem
            if(database == null)
            {
                database = new DBConnection(SISApplication.dbname);
            }

            //Note: In reality, passwords would be hashed and encrypted when stored, and thus a straight text comparison
            // such as the one below would not work. STORING PASSWORDS IN PLAIN TEXT IS BAD.
            string query = "select * from users join users_passwords where username = '" + username + "' and password = '" + password +"'";

            DataSet result = database.Query(query);

            //Will return true if row count > 0, meaning that at least one record was found with matching username and password.
            if (result.Tables[0].Rows.Count > 0)
            {
                return Convert.ToInt32(result.Tables[0].Rows[0]["ID"]);
            }
            else 
                return 0;
        }
    }
}
