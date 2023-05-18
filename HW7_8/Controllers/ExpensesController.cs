using HW7_8.Data.Repository;
using HW7_8.Models;
using Microsoft.AspNetCore.Mvc;

namespace HW7_8.Controllers
{
    public class ExpensesController : Controller
    {
        private readonly ExpenseRepository expenseRepository;
        private readonly CategoryRepository categoryRepository;

        public ExpensesController(ExpenseRepository expenseRepository, CategoryRepository categoryRepository)
        {
            this.expenseRepository = expenseRepository;
            this.categoryRepository = categoryRepository;
        }
        public IActionResult Index()
        {
            List<Expenses> expenses = expenseRepository.GetAllExpenses().ToList();

            return View(expenses);
        }

        public ActionResult AddEditExpense(int id)
        {
            Expenses expense = new Expenses();

            if (id > 0)
            {
                expense = expenseRepository.GetExpenseById(id);
            }

            Console.Write(expense.Comment);
            return PartialView("_expenseForm", expense);
        }

        [HttpPost]
        public IActionResult AddEdit(Expenses expense)
        {
            if (expense.Id > 0)
            {
                var editableExpense = expenseRepository.GetExpenseById(expense.Id);

                editableExpense.Category = categoryRepository.GetCategoryById(expense.CategoryId);
                editableExpense.Comment = expense.Comment;
                editableExpense.MoneySpent = expense.MoneySpent;   
                editableExpense.Date = expense.Date;

                expenseRepository.Update(editableExpense);
            } 
            else
            {
                var newExpense = new Expenses() { MoneySpent = expense.MoneySpent, Date = expense.Date, Category = categoryRepository.GetCategoryById(expense.CategoryId), Comment = expense.Comment };
                expenseRepository.Add(newExpense);
            }

            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            expenseRepository.Delete(id);

            return RedirectToAction("Index");
        }
    }
}
