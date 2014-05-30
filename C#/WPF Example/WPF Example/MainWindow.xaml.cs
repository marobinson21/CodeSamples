using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Data.SQLite;
using System.Data;

namespace WPF_Example
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            //string filename = @"C:\Users\Administrator\Documents\GitHub\CodeSamples\C#\WPF Example\WPF Example\example1.sqlite";

            //DBConnection database = new DBConnection(filename);
        }

        private void querybutton_Click(object sender, RoutedEventArgs e)
        {
            string inputtext = querybox.Text;

            string filename = @"C:\Users\Administrator\Documents\GitHub\CodeSamples\C#\WPF Example\WPF Example\example1.sqlite";
            DBConnection database = new DBConnection(filename);
            DataSet data;

            if (database.Open())
            {
                //This is a terrible, terrible plan. It leaves you open to all sorts of SQL Injection Shenanigans.
                //But this is just a practice example so I can get used to using WPF and Databases in C#.
                data = database.Query(inputtext);
                resultsgrid.ItemsSource = data.Tables[0].DefaultView;
            }
        }
    }

    public class DBConnection
    {
        private static SQLiteConnection connection;
        private static bool open;

        public DBConnection()
        {

        }

        public DBConnection(string filename)
        {
            if(connection == null)
            {
                connection = new SQLiteConnection("Data Source=" + filename + ";Version=3;");
            }
        }

        public bool Open()
        {
            if(connection != null)
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


    public class ConnectionNotSetException : Exception
    {
        public ConnectionNotSetException()
        {

        }

        public ConnectionNotSetException(string message)
            : base(message)
        {

        }

        public ConnectionNotSetException(string message, Exception inner)
            : base(message, inner)
        {

        }
    }
}
