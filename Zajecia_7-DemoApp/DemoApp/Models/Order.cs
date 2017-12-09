﻿using System;
using System.Collections.Generic;

namespace DemoApp.Models
{
    public class Order
    {
        public int OrderId { get; set; }
        public string ApplicationUserId { get; set; }
        public virtual ICollection<Food> OrderItems { get; set; }
        public DateTime OrderDate { get; set; }

        public virtual ApplicationUser ApplicationUser { get; set; }
    }
}