using AutoCars.Domain.Modelss;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoCars.DAL.Interfaces
{
   public   interface ICarRepository:IBaseRepository<Car>
    {
        Task<Car> GetByName(string name);
    }
}
