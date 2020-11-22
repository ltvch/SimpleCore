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

        readonly OfficeContext db;


        //public HomeController(ILogger<HomeController> logger)
        //{
        //    _logger = logger;
        //}
        /// <summary>
        ///  Организоваваем первоначальные данные для всех моделей
        /// </summary>
        /// <param name="context">Контекст работы с БД</param>
        public HomeController(OfficeContext context)
        {
            db = context;
        }
        /// <summary>
        ///  Основная форма с данными
        /// </summary>
        /// <returns>Возвращаем представление основного окна</returns>
        public IActionResult Index()
        {
            // return View(db.Employees.ToList()); //передаем список сотрудников в представление Index

            var items = db.Employees.ToList(); // список должностей
            ViewBag.Items = items;// передаем в представление
            return View(); //работаем с представлением
        }

        #region === Seat Pup Up Modal window ===

        /// <summary>
        /// Модальное окно для ввода должности
        /// </summary>
        /// <returns>Возвращаем частичное представление для модального окна</returns>
        [HttpGet]
        public ActionResult SeatPupUp()
        {
            return PartialView(); //частичное представление для модального окна
        }

        /// <summary>
        /// Сохраняем должности в БД
        /// </summary>
        /// <param name="seat">Модель должности</param>
        /// <returns>Возвращаемся на основное окно после заполнения</returns>
        [HttpPost]
        public ActionResult SeatPupUp(Seat seat)
        {
            db.Seats.Add(seat);// добавляем в бд
            db.SaveChanges(); //сохраняем в бд все изменения
            return RedirectToAction("Index");//возвращаемся на основное окно
        }
        #endregion

        #region === Employee Pup Up modal window ===

        /// <summary>
        /// Получаем список должностей в частичное представление модального окна
        /// </summary>
        /// <returns>Возвращаем заполненный списком компонент</returns>
        /// <remarks>Работаем с частичным представлением(компонентом) для списка должностей</remarks>
        [HttpGet]
        public ActionResult EmployeePupUp()
        {
            var items = db.Seats.ToList(); // список должностей
            ViewBag.Items = items;// передаем в представление
            return PartialView(); //работаем с частичным представлением
        }

        /// <summary>
        /// Обрабатываем данные модели с формы ввода сотрудника
        /// </summary>
        /// <param name="employee">Модель сотрудника</param>
        /// <returns>Вернуть результат обработки данных модели</returns>
        [HttpPost]
        public ActionResult EmployeePupUp(Employee employee)
        {
            ///если модель валидна сохраняем иначе повторный ввод
            if (ModelState.IsValid)//валидация на стороне сервера
            {
                db.Employees.Add(employee);// добавляем в бд
                db.SaveChanges(); //сохраняем в бд все изменения
                return RedirectToAction("Index");//возвращаемся на основное окно
            }
            else return PartialView(employee);//остаемся в том же модальном окне 
        }
        #endregion

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
