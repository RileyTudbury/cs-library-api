using System;
using System.Collections.Generic;
using library_api.Models;
using library_api.Repositories;

namespace library_api.Services
{
  public class BooksService
  {
    private readonly BooksRepository _repo;
    public BooksService(BooksRepository repo)
    {
      _repo = repo;
    }
    public IEnumerable<Book> Get()
    {
      return _repo.Get();
    }

    public Book Get(int id)
    {
      Book found = _repo.Get(id);
      if (found == null)
      {
        throw new Exception("Invalid Id");
      }
      return found;
    }

    public Book Create(Book newBook)
    {
      return _repo.Create(newBook);
    }

    public Book Edit(Book editedBook)
    {
      Book exists = _repo.Get(editedBook.Id);
      if (exists == null)
      {
        throw new Exception("Invalid Id");
      }
      return _repo.Edit(editedBook);
    }

    public string Delete(int id)
    {
      Book exists = _repo.Get(id);
      if (exists == null)
      {
        throw new Exception("Invalid Id");
      }
      if (_repo.Delete(id))
      {
        return "Success";
      }
      throw new Exception("Something went wrong with deleting that item.");
    }
  }
}