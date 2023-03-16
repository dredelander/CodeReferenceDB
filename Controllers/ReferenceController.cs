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
    public class ReferenceController : Controller
    {

        private readonly ApplicationDBContext _db;

        public ReferenceController(ApplicationDBContext db)
        {
            _db = db;
        }

        // GET: /<controller>/
        public IActionResult Index()
        {
            IEnumerable<Reference> objReferenceList = _db.References;
            return View(objReferenceList);
        }
    }
}

