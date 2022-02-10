using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.IO;

namespace main
{
    public class wheather
    {
        string[] paterns = new string[4]
        {
            "<span class=\"temp__value temp__value_with-unit\">(.*)</span>",
            "<span class=\"temp__value temp__value_with-unit\">(.*)</span>",
            "<span class=\"wind-speed\">(.*)</span>",
            "<abbr class=\" icon-abbr\" title=\"Ветер: западный\" aria-label=\"(.*)\" role=\"text\">З</abbr>",
        };

        public string temperatute;
        public string temperature_felt;
        public string wind;
        public string wind_side;
        public string constructor(string city, int IDpatern)
        {
            string url = "https://yandex.ru/pogoda/";
            string html = string.Empty;
            url += city+ "?lat=51.768199&lon=55.096955";

            HttpWebRequest webRequest = (HttpWebRequest)HttpWebRequest.Create(url);
            HttpWebResponse webResponse = (HttpWebResponse)webRequest.GetResponse();
            StreamReader webreader = new StreamReader(webResponse.GetResponseStream());
            html = webreader.ReadToEnd();

            Match match = Regex.Match(html, paterns[IDpatern]);

            //Form1 form = new Form1();
            //form.label1.Text = $"{match.Groups[1].ToString()}";
            return match.Groups[1].ToString();
        }
    }
}
