using PublicTransport;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Autobus a = new Autobus();
            a.AmountOfFuel = 5;
            a.Capacity = 40;
            a.ID = 153;
            Autobus b = new Autobus { ID = 235, AmountOfFuel = 25, Capacity = 30 };
            Autobus c = new Autobus { ID = 235, AmountOfFuel = 3, Capacity = 2 };
            Tram t = new Tram { ID = 7, NumberOfWagon = 2 };
            DispatchingOffice<Autobus> office = new DispatchingOffice<Autobus>();
            office.AddVehicle(a);
            office.AddVehicle(b);
            office.AddVehicle(c);

            office.NotifyObservers();
            
            Console.ReadKey();

        }
    }
}
