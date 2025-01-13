using AutoMapper;
using dotnet_boilerplate.Domain.Entities;
using DotnetBoilerplate.Application.Dtos;
using DotnetBoilerplate.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotnetBoilerplate.Application.Mapper
{
    public class OrderMapperProfile : Profile
    {
        public OrderMapperProfile() 
        {
            CreateMap<Order, PaymentRequest>().ReverseMap();
        }
    }
}
