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

   // routes go here
}