using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherPrognosis
{
    public class BiasedGenerator : IRandomGenerator
    {
        private Random generator;

        public BiasedGenerator(Random generator)
        {
            this.generator = generator;
        }

        public double Generate(double min, double max)
        {
            double a = generator.NextDouble();
            if (a <= 0.3333333333333333)
            {
                if (min >= 0) a = max - (max + min) / 2;
                else a = max - (max - min) / 2;
                a += generator.NextDouble() * (max - a);
                return a;
            }
            else
            {
                a = min;
                if (min >= 0) a += generator.NextDouble() * (max - (max + min) / 2);
                else a += generator.NextDouble() * (max - (max - min) / 2);
                return a;
            }

        }
    }
}
