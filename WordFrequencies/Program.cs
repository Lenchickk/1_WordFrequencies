using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordFrequencies
{
    class Program
    {
        static void Main(string[] args)
        {
           
            var words = new Dictionary<string, int>(StringComparer.CurrentCultureIgnoreCase);
            var heads = new Dictionary<string, int>(StringComparer.CurrentCultureIgnoreCase);
             /*
            Counter.countWordsInFile("try.txt", words);
            Counter.countWordsInFile("try.txt", words);

            String base_address = @"http://www.gazeta.ru/news/index.shtml?p=page&d=";//26.10.2015_09:23";
            DateTime now = DateTime.Now;

            base_address += now.Day + "." + now.Month + "." + now.Year + "_" + now.Hour+":"+now.Minute;
             * */

            //GazetaRip.GarezaRipper(words,heads);
            //GazetaRip.VestiRipper();
            //LevenshteinDistance.Compute("","");
            //LevenshteinDistance.Compute("России", "Pоссийский");
            //LevenshteinDistance.Compute("Украины", "Украинский");
            //LevenshteinDistance.LevenshteinDistance.Compute("", "");
            //LevenshteinDistance.Compute("", "");


            TopCounter tc = new TopCounter(Common.vestim);
        }
    }
}
