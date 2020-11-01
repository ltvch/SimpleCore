using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleCore.Models
{
    /// <summary>
    /// Класс который заполнит первичными(тестовыми) значениями таблицы в СУБД
    /// </summary>
    public class SampleEmployee
    {
        //добавим даные через инициализацию с применением контекста
        public static void Initialize(OfficeContext context)
        {
            //если таблица пустая
            if (!context.Employees.Any())
            {
              //добавим данные по сотрудникам
                context.Employees.AddRange(
                    new Employee
                    {
                        LastName = "Маслов",
                        Name = "Иван",
                        Position = "Middle Dev",
                        Salary = 1500,
                        Hired = new DateTime(2018, 12, 15)
                    },
                    new Employee
                    {
                        LastName = "Прыгунок",
                        Name = "Александр",
                        Position = "Junior QA",
                        Salary = 600,
                        Hired = new DateTime(2016, 5, 1),
                        Fired = new DateTime(2019, 10, 22)
                    },
                    new Employee
                    {
                        LastName = "Капустина",
                        Name = "Анастасия",
                        Position = "Senior BA",
                        Salary = 1800,
                        Hired = new DateTime(2015, 11, 11)
                    }
                );

                if (!context.Seats.Any())// если в СУБД нет данных по должностям
                {
                    context.Seats.AddRange(
                        new Seat { Position = "Middle Dev" }
                        , new Seat { Position = "Junior QA" }
                        , new Seat { Position = "Senior BA" }
                        ); //создаем диапазон данных для контекста
                }

                context.SaveChanges();// сохраняем изменения
            }
        }
    }
}
