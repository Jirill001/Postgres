using Microsoft.EntityFrameworkCore;
using Postgres;
using Postgres.Models;

namespace Postgres
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using var db = new ShopContext();

            void Show<T>(IEnumerable<T> items)
            {
                foreach (var x in items) Console.WriteLine(x);
                Console.WriteLine("---");
            }

            Console.WriteLine("Задание 1:");
            Show(db.Products.Where(p => p.CategoryId == 2).ToList());

            Console.WriteLine("Задание 2:");
            Show(db.Products.Where(p => p.Price >= 1000 && p.Price <= 5000).ToList());

            Console.WriteLine("Задание 3:");
            Show(db.Products.Where(p => p.Stock > 0 && p.Stock < 20).ToList());

            Console.WriteLine("Задание 4:");
            Show(db.Customers.Where(c => c.RegisteredAt.Year == 2025).ToList());

            Console.WriteLine("Задание 5:");
            Show(db.Customers.Where(c => c.City == "Казань" || c.City == "Новосибирск").ToList());

            Console.WriteLine("Задание 6:");
            Show(db.Customers.Where(c => c.City != "Москва").ToList());

            Console.WriteLine("Задание 7:");
            Show(db.Orders.Where(o => o.Status == "new").ToList());

            Console.WriteLine("Задание 8:");
            Show(db.Orders.Where(o => o.OrderDate > new DateTime(2025, 6, 1)).ToList());

            Console.WriteLine("Задание 9:");
            Show(db.Orders.Where(o =>
                o.OrderDate.DayOfWeek == DayOfWeek.Saturday ||
                o.OrderDate.DayOfWeek == DayOfWeek.Sunday).ToList());

            Console.WriteLine("Задание 10:");
            Show(db.Products.Where(p => EF.Functions.ILike(p.Name, "%книга%")).ToList());

            Console.WriteLine("Задание 11:");
            Show(db.Customers.Where(c => c.FullName.StartsWith("А")).ToList());

            Console.WriteLine("Задание 12:");
            Show(db.OrderItems.Where(oi => oi.Quantity > 1).ToList());

            Console.WriteLine("Задание 13:");
            var prices = new decimal[] { 990m, 1490m };
            Show(db.Products.Where(p => prices.Contains(p.Price)).ToList());


            Console.WriteLine("Задание 14:");
            Show(db.Products.OrderBy(p => p.Name).ToList());

            Console.WriteLine("Задание 15:");
            Show(db.Products.OrderBy(p => p.Stock).ThenByDescending(p => p.Price).ToList());

            Console.WriteLine("Задание 16:");
            Show(db.Customers.OrderByDescending(c => c.RegisteredAt).ToList());

            Console.WriteLine("Задание 17:");
            Show(db.Customers.OrderBy(c => c.City).ThenBy(c => c.FullName).ToList());

            Console.WriteLine("Задание 18:");
            Show(db.Orders.OrderBy(o => o.OrderDate)
                          .Select(o => new { o.Id, o.OrderDate })
                          .ToList());


            Console.WriteLine("Задание 19:");
            var mostExpensive = db.Products.OrderByDescending(p => p.Price).First();
            Console.WriteLine(mostExpensive);

            Console.WriteLine("Задание 20:");
            var p100 = db.Products.FirstOrDefault(p => p.Id == 100);
            Console.WriteLine(p100 == null ? "Товар с Id=100 не найден (null)" : p100.ToString());

            Console.WriteLine("Задание 21:");
            var oleg = db.Customers.Single(c => c.Email == "oleg@mail.ru");
            Console.WriteLine(oleg);

            Console.WriteLine("Задание 22:");
            var earliest = db.Orders.OrderBy(o => o.OrderDate).First();
            Console.WriteLine(earliest);

            Console.WriteLine("Задание 23:");
            var lastCustomer = db.Customers.OrderByDescending(c => c.RegisteredAt).First();
            Console.WriteLine(lastCustomer);

            Console.WriteLine("Задание 24:");
            var viaFind = db.Products.Find(5);
            Console.WriteLine("Find(5):        " + viaFind);

            var viaFirst = db.Products.FirstOrDefault(p => p.Id == 5);
            Console.WriteLine("FirstOrDefault: " + viaFirst);


            Console.WriteLine("Задание 25: " + db.Products.Any(p => p.Price > 100_000));
            Console.WriteLine("Задание 26: " + db.Products.All(p => p.Price > 500));
            Console.WriteLine("Задание 27: " + db.Customers.Any(c => c.City == "Сочи"));

            var statuses = new[] { "new", "paid", "shipped", "cancelled" };
            Console.WriteLine("Задание 28: " + db.Orders.All(o => statuses.Contains(o.Status)));


            Console.WriteLine("Задание 29:");
            Console.WriteLine("Всего клиентов: " + db.Customers.Count());
            Console.WriteLine("Из Москвы:      " + db.Customers.Count(c => c.City == "Москва"));

            Console.WriteLine("Задание 30:");
            Console.WriteLine("Min: " + db.Products.Min(p => p.Price));
            Console.WriteLine("Max: " + db.Products.Max(p => p.Price));
            Console.WriteLine("Avg: " + db.Products.Average(p => p.Price));

            Console.WriteLine("Задание 31: " + db.Products.Sum(p => p.Stock));
            Console.WriteLine("Задание 32: " + db.OrderItems.Sum(oi => oi.Quantity));

            Console.WriteLine("Задание 33:");
            Show(db.Products.OrderByDescending(p => p.Price).Take(5).ToList());

            Console.WriteLine("Задание 34:");
            Show(db.Products.OrderBy(p => p.Price).Skip(3).ToList());

            Console.WriteLine("Задание 35:");
            Show(db.Products.OrderBy(p => p.Name).Skip(4).Take(4).ToList());
        }
    }
}