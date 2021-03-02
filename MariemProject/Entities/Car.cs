﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MariemProject.Entities
{
    public class Car
    {
        public int Id { get; set; }
        public string MarketPlace { get; set; }
        public string Model { get; set; }
        public string Color { get; set; }
        public bool IsAvailable { get; set; }
    }
}
