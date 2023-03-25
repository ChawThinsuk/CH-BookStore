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
    /// Interaction logic for BookOrder.xaml
    /// </summary>
    public partial class BookOrder : Window
    {
        public BookOrder()
        {
            InitializeComponent();
        }
        void backToMain()
        {
            MainMenu backToMain = new MainMenu();
            this.Visibility = Visibility.Hidden;
            backToMain.Show();
        }
        void BookInformation_Open()
        {
            Transaction BookInformationScreen = new Transaction();
            this.Visibility = Visibility.Hidden;
            BookInformationScreen.Show();
        }
        private void backToMain_Click(object sender, RoutedEventArgs e)
        {
            backToMain();
        }

        public void showBookInformation_Click(object sender, RoutedEventArgs e)
        {
            bool Pass = DataAccess.ISBN_Check(txt_ISBN.Text);
            if (Pass)
            {
                Transaction tf = new Transaction(txt_ISBN.Text);
                tf.Show();
            }
            else
            {
                MessageBox.Show("We don't have this book.");
            }                      

        }

    }
}
