using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimulatorPerbaikanStrukturKalimat.Model
{
    class Levenshtein
    {
        private string FirstString;
        private string SecondString;
        private int EditDistance;

        public Levenshtein()
        {
            this.FirstString = string.Empty;
            this.SecondString = string.Empty;
            this.EditDistance = 0;
        }

        public void SetFirstString(string FirstString)
        {
            this.FirstString = " " + FirstString;
        }

        public void SetSecondString(string SecondString)
        {
            this.SecondString = " " + SecondString;
        }

        public void RunLevenshtein()
        {
            int[,] levi = new int[FirstString.Length, SecondString.Length];

            for (int i = 0; i < FirstString.Length; i++)
            {
                levi[i, 0] = i;
                for (int j = 0; j < SecondString.Length; j++)
                {
                    levi[0, j] = j;
                    if (i > 0 && j > 0)
                    {
                        if (FirstString[i] == SecondString[j])
                        {
                            levi[i, j] = levi[i - 1, j - 1];
                        }
                        else
                        {
                            levi[i, j] = GetMinInt(levi[i - 1, j] + 1, levi[i, j - 1] + 1, levi[i - 1, j - 1] + 1);
                        }
                    }
                }
            }

            EditDistance = levi[FirstString.Length - 1, SecondString.Length - 1];
        }

        private int GetMinInt(int cellTop, int cellLeft, int cellDiagonal)
        {
            int minInt = cellTop;
            if (cellLeft < minInt)
            {
                minInt = cellLeft;
            }
            else if (cellDiagonal < minInt)
            {
                minInt = cellDiagonal;
            }

            return minInt;
        }

        public int GetEditDistance()
        {
            return EditDistance;
        }
    }
}
