using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherPrognosis
{
    public class DailyForecast
    {
        private DateTime date;
        public Weather weather;

        public DailyForecast(DateTime date, Weather weather)
        {
            this.date = date;
            this.weather = weather;
        }

        public override string ToString()
        {
            return $"{date}: {weather.ToString()}\n";
        }

        public static bool operator >(DailyForecast temp1, DailyForecast temp2)
        {
            return temp1.weather.GetTemperature() < temp2.weather.GetTemperature();
        }

        public static bool operator <(DailyForecast temp1, DailyForecast temp2)
        {
            return temp1.weather.GetTemperature() > temp2.weather.GetTemperature();
        }

    }
}
