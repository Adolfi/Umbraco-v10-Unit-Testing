using Umbraco.Cms.Core.Models;
using Umbraco.Cms.Core.Models.PublishedContent;

namespace Umbraco10Testing.Tests.Features
{
    public class PageViewModel : ContentModel
    {
        public PageViewModel(IPublishedContent content) : base(content) { }

        public string Heading => (string)this.Content.GetProperty(nameof(Heading)).GetValue();

        public string? MyDictionaryProperty { get; internal set; }
    }
}
