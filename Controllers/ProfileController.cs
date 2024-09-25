using BartmartWeb.Models;
using Firebase.Database;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
namespace BartmartWeb.Controllers
{
   public class ProfileController : Controller
   {

           private readonly FirebaseClient _firebaseClient;
  public ProfileController()
       {
      //  FirebaseConfig.InitializeFirebase();
        _firebaseClient = new FirebaseClient("https://bartmartdb-4d9a9-default-rtdb.firebaseio.com");
       
       }
        public IActionResult Index()
        {
            return View();
        }
                public IActionResult ManageAccount()
{
   return View();
}
   public IActionResult MyListings()
   {
       return View();
   }

        public IActionResult NewListing()
        {
            return View();
        }

    }
}