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

namespace SapperByBloodyAlpha.AllPages
{
    /// <summary>
    /// Логика взаимодействия для Game.xaml
    /// </summary>
    public partial class Game : Page
    {
        private static int SizeX = 16;
        private static int SizeY = 16;
        private static int CellCount = SizeX * SizeY;
        private static int MineCount; //Hard

        Random rnd = new Random();

        public Game(double DifucyGame, int MSSSizeX, int MSSSizeY)
        {
            MineCount = Convert.ToInt32((SizeX * SizeY) / DifucyGame); //low
            SizeX = MSSSizeX; SizeY = MSSSizeY;

            Cell[,] Field = new Cell[SizeY, SizeX];
            StackPanel[] StackX = new StackPanel[SizeX];

            InitializeComponent();
            FieldGenerator(Field,StackX);
            NumberViwer(Field, StackX); //DevMode

        }



        public void FieldGenerator(Cell[,] Field, StackPanel[] StackX)
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
                    Field[y, x].button.Click += (sender, args) => Cell_MouseLeftButtonDown(tempY, tempX, Field, StackX);
                    Field[y, x].button.MouseRightButtonDown += (sender, args) => Cell_MouseRightButtonDown(tempY, tempX, Field, StackX);
                }
            }
            MineGenerator(Field, StackX);
        }

        private void Cell_MouseRightButtonDown(int y, int x, Cell[,] Field, StackPanel[] StackX)
        {
            if (Field[y, x].Flags == false && Field[y, x].Active == false)
            {
                Field[y, x].Flags = true;
                Field[y, x].button.Content = "F";

            }
            else if (Field[y, x].Flags == true && Field[y, x].Active == false)
            {
                Field[y, x].Flags = false;
                Field[y, x].button.Content = "";
            }

        }

        private void Cell_MouseLeftButtonDown(int y, int x, Cell[,] Field, StackPanel[] StackX)
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
            else if (Field[y, x].IsMine == true)
            {
                Field[y, x].Active = true;
                Field[y, x].button.Content = "B";
            }

        }

        public void MineGenerator(Cell[,] Field, StackPanel[] StackX)
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
        public void NumberViwer(Cell[,] Field, StackPanel[] StackX)
        {
            for (int y = 0; y < Field.GetLength(0); y++)
            {
                for (int x = 0; x < Field.GetLength(1); x++)
                {
                    if (Field[y, x].IsMine == false)
                    {
                        Field[y, x].button.Content = Field[y, x].NumInCell;
                    }
                }
            }
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

