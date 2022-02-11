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
    /// Логика взаимодействия для DrinksView.xaml
    /// </summary>
    public partial class DrinksView : UserControl
    {
        public DrinksView(SqlDataReader reader, MainWindow r301)
        {
            InitializeComponent();
            NameDr.Content = reader["Name"].ToString();
            CostDr.Content = reader["Cost"].ToString();
            //ImageDr.Source = reader["ImageDr"].ToString();
        }
    }
}
