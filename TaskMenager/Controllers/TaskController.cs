using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TaskMenager.Models;

namespace TaskMenager.Controllers
{
    public class TaskController : Controller
    {
        private static IList<TaskModel> tasks = new List<TaskModel>()
        {
            new TaskModel()
            {
                TaskId = 1,
                Name = "Wizyta u mechanika",
                Description = "Jesteśmy umówieni na godzinę 16:30. Wymiana sprzęgła.",
                Done = false
            },
            new TaskModel()
            {
                TaskId = 2,
                Name = "Zakupy w castoramie",
                Description = "Zakup mebli ogrodowych. Spotkanie o 12:30 w niedziele",
                Done = false
            },
            new TaskModel()
            {
                TaskId = 3,
                Name = "Odwiedzić dziadków",
                Description = "Obiad o godzinie 12 w poniedziałek",
                Done = false
            }
        };

        // GET: TaskController
        public ActionResult Index()
        {
            return View(tasks);
        }

        // GET: TaskController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: TaskController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TaskController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: TaskController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: TaskController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: TaskController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: TaskController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
