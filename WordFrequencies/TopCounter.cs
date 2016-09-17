using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Data;


namespace WordFrequencies
{
    class TopCounter
    {
        public Dictionary<string, ComplexList> data;
        static int Compare(Pair a, Pair b)
        {
            return a.date.Ticks.CompareTo(b.date.Ticks);
        }
        public TopCounter(string file)
        {
            String str;
            StreamReader sr = new StreamReader(file);
            data = new Dictionary<string, ComplexList>();
            DateTime start = new DateTime(2013,11,1);
           
            while ((str=sr.ReadLine())!=null)
            {
                Char[] del = { '\t' };
                String[] words = str.Split(del);
                Char[] del2 = { '.' };
                String[] d = words[0].Split(del2);
                System.DateTime dt = new DateTime(Int32.Parse(d[2]), Int32.Parse(d[1]), Int32.Parse(d[0]));

                for (int i=1; i<words.Length; i=i+2)
                {
                    Int32 freq = Int32.Parse(words[i + 1]);
                    if (words[i].Contains("Крым")) words[i] = "Крым";
                    if (words[i].Contains("Москв")) words[i] = "Москвa";
                    if (words[i].Contains("Украин")) words[i] = "Украина";
                    if (words[i].Contains("Кита")) words[i] = "Китай";
                    if (words[i].Contains("Донецк")) words[i] = "Донецк";
                    if (words[i].Contains("Киев")) words[i] = "Киев";
                    if (words[i].Contains("Росси")) words[i] = "Россия";
                    if (!data.ContainsKey(words[i]))
                    {
                        data.Add(words[i], new ComplexList());
                    }

                    data[words[i]].total += freq;
                    if (dt >= start)
                    {
                        data[words[i]].total_crisis += freq;
                        //data[words[i]].crisis_data.Add(new Pair(dt, freq));
                    }
                    data[words[i]].crisis_data.Add(new Pair(dt, freq));
                }

            }
            foreach (String key in data.Keys)
            {
                data[key].crisis_data.Sort(Compare);
            }
            sr.Close();

            DataTable tb = new DataTable();
            tb.Columns.Add("name", typeof(string));
            tb.Columns.Add("count", typeof(Int64));

            foreach (String entity in data.Keys)
            {
                tb.Rows.Add(entity, data[entity].total_crisis);
            }

            DataView dv = tb.DefaultView;
            dv.Sort = "count desc";
            tb = dv.ToTable();

            StreamWriter sw = new StreamWriter(Common.topresult, false);
            String header = "entity,crisis_freq,non_crisis_freq, total_freq,";
           

               foreach (Pair p in data[tb.Rows[0][0].ToString()].crisis_data)
            //for (int i = data[tb.Rows[0][0].ToString()].crisis_data.Count - 1; i >= 0; i--)
            {
                //Pair p = data[tb.Rows[0][0].ToString()].crisis_data[i];
                header += p.date.Month.ToString() + "." + p.date.Year.ToString() + ",";
            }
            header = header.Substring(0, header.Length - 1);
            sw.WriteLine(header);
            int index=0;
            //int index = data[tb.Rows[0][0].ToString()].crisis_data.Count - 1;
            Boolean done = false;

            foreach (DataRow dr in tb.Rows)
            {
                Int64 dif = data[dr["name"].ToString()].total - Int32.Parse(dr["count"].ToString());
                String toFile = dr["name"].ToString() + "," + dr["count"].ToString() + "," + dif.ToString() +","+ data[dr["name"].ToString()].total + "," ;
                index = 0;
                done = false;
                
                foreach (Pair p in data[tb.Rows[0][0].ToString()].crisis_data)
                //for (int i = data[tb.Rows[0][0].ToString()].crisis_data.Count - 1; i >= 0; i-- )
                {
                    //Pair p = data[tb.Rows[0][0].ToString()].crisis_data[i];
                   
                    if (!done && (data[dr["name"].ToString()].crisis_data.Count > 0) && (p.date == data[dr["name"].ToString()].crisis_data[index].date))
                    //if (!done && (data[dr["name"].ToString()].crisis_data.Count > 0) && (p.date == data[dr["name"].ToString()].crisis_data[index].date))
                    {
                        toFile += data[dr["name"].ToString()].crisis_data[index].number + ",";
                        index++;
                        //index--;
                        if (index == data[dr["name"].ToString()].crisis_data.Count) done = true;
                        //if (index == -1) done = true;
                    }
                    else
                    {
                        toFile += "0,";
                    }
                }
                toFile = toFile.Substring(0, toFile.Length - 1);
                sw.WriteLine(toFile);
            }

            sw.Close();
            
        }


    }
}
