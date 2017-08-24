using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Bookkeeping.ValidateAttribute;

namespace Bookkeeping.Models.ViewModels
{
    public class RecordDataViewModel
    {
        public int RecordId { get; set; }

        [Required(ErrorMessage = "請選擇{0}")]
        [DisplayName("類別")]
        public string RecordClass { get; set; }

        [Required(ErrorMessage = "請選擇{0}")]
        [BeforeToday(ErrorMessage = "選擇之{0}不得超過今日")]
        [DisplayName("日期")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime RecordDate { get; set; }

        [Required(ErrorMessage = "請輸入{0}")]
        [DisplayName("金額")]
        [RegularExpression(@"^\+?[1-9][0-9]*$", ErrorMessage = "請輸入大於0、整數之金額")]
        public int RecordAmount { get; set; }

        [Required(ErrorMessage = "紀錄一下自己把錢花在哪吧")]
        [StringLength(100, ErrorMessage = "輸入之內容長度不可超過{1}字")]
        [DisplayName("備註")]
        public string RecordMemo { get; set; }
    }
}