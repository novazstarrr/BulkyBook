using BulkBook.DataAccess.Repository.IRepository;
using BulkyBook.Models;
using BulkyBook.Models.ViewModels;
using BulkyBook.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Stripe.Checkout;
using System.Security.Claims;
using static System.Net.WebRequestMethods;

namespace BulkyBookWeb.Areas.Customer.Controllers
{
	[Area("Customer")]
	[Authorize]
	public class CartController : Controller
	{
		private readonly IUnitOfWork _unitOfWork;
		private readonly IEmailSender _emailSender;
		
		[BindProperty]
		public ShoppingCartVM ShoppingCartVMM { get; set; }
		

		public CartController(IUnitOfWork unitOfWork, IEmailSender emailSender)
		{
			_unitOfWork = unitOfWork;
			_emailSender = emailSender;
		}
		public IActionResult Index()
		{
			var claimsIdentity = (ClaimsIdentity)User.Identity;
			var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);

			ShoppingCartVMM = new ShoppingCartVM()
			{
				ListCart = _unitOfWork.ShoppingCart.GetAll(u => u.ApplicationUserId == claim.Value, includeProperties: "Product"),
				OrderHeader = new()
			};
			foreach(var cart in ShoppingCartVMM.ListCart)
			{
				cart.Price = GetPriceBasedOnQuantity(cart.Count, cart.Product.Price,
				cart.Product.Price50, cart.Product.Price100);
				ShoppingCartVMM.OrderHeader.OrderTotal += (cart.Price * cart.Count);
			}
			return View(ShoppingCartVMM);

		}
		[HttpPost]
		[ActionName("Summary")]
		[ValidateAntiForgeryToken]
		public IActionResult SummaryPOST()
		{
			var claimsIdentity = (ClaimsIdentity)User.Identity;
			var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);

			ShoppingCartVMM.ListCart = _unitOfWork.ShoppingCart.GetAll(u => u.ApplicationUserId == claim.Value,
			includeProperties: "Product");

			ShoppingCartVMM.OrderHeader.PaymentStatus = SD.PaymentStatusPending;
			ShoppingCartVMM.OrderHeader.OrderStatus = SD.StatusPending;
			ShoppingCartVMM.OrderHeader.OrderDate = System.DateTime.Now;
			ShoppingCartVMM.OrderHeader.ApplicationUserId = claim.Value;

			foreach (var cart in ShoppingCartVMM.ListCart)
			{
				cart.Price = GetPriceBasedOnQuantity(cart.Count, cart.Product.Price, cart.Product.Price50, cart.Product.Price100);
				ShoppingCartVMM.OrderHeader.OrderTotal += (cart.Price * cart.Count);
			}

			_unitOfWork.OrderHeader.Add(ShoppingCartVMM.OrderHeader);
			_unitOfWork.Save();
			foreach (var cart in ShoppingCartVMM.ListCart)
			{
				OrderDetails orderDetail = new()
				{
					ProductId = cart.ProductId,
					OrderId = ShoppingCartVMM.OrderHeader.Id,
					Price = cart.Price,
					Count = cart.Count
				};
				_unitOfWork.OrderDetails.Add(orderDetail);
				_unitOfWork.Save();
			}
			//stripe settings
			var domain = "https://localhost:7044/";
			var options = new SessionCreateOptions
			{
				PaymentMethodTypes = new List<string>
				{
					"card",
				},
				LineItems = new List<SessionLineItemOptions>()
				,
				Mode = "payment",
				SuccessUrl = domain + $"customer/cart/OrderConfirmation?id={ShoppingCartVMM.OrderHeader.Id}",
				CancelUrl = domain + $"customer/cart/index",
			};

			foreach (var item in ShoppingCartVMM.ListCart)
			{
				var sessionLineItem = new SessionLineItemOptions

				{
					PriceData = new SessionLineItemPriceDataOptions
					{
						UnitAmount = (long)(item.Price * 100),
						Currency = "usd",
						ProductData = new SessionLineItemPriceDataProductDataOptions
						{
							Name = item.Product.Title
						},
					},
					Quantity = item.Count,
				};
				options.LineItems.Add(sessionLineItem);

			}

