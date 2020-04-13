using Microsoft.Win32;
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
    /// Логика взаимодействия для SecondPage.xaml
    /// </summary>
    public partial class SecondPage : Page
    {
        private Frame Mainframe;
        public SecondPage(Frame frame)
        {
            InitializeComponent();
            Mainframe = frame;
        }

        private void ButtonGoBack_Click(object sender, RoutedEventArgs e)
        {
            Mainframe.GoBack();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Mainframe.GoBack();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Mainframe.Navigate(new Page1(Mainframe));
        }

        private void SecondPageLogin_Click(object sender, RoutedEventArgs e)
        {
            Mainframe.Navigate(new Page1(Mainframe)); 
            //var dialog = new OpenFileDialog();
            //if (dialog.ShowDialog() == true)
            //{               
            //    BitmapImage image = new BitmapImage(new Uri(dialog.FileName));
            //    SecondPageImage.Source = image;
            //}
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            Mainframe.Navigate(new RegistrationPage(Mainframe));
        }
    }
}
