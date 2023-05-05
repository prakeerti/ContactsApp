using ContactsApp.Classes;
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
using System.Data.SqlClient;
using SQLite;

namespace ContactsApp
{
    /// <summary>
    /// Interaction logic for ContactDetailsWindow.xaml
    /// </summary>
    public partial class ContactDetailsWindow : Window
    {
        Contact contact;
        public ContactDetailsWindow(Contact contact)
        {
            //whenever we will use this details window oit was always need a contact as parameter 
            InitializeComponent();
            Owner = Application.Current.MainWindow;
            WindowStartupLocation = WindowStartupLocation.CenterOwner; 
            this.contact= contact;
            nameTextbox.Text= contact.Name;
            phoneTextbox.Text = contact.PhoneNum;
            emailTextbox.Text = contact.Email;
        }

        private void updateButton_Click(object sender, RoutedEventArgs e)
        {
            contact.Name= nameTextbox.Text; 
            //now here we are assigning the text in text boxes to this contact properties
            contact.Email= emailTextbox.Text;
            contact.PhoneNum= phoneTextbox.Text;
            using (SQLiteConnection connection = new SQLiteConnection(App.databasePath))
            {
                connection.CreateTable<Contact>();
                connection.Update(contact);
                //to delete an item it is necessary to pass and id to give reference as to which element should be deleted 
            };

            Close();

        }

        private void deleteButton_Click(object sender, RoutedEventArgs e)
        {
            using (SQLiteConnection connection = new SQLiteConnection(App.databasePath))
            {
                connection.CreateTable<Contact>();
                connection.Delete(contact);
                //to delete an item it is necessary to pass and id to give reference as to which element should be deleted 
            };

            Close();
        }
    }
}
