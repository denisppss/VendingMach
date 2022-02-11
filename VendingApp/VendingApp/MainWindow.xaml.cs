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

namespace VendingApp
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            myframe.Navigate(new Glavnaya());
            manage.myframe = myframe;
        }
        int actualcoin = 0;
        private void btnback_click(object sender, RoutedEventArgs e)
        {
            manage.myframe.GoBack();
        }

        private void myframe_Navigated(object sender, NavigationEventArgs e)
        {

        }

        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void btn1(object sender, RoutedEventArgs e)
        {
            actualcoin += 1;
            CoinCount.Content = Convert.ToString(actualcoin) + "руб";
        }

        private void btn2(object sender, RoutedEventArgs e)
        {
            actualcoin += 2;
            CoinCount.Content = Convert.ToString(actualcoin) + "руб";
        }

        private void btn5(object sender, RoutedEventArgs e)
        {
            actualcoin += 5;
            CoinCount.Content = Convert.ToString(actualcoin) + "руб";
        }

        private void btn10(object sender, RoutedEventArgs e)
        {
            actualcoin += 10;
            CoinCount.Content = Convert.ToString(actualcoin) + "руб";
        }
    }
}
