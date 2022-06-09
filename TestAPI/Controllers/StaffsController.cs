using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TestAPI.Context;
using TestAPI.Models;


namespace TestAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StaffsController : ControllerBase
    {
        private readonly TestDBContext _context;
        public StaffsController(TestDBContext context)
        {
            _context = context;
        }
        [HttpGet("getStaffList")]
        public async Task<ActionResult<IEnumerable<Staff>>> GetStaffList()
        {
            return _context.Staffs.ToList();
        }
        [HttpGet("{id:int}")]
        public async Task<ActionResult<Staff>> GetStaff(int id)
        {
            var s = _context.Staffs.FirstOrDefault(e => e.Id == id);
            if (s == null)
            {
                return NotFound();
            }
            return s;
        }
        [HttpPost()]
        public async Task<ActionResult> AddStaff(Staff s)
        {
            _context.Entry(s).State = EntityState.Added;
            _context.SaveChanges();
            return Ok(s.Id);
        }
        [HttpPut("{id:int}")]
        public async Task<ActionResult> UpdateStaff(int id,Staff s)
        {
            var existingStaff = _context.Staffs.FirstOrDefault(e => e.Id == id);
            if (existingStaff == null)
            {
                return NotFound();
            }
            existingStaff.Name = s.Name;
            existingStaff.Age = s.Age;
            existingStaff.Gender = s.Gender;
            existingStaff.BirthDay = s.BirthDay;
            existingStaff.Country = s.Country;

            _context.Entry(existingStaff).State = EntityState.Modified;
            _context.SaveChanges();
            return Ok(s.Id);
        }
        [HttpDelete("{id:int}")]
        public async Task<ActionResult> DeleteStaff(int id)
        {
            var existingStaff = _context.Staffs.FirstOrDefault(e => e.Id == id);
            if (existingStaff == null)
            {
                return NotFound();
            }
            _context.Entry(existingStaff).State = EntityState.Deleted;
            _context.SaveChanges();
            return Ok(existingStaff.Id);
        }

    }

}     

