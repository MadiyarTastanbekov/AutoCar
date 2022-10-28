﻿using AutoCars.Domain.Enum;
using AutoCars.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoCars.Domain.Response
{
    public class BaseResponse<T>:IBaseResponse<T>
    {
        public string Description { get; set; }
        public StatusCode StatusCode { get; set; }

        public T Data { get; set; }
    }
   

}
