using HW7_8.Data;
using HW7_8.Data.Repository;
using HW7_8.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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

        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(Category category)
        {
            if (ModelState.IsValid)
            {
                var newCategory = new Category() { Name = category.Name };
                categoryRepository.Add(newCategory);

                return RedirectToAction("Index");
            }

            return View(category);
        }

        public IActionResult Edit(int id)
        {
            var category = categoryRepository.GetCategoryById(id);

            return View(category);
        }

        [HttpPost]
        public IActionResult Edit(Category category)
        {
            if (ModelState.IsValid)
            {
                var editableCategory = categoryRepository.GetCategoryById(category.Id);

                editableCategory.Name = category.Name;
                categoryRepository.Update(editableCategory);

                return RedirectToAction("Index");
            }

            return View(category);
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            categoryRepository.Delete(id);

            return RedirectToAction("Index");
        }
    }
}
