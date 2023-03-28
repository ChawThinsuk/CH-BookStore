using Microsoft.Data.Sqlite;
using System;

namespace CHBookStore
{
    internal class DataAccess
    {
        public async static void InitializeDatabase()
        {
            using (SqliteConnection db =
               new SqliteConnection($"Filename=BookStore.db"))
            {
                db.Open();
//           string droptablecommand = "drop table Customers ";
//           SqliteCommand droptable = new SqliteCommand(droptablecommand, db);
//           droptable.ExecuteReader();
                String tableCommand = "CREATE TABLE IF NOT EXISTS Books (ISBN INTEGER PRIMARY KEY," +
                    "Title NVARCHAR(50) ,Description NVARCHAR(200) NULL,Price INTEGER);" +
                    "CREATE TABLE IF NOT EXISTS Customers (Customer_Id INTEGER PRIMARY KEY," +
                    "Customer_Name NVARCHAR(50) ,Address TEXT ,Email NVARCHAR(50));" +
                    "CREATE TABLE IF NOT EXISTS Transactions (ReceiptNo NVARCHAR(50) PRIMARY KEY, ISBN INTEGER ," +
                    "Customer_Id INTEGER ,Quantity INTEGER ,Total_Price INTEGER);" +
                    "CREATE TABLE IF NOT EXISTS User(Username NVARCHAR(20),Password NVARCHAR(20));";
              SqliteCommand createTable = new SqliteCommand(tableCommand, db);
              createTable.ExecuteReader();
            }
        }
// Add BookData,CustomerData,TransactionData
        public static void AddBookData(string ISBN, string Title, string Description, string Price)
        {
            using (SqliteConnection db =
              new SqliteConnection($"Filename=BookStore.db"))
            {
                db.Open();
                SqliteCommand insertCommand = new SqliteCommand();
                insertCommand.Connection = db;

                insertCommand.CommandText = "INSERT INTO Books VALUES (@ISBN, @Title, @Description, @Price);";
                insertCommand.Parameters.Add(new SqliteParameter("@ISBN", ISBN));
                insertCommand.Parameters.Add(new SqliteParameter("@Title", Title));
                insertCommand.Parameters.Add(new SqliteParameter("@Description", Description));
                insertCommand.Parameters.Add(new SqliteParameter("@Price", Price));

                insertCommand.ExecuteReader();

                db.Close();

            }
        }
        public static void AddCustomerData(string Customer_Id, string Customer_Name, string Address, string Email)
        {
            using (SqliteConnection db =
              new SqliteConnection($"Filename=BookStore.db"))
            {
                db.Open();
                SqliteCommand insertCommand = new SqliteCommand();
                insertCommand.Connection = db;

                insertCommand.CommandText = "INSERT INTO Customers VALUES (@Customer_Id, @Customer_Name, @Address, @Email);";
                insertCommand.Parameters.Add(new SqliteParameter("@Customer_Id", Customer_Id));
                insertCommand.Parameters.Add(new SqliteParameter("@Customer_Name", Customer_Name));
                insertCommand.Parameters.Add(new SqliteParameter("@Address", Address));
                insertCommand.Parameters.Add(new SqliteParameter("@Email", Email));

                insertCommand.ExecuteReader();

                db.Close();

            }
        }
        public static void AddTransactionData(string ISBN, string Customer_Id, string Quantity, string Total_Price)
        {
            using (SqliteConnection db =
              new SqliteConnection($"Filename=BookStore.db"))
            {
                db.Open();
                SqliteCommand insertCommand = new SqliteCommand();
                insertCommand.Connection = db;
                Guid RandomId = Guid.NewGuid();
                insertCommand.CommandText = "INSERT INTO Transactions VALUES (@ReceiptNo, @ISBN, @Customer_Id, @Quantity, @Total_Price);";
                insertCommand.Parameters.Add(new SqliteParameter("@ReceiptNo", RandomId.ToString()));
                insertCommand.Parameters.Add(new SqliteParameter("@ISBN", ISBN));
                insertCommand.Parameters.Add(new SqliteParameter("@Customer_Id", Customer_Id));
                insertCommand.Parameters.Add(new SqliteParameter("@Quantity", Quantity));
                insertCommand.Parameters.Add(new SqliteParameter("@Total_Price", Total_Price));

                insertCommand.ExecuteReader();

                db.Close();

            }
        }
        //Check User,CustomerId,ISBN
        public static bool Username_Check(string Username)
        {
            using (SqliteConnection db =
               new SqliteConnection($"Filename=BookStore.db"))
            {
                db.Open();
                SqliteCommand selectCommand = new SqliteCommand
                    ("SELECT * from User WHERE UPPER(Username) = UPPER(@Username) ", db);
                selectCommand.Parameters.Add(new SqliteParameter("@Username", Username));
                SqliteDataReader query = selectCommand.ExecuteReader();
                bool Username_Check = true;
                while (query.Read())
                {
                    Username_Check = false;
                }
                db.Close();
                return Username_Check;
            }

        }
        public static bool ISBN_Check(string ISBN)
        {
            using (SqliteConnection db =
               new SqliteConnection($"Filename=BookStore.db"))
            {
                db.Open();
                SqliteCommand selectCommand = new SqliteCommand
                    ("SELECT * from Books WHERE ISBN = @ISBN ", db);
                selectCommand.Parameters.Add(new SqliteParameter("@ISBN", ISBN));
                SqliteDataReader query = selectCommand.ExecuteReader();
                bool ISBN_Check = false;
                while (query.Read())
                {
                    ISBN_Check = true;
                }
                db.Close();
                return ISBN_Check;
            }

        }
        public static bool CustomerId_Check(string Customer_Id)
        {
            using (SqliteConnection db =
               new SqliteConnection($"Filename=BookStore.db"))
            {
                db.Open();
                SqliteCommand selectCommand = new SqliteCommand
                    ("SELECT * from Customers WHERE Customer_Id = @Customer_Id ", db);
                selectCommand.Parameters.Add(new SqliteParameter("@Customer_Id", Customer_Id));
                SqliteDataReader query = selectCommand.ExecuteReader();
                bool CustomerId_Check = false;
                while (query.Read())
                {
                    CustomerId_Check = true;
                }
                db.Close();
                return CustomerId_Check;
            }

        }

