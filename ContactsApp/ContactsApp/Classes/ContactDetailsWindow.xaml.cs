using SQLite;
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

namespace ContactsApp.Classes
{
    /// <summary>
    /// Interaction logic for ContactDetailsWindow.xaml
    /// </summary>
    public partial class ContactDetailsWindow : Window
    {
        Contacts contact;
        public ContactDetailsWindow(Contacts contact)
        {
            InitializeComponent();
            this.contact = contact;
            nameTextBox.Text=contact.name;
            emailTextBox.Text=contact.email;
            phoneNumberTextBox.Text=contact.phone;
        }
        private void updateButton_Click(object sender, RoutedEventArgs e)
        {
            contact.name = nameTextBox.Text;
            contact.email = emailTextBox.Text;
            contact.phone = phoneNumberTextBox.Text;
            using (SQLiteConnection connection = new SQLiteConnection(App.databasePath))
            {
                connection.CreateTable<Contacts>();
                connection.Update(contact);
            }

            Close();

        }

        private void deleteButton_Click(object sender, RoutedEventArgs e)
        {
            using (SQLiteConnection connection = new SQLiteConnection(App.databasePath))
            {
                connection.CreateTable<Contacts>();
                connection.Delete(contact);
            }

            Close();
        }
    }
}
