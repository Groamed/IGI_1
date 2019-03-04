using System;
using System.Collections.Generic;
using System.Text;

namespace Lab1.Data
{
    class Trip
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Cost { get; set; }
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
        public int HotelId { get; set; }
        public Hotel Hotel { get; set; }
    }
}
