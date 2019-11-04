using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day09Travel
{
    class Travel
    {
        int id;
        string destination;
        string travellerName;
        string travellerPassport;
        DateTime departureDate;
        DateTime returnDate;

        public Travel(string destination, string travellerName, string travellerPassport, DateTime departureDate, DateTime returnDate, TravelEnum methodOfTravel)
        {
            Destination = destination;
            TravellerName = travellerName;
            TravellerPassport = travellerPassport;
            DepartureDate = departureDate;
            ReturnDate = returnDate;
            MethodOfTravel = methodOfTravel;
        }


        public int Id
        {
            get
            {
                return id;
            }
            set
            {
                id = value;
            }
        }
        public string Destination
        {
            get
            {
                return destination;
            }
            set
            {
                destination = value;
            }
        }
        public string TravellerName
        {
            get
            {
                return travellerName;
            }
            set
            {
                travellerName = value;
            }
        }
        public string TravellerPassport
        {
            get
            {
                return travellerPassport;
            }
            set
            {
                travellerPassport = value;
            }
        }
        public DateTime DepartureDate
        {
            get
            {
                return departureDate;
            }
            set
            {
                departureDate = value;
            }
        }
        public DateTime ReturnDate
        {
            get
            {
                return returnDate;
            }
            set
            {
                returnDate = value;
            }
        }
        public TravelEnum MethodOfTravel { get; set; }
       
        public enum TravelEnum { Car , Bus , Plane , Train , Other};

        public override string ToString()
        {
            return string.Format("{0} : {1}) , {2} , {3} ", TravellerName, TravellerPassport, Destination, DepartureDate );
        }
    }
}


