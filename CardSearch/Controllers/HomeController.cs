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
            /*
            if (!String.IsNullOrEmpty(searchkey))
                {
                    foreach (var item in card)
                    {

                        if (item.name.ToLower().Contains(searchkey.ToLower()) || item.desc.ToLower().Contains(searchkey.ToLower()) || item.atk.ToString() == searchkey || item.def.ToString() == searchkey || item.linkval.ToString() == searchkey || item.scale.ToString() == searchkey || item.type.ToLower().Contains(searchkey.ToLower()) || item.race.ToLower().Contains(searchkey.ToLower()) || item.level.ToString() == searchkey)
                        {                                    
                            scard.Add(item);   
                        }
                    }
                }
                else
                {
                    foreach (var item in card)
                    {
                        scard.Add(item);
                    }
                }
            }
            else
            {
                card = Enumerable.Empty<CardModel>();
                ModelState.AddModelError(string.Empty, "Eyvah");
            }

        }
        IEnumerable<CardModel> deneme = scard.ToPagedList(p, 20);
        return View(deneme);




        /*const int pageSize = 10;
        if (pg < 1) pg = 1;
        int recsCount = card.Count();
        var pager = new Pager(recsCount, pg, pageSize);
        int recSkip = (pg - 1) * pageSize;
        var data = card.Skip(recSkip).Take(pager.PageSize).ToList();
        this.ViewBag.Pager = pager;
        //return View(card);

         <div class="container">
@if (pager.TotalPages > 0)
        {
    <ul class="pagination justify-content-end">
        @for (var pge = pager.StartPage; pge < pager.EndPage; pge++)
        {
            <li class="page-item @(pge == pager.CurrentPage ? "active" : "")">
                <a class="page-link" asp-controller="Home" asp-action="Index" asp-route-pg="@pge"> @pge </a>
            </li>
        }
    </ul>
        }


</div>
         Pager pager = new Pager();

int pageNo = 0;
if (ViewBag.Pager != null)
{
    pager = ViewBag.Pager;
    pageNo = pager.CurrentPage;
}
         */

    }

}
