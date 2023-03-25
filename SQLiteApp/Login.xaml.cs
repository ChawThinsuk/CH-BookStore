using Microsoft.Data.Sqlite;
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
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Window
    {

        public Login()
        {
            InitializeComponent();
            DataAccess.InitializeDatabase();
        }
        void MainOpen()
        {
            MainMenu username = new MainMenu(txt_Username.Text);
            this.Visibility = Visibility.Hidden;
            username.Show();
        }
        public void Login_Click(object sender, RoutedEventArgs e)
        {
            bool Pass = DataAccess.Signin(txt_Username.Text,txt_Password.Text);
            if (Pass)
            {                
               MainOpen();
            }
            else 
            {
                MessageBox.Show("username or password you entered is incorrect");
            }
        }

        private void Btn_AddUser_Click(object sender, RoutedEventArgs e)
        {
            //1.Call DataAccess Check User 
            bool isUnique = DataAccess.Username_Check(txt_UserName_SignUp.Text);
            //2.condition = false => Show Message Dupplicate => end 
            if (!isUnique)
            {
                MessageBox.Show("Dupplicate");
                return;
            }
            
                //3. true Call Add
                DataAccess.AddUser(txt_UserName_SignUp.Text, txt_Password_SignUp.Text);
                MessageBox.Show("Sign Up Successful");          
        }
    }
}
