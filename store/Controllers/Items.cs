using Microsoft.AspNetCore.Mvc;
using store.Models;
using store.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace store.Controllers
{
    public class Items : Controller
    {
        private readonly StoreDbContext _context;
        public Items(StoreDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            ViewBag.scheme = Request.Scheme;
            ViewBag.url = Request.Host;
            ItemsViewModel ItemsViewModel = new ItemsViewModel();
            ItemsViewModel.Items = _context.Items.Select(c=> new ItemViewModel { Id = c.Id,Name=c.Name,Price=c.Price,Stock=c.Stock}).ToList();
            return View(ItemsViewModel);
        }
       
        [HttpPut]
        public IActionResult Edit(int id,ItemViewModel Ivm)
        {
            if (!ModelState.IsValid)
                return BadRequest();
           var Item = _context.Items.Find(id);
            if (Item==null)
                return NotFound();
            Item.Name = Ivm.Name;
            Item.Price = Ivm.Price;
            _context.SaveChanges();
            return Ok();

        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var Item = _context.Items.Find(id);
            if (Item == null)
                return NotFound();
            _context.Items.Remove(Item);
            _context.SaveChanges();
            return Ok();

        }
        [HttpPost]
        public IActionResult Add(ItemViewModel Ivm)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            Item Item = new Item();
            Item.Name = Ivm.Name;
            Item.Price = Ivm.Price;
            _context.Items.Add(Item);
            _context.SaveChanges();
            return Ok(Item);
        }
        [HttpGet]
        public IActionResult buy()
        {
            StockViewModels svm = new StockViewModels();
            svm.Ivm = _context.Items.Select(c => new ItemViewModel { Id = c.Id, Name = c.Name, Price = c.Price, Stock = c.Stock }).ToList();
            return View(svm);
        }
        [HttpPost]
        public IActionResult AddStock(StockViewModels st)
        {
            if (!ModelState.IsValid)
            {
                StockViewModels svm = new StockViewModels();
                svm.Ivm = _context.Items.Select(c => new ItemViewModel { Id = c.Id, Name = c.Name, Price = c.Price, Stock = c.Stock }).ToList();
                return View("buy",svm);

            }
            var item =  _context.Items.Find(st.Id);
            if (item==null)
            {
                ModelState.AddModelError("Invalid", "Invalid Item");
                StockViewModels svm = new StockViewModels();
                svm.Ivm = _context.Items.Select(c => new ItemViewModel { Id = c.Id, Name = c.Name, Price = c.Price, Stock = c.Stock }).ToList();
                return View("buy", svm);
            }
            item.Stock += st.Stock;
            _context.SaveChanges();
            return RedirectToAction("buy");
        }
    }
}
