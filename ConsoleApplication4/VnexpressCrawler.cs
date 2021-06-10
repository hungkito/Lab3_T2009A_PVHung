using System;
using System.Collections.Generic;
using System.Linq;
using HtmlAgilityPack;

namespace ConsoleApplication4
{
    public class VnexpressCrawler: Crawler
    {
        public Article Crawl(string url)
        {
            try
            {
                var htmlWeb = new HtmlWeb();
                var htmlDocument = htmlWeb.Load(url);
                var titleNode = htmlDocument.DocumentNode.SelectSingleNode("//h1[contains(@class, 'title-detail')]");
                var title = titleNode.InnerText;
                var contentNode = htmlDocument.DocumentNode.SelectSingleNode("//article[contains(@class, 'fck_detail')]");
                var content = contentNode.InnerHtml;
                var imageNode = htmlDocument.DocumentNode.SelectSingleNode("//picture/img");
                var image = imageNode.Attributes["src"].Value;
                Console.WriteLine(image);
                var article = new Article()
                {
                    Title = title,
                    Content = content,
                    Image = image,
                    Url = url
                };
                return article;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return null;
            }
        }

        public List<string> GetListLink(string listUrl)
        {
            var listLink = new List<string>();
            var htmlWeb = new HtmlWeb();
            var htmlDocument = htmlWeb.Load(listUrl);
            var listNodeA = htmlDocument.DocumentNode.SelectNodes("//h3[contains(@class, 'title-news')]/a");
            for (var i = 0; i < listNodeA.Count; i++)
            {
                var link = listNodeA.ElementAt(i).Attributes["href"].Value;
                listLink.Add(link);
            }
            return listLink;
        }
    }
}