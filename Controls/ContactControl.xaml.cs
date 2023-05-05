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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ContactsApp.Controls
{
    /// <summary>
    /// Interaction logic for ContactControl.xaml
    /// </summary>
    public partial class ContactControl : UserControl
    {


        public Contact Contact
        {
            get { return (Contact)GetValue(contactProperty); }
            set { SetValue(contactProperty, value); }
        }

        // Using a DependencyProperty as the backing store for contact.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty contactProperty =
            DependencyProperty.Register("Contact", typeof(Contact), typeof(ContactControl), new PropertyMetadata(new Contact(){ Name= "Name Lastname", PhoneNum="2552", Email= "dfh@gmail.com"}, SetText));

        public static void SetText(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            //this d will be the attribute of contact control
            ContactControl control= d as ContactControl;

            if(control != null)
            {
                control.nameTextblock.Text =  (e.NewValue as Contact).Name;
                control.emailTextblock.Text = (e.NewValue as Contact).Email;
                control.phoneTextblock.Text = (e.NewValue as Contact).PhoneNum;
            }
        }

        public ContactControl()
        {
            InitializeComponent();
        }
    }
}
