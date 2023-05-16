using HW7_8.Models;

namespace HW7_8.Data.Repository
{
    public interface IExpensesRepository
    {
        IEnumerable<Expenses> GetAllExpenses();
        Expenses GetExpenseById(int id);
        public void Add(Expenses expenses);
        public void Update(Expenses expenses);
        public void Delete(int id);


    }
}
