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
using System.Windows.Shapes;

namespace CHBookStore
{
    /// <summary>
    /// Interaction logic for MainMenu.xaml
    /// </summary>
    public partial class MainMenu : Window
    {
      public MainMenu(string Username)
      {
          InitializeComponent();
          tb_Username.Text = Username;
      }
        public MainMenu()
        {
            InitializeComponent();
            

        }
        void backToLogin()
        {
            Login backToLogin = new Login();
            this.Visibility = Visibility.Hidden;
            backToLogin.Show();
        }
        // Open Function
        void BookOrderOpen()
        {
            BookOrder BookOrderScreen = new BookOrder();
            this.Visibility = Visibility.Hidden;
            BookOrderScreen.Show();
        }
        void ManageCustomerOpen()
        {
            ManageCustomer ManageCustomerScreen = new ManageCustomer();
            this.Visibility = Visibility.Hidden;
            ManageCustomerScreen.Show();
        }
        void ManageBookOpen()
        {
            ManageBook ManageBookScreen = new ManageBook();
            this.Visibility = Visibility.Hidden;
            ManageBookScreen.Show();
        }
// Click to BookOrder, ManageCustomer, ManageBook
        private void Order_Click(object sender, RoutedEventArgs e)
        {
            BookOrderOpen();    
        }

        private void ManageCustomer_Click(object sender, RoutedEventArgs e)
        {
            ManageCustomerOpen();
        }

        private void ManageBook_Click(object sender, RoutedEventArgs e)
        {
            ManageBookOpen();
        }

        private void Logout_Click(object sender, RoutedEventArgs e)
        {
            backToLogin();
        }
    }
}
