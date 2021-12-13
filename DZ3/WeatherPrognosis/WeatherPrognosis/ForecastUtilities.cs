using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherPrognosis
{
    public static class ForecastUtilities
    {
        public static DailyForecast Parse(string dailyWeatherInput)
        {
            int count = 2;
            char[] split = { ',' };
            string[] stringByDay = dailyWeatherInput.Split(split, count);
            string[] doubles = stringByDay[1].Split(',');
            Weather weather = new Weather(double.Parse(doubles[0]) / 100, double.Parse(doubles[2]) / 10, double.Parse(doubles[1]) / 100);
            DailyForecast day = new DailyForecast(DateTime.Parse(stringByDay[0]), weather);
            return day;
        }

        public static void PrintWeathers(IPrinter[] printers, Weather[] weathers)
        {
                printers[0].Print(weathers);
                printers[1].Print(weathers);
        }
    }
}
