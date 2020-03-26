using System;
using System.ComponentModel.DataAnnotations;

namespace library_api.Models
{
  public class Book
  {

    [Required]
    public string Title { get; set; }

    [MinLength(3)]
    public string Author { get; set; }

    public int PageCount { get; set; }
    public string Id { get; set; }


    public Book()
    {
      Id = Guid.NewGuid().ToString();
    }

    public Book(string title, string author, int pageCount)
    {
      Title = title;
      Author = author;
      PageCount = pageCount;
      Id = Guid.NewGuid().ToString();


    }
  }
}