﻿using Microsoft.CodeAnalysis.CSharp;
using SalesMvc.Data;
using SalesMvc.Models;

namespace SalesMvc.Services
{
    public class SellerService
    {
        private readonly SalesMvcContext _context;

        public SellerService(SalesMvcContext context)
        {
            _context = context;
        }

        public List<Seller> FindAll()
        {
            return _context.Seller.ToList();
        }
    }
}