using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CourseLibrary.API.Entities;
using CourseLibrary.Api.Models;
using CourseLibrary.Api.Helpers;

namespace CourseLibrary.Api.Profiles
{
    public class AuthorProfile : Profile
    {

        public AuthorProfile()
        {
            CreateMap<Author, AuthorDto>()

                .ForMember(

               dest => dest.Name,
               opt => opt.MapFrom(src => $"{src.FirstName} {src.LastName}"))
                .ForMember(


                dest => dest.age,
                opt => opt.MapFrom(src => src.DateOfBirth.GetCurrentAge())


                )


                 ;
            CreateMap<AuthorForCreation,Author>();

        }


    }
}
