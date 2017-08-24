using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Bookkeeping.ValidateAttribute
{
    public sealed class BeforeTodayAttribute : ValidationAttribute
    {
        public BeforeTodayAttribute()
        {
        }
        public override bool IsValid(object date)
        {
            DateTime today = DateTime.Now.Date;
            DateTime pickDate = ((DateTime)date).Date;

            var isValidate = pickDate<= today;
            if (date == null)
                return true;
            if (isValidate)
            {
                return true;
            }
            return false;
        }
    }
}


