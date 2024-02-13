using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GenericRadzenComplexModelBlazor.Components.Model
{
    [Table("Instructors", Schema = "dbo")]
    public class Instructor
    {
        public int ID { get; set; }
        [MaxLength(20, ErrorMessage = "to long"), MinLength(2, ErrorMessage = "to short")]
        public string LastName { get; set; }
        [MaxLength(20, ErrorMessage = "to long"), MinLength(2, ErrorMessage = "to short")]
        public string FirstName { get; set; }
        public DateTime HireDate { get; set; }

        [Display(Name = "Full Name")]
        public string FullName
        {
            get
            {
                return LastName + ", " + FirstName;
            }
        }
        public ICollection<CourseAssignment> CourseAssignments { get; set; }
        public OfficeAssignment OfficeAssignment { get; set; }
    }
}
