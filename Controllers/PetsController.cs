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
      return _context.Pets.ToList();
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
      _context.Pets.Add(newPet);
      _context.SaveChanges();
      return Created($"/api/pets/{newPet.Id}", null);
   }

   // [HttpPut]

   // public IActionResult UpdatePet( [FromBody] Pet newPet) 
   // {

   // }
}
