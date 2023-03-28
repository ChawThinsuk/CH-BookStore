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
    /// Interaction logic for ManageBook.xaml
    /// </summary>
    public partial class ManageBook : Window
    {
        public ManageBook()
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
        // Click Delete/Add/Update Book
        private void DeleteBook_Click(object sender, RoutedEventArgs e)
        {
            bool have_Book = DataAccess.ISBN_Check(txt_ISBN.Text);
            if (have_Book)
            {
                DataAccess.DeleteBookData(txt_ISBN.Text);
                MessageBox.Show("Delete Book Success");
            }
            else
            {
                MessageBox.Show("We don't have this book.");
            }
        }

        private void AddBook_Click(object sender, RoutedEventArgs e)
        {
            bool have_Book = DataAccess.ISBN_Check(txt_ISBN.Text);
            if (!have_Book)
            {
                DataAccess.AddBookData(txt_ISBN.Text, txt_BookName.Text, txt_BookDetail.Text, txt_BookPrice.Text);
                MessageBox.Show("Add Book Success");
            }
            else
            {
                MessageBox.Show("We already have this book.");
            }
        }

        private void UpdateBook_Click(object sender, RoutedEventArgs e)
        {
            bool have_Book = DataAccess.ISBN_Check(txt_ISBN.Text);
            if (have_Book)
            {
                DataAccess.bookUpdate(txt_ISBN.Text, txt_BookName.Text, txt_BookDetail.Text, txt_BookPrice.Text);
                MessageBox.Show("Update Book Success");
            }
            else
            {
                MessageBox.Show("We don't have this book.");
            }
        }
        //Click Check Book Information
        private void CheckBook_Click(object sender, RoutedEventArgs e)
        {
            bool have_Book = DataAccess.ISBN_Check(txt_ISBN.Text);
            if (have_Book)
            {
                string Title = DataAccess.Title_Where(txt_ISBN.Text);
                string Description = DataAccess.Description_Where(txt_ISBN.Text);
                string Price = DataAccess.Price_Where(txt_ISBN.Text);
                MessageBox.Show("Title : " + Title + "Description : " + Description + "Price : " + Price);
            }
            else 
            {
                MessageBox.Show("We don't have this book.");        
            }
        }

    }
}
