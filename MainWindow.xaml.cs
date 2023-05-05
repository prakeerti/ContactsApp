using ContactsApp.Classes;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ContactsApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //ObservableCollection<Contact> contacts;
        List<Contact> contacts;




        public MainWindow()
        {
            InitializeComponent();
            contacts = new List<Contact>();
            //when main window initialise, I want to read the database components
            //contactsListView.Items.Clear();
            //contactsListView.ItemsSource = contacts;
            ReadDatabase();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //to open a window a from main window
            NewContactWindow newContactWindow = new NewContactWindow();
            newContactWindow.ShowDialog();

            ReadDatabase();

           // contacts.Add(new Contact { Email = "asas@gmail.com", Name = "sdsd", PhoneNum = "123545656" });

        }
        void ReadDatabase()
        {
            /*using (SQLite.SQLiteConnection conn = new SQLite.SQLiteConnection(App.databasePath))
            {
                conn.CreateTable<Contact>();

                contacts.Clear();

                foreach(var c in conn.Table<Contact>())
                {
                    //contactsListView.Items.Add(c);
                    contacts.Add(c);
                }
               
            }*/
            using (SQLite.SQLiteConnection conn = new SQLite.SQLiteConnection(App.databasePath))
            {
                conn.CreateTable<Contact>();
                contacts = (conn.Table<Contact>().ToList()).OrderBy(c=> c.Name).ToList();
            }

            if (contacts != null)
            {
                contactsListView.ItemsSource = contacts;
            }

            //contacts.Add(new Contact { Email="asas@gmail.com", Name="sdsd",PhoneNum= "123545656"});

        }

        private void Textbox_Textchange(object sender, TextChangedEventArgs e)
        {
            //to implement the searchbox we need the contactslist object and the textbox itself
            /*TextBox searchTextbox= sender as TextBox;
            var filteredList= contacts.Where(c=> c.Name.Contains(searchTextbox.Text)).ToList();
            
            //contactsListView.Items.Clear();

            contactsListView.ItemsSource= filteredList;*/

            TextBox searchTextBox = sender as TextBox;

            var filteredList = contacts.Where(c => c.Name.ToLower().Contains(searchTextBox.Text.ToLower())).ToList();

            contactsListView.ItemsSource = filteredList;
        }

        private void contactListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Contact selectedContact = (Contact)contactsListView.SelectedItem;
            if(selectedContact != null) 
            {
                ContactDetailsWindow contactDetailsWindow = new ContactDetailsWindow(selectedContact);
                contactDetailsWindow.ShowDialog();

                ReadDatabase();
            }
        }
    }
}
