using AutoCars.Domain.ViewModels;
using AutoCars.Service.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace AutoCars.Controllers
{
    [ApiController]
    [Route("api/Car")]
    public class CarController : Controller
    {
        private readonly ICarService _carService;

        public CarController(ICarService carService) 
        {
            _carService = carService;
        }
        [HttpGet("GetCars")]
        public  async Task<IActionResult> GetCars()
        {
            var response = await  _carService.GetCars();
            if(response.StatusCode == Domain.Enum.StatusCode.OK) { return Ok(response.Data); }
            return  RedirectToAction("Error");
        }
        [HttpGet("GetCarById/{id}")]
        public async Task<IActionResult> GetCarById(int id) 
        {
            var response=await _carService.GetCar(id);
            if (response.StatusCode == Domain.Enum.StatusCode.OK) { return Ok(response.Data); }
            return RedirectToAction("Error");
        }
        [Authorize(Roles ="Admin")]
        [HttpDelete("DeleteCarById/{id}")]
        public async Task<IActionResult> Delete(int id) 
        {
            var response = await _carService.DeleteCar(id);
            if (response.StatusCode == Domain.Enum.StatusCode.OK) { return RedirectToAction("GetCars"); }
            return RedirectToAction("Error");
        }
        [HttpGet("Save")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Save(int id)
        {
            if (id == 0) { return View(); }
            var response = await _carService.GetCar(id);
            if (response.StatusCode == Domain.Enum.StatusCode.OK) { return View(response.Data); }
            return RedirectToAction("Error");
        }
        [HttpPost("Save")]
        public async Task<IActionResult> Save(CarViewModel  carViewModel)
        {
            if (ModelState.IsValid)
            {
                if (carViewModel.Id == 0)
                {
                    await _carService.CreateCar(carViewModel);
                }
                else 
                {
                    await _carService.Edit(carViewModel.Id, carViewModel);
                }
            }
            return RedirectToAction("GetCars");
        }
    }
}
