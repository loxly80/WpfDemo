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

namespace WpfDemo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Rectangle rectangle;
        Point point;

        public MainWindow()
        {
            InitializeComponent();
            rectangle =new Rectangle();
            rectangle.Width = 50;
            rectangle.Height = 50;
            rectangle.Fill = new SolidColorBrush(Colors.Blue);
            rectangle.Cursor = Cursors.Hand;
            rectangle.MouseDown += Rectangle_MouseDown;
            rectangle.MouseMove += Rectangle_MouseMove;
            canvas.Children.Add(rectangle);
            Canvas.SetLeft(rectangle, 40);
            Canvas.SetTop(rectangle, 80);
        }

        private void Rectangle_MouseMove(object sender, MouseEventArgs e)
        {
            if(e.LeftButton == MouseButtonState.Pressed)
            {
                var actualPoint = e.GetPosition(canvas);
                var difX = actualPoint.X-point.X;
                var difY = actualPoint.Y-point.Y;
                Canvas.SetLeft(rectangle,Canvas.GetLeft(rectangle)+difX);
                Canvas.SetTop(rectangle,Canvas.GetTop(rectangle)+difY);
                point = e.GetPosition(canvas);
                this.Title = point.ToString();
            }
        }

        private void Rectangle_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if(e.LeftButton == MouseButtonState.Pressed)
            {
                point = e.GetPosition(canvas);
                this.Title = point.ToString();
            }            
        }
    }
}
