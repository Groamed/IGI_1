using System;
using System.Linq;
using System.Collections.Generic;
using Lab1.Data;
using static System.Console;

namespace Lab1
{
    class Program
    {
        static TouristContext db = new TouristContext();
        static void Main(string[] args)
        {
            DbInitializer.Initialize(db);
            WriteLine("1.	Выборку всех данных из таблицы, стоящей в схеме базы данных на стороне отношения «один»\n");
            WriteLine("Отели: ");
            var hotels = db.Hotels.ToList();
            foreach (Hotel hotel in hotels)
                WriteLine($"Название: {hotel.Name}, Страна: {hotel.Country}, Количество звезд: {hotel.Stars}");

            WriteLine("\n2.	Выборку данных из таблицы, стоящей в схеме базы данных нас стороне отношения «один», отфильтрованные по определенному условию, налагающему ограничения на одно или несколько полей\n");
            WriteLine("Отели, отфильтрованные по стране 'Беларусь'");
            hotels = db.Hotels.Where(p => p.Country == "Беларусь").ToList();
            foreach (Hotel hotel in hotels)
                WriteLine($"Название: {hotel.Name}, Страна: {hotel.Country}, Количество звезд: {hotel.Stars}");

            WriteLine("\n3.	Выборку данных, сгруппированных по любому из полей данных с выводом какого-либо итогового результата (min, max, avg, сount или др.) по выбранному полю из таблицы, стоящей в схеме базы данных нас стороне отношения «многие»\n");
            Write("Кол-во поездок стоимостью 2000: ");
            WriteLine(db.Trips.Where(p => p.Cost == 2000).Count());

            WriteLine("\n4.	Выборку данных из двух полей двух таблиц, связанных между собой отношением «один-ко-многим» \n");
            WriteLine("Поставки продуктов: ");
            var list1 = db.Customers.Join(db.Trips, p => p.Id, c => c.CustomerId, (p, c) => new { TripName = c.Name, c.Cost, CustomerFIO = p.FIO, p.Discount });
            foreach (var item in list1)
                WriteLine($"Название поездки: {item.TripName} Цена: {item.Cost} ФИО Покупателя: {item.CustomerFIO} Скидка: {item.Discount} ");

            WriteLine("\n5.	Выборку данных из двух таблиц, связанных между собой отношением «один-ко-многим» и отфильтрованным по некоторому условию, налагающему ограничения на значения одного или нескольких полей \n");
            WriteLine("Покупатели путевок с ценой 2000");
            list1 = db.Customers.Join(db.Trips, p => p.Id, c => c.CustomerId, (p, c) => new { TripName = c.Name, c.Cost, CustomerFIO = p.FIO, p.Discount }).Where(p => p.Cost == 2000);
            foreach (var item in list1)
                WriteLine($"Название поездки: {item.TripName} Цена: {item.Cost} ФИО Покупателя: {item.CustomerFIO} Скидка: {item.Discount} ");

            WriteLine("\n 6 и 8.	Вставка и удаление данных в таблицы, стоящей на стороне отношения «Один>\n");
            WriteLine("До добавления отеля");
            hotels = db.Hotels.ToList();
            foreach (Hotel hotel in hotels)
                WriteLine($"Название: {hotel.Name}, Страна: {hotel.Country}, Количество звезд: {hotel.Stars}");
            WriteLine("После добавления отеля");
            Hotel hotel1 = new Hotel() { Name = "Тестовый отель", Country = "Россия", Stars = 1 };
            db.Hotels.Add(hotel1);
            db.SaveChanges();
            hotels = db.Hotels.ToList();
            foreach (Hotel hotel in hotels)
                WriteLine($"Название: {hotel.Name}, Страна: {hotel.Country}, Количество звезд: {hotel.Stars}");
            WriteLine("После удаления отеля");
            db.Hotels.Remove(hotel1);
            db.SaveChanges();
            hotels = db.Hotels.ToList();
            foreach (Hotel hotel in hotels)
                WriteLine($"Название: {hotel.Name}, Страна: {hotel.Country}, Количество звезд: {hotel.Stars}");

            WriteLine("\n7 и 9.	Вставку и удаление данных в таблицы, стоящей на стороне отношения «Многие» \n");
            WriteLine("До добавления поездки: ");
            var trips = db.Trips.ToList();
            foreach (Trip trip in trips)
                WriteLine($"Название: {trip.Name} Id отеля: {trip.HotelId} Id покупателя: {trip.CustomerId} Цена: {trip.Cost}");
            Trip trip1 = new Trip() { Name = "Тест", Cost = 2000, HotelId = 1, CustomerId = 1 };
            db.Trips.Add(trip1);
            db.SaveChanges();
            WriteLine("После добавления поездки: ");
            trips = db.Trips.ToList();
            foreach (Trip trip in trips)
                WriteLine($"Название: {trip.Name} Id отеля: {trip.HotelId} Id покупателя: {trip.CustomerId} Цена: {trip.Cost}");
            db.Trips.Remove(trip1);
            db.SaveChanges();
            WriteLine("После удаления поездки: ");
            trips = db.Trips.ToList();
            foreach (Trip trip in trips)
                WriteLine($"Название: {trip.Name} Id отеля: {trip.HotelId} Id покупателя: {trip.CustomerId} Цена: {trip.Cost}");

            WriteLine("\n10.	Обновление удовлетворяющих определенному условию записей в любой из таблиц базы данных\n");
            WriteLine("Поездки до обновления");
            trips = db.Trips.ToList();
            foreach (Trip trip in trips)
                WriteLine($"Название: {trip.Name} Id отеля: {trip.HotelId} Id покупателя: {trip.CustomerId} Цена: {trip.Cost}");
            trips = db.Trips.Where(p => p.Cost < 2000).ToList();
            foreach (Trip trip in trips)
                trip.Cost = 1555;
            db.SaveChanges();
            WriteLine("Поездки после обновления");
            trips = db.Trips.ToList();
            foreach (Trip trip in trips)
                WriteLine($"Название: {trip.Name} Id отеля: {trip.HotelId} Id покупателя: {trip.CustomerId} Цена: {trip.Cost}");
            Read();

        }
    }
}
