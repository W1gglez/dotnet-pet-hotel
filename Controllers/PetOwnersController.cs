using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using pet_hotel.Models;

namespace pet_hotel.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PetOwnersController : ControllerBase
{
   private readonly ApplicationContext _context;
   public PetOwnersController(ApplicationContext context)
   {
      _context = context;
   }

   [HttpGet]
   public IEnumerable<PetOwner> GetAll()
   {
      return _context.PetOwners;
   }

   [HttpGet("{id}")]
   public ActionResult<PetOwner> GetById(int id)
   {
      PetOwner owner = _context.PetOwners.SingleOrDefault(owner => owner.Id == id);

      if (owner == null)
      {
         return null;
      }

      return owner;
   }

   [HttpPost]
   public IActionResult AddOwner([FromBody] PetOwner owner)
   {
      _context.Add(owner);
      _context.SaveChanges();

      return Created($"/api/pets/{owner.Id}", null);
   }

   [HttpDelete("{id}")]
   public IActionResult DeleteOwner(int id)
   {
      PetOwner owner = _context.PetOwners.SingleOrDefault(owner => owner.Id == id);
      _context.Remove(owner);
      _context.SaveChanges();
      return Ok();
   }


}