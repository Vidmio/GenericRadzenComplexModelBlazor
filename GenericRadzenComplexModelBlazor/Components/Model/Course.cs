using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GenericRadzenComplexModelBlazor.Components.Model
{
    [Table("Courses", Schema = "dbo")]
    public class Course
    {
        public int ID { get; set; }
        [MaxLength(20, ErrorMessage = "to long"), MinLength(2, ErrorMessage = "to short")]
        public string Title { get; set; }
        [Range(0, 5)]
        public int Credits { get; set; }

        public int DepartmentID { get; set; }
        [ForeignKey("DepartmentID")]
        public Department Department { get; set; }

        public ICollection<Enrollment> Enrollments { get; set; }
        public ICollection<CourseAssignment> CourseAssignments { get; set; }
    }
}
