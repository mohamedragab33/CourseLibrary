using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CourseLibrary.Api.Models
{
    public class AuthorForCreation
    {
        public string FirstName { get; set; }

        
        public string LastName { get; set; }

       
        public DateTimeOffset DateOfBirth { get; set; }
    
        public string MainCategory { get; set; }
        public ICollection<courseforCreation> courses
        {

            get; set;
        } = new List<courseforCreation>();
    }
}
