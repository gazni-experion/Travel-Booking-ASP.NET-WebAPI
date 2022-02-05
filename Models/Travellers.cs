using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace TravelWebAPI.Models
{
    public partial class Travellers
    {
        public Travellers()
        {
            Travels = new HashSet<Travels>();
        }

        public int PersonId { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Travels> Travels { get; set; }
    }
}
