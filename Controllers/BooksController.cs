using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using library_api.DB;
using library_api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace library_api.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class BooksController : ControllerBase
  {
    [HttpGet]
    public ActionResult<IEnumerable<Book>> Get()
    {
      try
      {
        return Ok(FakeDB.books);
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    [HttpGet("{bookId}")]
    public ActionResult<Book> Get(string bookId)
    {
      try
      {
        Book foundBook = FakeDB.books.Find(b => b.Id == bookId);
        if (foundBook == null)
        {
          throw new Exception("Invalid ID");
        }
        return Ok(foundBook);
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    [HttpPost]
    public ActionResult<Book> Create([FromBody] Book newBook)
    {
      try
      {
        FakeDB.books.Add(newBook);
        return Created($"api/book/{newBook.Id}", newBook);
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    [HttpPut]
    public ActionResult<Book> Edit(string id, [FromBody] Book editedBook)
    {
      try
      {
        Book bookToEdit = FakeDB.books.Find(b => b.Id == id);
        if (bookToEdit == null)
        {
          throw new Exception();
        }
        bookToEdit.Title = editedBook.Title;
        bookToEdit.Author = editedBook.Author;
        bookToEdit.PageCount = editedBook.PageCount;
        return Ok(bookToEdit);
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    [HttpDelete("{id}")]
    public ActionResult<string> Delete(string id)
    {
      try
      {
        Book bookToDelete = FakeDB.books.Find(b => b.Id == id);
        if (bookToDelete == null)
        {
          throw new Exception("Invalid Id");
        }
        FakeDB.books.Remove(bookToDelete);
        return Ok("Successfully Removed");
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }

  }
}
