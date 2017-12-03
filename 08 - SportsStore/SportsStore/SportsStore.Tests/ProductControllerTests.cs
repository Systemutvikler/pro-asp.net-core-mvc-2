using System;
using Xunit;
using Moq;
using SportsStore.Models;
using System.Linq;
using SportsStore.Controllers;
using System.Collections.Generic;
using SportsStore.Models.ViewModels;

namespace SportsStore.Tests
{
    public class ProductControllerTests
    {
        [Fact]
        public void Can_Paginate()
        {
            // Arrange
            Mock<IProductRepository> mock = new Mock<IProductRepository>();
            mock.Setup(m => m.Products).Returns(
                    Enumerable.Range(1, 5).Select(i => new Product { ProductID = i, Name = $"P{i}" }).Reverse()
                .AsQueryable());
            var controller = new ProductController(mock.Object) { PageSize = 3 };

            // Act
            var result = controller.List(2).ViewData.Model as ProductsListViewModel;

            // Assert
            var products = result.Products;
            Assert.True(products.Count() == 2);
            Assert.Equal("P4", products.First().Name);
            Assert.Equal("P5", products.ElementAt(1).Name);
        }

        [Fact]
        public void Can_Send_Pagination_View_Model()
        {
            // Arrange
            Mock<IProductRepository> mock = new Mock<IProductRepository>();
            mock.Setup(m => m.Products).Returns(
                    Enumerable.Range(1, 5).Select(i => new Product { ProductID = i, Name = $"P{i}" }).Reverse()
                .AsQueryable());
            var controller = new ProductController(mock.Object) { PageSize = 3 };

            // Act
            var result = controller.List(2).ViewData.Model as ProductsListViewModel;

            // Assert
            PagingInfo pageInfo = result.PagingInfo;
            Assert.Equal(2, pageInfo.CurrentPage);
            Assert.Equal(3, pageInfo.ItemsPerPage);
            Assert.Equal(5, pageInfo.TotalItems);
            Assert.Equal(2, pageInfo.TotalPages);
        }
    }
}
