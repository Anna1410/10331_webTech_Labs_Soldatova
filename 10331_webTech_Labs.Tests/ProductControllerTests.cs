using _10331_webTech_Labs.Controllers;
using _10331_webTech_Labs.DAL.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _10331_webTech_Labs.Tests
{
    public class ProductControllerTests
    {

        [Theory]
        [MemberData(nameof(TestData.Params), MemberType =
typeof(TestData))]
        public void ControllerGetsProperPage(int page, int qty, int id)
        {
            // Arrange 
            var controller = new ProductController();
            controller._dishes = TestData.GetDishesList();

            // Act
            var result = controller.Index(pageNo: page, group: null) as ViewResult;
            var model = result?.Model as List<Dish>;

            // Assert
            Assert.NotNull(model);
            Assert.Equal(qty, model.Count);
            Assert.Equal(id, model[0].DishId);
        }
    }
}
