using Newtonsoft.Json;
using NUnit.Framework;
using Umbraco10Testing.Tests.Features;

namespace Umbraco10Testing.Tests
{
    public class UmbracoApiControllerTests
    {
        private ProductsController controller;

        [SetUp]
        public void SetUp()
        {
            this.controller = new ProductsController();
        }

        [Test]
        public void WhenGetAllProducts_ThenReturnViewModelWithExpectedProducts()
        {
            var expected = new[] { "Table", "Chair", "Desk", "Computer", "Beer fridge" };

            var result = this.controller.GetAllProducts();

            Assert.AreEqual(expected, result);
        }

        [Test]
        public void WhenGetAllProductsJson_ThenReturnViewModelWithExpectedJson()
        {
            var json = JsonConvert.SerializeObject(this.controller.GetAllProductsJson().Value);

            Assert.AreEqual("[\"Table\",\"Chair\",\"Desk\",\"Computer\",\"Beer fridge\"]", json);
        }
    }
}
