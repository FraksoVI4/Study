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
using WpfApp4.Model;

namespace WpfApp4
{
    /// <summary>
    /// Логика взаимодействия для RegistrationPage.xaml
    /// </summary>
    public partial class RegistrationPage : Page
    {
        Context context = new Context();
        private Frame Mainframe;
        public RegistrationPage(Frame frame)
        {
            Mainframe = frame;
            InitializeComponent();
            datePicker.SelectedDate = DateTime.Now;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Mainframe.GoBack();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Mainframe.GoBack();
        }

        private void RegistrationButton_Click(object sender, RoutedEventArgs e)
        {
            Runner runner = new Runner();
            runner.Email = EmailBox.Text;
            runner.Password = FirstPasswordBox.Password;
            runner.FirstName = FirstName.Text;
            runner.LastName = LastName.Text;
            runner.Gender = ((TextBlock)GenderBox.SelectedItem).Text;
            runner.BirthDate = datePicker.SelectedDate.Value;
            runner.Country = ((TextBlock)CountryBox.SelectedItem).Text;
           if (ValidationCheck(runner))
            {
                if (context.Runners.Where(o => o.Email == runner.Email).FirstOrDefault() != null)
                {
                    MessageBox.Show("Пользователь с таким Email уже есть.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                else
                {
                    context.Runners.Add(runner);
                    context.SaveChanges();
                    MainWindow.Authorize(runner);
                }
                
            }
            
        }
        private bool ValidationCheck(Runner runner)
        {
            if (!ValidationEmail(runner.Email))
            {
                MessageBox.Show("Некорректный Email", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            if (runner.Password == "")
            {
                MessageBox.Show("Не введён пароль", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            if (runner.Password.Length <= 6 || runner.Password.Length >= 64)
            {
                MessageBox.Show("Пароль должен быть длиннее 6 символов и короче 64 символов", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
           if (runner.Password != SecondPasswordBox.Password)
            {
                MessageBox.Show("Пароли не совпадают", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
           if (runner.FirstName == "" || runner.LastName == "")
            {
                MessageBox.Show("Не заполнены имя или фамилия", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
           if (runner.BirthDate.AddYears(18) >= DateTime.Now)
            {
                MessageBox.Show("К соревнованиям допускаются только участники, достигшие 18 лет", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            return true;

        }
        private bool ValidationEmail(string email)
        {
            try
            {
                var adress = new System.Net.Mail.MailAddress(email);
                return adress.Address == email;
            } catch
            {
                return false;
            }
        }
    }
}
