using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Bookkeeping.Models.ViewModels;
using Bookkeeping.Repositories;
using Bookkeeping.Models.Service;
using PagedList;

namespace Bookkeeping.Controllers
{
    public class HomeController : Controller
    {
        private readonly RecordListService _recordSvc;
        private int pageSize = 10;

        public HomeController()
        {
            var unitOfWork = new EFUnitOfWork();
            _recordSvc = new RecordListService(unitOfWork);
        }

        public ActionResult Index(int? page)
        {
            //List<RecordDataViewModel> record = new List<RecordDataViewModel>();
            //DateTime date = new DateTime(2017, 7, 24);

            //for(var i = 0; i < 10; i++)
            //{
            //    record.Add(new RecordDataViewModel()
            //    {
            //        RecordClass = "支出" ,
            //        RecordDate = date,
            //        RecordAmount = 1000
            //    });
            //}               
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        // GET: RecordList/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: RecordList/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "RecordId,RecordClass,RecordAmount,RecordDate,RecordMemo")] RecordDataViewModel record)
        {
            //if (ModelState.IsValid)
            //{
                record.RecordId = Math.Abs((Guid.NewGuid().GetHashCode()));
                _recordSvc.Add(record);
                _recordSvc.Save();

                return RedirectToAction("Index");
            //}
            //var result = new RecordDataViewModel()
            //{
            //    RecordId = record.RecordId,
            //    RecordClass = record.RecordClass,
            //    RecordAmount = record.RecordAmount,
            //    RecordDate = record.RecordDate,
            //    RecordMemo = record.RecordMemo
            //};
            //return View(result);
        }


        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        private IPagedList<RecordDataViewModel> getPagedList(int page)
        {
            return _recordSvc.Lookup().OrderByDescending(x => x.RecordDate).ToPagedList(page, pageSize);
        }
    }
}