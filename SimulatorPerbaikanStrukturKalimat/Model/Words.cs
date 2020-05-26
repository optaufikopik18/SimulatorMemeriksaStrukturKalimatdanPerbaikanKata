using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace SimulatorPerbaikanStrukturKalimat.Model
{
    class Words
    {
        private string Word;

        public Words()
        {
            this.Word = string.Empty;
        }

        public string GroupingWords(string word)
        {
            /*XML for load Aturan Produksi*/
            XmlDocument xmlKamus = new XmlDocument();
            XmlNodeList node = xmlKamus.GetElementsByTagName("kata");
            xmlKamus.Load(@"kamus.xml");

            string catg = string.Empty;

            foreach (XmlNode ap in node)
            {
                /*Search same word and take the Category*/
                if (word.ToLower() == ap.ChildNodes[1].InnerText.ToLower())
                {
                    catg = ap.ChildNodes[0].InnerText;
                }
            }

            if (catg == string.Empty)
            {
                catg = "X";
            }

            return catg;
        }
    }
}
