using AutoMapper;
using CourseLibrary.Api.Helpers;
using CourseLibrary.Api.Models;
using CourseLibrary.API.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CourseLibrary.Api.Profiles
{
    public class CourseProfile : Profile
    {

        public CourseProfile()
        {

            CreateMap<Course, CourseDto>();
            CreateMap<courseforCreation,Course>();


        }
    }
}
