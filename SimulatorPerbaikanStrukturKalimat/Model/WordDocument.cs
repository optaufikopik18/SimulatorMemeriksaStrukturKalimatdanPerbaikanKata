using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Office.Interop.Word;

namespace SimulatorPerbaikanStrukturKalimat.Model
{
    class WordDocument
    {
        private bool isDoc;

        public WordDocument()
        {
            this.isDoc = false;
        }

        public void CheckDocument(string docPath)
        {
            if (docPath.Contains(".doc") && docPath.Contains(".docx"))
            {
                /* Jika file bukan berbentuk doc atau docx maka...*/
                isDoc = true;
            }
            else
            {
                /* Jika file berbentuk doc atau docx maka...*/
                isDoc = false;
            }
        }

        public bool isDocument()
        {
            return isDoc;
        }
    }
}
