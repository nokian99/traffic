using System;
using System.Collections.Generic;
using System.Text;

namespace BookingClassLibrary
{
    public class Tax
    {
        public int TaxId { get; set; }
        public decimal Value { get; set; }

        public Tax(int id, decimal value)
        {
            TaxId = id;
            Value = value;
        }
    }
}
