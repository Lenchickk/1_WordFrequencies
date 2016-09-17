using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace WordFrequencies
{
    class LevenshteinDistance
    {

        static public Dictionary<string, int> LevenshteinDistanceUpdate(Dictionary<string, int> dict)
        {
            Dictionary<string, int> n = new Dictionary<string, int>();

            foreach (String str in dict.Keys)
            {
                foreach (String str2 in n.Keys)
                {
                    if (Compute(str,str2)<=0.3)
                    {

                        n[str2] += dict[str];
                        if (str.Length<str2.Length)
                        {
                            n.Add(str, n[str2]);
                            n.Remove(str2);
                        }
                        goto next;
                    }
                   
                }
                n.Add(str, dict[str]);
            next: ;
            }

            DataTable dt = new DataTable();
            dt.Columns.Add("word", typeof(string));
            dt.Columns.Add("count", typeof(Int32));

            foreach (String str in n.Keys)
            {
                dt.Rows.Add(str, n[str]);
            }

            DataView dv = dt.DefaultView;
            dv.Sort = "count desc";
            dt = dv.ToTable();

            n = new Dictionary<string, int>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                Int32 count = Int32.Parse(dt.Rows[i]["count"].ToString());
                n.Add(dt.Rows[i]["word"].ToString(), count);
            }


            return n;
        }

        static String ParseToLower(String str)
        {
            String s="";
            for (int i=0; i<str.Length; i++)
            {
                s+=Char.ToLower(Char.ToLower(str[i]));
            }
            return s;
        }
        public static double Compute(string s, string t)
        {
            int sl = s.Length;
            int st = t.Length;
            if (s.Length>t.Length)
            {
                s = s.Substring(0, t.Length);
            }

            else
            {
                t = t.Substring(0, s.Length);
            }
            int n = s.Length;
            int m = t.Length;
            int[,] d = new int[n + 1, m + 1];

            // Step 1
            if (n == 0)
            {
                return m;
            }

            if (m == 0)
            {
                return n;
            }

            // Step 2
            for (int i = 0; i <= n; d[i, 0] = i++)
            {
            }

            for (int j = 0; j <= m; d[0, j] = j++)
            {
            }

            // Step 3
            for (int i = 1; i <= n; i++)
            {
                //Step 4
                for (int j = 1; j <= m; j++)
                {
                    // Step 5
                    int cost = (t[j - 1] == s[i - 1]) ? 0 : 1;

                    // Step 6
                    d[i, j] = Math.Min(
                        Math.Min(d[i - 1, j] + 1, d[i, j - 1] + 1),
                        d[i - 1, j - 1] + cost);
                }
            }
            // Step 7
            return (d[n, m]/(double)Math.Min(sl,st));
        }
    }
}
