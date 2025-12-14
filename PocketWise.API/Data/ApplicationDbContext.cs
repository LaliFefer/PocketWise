using Microsoft.EntityFrameworkCore;
using PocketWise.API.Models; // ייבוא המחלקה Transaction

namespace PocketWise.API.Data
{
    // המחלקה יורשת מ-DbContext כדי שתהיה מנוע Entity Framework
    public class ApplicationDbContext : DbContext
    {
        // הקונסטרקטור – נדרש על ידי EF Core 
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        // DbSet מייצג את טבלת ה-Transactions במסד הנתונים.
        public DbSet<Transaction> Transactions { get; set; }
    }
}