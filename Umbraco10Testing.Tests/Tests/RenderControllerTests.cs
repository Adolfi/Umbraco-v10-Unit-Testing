using AutoFixture.NUnit3;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewEngines;
using Microsoft.Extensions.Logging;
using Moq;
using NUnit.Framework;
using Umbraco.Cms.Core.Models;
using Umbraco.Cms.Core.Models.PublishedContent;
using Umbraco.Cms.Core.Web;
using Umbraco.Cms.Web.Common;
using Umbraco.Cms.Web.Common.Controllers;
using Umbraco10Testing.Tests.Features;

namespace Umbraco10Testing.Tests
{
    public class RenderControllerTests
    {
        private PageController controller;

        [SetUp]
        public void SetUp()
        {
            this.controller = new PageController(null, Mock.Of<ILogger<RenderController>>(), Mock.Of<ICompositeViewEngine>(), Mock.Of<IUmbracoContextAccessor>());
        }

        [Test, AutoData]
        public void When_PageAction_ThenResultIsIsAssignableFromContentResult(Mock<IPublishedContent> content)
        {
            var model = new ContentModel(content.Object);

            var result = this.controller.Page(model);

            Assert.IsAssignableFrom<ViewResult>(result);
        }

        [Test, AutoData]
        public void Given_PublishedContentHasHeading_When_PageAction_Then_ReturnViewModelWithHeading_With_AutoFixture(string value, Mock<IPublishedContent> content)
        {
            SetupPropertyValue(content, nameof(PageViewModel.Heading), value);

            var viewModel = (PageViewModel)((ViewResult)this.controller.Page(new ContentModel(content.Object))).ViewData.Model;

            Assert.AreEqual(value, viewModel.Heading);
        }

        public void SetupPropertyValue(Mock<IPublishedContent> content, string propertyAlias, string propertyValue, string culture = null)
        {
            var property = new Mock<IPublishedProperty>();
            property.Setup(x => x.Alias).Returns(nameof(PageViewModel.Heading));
            property.Setup(x => x.GetValue(culture, null)).Returns(propertyValue);
            content.Setup(x => x.GetProperty(propertyAlias)).Returns(property.Object);
        }
    }
}
