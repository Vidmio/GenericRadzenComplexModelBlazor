using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GenericRadzenComplexModelBlazor.Components.Model
{
    [Table("Enrollments", Schema = "dbo")]
    public class Enrollment
    {
        public int ID { get; set; }
        public int CourseID { get; set; }
        public int StudentID { get; set; }
        [ForeignKey("CourseID")]
        public Course Course { get; set; }
        [ForeignKey("StudentID")]
        public Student Student { get; set; }
    }
}
