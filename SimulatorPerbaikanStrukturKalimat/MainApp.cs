using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.Xml;
using SimulatorPerbaikanStrukturKalimat.Model;

namespace SimulatorPerbaikanStrukturKalimat
{
    public partial class MainApp : Form
    {
        private bool isMistaken;
        private bool isPolaMistaken;
        private string filename;

        private List<List<string>> sentence = new List<List<string>>(); /* Berisi kalimat-kalimat*/
        private List<string> mistakenWords = new List<string>(); /* Berisi kata yang salah */
        private List<int> mistakenWordsPos = new List<int>(); /* Berisi posisi dari kata yang salah*/
        private List<List<string>> fixedWords = new List<List<string>>(); /* Berisi kata yang diperbaiki {{kata yang salah} -> {perbaikan kata}}*/

        private List<string> pola = new List<string>(); /* Berisi pola kalimat*/
        private List<string> mistakenPola = new List<string>(); /* Berisi pola kalimat yang salah */
        private List<int> mistakenPolaPos = new List<int>(); /* Berisi posisi dari pola kalimat yang salah*/
        private List<List<string>> fixedPola = new List<List<string>>(); /* Berisi pola kalimat yang diperbaiki {{pola yang salah} -> {perbaikan pola}}*/

        public MainApp()
        {
            InitializeComponent();

            panelWords.Visible = false;
            panelTest.Visible = false;

            isMistaken = false;
            isPolaMistaken = false;

            filename = string.Empty;

            checkMenu.Enabled = false;

            listLog.AppendText("=> Pilih Menu File untuk memilih dokumen yang akan diuji\n");
            listLog.SelectionStart = listLog.Text.Length;
            listLog.ScrollToCaret();
        }

        /**********************************************Document****************************************************/
        private void uploadDocument_Click(object sender, EventArgs e)
        {
            DialogResult dialog = openFileDialog.ShowDialog();
            if (dialog == DialogResult.OK)
            {
                filename = openFileDialog.FileName;

                WordDocument wd = new WordDocument();
                wd.CheckDocument(filename);

                if (wd.isDocument() == true)
                {
                    textOutput.Clear();

                    listMistakenWords.Items.Clear();
                    listFixedWords.Items.Clear();

                    mistakenWords.Clear();
                    mistakenWordsPos.Clear();
                    fixedWords.Clear();

                    mistakenPola.Clear();
                    mistakenPolaPos.Clear();
                    fixedPola.Clear();

                    panelWords.Visible = false;
                    panelTest.Visible = false;

                    sentence.Clear();

                    breakDocument();
                    showAllWords();
                }
                else
                {
                    MessageBox.Show("Dokumen yang anda masukkan harus berupa .doc atau .docx!","Peringatan");
                }
            }
        }

        public void breakDocument()
        {
            string paragraphText = string.Empty;

            if (filename != string.Empty)
            {
                object missing = System.Type.Missing;
                Microsoft.Office.Interop.Word.Application word = new Microsoft.Office.Interop.Word.Application();
                Microsoft.Office.Interop.Word.Document docs = word.Documents.Open(filename,
                    ref missing, ref missing, ref missing,
                    ref missing, ref missing, ref missing,
                    ref missing, ref missing, ref missing,
                    ref missing, ref missing, ref missing,
                    ref missing, ref missing, ref missing);

                for (int i = 0; i < docs.Paragraphs.Count; i++)
                {
                    paragraphText += docs.Paragraphs[i + 1].Range.Text + "\n";
                }

                ((Microsoft.Office.Interop.Word._Document)docs).Close();
                ((Microsoft.Office.Interop.Word._Application)word).Quit();
            }

            string sentencePattern = "(\\.+\\s)";
            string[] snt = Regex.Split(paragraphText, sentencePattern);
            Array.Resize(ref snt, snt.Length - 1);

            for (int i = 0; i < snt.Length; i++)
            {
                if (!Regex.IsMatch(snt[i], sentencePattern))
                {
                    List<string> perWord = new List<string>();
                    string[] wrd = snt[i].Split(' ');

                    for (int j = 0; j < wrd.Length; j++)
                    {
                        if (wrd[j].Contains(","))
                        {
                            perWord.Add(wrd[j].TrimEnd(','));
                            perWord.Add(",");
                        }
                        else
                        {
                            perWord.Add(wrd[j]);
                        }
                    }

                    perWord.Add(".");
                    sentence.Add(perWord);
                }
            }

            Array.Clear(snt, 0, snt.Length);
        }

