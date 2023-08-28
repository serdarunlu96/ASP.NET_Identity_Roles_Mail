using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ANK13Identity.Areas.Identity.Data;
using ANK13Identity.Models;
using Microsoft.AspNetCore.Identity;

namespace ANK13Identity.Controllers
{
    public class RoleController : Controller
    {

        private readonly RoleManager<IdentityRole> _roleManager;

        public RoleController(RoleManager<IdentityRole> roleManager)
        {
            _roleManager = roleManager;
        }

        // GET: Role
        public async Task<IActionResult> Index()
        {
            //Bütün rolleri getirecek
            return View(_roleManager.Roles.ToList());
        }

        // GET: Role/Details/5
        public async Task<IActionResult> Details(string id)
        {

            //Id'ye ait olan rolü getir ve post edilmek üzere modele gönder 
            var selectedRole = _roleManager.Roles.FirstOrDefault(r => r.Id == id);

            return View(selectedRole);
        }

        // GET: Role/Create
        public IActionResult Create()
        {
            //Create'in get'i
            return View();
        }

        // POST: Role/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(RoleViewModel roleViewModel)
        {
            if (ModelState.IsValid)
            {
                //Formdan gelen viewmodel'in name prop.unu hakiki rolünkine atayıp rolü ekliyoruz.
                await _roleManager.CreateAsync(new IdentityRole { Name = roleViewModel.Name });

                return RedirectToAction(nameof(Index));
            }
            return View(roleViewModel);
        }

        // GET: Role/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            var selectedRole = _roleManager.Roles.FirstOrDefault(r => r.Id == id);
            //if (selectedRole == null)
            //{
            //    return NotFound();
            //}
            return View(selectedRole);
        }

        // POST: Role/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, IdentityRole role)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var selectedRow = await _roleManager.Roles.FirstOrDefaultAsync(r => r.Id == role.Id);

                    selectedRow.Name = role.Name;

                    var sonuc = await _roleManager.UpdateAsync(selectedRow);

                }
                catch (Exception ex)
                {
                    // Hata durumunu ele al
                    ModelState.AddModelError(string.Empty, "Bir hata oluştu. Lütfen tekrar deneyin.");
                    return View(role);
                }
            }
            return RedirectToAction(nameof(Index));
        }



        // GET: Role/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            //if (id == null || _context.RoleViewModel == null)
            //{
            //    return NotFound();
            //}

            var selectedRole = _roleManager.Roles.FirstOrDefault(r => r.Id == id);
            //if (roleViewModel == null)
            //{
            //    return NotFound();
            //}

            return View(selectedRole);
        }

        // POST: Role/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            //if (_context.RoleViewModel == null)
            //{
            //    return Problem("Entity set 'ANK13IdentityContext.RoleViewModel'  is null.");
            //}
            var selectedRole = _roleManager.Roles.FirstOrDefault(r => r.Id == id);
            //if (roleViewModel != null)
            //{
            //    _context.RoleViewModel.Remove(roleViewModel);
            //}

            await _roleManager.DeleteAsync(selectedRole);
            return RedirectToAction(nameof(Index));
        }

        //private bool RoleViewModelExists(string id)
        //{
        //  return (_context.RoleViewModel?.Any(e => e.Name == id)).GetValueOrDefault();
        //}
    }
}
