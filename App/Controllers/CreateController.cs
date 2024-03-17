using App.Data;
using App.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Storage;
using System.Security.Cryptography.Xml;

namespace App.Controllers
{
    public class CreateController : Controller

    {
        private readonly DB _context;
        public CreateController(DB DataBase)
        {
            _context = DataBase;

        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(int Id, string Name, int Year, int HorsePower)
        {
            CarClass CarClass = new CarClass();
            CarClass.Id = Id;
            CarClass.Name = Name;
            CarClass.Year = Year;
            CarClass.HorsePower = HorsePower;
            if (CarClass != null)
            {
                _context.CarTable.Add(CarClass);
                _context.SaveChanges();
            }           
            return RedirectToAction("Create");
        }
    }
}
