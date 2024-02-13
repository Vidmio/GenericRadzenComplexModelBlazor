using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GenericRadzenComplexModelBlazor.Components.Model
{
    [Table("OfficeAssignments", Schema = "dbo")]
    public class OfficeAssignment
    {
        public int ID { get; set; }
        [StringLength(50)]
        [Display(Name = "Office Location")]
        public string Location { get; set; }
        public int InstructorID { get; set; }

        [ForeignKey("InstructorID")]
        public Instructor Instructor { get; set; }
    }
}
