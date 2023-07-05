using AutoMapper;
using FemKampAPI.Database;
using FemKampAPI.Models;
using FemKampAPI.Models.Dtos;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FemKampAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public UserController(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;   
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserResponse>>> GetUsers()
        {
            var users = await _context.User.ToListAsync();

            return Ok(_mapper.Map<IEnumerable<UserResponse>>(users));
        }

        [HttpGet("{id}", Name = "GetUserById")]
        public async Task<ActionResult<UserResponse>> GetUserById(int id)
        {
            var user = await _context.User.FindAsync(id);
            if (user != null)
                return Ok(_mapper.Map<UserResponse>(user));
            return NotFound();
        }

        [HttpPost]
        public async Task<ActionResult> CreateUser(UserCreate user)
        {
            var newUser = _mapper.Map<User>(user);

            await _context.User.AddAsync(newUser);
            await _context.SaveChangesAsync();

            var response = _mapper.Map<UserResponse>(newUser);
            return CreatedAtRoute(nameof(GetUserById), new { id = response.UserId }, response);

        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> PatchUserById([FromRoute] int id,
         [FromBody] JsonPatchDocument<User> userUpdates)
        {
            var currUser = await _context.User.FindAsync(id);
            if (currUser != null)
            {
                userUpdates.ApplyTo(currUser);
                await _context.SaveChangesAsync();
                return Ok();
            }
            return NotFound();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteResourceById(int id)
        {
            var currUser = await _context.User.FindAsync(id);
            if (currUser != null)
            {
                _context.Remove(currUser);
                await _context.SaveChangesAsync();
                return Ok();
            }
            return NotFound();
        }
    }
}
