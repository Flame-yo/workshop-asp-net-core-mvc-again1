﻿using Microsoft.AspNetCore.Mvc;
using SalesWebMvc1.Models;
using SalesWebMvc1.Models.ViewModels;
using SalesWebMvc1.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalesWebMvc1.Controllers
{
    public class SellersController : Controller
    {
        private readonly SellerService _sellerService;
        private readonly DepartmentService _departmentService;

        public SellersController(SellerService sellerService, DepartmentService departmentService)
        {
            _sellerService = sellerService;
            _departmentService = departmentService;
        }
        public IActionResult Index()
        {
            var sellers = _sellerService.FindAll();
            return View(sellers);
        }

        public IActionResult Create()
        {
            var departments = _departmentService.FindAll();
            var obj = new SellerFormViewModel { Departments = departments };
            return View(obj);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Seller seller)
        {
            _sellerService.Insert(seller);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var obj = _sellerService.FindById(id.Value);
            if (obj == null)
            {
                return NotFound();
            }
            return View(obj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {;
            _sellerService.Remove(id);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Edit()
        {
            return View();
        }
    }
}
