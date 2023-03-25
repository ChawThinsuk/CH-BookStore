﻿using System;
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
        // Click Delete/Add/Update Customer
        private void DeleteCustomer_Click(object sender, RoutedEventArgs e)
        {
            DataAccess.DeleteCustomerData(txt_CustomerId.Text);
            MessageBox.Show("Delete Customer Success");
        }

        private void AddCustomer_Click(object sender, RoutedEventArgs e)
        {
            DataAccess.AddCustomerData(txt_CustomerId.Text, txt_CustomerName.Text, txt_Address.Text, txt_Email.Text);
            MessageBox.Show("Add Customer Success");
        }

        private void UpdateCustomer_Click(object sender, RoutedEventArgs e)
        {
            DataAccess.CustomerUpdate(txt_CustomerId.Text, txt_CustomerName.Text, txt_Address.Text, txt_Email.Text);
            MessageBox.Show("Update Customer Success");
        }
        // Click BackToMain
        private void BackToMain_Click(object sender, RoutedEventArgs e)
        {
            backToMain();
        }


    }
}
