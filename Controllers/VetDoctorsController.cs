using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VetClinicSystemAPI.Data;
using VetClinicSystemAPI.Models;

namespace VetClinicSystemAPI.Controllers
{
    [Route("api/vetdoctors")]
    [ApiController]
    public class VetDoctorsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public VetDoctorsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/vetdoctors
        [HttpGet]
        public async Task<ActionResult<IEnumerable<VetDoctor>>> GetVetDoctors()
        {
            return await _context.VetDoctors
                .Include(v => v.Pets)
                .ToListAsync();
        }

        // GET: api/vetdoctors/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<VetDoctor>> GetVetDoctor(int id)
        {
            var doctor = await _context.VetDoctors
                .Include(v => v.Pets)
                .FirstOrDefaultAsync(v => v.Id == id);

            if (doctor == null)
                return NotFound();

            return doctor;
        }

        // POST: api/vetdoctors
        [HttpPost]
        public async Task<ActionResult<VetDoctor>> PostVetDoctor(VetDoctor doctor)
        {
            _context.VetDoctors.Add(doctor);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetVetDoctor), new { id = doctor.Id }, doctor);
        }

        // PUT: api/vetdoctors/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> PutVetDoctor(int id, VetDoctor doctor)
        {
            if (id != doctor.Id)
                return BadRequest();

            _context.Entry(doctor).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.VetDoctors.Any(e => e.Id == id))
                    return NotFound();

                throw;
            }

            return NoContent();
        }

        // DELETE: api/vetdoctors/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteVetDoctor(int id)
        {
            var doctor = await _context.VetDoctors.FindAsync(id);
            if (doctor == null)
                return NotFound();

            _context.VetDoctors.Remove(doctor);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
