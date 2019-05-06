using AutoMapper;
using MovieStore2019.DTOs;
using MovieStore2019.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MovieStore2019.App_Start
{
    public class MappingProfile : Profile
    {
        //Here we add a constructor.
        public MappingProfile()
        {
            //We use Mapper.CreateMap generic method to create a mapping configuration between two types.
            //This method takes 2 parameters: the first is the Source, the second is the Target.
            Mapper.CreateMap<Customer, CustomerDto>(); //I want to be able to map a Customer to a CustomerDto.
            Mapper.CreateMap<CustomerDto, Customer>().ForMember(c => c.Id, opt => opt.Ignore()); //I also want to be able to map a CustomerDto to a Customer.

            Mapper.CreateMap<Movie, MovieDto>();
            Mapper.CreateMap<MovieDto, Movie>().ForMember(m => m.Id, opt => opt.Ignore());


            //When we call this CreateMap method AutoMapper uses reflection to scan these types, it finds their properties and maps them
            //based on their name. 
            //This is why we call AutoMapper a convention based mapping tool, because it uses property names as the convention to map objects.

            /*
             *  WE NEED TO LOAD THIS PROFILE WHEN THE APPLICATION IS STARTED:
             *  Solution Explorer -> Global.asax -> Global.asax.cs -> We use the Mapper class defined in AutoMapper and the Initialize method
             *  -> Mapper.Initialize(c => c.AddProfile<MappingProfile>());
             *  
             *  Initialize() takes a parameter of type Action<IConfiguraton> --> When we see this kind of type we can pass a lamda expression.
             *  
             *  (c => c.AddProfile<MappingProfile>) --> c stands for configuration, and in AddProfile<> generic method we pass the MappingProfile
             *  that we created here.
             */
        }
    }
}