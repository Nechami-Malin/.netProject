using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Subscriber.Data.Entities
{
    [Table("Card")]
    public class Card
    {
        [Key]
        [Required]
        public int Id { get; set; }

        public int? SubscriberId { get; set; }
        [ForeignKey(nameof(SubscriberId))]
        private Subscribers SubscriberCard { get; set; }
        [Column(TypeName = "date"), DisplayFormat(DataFormatString = "{0:dd/mm/yyyy ")]
        public DateTime OpenDate { get; set; }
        public double BMI { get; set; } = 0;
        public double Height { get; set; }
        public double Weight { get; set; }
        [Column(TypeName = "date"), DisplayFormat(DataFormatString = "{0:dd/mm/yyyy ")]
        public DateTime UpDate { get; set; }
    }
}
