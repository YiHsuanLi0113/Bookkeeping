using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Bookkeeping.Models.ViewModels
{
    public class RecordDataViewModel
    {
        public int RecordId { get; set; }
        public string RecordClass { get; set; }
        public DateTime RecordDate { get; set; }
        public int RecordAmount { get; set; }
    }
}