			var service = new SessionService();
			Session session = service.Create(options);
			_unitOfWork.OrderHeader.UpdateStripePaymentId(ShoppingCartVMM.OrderHeader.Id, session.Id, session.PaymentIntentId);
			_unitOfWork.Save();
			Response.Headers.Add("Location", session.Url);
			return new StatusCodeResult(303);
				   
			
			


			
        }

		public IActionResult OrderConfirmation(int id)
		{
			OrderHeader orderHeader = _unitOfWork.OrderHeader.GetFirstOrDefault(
				u => u.Id == id, includeProperties:"ApplicationUser");
			var service = new SessionService();
			Session session = service.Get(orderHeader.SessionId);
			//stripe status check
			if (session.PaymentStatus.ToLower() == "paid")
			{
				_unitOfWork.OrderHeader.UpdateStripePaymentId(id, orderHeader.SessionId, session.PaymentIntentId);
				_unitOfWork.OrderHeader.UpdateStatus(id, SD.StatusApproved, SD.PaymentStatusApproved);
				_unitOfWork.Save();
			}
			_emailSender.SendEmailAsync(orderHeader.ApplicationUser.Email, "New Order", "<p>New Order Created</p>");
			List<ShoppingCart> shoppingCarts = _unitOfWork.ShoppingCart.GetAll(
				u => u.ApplicationUserId == orderHeader.ApplicationUserId).ToList();
			HttpContext.Session.Clear();
			_unitOfWork.ShoppingCart.RemoveRange(shoppingCarts);
			_unitOfWork.Save();
			return View(id);

		}

        public IActionResult Summary()
		{
			var claimsIdentity = (ClaimsIdentity)User.Identity;
			var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);

			ShoppingCartVMM = new ShoppingCartVM()
			{
				ListCart = _unitOfWork.ShoppingCart.GetAll(u => u.ApplicationUserId == claim.Value,
				includeProperties: "Product"),
					OrderHeader= new()

			};
			ShoppingCartVMM.OrderHeader.ApplicationUser = _unitOfWork.ApplicationUser.GetFirstOrDefault(
			u => u.Id == claim.Value);

			ShoppingCartVMM.OrderHeader.Name = ShoppingCartVMM.OrderHeader.ApplicationUser.Name;
			ShoppingCartVMM.OrderHeader.PhoneNumber = ShoppingCartVMM.OrderHeader.ApplicationUser.PhoneNumber;
			ShoppingCartVMM.OrderHeader.StreetAddress = ShoppingCartVMM.OrderHeader.ApplicationUser.StreetAddress;
			ShoppingCartVMM.OrderHeader.City = ShoppingCartVMM.OrderHeader.ApplicationUser.City;
			ShoppingCartVMM.OrderHeader.State = ShoppingCartVMM.OrderHeader.ApplicationUser.State;
			ShoppingCartVMM.OrderHeader.PostalCode = ShoppingCartVMM.OrderHeader.ApplicationUser.PostalCode;

			foreach (var cart in ShoppingCartVMM.ListCart)
			{
				cart.Price = GetPriceBasedOnQuantity(cart.Count, cart.Product.Price, cart.Product.Price50, cart.Product.Price100);
				ShoppingCartVMM.OrderHeader.OrderTotal += (cart.Price * cart.Count);
			}

			return View(ShoppingCartVMM);
		}
			
		private double GetPriceBasedOnQuantity(double quantity, double price, double price50, double price100)
		{
			if (quantity <= 50)
			{
				return price;
			}
			else
			{
				if (quantity <= 100)
				{
					return price50;
				}
				return price100;
			}
		}

		public IActionResult Plus(int cartId)
		{
			var cart = _unitOfWork.ShoppingCart.GetFirstOrDefault(u => u.Id == cartId);
			_unitOfWork.ShoppingCart.IncrementCount(cart, 1);
			_unitOfWork.Save();
			return RedirectToAction(nameof(Index));
		}
		public IActionResult Remove(int cartId)
		{
			var cart = _unitOfWork.ShoppingCart.GetFirstOrDefault(u => u.Id == cartId);
			_unitOfWork.ShoppingCart.Remove(cart);
			_unitOfWork.Save();
			var count = _unitOfWork.ShoppingCart.GetAll(U => U.ApplicationUserId == cart.ApplicationUserId)
				.ToList().Count;
			HttpContext.Session.SetInt32(SD.SessionCart, count);
			return RedirectToAction(nameof(Index));
		}
		public IActionResult Minus(int cartId)
		{
			var cart = _unitOfWork.ShoppingCart.GetFirstOrDefault(u => u.Id == cartId);
			if (cart.Count <= 1)
			{
				_unitOfWork.ShoppingCart.Remove(cart);
				var count = _unitOfWork.ShoppingCart.GetAll(u => u.ApplicationUserId == cart.ApplicationUserId).ToList().Count -1;
				HttpContext.Session.SetInt32(SD.SessionCart, count);

			}
			else
			{
				_unitOfWork.ShoppingCart.DecrementCount(cart, 1);
			}
			
			_unitOfWork.Save();
			return RedirectToAction(nameof(Index));
		}



	}
}
