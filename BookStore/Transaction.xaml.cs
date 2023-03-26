using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
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
    /// Interaction logic for Transaction.xaml
    /// </summary>
    public partial class Transaction : Window
    {


        public Transaction(string ISBN)
        {
            InitializeComponent();
            txt_BookISBN.Text = ISBN;
        }
        public Transaction()
        {
            InitializeComponent();
        }
        void backToMain()
        {
            MainMenu backToMain = new MainMenu();
            this.Visibility = Visibility.Hidden;
            backToMain.Show();
        }
        void backToBookOrder()
        {
            BookOrder backToBookOrder = new BookOrder();
            this.Visibility = Visibility.Hidden;
            backToBookOrder.Show();
        }


        private void confirm_Click(object sender, RoutedEventArgs e)
        {
            int price = int.Parse(txt_Price.Text);
            int quantity = int.Parse(txt_Quantity.Text);
            int totalPrice = price * quantity;
            txt_TotalPrice.Text = totalPrice.ToString();
            txt_CustomerName.Text = DataAccess.CustomerName_Where(txt_CustomerId.Text);
        }


        private void btn_MakeAPurchase_Click(object sender, RoutedEventArgs e)
        {

            DataAccess.AddTransactionData(txt_BookISBN.Text, txt_CustomerId.Text, txt_Quantity.Text, txt_TotalPrice.Text);
            MessageBox.Show("Success");
            backToMain();

        }

        private void txt_BookISBN_TextChanged(object sender, TextChangedEventArgs e)
        {
            txt_Price.Text = DataAccess.Price_Where(txt_BookISBN.Text);
            txt_Description.Text = DataAccess.Description_Where(txt_BookISBN.Text);            
        }

        private void btn_BackToBookOrder_Click(object sender, RoutedEventArgs e)
        {
            backToBookOrder();
        }
    }
}
