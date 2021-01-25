using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace BookingClassLibrary
{
    public class RegisterSystem
    {
        public string nextNr { get; set; }
        private ArrayList registers = new ArrayList();
        private ArrayList periods = new ArrayList();
        public List<Vehicle> Vehicles { get; set; }
        public List<Vehicle> VehiclesRegisteredList { get; set; }

        public ArrayList Registers
        {
            get { return registers; }
        }
        public ArrayList Periods
        {
            get { return periods; }
        }

        public RegisterSystem()
        {
            Vehicles = new List<Vehicle>();
            VehiclesRegisteredList = new List<Vehicle>();
        }
        
        public void CreateRegister(DateTime date, Vehicle v, VehicleType vt, Period p)
        {
            
            try
            {
                Registers.Add(new Register(nextNr, date, v, vt, p));
            }
            catch(Exception ex) { }
            checkIfPay(date, vt, p);
            
        }
        public void CreatePeriods(int id, TimeSpan ts1, TimeSpan ts2, decimal time)
        {

            try
            {
                Periods.Add(new Period(id, ts1, ts2, time));
            }
            catch (Exception ex) { }
           
        }

        public Period GetPeriod(TimeSpan ts)
        {
            Period p1 = new Period();
            p1 = null;
            for (int i = 0; i < periods.Count; i++)
            {
                if (ts > ((Period)Periods[i]).PeriodBegin && ts < ((Period)Periods[i]).PeriodEnd)
                {
                    p1 = ((Period)Periods[i]);
                    return p1;
                }
                else 
                {
                    p1 = ((Period)Periods[9]);
                    
                }

            }
            return p1;
        }

        public void checkIfPay(DateTime dt, VehicleType vt, Period p)
        {


            DateTime now = dt;
            DateTime dt24Hours = new DateTime();
            DateTime dt1Hour = new DateTime();
            dt24Hours = DateTime.Now.AddHours(-24);
            dt1Hour = DateTime.Now.AddHours(-1);
           

            bool shouldPay = true;

            List<Register> rList = GetRegisteredByDate(vt.PlateNr);


            if (OkPeriod(now))
            {
                if (vt.Diplomat != true && vt.VehicleId != 1 && vt.VehicleId != 1 && vt.VehicleId != 4 && vt.VehicleId != 5 && (vt.VehicleId != 3 && vt.Weight < 14000))
                {

                    if (rList.Count > 0)
                    {
                        //test 24 hour traffic
                        foreach (var item in rList)
                        {
                            item.VType.PayedTax = item.Period.Tax;

                            decimal totalcost = PayedTaxes(item.VType.PlateNr, dt24Hours);
                            if (totalcost >= item.VType.MaxTax)
                            { 
                                shouldPay = false;
                                item.VType.PayedTax = 0;
                            }

                            //test 1 hour traffic
                            if (shouldPay)
                            {
                                ArrayList al = new ArrayList();
                                al = PayedTaxesHour(item.VType.PlateNr, dt1Hour);

                                for (int i = 0; i < al.Count; i++)
                                {
                                    decimal allredyPayed = 0;
                                    if (i == al.Count - 2)
                                    {
                                        allredyPayed = ((Register)al[i]).VType.PayedTax;

                                        if (allredyPayed < p.Tax)
                                        {
                                            ((Register)rList[i]).VType.PayedTax = p.Tax;

                                        }
                                        else ((Register)rList[i]).VType.PayedTax =0;
                                    }
                                    else
                                    {
                                        ((Register)rList[i]).VType.PayedTax = 0;
                                    }

                                }
                            }
                        }

                    }

                }

            }
        }
        public Register GetRegistered(string plateNr)
        {
            for (int i = 0; i < registers.Count; i++)
            {
                if (plateNr == ((Register)Registers[i]).RegisterNr)
                    return ((Register)Registers[i]);

            }
            return null;
        }

        public List<Register> GetRegisteredByDate(string plateNr)
        {
            List<Register> rList = new List<Register>();
            for (int i = 0; i < registers.Count; i++)
            {
                if (plateNr == ((Register)Registers[i]).VType.PlateNr)

                            {
                   rList.Add((Register)Registers[i]);
                }

                
            }
            return rList;
        }
        public Register GetRegisters()
        {
            for (int i = 0; i < registers.Count; i++)
            {
                
                    return ((Register)Registers[i]);

            }
            return null;
        }

        public decimal PayedTaxes(string regnr, DateTime dt)
        {
           
            decimal totalCost = 0;
            for(int i=0;i<registers.Count;i++)
            {
                if(regnr == ((Register)registers[i]).VType.PlateNr && dt < ((Register)registers[i]).Date)
                    totalCost = totalCost + ((Register)registers[i]).VType.PayedTax;
            }
            

            return totalCost;
        }
        public ArrayList PayedTaxesHour(string regnr, DateTime dt)
        {
            ArrayList al = new ArrayList();
            for (int i = 0; i < registers.Count; i++)
            {
                if (regnr == ((Register)registers[i]).VType.PlateNr && dt < ((Register)registers[i]).Date)
                    al.Add(((Register)registers[i]));
            }


            return al;
        }
        public bool OkPeriod(DateTime date)
        {
            bool okperiod = false;
            string dateday = date.DayOfWeek.ToString();
            int datemonth = date.Month;
            if (datemonth != 7 && dateday != "Saturday" && dateday != "Sunday") okperiod = true;
            return okperiod;
        }
        public void PrintMainText()
        {
            Console.Clear();
            Console.WriteLine("Göteborg register system");
            Console.WriteLine("-----------------------------");
            Console.WriteLine("");
        }
        public int MainMenu()
        {
            int action =0;

            Console.WriteLine("0: Quit simulation");
            Console.WriteLine("1: List of the cars in system");
            Console.WriteLine("2: Register car tax in Göteborg system");
            Console.WriteLine("3: List of the cars in Göteborg system");
           
            Console.WriteLine("Write commando code (0-3)");
            try
            {
                action = Convert.ToInt32(Console.ReadLine());
            }
            catch { }
            //input.Comand = stdin;
            return action;
        }
        public  void PrintVehicleTypeList(List<VehicleType> VehicleTypes)
        {
            PrintMainText();

            Console.WriteLine("Wehicle list in entire worlds database");
            Console.WriteLine("-----------------------------");
            Console.WriteLine("");

            for (int i = 0; i < VehicleTypes.Count; i++)
            {


                Console.WriteLine("Regnr: " + VehicleTypes[i].PlateNr + "   Fordongrupp: " + VehicleTypes[i].VehicleName + "  Vikt: " + VehicleTypes[i].Weight + "  Märke: " + VehicleTypes[i].Brand + "   Model: " + VehicleTypes[i].Model + "   Diplomat regnr: " + VehicleTypes[i].Diplomat);

            }
           
        }

        public void PrintRegisteredCars()
        {
            PrintMainText();

            //for (int i = 0; i < s.Vehicles.Count; i++)
            //{
            //    Console.WriteLine("vehicle exists # " + i + s.Vehicles[i]);
            //}

            Console.WriteLine("Registered wehicle list in entire worlds database");
            Console.WriteLine("-----------------------------");
            Console.WriteLine("");

            for (int i = 0; i < registers.Count; i++)
            {
                Register reg = (Register)registers[i];

                Console.WriteLine("Date: " + reg.Date + "   Platenr: " + reg.VType.PlateNr + "   Vehicle group: " + reg.VType.VehicleName + "  Weight: " + reg.VType.Weight + "  Brand: " + reg.VType.Brand + "   Model: " + reg.VType.Model + "   Diplomat plate number: " + reg.VType.Diplomat + "   Payed tax: " + reg.VType.PayedTax);

            }
            Console.WriteLine("-----------------------------");
            Console.WriteLine("");

        }

      
    }
}
