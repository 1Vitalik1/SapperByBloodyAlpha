using System;
using System.Collections;
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

namespace SapperByBloodyAlpha
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private static int SizeX = 15;
        private static int SizeY = 15;
        private static int CellCount = SizeX * SizeY;
        private static int MineCount = Convert.ToInt32((SizeX * SizeY) / 6.4); //Medium
        Cell[,] Field = new Cell[SizeY, SizeX];
        StackPanel[] StackX = new StackPanel[SizeX];
        Random rnd = new Random();

        public MainWindow()
        {
            InitializeComponent();
            FieldGenerator();
            // NumberViwer(); //DevMode
        }

        public void FieldGenerator()
        {
            for (int y = 0; y != Field.GetLength(0); y++)
            {
                StackX[y] = new StackPanel();
                StackX[y].Orientation = Orientation.Horizontal;
                StackY.Children.Add(StackX[y]);
                for (int x = 0; x != Field.GetLength(1); x++)
                {
                    var tempY = y;
                    var tempX = x;
                    Field[y, x] = new Cell();
                    Field[y, x].button = new Button();
                    Field[y, x].button.Width = 20;
                    Field[y, x].button.Height = 20;
                    StackX[y].Children.Add(Field[y, x].button);
                    Field[y, x].button.Click += (sender, args) => Cell_MouseLeftButtonDown(tempY, tempX);
                    Field[y, x].button.MouseRightButtonDown += (sender, args) => Cell_MouseRightButtonDown(tempY, tempX);
                }
            }
            MineGenerator();
        }

        private void Cell_MouseRightButtonDown (int y, int x)
        {
            if (Field[y,x].Flags == false && Field[y,x].Active == false)
            {
                Field[y, x].Flags = true;
                Field[y, x].button.Content = "F";

            }
            else if (Field[y,x].Flags == true && Field[y,x].Active == false) 
            {
                Field[y, x].Flags = false;
                Field[y, x].button.Content = "";
            }

        }

        private void Cell_MouseLeftButtonDown(int y, int x)
        {
            if (Field[y, x].IsMine == false && Field[y, x].NumInCell == 0)
            {
                Field[y, x].Active = true;
                //Тут будет код открытия пустых ячеек
            }

            if (Field[y, x].IsMine == false)
            {
                Field[y, x].button.Content = Field[y, x].NumInCell;
                Field[y, x].Active = true;
            }
            else if (Field[y,x].IsMine == true)
            {
                Field[y, x].Active = true;
                Field[y, x].button.Content = "B";
            }

        }

        public void MineGenerator()
        {
            for (int i = 0; i < MineCount; i++)
            {
                int MineX = rnd.Next(0, SizeX);
                int MineY = rnd.Next(0, SizeY);

                if (Field[MineY, MineX].IsMine == false)
                {
                    Field[MineY, MineX].IsMine = true;

                    for (int y = -1; y <= 1; y++)
                    {
                        for (int x = -1; x <= 1; x++)
                        {
                            if (MineY + x >= 0 && MineY + x < SizeY && MineX + y >= 0 && MineX + y < SizeX)
                            {
                                if (Field[MineY + x, MineX + y].IsMine == false)
                                    Field[MineY + x, MineX + y].NumInCell += 1;
                            }
                        }
                    }
                }
            }

            
        }
        public void NumberViwer()
        {
            for (int y = 0; y < Field.GetLength(0); y++)
            {
                for (int x = 0; x < Field.GetLength(1); x++)
                {
                    if (Field[y,x].IsMine == false)
                    {
                        Field[y, x].button.Content = Field[y, x].NumInCell;
                    } 
                }
            }
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
            if (Mouse.LeftButton == MouseButtonState.Pressed) {this.DragMove();}
        }
    }

    public class Cell
    {
        public Button button;
        public int NumInCell;
        public bool Active;
        public bool IsMine;
        public bool Flags;

    }

}