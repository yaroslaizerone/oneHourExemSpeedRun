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
    /// Логика взаимодействия для UserService.xaml
    /// </summary>
    public partial class UserService : Window
    {
        public UserService()
        {
            InitializeComponent();
            var listService = DataBaseFunc.GetServices();
            cmbService.ItemsSource = listService;
        }
        
        private void btnAddOrder_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show($"Запись быых!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);

            try
            {

                int IdService = (int) cmbService.SelectedIndex + 1;
                string FirstName = tbFirstName.Text;
                string LastName = tbLastName.Text;
                string SecondName = tbSecondName.Text;
                DateTime? selectedDate = dpDateGetOrder.SelectedDate;

                if (IdService != -1 && !string.IsNullOrEmpty(FirstName) && !string.IsNullOrEmpty(SecondName) && selectedDate.HasValue)
                {
                    DataBaseFunc.AddOrder(IdService, FirstName, LastName, SecondName, selectedDate.Value);
                }
                else
                {
                    MessageBox.Show("Пожалуйста, заполните все поля!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка:{ex.Message}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

    } 
}
