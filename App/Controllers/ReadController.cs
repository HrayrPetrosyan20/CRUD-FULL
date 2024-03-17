using App.Data;
using App.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using Microsoft.IdentityModel.Tokens;

namespace App.Controllers
{
    public class ReadController : Controller
    {
        private readonly DB _context;
        public ReadController(DB DataBase)
        {
            _context = DataBase;

        }

        public IActionResult Read()
        {

            return View(_context.CarTable.ToList());

        }
        public IActionResult Delete(int Id)
        {
            var del = _context.CarTable.Find(Id);
            _context.CarTable.Remove(del);
            _context.SaveChanges();
            return RedirectToAction("Read");
        }
        public IActionResult Update(int Id, string Name, int Year, int HorsePower)
        {
            var edit = _context.CarTable.Find(Id);
            edit.Name = Name;
            edit.Year = Year;
            edit.HorsePower = HorsePower;
            _context.CarTable.Update(edit);           
            _context.SaveChanges();
            return RedirectToAction("Read");
        }
    }
}
