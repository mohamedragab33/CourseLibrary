using AutoMapper;
using CourseLibrary.Api.Helpers;
using CourseLibrary.Api.Models;
using CourseLibrary.API.Entities;
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


        [HttpGet("{AuthorId:Guid}" , Name ="GetAuthor")]
        public IActionResult GetAuthor(Guid AuthorId)
        {


            var AuthorsFromDto = _course.GetAuthor(AuthorId);
            if (AuthorsFromDto == null)
            {


                return NotFound();

            }



            return Ok(_mapper.Map<AuthorDto>(AuthorsFromDto));


        }


        [HttpPost]
        public ActionResult<AuthorDto> AddAuthor(AuthorForCreation authorForCreation) {

            if (authorForCreation == null)
            {


                return NotFound();

            }
            var authorEntity = _mapper.Map<Author>(authorForCreation);
            _course.AddAuthor(authorEntity);
            _course.Save();

            var authorToReturn = _mapper.Map<AuthorDto>(authorEntity);
            return CreatedAtRoute("GetAuthor", new{authorId= authorToReturn.Id},authorToReturn);

        
        
        }


        //[HttpGet]
        //public ActionResult<IEnumerable<AuthorDto>> GetAuthors(string mainCategory)
        //{

        //    var authorsFromRepo = _course.GetAuthors();

        //    return Ok(_mapper.Map<IEnumerable<AuthorDto>>(authorsFromRepo));


        //}



    }
}
