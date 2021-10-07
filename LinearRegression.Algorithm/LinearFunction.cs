using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinearRegression.Algorithm
{
    public class LinearFunction
    {
        public double K { get; set; } = 0;
        public double D { get; set; } = 0;

        public LinearFunction()
        {

        }

        /// <summary>
        /// Return the Y value for the given X value.
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public double GetY(double x)
        {
            return K * x + D;
        }
    }
}
