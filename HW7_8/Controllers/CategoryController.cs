using HW7_8.Data;
using HW7_8.Data.Repository;
using HW7_8.Models;
using Microsoft.AspNetCore.Mvc;

namespace HW7_8.Controllers
{
    public class CategoryController : Controller
    {
        private readonly CategoryRepository categoryRepository;

        public CategoryController(CategoryRepository categoryRepository)
        {
            this.categoryRepository = categoryRepository;
        }

        public IActionResult Index()
        {
            List<Category> categories = categoryRepository.GetCategories().ToList();
            return View(categories);
        }
    }
}
