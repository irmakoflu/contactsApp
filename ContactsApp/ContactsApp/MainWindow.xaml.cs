using ContactsApp.Classes;
using System.Text;
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
        List<Contacts> contacts;
        public MainWindow()
        {
            InitializeComponent();
            contacts = new List<Contacts>();
            ReadDataBase();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            NewContactsWindow newContactsWindow = new NewContactsWindow();
            newContactsWindow.ShowDialog();
            ReadDataBase();
        }
        void ReadDataBase()
        {
           

            using (SQLite.SQLiteConnection conn = new SQLite.SQLiteConnection(App.databasePath))
            {
                conn.CreateTable<Contacts>();
              contacts=(conn.Table<Contacts>().ToList()).OrderBy(c=> c.name).ToList();
            };
            if (contacts != null) {
               /* foreach (var c in contacts)
                {
                    ContactsLİstView.Items.Add(new ListViewItem()
                    {
                        Content = c
                    });

                } Bu şekilde tekrar tekrar yazıyor*/
               ContactsLİstView.ItemsSource = contacts;

            }

        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox searchtextbox = sender as TextBox;
            var filteredList=contacts.Where(c=> c.name.ToLower().Contains(searchtextbox.Text.ToLower())).ToList();  
            ContactsLİstView.ItemsSource= filteredList;

           /* var filteredlist2=(from c2 in contacts
                               where c2.name.ToLower().Contains(searchtextbox.Text.ToLower())
                               orderby c2.email
                select c2.Id).ToList();*/
        }

        private void ContactsLİstView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Contacts selectedcontact = (Contacts)ContactsLİstView.SelectedItem;

            if (selectedcontact != null)
            {
                ContactDetailsWindow contactDetailsWindow=new ContactDetailsWindow(selectedcontact);
                contactDetailsWindow.ShowDialog();
                ReadDataBase();
            }
        }
    }
}