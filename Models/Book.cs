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
    public int Id { get; set; }


    public Book()
    {
    }

    public Book(string title, string author, int pageCount)
    {
      Title = title;
      Author = author;
      PageCount = pageCount;


    }
  }
}