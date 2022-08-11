using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using Umbraco.Cms.Core.Cache;
using Umbraco.Cms.Core.Logging;
using Umbraco.Cms.Core.Routing;
using Umbraco.Cms.Core.Services;
using Umbraco.Cms.Core.Web;
using Umbraco.Cms.Infrastructure.Persistence;
using Umbraco10Testing.Tests.Features;

namespace Umbraco10Testing.Tests
{
    public class SurfaceControllerTests
    {
        private PageSurfaceController controller;

        [SetUp]
        public void SetUp()
        {
            this.controller = new PageSurfaceController(Mock.Of<IUmbracoContextAccessor>(), Mock.Of<IUmbracoDatabaseFactory>(), ServiceContext.CreatePartial(), AppCaches.NoCache, Mock.Of<IProfilingLogger>(), Mock.Of<IPublishedUrlProvider>());
        }

        [Test]
        public void When_SubmitAction_ThenResultIsIsAssignableFromContentResult()
        {
            var result = this.controller.Submit();

            Assert.IsAssignableFrom<ContentResult>(result);
        }

        [Test]
        public void When_SubmitAction_Then_ExpectHelloWorld()
        {
            var result = (ContentResult)this.controller.Submit();

            Assert.AreEqual("H5YR!", result.Content);
        }
    }
}
