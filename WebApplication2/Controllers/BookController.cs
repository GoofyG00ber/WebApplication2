﻿using Microsoft.AspNetCore.Mvc;
using WebApplication2.BookModels;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApplication2.Controllers
{
    [Route("api/book")]
    [ApiController]
    public class BookController : ControllerBase
    {
        // GET: api/<BookController>
        [HttpGet]
        public IActionResult GetMind()
        {
            FunnyDatabaseContext context = new FunnyDatabaseContext();
            return Ok(context.Books.ToList());
        }

        // GET api/<BookController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            FunnyDatabaseContext context = new FunnyDatabaseContext();

            var book = (from x in context.Books
                        where x.Id == id
                        select x).FirstOrDefault();

            if (book == null)
            {
                return NotFound("nincs ilyen könyv ezzel az azonositoval");
            }

            return Ok(book);
        }

        // POST api/<BookController>
        [HttpPost]
        public void Post([FromBody] Book book)
        {
            FunnyDatabaseContext context = new FunnyDatabaseContext();
            context.Books.Add(book);
            context.SaveChanges();
        }

        // PUT api/<BookController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Book value)
        {
            FunnyDatabaseContext context = new FunnyDatabaseContext();
            var booktomodify = (from x in context.Books
                                where x.Id == id
                                select x).FirstOrDefault();

            if (booktomodify == null)
            {
                return NotFound("");
            }

            booktomodify.Title = value.Title;
            booktomodify.Author= value.Author;
            booktomodify.Year = value.Year;
            booktomodify.Genre = value.Genre;
            booktomodify.IsAvailable = value.IsAvailable;

            context.SaveChanges();

            return Ok("Sikeres módosítás");
        }

        // DELETE api/<BookController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            FunnyDatabaseContext context = new FunnyDatabaseContext();

            var booktodelete = (from x in context.Books
                        where x.Id == id
                        select x).FirstOrDefault();

            if (booktodelete == null)
            {
                return NotFound("Nincs ilyen");
            }

            context.Books.Remove(booktodelete);
            context.SaveChanges();

            return Ok("Sikeres törlés");
        }
    }
}
