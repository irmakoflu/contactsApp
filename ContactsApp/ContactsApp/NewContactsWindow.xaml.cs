using ContactsApp.Classes;
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

namespace ContactsApp
{
    /// <summary>
    /// Interaction logic for NewContactsWindow.xaml
    /// </summary>
    public partial class NewContactsWindow : Window
    {
        public NewContactsWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Contacts  Contacts =new Contacts()
            {
name=nameTextBox.Text,
email=emailTextBox.Text,
phone=phoneTextBox.Text,
            };


           using( SQLiteConnection connection = new SQLiteConnection(App.databasePath))
                {
                connection.CreateTable<Contacts>();
                connection.Insert(Contacts);
                //connection.Close(); her actigimizda yeni bir sql baglantisi gerekir bu kod satırı işe yarasa da daha verimli yolu vardır onu kullanacağım.
            };
            this.Close();
        }
    }
}
