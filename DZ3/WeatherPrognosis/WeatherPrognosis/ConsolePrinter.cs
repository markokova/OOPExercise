using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherPrognosis
{
    public class ConsolePrinter : IPrinter
    {
        private ConsoleColor color;

        public ConsolePrinter(ConsoleColor color)
        {
            this.color = color;
        }

        public void Print(Weather[] weathers)
        {
            Console.ForegroundColor = color;
            for(int i = 0; i < weathers.Length; i++)
            Console.WriteLine($"{weathers[i].ToString()}",Console.ForegroundColor);
        }
    }
}
