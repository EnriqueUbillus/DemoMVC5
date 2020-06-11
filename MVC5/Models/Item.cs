using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace MVC5.Models
{
    public class Item
    {
        [Key]
        public int Id { get; set; }
        public ItemType ObjectType { get; set; }

        [Required]
        [MaxLength(50)]
        public string Description { get; set; }
        //public DateTime Date { get; set; }
    }

    public enum ItemType
    {
        Film = 0,
        Pdf = 1,
        Serie = 2,
        Other = 3
    }
}