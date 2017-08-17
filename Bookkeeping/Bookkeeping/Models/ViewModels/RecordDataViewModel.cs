using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Bookkeeping.Models.ViewModels
{
    public class RecordDataViewModel
    {
        public int RecordId { get; set; }

        [Display(Name = "類別")]
        public string RecordClass { get; set; }

        [Display(Name = "日期")]
        public DateTime RecordDate { get; set; }

        [Display(Name = "金額")]
        public int RecordAmount { get; set; }
    }
}