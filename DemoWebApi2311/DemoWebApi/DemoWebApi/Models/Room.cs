using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DemoWebApi.Models
{
    public class Room
    {
        [Key]
        public int IdRoom { get; set; }
        public int Number { get; set; }
        public string Description { get; set; }
        public int Type { get; set; }
        public decimal Price { get; set; }
        public Boolean HasTV { get; set; }
        public Boolean HasHairDryer { get; set; }
        public int IdHotel { get; set; }
        public Hotel hotel { get; set; }
    }
}