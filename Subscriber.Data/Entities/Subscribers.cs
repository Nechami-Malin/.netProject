using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Subscriber.Data.Entities
{
    [Table("Subscriber")]
    public class Subscribers
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [MaxLength(100)]
        public string FirstName { get; set; }
        [MaxLength(100)]
        public string LastName { get; set; }
        [RegularExpression("^[\\w\\.-]+@[\\w\\.-]+\\.\\w+$", ErrorMessage ="Invalid Email")]
        public string? Email { get; set; }
        [Required]
        [RegularExpression("^(?=.*[A-Z])(?=.*[a-z])(?=.*\\d)(?=.*[!@#$%^&*()_\\-+=]).{8,}$",ErrorMessage ="Invalid Password")]
        public string Password { get; set; }
    }
}
