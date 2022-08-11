using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewEngines;
using Microsoft.Extensions.Logging;
using Umbraco.Cms.Core.Models;
using Umbraco.Cms.Core.Web;
using Umbraco.Cms.Web.Common;
using Umbraco.Cms.Web.Common.Controllers;

namespace Umbraco10Testing.Tests.Features
{
    public class PageController : RenderController
    {
        private readonly UmbracoHelper umbracoHelper;

        public PageController(UmbracoHelper umbracoHelper, ILogger<RenderController> logger, ICompositeViewEngine compositeViewEngine, IUmbracoContextAccessor umbracoContextAccessor) : base(logger, compositeViewEngine, umbracoContextAccessor)
        {
            this.umbracoHelper = umbracoHelper;
        }

        public IActionResult Page(ContentModel model)
        {
            return View(new PageViewModel(model.Content));
        }

        public IActionResult PageWithDictionaryItem(ContentModel model)
        {
            var myCustomModel = new PageViewModel(model.Content)
            {
                MyDictionaryProperty = this.umbracoHelper.GetDictionaryValue("myDictionaryKey")
            };

            return View(myCustomModel);
        }
    }
}
