using ANK13Identity.Areas.Identity.Data;
using ANK13Identity.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ANK13Identity.Controllers
{
    [Authorize(Roles = "Student")]
    public class StudentLessonController : Controller
    {
        private readonly ANK13IdentityContext _db;
        private readonly UserManager<ANK13IdentityUser> _userManager;

        public StudentLessonController(ANK13IdentityContext db,UserManager<ANK13IdentityUser> userManager) 
        {
            _db = db;
            _userManager = userManager;
        }
        // Her ogrenci kendisine ders sececek.
        public IActionResult Index()
        {
            ViewBag.StudentLessons = _db.StudentLessons.Where(s => s.ANK13IdentityUserId == _userManager.GetUserId(HttpContext.User)).ToList();

            ViewBag.Lessons = _db.Lesson.ToList();
            return View();
        }

        [HttpPost]
        public async Task <IActionResult> Index(StudentLesson studentLesson)
        {
            studentLesson.ANK13IdentityUserId = _userManager.GetUserId(HttpContext.User);
            _db.StudentLessons.Add(studentLesson);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
