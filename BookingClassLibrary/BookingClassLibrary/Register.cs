using System;
using System.Collections.Generic;
using System.Text;

namespace BookingClassLibrary
{
    public class Register
    {
        public string RegisterNr { get; set; }
        public DateTime Date { get; set; }
        public Vehicle Vehicle { get; set; }
        public VehicleType VType { get; set; }
        public Period Period { get; set; }

        public Register(string reservationNr, DateTime date,Vehicle v, VehicleType vt, Period p)
        {
            RegisterNr = reservationNr;
            Date = date;
            Vehicle = v;
            VType = vt;
            Period = p;
        }
        public Register() { }
    }
}
