using PocketWise.API.Data;
using PocketWise.API.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PocketWise.API.Repositories
{
    // המחלקה מממשת את החוזה (ITransactionRepository)
    public class TransactionRepository : ITransactionRepository
    {
        // שדה פרטי לקבלת המופע של ApplicationDbContext בהזרקת תלויות
        private readonly ApplicationDbContext _context;

        // הבנאי (Constructor) שמקבל את ApplicationDbContext
        public TransactionRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        // ----------------------------------------------------
        // 1. CREATE (יצירת טרנזקציה חדשה)
        // ----------------------------------------------------
        public async Task<Transaction> AddAsync(Transaction transaction)
        {
            _context.Transactions.Add(transaction); // מוסיף לזיכרון
            await _context.SaveChangesAsync();      // שולח INSERT ל-DB
            return transaction;
        }

        // ----------------------------------------------------
        // 2. READ (שליפת כל הטרנזקציות)
        // ----------------------------------------------------
        public async Task<IEnumerable<Transaction>> GetAllAsync()
        {
            // שולף את כל הרשומות מטבלת Transactions (SELECT *)
            return await _context.Transactions.ToListAsync();
        }

        // ----------------------------------------------------
        // 3. READ (שליפת טרנזקציה לפי ID)
        // ----------------------------------------------------
        public async Task<Transaction?> GetByIdAsync(int id)
        {
            // שולף רשומה בודדת לפי ID (SELECT TOP 1 * WHERE Id = id)
            return await _context.Transactions.FirstOrDefaultAsync(t => t.Id == id);
            // אפשר גם להשתמש ב: return await _context.Transactions.FindAsync(id);
        }

        // ----------------------------------------------------
        // 4. UPDATE (עדכון טרנזקציה קיימת)
        // ----------------------------------------------------
        public async Task<Transaction?> UpdateAsync(Transaction updatedTransaction)
        {
            // מחפשים את הרשומה הקיימת בבסיס הנתונים
            var existing = await _context.Transactions.FindAsync(updatedTransaction.Id);

            if (existing == null)
                return null; // אם לא קיים, מחזירים null

            // מעתיקים את הערכים החדשים מהאובייקט המעודכן לאובייקט הקיים בזיכרון
            // זה מבטיח שרק השדות המעודכנים יישלחו ל-DB
            _context.Entry(existing).CurrentValues.SetValues(updatedTransaction);

            await _context.SaveChangesAsync(); // שולח UPDATE ל-DB

            return existing;
        }

        // ----------------------------------------------------
        // 5. DELETE (מחיקת טרנזקציה)
        // ----------------------------------------------------
        public async Task<bool> DeleteAsync(int id)
        {
            // מוצאים את האובייקט לפי ID
            var transaction = await _context.Transactions.FindAsync(id);

            if (transaction == null)
                return false; // אם לא נמצא, אין מה למחוק

            _context.Transactions.Remove(transaction); // מסמן למחיקה
            await _context.SaveChangesAsync();         // שולח DELETE ל-DB

            return true;
        }
    }
}