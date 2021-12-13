using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherPrognosis
{
    public class WeeklyForecast
    {
        private DailyForecast[] daily;

        public WeeklyForecast(DailyForecast[] daily)
        {
            this.daily = daily;
        }

        public override string ToString()
        {
            string representationOfTheWeek = "";
            for (int i = 0; i < daily.Length; i++)
            {
                representationOfTheWeek += daily[i].ToString();
            }

            return representationOfTheWeek;
        }

        public double GetMaxTemperature()
        {
            DailyForecast max = daily[0];
            for (int i = 1; i < daily.Length; i++)
            {
                if (max > daily[i]) max = daily[i];
            }
            return max.weather.GetTemperature();
        }

        public DailyForecast this[int indexOfDay] { get { return daily[indexOfDay]; } }

    }
}
