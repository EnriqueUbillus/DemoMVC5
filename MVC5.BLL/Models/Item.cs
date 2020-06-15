using MVC5.BLL.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC5.BLL.Models
{
    public class Item
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        //[DisplayName("Description: ")]
        public string Description { get; set; }

        //[Required]
        public string Path { get; set; }

        public ItemType ObjectType { get; set; }

        //public DateTime Date { get; set; }
    }
}
