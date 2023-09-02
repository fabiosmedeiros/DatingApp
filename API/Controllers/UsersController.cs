using API.Data;
using API.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers; // Não esquecer de sempre ajustar o namespace

// ControllerBase é a classe base quando trabalhamos com API
[ApiController]
[Route("api/[controller]")]
public class UsersController : ControllerBase
{

    private readonly DataContext _context;
    public UsersController(DataContext context)
    {
        _context = context;// Isso vai ser injetado quando um UsersController for criado
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<AppUser>>> GetUsers ()
    {
        var users = _context.Users.ToListAsync();

        return await users;
    }

    [HttpGet("{id}")] // /api/users/2
    public async Task<ActionResult<AppUser>> GetUser (int id)
    {
        return await _context.Users.FindAsync(id);
    }

}
