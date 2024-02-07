using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Subscriber.Data.DTO
{
    public class CardDTO
    {
        public DateTime OpenDate { get; set; }
        public double BMI { get; set; }
        public double height { get; set; }
        public double weight { get; set; }
        public DateTime UpDate { get; set; }


    }
}