        // Add User,SignIn
        public static void AddUser(string Username, string Password)
        {
            using (SqliteConnection db =
              new SqliteConnection($"Filename=BookStore.db"))
            {
                db.Open();
                SqliteCommand insertCommand = new SqliteCommand();
                insertCommand.Connection = db;

                insertCommand.CommandText = "INSERT INTO User VALUES (@Username, @Password);";
                insertCommand.Parameters.Add(new SqliteParameter("@Username", Username));
                insertCommand.Parameters.Add(new SqliteParameter("@Password", Password));
                insertCommand.ExecuteReader();

                db.Close();

            }
        }
        public static bool Signin(string Username, string Password)
        {
            using (SqliteConnection db =
               new SqliteConnection($"Filename=BookStore.db"))
            {
                db.Open();
                SqliteCommand selectCommand = new SqliteCommand
                    ("SELECT * from User WHERE UPPER(Username) = UPPER(@Username) and Password = @Password  ", db);
                selectCommand.Parameters.Add(new SqliteParameter("@Username", Username));
                selectCommand.Parameters.Add(new SqliteParameter("@Password", Password));
                SqliteDataReader query = selectCommand.ExecuteReader();
                bool Sign = false;
                while (query.Read())
                {
                    Sign = true;
                }
                db.Close();
                return Sign;
            }

        }

        // DeleteCustomerData,BookData    
        public static void DeleteCustomerData(string Customer_Id)
        {
            using (SqliteConnection db =
              new SqliteConnection($"Filename=BookStore.db"))
            {
                db.Open();
                SqliteCommand insertCommand = new SqliteCommand();
                insertCommand.Connection = db;

                insertCommand.CommandText = "DELETE FROM Customers WHERE Customer_Id = @Customer_Id;";
                insertCommand.Parameters.Add(new SqliteParameter("@Customer_Id", Customer_Id));
                insertCommand.ExecuteReader();

                db.Close();

            }
        }
        public static void DeleteBookData(string ISBN)
        {
            using (SqliteConnection db =
              new SqliteConnection($"Filename=BookStore.db"))
            {
                db.Open();
                SqliteCommand insertCommand = new SqliteCommand();
                insertCommand.Connection = db;

                insertCommand.CommandText = "DELETE FROM Books WHERE Customer_Name = @ISBN;";
                insertCommand.Parameters.Add(new SqliteParameter("@ISBN", ISBN));
                insertCommand.ExecuteReader();

                db.Close();

            }
        }
        //Update Customer Data,Book Data
        public static void bookUpdate(string ISBN, string Title, string Description, string Price)
        {
            using (SqliteConnection db =
              new SqliteConnection($"Filename=BookStore.db"))
            {
                db.Open();
                SqliteCommand insertCommand = new SqliteCommand();
                insertCommand.Connection = db;

                insertCommand.CommandText = "UPDATE Books SET Title = @Title, Description = @Description, Price = @Price" +
                    " WHERE ISBN = @ISBN;";
                insertCommand.Parameters.Add(new SqliteParameter("@ISBN", ISBN));
                insertCommand.Parameters.Add(new SqliteParameter("@Title", Title));
                insertCommand.Parameters.Add(new SqliteParameter("@Description", Description));
                insertCommand.Parameters.Add(new SqliteParameter("@Price", Price));
                insertCommand.ExecuteReader();

                db.Close();

            }
        }
        public static void CustomerUpdate(string Customer_Id, string Customer_Name, string Address, string Email)
        {
            using (SqliteConnection db =
              new SqliteConnection($"Filename=BookStore.db"))
            {
                db.Open();
                SqliteCommand insertCommand = new SqliteCommand();
                insertCommand.Connection = db;

                insertCommand.CommandText = "UPDATE Customers SET Customer_Name = @Customer_Name, Address = @Address, Email = @Email" +
                    " WHERE Customer_Id = @Customer_Id;";
                insertCommand.Parameters.Add(new SqliteParameter("@Customer_Id", Customer_Id));
                insertCommand.Parameters.Add(new SqliteParameter("@Customer_Name", Customer_Name));
                insertCommand.Parameters.Add(new SqliteParameter("@Address", Address));
                insertCommand.Parameters.Add(new SqliteParameter("@Email", Email));
                insertCommand.ExecuteReader();

                db.Close();

            }
        }

