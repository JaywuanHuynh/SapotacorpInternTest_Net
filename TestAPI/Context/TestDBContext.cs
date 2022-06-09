using Microsoft.EntityFrameworkCore;
using TestAPI.Models;
namespace TestAPI.Context
{
    public class TestDBContext:DbContext
    {
        public TestDBContext(DbContextOptions options)
            : base(options)
        { }
        public DbSet<Staff> Staffs { get; set; }
    }
}
