using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace WeatherPrognosis
{
    public class Weather
    {
        protected double temp;
        private double humidity;
        private double windSpeed;

        //PODRAZUMIJEVANI KONSTRUKTOR
        public Weather()
        {
            temp = 0;
            humidity = 0;
            windSpeed = 0;
        }

        //PARAMETARSKI KONSTRUKTOR
        public Weather(double temperature, double humidity, double windSpeed)
        {
            this.temp = temperature;
            this.humidity = humidity;
            this.windSpeed = windSpeed;
        }

        public void SetTemperature(double temp)
        {
            this.temp = temp;
        }

        public void SetWindSpeed(double speed)
        {
            this.windSpeed = speed;
        }

        public void SetHumidity(double humidity)
        {
            this.humidity = humidity;
        }

        public double GetTemperature()
        {
            return temp;
        }

        public double GetHumidity()
        {
            return humidity;
        }

        public double GetWindSpeed()
        {
            return windSpeed;
        }

        public string GetAsString()
        {
            return $"T={temp}°C, w={windSpeed}km/h, h={humidity}%";
        }

        public double CalculateFeelsLikeTemperature()
        {
            temp = temp * 1.8 + 32;
            double result = -42.379 + 2.04901523 * temp + 10.14333127 * humidity + -0.22475541 * temp * humidity + -6.83783 * Math.Pow(10, -3) * temp * temp + -5.481717 * Math.Pow(10, -2) * humidity * humidity + 1.22874 * Math.Pow(10, -3) * temp * temp * humidity + 8.5282 * Math.Pow(10, -4) * temp * humidity * humidity + -1.99 * Math.Pow(10, -6) * temp * temp * humidity * humidity;
            return (result - 32) / 1.8;
        }

        public double CalculateWindChill()
        {
            if (temp < 10 && windSpeed > 4.8)
                return (13.12 + 0.6215 * temp - 11.37 * Math.Pow(windSpeed, 0.16) + 0.3965 * temp * Math.Pow(windSpeed, 0.16));
            else return 0;
        }




        public static Weather FindWeatherWithLargestWindchill(Weather[] weathers)
        {
            Weather max = weathers[0];
            for (int i = 0; i < weathers.Length; i++)
            {
                if (max.CalculateWindChill() < weathers[i].CalculateWindChill())
                {
                    max = weathers[i];
                }
            }
            return max;
        }

    }
}