using System;
using System.Collections.Generic;
using library_api.DB;
using library_api.Models;
using library_api.Services;
using Microsoft.AspNetCore.Mvc;

namespace library_api.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class BooksController : ControllerBase
  {
    private readonly BooksService _bs;

    public BooksController(BooksService bs)
    {
      _bs = bs;
    }


    [HttpGet]
    public ActionResult<IEnumerable<Book>> Get()
    {
      try
      {
        return Ok(_bs.Get());
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    [HttpGet("{bookId}")]
    public ActionResult<Book> Get(int bookId)
    {
      try
      {
        return Ok(_bs.Get(bookId));
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
        return Ok(_bs.Create(newBook));
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    [HttpPut("{id}")]
    public ActionResult<Book> Edit(int id, [FromBody] Book editedBook)
    {
      try
      {
        editedBook.Id = id;
        return Ok(_bs.Edit(editedBook));
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    [HttpDelete("{id}")]
    public ActionResult<string> Delete(int id)
    {
      try
      {
        return Ok(_bs.Delete(id));
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }

  }
}
