using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace Kea.WebApi.Controllers.Products
{
    public class ProductController : ApiController
    {
        public ProductController()
        {
        }

        public async Task<IEnumerable<Product>> Get()
        {
            return new[] { new Product
            {
                IdReg = 0,
                Name = "Apples"
            },
            new Product
            {
                IdReg = 1,
                Name = "Oranges"
            } };
        }
    }
}
