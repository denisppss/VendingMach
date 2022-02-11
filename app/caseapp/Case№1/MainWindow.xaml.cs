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
using System.Data.SqlClient;

namespace Case_1
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public int[] coins_add = new int[4];
        VendingMachinesEntities x = new VendingMachinesEntities();
        public MainWindow()
        {
            InitializeComponent();
            var c = x.Drinks.ToList();
            LViewDrinks.ItemsSource = c;

        }

        private void butmenu_Click(object sender, RoutedEventArgs e)
        {
            Admin admin = new Admin();
            admin.Show();
            this.Hide();
        }

        private void b1_Click(object sender, RoutedEventArgs e)
        {
            int clickB = Convert.ToInt32(bcost.Text);
            bcost.Text = Convert.ToString(clickB + 1);
            coins_add[0]++;
        }

        private void b2_Click(object sender, RoutedEventArgs e)
        {
            int clickB = Convert.ToInt32(bcost.Text);
            bcost.Text = Convert.ToString(clickB + 2);
            coins_add[1]++;
        }

        private void b3_Click(object sender, RoutedEventArgs e)
        {
            int clickB = Convert.ToInt32(bcost.Text);
            bcost.Text = Convert.ToString(clickB + 5);
            coins_add[2]++;
        }

        private void b4_Click(object sender, RoutedEventArgs e)
        {
            int clickB = Convert.ToInt32(bcost.Text);
            bcost.Text = Convert.ToString(clickB + 10);
            coins_add[3]++;
        }

        private void b6_Click(object sender, RoutedEventArgs e)
        {
            int a = Convert.ToInt32(bcost.Text);

            var mon1 = x.VendingMachineCoins.Single(m1 => m1.CoinsId == 1);
            var mon2 = x.VendingMachineCoins.Single(m1 => m1.CoinsId == 2);
            var mon5 = x.VendingMachineCoins.Single(m1 => m1.CoinsId == 3);
            var mon10 = x.VendingMachineCoins.Single(m1 => m1.CoinsId == 4);

            int f1 = mon1.Count;
            int f2 = mon2.Count;
            int f5 = mon5.Count;
            int f10 = mon10.Count;

            int[] coins = new int[4];
            coins[0] = 0;
            coins[1] = 0;
            coins[2] = 0;
            coins[3] = 0;
            for (int i = a; i >= 0;)
            {
                if (i >= 10 && f10 > 0)
                {
                    i -= 10;
                    coins[3]++;
                    f10--;
                }
                else
                {
                    if (i >= 5 && f5 > 0)
                    {
                        i -= 5;
                        coins[2]++;
                        f5--;
                    }
                    else
                    {
                        if (i >= 2 && f2 > 0)
                        {
                            i -= 2;
                            coins[1]++;
                            f2--;
                        }
                        else
                        {
                            if (i >= 1 && f1 > 0)
                            {
                                i -= 1;
                                coins[0]++;
                                f1--;
                            }
                            else
                            {
                                if (i == 0)
                                {
                                    MessageBox.Show("Заберите сдачу!");
                                    a = i;
                                    i--;
                                }
                                else
                                {
                                    MessageBox.Show("В аппарате недостаточно средств!");
                                    a = i;
                                    i--;
                                }
                            }
                        }
                    }
                }
            }
            bcost.Text = a.ToString();
            for (int i = 0; i < 4; i++)
            {
                coins[i] = coins[i] - coins_add[i];
            }
            for (int i = 0; i < 4; i++)
            {
                var nowCoin = x.VendingMachineCoins.Single(id => id.CoinsId == (i + 1));
                nowCoin.Count = nowCoin.Count - coins[i];
                x.SaveChanges();
            }

        }

        private void LViewDrinks_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int actuallyCoin = Convert.ToInt32(bcost.Text);


            if (LViewDrinks.SelectedItem != null)
            {
                if (actuallyCoin >= Convert.ToInt32((LViewDrinks.SelectedItem as Drinks).Cost))
                {
                    actuallyCoin -= Convert.ToInt32((LViewDrinks.SelectedItem as Drinks).Cost);

                    bcost.Text = actuallyCoin.ToString();

                }
                else
                {
                    MessageBox.Show("Недостаточно монет на счету!");
                }
            }


            x.SaveChanges();
            LViewDrinks.SelectedItem = null;
        }
    }
        
      
}
