using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using HtmlAgilityPack;
using System.IO;
using System.Net;

namespace WordFrequencies
{
    class GazetaRip
    {

        static public void GarezaRipper(Dictionary<string, int> words, Dictionary<string, int> heads)
        {
            DateTime now = DateTime.Now;
            DateTime now2 = DateTime.Now;
            var words_m = new Dictionary<string, int>(StringComparer.CurrentCultureIgnoreCase);
            var heads_m = new Dictionary<string, int>(StringComparer.CurrentCultureIgnoreCase);
            String base_address = @"http://www.gazeta.ru/news/index.shtml?p=page&d=";
            
            String current_address=base_address+Common.fullTime(now);//26.10.2015_09:23";
                    
            var document = new HtmlDocument();
            var client = new WebClient();

            while (now.Year>2010)
            {
                current_address = base_address + Common.fullTime(now);
            again:
                var stream = client.OpenRead(current_address);

                var reader = new StreamReader(stream, Encoding.GetEncoding("Windows-1251"));
                var html = reader.ReadToEnd();
                document.LoadHtml(html);

                HtmlNodeCollection nodes = document.DocumentNode.SelectNodes("//div[@class='article_text txt_1']");
                if (nodes==null)
                {
                    current_address = current_address.Substring(0, current_address.Length - 1) + "9";
                    goto again;
                }
                
                foreach (HtmlNode n in nodes)
                {
                    foreach (HtmlNode c in n.ChildNodes)
                    {
                        if (c.Name == "h1")
                        {
                            //Counter.countWordsInText(c.InnerText, heads);
                            Counter.countWordsInText(c.InnerText, heads_m);
                            continue;
                        }
                        if (c.Name=="noindex")
                        {
                            //Counter.countWordsInText(c.InnerText, words);
                            Counter.countWordsInText(c.InnerText, words_m);
                            break;
                        }

                    }
                }

                nodes = document.DocumentNode.SelectNodes("//h3[@class='txtclear txt_info_g pd5 hide_show ml2']");

                now = DateTime.ParseExact((nodes[nodes.Count - 1].InnerText).Replace(".",""), "ddMMyyyy",null);
                if (now2.Month!=now.Month)
                {
                    Export.ToFile(words_m, nodes[nodes.Count - 1].InnerText, Common.tfolder, Common.tfolderm);
                    Export.ToFile(heads_m, nodes[nodes.Count - 1].InnerText, Common.hfolder, Common.hfolderm);
                }
                now2 = now;
                Console.WriteLine(now.ToString());
                

            }

        }



        static public void VestiRipper()
        {
            DateTime now = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
            DateTime now2 = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
            var heads_m = new Dictionary<string, int>(StringComparer.CurrentCultureIgnoreCase);
            String base_address = @"http://www.vesti.ru/news/index/date/";
            StreamWriter sw = new StreamWriter(Common.vestiallheads,false);
            sw.Close();

            String current_address;// = base_address + Common.fullTime(now);//26.10.2015_09:23";

            var document = new HtmlDocument();
            var client = new WebClient();

            while (now.Year > 2005)
            {
                current_address = base_address + Common.fullTimeNT(now);
                
                var stream = client.OpenRead(current_address);

                var reader = new StreamReader(stream, Encoding.GetEncoding("UTF-8"));
                var html = reader.ReadToEnd();
                document.LoadHtml(html);

                HtmlNodeCollection nodes = document.DocumentNode.SelectNodes("//div[@class='b-item_list item']");
               

                foreach (HtmlNode n in nodes)
                {
                    if (n.InnerText.Replace('\n', ' ').Trim() == null) continue;
                    if (n.InnerText.Replace('\n', ' ').Trim().Split(' ')[0][0] == '<') continue;
                    if (n.InnerText.Replace('\n', ' ').Trim().Split(' ')[0][0] == '=') continue;
                    int index= n.InnerText.Replace('\n', ' ').Trim().IndexOf("        ");
                    String help = n.InnerText.Replace('\n', ' ').Trim().Substring(0, index);
                    Counter.countWordsInText(help, heads_m);
                    sw = new StreamWriter(Common.vestiallheads, true);
                    sw.WriteLine(now2.Day + "." + now2.Month + "." + now2.Year + " " +  help);

                    sw.Close();
                }

                now = new DateTime(now.Ticks - TimeSpan.TicksPerDay);
                Console.WriteLine(now2.Day + "." + now2.Month + "." + now2.Year);
                if (now2.Month != now.Month)
                {
                    Export.ToFile(heads_m, now2.Day+"."+now2.Month+"."+now2.Year, Common.vesti, Common.vestim);
                    heads_m = new Dictionary<string, int>(StringComparer.CurrentCultureIgnoreCase);
                }
                now2 = new DateTime(now.Ticks);

            }

     

        }
    }
}
