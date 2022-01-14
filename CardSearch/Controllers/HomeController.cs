using CardSearch.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web.Mvc;
using PagedList;

namespace CardSearch.Controllers
{
    public class HomeController : Controller
    {
        //1 GET: Home
        public ActionResult Index(string searcher, int p = 1)
        {
            ViewData["Arama"] = searcher;
            GlobalVar.Veriler();
            if (!String.IsNullOrEmpty(searcher))
                GlobalVar.search(searcher);           
                IEnumerable<CardModel> deneme = GlobalVar.cardres.ToPagedList(p, 20);
                return View(deneme);
        }
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return null;
            }
            {
                GlobalVar.Detail(id);
                return View(GlobalVar.detay);
            }
        }
    }

}
