﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DemoWebApi.Models
{
    public class Picture
    {
        [Key]
        public int IdPicture { get; set; }
        public string Url { get; set; }
        public int IdRoom { get; set; }
    }
}