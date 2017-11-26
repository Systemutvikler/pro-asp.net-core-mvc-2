using System.Collections;
using System.Collections.Generic;
using System.Linq;
using WorkingWithVisualStudio.Models;

namespace WorkingWithVisualStudio.Tests
{
    public class ProductTestData : IEnumerable<object[]>
    {
        private System.Func<decimal,int, Product> Decimal2Product = (p, i) => new Product { Name = $"P{i+1}", Price = p };

        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[] { GetPricesUnder50() };
            yield return new object[] { GetPricesOver50 };
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        private IEnumerable<Product> GetPricesUnder50()
        {
            //return Enumerable.Select(new decimal []{ 275, 49.95M, 19.50M, 24.95M }, Decimal2Product );
            return new decimal[] { 275, 49.95M, 19.50M, 24.95M }.Select(Decimal2Product);
        }

        private Product[] GetPricesOver50 => new Product[] {
            new Product { Name = "P1", Price = 5 },
            new Product { Name = "P2", Price = 48.95M },
            new Product { Name = "P3", Price = 19.50M },
            new Product { Name = "P4", Price = 24.95M }};
    }
}