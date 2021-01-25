using System;
using System.Collections.Generic;
using System.Text;

namespace BookingClassLibrary
{
   public class VehicleType
    {
        public int VtId { get; set; }
        public int VehicleId { get; set; }
        public string VehicleName { get; set; }
        public string PlateNr { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public int Weight { get; set; }
        public bool Diplomat { get; set; }
        public decimal PayedTax { get; set; }
        public decimal MaxTax { get; set; }
      
      

        public VehicleType(int id, int vid,string vname,string platenr,string brand, string model, int weight, bool diplomat,decimal payedtax)
        {
            VtId = id;
            VehicleId = vid;
            VehicleName = vname;
            PlateNr = platenr;
            Brand = brand;
            Model = model;
            Weight = weight;
            Diplomat = diplomat;
            PayedTax = payedtax;
            MaxTax = 60;
           
        }

        //override public string ToString()
        //{
            
        //}
    }
}
