using System;
using System.Collections.Generic;
using System.Text;

namespace BookingClassLibrary
{
    public class Period
    {
        public int Id { get; set; }

        public TimeSpan PeriodBegin { get; set; }
        public TimeSpan PeriodEnd { get; set; }
        public decimal Tax { get; set; }

        public Period(){}
        public Period(int id, TimeSpan start, TimeSpan end, decimal tax)
        {
            Id = id;
            PeriodBegin = start;
            PeriodEnd = end;
            Tax = tax;
        }
    }
}
