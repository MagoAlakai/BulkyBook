﻿namespace BulkyBook1.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ApplicationDbContext _db;
        public CategoryController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            IEnumerable<Category> objCategoryList = _db.Categories;
            IEnumerable<CategoryViewModel> viewObjCategoryList;
            viewObjCategoryList = objCategoryList.Adapt<IEnumerable<CategoryViewModel>>();

            return View(viewObjCategoryList);
        }

        //CREATE
        //Get
        public IActionResult Create()
        {
            return View();
        }

        //Post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Category obj)
        {
            if (ModelState.IsValid)
            {
                _db.Categories.Add(obj);
                _db.SaveChanges();
                TempData["success"] = "Category created successfully";
                return RedirectToAction("Index");
            }
            
            return View(obj);
        }

        //EDIT
        //Get
        public IActionResult Edit(int? id)
        {
            if(id is null || id is 0)
            {
                return NotFound();
            }
            var categoryFromDb = _db.Categories.Find(id);
            
            if (categoryFromDb is null)
            {
                return NotFound();
            }

            var viewCategory = categoryFromDb.Adapt<CategoryViewModel>();
            return View(viewCategory);
        }

        //Post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Category obj)
        {
            if (ModelState.IsValid)
            {
                _db.Categories.Update(obj);
                _db.SaveChanges();
                TempData["success"] = "Category updated successfully";
                return RedirectToAction("Index");
            }

            return View(obj);
        }

        //DELETE
        //Get
        public IActionResult Delete(int? id)
        {
            if (id is null || id is 0)
            {
                return NotFound();
            }
            var categoryFromDb = _db.Categories.Find(id);
            if (categoryFromDb is null)
            {
                return NotFound();
            }
            var viewCategory = categoryFromDb.Adapt<CategoryViewModel>();
            return View(viewCategory);
        }

        //Post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(Category category)
        {
            if (category is null)
            {
                return NotFound();
            }
            _db.Categories.Remove(category);
            _db.SaveChanges();
            TempData["success"] = "Category deleted successfully";
            return RedirectToAction("Index");
        }
    }
}
