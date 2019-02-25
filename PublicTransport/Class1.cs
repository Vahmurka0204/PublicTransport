using System;
using System.Collections.Generic;


namespace PublicTransport
{
    public delegate void RecievedInformationHandler<TValue>(TValue T);

    public abstract class Vehicle
    {
        public event RecievedInformationHandler<Vehicle> RecievedInformationEvent;
        public int ID;

        public void SendInfoToDispatcher()
        {
            if(RecievedInformationEvent!=null)
                RecievedInformationEvent.Invoke(this);
        }

        public void RecieveMessage(string message)
        {
            Console.WriteLine(message);
        }
    }

    public class Autobus : Vehicle
    {
        public int Capacity;
        public int AmountOfFuel;

        public override string ToString()
        {
            return "ID:" + ID + ", Capacity:" + Capacity + ", amount of fuel:" + AmountOfFuel;
        }
    }

    public class Tram : Vehicle
    {
        public int NumberOfWagon;

        public override string ToString()
        {
            return "ID:" + ID + ", Number of wagon: " + NumberOfWagon;
        }
    }

    public class DispatchingOffice<TValue> where TValue: Vehicle
    {
        public List<TValue> Vehicles;
        public string VehicleType;
        public HashSet<int> BusyNumbers;
        public int NextNumber;
        public DispatchingOffice()
        {
            Vehicles = new List<TValue>();
            NextNumber = 1;
            BusyNumbers = new HashSet<int>();
        }

        public void SendMessageToVehicles(TValue T)
        {
            T.RecieveMessage("Safe journey, " + T.ID+"!");
        }

        public void OnRecievedInfo(TValue T)
        {
            Console.WriteLine(T.ToString());
            SendMessageToVehicles(T);
        }

        public void AddVehicle(Vehicle vehicle)
        {
            vehicle.ID = NextNumber;
            NextNumber++;
            Vehicles.Add(vehicle);
            BusyNumbers.Add(vehicle.ID);
            vehicle.RecievedInformationEvent += OnRecievedInfo;
            
        }
    }
}
