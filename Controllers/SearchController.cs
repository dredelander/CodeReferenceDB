using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CodeHelpRepoWebApp.Data;
using CodeHelpRepoWebApp.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CodeHelpRepoWebApp.Controllers
{
    public class SearchController : Controller
    {

        private readonly ApplicationDBContext _db;

        public SearchController(ApplicationDBContext db)
        {
            _db = db;
        }

        public IActionResult EmptyKeyword()
        {
            return View();
        }
        // GET: /<controller>/
        public IActionResult Index(string keyword)
        {
            if(!String.IsNullOrEmpty(keyword))
            {
                IEnumerable<Reference> objSearchList = _db.References.Where(r => r.Keyphrase.ToLower().Contains(keyword.ToLower())
                    || r.ProjectName.ToLower().Contains(keyword.ToLower()) || r.Language.ToLower().Contains(keyword.ToLower()));
                return View(objSearchList);
            }

            return RedirectToAction("EmptyKeyword");
        }
    }
}

