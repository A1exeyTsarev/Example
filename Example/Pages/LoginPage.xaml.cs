using Example.AppData;
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

namespace Example.Pages
{
    /// <summary>
    /// Логика взаимодействия для LoginPage.xaml
    /// </summary>
    public partial class LoginPage : Page
    {
        public LoginPage()
        {
            InitializeComponent();
        }
            public static int CurrentUserId;
            public static string CurrentRoleName;

        private void ButLogin_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(LoginBox.Text) || string.IsNullOrEmpty(PasswordBox.Password))
                {
                    MessageBox.Show("Введите логин и пароль", "Ошибка", 
                        MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }

                var user =AppConnect.model1.Users.FirstOrDefault(x => x.Login == LoginBox.Text && x.Password==PasswordBox.Password);

                if (user == null)
                {
                    MessageBox.Show("Неверный логин или пароль", "Ошибка", 
                        MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }

                CurrentUserId = user.User_Id;
                CurrentRoleName = user.Roles.RoleName;

                MessageBox.Show($"Добро пожаловать, {user.UserFullName}! "+$"Роль, {user.Roles.RoleName}", "Успех", 
                    MessageBoxButton.OK, MessageBoxImage.Information);

                AppFrame.MainFrame.Navigate(new BookPage());
            }
            catch (Exception ex) 
            
            {
                MessageBox.Show($"Ошибка: {ex.Message}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
