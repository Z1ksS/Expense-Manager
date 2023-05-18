using HW7_8.Models;
using Microsoft.EntityFrameworkCore;

namespace HW7_8.Data.Repository
{
    public class ExpenseRepository : IExpensesRepository
    {
        private readonly ApplicationDbContext dbContext;

        public ExpenseRepository(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public IEnumerable<Expenses> GetAllExpenses()
        {
            var expenses = dbContext.expenses.ToList();
            return expenses;
        }

        public Expenses GetExpenseById(int id)
        {
            var expense = dbContext.expenses.Find(id);

            return expense;
        }

        public void Add(Expenses expenses)
        {
            dbContext.expenses.Add(expenses);
            dbContext.SaveChanges();
        }

        public void Delete(int id)
        {
            dbContext.expenses.Remove(GetExpenseById(id));
            dbContext.SaveChanges();
        }

        public void Update(Expenses expenses)
        {
            dbContext.expenses.Update(expenses);
            dbContext.SaveChanges();
        }
    }
}
