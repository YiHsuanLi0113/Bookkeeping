using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Bookkeeping.Repositories;
using Bookkeeping.Models.Service;
using Bookkeeping.Models.ViewModels;

namespace Bookkeeping.Models.Service
{
    public class RecordListService
    {
        private readonly IRepository<AccountBook> _accountRep;
        private readonly IUnitOfWork _unitOfWork;

        public RecordListService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _accountRep = new Repository<AccountBook>(unitOfWork);
        }

        public IEnumerable<RecordDataViewModel> Lookup()
        {
            var source = _accountRep.LookupAll();
            var result = source.Select(record => new RecordDataViewModel()
            {
                RecordClass = record.Categoryyy == 0 ? "支出" : "收入",
                RecordAmount = record.Amounttt,
                RecordDate = record.Dateee,
                RecordMemo = record.Remarkkk
            }).ToList();
            return result;
        }

        public static Guid ToGuid(int value)
        {
            byte[] bytes = new byte[16];
            BitConverter.GetBytes(value).CopyTo(bytes, 0);
            return new Guid(bytes);
        }

        public void Add(RecordDataViewModel record)
        {
            var result = new AccountBook()
            {
                Id = ToGuid(record.RecordId),
                Categoryyy = record.RecordClass == "支出" ?  0 : 1 ,
                Amounttt = record.RecordAmount,
                Dateee = record.RecordDate,
                Remarkkk = record.RecordMemo
            };
            Add(result);
        }

        public void Add(AccountBook record)
        {
            _accountRep.Create(record);
        }


        public void Save()
        {
            _unitOfWork.Save();
        }

        
    }
}