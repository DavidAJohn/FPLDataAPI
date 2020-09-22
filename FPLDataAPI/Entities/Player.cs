using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FPLDataAPI.Entities
{
    public class Player
    {
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string Name { get; set; }
        public Team TeamName { get; set; }
        public int TeamId { get; set; }
        public int Goals { get; set; }
        public int Assists { get; set; }

    }
}
