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
public class ProductController : Controller
{

        private readonly IUnitOfWork _context;
        private readonly IWebHostEnvironment _webhostenvironment;


        public ProductController(IUnitOfWork context, IWebHostEnvironment webhostenvironment)
        {
            _context = context;
            _webhostenvironment = webhostenvironment;   
        }

        public IActionResult Index()
        {
           
            return View();
        }

        
        //Get
        public IActionResult Upsert(int? id)
        {
            ProductVM productVM = new()
            {
                Product=new(),
                CategoryList = _context.Category.GetAll().Select(i => new SelectListItem
                {
                    Text = i.Name,
                    Value = i.Id.ToString()
                }),

                CoverTypeList = _context.CoverType.GetAll().Select(i => new SelectListItem
                {
                    Text = i.Name,
                    Value = i.Id.ToString()
                })
            };

            if (id == null || id == 0)
            {
                //create product
                
                return View(productVM);
        }
        else
            {
            productVM.Product = _context.Product.GetFirstOrDefault(u => u.Id == id);
            return View(productVM);
            //update product
            }
            
           
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Upsert(ProductVM obj, IFormFile? file)
        {
            
            if (ModelState.IsValid)
            {
                string wwwRootPath = _webhostenvironment.WebRootPath;
                if (file != null)
                {
                    string fileName =  Guid.NewGuid().ToString();
                    var uploads = Path.Combine(wwwRootPath, @"images\products");
                    var extension = Path.GetExtension(file.FileName);

                    if (obj.Product.ImageUrl != null)
                {
                    var oldImagePath = Path.Combine(wwwRootPath, obj.Product.ImageUrl.TrimStart('\\'));
                    if (System.IO.File.Exists(oldImagePath))
                    {
                        System.IO.File.Delete(oldImagePath);
                    }
                }

                    using (var fileStreams = new FileStream(Path.Combine(uploads, fileName+extension)
                        ,FileMode.Create))
                    {
                        file.CopyTo(fileStreams);
                    }
                    obj.Product.ImageUrl = @"\images\products\" + fileName + extension;

                }
                if (obj.Product.Id == 0)
            {
                _context.Product.Add(obj.Product);
            }
                else
            {
                _context.Product.Update(obj.Product);
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
        var productList = _context.Product.GetAll(includeProperties: "Category,CoverType");
        return Json(new { data = productList });
    }


    [HttpDelete]
    
    public IActionResult Delete(int? id)
    {
        var obj = _context.Product.GetFirstOrDefault(i => i.Id == id);

        if (obj == null)
        {
            return Json(new { success = false, message = "Error while deleting"});
        }

        var oldImagePath = Path.Combine(_webhostenvironment.WebRootPath, obj.ImageUrl.TrimStart('\\'));
        if (System.IO.File.Exists(oldImagePath))
        {
            System.IO.File.Delete(oldImagePath);
        }

        _context.Product.Remove(obj);
        _context.Save();
             return Json(new { success = true, message = "Delete Success Babyyyyyyyyyyy" });







    }
    #endregion

}




