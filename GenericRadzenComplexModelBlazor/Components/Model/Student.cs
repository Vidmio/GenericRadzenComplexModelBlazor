using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GenericRadzenComplexModelBlazor.Components.Model
{
    [Table("Students", Schema = "dbo")]
    public class Student
    {
        public int ID { get; set; }
        [MaxLength(20, ErrorMessage = "to long"), MinLength(2, ErrorMessage = "to short")]
        public string LastName { get; set; }
        [MaxLength(20, ErrorMessage = "to long"), MinLength(2, ErrorMessage = "to short")]
        public string FirstName { get; set; }
        public DateTime EnrollmentDate { get; set; }

        [Display(Name = "Full Name")]
        public string FullName
        {
            get
            {
                return LastName + ", " + FirstName;
            }
        }

        public ICollection<Enrollment> Enrollments { get; set; }
    }
}
