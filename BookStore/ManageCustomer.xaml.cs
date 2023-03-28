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
    /// Interaction logic for ManageCustomer.xaml
    /// </summary>
    public partial class ManageCustomer : Window
    {
        public ManageCustomer()
        {
            InitializeComponent();
        }
        void backToMain()
        {
            MainMenu backToMain = new MainMenu();
            this.Visibility = Visibility.Hidden;
            backToMain.Show();
        }
        private void BackToMain_Click(object sender, RoutedEventArgs e)
        {
            backToMain();
        }

        // Click Delete/Add/Update Customer
        private void DeleteCustomer_Click(object sender, RoutedEventArgs e)
        {
            bool have_Customer = DataAccess.CustomerId_Check(txt_CustomerId.Text);
            if (have_Customer)
            {
                DataAccess.DeleteCustomerData(txt_CustomerId.Text);
                MessageBox.Show("Delete Customer Success");
            }
            else
            {
                MessageBox.Show("We don't have this Customer.");
            }
        }

        private void AddCustomer_Click(object sender, RoutedEventArgs e)
        {
            bool isUnique = DataAccess.CustomerId_Check(txt_CustomerId.Text); 
            if (isUnique)
            {
                MessageBox.Show("Dupplicate");
                return;
            }
            DataAccess.AddCustomerData(txt_CustomerId.Text, txt_CustomerName.Text, txt_Address.Text, txt_Email.Text);
            MessageBox.Show("Add Customer Success");
        }

        private void UpdateCustomer_Click(object sender, RoutedEventArgs e)
        {
            bool have_Customer = DataAccess.CustomerId_Check(txt_CustomerId.Text);
            if (have_Customer)
            {
                DataAccess.CustomerUpdate(txt_CustomerId.Text, txt_CustomerName.Text, txt_Address.Text, txt_Email.Text);
                MessageBox.Show("Update Customer Success");
            }
            else 
            {
                MessageBox.Show("We don't have this Customer.");
            }

        }
 
        private void CheckCustomer_Click(object sender, RoutedEventArgs e)
        {
            bool have_Customer = DataAccess.CustomerId_Check(txt_CustomerId.Text);
            if (have_Customer)
            {
                string Customer_Name = DataAccess.CustomerName_Where(txt_CustomerId.Text);
                string Address = DataAccess.Address_Where(txt_CustomerId.Text);
                string Email = DataAccess.Email_Where(txt_CustomerId.Text);
                MessageBox.Show("Customer_Name : " + Customer_Name + "Address : " + Address + "Email : " + Email);
            }
            else
            {
                MessageBox.Show("We don't have this Customer.");
            }
        }
    }
}
