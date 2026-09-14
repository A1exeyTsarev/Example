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
using Example.AppData;
using Example.Pages;

namespace Example.Pages
{
    /// <summary>
    /// Логика взаимодействия для BookPage.xaml
    /// </summary>
    public partial class BookPage : Page
    {
        public BookPage()
        {
            InitializeComponent();
            loadBooks();
            checkRole();

        }
        private void loadBooks()
        {
            try
            {
                var Books = AppConnect.model1.Books.Select(b => new
                {
                    book_id = b.Book_Id,
                    Title = b.Title,
                    Author = b.Author,
                    Year = b.Year,
                    Price = b.Price,

                }).ToList();
                LvBooks.ItemsSource = Books;
            }
            
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки: {ex.Message}");
            }
        }
        private void checkRole()
        {
            if(LoginPage.CurrentRoleName=="Manager")
            {
                BtnAdd.Visibility=Visibility.Visible;
                BtnDelete.Visibility=Visibility.Visible;
                BtnEdit.Visibility=Visibility.Visible;

            }
        }
        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            AppFrame.MainFrame.Navigate(new AddPage());
        }
        private void BtnEdite_Click(object sender, RoutedEventArgs e)
        {
            AppFrame.MainFrame.Navigate(new EditePage());
        }
        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            AppFrame.MainFrame.Navigate(new DeletePage());
        }
        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            AppFrame.MainFrame.Navigate(new LoginPage());
        }
    }
}
