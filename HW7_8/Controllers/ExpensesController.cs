using HW7_8.Data.Repository;
using HW7_8.Models;
using Microsoft.AspNetCore.Mvc;

namespace HW7_8.Controllers
{
    public class ExpensesController : Controller
    {
        private readonly ExpenseRepository expenseRepository;

        public ExpensesController(ExpenseRepository expenseRepository)
        {
            this.expenseRepository = expenseRepository;
        }
        public IActionResult Index()
        {
            List<Expenses> expenses = expenseRepository.GetAllExpenses().ToList();

            return View(expenses);
        }

        public ActionResult AddEditExpense(int id)
        {
            Expenses expense = new Expenses();

            if (expense.Id > 0)
            {
                expense = expenseRepository.GetExpenseById(id);
            }

            return PartialView("_expenseForm", expense);
        }

        [HttpPost]
        public ActionResult AddEdit(Expenses expense)
        {
            if (ModelState.IsValid)
            {
                if (expense.Id > 0)
                {
                    var editableExpense = expenseRepository.GetExpenseById(expense.Id);

                    editableExpense.Category = expense.Category;
                    editableExpense.Comment = expense.Comment;
                    editableExpense.MoneySpent = expense.MoneySpent;   
                    editableExpense.Date = expense.Date;

                    expenseRepository.Update(editableExpense);
                } 
                else
                {
                    var newExpense = new Expenses() { MoneySpent = expense.MoneySpent, Date = expense.Date, Category = expense.Category, Comment = expense.Comment };
                    expenseRepository.Add(newExpense);
                }        
            }

            return RedirectToAction("Index");
        }
    }
}
