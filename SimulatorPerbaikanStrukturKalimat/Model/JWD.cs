using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimulatorPerbaikanStrukturKalimat.Model
{
    class JWD
    {
        private String String1;
        private String String2;
        private float threshold;

        public int[] Matches(string String1, string String2)
        {
            String Max, Min;
            if (String1.Length > String2.Length)
            {
                Max = String1;
                Min = String2;
            }
            else
            {
                Max = String2;
                Min = String1;
            }

            var range = Math.Max(Max.Length / 2 - 1, 0);
            var matchIndexes = new int[Max.Length];

            for (var i = 0; i < matchIndexes.Length; i++)
                matchIndexes[i] = -1;

            var matchFlags = new bool[Max.Length];
            var matches = 0;

            for (var mi = 0; mi < Min.Length; mi++)
            {
                var c1 = Min[mi];
                for (int xi = Math.Max(mi - range, 0),
                    xn = Math.Min(mi + range + 1, Max.Length); xi < xn; xi++)
                {
                    if (matchFlags[xi] || c1 != Max[xi]) continue;
                    matchIndexes[mi] = xi;
                    matchFlags[xi] = true;
                    matches++;
                    break;
                }
            }

            var ms1 = new char[matches];
            var ms2 = new char[matches];

            for (int i = 0, Stringi = 0; i < Min.Length; i++)
            {
                if (matchIndexes[i] != -1)
                {
                    ms1[Stringi] = Min[i];
                    Stringi++;
                }
            }

            for (int i = 0, Stringi = 0; i < Max.Length; i++)
            {
                if (matchFlags[i])
                {
                    ms2[Stringi] = Max[i];
                    Stringi++;
                }
            }

            var transpotitions = ms1.Where((t, mi) => t != ms2[mi]).Count();

            var prefix = 0;
            for (var mi = 0; mi < Min.Length; mi++)
            {
                if (String1[mi] == String2[mi])
                {
                    prefix++;
                }
                else
                {
                    break;
                }
            }

            return new int[] { matches, transpotitions / 2, prefix, Max.Length };
        }

        public float GetDistance(string String1, string String2)
        {
            var mtp = Matches(String1, String2);
            var m = (float)mtp[0];

            if (m == 0)
                return 0f;

            float j = ((m / String1.Length + m / String2.Length + (m - mtp[1]) / m)) / 3;
            float jw = j < threshold ? j : j + Math.Min(0.1f, 1f / mtp[3]) * mtp[2] * (1 - j);

            return jw;
        }

        public float Threshold
        {
            get { return threshold; }
            set { this.threshold = value; }
        }
    }
}
