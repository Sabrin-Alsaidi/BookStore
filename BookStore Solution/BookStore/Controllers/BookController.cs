using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookStore.Interface;
using BookStore.Model;
using BookStore.Repository;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BookStore.Controllers
{
    [EnableCors("AllowSabrin")]
    [Route("api/[controller]")]
    [ApiController]
    
    public class BookController: ControllerBase
    {
        private readonly IBookRepository _bookRepository;

        public BookController(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        //Get All the data from the database 
        [HttpGet]
        [ProducesResponseType(statusCode: 200)]
        [ProducesResponseType(statusCode: 400)]
        public IActionResult ViewAll()
        {
            var books =  _bookRepository.GetAll();
            return Ok(books);
        }

        //Get data By Id
        [HttpGet("int:id")]
        [ProducesResponseType(statusCode: 200)]
        [ProducesResponseType(statusCode: 400)]
        public ActionResult Get(int id)
        {
            var book = _bookRepository.Get(id);
            if (book is null)
            {
                return NotFound();
            }
            return Ok(book);

        }

        //Add new Record 
        [HttpPost]
        public ActionResult Create([FromBody] Book book)
        {
            if (ModelState.IsValid)
            {
                _bookRepository.Create(book);
                return CreatedAtAction(nameof(Get), new { id = book.Id }, book);
                //return Ok("Recorde is add!!");

            }
            return BadRequest();
        }

        //Update a record 
        [HttpPut("int:id")]
        //[HttpPut("{id}")]
        //[HttpPut("api/[action]/{id}")]
        public ActionResult Update( int id , [FromBody] Book book)
        {
            if (id != book.Id )
            {
                return NotFound();

            }
            else
            {

                if (ModelState.IsValid)
                {
                     _bookRepository.Update(book);
                    return Ok(book);

                } 
                return BadRequest();
            }
        }

        //Delete a record
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var book = _bookRepository.Get(id);

            if (book == null)
            {
                return NotFound();
            }

            _bookRepository.Delete(book);
            return Ok("Record is deleted!");
        }
        //[HttpDelete("int:id")]
        //public ActionResult Delete(int id, Book book)
        //{
        //    if (id != book.Id)
        //    {
        //        return NotFound();

        //    }
        //    else
        //    {
        //        _bookRepository.Delete(book);
        //        return Ok("Record is deleted!");
        //    }
        //}



    }
}