        private void showAllWords()
        {
            textOutput.Clear();
            for (int i = 0; i < sentence.Count; i++)
            {
                string txt = string.Empty;
                for (int j = 0; j < sentence[i].Count - 1; j++)
                {
                    if (sentence[i][j].Contains(","))
                    {
                        txt = txt.TrimEnd(' ');
                        txt += ", ";
                    }
                    else
                    {
                        txt += sentence[i][j] + " ";
                    }
                }

                txt = txt.TrimEnd(' ') + sentence[i][sentence[i].Count - 1] + " ";
                textOutput.AppendText(txt);
            }

            textOutput.Text = textOutput.Text.TrimEnd(' ');

            fileMenu.Enabled = true;
            checkMenu.Enabled = true;
            checkWords.Enabled = true;
            checkStructure.Enabled = true;
        }
        /**************************************************************************************************/

        /*************************************************Words*************************************************/
        private void checkWords_Click(object sender, EventArgs e)
        {
            isMistaken = false;
            isPolaMistaken = false;

            listMistakenWords.Items.Clear();
            listFixedWords.Items.Clear();

            mistakenWords.Clear();
            mistakenWordsPos.Clear();
            fixedWords.Clear();

            mistakenPola.Clear();
            mistakenPolaPos.Clear();
            fixedPola.Clear();

            panelWords.Visible = false;
            panelTest.Visible = false;

            Words words = new Words();

            for (int i = 0; i < sentence.Count; i++)
            {
                for (int j = 0; j < sentence[i].Count; j++)
                {
                    if (words.GroupingWords(sentence[i][j]) == "X" && sentence[i][j] != ".")
                    {
                        mistakenWords.Add(sentence[i][j]);
                        mistakenWordsPos.Add(i);
                        isMistaken = true;
                    }
                }
            }

            listLog.AppendText("Hasil pemeriksaan kata:\n=======================\n");
            listLog.SelectionStart = listLog.Text.Length;
            listLog.ScrollToCaret();

            if (checkTag() == true)
            {
                fixingWords();
                showFixedWords();
            }
            else
            {
                MessageBox.Show("Tidak terdapat kata yang keliru","Pemberitahuan");
                selectWord.Enabled = false;
            }
        }

        private bool checkTag()
        {
            bool check = false;
            if (isMistaken == true)
            {
                check = true;
            }

            return check;
        }

        private void fixingWords()
        {
            XmlDocument xmlKamus = new XmlDocument();
            XmlNodeList node = xmlKamus.GetElementsByTagName("kata");
            xmlKamus.Load(@"kamus.xml");

            JWD jwd = new JWD();
            int minDistance = 0;

            for (int i = 0; i < mistakenWords.Count; i++)
            {
                List<string> fWord = new List<string>();
                Dictionary<string, int> dict = new Dictionary<string, int>();
                minDistance = mistakenWords[i].Length;

                foreach (XmlNode ap in node)
                {
                    if (ap.ChildNodes[1].InnerText != string.Empty)
                    {
                        string String1 = mistakenWords[i];
                        string String2 = ap.ChildNodes[1].InnerText;
                        float ans = jwd.GetDistance(String1, String2);
                        float formatPercents = ans * 100;
                        double formattedAns = Math.Round(formatPercents, 0);

                        try
                        {
                            dict.Add(ap.ChildNodes[1].InnerText, (int)formattedAns);
                        }
                        catch (Exception e)
                        {

                        }

                        if (minDistance < (int)formattedAns)
                        {
                            minDistance = (int)formattedAns;
                        }
                    }
                }

                foreach (var pair in dict)
                {
                    if (pair.Value == minDistance)
                    {
                        fWord.Add(pair.Key);
                    }
                }

                fixedWords.Add(fWord);
            }
        }

