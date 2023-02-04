using System.ComponentModel.DataAnnotations.Schema;

namespace Anyar_Project.Models
{
    public class Employee
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Position { get; set; }
        public string? Title { get; set; }
        public string? Image { get; set; }
        [NotMapped]
        public IFormFile FormFile { get; set; }
        public List<Icon>? Icons { get; set; }
    }
}
