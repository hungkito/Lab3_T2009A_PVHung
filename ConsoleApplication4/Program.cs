using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HtmlAgilityPack;

namespace ConsoleApplication4
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            VnexpressCrawler vnexpressCrawler = new VnexpressCrawler();
            DantriCrawler dantri = new DantriCrawler();
            while (true)
            {
                Console.WriteLine("=====ListLinkNews=====");
                Console.WriteLine("1. vnexpress");
                Console.WriteLine("2. DanTri");
                Console.WriteLine("3. Exit");
                Console.WriteLine("======================");
                int choice = Convert.ToInt32(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        List<string> listLink = vnexpressCrawler.GetListLink("https://vnexpress.net/giai-tri");
                        for (int i = 0; i < 20; i++)
                        {
                            Console.WriteLine(i);
                            if (i!=5 && i!=11 && i!=15)
                            {
                                Article article = vnexpressCrawler.Crawl(listLink[i]);
                                                            Console.WriteLine(article.Title.ToString());
                            }
                        }
                        break;
                    case 2:
                        List<string> listLinkDantri = dantri.GetListLink("https://dantri.com.vn");
                        for (int i = 0; i < listLinkDantri.Count(); i++)
                        {
                            Article article = dantri.Crawl(listLinkDantri[i]);
                            Console.WriteLine(article.Title.ToString());
                        } 
                        break;
                    case 3:
                        Console.WriteLine("Bye!");
                        break;
                    default:
                        Console.WriteLine("error!! please choice again");
                        break;
                }

                if (choice == 3)
                {
                    break;
                }

                Console.ReadLine();
                
            }
        }
    }
}