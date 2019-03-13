using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using cethw1.Models;
using Microsoft.AspNetCore.Mvc;

namespace cethw1.Controllers
{
    public class studentsController : Controller
    {
        stcontext Stcontext;
        public studentsController(stcontext context)
        {
            Stcontext = context;

        }
        public IActionResult Index()
        {
            var books = Stcontext.Books.ToList();
            return View(books);
           
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(student book)
        {
            if (ModelState.IsValid)
            {
                Stcontext.Books.Add(book);
                Stcontext.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                return View(book);
            }
        }
        public IActionResult Edit(int? id)
        {
            if (!id.HasValue)
            {
                return BadRequest();
            }
            var book = Stcontext.Books.Find(id);
            if (book == null)
            {
                return NotFound();
            }

            return View(book);


        }
        [HttpPost]
        public IActionResult Edit(int? id, student book)
        {

            if (!id.HasValue)
            {
                return BadRequest();
            }

            if (book == null)
            {
                return NotFound();
            }

            if (id != book.Id)
            {
                return BadRequest();
            }
            if (ModelState.IsValid)
            {
                Stcontext.Books.Update(book);
                Stcontext.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                return View(book);
            }
        }
        public IActionResult Detay(int id)
        {

            student st = Stcontext.Books.Where(b => b.Id == id).FirstOrDefault();
            if (st != null)
            {
                return View(st);
            }
            else
            {
                return NotFound();
            }
        }
    }
}