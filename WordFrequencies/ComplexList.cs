using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordFrequencies
{
    public struct Pair
    {
        public DateTime date;
        public Int32 number;
        public Pair(DateTime s, Int32 n)
        {
            date = s;
            number = n;
        }
    }
    class ComplexList
    {
        public Int64 total;
        public Int64 total_crisis;
        public List<Pair> crisis_data;

        public ComplexList()
        {
            total = 0;
            total_crisis = 0;
            crisis_data = new List<Pair>();
        }
        
    }
}
