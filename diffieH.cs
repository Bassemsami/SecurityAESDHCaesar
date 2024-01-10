using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project_network_S_DES
{
    class diffieH
    {
        public static int Q, A, Xa, Xb, Ya, Yb, Ka, Kb;
        public static string cip;

        public static int Power(int Mm)
        {
            int ans = Mm * Mm;
            return ans;
        }
        public static int ct;
        public static void CalD(int Bmod, int Amod, int d)
        {
            ct += ((Bmod - d) / Amod);
        }
        public static string GetBinC(int c)
        {
            char m = (char)1;
            string pb = "";
            for (int i = 7; i >= 0; i--)
            {
                int bit = c & ((m << i));
                if (bit != 0) { bit = 1; }
                pb += bit.ToString();
            }

            return pb;
        }

        static string ans;
        public static int getValue(string ss, int mb)
        {
            int cc = 1;
            ans = "";
            for (int i = 0; i < ss.Length; i++)
            {
                if (ss[i] == '1') { ans += "QM"; }
                if (ss[i] == '0') { ans += "Q"; };
            }
            for (int i = 0; i < ans.Length; i++)
            {
                if (ans[i] == 'Q') { cc = Power(cc); }
                if (ans[i] == 'M') { cc *= mb; }
                if (cc > Q) { cc = (cc % Q); }
            }
            return cc;
        }
        public static int binP;
        public static void Computing_public_keyA()
        {
            
            int Pow = int.Parse(GetBinC(Xa));
            binP = Pow;
            string pb = binP.ToString();
            Ya = getValue(pb, A);

        }
        public static void Computing_public_keyB()
        {
            
            int Pow = int.Parse(GetBinC(Xb));
            binP = Pow;
            string pb = binP.ToString();
            Yb = getValue(pb, A);

        }

        public static void Computing_shared_session_key_KA()
        {
            int Pow = int.Parse(GetBinC(Xa));
            binP = Pow;
            string pb = binP.ToString();
            Ka = getValue(pb, Yb);

        }
        public static void Computing_shared_session_key_KB()
        {
            
            int Pow = int.Parse(GetBinC(Xb));
            binP = Pow;
            string pb = binP.ToString();
            Kb = getValue(pb, Ya);

        }

        public static void startpoint(int q, int a, int xa, int xb)
        {
          
            Q = q;
            A = a;
            Xa = xa;
            Xb = xb;
            Computing_public_keyA();
            Computing_public_keyB();
            Computing_shared_session_key_KA();
            Computing_shared_session_key_KB();

        }
    }
}
