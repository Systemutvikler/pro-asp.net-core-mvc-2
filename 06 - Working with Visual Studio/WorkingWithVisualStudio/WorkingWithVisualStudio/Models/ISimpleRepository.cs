using System.Collections.Generic;

namespace WorkingWithVisualStudio.Models
{
    public interface ISimpleRepository
    {
        IEnumerable<Product> Products { get; }
    }
}