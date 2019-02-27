using Patterns;
using System;
using System.Collections.Generic;


namespace PublicTransport
{
   // public delegate void RecievedInformationHandler<TValue>(TValue T);

    public abstract class Vehicle: IObserver
    {
      //  public event RecievedInformationHandler<Vehicle> RecievedInformationEvent;
        public int ID;

       /* public void SendInfoToDispatcher(ISubject subject)
        {
            subject.NotifyObservers();
        }*/

        public void RecieveMessage(string message)
        {
            Console.WriteLine(message);
        }

        public void Update(string message)
        {
            RecieveMessage(message);
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

    public class DispatchingOffice<TValue>:ISubject where TValue: Vehicle, IObserver
    {
        public List<TValue> Vehicles;
        public List<IObserver> Observers;
        public string VehicleType;
       // public HashSet<int> BusyNumbers;
        public int NextNumber;
        public DispatchingOffice()
        {
            Vehicles = new List<TValue>();
            NextNumber = 1;
            Observers = new List<IObserver>();
           // BusyNumbers = new HashSet<int>();
        }

        public void NotifyObservers()
        {
            foreach (IObserver T in Vehicles)
            {
                //Console.WriteLine(T.ToString());
                SendMessageToVehicles((TValue)T);
                T.Update(T.ToString());
            }
        }

        public void SendMessageToVehicles(TValue T)
        {
            T.RecieveMessage("Safe journey, " + T.ID+"!");
        }

        /*public void OnRecievedInfo(TValue T)
        {
            Console.WriteLine(T.ToString());
            SendMessageToVehicles(T);
        }*/

        public void AddVehicle(TValue vehicle)
        {
            vehicle.ID = NextNumber;
            NextNumber++;
            Vehicles.Add(vehicle);
           // BusyNumbers.Add(vehicle.ID);
            RegisterObserver(vehicle);
           // vehicle.RecievedInformationEvent += OnRecievedInfo;
            
        }

        public void RegisterObserver(IObserver observer)
        {
            Observers.Add(observer);
        }

        public void RemoveObserver(IObserver observer)
        {
            Observers.Remove(observer);
        }
    }
}
