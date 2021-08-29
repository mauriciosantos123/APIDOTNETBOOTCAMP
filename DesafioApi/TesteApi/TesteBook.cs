using DesafioApi.Data;
using DesafioApi.Models;
using DesafioApi.Controllers;

using System;
using System.Collections.Generic;


namespace DesafioApi.Test
{
    public class BookTest
    {
        [Fact]
        public void GetBookwhenExists()
        {
            
            BookItem bookRequest = new BookItem()
            {
                Id = 1
            };

            IList<BookItem> books = new List<BookItem>();
            books.Add(new BookItem { Title = "casco", Id = 1, Category = "romance", Name = "teste1" });
            books.Add(new BookItem { Title = "fei", Id = 2, Category = "romance", Name = "teste2" });
            books.Add(new BookItem { Title = "tato", Id = 3, Category = "romance", Name = "teste3" });
            books.Add(new BookItem { Title = "varios", Id = 4, Category = "romance", Name = "Frederico" });
            books.Add(new BookItem { Title = "viu", Id = 5, Category = "romance", Name = "Diogo" });


        }

    }
}