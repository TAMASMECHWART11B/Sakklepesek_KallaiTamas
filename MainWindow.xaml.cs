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

            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    mezok[i, j] = new Rectangle();
                    mezok[i, j].Stroke = Brushes.Black;
                    mezok[i, j].Fill = (i + j) % 2 == 0 ? Brushes.White : Brushes.Black;
                    tabla.Children.Add(mezok[i, j]);
                    Grid.SetColumn(mezok[i, j], j);
                    Grid.SetRow(mezok[i, j], i);
                }
            }
        }

        private void FelGeneral()
        {
            for (int i = 0; i < 2; i++)
            {
                ablak.RowDefinitions.Add(new RowDefinition());

            }
            ComboBox vbabu = new ComboBox();
            vbabu.Items.Add("Király");
            vbabu.Items.Add("Vezér");
            vbabu.Items.Add("Futó");
            vbabu.Items.Add("Bástya");
            vbabu.Items.Add("Huszár");
            vbabu.Items.Add("Fekete paraszt");
            vbabu.Items.Add("Fehér paraszt");
            ablak.Children.Add(vbabu);
            Grid.SetRow(vbabu, 0);
            vbabu.Height = 30;
            vbabu.Width = 100;
            vbabu.HorizontalAlignment = HorizontalAlignment.Center;
            vbabu.VerticalAlignment = VerticalAlignment.Center;
            tabla = new Grid();
            for (int i = 0; i < 10; i++)
            {
                tabla.RowDefinitions.Add(new RowDefinition());
                tabla.ColumnDefinitions.Add(new ColumnDefinition());

            }
            tabla.Width = 600;
            tabla.Height = 600;
            tabla.HorizontalAlignment = HorizontalAlignment.Center;
            tabla.VerticalAlignment = VerticalAlignment.Top;
            ablak.Children.Add(tabla);
            Grid.SetRow(tabla, 1);

        }


    }
}
