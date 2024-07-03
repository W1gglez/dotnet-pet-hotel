using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using pet_hotel.Models;

namespace pet_hotel.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PetsController : ControllerBase
{
   private readonly ApplicationContext _context;
   public PetsController(ApplicationContext context)
   {
      _context = context;
   }

   // routes go here

   [HttpGet]
   public IEnumerable<Pet> GetPets()
   {
      return _context.Pets.Include(p => p.petOwner);
   }

   [HttpGet("{petId}")]
   public IActionResult GetPetById(int petId)
   {
      Pet pet = _context.Pets.SingleOrDefault(Pets => Pets.Id == petId);
      if (pet == null)
      {
         return NotFound();
      }
      return Ok(pet);
   }

   [HttpPost]
   public IActionResult CreatePet([FromBody] Pet newPet)
   {
      _context.Add(newPet);
      _context.SaveChanges();

      Pet CreatedPet = _context.Pets.OrderByDescending(p => p.Id).Include(p => p.petOwner).FirstOrDefault();


      return Created($"/api/pets/{newPet.Id}", CreatedPet);
   }

   [HttpPut("{petId}")]

   public Pet UpdatePet(int petId, [FromBody] Pet updatePet)
   {
      updatePet.Id = petId;

      _context.Pets.Update(updatePet);
      _context.SaveChanges();

      return updatePet;
   }


   [HttpDelete("{petId}")]
   public IActionResult Delete(int petId)
   {
      Pet pet = _context.Pets.Find(petId);

      if (pet == null)
      {
         return NotFound();
      }

      _context.Pets.Remove(pet);
      _context.SaveChanges();

      return NoContent();
   }


   [HttpPut("{petId}/checkin")]

   public IActionResult CheckIn(int petId)
   {
      Pet pet = _context.Pets.SingleOrDefault(pet => pet.Id == petId);

      pet.CheckedInAt = DateTime.Now.ToUniversalTime();

      _context.Pets.Update(pet);

      _context.SaveChanges();

      return Ok(pet);


   }



   [HttpPut("{petId}/checkout")]

   public IActionResult Checkout(int petId)
   {
      Pet pet = _context.Pets.SingleOrDefault(pet => pet.Id == petId);

      pet.CheckedInAt = null;

      _context.Pets.Update(pet);

      _context.SaveChanges();

      return Ok(pet);


   }

}
