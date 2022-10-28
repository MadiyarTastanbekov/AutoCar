using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoCars.Domain.Interfaces;
using AutoCars.Domain.Modelss;
using AutoCars.Domain.Response;
using AutoCars.Domain.ViewModels;

namespace AutoCars.Service.Interfaces
{
   public interface ICarService
    {
        Task<IBaseResponse<IEnumerable<Car>>> GetCars();
        public  Task<IBaseResponse<Car>> GetCar(int id);
        public  Task<IBaseResponse<Car>> GetByName(string name);
        public  Task<IBaseResponse<bool>> DeleteCar(int id);
        public  Task<IBaseResponse<CarViewModel>> CreateCar(CarViewModel carViewModel);
        public Task<IBaseResponse<Car>> Edit(int id,CarViewModel carViewModel);

    }
}
