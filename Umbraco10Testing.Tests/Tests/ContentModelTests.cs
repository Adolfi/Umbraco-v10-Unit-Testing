using AutoFixture.NUnit3;
using Moq;
using NUnit.Framework;
using Umbraco.Cms.Core.Models.PublishedContent;
using Umbraco10Testing.Web.Features;

namespace Umbraco10Testing.Tests
{
    public class ContentModelTests
    {
        [Test, AutoData]
        public void Given_PublishedContent_When_GetHeading_Then_ReturnPageViewModelWithHeading(string value, Mock<IPublishedContent> content)
        {
            SetupPropertyValue(content, nameof(PageViewModel.Heading), value);

            var viewModel = new PageViewModel(content.Object);

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