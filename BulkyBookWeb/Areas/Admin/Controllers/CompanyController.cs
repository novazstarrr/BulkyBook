using System.Linq;
using BulkBook.DataAccess.Repository;
using BulkBook.DataAccess.Repository.IRepository;
using BulkyBook.DataAccess;
using BulkyBook.Models;
using BulkyBook.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.IO;
using BulkyBook.Utility;

namespace BulkyBookWeb.Areas.Admin.Controllers;
[Area("Admin")]
[Authorize(Roles = SD.Role_Admin)]
public class CompanyController : Controller
{

        private readonly IUnitOfWork _context;
        


        public CompanyController(IUnitOfWork context)
        {
            _context = context;
            
        }

        public IActionResult Index()
        {
           
            return View();
        }

        
        //Get
        public IActionResult Upsert(int? id)
        {
        Company company = new();
            
                

            if (id == null || id == 0)
            {
                //create product
                
                return View(company);
            }
            else
            {
            company = _context.Company.GetFirstOrDefault(u => u.Id == id);
            return View(company);
            //update product
            }
            
           
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Upsert(Company obj)
        {
            
            if (ModelState.IsValid)
            {
                
              
                if (obj.Id == 0)
            {
                _context.Company.Add(obj);
                TempData["success"] = "Updated Successfully";
            }
                else
            {
                _context.Company.Update(obj);
            }

                
                _context.Save();
                TempData["success"] = "Updated Successfully";
                return RedirectToAction("Index");
            }
            return View(obj);
        }

        
        

        #region API CALLS
        [HttpGet]
        public IActionResult GetAll()
        {
            var companyList = _context.Company.GetAll();
            return Json(new { data = companyList });
        }

    [HttpDelete]
    
    public IActionResult Delete(int? id)
    {
        var obj = _context.Company.GetFirstOrDefault(i => i.Id == id);

        if (obj == null)
        {
            return Json(new { success = false, message = "Error while deleting"});
        }

        
        
         
        _context.Company.Remove(obj);
        _context.Save();
        return Json(new { success = true, message = "Delete Success Babyyyyyyyyyyy" });







    }
    #endregion

}




