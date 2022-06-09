
using System.ComponentModel.DataAnnotations;
namespace TestAPI.Models
{
    public class Staff
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Gender { get; set; }
        public DateTime BirthDay { get; set; }
        public String Country { get; set; }
    }
}
