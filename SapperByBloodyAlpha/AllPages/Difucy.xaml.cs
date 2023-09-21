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
    /// Логика взаимодействия для Difucy.xaml
    /// </summary>
    public partial class Difucy : Page
    {
        public int SizeX;
        public int SizeY;
        public Difucy(int GetSizeX, int GetSizeY)
        {
            SizeX = GetSizeX;
            SizeY = GetSizeY;

            InitializeComponent();
        }

        //                    private static int MineCount = Convert.ToInt32((SizeX * SizeY) / 8.1); //low
        //                    private static int MineCount = Convert.ToInt32((SizeX * SizeY) / 6.4); //Medium
        //                    private static int MineCount = Convert.ToInt32((SizeX * SizeY) / 4.8); //Hard

        private void Btn_Hard_Click(object sender, RoutedEventArgs e)
        {
            Game game = new Game(4.8,SizeX,SizeY);
            NavigationService.Navigate(game);

        }

        private void Btn_Exit_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Btn_Low_Click(object sender, RoutedEventArgs e)
        {

            Game game = new Game(8.1, SizeX, SizeY);
            NavigationService.Navigate(game);
        }

        private void Btn_Normal_Click(object sender, RoutedEventArgs e)
        {

            Game game = new Game(6.4, SizeX, SizeY);
            NavigationService.Navigate(game);
        }
    }
}
