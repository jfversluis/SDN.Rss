using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml.Linq;
using Xamarin.Forms;

namespace SDN.Rss
{
    public class RssNode
    {
        public string Title { get; set; }

        public string PubDate { get; set; }

        public string Summary { get; set; }

        public HtmlWebViewSource Content { get; set; }

        public string Link { get; set; }
    }

    public static class RssThingies
    {
        public static async Task<RssNode[]> GetRssAsync(string feedUrl)
        {
            using (var client = new HttpClient())
            {
                var xmlFeed = await client.GetStringAsync(feedUrl);

                // HACK &euml; isn't valid XML but it's in there, so work around it..
                xmlFeed = xmlFeed.Replace("&euml;", "ë");
                var doc = XDocument.Parse(xmlFeed);
                
                var items = (from item in doc.Descendants("item")
                             select new RssNode
                             {
                                 Title = item.Element("title").Value,
                                 PubDate = item.Element("pubDate").Value,
                                 Summary = StripTagsRegex(item.Element("description").Value).Trim(),
                                 Content = new HtmlWebViewSource { Html = "<html style=\"font-family: -apple-system;\">" + WebUtility.HtmlDecode(item.Element("description").Value) + "</html>" },
                                 Link = item.Element("link").Value
                             }).ToArray();

                return items;
            }
        }

        public static string StripTagsRegex(string source)
        {
            return Regex.Replace(source, "<.*?>", " ");
        }
    }
}