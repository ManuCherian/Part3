using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment2.Models
{
    public partial class MyEvent
    {
        [Key]
        public int EventId { get; set; }

        [Required]
        [StringLength(255)]
        public string EventTitle { get; set; }

        [StringLength(80)]
        public string Location { get; set; }

        public int IdNumber { get; set; }


    }
}