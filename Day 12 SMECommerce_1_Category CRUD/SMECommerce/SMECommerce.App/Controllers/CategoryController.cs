using Microsoft.AspNetCore.Mvc;
using SMECommerce.App.Models.CategoryModels;
using SMECommerce.Models.EntityModels;
using SMECommerce.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SMECommerce.App.Controllers
{
    public class CategoryController : Controller
    {
        CategoryRepository _categoryRepository;

        public CategoryController()
        {
            _categoryRepository = new CategoryRepository();
        }
        public string Index()
        {
            return "This is the default controller";
        }

        
        public IActionResult Create()
        {
           return View();
        }

        [HttpPost]
        public IActionResult Create(CategoryCreate model)
        {
           
            if (model.Name != null)
            {
                var category = new Category()
                {
                    Name = model.Name,
                    Description = model.Description,
                    Code = model.Code
                };

                var isAdded = _categoryRepository.Add(category);

                if (isAdded)
                {
                    return RedirectToAction("List");
                }
            }

            return View();
        }


        public IActionResult Edit(int? id)
        {
            if(id == null)
            {
                return RedirectToAction("List");
            }

            var category = _categoryRepository.GetById((int)id);

            if(category == null)
            {
                return RedirectToAction("List");
            }

            var categoryEditVm = new CategoryEditVm()
            {
                Id = category.Id,
                Name = category.Name,
                Code = category.Code,
                Description = category.Description
            };

            return View(categoryEditVm);

        }

        [HttpPost]
        public IActionResult Edit(CategoryEditVm model)
        {
            if (ModelState.IsValid)
            {
                var category = new Category()
                {
                    Id = model.Id,
                    Name = model.Name,
                    Code = model.Code,
                    Description = model.Description
                };


                bool isUpdated = _categoryRepository.Update(category);
                if (isUpdated)
                {
                    return RedirectToAction("List");
                }
            }

            return View();
        }


        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("List");
            }

            var category = _categoryRepository.GetById((int)id);
            if(category == null)
            {
                return RedirectToAction("List");
            }

            bool isRemoved = _categoryRepository.Remove(category);

            if (isRemoved)
            {
                return RedirectToAction("List");
            }

            return RedirectToAction("List");
        }


        public IActionResult List()
        {
            var categoryList = _categoryRepository.GetAll();

            var categoryListVm = new CategoryListVM()
            {
                Title = "Category Overview",
                Description = "You can manage categories from this page, you can create update, delete categories...",
                CategoryList = categoryList.ToList()
            };

            return View(categoryListVm);
        }

        public string CategoryListCreate(CategoryCreate[] categories)
        {
            string data = "Category List Create"+Environment.NewLine;
            if(categories!=null && categories.Any())
            {
                foreach(var category in categories)
                {
                    data += $"Category Create: {category.Name} Code: {category.Code}"+Environment.NewLine;
                }
            }

            return data;
        }
    }
}
