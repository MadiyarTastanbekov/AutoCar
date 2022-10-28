using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoCars.Domain.Enum
{
    public enum TypeCar
    {
        [Display(Name="Легковой автомобиль")]
        PassengerCar=0,
        [Display(Name = "Седан")]
        Sedan=1,
        [Display(Name = "Хэтчбек")]
        HatcBack=2,
        [Display(Name = "Минивен")]
        Minivan=3,
        [Display(Name = "Спортивная машина")]
        SportsCar=4,
        [Display(Name = "Внедорожник")]
        Suv=5
    }
}
