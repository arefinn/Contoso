using System.Linq;
using System.Web.Mvc;
using ContosoUniversity.DAL;
using ContosoUniversity.Models;

namespace ContosoUniversity.Controllers
{
    public class StudentController : Controller
    {
        private StudentRepository _repository = new StudentRepository();

        public ActionResult Index()
        {
            return View(_repository.GetAll().ToList());
        }

        public ActionResult Details(int id)
        {
            var student = _repository.Get(id);
            if (student == null)
            {
                return HttpNotFound();
            }
            return View(student);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,LastName,FirstMidName,EnrollmentDate")] Student student)
        {
            if (ModelState.IsValid)
            {
                _repository.Add(student);
                _repository.SaveChanges();
                return RedirectToAction("Index");

            }
            return View(student);
        }

        public ActionResult Edit(int id)
        {
            var student = _repository.Get(id);
            if (student == null)
            {
                return HttpNotFound();
            }
            return View(student);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,LastName,FirstMidName,EnrollmentDate")] Student student)
        {
            if (ModelState.IsValid)
            {
                _repository.SetModifiedState(student);
                _repository.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(student);
        }

        public ActionResult Delete(int id)
        {
            var student = _repository.Get(id);
            if (student == null)
            {
                return HttpNotFound();
            }
            return View(student);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var student = _repository.Get(id);
            _repository.Remove(student);
            _repository.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
