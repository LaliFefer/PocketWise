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
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // הגדרת הדיוק (Precision) של השדה Amount ל-Decimal(18, 2)
            modelBuilder.Entity<Transaction>()
                .Property(t => t.Amount)
                .HasPrecision(18, 2);

            base.OnModelCreating(modelBuilder);
        }
        // DbSet מייצג את טבלת ה-Transactions במסד הנתונים.
        public DbSet<Transaction> Transactions { get; set; }
    }
}