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
        public DbSet<Category> Categories { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder); // השאירי את הקריאה ל-base

            // הוספת נתוני בסיס (Seed Data) לטבלת Categories
            modelBuilder.Entity<Category>().HasData(
                // הוצאות (IsIncome = false)
                new Category { Id = 1, Name = "אוכל ושתייה", Icon = "restaurant", Color = "#FF6347", IsIncome = false },
                new Category { Id = 2, Name = "תחבורה", Icon = "directions_car", Color = "#1E90FF", IsIncome = false },
                new Category { Id = 3, Name = "דיור ושכירות", Icon = "home", Color = "#3CB371", IsIncome = false },

                // הכנסות (IsIncome = true)
                new Category { Id = 4, Name = "משכורת", Icon = "account_balance_wallet", Color = "#FFA500", IsIncome = true },
                new Category { Id = 5, Name = "מתנות", Icon = "card_giftcard", Color = "#8A2BE2", IsIncome = true }
            );
        }
        // DbSet מייצג את טבלת ה-Transactions במסד הנתונים.
        public DbSet<Transaction> Transactions { get; set; }
    }
}