using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Bookkeeping.Models.ViewModels
{
    public class RecordDataViewModel
    {
        public int RecordId { get; set; }

        [DisplayName("類別")]
        public string RecordClass { get; set; }

        [DisplayName("日期")]
        public DateTime RecordDate { get; set; }

        [DisplayName("金額")]
        public int RecordAmount { get; set; }

        [DisplayName("備註")]
        public string RecordMemo { get; set; }
    }
}