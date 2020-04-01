using System.Collections.Generic;
using System.Data;
using Dapper;
using library_api.Models;

namespace library_api.Repositories
{
  public class BooksRepository
  {
    private readonly IDbConnection _db;
    public BooksRepository(IDbConnection db)
    {
      _db = db;
    }

    public IEnumerable<Book> Get()
    {
      string sql = "SELECT * FROM books";
      return _db.Query<Book>(sql);
    }

    public Book Get(int id)
    {
      string sql = "SELECT * FROM books WHERE id = @Id";
      return _db.QueryFirstOrDefault<Book>(sql, new { id });
    }

    public Book Create(Book newBook)
    {
      string sql = @"
      INSERT INTO books
      (title, author, pageCount, creatorId)
      VALUES
      (@Title, @Author, @PageCount, @CreatorId);
      SELECT LAST_INSERT_ID();
      ";
      int id = _db.ExecuteScalar<int>(sql, newBook);
      newBook.Id = id;
      return newBook;
    }

    public Book Edit(Book updatedBook)
    {
      string sql = @"
      UPDATE books
      SET
          title = @Title,
          author = @Author,
          pageCount = @PageCount
      WHERE id = @Id
      ";
      _db.Execute(sql, updatedBook);
      return updatedBook;
    }

    public bool Delete(int Id)
    {
      string sql = "DELETE FROM books WHERE id = @Id";
      int changed = _db.Execute(sql, new { Id });
      return changed == 1;
    }
  }
}