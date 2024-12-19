﻿using Microsoft.EntityFrameworkCore;
using SalesWebMvc1.Data;
using SalesWebMvc1.Models;
using System.Collections.Generic;
using System.Linq;

namespace SalesWebMvc1.Services
{
    public class SellerService
    {
        private readonly SalesWebMvc1Context _context;

        public SellerService(SalesWebMvc1Context context)
        {
            _context = context;
        }

        public List<Seller> FindAll()
        {
            return _context.Seller.ToList();
        }

        public void Insert(Seller seller)
        {
            _context.Add(seller);
            _context.SaveChanges();
        }

        public Seller FindById(int id)
        {
            return _context.Seller.Include(obj => obj.Department).FirstOrDefault(obj => obj.Id == id);
        }

        public void Remove(int id)
        {
            var obj = _context.Seller.Find(id);
            _context.Seller.Remove(obj);
            _context.SaveChanges();
        }

        public void Update(int id)
        {
            var obj = _context.Seller.FirstOrDefault(s => s.Id == id);
            _context.Seller.Update(obj);
            _context.SaveChanges();
        }
    }
}
