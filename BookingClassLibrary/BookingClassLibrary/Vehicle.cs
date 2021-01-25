using System;
using System.Collections.Generic;
using System.Text;

namespace BookingClassLibrary
{
    public class Vehicle
    {
        public int VehicleId { get; set; }
        public string VehicleName { get; set; }
        public List<Vehicle> Vehicles { get; set; }
        public List<VehicleType> VehicleTypes { get; set; }


        public Vehicle(int id,string name)
        {
            VehicleId = id;
            VehicleName = name;
        }
        
           
        public Vehicle()
        {

        }

        public void addVehicle(Vehicle v)
        {
           
            Vehicles.Add(v);
        }

    }
}
