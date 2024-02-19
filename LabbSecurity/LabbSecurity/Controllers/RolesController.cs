using LabbSecurity.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LabbSecurity.Controllers
{
    [Authorize (Roles = "Admin")]
    public class RolesController : Controller
    {
        private readonly RoleManager<IdentityRole> _roleManager;
        public RolesController(RoleManager<IdentityRole> roleManager)
        {
               _roleManager = roleManager;

        }
        public async Task<IActionResult> Index()
        {
            var roles= await _roleManager.Roles.ToListAsync();
            return View(roles);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Index(RoleFormModel newrole)
        {
            if (!ModelState.IsValid)
            {
                // Handle validation errors, e.g., show error messages.
                return View(newrole);
            }

            var roleExists = await _roleManager.RoleExistsAsync(newrole.Name);
            if (roleExists)
            {
                ModelState.AddModelError("Name", "Role already exists");
                return View(newrole);
            }

            // Create the role
            var result = await _roleManager.CreateAsync(new IdentityRole { Name = newrole.Name.Trim() });

            if (result.Succeeded)
            {
                // Role created successfully
                return RedirectToAction("Index");
            }
            else
            {
                // Handle role creation failure, e.g., show error messages.
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
                return View(newrole);
            }
        }
        public async Task<IActionResult> Delete(string id)
        {
            if (string.IsNullOrWhiteSpace(id))
            {
                return NotFound();
            }

            var role = await _roleManager.FindByIdAsync(id);

            if (role == null)
            {
                return NotFound();
            }

            return View(role);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ConfirmDelete(string id)
        {
            var role = await _roleManager.FindByIdAsync(id);

            if (role == null)
            {
                return NotFound();
            }

            var result = await _roleManager.DeleteAsync(role);

            if (result.Succeeded)
            {
                return RedirectToAction("Index");
            }

            // Handle deletion failure, e.g., show error messages.
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(string.Empty, error.Description);
            }

            return View("Delete", role);
        }
    }
}
