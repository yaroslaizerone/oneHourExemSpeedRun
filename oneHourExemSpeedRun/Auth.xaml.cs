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
using oneHourExemSpeedRun.Classes;

namespace oneHourExemSpeedRun
{
    /// <summary>
    /// Логика взаимодействия для Auth.xaml
    /// </summary>
    public partial class Auth : Window
    {
        public Auth()
        {
            InitializeComponent();
        }

        private void btnAuth_Click(object sender, RoutedEventArgs e)
        {
            try
            {

                string UserLogin = tbLogin.Text;
                string UserPassword = tbPassword.Text;

                if (string.IsNullOrEmpty(UserLogin) || string.IsNullOrEmpty(UserPassword))
                {
                    MessageBox.Show($"Неверные данные авторизации!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
                string SystemRole = DataBaseFunc.Authentication(UserLogin, UserPassword);

                switch (SystemRole)
                {   
                    case "Администратор":
                        var adminpanel = new AdminPanel();
                        adminpanel.Show();
                        this.Close();
                        MessageBox.Show("Авторизация прошла успешна, вы зашли под ролью администратора", "Информация", MessageBoxButton.OK, MessageBoxImage.Information);
                        break;
                    case "Пользователь":
                        var userservice = new UserService();
                        userservice.Show();
                        this.Close();
                        MessageBox.Show("Авторизация прошла успешна, вы зашли под ролью пользователя", "Информация", MessageBoxButton.OK, MessageBoxImage.Information);
                        break;
                }
            }
            catch (Exception ex) { 
                MessageBox.Show($"Ошибка:{ex.Message}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
