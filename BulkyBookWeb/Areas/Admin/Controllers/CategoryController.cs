using BulkBook.DataAccess.Repository.IRepository;
using BulkyBook.DataAccess;
using BulkyBook.Models;
using Microsoft.AspNetCore.Mvc;

namespace BulkyBookWeb.Areas.Admin.Controllers;
[Area("Admin")]

public class CategoryController : Controller
{

    private readonly IUnitOfWork _context;

    public CategoryController(IUnitOfWork context)
    {
        _context = context;
    }

    public IActionResult Index()
    {
        IEnumerable<Category> objCategoryList = _context.Category.GetAll();
        return View(objCategoryList);
    }

    public IActionResult Create()
    {
        return View();
    }
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Create(Category obj)
    {
        if (obj.Name == obj.DisplayOrder.ToString())
        {
            ModelState.AddModelError("CustomError", "The displayorder can't match the name");
        }
        if (ModelState.IsValid)
        {
            _context.Category.Add(obj);
            _context.Save();
            TempData["success"] = "Category created successfully";
            return RedirectToAction("Index");
        }
        return View(obj);
    }
    //Edit Page Get function
    public IActionResult Edit(int? id)
    {
        if (id == null || id == 0)
        {
            return NotFound();
        }
        var dbCategory = _context.Category.GetFirstOrDefault(i => i.Id == id);

        if (dbCategory == null)
        {
            return NotFound();
        }
        return View(dbCategory);
    }
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Edit(Category obj)
    {
        if (obj.Name == obj.DisplayOrder.ToString())
        {
            ModelState.AddModelError("CustomError", "The displayorder can't match the name");
        }
        if (ModelState.IsValid)
        {
            _context.Category.Update(obj);
            _context.Save();
            TempData["success"] = "Edited Successfully";
            return RedirectToAction("Index");
        }
        return View(obj);
    }

    //Delete Page Get function
    public IActionResult Delete(int? id)
    {
        if (id == null || id == 0)
        {
            return NotFound();
        }
        var dbCategory = _context.Category.GetFirstOrDefault(i => i.Id == id);

        if (dbCategory == null)
        {
            return NotFound();
        }
        return View(dbCategory);
    }
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public IActionResult DeletePOST(int? id)
    {
        var obj = _context.Category.GetFirstOrDefault(i => i.Id == id);

        if (obj == null)
        {
            return NotFound();
        }

        _context.Category.Remove(obj);
        _context.Save();

        return RedirectToAction("Index");


    }
}
