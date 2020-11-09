using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SimpleCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleCore.ViewComponents
{
    public class AddSeats : ViewComponent
    {
        #region --- Fields ---
        private readonly OfficeContext _context;
        #endregion

        #region --- CTOR ---
        public AddSeats(OfficeContext context)
        {
            _context = context;
        }
        #endregion

        #region --- Methods ---
        public IViewComponentResult Invoke()
        {
            ViewData["Items"] = new SelectList(_context.Seats, "Position", "Position");
            return View();
        }
        #endregion
    }
}
