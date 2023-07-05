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
    public class ResourceGroupController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public ResourceGroupController(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ResourceResponse>>> GetResources()
        {
            var resources = await _context.ResourceGroup.ToListAsync();

            return Ok(_mapper.Map<IEnumerable<ResourceResponse>>(resources));
        }

        [HttpGet("{id}", Name = "GetResourceById")]
        public async Task<ActionResult<ResourceResponse>> GetResourceById(int id)
        {
            var resource = await _context.ResourceGroup.FindAsync(id);
            if (resource != null)
                return Ok(_mapper.Map<ResourceResponse>(resource));
            return NotFound();
        }

        [HttpPost]
        public async Task<ActionResult<ResourceResponse>> CreateResource(ResourceCreate resource)
        {
            var newResource = _mapper.Map<ResourceGroup>(resource);
            await _context.ResourceGroup.AddAsync(newResource);
            await _context.SaveChangesAsync();

            var response = _mapper.Map<ResourceResponse>(newResource);
            return CreatedAtRoute(nameof(GetResourceById), new { id = response.ResourceId }, response);
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> PatchResourceById([FromRoute] int id, 
            [FromBody]  JsonPatchDocument<ResourceGroup> resourceUpdates)
        {
            var currResource = await _context.ResourceGroup.FindAsync(id);
            if(currResource != null)
            {
                resourceUpdates.ApplyTo(currResource);
                await _context.SaveChangesAsync();
                return Ok();
            }
            return NotFound();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteResourceById(int id) 
        {
            var currResource = await _context.ResourceGroup.FindAsync(id);
            if(currResource != null)
            {
                _context.Remove(currResource);
                await _context.SaveChangesAsync();
                return Ok();
            }
            return NotFound();
        }
    }
}
