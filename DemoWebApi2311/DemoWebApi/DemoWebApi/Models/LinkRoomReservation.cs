using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DemoWebApi.Models
{
    public class LinkRoomReservation
    {
        [Key]
        public int IdLinkRoomReservation { get; set; }
        public decimal PriceRoom { get; set; }
        public int IdReservation { get; set; }
        public int IdRoom { get; set; }
    }
}