using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace dzOOP
{
    class Weather
    {
        private double temp;
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

        public double CalculateFeelsLikeTemperature()
        {
            return -8.78469475556 + 1.61139411 * temp + 2.33854883889 * humidity * 100 - 0.14611605 * temp * humidity * 100 - 0.012308094 * temp * temp - 0.0164248277778 * humidity * humidity * 10000 + 0.002211732 * temp * temp * humidity * 100 + 0.00072546 * temp * humidity * humidity * 10000 - 0.000003582 * temp * temp * humidity * humidity * 10000;

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