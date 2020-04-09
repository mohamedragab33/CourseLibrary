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
    [Route("api/authors/{authorid}/course")]
    public class CourseController : ControllerBase
    {
        private readonly ICourseLibraryRepository _repo;
        private readonly IMapper _map;

        public CourseController(ICourseLibraryRepository repo, IMapper map)
        {

            _repo = repo;
            _map = map ??
            throw new ArgumentNullException(nameof(map));


        }
        [HttpGet]
        public ActionResult<IEnumerable<CourseDto>> GetAllCourses(Guid authorid)
        {


            if (!_repo.AuthorExists(authorid))
            {

                return NotFound();

            }
            var courses = _repo.GetCourses(authorid);

            return Ok(_map.Map<IEnumerable<CourseDto>>(courses));

        }

        [HttpGet("{courseId}", Name = "GetCourse")]



        public ActionResult<CourseDto> GetSpasifcCousre(Guid authorId, Guid CourseId)
        {

            if (!_repo.AuthorExists(authorId))
            {

                return NotFound();

            }
            var spasifcCouse = _repo.GetCourse(authorId, CourseId);

            if (spasifcCouse == null)
            {

                return NotFound();


            }
            return Ok(_map.Map<CourseDto>(spasifcCouse));


        }
        [HttpPost]
       
        public ActionResult<CourseDto> ADDNewCourse(Guid authorid, courseforCreation courseforCreation) {


            if (!_repo.AuthorExists(authorid)) {

                return NotFound();
            
            }

            var courseEntity = _map.Map<Course>(courseforCreation);
            _repo.AddCourse(authorid, courseEntity);
            _repo.Save();

            var courseToReturn = _map.Map<CourseDto>(courseEntity);
            return CreatedAtRoute("GetCourse", new
            {

                AuthorId = authorid, courseId =courseToReturn.Id 


            },courseToReturn); ;



        }


    }
}
