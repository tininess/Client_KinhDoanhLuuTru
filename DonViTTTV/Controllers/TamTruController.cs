using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DonViTTTV.Models;
using DonViTTTV.ServiceReference1;
using MvcPaging;
using DonViTTTV.Classes;

namespace DonViTTTV.Controllers
{
    public class TamTruController : Controller
    {
        //
        // GET: /TamTru/

        Level2ServiceClient proxy = new Level2ServiceClient();
        TamTruAccessConsolidator access = new TamTruAccessConsolidator();
        private const int defaultPageSize = 3;
        [Authorize]
         public ActionResult Index(int ?page)
        {
            string username=User.Identity.Name;
            var today=DateTime.Today;
            int currentPageIndex = page.HasValue ? page.Value - 1 : 0;
            IList<TamTruModel> list = access.getAllTTTV(username).Where(e => e.TT_NgayDi <= today).ToList();                   
            if (Request.IsAjaxRequest())
            {
                return PartialView("_ListControl", list.ToPagedList(currentPageIndex, defaultPageSize));
            }
            else
            {
                return View(list.ToPagedList(currentPageIndex, defaultPageSize));
            }
        }

        public ActionResult Search(int? page, string keySearch = "code", string valSearch = "", string keyFilter = "3")
        {
            ViewData["keySearch"] = keySearch;
            ViewData["valSearch"] = valSearch;
            ViewData["keyFilter"] = keyFilter;
            string username = User.Identity.Name;
            var today=DateTime.Today;
            int currentPageIndex = page.HasValue ? page.Value - 1 : 0;
            int filter = 3;
            switch (keyFilter)
            {
                case "1":
                    filter = 1;
                    break;
                case "2":
                    filter = 2;
                    break;
                case "3":
                    filter = 3;
                    break;
              
                
            }
            var list = access.getAllTTTV(username);
            if (keySearch == "code")
            {
                if (filter == 3)
                {
                    list = list.Where(e => e.TT_GiayTo.ToLower().Contains(valSearch.ToLower()) && e.TT_NgayDi <= today).OrderBy(e => e.TT_FullName).ToList().ToPagedList(currentPageIndex, defaultPageSize);
                }
                else if (filter == 2)
                {
                    list = list.Where(e => e.TT_GiayTo.ToLower().Contains(valSearch.ToLower()) && e.TT_NgayDi >= today).OrderBy(e => e.TT_FullName).ToList().ToPagedList(currentPageIndex, defaultPageSize);
                }
                else
                {
                    list = list.Where(e => e.TT_GiayTo.ToLower().Contains(valSearch.ToLower())).OrderBy(e => e.TT_FullName).ToList().ToPagedList(currentPageIndex, defaultPageSize);
                }

            }
            else
            {
                if (filter == 3)
                {
                    list = list.Where(e => e.TT_FullName.ToLower().Contains(valSearch.ToLower()) && e.TT_NgayDi <= today).OrderBy(e => e.TT_FullName).ToList().ToPagedList(currentPageIndex, defaultPageSize);
                }
                else if (filter == 2)
                {
                    list = list.Where(e => e.TT_FullName.ToLower().Contains(valSearch.ToLower()) && e.TT_NgayDi >= today).OrderBy(e => e.TT_FullName).ToList().ToPagedList(currentPageIndex, defaultPageSize);
                }
                else
                {
                    list = list.Where(e => e.TT_FullName.ToLower().Contains(valSearch.ToLower())).OrderBy(e => e.TT_FullName).ToList().ToPagedList(currentPageIndex, defaultPageSize);
                }
 
            }
            if (Request.IsAjaxRequest())
            {
                return PartialView("_ListControl", list);
            }
            else
            {
                return View("Index", list);
            }


        }

        //
        // GET: /TamTru/Details/5

        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /TamTru/Create

        public ActionResult Create()
        {
            ViewData["GiayTo"] = new SelectList(proxy.getAllGiayTo(), "ID_GiayTo", "GiayTo");
            ViewData["LiDo"] = new SelectList(proxy.getAllLiDo(), "ID_LiDo", "LiDo");
            ViewData["QuocTich"] = new SelectList(proxy.getAllQuocTich(), "ID_QuocTich", "QuocTich");
            return View();
        } 

        //
        // POST: /TamTru/Create

        [HttpPost]
        public ActionResult Create(TamTruModel model)
        {
            if (ModelState.IsValid)
            {
                string user = User.Identity.Name.ToString();
                proxy.insertbyHotel(user, model.SelectedGiayToValue, model.SelectedLiDoValue, model.SelectedQuocTichValue,model.TT_FullName, model.TT_DiaChiThuongTru, model.TT_NgayDen, model.TT_NgayDi, model.TT_Room, model.TT_GiayTo, model.TT_LiDoKhac);
                return View("Success1");
            }
            ViewData["GiayTo"] = new SelectList(proxy.getAllGiayTo(), "ID_GiayTo", "GiayTo", model.SelectedGiayToValue);
            ViewData["LiDo"] = new SelectList(proxy.getAllLiDo(), "ID_LiDo", "LiDo", model.SelectedLiDoValue);
            ViewData["QuocTich"] = new SelectList(proxy.getAllQuocTich(), "ID_QuocTich", "QuocTich", model.SelectedQuocTichValue);
            return View(model);
        }
        
        //
        // GET: /TamTru/Edit/5
 
        public ActionResult Edit(int id)
        {
            TamTruModel model = access.getTTTVByID(id);
            ViewData["GiayTo"] = new SelectList(proxy.getAllGiayTo(), "ID_GiayTo", "GiayTo", model.SelectedGiayToValue);
            ViewData["LiDo"] = new SelectList(proxy.getAllLiDo(), "ID_LiDo", "LiDo", model.SelectedLiDoValue);
            ViewData["QuocTich"] = new SelectList(proxy.getAllQuocTich(), "ID_QuocTich", "QuocTich", model.SelectedQuocTichValue);
            return View(model);
        }

        //
        // POST: /TamTru/Edit/5

        [HttpPost]
        public ActionResult Edit(TamTruModel model)
        {
            if (ModelState.IsValid)
            {
                string user = User.Identity.Name.ToString();
                proxy.UpdatetamtruByHotel(model.MaTamTru, model.SelectedGiayToValue, model.SelectedLiDoValue, model.SelectedQuocTichValue, model.TT_FullName, model.TT_DiaChiThuongTru, model.TT_NgayDen, model.TT_NgayDi, model.TT_Room, model.TT_GiayTo, model.TT_LiDoKhac, user);
                return RedirectToAction("Index");
            }
            ViewData["GiayTo"] = new SelectList(proxy.getAllGiayTo(), "ID_GiayTo", "GiayTo", model.SelectedGiayToValue);
            ViewData["LiDo"] = new SelectList(proxy.getAllLiDo(), "ID_LiDo", "LiDo", model.SelectedLiDoValue);
            ViewData["QuocTich"] = new SelectList(proxy.getAllQuocTich(), "ID_QuocTich", "QuocTich", model.SelectedQuocTichValue);
            return View();
        }

        //
        // GET: /TamTru/Delete/5
 
        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /TamTru/Delete/5

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
 
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
