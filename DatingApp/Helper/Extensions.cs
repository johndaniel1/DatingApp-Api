using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DatingApp.Helper
{
    public static class Extensions
    {
        public static int CalculateAge(this DateTime dateTime)
        {
            var age = DateTime.Today.Year - dateTime.Year;
            if(DateTime.Today.Month <= dateTime.Month && DateTime.Today.Date < dateTime.Date)
            {
                age= age-1;
            }
            return age;
        }
    }
}