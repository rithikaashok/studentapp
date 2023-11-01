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
         optionsBuilder.UseSqlServer("Data Source=studentserver.database.windows.net; Initial Catalog=studentdb; User Id=capstone; password=Kishore@123; TrustServerCertificate= True");
        }
    }
}