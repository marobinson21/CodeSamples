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
            SISApplication.activescreen = "login";
            //string filename = @"C:\Users\Administrator\Documents\GitHub\CodeSamples\C#\WPF Example\WPF Example\example1.sqlite";

            //DBConnection database = new DBConnection(filename);
        }

        private void loginbutton_Click(object sender, RoutedEventArgs e)
        {

            if(SISApplication.loginUser(loginname.Text,loginpass.Text))
            {
                loginname.Visibility = System.Windows.Visibility.Hidden;
                loginpass.Visibility = System.Windows.Visibility.Hidden;
                welcometext.Visibility = System.Windows.Visibility.Hidden;
                loginbutton.Visibility = System.Windows.Visibility.Hidden;

                welcomebox.Visibility = System.Windows.Visibility.Visible;
                welcomebox.Text = "Welcome to SIS, " + SISApplication.CurrentUser.getFormattedName()+". Please select an option from the menu above.";

                searchbutton.Visibility = System.Windows.Visibility.Visible;
            }
        }

        private void loginname_GotKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            loginname.Text = "";
        }

        private void loginname_LostKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            if(loginname.Text == "")
                loginname.Text = "Username";
        }

        private void loginpass_LostKeyboardFocus_1(object sender, KeyboardFocusChangedEventArgs e)
        {
            if (loginpass.Text == "")
                loginpass.Text = "Password";
        }

        private void loginpass_GotKeyboardFocus_1(object sender, KeyboardFocusChangedEventArgs e)
        {
            loginpass.Text = "";
        }

        private void searchbutton_MouseDown(object sender, MouseButtonEventArgs e)
        {
            searchbutton.Source = new BitmapImage(new Uri(@"searchbutton_pressed.jpg", UriKind.Relative));
        }

    }
}
