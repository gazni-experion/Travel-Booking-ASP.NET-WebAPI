using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TravelWebAPI.Repositories;
using TravelWebAPI.ViewModels;
using TravelWebAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace TravelWebAPI.Repositories
{
    public class Booking : IBooking
    {
        //Readonly field for db context
        private readonly Travel_BookingContext _context;

       //Constructor for initializing db context
        public Booking(Travel_BookingContext context)
        {
            _context = context;
        }




        #region Get All Bookings

        //Get list of all bookings
        public async Task<List<BookingsViewModel>> GetAllBookings()
        {
            if (_context!=null)
            {
                //Using LINQ to retrieve data
                return await (
                    from c in _context.Travellers
                    from t in _context.Travels
                    from a in _context.Airlines
                    where t.PersonId == c.PersonId && t.AirlineId == a.AirlineId
                    select new BookingsViewModel
                    {
                        PassengerName = c.Name,
                        DateOfTravel = (DateTime)t.DateOfTravel,
                        TimeOfTravel = (TimeSpan)t.Timeoftravel,
                        Destination = t.Destination,
                        Departure = t.PlaceOfDeparture,
                        Tickets = (short)t.TicketNos,
                        Airline = a.AirlineName,
                        PricePerTicket = (int)a.PricePerTicket,
                        HandlingCharges = (int)a.HandlingCharges,
                        ExtraBaggageCharges = (int)a.ExtraBaggageCharges,
                        TotalPrice = (((int)((t.TicketNos*a.PricePerTicket)+a.HandlingCharges+a.ExtraBaggageCharges)))
                    }
                    ).ToListAsync();
            }
            return null;
        }
        #endregion


        #region Get All travels

        //Get list of all travels
        public async Task<List<Travels>> GetAllTravels()
        {
            if (_context != null)
            {
                return await _context.Travels.ToListAsync();
            }
            return null;
        }
        #endregion

        #region Add new Booking

        //Add a new booking existing customer
        public async Task<int> AddNewBooking(Travels travels)
        {
            if (_context!=null)
            {
                await _context.Travels.AddAsync(travels);
                await _context.SaveChangesAsync();
                return travels.TravelId;
            }
            return 0;
        }
        #endregion

        #region Update Booking

        //Update a booking
        public async Task UpdateBooking(Travels travels)
        {
            if (_context != null)
            {
                _context.Entry(travels).State = EntityState.Modified;
                _context.Travels.Update(travels);
                await _context.SaveChangesAsync();
            }
        }
        #endregion

        #region Cancel booking

        public async Task<int> CancelBooking(int? id)
        {
            int result = 0;
            if (_context != null)
            {
                var booking = await _context.Travels.FirstOrDefaultAsync(bk => bk.TravelId == id);
                if (booking != null) //Check condition
                {
                    //Delete
                    _context.Travels.Remove(booking);

                    //Commiting to change the physical db
                    result = await _context.SaveChangesAsync();
                }
                return result;
            }
            return result;
        }
        #endregion


        #region Get booking list By Destination
        /*
                //Getting list of booking by destination
                public async Task<List<BookingParamsViewModel>> GetByDestination(string? destination)
                {
                    if (_context != null)
                    {
                        //Using LINQ to retrieve data
                        return await (
                            from c in _context.Travellers
                            from t in _context.Travels
                            from a in _context.Airlines
                            join passengers in _context.Travellers on c.PersonId equals passengers.PersonId 
                            join airline in _context.Airlines on a.AirlineId equals airline.AirlineId
                            where t.Destination == destination
                            select new BookingParamsViewModel
                            {
                                PassengerName = passengers.Name,
                                DateOfTravel = (DateTime)t.DateOfTravel,
                                TimeOfTravel = (TimeSpan)t.Timeoftravel,
                                Destination = t.Destination,
                                Departure = t.PlaceOfDeparture,
                                Tickets = (short)t.TicketNos,
                                Airline = airline.AirlineName,
                                PricePerTicket = (int)airline.PricePerTicket
                            }
                            ).ToListAsync();
                    }
                    return null;
                }*/
        #endregion

    }
}
