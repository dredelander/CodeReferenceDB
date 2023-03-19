using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CodeHelpRepoWebApp.Data;
using CodeHelpRepoWebApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;


// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CodeHelpRepoWebApp.Controllers
{
    public class ReferenceController : Controller
    {

        private readonly ApplicationDBContext _db;
        private readonly IConfiguration _config;

        

        //Constructor
        public ReferenceController(ApplicationDBContext db, IConfiguration config)
        {
            _db = db;
            _config = config;
        }

        // GET: /<controller>/
        public IActionResult Index()
        {
            

            IEnumerable<Reference> objReferenceList = _db.References;
            return View(objReferenceList);
        }

        //GET
        public IActionResult Create()
        {

            return View();
        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Reference obj, string passcode)
        {
            string password = passcode;
            var CRUDcode = _config["Secrets:CRUDcode"];

            if (obj.Language == "default")
            {
                ModelState.AddModelError("CustomError", "Please select a coding language");
            }

            if (password == CRUDcode)
            {

                if (ModelState.IsValid)
                {
                    _db.References.Add(obj);
                    _db.SaveChanges();
                    TempData["success"] = "Reference saved";
                    return RedirectToAction("Index");
                }
            }
            else
            {
                ModelState.AddModelError("CustomError", "Wrong token, please try again or contact admin token help");
            }
            return View(obj);
        }

        //GET
        public IActionResult Edit(int? id)
        {
            if (id == 0 || id == null)
            {
                return NotFound();
            }

            var referenceFromDB = _db.References.Find(id);

            if (referenceFromDB == null)
            {
                return NotFound();
            }

            return View(referenceFromDB);
        }

        //PUT
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Reference obj, string passcode)
        {

             string password = passcode;
            var CRUDcode = _config["Secrets:CRUDcode"];

            if (obj.Language == "default")
            {
                ModelState.AddModelError("CustomError", "Please select a coding language");
            }

            if (password == CRUDcode)
            {
                if (ModelState.IsValid)
                {
                    _db.References.Update(obj);
                    _db.SaveChanges();
                    TempData["success"] = "Reference saved";
                    return RedirectToAction("Index");
                }
            }
            else
            {
                ModelState.AddModelError("CustomError", "Wrong token, please try again or contact admin token help");
            }
        
            
            return View(obj);
        }


        public IActionResult Delete(int? id)
        {
            if (id == 0 || id == null)
            {
                return NotFound();
            }

            var referenceFromDB = _db.References.Find(id);

            if (referenceFromDB == null)
            {
                return NotFound();
            }

            return View(referenceFromDB);
        }

        //DELETE
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteReference(int? id, string passcode)
        {
            var referenceFromDB = _db.References.Find(id);
            string password = passcode;
            var DELETEcode = _config["Secrets:DELETEcode"];

            if (referenceFromDB == null)
            {
                return NotFound();
            }

            if (password == DELETEcode)
            {
                _db.References.Remove(referenceFromDB);
                _db.SaveChanges();
                TempData["success"] = "Reference Deleted";
                return RedirectToAction("Index");
            }
            else
            {
                ModelState.AddModelError("CustomError", "Wrong token, please try again or contact admin token help");
                TempData["error"] = "Wrong token, please try again or contact admin token help";
            }

            
            return RedirectToAction("Delete", referenceFromDB);




        }





    }
}

