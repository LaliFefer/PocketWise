using Microsoft.EntityFrameworkCore;
using PocketWise.API.Models; // ייבוא המחלקות Category ו-Transaction

namespace PocketWise.API.Data
{
    // המחלקה יורשת מ-DbContext כדי שתהיה מנוע Entity Framework
    // ודאי ששם המחלקה הוא *ApplicationDbContext* (כפי שהגדירו מפתחת א')
    public class ApplicationDbContext : DbContext
    {
        // הקונסטרקטור – נדרש על ידי EF Core 
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        // --- הוספת ה-DbSets (מייצגים את הטבלאות ב-DB) ---

        // DbSet של מפתחת א' ל-Transactions
        public DbSet<Transaction> Transactions { get; set; }

        // DbSet שלך ל-Categories
        public DbSet<Category> Categories { get; set; }


        // --- המתודה ליצירת מודל והוספת Seed Data ---
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

            // ודאי שכל ה-Seed Data של מפתחת א' ל-Transaction (אם קיים) נשאר כאן!
        }
    }
}