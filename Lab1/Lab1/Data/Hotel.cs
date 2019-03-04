using System;
using System.Collections.Generic;
using System.Text;

namespace Lab1.Data
{
    class Hotel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Country { get; set; }
        public int Stars { get; set; }
        public List<Trip> Trips { get; set; }
    }
}
