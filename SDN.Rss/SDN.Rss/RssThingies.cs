using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace SDN.Rss
{
    public class RssNode
    {
        public string Title { get; set; }

        public string PubDate { get; set; }

        public string Summary { get; set; }

        public string Link { get; set; }
    }

    public static class RssThingies
    {
        public static async Task<RssNode[]> GetRssAsync(string feedUrl)
        {
            using (var client = new HttpClient())
            {
                var xmlFeed = await client.GetStringAsync(feedUrl);
                var doc = XDocument.Parse(xmlFeed);

                var items = (from item in doc.Descendants("item")
                             select new RssNode
                             {
                                 Title = item.Element("title").Value,
                                 PubDate = item.Element("pubDate").Value,
                                 Summary = StripTagsRegex(WebUtility.HtmlDecode(item.Element("description").Value)),
                                 Link = item.Element("link").Value
                             }).ToArray();

                return items;
            }
        }

        public static string StripTagsRegex(string source)
        {
            return Regex.Replace(source, "<.*?>", string.Empty);
        }
    }
}