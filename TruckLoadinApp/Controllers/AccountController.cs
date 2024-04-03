using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using TruckLoadinApp.Models;
using TruckLoadinApp.Models.Account;
using TruckLoadinApp.ViewModels;

namespace TruckLoadinApp.Controllers
{
    public class AccountController : Controller
    {
        
       
            private readonly ILogger<AccountController> _logger;
            private readonly TruckLoadingContextDb _context;

            public AccountController(TruckLoadingContextDb context, ILogger<AccountController> logger)
            {
                _context = context;
                _logger = logger;
            }


            [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
            public IActionResult Error()
            {
                return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
            }


            public IActionResult Index(AccountViewModel model)
            {
                model.LoadUsers(_context);
                return View(model);
            }


            public IActionResult Create(int Id = 0)
            {
                var model = new ApplicationUser();
                return View(model);
            }

            [HttpPost]
            [ValidateAntiForgeryToken]
            public async Task<IActionResult> Create(ApplicationUser user)
            {
                try
                {
                   
                    if (string.IsNullOrEmpty(user.FirstName))
                        throw new Exception("Please provide the first name!");
                    if (string.IsNullOrEmpty(user.LastName))
                        throw new Exception("Please provide the last name!");
                    

                    _context.Add(user);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index), new { SuccessMessage = "Successfully created a user!" });

                }
                catch (Exception ex)
                {
                 
                    user.ErrorMessage = ex.GetBaseException().Message;
                }
                return View(user);
            }

            public async Task<IActionResult> Details(int id)
            {
                var user = await _context.ApplicationUser.FindAsync(id);
                if (user == null)
                {
                    return NotFound();
                }

               

                return View(user);
            }

            [HttpPost]
            [ValidateAntiForgeryToken]
            public async Task<IActionResult> Details(int id, ApplicationUser user)
            {
                if (id != user.Id)
                {
                    return NotFound();
                }

                // Skip ModelState validation

                _context.Update(user);
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index), new { SuccessMessage = "Successfully updated the user!" });
            }


            public JsonResult _Delete(int Id)
            {
                string errorMessage;
                bool success = false;


                // Retrieve the entity you want to delete
                var courseUnitDb = _context.ApplicationUser.FirstOrDefault(e => e.Id == Id);

                if (courseUnitDb != null)
                {
                    // Remove the entity from the context
                    _context.ApplicationUser.Remove(courseUnitDb);

                    // Save changes to the database
                    _context.SaveChanges();

                    errorMessage = "User deleted successfully.";
                    success = true;
                }
                else
                {
                    errorMessage = "User not found.";
                    success = false;
                }


                return Json(new
                {
                    success,
                    errorMessage
                });
            }
        }
}
