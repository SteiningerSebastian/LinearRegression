using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace LinearRegression.UI
{
    public class CanvasHandler
    {
        public Canvas Canvas_ { get; private set; }
        public Brush Brush { get; set; }
        public double StrokeThickness { get; set; }

        private List<Line> linearFunctions;

        /// <summary>
        /// Construct the main canvas.
        /// </summary>
        /// <param name="canvas">The main canvas.</param>
        public CanvasHandler(Canvas canvas)
        {
            Canvas_ = canvas;
            Brush = new SolidColorBrush(Color.FromRgb(0, 0, 0));
            StrokeThickness = 3;
            linearFunctions = new List<Line>();
        }

        /// <summary>
        /// Setup the Canvs
        /// </summary>
        public void Setup()
        {
            SetAxis();
        }

        /// <summary>
        /// Draw the axis for the canvas
        /// </summary>
        protected void SetAxis()
        {
            Line xAxis = new Line();
            xAxis.X1 = 10;
            xAxis.Y1 = Canvas_.ActualHeight-10;
            xAxis.X2 = Canvas_.ActualWidth;
            xAxis.Y2 = Canvas_.ActualHeight-10;
            xAxis.Stroke = Brush;
            xAxis.StrokeThickness = StrokeThickness;

            Canvas_.Children.Add(xAxis);

            Line yAxis = new Line();
            yAxis.X1 = 10;
            yAxis.Y1 = 0;
            yAxis.X2 = 10;
            yAxis.Y2 = Canvas_.ActualHeight-10;
            yAxis.Stroke = Brush;
            yAxis.StrokeThickness = StrokeThickness;

            Canvas_.Children.Add(yAxis);
        }

        /// <summary>
        /// Set a point on the canvas
        /// </summary>
        /// <param name="point">The position of the point</param>
        public void SetPoint(Point point, double radius = 4)
        {
            Ellipse ellipse = new Ellipse();

            ellipse.Width = radius*2;
            ellipse.Height = radius*2;

            ellipse.Stroke = Brush;
            ellipse.StrokeThickness = StrokeThickness;
            ellipse.Fill = Brush;

            Canvas.SetLeft(ellipse, point.X-ellipse.Width/2);
            Canvas.SetTop(ellipse, point.Y-ellipse.Height/2);

            Canvas_.Children.Add(ellipse);
        }

        /// <summary>
        /// Draws a Linear Function on the canvas.
        /// </summary>
        /// <param name="linearFunction">The linear function to plot</param>
        public void DrawLinearFunction(Algorithm.LinearFunction linearFunction)
        {
            Line function = new Line();
            function.X1 = 10;
            function.Y1 = linearFunction.GetY(10);
            function.X2 = Canvas_.ActualWidth;
            function.Y2 = linearFunction.GetY(Canvas_.ActualWidth);
            function.Stroke = Brush;
            function.StrokeThickness = StrokeThickness;

            Canvas_.Children.Add(function);
            linearFunctions.Add(function);
        }

        /// <summary>
        /// Removes all linear functions from the canvas
        /// </summary>
        public void ClearLinearFunctions()
        {
            foreach(Line f in linearFunctions)
            {
                Canvas_.Children.Remove(f);
            }
        }
    }
}
