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
    public string CreatorId { get; set; }
    public int Id { get; set; }


  }
}