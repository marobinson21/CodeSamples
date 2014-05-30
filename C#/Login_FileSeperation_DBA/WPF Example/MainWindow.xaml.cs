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

        private void loginbutton_Click(object sender, RoutedEventArgs e)
        {

            if(LoginSystem.login(loginname.Text,"gorilla111"))
            {
                loginname.Visibility = System.Windows.Visibility.Hidden;
            }
        }
    }
}
