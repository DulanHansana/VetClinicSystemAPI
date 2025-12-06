using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VetClinicSystemAPI.Data;
using VetClinicSystemAPI.Models;

namespace VetClinicSystemAPI.Controllers
{
    [Route("api/petprofiles")]
    [ApiController]
    public class PetProfilesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public PetProfilesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/petprofiles/{petId}
        [HttpGet("{petId}")]
        public async Task<ActionResult<PetProfile>> GetProfile(int petId)
        {
            var profile = await _context.PetProfiles
                .FirstOrDefaultAsync(p => p.PetId == petId);

            if (profile == null)
                return NotFound();

            return profile;
        }

        // POST: api/petprofiles
        // Create OR overwrite
        [HttpPost]
        public async Task<IActionResult> CreateProfile(PetProfile profile)
        {
            var existing = await _context.PetProfiles
                .FirstOrDefaultAsync(p => p.PetId == profile.PetId);

            if (existing != null)
                _context.PetProfiles.Remove(existing);

            _context.PetProfiles.Add(profile);
            await _context.SaveChangesAsync();

            return Ok(profile);
        }

        // PUT: api/petprofiles/{petId}
        [HttpPut("{petId}")]
        public async Task<IActionResult> UpdateProfile(int petId, PetProfile updated)
        {
            var existing = await _context.PetProfiles
                .FirstOrDefaultAsync(p => p.PetId == petId);

            if (existing == null)
                return NotFound();

            existing.VetNotes = updated.VetNotes;

            await _context.SaveChangesAsync();
            return NoContent();
        }

        // DELETE: api/petprofiles/{petId}
        [HttpDelete("{petId}")]
        public async Task<IActionResult> DeleteProfile(int petId)
        {
            var profile = await _context.PetProfiles
                .FirstOrDefaultAsync(p => p.PetId == petId);

            if (profile == null)
                return NotFound();

            _context.PetProfiles.Remove(profile);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
