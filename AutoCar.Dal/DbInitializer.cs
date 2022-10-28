using AutoCars.Domain.Enum;
using AutoCars.Domain.Modelss;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoCars.DAL
{
    public static class DbInitializer
    {
        public static void Initialize(ApplicationDbContext context)
        {
            try
            {
                context.Database.EnsureCreated();
                if (context.Cars.Any())
                {
                    return;
                }
                var students = new Car[]
                {
                    new Car{Model="Audi",TypeCar=TypeCar.SportsCar,DateCreate=DateTime.Parse("2005-09-01"),Description="Audi8",Price=250000,Name="Audi 8r"},
                    new Car{Model="Mersedes",TypeCar=TypeCar.Sedan,DateCreate=DateTime.Parse("2002-09-01"),Description="Mersedes",Price=350000,Name="Mersedes 8r"},
                    new Car{Model="Jaguar",TypeCar=TypeCar.Sedan,DateCreate=DateTime.Parse("2003-09-01"),Description="Jaguar G",Price=400000,Name="Jaguar 8r"},
                };
                foreach (Car s in students)
                {
                    context.Cars.Add(s);
                }
                context.SaveChanges();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

    }
}
