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

namespace TupperKMatrixGen
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        protected double drawGrid = 1;
        protected bool? wasFirstBlack = false;
        protected bool initialized = false;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Rect0x0_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Rectangle r = (Rectangle)sender;
            r.StrokeThickness = (r.StrokeThickness == drawGrid) ? 4 : drawGrid;
            wasFirstBlack = r.StrokeThickness == 4;
        }

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            if (!initialized)
            {
                initialized = true;
                return;
            }
            drawGrid =  1;
            for (int x = 0; x < 106; x++)
            {
                for (int y = 0; y < 17; y++)
                {
                    Rectangle r = (Rectangle)FindName("Rect" + x + "x" + y);
                    r.StrokeThickness = (r.StrokeThickness == 0) ? drawGrid : 4;
                }
            }
            Border1.Height = 1;
            Border2.Width = 1;
        }

        private void Rect0x0_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            wasFirstBlack = null;
        }

        private void Grid_MouseEnter(object sender, MouseEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed && wasFirstBlack != null)
            {
                Rectangle r = (Rectangle)sender;
                r.StrokeThickness = (wasFirstBlack == true) ? 4 : drawGrid;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            for (int x = 0; x < 106; x++)
            {
                for (int y = 0; y < 17; y++)
                {
                    Rectangle r = (Rectangle)FindName("Rect" + x + "x" + y);
                    r.StrokeThickness = drawGrid;
                }
            }
        }

        private void CheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            drawGrid = 0;
            for (int x = 0; x < 106; x++)
            {
                for (int y = 0; y < 17; y++)
                {
                    Rectangle r = (Rectangle)FindName("Rect" + x + "x" + y);
                    r.StrokeThickness = (r.StrokeThickness == 1) ? drawGrid : 4;
                }
            }
            initialized = true;
            Border1.Height = 0;
            Border2.Width = 0;
        }
        private void doIt_JustDoIt(object sender, RoutedEventArgs e)
        {

        }
    }
}
