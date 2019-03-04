using System;
using System.Collections.Generic;
using System.Text;

namespace Lab1.Data
{
    class Customer
    {
        public int Id { get; set; }
        public string FIO { get; set; }
        public string Phone { get; set; }
        public int Discount { get; set; }
        public List<Trip> Trips { get; set; }
    }
}
