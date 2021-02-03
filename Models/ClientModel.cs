using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace LAB0_2530019_1203819.Models
{
    public class ClientModel
    {
        
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public int phone { get; set; }
        [Required]
        public string Description { get; set; }
    }
}
