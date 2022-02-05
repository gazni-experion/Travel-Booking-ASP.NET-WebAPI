using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TravelWebAPI.Models;
using TravelWebAPI.Repositories;

namespace TravelWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class BookingsController : ControllerBase
    {
        //Readonly field for IBooking
        private readonly IBooking _booking;

        public BookingsController(IBooking booking)
        {
            _booking = booking;
        }

        #region Get Bookings

        //HTTPGET: /api/bookings/getallbookings
        [HttpGet("GetAllBookings")]
        
        public async Task<IActionResult> GetAllBookings()
        {
            try
            {
                var bookings = await _booking.GetAllBookings();
                if (bookings == null)
                {
                    return NotFound();
                }
                return Ok(bookings);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
        #endregion

        #region Get all travels

        [HttpGet("Travels")]

        public async Task<ActionResult<IEnumerable<Travels>>> GetAllTravels(){

            return await _booking.GetAllTravels();
        }
        #endregion

        #region Add a new booking to existing customer

        [HttpPost("NewBooking")]
        public async Task<IActionResult> AddNewBooking([FromBody]Travels travels)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var travelId = await _booking.AddNewBooking(travels);
                    if (travelId>0)
                    {
                        return Ok(travelId);
                    }
                    else
                    {
                        return NotFound();
                    }
                }
                catch (Exception)
                {
                    return BadRequest();
                }
            }
            return BadRequest();
        }
        #endregion

        #region Update a booking
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateBooking([FromBody]Travels travels)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await _booking.UpdateBooking(travels);
                    return Ok();
                }
                catch (Exception)
                {
                    return BadRequest();
                }
            }
            return BadRequest();
        }
        #endregion

        #region Get booking by destination
        /*
        [HttpGet("destination")]
        public async Task<IActionResult> GetByDestination(string destination)
        {
            if (destination == null)
            {
                return BadRequest();
            }
            try
            {
                var booking = await _booking.GetByDestination(destination);
                if (booking == null)
                {
                    return NotFound();
                }
                return Ok(booking);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
        */
        #endregion

        #region Cancel booking

        [HttpDelete("{id}")]
        public async Task<IActionResult> CancelBooking(int? id)
        {
            int result = 0;
            if (id == null)
            {
                return BadRequest();
            }
            try
            {
                result = await _booking.CancelBooking(id);
                if (result == 0)
                {
                    return NotFound();
                }
                return Ok();        //return Ok(employee);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
        #endregion
    }
}
