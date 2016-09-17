using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Data;

namespace WordFrequencies
{
    
    static public class Export
    {
        static public String[] simplelist = { "На", "Как" };
        static public void ToFile(Dictionary<string, int> d, String date, String file, String file2)
        {
            String newline = date + "\t";
            Dictionary<string,int> dt = TableFromDict(d);

           /*
            for (int i=0; i<50; i++)
            {
                newline += dt[i] + "\t" + dt.Rows[i]["count"].ToString() + "\t";
                newline += dt.Rows[i]["word"].ToString() + "\t" + dt.Rows[i]["count"].ToString() + "\t";
            }
           */
            /*
            foreach (String str in dt.Keys)
            {
                newline += str + "\t" + dt[str].ToString() + "\t";
            }

            newline = newline.Substring(0, newline.Length - 1);
            StreamWriter sw = new StreamWriter(file, true, Encoding.UTF8);
            sw.WriteLine(newline);
            sw.Close();*/
            StreamWriter sw = new StreamWriter(file2, true, Encoding.UTF8);
            dt = LevenshteinDistance.LevenshteinDistanceUpdate(dt);

            newline = date + "\t";
            foreach (String str in dt.Keys)
            {
                newline += str + "\t" + dt[str].ToString() + "\t";
            }

            newline = newline.Substring(0, newline.Length - 1);
            sw = new StreamWriter(file2, true, Encoding.UTF8);
            sw.WriteLine(newline);
            sw.Close();

                       
        }


        static Dictionary<string, int> TableFromDict(Dictionary<string, int> d)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("word", typeof(string));
            dt.Columns.Add("count", typeof(Int32));

            foreach (String str in d.Keys)
            {
                dt.Rows.Add(str, d[str]);
            }

            DataView dv = dt.DefaultView;
            dv.Sort = "count desc";
            dt = dv.ToTable();

            d = new Dictionary<string, int>();

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                Int32 count = Int32.Parse(dt.Rows[i]["count"].ToString());
                d.Add(dt.Rows[i]["word"].ToString(),count);
            }

            return d;
        }



    }
}
