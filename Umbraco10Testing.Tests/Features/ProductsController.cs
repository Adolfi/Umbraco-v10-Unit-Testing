using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Umbraco.Cms.Web.Common.Controllers;

namespace Umbraco10Testing.Tests.Features
{
    public class ProductsController : UmbracoApiController
    {
        public IEnumerable<string> GetAllProducts()
        {
            return new[] { "Table", "Chair", "Desk", "Computer", "Beer fridge" };
        }

        [HttpGet]
        public JsonResult GetAllProductsJson()
        {
            return new JsonResult(this.GetAllProducts());
        }
    }

}
