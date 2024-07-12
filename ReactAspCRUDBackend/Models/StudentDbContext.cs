using Microsoft.EntityFrameworkCore;

namespace ReactAspCRUDBackend.Models  // Adjusted to match the Student class namespace
{
    public class StudentDbContext : DbContext
    {
        public StudentDbContext(DbContextOptions<StudentDbContext> options) : base(options)
        {
        }

        public DbSet<Student> Students { get; set; }  // Use plural form for DbSet<Student>

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Use verbatim string literal (@) to avoid escaping issues with backslashes
            optionsBuilder.UseSqlServer(@"Server=SD-40W9NK2-DT\SQLEXPRESS;Database=school;User Id=rithika;Password=rithika;TrustServerCertificate=True");
        }
    }
}


