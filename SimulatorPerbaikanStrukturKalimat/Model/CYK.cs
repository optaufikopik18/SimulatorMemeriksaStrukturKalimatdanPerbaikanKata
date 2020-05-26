using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace SimulatorPerbaikanStrukturKalimat.Model
{
    class CYK
    {
        private string CYKString;
        private string LastString;

        public CYK()
        {
            this.CYKString = string.Empty;
        }

        public void SetString(string CYKString)
        {
            this.CYKString = CYKString;
        }

        public void RunCYK()
        {
            string[] splitString = CYKString.Split(' ');
            string[,] CYKTable = new string[splitString.Length, splitString.Length];
            string temp = string.Empty;

            for (int i = 0; i < splitString.Length; i++)
            {
                CYKTable[0, i] = splitString[i];
            }

            for (int j = 1; j < splitString.Length; j++)
            {
                for (int k = 0; k < (splitString.Length - j); k++)
                {
                    for (int l = 0; l < j; l++)
                    {
                        CYKTable[j, k] = GetProduction(CYKTable[(j - (l + 1)), k] + " " + CYKTable[l, (j + k - l)]);
                        if (CYKTable[j, k] != "-")
                        {
                            temp = CYKTable[j, k];
                        }
                    }

                    if (temp == string.Empty)
                    {
                        temp = "-";
                    }
                    CYKTable[j, k] = temp;
                    temp = string.Empty;
                }
            }

            LastString = CYKTable[splitString.Length-1, 0];
            Array.Clear(CYKTable, 0, CYKTable.Length);
            Array.Clear(splitString, 0, splitString.Length);
        }

        private string GetProduction(string categoryString)
        {
            string sChar = "-";

            XmlDocument xmlKamus = new XmlDocument();
            XmlNodeList node = xmlKamus.GetElementsByTagName("produksi");
            xmlKamus.Load(@"aturanproduksi.xml");
            
            foreach(XmlNode ap in node)
            {
                if (ap.ChildNodes[1].InnerText == categoryString)
                {
                    sChar = ap.ChildNodes[0].InnerText;
                }
            }

            return sChar;
        }

        public string GetLastCell()
        {
            return LastString;
        }
    }
}
