using System.ComponentModel.DataAnnotations;

namespace Lab12_Async_Inn.Models
{
    public class Amenity
    {
        [Key]
        public int ID { get; set; }
        [Required]
        public string Name { get; set; }
    }
}
