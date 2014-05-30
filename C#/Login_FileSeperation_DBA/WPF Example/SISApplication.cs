/***************************************************
 * CLASS NAME: SISApplication
 * CREATED BY: Marc Robinson
 * 
 * The primary class that performs base actions and keeps 
 * track of variables and state global to the application.
 * 
 * PUBLIC METHODS AVAILABLE:
 * ***************************************************/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF_Example
{
    public static class SISApplication
    {
        public static User CurrentUser {get; private set;}
        public static string dbname = @"C:\Users\Administrator\Documents\GitHub\CodeSamples\C#\WPF Example\WPF Example\example1.sqlite";
        public static string activescreen;

        public static bool loginUser(string username, string password)
        {
            int userID = LoginSystem.login(username, password);

            if(userID != 0)
            {
                CurrentUser = new User(userID);
                activescreen = "main";
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
