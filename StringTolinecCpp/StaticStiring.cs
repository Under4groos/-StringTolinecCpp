using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringTolinecCpp
{
    public static class StaticStiring
    {
        public static bool is_vlaid_string(this string str)
        {
            return str != " " && str != "" && str.Equals("") && str != "\n" && str != Properties.Resources.test;
        } 
        public static string mul_replace(this string str , List<(string,string)> str_table)
        {
            if (str_table.Count <= 0)
                return str;
            foreach (var item in str_table)
            {
                str = str.Replace(item.Item1, item.Item2);
            }
            return str;
        }
        public static string mul_replace(this string str , List<string> str_table , string str_repl)
        {
            if (str_table.Count <= 0)
                return str;
            foreach (var item in str_table)
            {
                str = str.Replace(item, str_repl);
            }
            return str;
        }

        public static int StringToInt(this string str)
        {
            int out_num = 0;
            if (int.TryParse(str, out out_num))
                return out_num;
            return out_num;
        }
        public static int GetTextNumber(this string str)
        {
            string str_ret = "";
            foreach (char item in str)
            {
                int out_num = 0;
                if (int.TryParse(item.ToString(), out out_num))
                    str_ret += $"{out_num}";
            }
            Console.WriteLine(str_ret);
            return str_ret.StringToInt();
        }
    }
}
