using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using WorkingWithVisualStudio.Controllers;
using WorkingWithVisualStudio.Models;
using Xunit;

namespace WorkingWithVisualStudio.Tests
{
    public class HomeControllerTests
    {

        private Func<Product, Product, bool> ProductCompare => (p1, p2) => p1.Name == p2.Name && p1.Price == p2.Price;

        [Theory]
        [ClassData(typeof(ProductTestData))]
        public void IndexActionModelIsComplete(IEnumerable<Product> products)
        {
            // Arrange
            var mock = new Mock<IRepository>();
            mock.SetupGet(m => m.Products).Returns(products);
            var controller = new HomeController(mock.Object);

            // Act
            var model = (controller.Index() as ViewResult)?.ViewData.Model as IEnumerable<Product>;

            // Assert
            Assert.Equal(products, model,
                Comparer.Get<Product>(ProductCompare));
        }

        [Fact]
        public void RepositoryPropertyCalledOnce()
        {
            // Arrange
            var mock = new Mock<IRepository>();
            mock.SetupGet(m => m.Products)
                .Returns(new[] { new Product { Name = "P1", Price = 100 } });
            var controller = new HomeController(mock.Object);

            //Act
            var result = controller.Index();

            // Assert
            mock.VerifyGet(m => m.Products, Times.Once);
            mock.Verify(m => m.AddProduct(It.IsAny<Product>()), Times.Never);
        }
    }
}
