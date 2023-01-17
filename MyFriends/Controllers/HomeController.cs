using Microsoft.AspNetCore.Mvc;
using MyFriends.Models;
using MyFriends.ViewsModels;
using System.Diagnostics;
using System.Data.Entity;
namespace MyFriends.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        // הפונקציה שעולה ראשונה
        public IActionResult Index()
        {
            // טעינת רשימת החברים ממסד הנתונים כולל התמונות שלהם
            List<Friend> friends = DataLayer.Data.Friends.Include(f=>f.Images).ToList();
            return View(friends);
        }

        //  פונקציה ליצירת חבר חדש
        public IActionResult Create()
        {
            // שליחה לדף תצוגה של מודל מוכן המכיל גם חבר חדש וגם מקום לתמונה
            return View(new VMFriendWithImage());
        }

        // פונקציה המקבלת טופס מלא מהתצוגה / משתמש
        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult Create(VMFriendWithImage VM)
        {
            //1. הוספת החבר החדש לטבלה של החברים
            DataLayer.Data.Friends.Add(VM.Friend);
            //2. הוספת התמונה לחבר
            VM.Friend.AddImage(VM.File);
            //3. שמירת הנתונים במסד נתונים
            DataLayer.Data.SaveChanges();
            //4. צריך להחליט האם עוברים מכאן לרשימה הכללית או לפרטי החבר הנוכחי

           return RedirectToAction("Index");
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
}