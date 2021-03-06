﻿using System;
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
    /// Логика взаимодействия для MainPage.xaml
    /// </summary>
    public partial class MainPage : Page
    {
        private Frame Mainframe;
        public MainPage(Frame frame)
        {
            InitializeComponent();
            Mainframe = frame;
        }

        private void GoSecondPageButton_Click(object sender, RoutedEventArgs e)
        {
           
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Mainframe.Navigate(new SecondPage(Mainframe));
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Mainframe.Navigate(new Page1(Mainframe));
        }
    }
}
