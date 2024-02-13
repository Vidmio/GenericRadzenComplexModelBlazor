using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace GenericRadzenComplexModelBlazor.Components.Model
{
    public class Department
    {
        public int ID { get; set; }
        [StringLength(50, MinimumLength = 3)]
        public string Name { get; set; }

        [DataType(DataType.Currency)]
        [Column(TypeName = "money")]
        public decimal Budget { get; set; }

        public int? InstructorID { get; set; }

        [ForeignKey("InstructorID")]
        public Instructor Administrator { get; set; }
        public ICollection<Course> Courses { get; set; }

    }
}
