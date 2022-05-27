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

namespace Sakklepesek_KállaiTamásMiklós
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Rectangle[,] mezok;
        Grid tabla;
        ComboBox valasztas;
        public MainWindow()
        {
            InitializeComponent();
            FelGeneral();
            Tabla();
        }

        private void Tabla()
        {
            mezok = new Rectangle[8, 8];
            char betuJel = 'A';
            for (int i = 1; i < 9; i++)
            {
                Label betu = new Label();
                betu.HorizontalAlignment = HorizontalAlignment.Left;
                betu.VerticalAlignment = VerticalAlignment.Top;
                betu.Content = betuJel++;
                tabla.Children.Add(betu);
                Grid.SetRow(betu, 0);
                Grid.SetColumn(betu, i);

                betu = new Label();
                betu.HorizontalAlignment = HorizontalAlignment.Left;
                betu.VerticalAlignment = VerticalAlignment.Top;
                betu.Content = betuJel++;
                tabla.Children.Add(betu);
                Grid.SetRow(betu, 9);
                Grid.SetColumn(betu, i);

                betu = new Label();
                betu.HorizontalAlignment = HorizontalAlignment.Left;
                betu.VerticalAlignment = VerticalAlignment.Top;
                betu.Content = 9 - i;
                tabla.Children.Add(betu);
                Grid.SetRow(betu, i);
                Grid.SetColumn(betu, 9);

                betu = new Label();
                betu.HorizontalAlignment = HorizontalAlignment.Left;
                betu.VerticalAlignment = VerticalAlignment.Top;
                betu.Content = 9 - i;
                tabla.Children.Add(betu);
                Grid.SetRow(betu, i);
                Grid.SetColumn(betu, 9);
            }
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    mezok[i, j] = new Rectangle();
                    mezok[i, j].Stroke = Brushes.Black;
                    mezok[i, j].Fill = (i + j) % 2 == 0 ? Brushes.White : Brushes.Black;
                    mezok[i, j].MouseUp += KattTabla;
                    tabla.Children.Add(mezok[i, j]);
                    
                    Grid.SetColumn(mezok[i, j], j);
                    Grid.SetRow(mezok[i, j], i);
                }
            }
            

        }

        public void FelGeneral()
        {
            for (int i = 0; i < 2; i++)
            {
                ablak.RowDefinitions.Add(new RowDefinition());
                ablak.ColumnDefinitions.Add(new ColumnDefinition());

            }
            valasztas = new ComboBox();
            
            valasztas.Items.Add("Király");
            valasztas.Items.Add("Királyné");
            valasztas.Items.Add("Futó");
            valasztas.Items.Add("Bástya");
            valasztas.Items.Add("Huszár");
            valasztas.Items.Add("Fekete paraszt");
            valasztas.Items.Add("Fehér paraszt");
            ablak.Children.Add(valasztas);
            Grid.SetRow(valasztas, 0);
            Grid.SetColumn(valasztas, 0);
            valasztas.Height = 30;
            valasztas.Width = 100;
            valasztas.HorizontalAlignment = HorizontalAlignment.Center;
            valasztas.VerticalAlignment = VerticalAlignment.Center;
            tabla = new Grid();
            for (int i = 0; i < 10; i++)
            {
                tabla.RowDefinitions.Add(new RowDefinition());
                tabla.ColumnDefinitions.Add(new ColumnDefinition());

            }
            tabla.Width = 400;
            tabla.Height = 400;
            tabla.HorizontalAlignment = HorizontalAlignment.Center;
            tabla.VerticalAlignment = VerticalAlignment.Top;
            
            ablak.Children.Add(tabla);
            Grid.SetRow(tabla, 1);
            Grid.SetColumn(tabla, 0);

        }

        public void KattTabla(object sender, MouseButtonEventArgs e)
        {
            Rectangle aktualis = sender as Rectangle;

            int xKordinata = 0;
            int yKordinata = 0;

            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    if (mezok[i, j].Equals(aktualis))
                    {
                        xKordinata = i;
                        yKordinata = j;
                    }
                    mezok[i, j].Fill = (i + j) % 2 == 0 ? Brushes.White : Brushes.Black;
                }
            }
            mezok[xKordinata, yKordinata].Fill = Brushes.Red;
        }


    }
}
