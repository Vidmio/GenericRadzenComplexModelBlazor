using System.ComponentModel.DataAnnotations.Schema;

namespace GenericRadzenComplexModelBlazor.Components.Model
{
    [Table("Errors", Schema = "dbo")]
    public class Error
    {
        public int ID { get; set; }
        public string? Message { get; set; }
        public DateTime DateTimeStamp { get; set; }
    }
}
