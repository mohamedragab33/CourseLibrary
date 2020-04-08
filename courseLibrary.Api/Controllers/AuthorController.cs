using AutoMapper;
using CourseLibrary.Api.Helpers;
using CourseLibrary.Api.Models;
using CourseLibrary.API.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CourseLibrary.Api.Controllers
{
    [ApiController]
    [Route("api/authors")]
    public class AuthorController : ControllerBase
    {
        private readonly ICourseLibraryRepository _course;
        private readonly IMapper _mapper;

        public AuthorController(ICourseLibraryRepository course, IMapper maaper)
        {
            _course = course;
            _mapper = maaper ??
            throw new ArgumentNullException(nameof(maaper));

        }
        [HttpGet()]
        public ActionResult<IEnumerable<AuthorDto>> GetAllAuthor(string mainCategory)
        {


            var AuthorsFromDto = _course.GetAllAuthor(mainCategory);


            return Ok(_mapper.Map<IEnumerable<AuthorDto>>(AuthorsFromDto));




        }


        [HttpGet("{AuthorId:Guid}")]
        public IActionResult GetAuthor(Guid AuthorId)
        {


            var AuthorsFromDto = _course.GetAuthor(AuthorId);
            if (AuthorsFromDto == null)
            {


                return NotFound();

            }



            return Ok(_mapper.Map<AuthorDto>(AuthorsFromDto));


        }


        //[HttpGet]
        //public ActionResult<IEnumerable<AuthorDto>> GetAuthors(string mainCategory)
        //{

        //    var authorsFromRepo = _course.GetAuthors();

        //    return Ok(_mapper.Map<IEnumerable<AuthorDto>>(authorsFromRepo));


        //}



    }
}
