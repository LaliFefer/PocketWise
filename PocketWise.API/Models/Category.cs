namespace PocketWise.API.Models
{
    public class Category
    {
        // Primary Key for the database
        public int Id { get; set; }

        // The name of the category (e.g., "Food", "Rent", "Salary")
        public required string Name { get; set; }

        // A unique icon name (e.g., "fa-home", "fa-pizza-slice")
        public string? Icon { get; set; }

        // A color code for visual representation (e.g., "#FF5733")
        public string? Color { get; set; }

        // Type of transaction associated with the category (true for Income, false for Expense)
        public required bool IsIncome { get; set; }
    }
}