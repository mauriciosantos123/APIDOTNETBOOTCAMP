using Microsoft.EntityFrameworkCore;
using DesafioApi.Models;

namespace DesafioApi.Data
{

    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }
        public DbSet<BookItem> BookItems {get; set;}
    }


}