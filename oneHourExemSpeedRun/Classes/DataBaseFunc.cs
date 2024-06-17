using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using oneHourExemSpeedRun.Entity;

namespace oneHourExemSpeedRun.Classes
{
    public class DataBaseFunc
    {
        private static TestRunEntities db = Helper.GetContext();

        public static string Authentication(string login, string password)
        {
            var AuthUser = db.UserAuth.FirstOrDefault(x => x.login == login && x.password == password);

            return AuthUser?.UserRole.role;
        }

        public static List<Service> GetServices()
        {
            return db.Service.ToList();
        }

        public static List<Orders> GetOrders()
        {
            return db.Orders.ToList();
        }

        public static void AddOrder(int ID, string FirstName, string LastName, string SecondName, DateTime? selectedDate)
        {
            try
            {

                var NewOrder = new Orders
                {
                    id = db.Orders.Count() + 1,
                    service = ID,
                    firstname = FirstName,
                    secondname = SecondName,
                    lastname = LastName,
                    dategetorder = selectedDate
                };
                db.Orders.Add(NewOrder);
                db.SaveChanges();
                MessageBox.Show("Запись была добавлена в базу данных!", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception ex) {
                MessageBox.Show($"Ошибка:{ex.Message}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
