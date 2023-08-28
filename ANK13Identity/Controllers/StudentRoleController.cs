using ANK13Identity.Areas.Identity.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ANK13Identity.Controllers
{
    //[Authorize(Roles = "Admin")]
    public class StudentRoleController : Controller
    {
        private readonly UserManager<ANK13IdentityUser> _userManager;
     

        public StudentRoleController(UserManager<ANK13IdentityUser> userManager)
        {
            _userManager = userManager;
           
        }

        //Yetki verme bölümü
        public IActionResult Index()
        {
            //Bütün kullanıcıları getirip view'ımıza aktaralım
            //Aktarabilmek için usermanager'ına ihtiyacımız vardır.
            //Onu da enjekte edelim.

            //Bu usermanager bize hem kullanıcıları getirmeyi hem de rol atama ve silmeyi
            //sağlayacak

            return View(_userManager.Users.ToList());
        }

        public async Task<IActionResult> AddStudentRole(string id)
        {
            //Gelen id'ye ait olan kullanıya bul.
            var selectedUser = await _userManager.FindByIdAsync(id);

            //Tekrar index'e git
            return View(selectedUser);

          

        }

        [HttpPost]
        public async Task<IActionResult> AddStudentRole(ANK13IdentityUser user)  //?
        {


            var user2 = await _userManager.FindByIdAsync(user.Id);

            var userRoles = await _userManager.GetRolesAsync(user2);

            if (userRoles.Contains("Student"))
                TempData["Hata"] = "Öğrenci Rolü Zaten Vardır!";
            else
                await _userManager.AddToRoleAsync(user2, "Student");


            //Tekrar index'e git
            return RedirectToAction("Index");



        }
        public async Task<IActionResult> RemoveStudentRole(string id)
        {
            //Gelen id'ye ait olan kullanıya bul.
            var selectedUser = await _userManager.FindByIdAsync(id);


            return View(selectedUser);
        }

        [HttpPost]
        public async Task<IActionResult> RemoveStudentRole(ANK13IdentityUser user)
        {
            var user2 = await _userManager.FindByIdAsync(user.Id);

            var userRoles = await _userManager.GetRolesAsync(user2);

            if (!userRoles.Contains("Student"))
                TempData["Hata"] = "Öğrenci Rolü Yoktur!";
            else

                await _userManager.RemoveFromRoleAsync(user2, "Student");


            //Tekrar index'e git
            return RedirectToAction("Index");
        }
    }
}
