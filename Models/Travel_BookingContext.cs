using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace TravelWebAPI.Models
{
    public partial class Travel_BookingContext : DbContext
    {
        public Travel_BookingContext()
        {
        }

        public Travel_BookingContext(DbContextOptions<Travel_BookingContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Airlines> Airlines { get; set; }
        public virtual DbSet<Travellers> Travellers { get; set; }
        public virtual DbSet<Travels> Travels { get; set; }

        /*
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source= MOHAMMEDGASNI; Initial Catalog= Travel_Booking; Integrated security=True");
            }
        }
        */

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Airlines>(entity =>
            {
                entity.HasKey(e => e.AirlineId)
                    .HasName("PK__Airlines__DC4582132B13B66F");

                entity.Property(e => e.AirlineName)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.ExtraBaggageCharges).HasColumnName("extraBaggageCharges");

                entity.Property(e => e.HandlingCharges).HasColumnName("handlingCharges");

                entity.Property(e => e.PricePerTicket).HasColumnName("pricePerTicket");
            });

            modelBuilder.Entity<Travellers>(entity =>
            {
                entity.HasKey(e => e.PersonId)
                    .HasName("PK__Travelle__EC7D7D4D6229095E");

                entity.Property(e => e.PersonId).HasColumnName("personId");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .IsFixedLength();
            });

            modelBuilder.Entity<Travels>(entity =>
            {
                entity.HasKey(e => e.TravelId)
                    .HasName("PK__Travels__082EFC1F6FD4103D");

                entity.Property(e => e.TravelId).HasColumnName("travelId");

                entity.Property(e => e.DateOfTravel)
                    .HasColumnName("dateOfTravel")
                    .HasColumnType("date");

                entity.Property(e => e.Destination)
                    .HasColumnName("destination")
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.PersonId).HasColumnName("personId");

                entity.Property(e => e.PlaceOfDeparture)
                    .HasColumnName("placeOfDeparture")
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.TicketNos).HasColumnName("ticketNos");

                entity.Property(e => e.Timeoftravel)
                    .HasColumnName("timeoftravel")
                    .HasColumnType("time(0)");

                entity.HasOne(d => d.Airline)
                    .WithMany(p => p.Travels)
                    .HasForeignKey(d => d.AirlineId)
                    .HasConstraintName("FK__Travels__Airline__3A81B327");

                entity.HasOne(d => d.Person)
                    .WithMany(p => p.Travels)
                    .HasForeignKey(d => d.PersonId)
                    .HasConstraintName("FK__Travels__personI__3B75D760");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
