using Microsoft.EntityFrameworkCore;
using todo_list.Models;

namespace todo_list.Data
{
    public class AppDBContext : DbContext
    {
        public AppDBContext(DbContextOptions<AppDBContext> options) :base(options)
        {}
        public DbSet<ToDoItem> ToDoItems { get; set; }
    }
}
