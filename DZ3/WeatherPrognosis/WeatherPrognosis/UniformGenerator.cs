using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherPrognosis
{
    public class UniformGenerator : IRandomGenerator
    {
        private Random generator;

        public UniformGenerator(Random generator)
        {
            this.generator = generator;
        }

        public double Generate(double min, double max)
        {
            return generator.NextDouble() * (max - min) + min;
        }
    }
}
