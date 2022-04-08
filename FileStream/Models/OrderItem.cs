using System;
using System.Collections.Generic;
using System.Text;

namespace File.Models
{
    class OrderItem
    {
        public int Id { get; set; }
        public Computer Computer { get; set; }
        public double Price { get; set; }
    }
}
