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
            DataContext = (MainWindow)Application.Current.MainWindow;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Mainframe.GoBack();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Mainframe.GoBack();
        }
        public void AuthorizeBlock()
        {
           ((MainWindow)Application.Current.MainWindow).AuthTry--;
            if (!(((MainWindow)Application.Current.MainWindow).AuthTry == 0))
            {
                MessageBox.Show($"Неправильный логин или пароль, осталось {((MainWindow)Application.Current.MainWindow).AuthTry} попыток", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                MessageBox.Show("Неправильный логин или пароль, превышено количество попыток", "Блокировка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
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
                        AuthorizeBlock();                     
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
                        AuthorizeBlock();
                    }
                }
            }
        }
    }
}
