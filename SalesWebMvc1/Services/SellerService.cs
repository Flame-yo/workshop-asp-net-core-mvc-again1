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

        public void Create()
        {
    
        }
    }
}