        public void showFixedWords()
        {
            listLog.AppendText("Terdapat beberapa kesalahan kata:\n");
            listLog.SelectionStart = listLog.Text.Length;
            listLog.ScrollToCaret();

            textOutput.Clear();
            for (int i = 0; i < sentence.Count; i++)
            {
                string txt = string.Empty;
                for (int j = 0; j < sentence[i].Count - 1; j++)
                {
                    if (sentence[i][j].Contains(","))
                    {
                        txt = txt.TrimEnd(' ');
                        txt += ", ";
                    }
                    else
                    {
                        txt += sentence[i][j] + " ";
                    }
                }

                txt = txt.TrimEnd(' ') + sentence[i][sentence[i].Count - 1] + " ";
                textOutput.AppendText(txt);
            }

            textOutput.Text = textOutput.Text.TrimEnd(' ');

            int index = 0;
            for (int k = 0; k < mistakenWords.Count; k++)
            {
                while (index < textOutput.Text.LastIndexOf(mistakenWords[k]))
                {
                    textOutput.Find(mistakenWords[k], index, textOutput.TextLength, RichTextBoxFinds.None);
                    textOutput.SelectionColor = Color.Red;
                    index = textOutput.Text.IndexOf(mistakenWords[k], index) + 1;
                }
            }

            for (int l = 0; l < mistakenWords.Count; l++)
            {
                listMistakenWords.Items.Add(mistakenWords[l]);
                listLog.AppendText("=> " + mistakenWords[l]+"\n");
                listLog.SelectionStart = listLog.Text.Length;
                listLog.ScrollToCaret();
            }


            panelWords.Visible = true;
            panelTest.Visible = false;

            selectWord.Enabled = true;
            listMistakenWords.Enabled = true;
            listFixedWords.Enabled = true;

            fileMenu.Enabled = true;
            checkMenu.Enabled = true;
            checkWords.Enabled = true;
            checkStructure.Enabled = true;
        }
        /**************************************************************************************************/

        /***********************************************Select Word***************************************************/
        private void selectWord_Click(object sender, EventArgs e)
        {
            if (checkSelectedWord() == true)
            {
                changeWord();
            }
            else
            {
                MessageBox.Show("Pilih kata yang akan diperbaiki terlebih dahulu!","Peringatan");
            }
        }

        private bool checkSelectedWord()
        {
            bool selected = false;
            if (listFixedWords.SelectedIndex != -1)
            {
                selected = true;
            }
            return selected;
        }

        private void changeWord()
        {
            int index = listMistakenWords.SelectedIndex;
            int pos = mistakenWordsPos[index];

            for (int i = 0; i < sentence[pos].Count; i++)
            {
                if (sentence[pos][i].ToLower() == listMistakenWords.Text.ToLower())
                {
                    listLog.AppendText("Kata '" + sentence[pos][i] + "' pada kalimat ke-" + (pos + 1) + " diganti menjadi '" + listFixedWords.Text + "'\n");
                    listLog.SelectionStart = listLog.Text.Length;
                    listLog.ScrollToCaret();
                    sentence[pos][i] = listFixedWords.Text;
                    break;
                }
            }
        }
        /**************************************************************************************************/

        /***********************************************Sentences Structure***************************************************/
        private void checkStructure_Click(object sender, EventArgs e)
        {
            isMistaken = false;
            isPolaMistaken = false;

            textOutput.Clear();

            pola.Clear();
            mistakenPola.Clear();
            mistakenPolaPos.Clear();
            fixedPola.Clear();

            panelWords.Visible = false;
            panelTest.Visible = false;

            arrangeWordsClass();

            finalResult.Clear();
            if (checkPola() == true)
            {
                fixingPola();
                showFixedPola();
            }
            else
            {
                MessageBox.Show("Tidak terdapat pola kalimat yang keliru","Pemberitahuan");
            }
        }

        private void arrangeWordsClass()
        {
            Words words = new Words();

            for (int i = 0; i < sentence.Count; i++)
            {
                string strPola = string.Empty;
                for (int j = 0; j < sentence[i].Count; j++)
                {
                    strPola += words.GroupingWords(sentence[i][j]) + " ";
                }

                pola.Add(strPola);
            }
        }

