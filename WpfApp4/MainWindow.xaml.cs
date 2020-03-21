using System;
using System.Collections.Generic;
using System.Linq;
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

namespace WpfApp4
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        DateTime datetime = new DateTime(2020, 3, 4, 18, 6, 0);
        Timer timer;
        public MainWindow()
        {           
            InitializeComponent();
            if (datetime.Subtract(DateTime.Now).TotalSeconds <= 0)
            {
                StartTimerLabel.Content = "0 дней 0 часов и 0 минут до старта марафона!";
            }
            else
            {
                timer = new Timer(datetime.Subtract(DateTime.Now).TotalSeconds * 1000);
                timer.Interval = 1 * 1000;
                timer.Elapsed += Timer_Elapsed;
                timer.Start();
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
    }
}
