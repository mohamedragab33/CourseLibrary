using CourseLibrary.API.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CourseLibrary.Api.Helpers
{
    public static class DateTimeOfsetValue
    {
        public static int GetCurrentAge(this DateTimeOffset dateTimeoffset) {

            var CurrentDate = DateTime.UtcNow;

            int age = CurrentDate.Year - dateTimeoffset.Year;
            if (CurrentDate < dateTimeoffset.AddYears(age))
            {


                age--;
            }
            return age;
        
        }





    }
}
