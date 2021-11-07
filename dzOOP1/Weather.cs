using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
# Zadaća 1 - Osnove OOP

## Zadatak

Radite sustav koji omogućuje rad s informacijama o wremenskim prilikama.Vremenske prilike predstavljene su klasom *Weather* sa stanjem za trenutnu temperaturu u stupnjevima Celzijusa, relativnu vlažnost zraka u postotcima te jačinu vjetra u km/h.Implementirajte sve potrebne klase definirajući njihova stanja i metode kako bi se testni program u nastavku mogao ispravno izvesti.

## Dodatne upute i materijali

* Više o osjetu hladnoće vjetra (engl. * wind chill*) moguće je pronaći na[Wind chill - Wiki](https://en.wikipedia.org/wiki/Wind_chill).

    * Paziti na to u kojim se slučajevima računa osjet hladnoće vjetra, ako ga nije moguće odrediti uzima se da je osjet = 0.
* Više o osjetu topline(engl.Heat index, feels like) moguće je pronaći na[Heat index - Wiki](https://en.wikipedia.org/wiki/Heat_index).

    * Paziti na to da se rabi ispravna jednadžba, namijenjena odgovarajućoj mjernoj jedinici temperature.
* Niti jedna od ovih stvari ne predstavlja stanje.

## Pravila

* Koristiti programski jezik C#.
* Svaka klasa ide u zasebnu datoteku, imena jednakog kao i klasa
* Kreirati dva projekta unutar solutiona, jedan koji će biti definiran kao* class library* i u kojem će biti logika rješenja, a drugi koji će biti konzolna aplikacija i koji će predstavljati UI.Referencirati projekt s rješenjem u projektu koji predstavlja UI i na taj način rabiti njegove elemente.
* Koristiti.NET Core projekte u VS-u.
* Uploadati rješenje na Github, na privatni repozitorij.
* Zalijepiti link na repozitorij na odgovarajuće mjesto na Merlinu za predaju zadaće.
* Nakon isteka roka za zadaću učiniti repozitorij javnim kako bi mogao biti ocijenjen.
* Prepisivanje je strogo zabranjeno i bit će kažnjavano (i za izvor i za prepisivača!).

## Testni program

```c#	
private static void RunDemoForHW1()
{
    Weather current = new Weather();
    current.SetTemperature(24.12);
    current.SetWindSpeed(3.5);
    current.SetHumidity(0.56);
    Console.WriteLine("Weather info:\n"
        + "\ttemperature: " + current.GetTemperature() + "\n"
        + "\thumidity: " + current.GetHumidity() + "\n"
        + "\twind speed: " + current.GetWindSpeed() + "\n");
    Console.WriteLine("Feels like: " + current.CalculateFeelsLikeTemperature());

    Console.WriteLine("Finding weather info with largest windchill!");
    const int Count = 5;
    double[] temperatures = new double[Count] { 8.33, -1.45, 5.00, 12.37, 7.67 };
    double[] humidities = new double[Count] { 0.3790, 0.4555, 0.743, 0.3750, 0.6612 };
    double[] windSpeeds = new double[Count] { 4.81, 1.5, 5.7, 4.9, 1.2 };

    Weather[] weathers = new Weather[Count];
    for (int i = 0; i < weathers.Length; i++)
    {
        weathers[i] = new Weather(temperatures[i], humidities[i], windSpeeds[i]);
        Console.WriteLine("Windchill for weathers[" + i + "] is: " + weathers[i].CalculateWindChill());
    }
    Weather largestWindchill = FindWeatherWithLargestWindchill(weathers);
    Console.WriteLine(
        "Weather info:" + largestWindchill.GetTemperature() + ", " +
        largestWindchill.GetHumidity() + ", " + largestWindchill.GetWindSpeed()
    );
}
```

## Primjer izlaza
```
Weather info:
        temperature: 24.12
        humidity: 0.56
        wind speed: 3.5
Feels like: 22.97781714756796
Finding weather info with largest windchill!
Windchill for weathers[0] is: 7.925068596643065
Windchill for weathers[1] is: 0
Windchill for weathers[2] is: 3.8255514044838046
Windchill for weathers[3] is: 0
Windchill for weathers[4] is: 0
Weather info:8.33, 0.379, 4.8
*/


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
            //return 16.923 + 0.185212 * temp + 5.37941 * humidity * 100 - -0.100254 * temp * humidity * 100 + 9.41695 * Math.Pow(10, -3) * temp * temp +7.28898 * Math.Pow(10, -3) * humidity * humidity * 10000 + 3.45372 * Math.Pow(10, -4) * temp * temp * humidity * 100 - 8.14971 * Math.Pow(10, -4) * temp * humidity * humidity * 10000 + 1.02102 * Math.Pow(10, -5) * temp * temp * humidity * humidity * 10000 - 3.8646 * Math.Pow(10,-5) * Math.Pow(temp,3) + 2.91583 * Math.Pow(10,-5)*Math.Pow(humidity,3)*1000000 + 1.42721+ Math.Pow(10,-6)*Math.Pow(temp,3)*humidity*100 + 1.97483 * Math.Pow(10,-7)*temp*Math.Pow(humidity,3)*1000000 - 2.18429*Math.Pow(10,-8)*Math.Pow(temp,3)*humidity*humidity*10000 + 8.43296 * Math.Pow(10,-10)*temp*temp*Math.Pow(humidity,3)*1000000 - 4.81975* Math.Pow(10,-11)*Math.Pow(temp,3)*Math.Pow(humidity,3)*1000000;


            //return 0.363445176 + 0.988622465 * temp + 4.777114035 * humidity * 100 - -0.114037667 * temp * humidity * 100 -8.50208 * Math.Pow(10, -4) * temp * temp - 2.0716198 * Math.Pow(10, -2) * humidity * humidity * 10000 + 6.87678 * Math.Pow(10, -4) * temp * temp * humidity * 100 + 2.74954 * Math.Pow(10, -4) * temp * humidity * humidity * 10000 - 0 * Math.Pow(10, -6) * temp * temp * humidity * humidity * 10000;
            //return -42.379 + 2.04901523 * temp + 10.14333127 * humidity * 100 - 0.22475541 * temp * humidity * 100 - 6.83783 * Math.Pow(10, -3) * temp * temp - 5.481717 * Math.Pow(10, -2) * humidity * humidity * 10000 + 1.22874 * Math.Pow(10, -3) * temp * temp * humidity * 100 + 8.5282 * Math.Pow(10, -4) * temp * humidity * humidity * 10000 - 1.99 * Math.Pow(10, -6) * temp * temp * humidity * humidity * 10000;
            if (temp > 27 && humidity > 0.4)
                /*ovaj je do sad kao najboljo*/
                return -8.78469475556 + 1.61139411 * temp + 2.33854883889 * humidity * 100 - 0.14611605 * temp * humidity * 100 - 0.012308094 * temp * temp - 0.0164248277778 * humidity * humidity * 10000 + 0.002211732 * temp * temp * humidity * 100 + 0.00072546 * temp * humidity * humidity * 10000 - 0.000003582 * temp * temp * humidity * humidity * 10000;
            else return temp;
        }

        public double CalculateWindChill()
        {
            if (temp < 10 && windSpeed > 4.8)
                return (13.12 + 0.6215 * temp - 11.37 * Math.Pow(windSpeed, 0.16) + 0.3965 * temp * Math.Pow(windSpeed, 0.16));
            else return 0;
        }

        //example: (50°F - 32) x .5556 = 10°C

        /*public static Weather FindWeatherWithLargestWindchill(Weather[] weathers)
        {
            Weather max = weathers[0];
            for(int i = 0; i < weathers.Length; i++)
            {
                if(weathers[i].CalculateWindChill() > max.CalculateWindChill())
                {
                    max = weathers[i];
                }
            }
            return max;
        }*/

    }
}