using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TravelWebAPI.ViewModels;
using TravelWebAPI.Models;

namespace TravelWebAPI.Repositories
{
    public interface IBooking
    {
        //Get list of all Bookings
        Task<List<BookingsViewModel>> GetAllBookings();

        //Get list of Travellers
        Task<List<Travels>> GetAllTravels();

        //Add a new booking for existing customer
        Task<int> AddNewBooking(Travels travels);

        //Update a booking
        Task UpdateBooking(Travels travels);

        //Delete a booking
        Task<int> CancelBooking(int? id);

        //Get list of booking by destination
        //Task<List<BookingsViewModel>> GetByDestination(string? destination);

    }
}
