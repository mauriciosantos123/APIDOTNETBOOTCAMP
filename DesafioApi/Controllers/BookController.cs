using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using DesafioApi.Models;
using DesafioApi.Data;


namespace DesafioApi.Controllers
{
    // POST: api/BooksController
    [ApiController]
    [Route("v1/books")]
    public class BooksController : ControllerBase
    {
        [HttpGet]
        [Route("")]
        public async Task<ActionResult<List<BookItem>>> Get([FromServices] DataContext context)
        {
            var books = await context.BookItems.ToListAsync();
            return books;
        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<ActionResult<BookItem>> GetById([FromServices] DataContext context, int id)
        {
            var books = await context.BookItems.Include(x => x.Category)
            .FirstOrDefaultAsync(x => x.Id == id);
            return books;
        }
        [HttpPost]
        [Route("")]
        public async Task<ActionResult<BookItem>> Post(
            [FromServices] DataContext context,
            [FromBody] BookItem model)
        {
            if (ModelState.IsValid)
            {
                context.BookItems.Add(model);
                await context.SaveChangesAsync();
                return model;
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        //PUT
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] BookItem model,[FromServices] DataContext context)
        {
            if (model.Id != id)
            {
                return BadRequest();
            }
            context.Entry(model).State = EntityState.Modified;
            await context.SaveChangesAsync();
            return NoContent();
        }
        //DELETE

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id, [FromServices] DataContext context)
        {
            var books = await context.BookItems.FindAsync(id);
            if (books == null)
            {
                return NotFound();
            }

            context.BookItems.Remove(books);
            await context.SaveChangesAsync();

            return NoContent();
        }
    }


}
