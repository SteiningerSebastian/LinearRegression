using LinearRegression.Algorithm;
using LinearRegression.UI;
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

namespace LinearRegression.UI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        CanvasHandler canvasHandler;
        PointList pointList;
        Brush brush_blue = new SolidColorBrush(Color.FromRgb(0, 0, 200));
        Brush brush_black = new SolidColorBrush(Color.FromRgb(0, 0, 0));
        LinearRegression.Algorithm.LinearRegression linearRegression;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            canvasHandler = new CanvasHandler(mainCanvas);
            pointList = new PointList();
            linearRegression = new Algorithm.LinearRegression(pointList);
        }

        private void mainCanvas_MouseDown(object sender, MouseButtonEventArgs e)
        {
            canvasHandler.Brush = brush_blue;
            System.Windows.Point position = Mouse.GetPosition(mainCanvas);
            canvasHandler.SetPoint(position);
            pointList.Add(new Algorithm.Point(position.X, position.Y));
            canvasHandler.ClearLinearFunctions();
            if(pointList.Count > 1)
            {
                canvasHandler.Brush = brush_black;
                LinearFunction linearFunction = linearRegression.Execute();
                canvasHandler.DrawLinearFunction(linearFunction);
                double cost = Math.Round(linearRegression.Evaluate(linearFunction), 1);
                result.Content = cost.ToString();
            }
        }

        private void mainCanvas_Loaded(object sender, RoutedEventArgs e)
        {
            canvasHandler.Setup();
        }
    }
}
