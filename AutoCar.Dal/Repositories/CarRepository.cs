using AutoCars.DAL.Interfaces;
using AutoCars.Domain.Modelss;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoCars.DAL.Repositories
{
    public class CarRepository : ICarRepository
    {
        private readonly ApplicationDbContext _applicationDb;
        public CarRepository(ApplicationDbContext applicationDb) 
        {
            _applicationDb = applicationDb;
        }
        public async Task<bool> Create(Car entity)
        {
           await _applicationDb.AddAsync(entity);
            await _applicationDb.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Delete(Car entity)
        {
             _applicationDb.Remove(entity);
            await _applicationDb.SaveChangesAsync();
            return true;
        }

        public async Task<Car> Get(int id)
        {
            return  await _applicationDb.Cars.FirstOrDefaultAsync(x => x.Id== id);
        }

        public async Task<Car> GetByName(string name)
        {
            return await _applicationDb.Cars.FirstOrDefaultAsync(x => x.Name == name);
        }

        public async Task<IEnumerable<Car>> GetCar()
        {
            return  await _applicationDb.Cars.ToListAsync();     
        }

        public async  Task<Car> Update(Car entity)
        {
            _applicationDb.Cars.Update(entity);
           await _applicationDb.SaveChangesAsync();
            return entity;
        }
    }
}
