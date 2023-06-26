using SalesMvc.Data;
using SalesMvc.Models;

namespace SalesMvc.Services
{
    public class DepartmentService
    {

        private readonly SalesMvcContext _context;

        public DepartmentService(SalesMvcContext context)
        {
            _context = context;
        }

        public List<Department> FindAll()
        {
            return _context.Department.OrderBy(x => x.Name).ToList();
        }
    }
}
