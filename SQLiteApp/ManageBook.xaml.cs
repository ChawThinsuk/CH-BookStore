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
// Click Delete/Add/Update Book
        private void DeleteBook_Click(object sender, RoutedEventArgs e)
        {
            DataAccess.DeleteBookData(txt_ISBN.Text);
            MessageBox.Show("Delete Book Success");
        }

        private void AddBook_Click(object sender, RoutedEventArgs e)
        {
            DataAccess.AddBookData(txt_ISBN.Text, txt_BookName.Text, txt_BookDetail.Text, txt_BookPrice.Text);
            MessageBox.Show("Add Book Success");
        }

        private void UpdateBook_Click(object sender, RoutedEventArgs e)
        {
            DataAccess.bookUpdate(txt_ISBN.Text, txt_BookName.Text, txt_BookDetail.Text, txt_BookPrice.Text);
            MessageBox.Show("Update Book Success");
        }
// Click BackToMain
        private void BackToMain_Click(object sender, RoutedEventArgs e)
        {
            backToMain();
        }
    }
}
