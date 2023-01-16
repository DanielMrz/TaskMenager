using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TaskMenager.Models;
using TaskMenager.Repositories;

namespace TaskMenager.Controllers
{
    public class TaskController : Controller
    {
        private readonly ITaskRepository _taskRepository;
        public TaskController(ITaskRepository taskRepository)
        {
            this._taskRepository = taskRepository;
        }

        //private static IList<TaskModel> tasks = new List<TaskModel>()
        //{
        //    new TaskModel()
        //    {
        //        TaskId = 1,
        //        Name = "Wizyta u mechanika",
        //        Description = "Jesteśmy umówieni na godzinę 16:30. Wymiana sprzęgła.",
        //        Done = false
        //    },
        //    new TaskModel()
        //    {
        //        TaskId = 2,
        //        Name = "Zakupy w castoramie",
        //        Description = "Zakup mebli ogrodowych. Spotkanie o 12:30 w niedziele",
        //        Done = false
        //    },
        //    new TaskModel()
        //    {
        //        TaskId = 3,
        //        Name = "Odwiedzić dziadków",
        //        Description = "Obiad o godzinie 12 w poniedziałek",
        //        Done = false
        //    }
        //};

        // GET: Task
        public ActionResult Index()
        {
            return View(_taskRepository.GetAllActive());
        }

        // GET: Task/Details/5
        public ActionResult Details(int id)
        {
            return View(_taskRepository.Get(id));
        }

        // GET: Task/Create
        public ActionResult Create()
        {
            return View(new TaskModel());
        }

        // POST: Task/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(TaskModel taskModel)
        {
            _taskRepository.Add(taskModel);
            return RedirectToAction(nameof(Index));
        }

        // GET: Task/Edit/5
        public ActionResult Edit(int id)
        {
            return View(_taskRepository.Get(id));
        }

        // POST: Task/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, TaskModel taskModel)
        {
            _taskRepository.Update(id, taskModel);
                return RedirectToAction(nameof(Index));
        }

        // GET: Task/Delete/5
        public ActionResult Delete(int id)
        {
            return View(_taskRepository.Get(id));
        }

        // POST: Task/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, TaskModel taskModel)
        {
            _taskRepository.Delete(id);
            return RedirectToAction(nameof(Index));
        }

        // GET: Task/Done/5
        public ActionResult Done(int id)
        {
            TaskModel task = _taskRepository.Get(id);
            task.Done = true;
            _taskRepository.Update(id, task);

            return RedirectToAction(nameof(Index));
        }
    }
}
