using Microsoft.EntityFrameworkCore;
using ReactAspCRUDBackend.Models;

namespace ReactAspCrudBackend.Models
{
    public class StudentDbContext : DbContext
    {
        public StudentDbContext(DbContextOptions<StudentDbContext> options) : base(options)
        {
        }
        public DbSet<Student> Student { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
         optionsBuilder.UseSqlServer("Server=localhost\\SQLEXPRESS;Database=school;User Id=rithika;Password=rithika; TrustServerCertificate=True");

        }
    }
}
