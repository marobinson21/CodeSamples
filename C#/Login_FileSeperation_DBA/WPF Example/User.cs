/***************************************************
 * CLASS NAME: User
 * CREATED BY: Marc Robinson
 * 
 * The User class is an example of a Database Abstraction Layer.
 * Passing the UserID of a user populates the User class with the
 * relevant information without having to worry about the 
 * database logic. Information can be changed, and the changes will
 * be reflected in the Database after Storing
 * 
 * PUBLIC METHODS AVAILABLE:
 * CONSTRUCTOR(int userID)
 * CONSTRUCTOR()
 * getFormattedName()
 * 
 * PUBLIC VARIABLES AVAILABLE:
 * userid (GET ONLY)
 * username (GET AND SET)
 * firstname (GET AND SET)
 * lastname (GET AND SET)
 * age (GET AND SET)
 * ***************************************************/


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace WPF_Example
{
    public class User
    {
        public int userid{ get; private set; }
        public string username { get; set; }
        public string firstname { get; set; }
        public string lastname { get; set; }
        public int age { get; set; }

        /*************************************
        * METHOD NAME: User (CONSTRUCTOR)
        * INPUTS: NONE
        * OUTPUT: NONE
        * 
        * PURPOSE: This method creates a blank User object with the next available UserID,
        * as retrieved from the database.
        * ************************************/
        public User(){}

        /*************************************
        * METHOD NAME: User (CONSTRUCTOR)
        * INPUTS: userid (int)
        * OUTPUT: NONE
        * 
        * PURPOSE: This method creates a User object from a given
         * UserID. 
        * ************************************/
        public User(int userid_in)
        {
            DBConnection connection = new DBConnection(SISApplication.dbname);

            DataSet result = connection.Query("select * from users where ID = '" + userid_in + "'");

            userid = Convert.ToInt32(result.Tables[0].Rows[0]["ID"]);
            username = Convert.ToString(result.Tables[0].Rows[0]["username"]);
            firstname = Convert.ToString(result.Tables[0].Rows[0]["First Name"]);
            lastname = Convert.ToString(result.Tables[0].Rows[0]["Last Name"]);
            age = Convert.ToInt32(result.Tables[0].Rows[0]["Age"]);
        }

        /*************************************
        * METHOD NAME: getFormattedName
        * INPUTS: NONE
        * OUTPUT: (string) - The formatted name.
        * 
        * PURPOSE: This method combines the First and Last names of the user and returns them
        * formatted as "<FirstName> <LastName>"
        * ************************************/
        public string getFormattedName()
        {
            return firstname + " " + lastname;
        }


        /*************************************
        * METHOD NAME: Store
        * INPUTS: NONE
        * OUTPUT: NONE
        * 
        * PURPOSE: This method stores the User Object in the database. It checks to see
         * if a User with the given ID exists first. If it does, it updates that user. If it does not
         * it creates a new user with the ID.
        * ************************************/
        private void Store()
        {
            DBConnection connection = new DBConnection(SISApplication.dbname);

            if(userExists(this.userid))
            {
                connection.Query("update users set username = '" + this.username + "', First Name = '" + this.firstname + "', Last Name = '" + this.lastname + "', Age = '" + this.age + "' where ID = '" + this.userid + "'");
            }
            else
            {
                connection.Query("insert into users(username,First Name,Last Name,Age) values ('" + this.username + "','" + this.firstname + "','" + this.lastname + "','" + this.age + "')");
            }

        }

        /*************************************
        * METHOD NAME: userExists
        * INPUTS: userid (int)
        * OUTPUT: (string) - True is User Exists, False if it does not.
        * 
        * PURPOSE: Method returns whether a user with the given ID exists or
         * not in the database.
        * ************************************/
        private bool userExists(int userid)
        {
            DBConnection connection = new DBConnection(SISApplication.dbname);

            DataSet result = connection.Query("select * from users where ID = '" + userid + "'");

            if (result.Tables[0].Rows.Count > 0)
            {
                return true;
            }
            else
                return false;
        }
    }
}
