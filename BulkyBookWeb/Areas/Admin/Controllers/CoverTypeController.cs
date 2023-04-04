using BulkBook.DataAccess.Repository.IRepository;
using BulkyBook.DataAccess;
using BulkyBook.Models;
using BulkyBook.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BulkyBookWeb.Areas.Admin.Controllers;
[Area("Admin")]
[Authorize(Roles = SD.Role_Admin)]
public class CoverTypeController : Controller
{

    private readonly IUnitOfWork _context;

    public CoverTypeController(IUnitOfWork context)
    {
        _context = context;
    }

    public IActionResult Index()
    {
        IEnumerable<CoverType> objCoverType = _context.CoverType.GetAll();
        return View(objCoverType);
    }

    public IActionResult Create()
    {
        return View();
    }
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Create(CoverType obj)
    {
       
        if (ModelState.IsValid)
        {
            _context.CoverType.Add(obj);
            _context.Save();
            TempData["success"] = "CoverType created successfully";
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
        var CoverTypeFromDbFirst = _context.CoverType.GetFirstOrDefault(i => i.Id == id);

        if (CoverTypeFromDbFirst == null)
        {
            return NotFound();
        }
        return View(CoverTypeFromDbFirst);
    }
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Edit(CoverType obj)
    {
        
        if (ModelState.IsValid)
        {
            _context.CoverType.Update(obj);
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
        var CoverTypeFromDbFirst = _context.CoverType.GetFirstOrDefault(i => i.Id == id);

        if (CoverTypeFromDbFirst == null)
        {
            return NotFound();
        }
        return View(CoverTypeFromDbFirst);
    }
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public IActionResult DeletePOST(int? id)
    {
        var obj = _context.CoverType.GetFirstOrDefault(i => i.Id == id);

        if (obj == null)
        {
            return NotFound();
        }

        _context.CoverType.Remove(obj);
        _context.Save();

        return RedirectToAction("Index");


    }
}
