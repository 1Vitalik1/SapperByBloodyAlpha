using SapperByBloodyAlpha.AllPages;
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
using System.Windows.Shapes;

namespace SapperByBloodyAlpha
{
    /// <summary>
    /// Логика взаимодействия для PrimaryWindows.xaml
    /// </summary>
    public partial class PrimaryWindows : Window
    {
        public PrimaryWindows()
        {
            InitializeComponent();
            MainMenu mainMenu = new MainMenu();
            Pages_Selector.Navigate(mainMenu);
        }


        private void Btn_WinMinimize_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void Btn_Exit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Border_Windows_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (Mouse.LeftButton == MouseButtonState.Pressed) { this.DragMove(); }
        }
    }
}
