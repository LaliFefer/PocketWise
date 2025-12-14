namespace PocketWise.API.Models
{
    public class Transaction
    {
        // 1. מזהה ייחודי (Primary Key) – EF Core מזהה שדה בשם Id כ-PK אוטומטית.
        public int Id { get; set; }

        // 2. הסכום הכספי של התנועה
        public decimal Amount { get; set; }

        // 3. תאריך התנועה (חובה)
        public DateTime Date { get; set; }

        // 4. תיאור קצר (ניתן לביטול)
        public string? Description { get; set; }

        // 5. מפתח זר לקטגוריה (המחלקה Category תיווצר על ידי מפתחת ב')
        public int CategoryId { get; set; }

        // 6. סוג התנועה (הכנסה/הוצאה). נשתמש במחרוזת פשוטה או Enum בהמשך, כרגע נשאיר String.
        public string Type { get; set; } // לדוגמה: "Income" או "Expense"
    }
}