        private bool checkPola()
        {
            CYK cyk = new CYK();
            XmlDocument xmlKamus = new XmlDocument();
            XmlNodeList node = xmlKamus.GetElementsByTagName("pola");
            xmlKamus.Load(@"pola.xml");

            for (int k = 0; k < pola.Count; k++)
            {
                cyk.SetString(pola[k]);
                cyk.RunCYK();

                if (cyk.GetLastCell() == "-")
                {
                    mistakenPola.Add(pola[k]);
                    mistakenPolaPos.Add(k);
                    isPolaMistaken = true;
                }
            }

            return isPolaMistaken;
        }

        private void fixingPola()
        {
            XmlDocument xmlKamus = new XmlDocument();
            XmlNodeList node = xmlKamus.GetElementsByTagName("pola");
            xmlKamus.Load(@"pola.xml");

            Levenshtein levPola = new Levenshtein();

            for (int i = 0; i < mistakenPola.Count; i++)
            {
                List<string> perPola = new List<string>();
                Dictionary<string, int> dict = new Dictionary<string, int>();
                int minDistance = mistakenPola[i].Length;

                foreach (XmlNode p in node)
                {
                    if (p.InnerText != string.Empty)
                    {
                        levPola.SetFirstString(p.InnerText);
                        levPola.SetSecondString(mistakenPola[i]);
                        levPola.RunLevenshtein();

                        if (minDistance > levPola.GetEditDistance())
                        {
                            dict.Add(p.InnerText, levPola.GetEditDistance());
                            minDistance = levPola.GetEditDistance();
                        }
                    }
                }

                foreach (var pair in dict)
                {
                    if (pair.Value == minDistance)
                    {
                        perPola.Add(pair.Key);
                    }
                }

                fixedPola.Add(perPola);
            }
        }

        private void showFixedPola()
        {
            textOutput.Clear();
            for (int i = 0; i < sentence.Count; i++)
            {
                string txt = string.Empty;
                for (int j = 0; j < sentence[i].Count - 1; j++)
                {
                    if (sentence[i][j].Contains(","))
                    {
                        txt = txt.TrimEnd(' ');
                        txt += ", ";
                    }
                    else
                    {
                        txt += sentence[i][j] + " ";
                    }
                }

                txt = txt.TrimEnd(' ') + sentence[i][sentence[i].Count - 1] + " ";
                textOutput.AppendText(txt);
            }

            textOutput.Text = textOutput.Text.TrimEnd(' ');

            List<int> idm = new List<int>();
            for (int m = 0; m < mistakenPola.Count; m++)
            {
                idm.Add(mistakenPolaPos[m]);
            }

            for (int n = 0; n < pola.Count; n++)
            {
                string rest = string.Empty;
                finalResult.Text += "======================Kalimat ke-" + (n + 1) + "======================\n";

                for (int q = 0; q < sentence[n].Count; q++)
                {
                    rest += sentence[n][q] + " ";
                }
                finalResult.Text += rest.TrimEnd(' ') + "\n";

                finalResult.Text += "Pola kalimat: " + pola[n] + "\n";
                if (idm.Contains(n))
                {
                    string que = string.Empty;
                    for (int p = 0; p < fixedPola[n].Count; p++)
                    {
                        que += fixedPola[n][p] + " ";
                    }

                    finalResult.Text += "Saran perbaikan: " + que.TrimEnd(' ') + "\n";
                }
                else
                {
                    finalResult.Text += "Tidak ada saran perbaikan\n";
                }
            }

            panelWords.Visible = false;
            panelTest.Visible = true;
        }
        /******************************/

