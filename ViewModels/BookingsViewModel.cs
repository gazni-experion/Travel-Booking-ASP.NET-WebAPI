using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TravelWebAPI.ViewModels
{
    public class BookingsViewModel
    {
        public string PassengerName { get; set; }
        public DateTime DateOfTravel { get; set; }
        public TimeSpan TimeOfTravel { get; set; }
        public string Destination { get; set; }
        public string Departure { get; set; }
        public short Tickets { get; set; }
        public string Airline { get; set; }
        public int PricePerTicket { get; set; }
        public int HandlingCharges { get; set; }
        public int ExtraBaggageCharges { get; set; }
        public int TotalPrice { get; set; }
    }
}
