using LaundryApplication.Models;
using LaundryApplication.Shared;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Net;
using System.Numerics;

namespace LaundryApplication.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IStorage _storage;
        private readonly ISessionInfo _sessionMgr;
        private readonly IPricing _priceMgr;

        public HomeController(ILogger<HomeController> logger, IStorage storage, ISessionInfo sessionInfo, IPricing pricing)
        {

            _logger = logger;
            _storage = storage;
            _sessionMgr = sessionInfo;
            _priceMgr = pricing;
        }

        public IActionResult Index()
        {
            // access session storage so that it is tracked (otherwise we'll get a new session per request)
            HttpContext.Session.Set("init", new byte[] { 0 });

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Login(string phone)
        {
            try
            {
                User theUser = _storage.GetUserFromPhone(phone);

                _sessionMgr.SetCurrentUser(HttpContext.Session.Id, theUser);

                return View("vendorDetails", new CheckoutWithAccount(theUser, _priceMgr.getMensDryCleanTShirtRate(), _priceMgr.getMensDryCleanJeansRate(), _priceMgr.getMensDryCleanKurtaRate(), _priceMgr.getTaxRate()));
            }
            catch (Exception)
            {
                return View("Error", new ErrorViewModel(String.Format("User with phone {0} not found!", phone)));
            }
        }

        //[HttpPost]
        public IActionResult Checkout(int TShirtCount, int JeansCount, int KurtaCount, double TShirtCost, double JeansCost, double KurtaCost, double subtotal)
        {
            User theUser = _sessionMgr.GetCurrentUser(HttpContext.Session.Id);

            return View("checkout_with_account", new CheckoutModel(theUser, TShirtCount, JeansCount, KurtaCount, TShirtCost, JeansCost, KurtaCost, subtotal, _priceMgr.getTaxRate()));
        }

        public IActionResult AccountInfo()
        {
            try
            {
                User theUser = _sessionMgr.GetCurrentUser(HttpContext.Session.Id);

                return View("myAccount", new AccountModel());
            }
            catch (Exception)
            {
                return View("Error", new ErrorViewModel("No Logged-in User"));
            }
        }

        public IActionResult CreateAccount(string phone, string user, string email, string pwd)
        {
            try
            {
                _storage.AddUser(phone, user, email);
            }
            catch (Exception exc)
            {
                return View("Error", new ErrorViewModel(exc.Message));
            }

            return View("Index");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel(""));
        }
    }
}