        /***** List Words Status *****/
        private void listMistakenWords_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listMistakenWords.SelectedIndex != -1)
            {
                listFixedWords.Items.Clear();
                int index = listMistakenWords.SelectedIndex;

                for (int i = 0; i < fixedWords[index].Count; i++)
                {
                    listFixedWords.Items.Add(fixedWords[index][i]);
                }
            }
        }

        /***********************************/

        /* Fungsionalitas 
         * --------------
         * checkDocument()
         * checkWords()
         * fixingWords() <-- optional but important
         * selectWord()
         * checkSentencesStructure()
         * selectStructure()
         * fixSentencesStructure()
         */

        /*
        private void checkSentencesStructure()
        {
            CYK cyk = new CYK();

            Levenshtein lvp = new Levenshtein();
            XmlDocument xmlKamus = new XmlDocument();
            XmlNodeList node = xmlKamus.GetElementsByTagName("pola");
            xmlKamus.Load(@"pola.xml");

            for (int k = 0; k < pola.Count; k++)
            {
                cyk.SetString(pola[k]);
                cyk.RunCYK();

                if (cyk.GetLastCell() == "-")
                {
                    bool flag = false;
                    bool found = false;
                    foreach (XmlNode p in node)
                    {
                        lvp.SetFirstString(pola[k].TrimEnd(' '));
                        lvp.SetSecondString(p.InnerText.TrimEnd(' '));
                        lvp.RunLevenshtein();

                        if (lvp.GetEditDistance() == 0)
                        {
                            flag = true;
                            found = true;
                        }
                    }

                    if (!found)
                    {
                        mistakenPola.Add(cyk.GetString());
                        mistakenPolaPos.Add(k);
                        isPolaMistaken = true;
                    }

                    if (flag) continue;
                }
            }
        }
        private void rebuildSentence(string pola1, string pola2)
        {
            string[] oldPola = pola1.Split(' ');
            string[] newPola = pola2.Split(' ');

            Queue<string> queueSent = new Queue<string>();
            Queue<string> queuePola = new Queue<string>();

            Queue<string> tempQSent = new Queue<string>();
            Queue<string> tempQPola = new Queue<string>();

            List<string> resSent = new List<string>();
            List<string> resPola = new List<string>();

            string res = string.Empty;
            
            for (int i = 0; i < sentence[mistakenPolaPos[listMistakenPola.SelectedIndex]].Count; i++)
            {
                queueSent.Enqueue(sentence[mistakenPolaPos[listMistakenPola.SelectedIndex]][i]);
                queuePola.Enqueue(oldPola[i]);

                //textResult.AppendText(oldPola[i] + " - " + sentence[mistakenPolaPos[listMistakenPola.SelectedIndex]][i] + "\n");
            }
            
            for (int j = 0; j < newPola.Length-1; j++)
            {
                bool found = false;
                while (queuePola.Count > 0)
                {
                    if (newPola[j] == queuePola.Peek() && found == false)
                    {
                        resPola.Add(queuePola.Peek());
                        resSent.Add(queueSent.Peek());
                        found = true;
                    }
                    else
                    {
                        tempQPola.Enqueue(queuePola.Peek());
                        tempQSent.Enqueue(queueSent.Peek());
                    }

                    queuePola.Dequeue();
                    queueSent.Dequeue();
                }

                if (found == false)
                {
                    resPola.Add(newPola[j]);
                    resSent.Add("[" + newPola[j] + "]");
                }

                queuePola.Clear();
                queueSent.Clear();

                queuePola = new Queue<string>(tempQPola.ToArray());
                queueSent = new Queue<string>(tempQSent.ToArray());

                tempQPola.Clear();
                tempQSent.Clear();
            }

            resPola.Add("Z");
            resSent.Add(".");

            sentence[mistakenPolaPos[listMistakenPola.SelectedIndex]].Clear();

            string str = string.Empty;
            for (int k = 0; k < resSent.Count; k++)
            {
                str += resSent[k] + " ";
                sentence[mistakenPolaPos[listMistakenPola.SelectedIndex]].Add(resSent[k]);
            }

            LogText(str.TrimEnd(' '));
        }

        private void selectStructure()
        {
            //textResult.Clear();
        }
        /*************** End All About Pola ***************/
        private void exitSimulator_Click(object sender, EventArgs e)
        {
            if (showQuestion() == true)
            {
                quitSimulator();
            }
            else
            {
                backToMenu();
            }
        }

        private bool showQuestion()
        {
            bool stat = false;
            DialogResult dr = MessageBox.Show("Anda yakin ingin keluar dari simulator ini?", "Peringatan", MessageBoxButtons.YesNo);
            if (dr == DialogResult.Yes)
            {
                stat = true;
            }

            return stat;
        }

        private void backToMenu()
        {

        }

        private void quitSimulator()
        {
            Application.Exit();
        }

        private void checkMenu_Click(object sender, EventArgs e)
        {

        }

        private void fileMenu_Click(object sender, EventArgs e)
        {

        }
    }
}
