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
        DateTime date = new DateTime(2020, 3, 5, 17, 35, 0);
        Timer startTimer;

        public MainWindow()
        {
            InitializeComponent();
            MainFrame.Navigate(new MainPage(MainFrame));

            if (date.Subtract(DateTime.Now).TotalSeconds >= 1)
            {
                startTimer = new Timer(date.Subtract(DateTime.Now).TotalSeconds * 1000);
                startTimer.Interval = 1 * 1000;
                startTimer.Elapsed += Update;
                startTimer.Start();
            }
            else
            {
                MessageBox.Show("Соревнования начались!");
            }
        }

        public void Update(object sender, ElapsedEventArgs e)
        {
            Dispatcher.BeginInvoke(new Action(
                () => {
                    var t = date.Subtract(DateTime.Now);
                    StartTimerLabel.Content = $"{t.Days} дней {t.Hours} часов {t.Minutes} минут и {t.Seconds} секунд до старта марафона!";

                    if(t.TotalSeconds <= 1)
                    {
                        startTimer.Dispose();
                        MessageBox.Show("Соревнования начались!");
                    }
                    }
                ));
        }
    }
}
