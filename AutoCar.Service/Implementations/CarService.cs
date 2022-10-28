using AutoCars.DAL.Interfaces;
using AutoCars.Domain.Enum;
using AutoCars.Domain.Interfaces;
using AutoCars.Domain.Modelss;
using AutoCars.Domain.Response;
using AutoCars.Domain.ViewModels;
using AutoCars.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace AutoCars.Service.Implementations
{
    public class CarService : ICarService
    {
        private readonly ICarRepository _carRepository;
        public CarService(ICarRepository carRepository) 
        {
            _carRepository = carRepository;
        }
        public async Task<IBaseResponse<Car>> GetCar(int id) 
        {
            var baseresponse = new BaseResponse<Car>();
            try
            {
                var cars = await _carRepository.Get(id);
                if(cars is null)
                {
                    baseresponse.Description = "User not found";
                    baseresponse.StatusCode = StatusCode.UserNotFound;
                    return baseresponse;
                }
                baseresponse.StatusCode = StatusCode.OK;
                baseresponse.Data = cars;
                return baseresponse;
                
            }
            catch (Exception ex)
            {
                return new BaseResponse<Car>()
                {
                    Description = $"[GetCar]: {ex.Message}",
                    StatusCode = StatusCode.InternalServerError
                };
            }
        }
        public async Task<IBaseResponse<Car>> GetByName(string name)
        {
            var baseresponse = new BaseResponse<Car>();
            try
            {
                var cars = await _carRepository.GetByName(name);
                if (cars is null)
                {
                    baseresponse.Description = "User not found";
                    baseresponse.StatusCode = StatusCode.UserNotFound;
                    return baseresponse;
                }
                baseresponse.Data = cars;
                return baseresponse;
            }
            catch (Exception ex)
            {
                return new BaseResponse<Car>()
                {
                    Description = $"[GetCarByName]: {ex.Message}",
                    StatusCode = StatusCode.InternalServerError
                };
            }
        }
        public async Task<IBaseResponse<bool>> DeleteCar(int id) 
        {
            var baseresponse = new BaseResponse<bool>();
            try 
            {
                var car = await _carRepository.Get(id);
                if(car is null) 
                {
                    baseresponse.Description = "User not found";
                    baseresponse.StatusCode = StatusCode.UserNotFound;
                    baseresponse.Data = false;
                    return baseresponse;
                }
                await _carRepository.Delete(car);
               
              return baseresponse;
            }
            catch(Exception ex)
            {
                return new BaseResponse<bool>()
                {
                    Description = $"[DeleteCar]: {ex.Message}",
                    StatusCode = StatusCode.InternalServerError
                };

            }

        }
        public async Task<IBaseResponse<CarViewModel>> CreateCar(CarViewModel carViewModel) 
        {
            var baseresponse = new BaseResponse<CarViewModel>();
            try
            {
                var car = new Car()
                {
                    Name = carViewModel.Name,
                    Model = carViewModel.Model,
                    Price = carViewModel.Price,
                    DateCreate = DateTime.Now,
                    Description = carViewModel.Description,
                    Speed = carViewModel.Speed,
                    TypeCar = (TypeCar)Convert.ToInt32(carViewModel.TypeCar)
                };
                await _carRepository.Create(car);
                return baseresponse;
            }
            catch(Exception ex) 
            {
                return new BaseResponse<CarViewModel>()
                {
                    Description = $"[CreateCar]: {ex.Message}",
                    StatusCode = StatusCode.InternalServerError
                };
            }

        }
        public async Task<IBaseResponse<IEnumerable<Car>>> GetCars()
        {
            var baseResponse = new BaseResponse<IEnumerable<Car>>();
            try
            {
                var cars =  await _carRepository.GetCar();
                if (cars.ToList().Count == 0)
                {
                    baseResponse.Description = "No Finfd elements";
                    baseResponse.StatusCode = StatusCode.CarNotFound;
                    return baseResponse;
                }
                baseResponse.Data = cars;
                baseResponse.StatusCode = StatusCode.OK;
                return baseResponse;
            }
            catch(Exception ex) 
            {
                return new BaseResponse<IEnumerable<Car>>()
                {
                    Description = $"[GetCars]: {ex.Message}"
                };
            }
            
        }

        public async Task<IBaseResponse<Car>> Edit(int id, CarViewModel carViewModel)
        {
            var baseResponse = new BaseResponse<Car>();
            try 
            {
                var car = await _carRepository.Get(id);
                if(car is null) {
                    baseResponse.Description = "Car not found";
                    baseResponse.StatusCode = StatusCode.CarNotFound;
                    return baseResponse;
                }
                car.Description = carViewModel.Description;
                car.DateCreate = carViewModel.DateCreate;
                car.Price = carViewModel.Price;
                car.Model = carViewModel.Model;
                car.Name = carViewModel.Name;
                car.Speed = carViewModel.Speed; 

                await _carRepository.Update(car);

                return baseResponse;
            }
           catch (Exception ex)
            {
                return  new BaseResponse<Car>()
                {
                    Description = $"[Edit]: {ex.Message}",
                    StatusCode = StatusCode.InternalServerError
                };
            }
        }
    }
}
