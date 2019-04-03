using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using cethw1.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Hosting;

using Microsoft.AspNetCore.Http;
using System.IO;


namespace cethw1.Controllers
{
    public class studentsController : Controller
    {
        stcontext Stcontext;
    
        private readonly IHostingEnvironment _hostingEnvironment;

      
        public studentsController(stcontext context, IHostingEnvironment hostingEnvironment)
        {
            Stcontext = context;
            _hostingEnvironment = hostingEnvironment;

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
        public IActionResult Create(student book, IFormFile FileUrl)
        {
            if (ModelState.IsValid)
            {
                string dirPath = Path.Combine(_hostingEnvironment.WebRootPath, @"uploads\");
                var fileName = Guid.NewGuid().ToString().Replace("-", "") + "_" + FileUrl.FileName;
                using (var fileStream = new FileStream(dirPath + fileName, FileMode.Create))
                {
                     FileUrl.CopyTo(fileStream);
                }

               book.ImageUrl = fileName;
               Stcontext.Add(book);
                Stcontext.SaveChanges();
                return RedirectToAction(nameof(Index));

                //Stcontext.Books.Add(book);
                //Stcontext.SaveChanges();
                //return RedirectToAction("Index");
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