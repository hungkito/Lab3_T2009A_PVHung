using System;
using System.Collections.Generic;
using System.Linq;
using HtmlAgilityPack;

namespace ConsoleApplication4
{
    public class DantriCrawler: Crawler
    {
        public Article Crawl(string url)
        {
            try
            {
                var htmlWeb = new HtmlWeb();
                var htmlDocument = htmlWeb.Load(url);
                var titleNode = htmlDocument.DocumentNode.SelectSingleNode("//h1[contains(@class, 'dt-news__title')]");
                var title = titleNode.InnerText;
                var contentNode = htmlDocument.DocumentNode.SelectSingleNode("//div[contains(@class, 'dt-news')]");
                var content = contentNode.InnerHtml;
                var imageNode = htmlDocument.DocumentNode.SelectSingleNode("//img");
                var image = imageNode.Attributes["src"].Value;
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
            var listNodeA = htmlDocument.DocumentNode.SelectNodes("//h2[contains(@class, 'news-item__title')]/a");
            for (var i = 0; i < listNodeA.Count; i++)
            {
                var link = listUrl+listNodeA.ElementAt(i).Attributes["href"].Value;
                listLink.Add(link);
            }
            return listLink;
        }
    }
}