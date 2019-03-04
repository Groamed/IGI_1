using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Lab1.Data;

namespace Lab1
{
    class DbInitializer
    {
        public static void Initialize(TouristContext db)
        {
            db.Database.EnsureCreated();
            if (db.Trips.Any() || db.Customers.Any())
            {
                return;
            }
            Hotel hotel1 = new Hotel() { Name = "Турист", Country = "Беларусь", Stars = 2 };
            Hotel hotel2 = new Hotel() { Name = "Гомель", Country = "Беларусь", Stars = 3 };
            Hotel hotel3 = new Hotel() { Name = "Галунов", Country = "Россия", Stars = 5 };
            Hotel hotel4 = new Hotel() { Name = "Вершина", Country = "Украина", Stars = 4 };
            Hotel hotel5 = new Hotel() { Name = "Цитрус", Country = "Россия", Stars = 4 };
            db.Hotels.AddRange(new Hotel[] { hotel1, hotel2, hotel3, hotel4, hotel5 });
            db.SaveChanges();
            Customer customer1 = new Customer() { FIO = "Иванов Иван Иванович", Phone = "1232323", Discount = 10 };
            Customer customer2 = new Customer() { FIO = "Федоров Андрей Владимирович", Phone = "5123467", Discount = 0 };
            Customer customer3 = new Customer() { FIO = "Нормальный Александр Александрович", Phone = "8754324", Discount = 4 };
            db.Customers.AddRange(new Customer[] { customer1, customer2, customer3 });
            db.SaveChanges();
            Trip trip1 = new Trip() { Name = "Hot caribian", Cost = 2000, Customer = customer1, Hotel = hotel1 };
            Trip trip2 = new Trip() { Name = "Cold mountings", Cost = 3500, Customer = customer3, Hotel = hotel4 };
            Trip trip3 = new Trip() { Name = "Ocean breathe", Cost = 1500, Customer = customer1, Hotel = hotel3 };
            Trip trip4 = new Trip() { Name = "Epic city", Cost = 2000, Customer = customer2, Hotel = hotel2 };
            Trip trip5 = new Trip() { Name = "Good drinks", Cost = 2400, Customer = customer2, Hotel = hotel5 };
            Trip trip6 = new Trip() { Name = "Half of snow", Cost = 1750, Customer = customer1, Hotel = hotel4 };
            Trip trip7 = new Trip() { Name = "Small trip", Cost = 2000, Customer = customer3, Hotel = hotel1 };
            Trip trip8 = new Trip() { Name = "Trip of the god", Cost = 7000, Customer = customer1, Hotel = hotel3 };
            Trip trip9 = new Trip() { Name = "Low cost", Cost = 500, Customer = customer2, Hotel = hotel1 };
            Trip trip10 = new Trip() { Name = "Best dolphines", Cost = 1000, Customer = customer2, Hotel = hotel5 };
            db.Trips.AddRange(new Trip[] { trip1, trip2, trip3, trip4, trip5, trip6, trip7, trip8, trip9, trip10 });
            db.SaveChanges();
        }
    }
}
