using BartmartWeb.Models;
using Firebase.Database;
using Firebase.Database.Query;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;
namespace BartmartWeb.Controllers
{
   public class AdminController : Controller
   {
       private readonly FirebaseClient _firebaseClient;
       public AdminController()
       {
           _firebaseClient = new FirebaseClient("https://bartmartdb-4d9a9-default-rtdb.firebaseio.com");
       }
       public async Task<IActionResult> Index(int pageNumber = 1, int pageSize = 20)
       {
           var users = await _firebaseClient
               .Child("users")
               .OnceAsync<User>();
           var paginatedUsers = users.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToList();
           ViewBag.TotalPages = (int)Math.Ceiling(users.Count / (double)pageSize);
           return View(paginatedUsers);
       }
       public async Task<IActionResult> Edit(string id)
       {
           var user = await _firebaseClient
               .Child("users")
               .Child(id)
               .OnceSingleAsync<User>();
           return View(user);
       }
       [HttpPost]
       public async Task<IActionResult> Edit(string id, User user)
       {
           await _firebaseClient
               .Child("users")
               .Child(id)
               .PutAsync(user);
           return RedirectToAction(nameof(Index));
       }
       public async Task<IActionResult> Delete(string id)
       {
           await _firebaseClient
               .Child("users")
               .Child(id)
               .DeleteAsync();
           return RedirectToAction(nameof(Index));
       }
       [HttpPost]
       public async Task<IActionResult> Create(User user)
       {
           var newUserRef = await _firebaseClient
               .Child("users")
               .PostAsync(user);
           user.UserID = newUserRef.Key;
           user.IsAdmin = false; // Default to non-admin
           await _firebaseClient
               .Child("users")
               .Child(user.UserID)
               .PutAsync(user);
           return RedirectToAction(nameof(Index));
       }
       [HttpPost]
       public async Task<IActionResult> CreateAdmin(User user)
       {
           var newUserRef = await _firebaseClient
               .Child("users")
               .PostAsync(user);
           user.UserID = newUserRef.Key;
           user.IsAdmin = true; // Set admin flag to true
           await _firebaseClient
               .Child("users")
               .Child(user.UserID)
               .PutAsync(user);
           return RedirectToAction(nameof(Index));
       }
   }
}