using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace WeatherPrognosis
{
    public class FilePrinter : IPrinter
    {
        private string name;

        public FilePrinter(string name)
        {
            this.name = name;
        }

        public void Print(Weather[] weathers)
        {
            if(File.Exists(name) == false)
            {
                Console.WriteLine("The file does not exsist");
            }
            else
            {
                string[] weatherStrings = new string[weathers.Length];
                for (int i = 0; i < weathers.Length; i++) weatherStrings[i] = weathers[i].ToString();
                File.WriteAllLines(name, weatherStrings);
            }
        }
    }
}
