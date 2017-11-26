using System.Collections.Generic;
using System.Linq;

namespace WorkingWithVisualStudio.Models
{
    public class SimpleRepository : IRepository
    {
        private Dictionary<string, Product> products;

        public SimpleRepository()
        {
            products = new[]
            {
                new Product { Name = "Kayak", Price = 275M },
                new Product { Name = "Lifejacket", Price = 48.95M },
                new Product { Name = "Soccer ball", Price = 19.50M },
                new Product { Name = "Corner flag", Price = 34.95M }
            }.ToDictionary(p => p.Name);
            products.Add("Error", null);
        }

        public IEnumerable<Product> Products => products.Values;

        public void AddProduct(Product p) => products.Add(p.Name, p);
    }
}
