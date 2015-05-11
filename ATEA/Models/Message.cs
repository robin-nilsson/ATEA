using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ATEA.Models
{
    public class Message
    {
        [Key]
        public int MessageId { get; set; }

        [Required, MaxLength(25), MinLength(3)]
        public string Title { get; set; }

        [Required, MinLength(3)]
        public string Body { get; set; }

        [Required]
        public DateTime Date { get; set; }
    }
}