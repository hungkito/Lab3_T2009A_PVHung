using System.Collections.Generic;

namespace ConsoleApplication4
{
    public interface Crawler
    {
        Article Crawl(string url);

        List<string> GetListLink(string listUrl);
    }
}