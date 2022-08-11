using AutoFixture.NUnit3;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewEngines;
using Microsoft.Extensions.Logging;
using Moq;
using NUnit.Framework;
using Umbraco.Cms.Core;
using Umbraco.Cms.Core.Dictionary;
using Umbraco.Cms.Core.Models;
using Umbraco.Cms.Core.Models.PublishedContent;
using Umbraco.Cms.Core.Templates;
using Umbraco.Cms.Core.Web;
using Umbraco.Cms.Web.Common;
using Umbraco.Cms.Web.Common.Controllers;
using Umbraco10Testing.Web.Features;

namespace Umbraco10Testing.Tests
{
    public class UmbracoHelperTests
    {
        private Mock<ICultureDictionary> cultureDictionary;
        private Mock<ICultureDictionaryFactory> cultureDictionaryFactory;
        private UmbracoHelper umbracoHelper;
        private PageController controller;

        [SetUp]
        public void SetUp()
        {
            this.cultureDictionary = new Mock<ICultureDictionary>();
            this.cultureDictionaryFactory = new Mock<ICultureDictionaryFactory>();
            this.cultureDictionaryFactory.Setup(x => x.CreateDictionary()).Returns(this.cultureDictionary.Object);
            this.umbracoHelper = new UmbracoHelper(this.cultureDictionaryFactory.Object, Mock.Of<IUmbracoComponentRenderer>(), Mock.Of<IPublishedContentQuery>());
            this.controller = new PageController(this.umbracoHelper, Mock.Of<ILogger<RenderController>>(), Mock.Of<ICompositeViewEngine>(), Mock.Of<IUmbracoContextAccessor>());
        }

        [Test, AutoData]
        public void GivenMyDictionaryKey_WhenIndexAction_ThenReturnViewModelWithMyPropertyDictionaryValue(string expected)
        {
            var model = new ContentModel(new Mock<IPublishedContent>().Object);
            this.cultureDictionary.Setup(x => x["myDictionaryKey"]).Returns(expected);

            var result = (PageViewModel)((ViewResult)this.controller.PageWithDictionaryItem(model)).Model;

            Assert.AreEqual(expected, result.MyDictionaryProperty);
        }
    }
}
