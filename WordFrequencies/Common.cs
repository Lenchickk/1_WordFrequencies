using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordFrequencies
{
    static public class Common
    {
        static public String Base = @"D:\wp\pipe\frequencies\";
        static public String vesti = Base + "vesti.txt";
        static public String vestim = Base + "vestiM.txt";
        static public String vestiallheads = Base + "vestiHeads.txt";

        static public String tfolder = @"C:\Users\Lenchick\Google Drive\WASHU FALL2015\play ground\pipe\freq\frequencies_in_articles.txt";
        static public String hfolder = @"C:\Users\Lenchick\Google Drive\WASHU FALL2015\play ground\pipe\freq\frequencies_in_heads.txt";
        static public String tfolderm = @"C:\Users\Lenchick\Google Drive\WASHU FALL2015\play ground\pipe\freq\frequencies_in_articles_LU.txt";
        static public String hfolderm = @"C:\Users\Lenchick\Google Drive\WASHU FALL2015\play ground\pipe\freq\frequencies_in_heads_LU.txt";
       
        static public String topresult = Base + "VestiTopsorted.txt";
        
        
        static public String fullTime(DateTime dt)
        {
            String str = "";
            if (dt.Day < 10)
            {
                str += "0" + dt.Day + ".";
            }
            else
            {
                str += dt.Day + ".";
            }

            if (dt.Month < 10)
            {
                str += "0" + dt.Month + ".";
            }
            else
            {
                str += dt.Month + ".";
            }

            str += dt.Year + "_";

            if (dt.Hour < 10)
            {
                str += "0" + dt.Hour + ":";
            }
            else
            {
                str += dt.Hour + ":";
            }

            if (dt.Minute < 10)
            {
                str += "0" + (dt.Minute+2).ToString();
            }
            else
            {
                str += (dt.Minute+2).ToString();
            }

            return str;
        }

        static public String fullTimeNT(DateTime dt)
        {
            String str = "";
            if (dt.Day < 10)
            {
                str += "0" + dt.Day + ".";
            }
            else
            {
                str += dt.Day + ".";
            }

            if (dt.Month < 10)
            {
                str += "0" + dt.Month + ".";
            }
            else
            {
                str += dt.Month + ".";
            }

            str += dt.Year;


            return str;
        }
    }
}
