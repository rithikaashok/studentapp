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
         optionsBuilder.UseSqlServer("Data Source=prostudentserver.database.windows.net; Initial Catalog=StudentproDB ; User Id=prostudent; password=Charlie*6721; TrustServerCertificate= True");
        }
    }
}