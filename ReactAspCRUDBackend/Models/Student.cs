using System.ComponentModel.DataAnnotations;

namespace ReactAspCrudBackend.Models  // Adjusted to match the StudentDbContext class namespace
{
    public class Student
    {
        [Key]
        public int Id { get; set; }

        public string StName { get; set; }

        public string Course { get; set; }

        public string PhNumber { get; set; }

        // Constructor to initialize non-nullable properties
        public Student()
        {
            StName = "";
            Course = "";
            PhNumber = "";
        }
    }
}
