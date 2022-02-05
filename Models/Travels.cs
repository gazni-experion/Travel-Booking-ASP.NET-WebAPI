using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace TravelWebAPI.Models
{
    public partial class Travels
    {
        public int TravelId { get; set; }
        public short? TicketNos { get; set; }
        public string PlaceOfDeparture { get; set; }
        public string Destination { get; set; }
        public DateTime? DateOfTravel { get; set; }
        public TimeSpan? Timeoftravel { get; set; }
        public int? AirlineId { get; set; }
        public int? PersonId { get; set; }

        public virtual Airlines Airline { get; set; }
        public virtual Travellers Person { get; set; }
    }
}
