using AutoCars.Domain.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoCars.Domain.Interfaces
{
    public interface IBaseResponse<T>
    {
        T Data { get; }
        StatusCode StatusCode { get;  }
    }
}
