using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using SimpleCore.Models;

namespace SimpleCore.Controllers
{
    public class HomeController : Controller
    {
       // private readonly ILogger<HomeController> _logger;

        OfficeContext db;


        //public HomeController(ILogger<HomeController> logger)
        //{
        //    _logger = logger;
        //}

        public HomeController(OfficeContext context)
        {
            db = context;
        }

        public IActionResult Index()
        {
            return View(db.Employees.ToList()); //передаем список сотрудников в представление Index
        }

        #region === Seat Pup Up Modal window ===
        [HttpGet]          
        public ActionResult SeatPupUp()
        {
            return PartialView(); //частичное представление для модального окна
        }

        [HttpPost]
        public ActionResult SeatPupUp(Seat seat)
        {
            db.Seats.Add(seat);// добавляем в бд
            db.SaveChanges(); //сохраняем в бд все изменения
            return RedirectToAction("Index");//возвращаемся на основное окно
        }
        #endregion

        #region === Employee Pup Up modal window ===
        [HttpGet]
        public ActionResult EmployeePupUp()
        {
            List<string> items = db.Seats.Select(x => x.Position).ToList();//список должностей
            ViewBag.Items = items;// передаем в представление
            return PartialView(); //работаем с частичным представлением
        }

        [HttpPost]
        public ActionResult EmployeePupUp(Employee employee)
        {
            db.Employees.Add(employee);// добавляем в бд
            db.SaveChanges(); //сохраняем в бд все изменения
            return RedirectToAction("Index");//возвращаемся на основное окно 
        }
        #endregion

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
