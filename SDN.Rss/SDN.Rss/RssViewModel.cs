using System.Collections.ObjectModel;

namespace SDN.Rss
{
    public class RssViewModel
    {
        private readonly ObservableCollection<RssNode> _rssNodes = new ObservableCollection<RssNode>();

        public ObservableCollection<RssNode> RssNodes
        {
            get { return _rssNodes; }
        }

        public RssViewModel()
        {
            GetMeTheRss();
        }

        private async void GetMeTheRss()
        {
            var nodes = await
                RssThingies.GetRssAsync(
                    "http://www.sdn.nl/DesktopModules/DnnForge%20-%20NewsArticles/Rss.aspx?TabID=120&ModuleID=466&MaxCount=25");

            foreach (var rssNode in nodes)
                RssNodes.Add(rssNode);
        }
    }
}