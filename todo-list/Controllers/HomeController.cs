using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using todo_list.Data;
using todo_list.Models;

namespace todo_list.Controllers
{
    public class HomeController : Controller
    {
        private readonly AppDBContext _appDBContext;

        public HomeController(AppDBContext appDBContext)
        {
            _appDBContext = appDBContext;
        }

        public IActionResult Index()
        {
            IEnumerable<ToDoItem> obj = _appDBContext.ToDoItems;
            return View(obj);
        }

        //Get
        public IActionResult Add()
        {
            return View();
        }
        //Post
        [HttpPost]
        [ValidateAntiForgeryToken] //For cross-site entry
        public IActionResult Add(ToDoItem obj)
        {
            /*if(obj.Name == _db.ToDoItems.Name.Single())
            {
                ModelState.AddModelError("name", "New item cannot match existing items");
            }*/
            if (ModelState.IsValid)
            {
                _appDBContext.ToDoItems.Add(obj);
                _appDBContext.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(obj);
        }

        //Get
        public IActionResult Edit(int? id)
        {
            if(id == null || id == 0)
            {
                return NotFound();
            }
            var Dbitem = _appDBContext.ToDoItems.Find(id);
            if (Dbitem == null) { return NotFound(); }
            return View(Dbitem);
        }
        //Post
        [HttpPost]
        [ValidateAntiForgeryToken] //For cross-site entry
        public IActionResult Edit(ToDoItem obj)
        {
            if (ModelState.IsValid)
            {
                _appDBContext.ToDoItems.Update(obj);
                _appDBContext.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(obj);
        }

        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var Dbitem = _appDBContext.ToDoItems.Find(id);
            if (Dbitem == null) { return NotFound(); }
            _appDBContext.ToDoItems.Remove(Dbitem);
            _appDBContext.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}