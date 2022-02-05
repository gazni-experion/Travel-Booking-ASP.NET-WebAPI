using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace TravelWebAPI.Models
{
    public partial class Airlines
    {
        public Airlines()
        {
            Travels = new HashSet<Travels>();
        }

        public int AirlineId { get; set; }
        public string AirlineName { get; set; }
        public int? PricePerTicket { get; set; }
        public int? HandlingCharges { get; set; }
        public int? ExtraBaggageCharges { get; set; }

        public virtual ICollection<Travels> Travels { get; set; }
    }
}
