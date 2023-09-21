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

namespace SapperByBloodyAlpha.AllPages
{
    /// <summary>
    /// Логика взаимодействия для MapSizeSelector.xaml
    /// </summary>
    public partial class MapSizeSelector : Page
    {
        public MapSizeSelector()
        {
            InitializeComponent();
        }

        private void Btn_Big_Click(object sender, RoutedEventArgs e)
        {
            Difucy difucy = new Difucy(15,15);
            NavigationService.Navigate(difucy);
        }

        private void Btn_Medium_Click(object sender, RoutedEventArgs e)
        {

            Difucy difucy = new Difucy(10, 10);
            NavigationService.Navigate(difucy);
        }

        private void Btn_Low_Click(object sender, RoutedEventArgs e)
        {

            Difucy difucy = new Difucy(7, 7);
            NavigationService.Navigate(difucy);
        }

        private void Btn_Custom_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
