using System.Collections.Generic;
using library_api.Models;

namespace library_api.DB
{
  static class FakeDB
  {
    public static List<Book> books = new List<Book>()
    {
      new Book("The Fellowship of the Ring", "Tolkien", 423),
      new Book("The 2nd Book", "Riley", 1),
      new Book("The Cat in the Hat", "Dr.Seuss", 61)
    };
  }
}