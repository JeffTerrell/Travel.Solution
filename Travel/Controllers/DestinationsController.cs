using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Travel.Models;


namespace Travel.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class DestinationsController : ControllerBase
  {
    private readonly TravelContext _db;

    public DestinationsController(TravelContext db)
    {
      _db = db;
    }

    // GET api/destination
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Destination>>> Get(string state, string city, int rating, string sortBy) 
    {
      var query = _db.Destinations.AsQueryable();
      
      if (state != null)
      {
        query = query.Where(entry => entry.Country == state);
      }

      if ( city != null)
      {
        query = query.Where(entry => entry.City == city);
      }

      if (rating != 0 )
      {
        query = query.Where(entry => entry.Rating == rating);
      }
      
      if (sortBy != null)
      {
        if ( sortBy == "rating")
        {
        query = query.OrderByDescending(entry => entry.Rating);
        }
        if (sortBy == "city")
        {
          query = query.OrderByDescending(entry => entry.City);
        }
        if (sortBy == "state")
        {
          query = query.OrderByDescending(entry => entry.State);
        }  
      }
      return await query.ToListAsync();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Destination>> GetDestination(int id)
    {
      var destination = await _db.Destinations.FindAsync(id);

      if (destination == null)
      {
          return NotFound();
    }

    return destination;
}

    // POST api/destinations
    [HttpPost]
    public async Task<ActionResult<Destination>> Post(Destination destination)
    {
      _db.Destinations.Add(destination);
      await _db.SaveChangesAsync();

      return CreatedAtAction(nameof(GetDestination), new { id = destination.DestinationId }, destination);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Put(int id, Destination destination)
    {
      if (id != destination.DestinationId)
      {
        return BadRequest();
      }

      _db.Entry(destination).State = EntityState.Modified;

      try
      {
        await _db.SaveChangesAsync();
      }
      catch (DbUpdateConcurrencyException)
      {
        if (!DestinationExists(id))
        {
          return NotFound();
        }
        else
        {
          throw;
        }
      }

      return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteDestination(int id)
    {
      var destination = await _db.Destinations.FindAsync(id);
      if (destination == null)
      {
        return NotFound();
      }

      _db.Destinations.Remove(destination);
      await _db.SaveChangesAsync();

      return NoContent();
    }
    private bool DestinationExists(int id)
    {
      return _db.Destinations.Any(find => find.DestinationId == id);
    }
  }
}