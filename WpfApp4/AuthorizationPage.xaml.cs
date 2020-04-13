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

namespace WpfApp4
{
    /// <summary>
    /// Логика взаимодействия для Page1.xaml
    /// </summary>
    public partial class Page1 : Page
    {
        Context context = new Context();
        private Frame Mainframe;
        public Page1(Frame frame)
        {
            Mainframe = frame;
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Mainframe.GoBack();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Mainframe.GoBack();
        }

        private void LoginBtn_Click(object sender, RoutedEventArgs e)
        {
            var window = new RoleForAuthorizationWindow();
            if (window.ShowDialog() == true)
            {
               if (window.Role == "Runner")
                {
                    var runner = context.Runners.Where(o => o.Email == Login.Text && o.Password == Password.Password).SingleOrDefault();
                    if (runner != null)
                    {
                        MainWindow.Authorize(runner);
                        
                    }
                    else
                    {
                        MessageBox.Show("Неправильный логин или пароль.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
               else if (window.Role == "Admin")
                {
                    var admin = context.Admins.Where(o => o.Email == Login.Text && o.Password == Password.Password).SingleOrDefault();
                    if (admin != null)
                    {
                        MainWindow.Authorize(admin);
                    }
                    else
                    {
                        MessageBox.Show("Неправильный логин или пароль.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
            }
        }
    }
}