        //Where Title, Description, Price in ShowBookInformation

        public static string Title_Where(string ISBN)
        {
            using (SqliteConnection db =
              new SqliteConnection($"Filename=BookStore.db"))
            {
                db.Open();
                SqliteCommand selectCommand = new SqliteCommand();
                selectCommand.Connection = db;

                selectCommand.CommandText = "SELECT Title FROM Books WHERE ISBN = @ISBN";
                selectCommand.Parameters.Add(new SqliteParameter("@ISBN", ISBN));
                string colTitleValue = "";
                SqliteDataReader query = selectCommand.ExecuteReader();
                while (query.Read())
                {
                    colTitleValue = query["Title"].ToString();
                }

                db.Close();
                return colTitleValue;
            }
        }
        public static string Description_Where(string ISBN)
        {
            using (SqliteConnection db =
              new SqliteConnection($"Filename=BookStore.db"))
            {
                db.Open();
                SqliteCommand selectCommand = new SqliteCommand();
                selectCommand.Connection = db;

                selectCommand.CommandText = "SELECT * FROM Books WHERE ISBN = @ISBN";
                selectCommand.Parameters.Add(new SqliteParameter("@ISBN", ISBN));
                string colDescriptionValue = "";
                SqliteDataReader query = selectCommand.ExecuteReader();
                while (query.Read())
                {
                    colDescriptionValue = query["Description"].ToString();
                }

                db.Close();
                return colDescriptionValue;
            }
        }
        public static string Price_Where(string ISBN)
        {
            using (SqliteConnection db =
              new SqliteConnection($"Filename=BookStore.db"))
            {
                db.Open();
                SqliteCommand selectCommand = new SqliteCommand();
                selectCommand.Connection = db;

                selectCommand.CommandText = "SELECT Price FROM Books WHERE ISBN = @ISBN";
                selectCommand.Parameters.Add(new SqliteParameter("@ISBN", ISBN));

                string colPriceValue = "";
                SqliteDataReader query = selectCommand.ExecuteReader();
                while (query.Read())
                {
                    colPriceValue = query["Price"].ToString();
                }

                db.Close();
                return colPriceValue;

            }
        }
//Where Customer_Name, Address, Email in ShowBookInformation
        public static string CustomerName_Where(string Customer_Id)
        {
            using (SqliteConnection db =
              new SqliteConnection($"Filename=BookStore.db"))
            {
                db.Open();
                SqliteCommand selectCommand = new SqliteCommand();
                selectCommand.Connection = db;

                selectCommand.CommandText = "SELECT Customer_Name FROM Customers WHERE Customer_Id = @Customer_Id";
                selectCommand.Parameters.Add(new SqliteParameter("@Customer_Id", Customer_Id));

                string colCustomerNameValue = "";
                SqliteDataReader query = selectCommand.ExecuteReader();
                while (query.Read())
                {
                    colCustomerNameValue = query["Customer_Name"].ToString();
                }

                db.Close();
                return colCustomerNameValue;

            }
        }
        public static string Address_Where(string Customer_Id)
        {
            using (SqliteConnection db =
              new SqliteConnection($"Filename=BookStore.db"))
            {
                db.Open();
                SqliteCommand selectCommand = new SqliteCommand();
                selectCommand.Connection = db;

                selectCommand.CommandText = "SELECT Address FROM Customers WHERE Customer_Id = @Customer_Id";
                selectCommand.Parameters.Add(new SqliteParameter("@Customer_Id", Customer_Id));

                string colAddressValue = "";
                SqliteDataReader query = selectCommand.ExecuteReader();
                while (query.Read())
                {
                    colAddressValue = query["Address"].ToString();
                }

                db.Close();
                return colAddressValue;

            }
        }
        public static string Email_Where(string Customer_Id)
        {
            using (SqliteConnection db =
              new SqliteConnection($"Filename=BookStore.db"))
            {
                db.Open();
                SqliteCommand selectCommand = new SqliteCommand();
                selectCommand.Connection = db;

                selectCommand.CommandText = "SELECT Email FROM Customers WHERE Customer_Id = @Customer_Id";
                selectCommand.Parameters.Add(new SqliteParameter("@Customer_Id", Customer_Id));

                string colEmailValue = "";
                SqliteDataReader query = selectCommand.ExecuteReader();
                while (query.Read())
                {
                    colEmailValue = query["Email"].ToString();
                }

                db.Close();
                return colEmailValue;

            }
        }
    }
}
