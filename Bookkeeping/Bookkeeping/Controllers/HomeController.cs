using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Bookkeeping.Models.ViewModels;

namespace Bookkeeping.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            List<RecordDataViewModel> record = new List<RecordDataViewModel>();
            DateTime date = new DateTime(2017, 7, 24);

            for(var i = 0; i < 10; i++)
            {
                record.Add(new RecordDataViewModel()
                {
                    RecordClass = "支出" ,
                    RecordDate = date,
                    RecordAmount = 1000
                });
            }               

            return View(record);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}