using Microsoft.EntityFrameworkCore;

namespace RestWithASP_NET5.Models.Context
{
    public class MySQLContext: DbContext
    {
        public MySQLContext()
        {
            //
        }
        public MySQLContext(DbContextOptions<MySQLContext> options) : base(options) { }

        DbSet<Person> People { get; set; }
    }
}
