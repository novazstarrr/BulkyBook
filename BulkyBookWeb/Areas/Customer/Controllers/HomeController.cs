using System.Diagnostics;
using System.Security.Claims;
using BulkBook.DataAccess.Repository.IRepository;
using BulkyBook.Models;
using BulkyBook.Models.ViewModels;
using BulkyBook.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace BulkyBookWeb.Areas.Customer.Controllers;
[Area("Customer")]


public class HomeController : Controller
{
	private readonly ILogger<HomeController> _logger;
	private readonly IUnitOfWork _unitOfWork;

	public HomeController(ILogger<HomeController> logger, IUnitOfWork unitOfWork)
	{
		_logger = logger;
		_unitOfWork = unitOfWork;
	}


	

	public IActionResult Index(string searchString)
	{
		Func<int, int, string> addTwoAges = (int age1, int age2) => $"The total age = {age1 + age2}";

		var result = addTwoAges(10, 20);

		addTwoAges = (int age, int age2) => $"Something something/.... {age + age2}";
		addTwoAges(10, 20);

		IEnumerable<Product> productList = _unitOfWork.Product.GetAll(
			(product) => searchString.IsNullOrEmpty()  || product.Title.ToUpper().Contains(searchString.ToUpper()),
			"Category,CoverType"
			);

		var model = new HomeViewModel
		{
			Products = productList,
			SearchString = searchString
		};

		return View(model);
	}




	public IActionResult Details(int productid)
	{
		ShoppingCart cartObj = new()
		{
			Count = 1,
			ProductId = productid,
			Product = _unitOfWork.Product.GetFirstOrDefault(u => u.Id == productid, includeProperties: "Category,CoverType")
		/* */
		};

		ShoppingCart cart = new ShoppingCart();

		return View(cartObj);
	}

	[HttpPost]
	[ValidateAntiForgeryToken]
	[Authorize]
	public IActionResult Details(ShoppingCart shoppingCart)
	{
		var claimsIdentity = (ClaimsIdentity)User.Identity;
		var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);
		shoppingCart.ApplicationUserId = claim.Value;

		ShoppingCart cartFromDb = _unitOfWork.ShoppingCart.GetFirstOrDefault(
			u => u.ApplicationUserId == claim.Value && u.ProductId == shoppingCart.ProductId);

		if (cartFromDb == null)
		{
			_unitOfWork.ShoppingCart.Add(shoppingCart);
			_unitOfWork.Save();
			HttpContext.Session.SetInt32(SD.SessionCart, _unitOfWork.ShoppingCart.GetAll(
			u => u.ApplicationUserId == claim.Value).ToList().Count);
		}
		else
		{
			_unitOfWork.ShoppingCart.IncrementCount(cartFromDb, shoppingCart.Count);
			_unitOfWork.Save();
		}
		_unitOfWork.Save();

		return RedirectToAction(nameof(Index));
	}

	public IActionResult Privacy()
	{
		return View();
	}

	[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
	public IActionResult Error()
	{
		return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
	}
}