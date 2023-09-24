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
            int i = 0;

            if (i != 0 && int.Parse(RTB_SizeX.Text) > int.Parse(RTB_SizeY.Text))
            {
                int temp;
                temp = int.Parse(RTB_SizeY.Text);
                RTB_SizeY.Text = RTB_SizeX.Text;
                RTB_SizeX.Text = Convert.ToString(temp);
            }

            if (RTB_SizeX.Text != "" && RTB_SizeY.Text != "")
            {
                i++;
                try
                {
                  
                    Difucy difucy = new Difucy(int.Parse(RTB_SizeX.Text),int.Parse(RTB_SizeY.Text));
                    NavigationService.Navigate(difucy);
                }
                catch 
                {

                    Label_BAS.Content = "Вы ввели неверное число!";
                }
            }

            if (RTB_SizeX.Text == "" && RTB_SizeY.Text == "")
            {
                Border_SizeXY.Visibility = Visibility.Visible;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
