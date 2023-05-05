using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace ContactsApp  
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        //where database will be created
        static string databaseName = "Contacts.db";
        //this folder path refers to the folder whwre we will store our database and access database
        //using the in build environment class
        static string folderPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

        //generating the path for the database
        public static string databasePath = System.IO.Path.Combine(folderPath, databaseName);
    }
}
