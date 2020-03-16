using System;
using System.Collections.Generic;
using System.ComponentModel;
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

namespace WpfApp4
{
    /// <summary>
    /// Логика взаимодействия для RoleForAuthorizationWindow.xaml
    /// </summary>
    public partial class RoleForAuthorizationWindow : Window
    {
        public string Role;
        public RoleForAuthorizationWindow()
        {
            InitializeComponent();
        }

        private void RunnerBtn_Click(object sender, RoutedEventArgs e)
        {
            Role = "Runner";
            this.DialogResult = true;
        }

        private void CoordinatorBtn_Click(object sender, RoutedEventArgs e)
        {
            Role = "Coordinator";
            this.DialogResult = true;
        }

        private void AdminBtn_Click(object sender, RoutedEventArgs e)
        {
            Role = "Admin";
            this.DialogResult = true;
        }

    }
}
