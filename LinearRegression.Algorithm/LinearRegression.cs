using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinearRegression.Algorithm
{
    public class LinearRegression
    {
        private PointList points_;

        public LinearRegression(PointList points)
        {
            points_ = points;
        }

        /// <summary>
        /// Executes the linear regression algorithm
        /// </summary>
        /// <returns>Returns a linear function.</returns>
        public LinearFunction Execute()
        {
            LinearFunction linearFunction = new LinearFunction();

            double x_, y_;
            (x_, y_) = GetAverage();

            double sx, sy;
            (sx, sy) = GetStandardDeviation(x_, y_);
                
            //sxy = 1/n * Sum((xk - x_) * (yk - y_))
            double sxy = GetCovariance(x_, y_);

            //rxy = sxy/(sx * sy)
            double rxy = GetCorrelation(sx, sy, sxy);

            double b = sy / sx * rxy;

            double a = -sy / sx * rxy * x_ + y_;

            linearFunction.K = b;
            linearFunction.D = a;

            return linearFunction;
        }

        /// <summary>
        /// Get the average for x and y for all points in the list
        /// </summary>
        /// <returns>Returns the average as (double, double)</returns>
        public (double, double) GetAverage()
        {
            double x_ = 0;
            double y_ = 0;

            foreach (Point p in points_)
            {
                x_ += p.X;
                y_ += p.Y;
            }

            x_ = x_ / points_.Count;
            y_ = y_ / points_.Count;

            return (x_, y_);
        }


        /// <summary>
        /// Calculates the standardDevaiation of x and y for all points
        /// </summary>
        /// <param name="x_">The average for all x values</param>
        /// <param name="y_">The average for all y values</param>
        /// <returns>Returns the standardDeviation for x and y as (double , double)</returns>
        public (double, double) GetStandardDeviation(double x_, double y_)
        {
            double sx = 0;
            double sy = 0;

            foreach (Point p in points_)
            {
                sx += Math.Pow(p.X - x_, 2);
                sy += Math.Pow(p.Y - y_, 2);
            }
            
            sx = Math.Sqrt(sx/points_.Count);
            sy = Math.Sqrt(sy/points_.Count);
        
            return (sx, sy);
        }

        /// <summary>
        /// Get the Covariance
        /// </summary>
        /// <param name="x_">The average for all points</param>
        /// <param name="y_">The average for all points</param>
        /// <returns></returns>
        public double GetCovariance(double x_, double y_)
        {
            double sum = 0;
            foreach (Point p in points_)
            {
                sum += (p.X - x_) * (p.Y - y_);
            }
            return sum / (points_.Count);
        }

        /// <summary>
        /// Returns the correlation
        /// </summary>
        /// <param name="sx">the standard devaiation for x</param>
        /// <param name="sy">the standard devaiation for y</param>
        /// <param name="sxy">the covariance</param>
        /// <returns>Returns the correlation.</returns>
        public double GetCorrelation(double sx, double sy, double sxy)
        {
            return sxy / (sx * sy);
        }


    }
}
