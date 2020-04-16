using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
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
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        private int authTry;
        public int AuthTry
        {
            get
            {
               return authTry;
            }
            set
            {
                authTry = value;
                OnPropertyChanged("AuthTry");
            }
        }
        
        private static Runner _runner;
        private static Admin _admin;
        DateTime datetime = new DateTime(2020, 5, 18, 14, 0, 0);
        Timer timer;
        private Visibility visibility;

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string name = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        public Visibility LogOutVisibility
        {
            get
            {
                return visibility;
            }
            set
            {
                visibility = value;
                OnPropertyChanged("LogOutVisibility");
            }
        }

        public MainWindow()
        {           
            InitializeComponent();
            DataContext = this;
            AuthTry = 3;
            LogOutVisibility = Visibility.Hidden;
            if (datetime.Subtract(DateTime.Now).TotalSeconds <= 0)
            {
                StartTimerLabel.Content = "0 дней 0 часов и 0 минут до старта марафона!";
            }
            else
            {
                var sub = datetime.Subtract(DateTime.Now);
                if (sub.TotalDays > 10)
                {
                    StartTimerLabel.Content = $"{sub.TotalDays:0} дней до старта марафона!";
                }
                else
                {
                    timer = new Timer(sub.TotalSeconds * 1000);
                    timer.Interval = 1 * 1000;
                    timer.Elapsed += Timer_Elapsed;
                    timer.Start();
                }
            }
            MainFrame.Navigate(new MainPage(MainFrame));
        }

        private void Timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            Dispatcher.BeginInvoke(new Action( () => {
                var timeSpan = datetime.Subtract(DateTime.Now);
                StartTimerLabel.Content = $"{timeSpan.Days} дней {timeSpan.Hours} часов и {timeSpan.Minutes} минут до старта марафона!";
                if (timeSpan.TotalSeconds <= 0)
                {
                    timer.Dispose();
                    MessageBox.Show("Марафон начался!");
                }

            }) );
            
        }

        public static void Authorize(Runner runner)
        {
            if (IsAuthorize())
            {
                MessageBox.Show("Вы уже авторизованы", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            _runner = runner;
            MessageBox.Show($"{runner.FirstName} {runner.LastName}, вы вошли в систему под ролью бегуна.");
            ((MainWindow)Application.Current.MainWindow).ShowLogOut();
        }
      
        public static void Authorize(Admin admin)
        {
            if (IsAuthorize())
            {
                MessageBox.Show("Вы уже авторизованы", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);                
                return;
            }    
            
            _admin = admin;
            MessageBox.Show($"{admin.FirstName} {admin.LastName}, вы вошли в систему под ролью администратора.");
            ((MainWindow)Application.Current.MainWindow).ShowLogOut();

        }

        public void HideLogOut()
        {
            LogOutVisibility = Visibility.Hidden;
        }

        public void ShowLogOut()
        {
            LogOutVisibility = Visibility.Visible;
        }

        private static bool IsAuthorize()
        {
            if (_admin != null || _runner != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static void LogOut()
        {
            _runner = null;
            _admin = null;
            ((MainWindow)Application.Current.MainWindow).HideLogOut();
            MessageBox.Show("Вы вышли из системы", "Оповещение", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void LogOutButton_Click(object sender, RoutedEventArgs e)
        {
            LogOut();
        }
    }
}
