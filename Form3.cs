using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace project_network_S_DES
{
    public partial class Form3 : Form
    {
        
        string[][] Table = new string[16][];
        string[][] MS = new string[2][];
        string[][] BinToDe = new string[16][];
        string[][] Addtion = new string[16][];
        string[][] Multi = new string[16][];
        int[][] GM = new int[2][];
        string[][] myM = new string[2][];
        string[][] Index = new string[6][];
        int dec = 1;
        Timer tt = new Timer();
        int ct = 0;
        string v1, v2;
        string w0 = "";
        string w1 = "";
        string w2 = "";
        string w3 = "";
        string w4 = "";
        string w5 = "";
        string k0 = "";
        string k1 = "";
        string k2 = "";
        string s1 = "";
        string s2 = "";
        string s3 = "";
        string s4 = "";
        string step1 = "";
        string goodn = "";
        public Form3()
        {
            tt.Tick += Tt_Tick;
            tt.Start();
            InitializeComponent();

        }
        string decryption(string ctext, string k)
        {
            
            dec = 0;
            goodn = "";
            for (int h = 0; h < ctext.Length; h += 16)
            {
                step1 = "";
                for (int l = h; l < h + 16; l++)
                {
                    step1 = step1 + ctext[l];
                }
                key = k;
                keygeneration();

                step1 = XoR(step1, k2);

                devideTo4();
                step1 = s1 + s4 + s3 + s2;

                s1 = searchinverse(s1);
                s2 = searchinverse(s2);
                s3 = searchinverse(s3);
                s4 = searchinverse(s4);
                step1 = s1 + s4 + s3 + s2;

                step1 = XoR(step1, k1);
                devideTo4();
                step1 = s1 + s4 + s3 + s2;
                devideTo4();
                SetMS();
                devideTo4();
                s1 = searchinverse(s1);
                s2 = searchinverse(s2);
                s3 = searchinverse(s3);
                s4 = searchinverse(s4);
                step1 = s1 + s4 + s3 + s2;
                step1 = XoR(step1, k0);
                step1 = step1.Substring(8, 8);
                step1 = BinaryToString(step1);
                goodn += step1;
            }
            return goodn;
        }
        private void Tt_Tick(object sender, EventArgs e)
        {
            ct++;
            if (ct % 10 == 0)
            {
                richTextBox1.Text = " ";
                StreamReader SR = new StreamReader("Text.txt");

                while (!SR.EndOfStream)
                {
                    string line = SR.ReadLine();
                    string[] split = line.Split(',');
                    if (split[0] == "1")
                        richTextBox1.Text += "\x0A" + "Friend: " + decryption(split[1], split[2]);
                    if (split[0] == "2")
                        richTextBox1.Text += "\x0A" + "Me: " + decryption(split[1], split[2]);

                }
                SR.Close();
            }



        }
        private void Form3_Load(object sender, EventArgs e)
        {

        }
        public static byte[] ConvertToByteArray(string str, Encoding encoding)
        {
            return encoding.GetBytes(str);
        }
        public static String ToBinary(Byte[] data)
        {
            return string.Join("00000000", data.Select(byt => Convert.ToString(byt, 2).PadLeft(8, '0')));
        }
        private string makeit16bit(string pt)
        {
            string temp0 = "00000000";
            string all = ToBinary(ConvertToByteArray(pt, Encoding.ASCII));
            all = temp0 + all;
            return all;
        }
        public string XoR(string S1, string S2)
        {
            string Res = "";
            for (int i = 0; i < S1.Length; i++)
            {
                if (S1[i] == S2[i])
                {
                    Res += 0;
                }
                else
                {
                    Res += 1;
                }
            }

            return Res;
        }
        void SetGM()//Set Me Matrix
        {
           
            GM[0] = new int[2] { 1, 4 };
            GM[1] = new int[2] { 4, 1 };
        }
        void SetMulti()//Multiplication Table
        {
            Multi[0] = new string[16] { "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0" };
            Multi[1] = new string[16] { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9", "a", "b", "c", "d", "e", "f" };
            Multi[2] = new string[16] { "0", "2", "4", "6", "8", "a", "c", "e", "3", "1", "7", "5", "b", "9", "f", "d" };
            Multi[3] = new string[16] { "0", "3", "6", "5", "c", "f", "a", "9", "b", "8", "d", "e", "7", "4", "1", "2" };
            Multi[4] = new string[16] { "0", "4", "8", "c", "3", "7", "b", "f", "6", "2", "e", "a", "5", "1", "d", "9" };
            Multi[5] = new string[16] { "0", "5", "a", "f", "7", "2", "d", "8", "e", "b", "4", "1", "9", "c", "3", "6" };
            Multi[6] = new string[16] { "0", "6", "c", "a", "b", "d", "7", "1", "5", "3", "9", "f", "e", "8", "2", "4" };
            Multi[7] = new string[16] { "0", "7", "e", "9", "f", "8", "1", "6", "d", "a", "3", "4", "2", "5", "c", "b" };
            Multi[8] = new string[16] { "0", "8", "3", "b", "6", "e", "5", "d", "c", "4", "f", "7", "a", "2", "9", "1" };
            Multi[9] = new string[16] { "0", "9", "1", "8", "2", "b", "3", "a", "4", "d", "5", "c", "6", "f", "7", "e" };
            Multi[10] = new string[16] { "0", "a", "7", "d", "e", "4", "9", "3", "f", "5", "8", "2", "1", "b", "6", "c" };
            Multi[11] = new string[16] { "0", "b", "5", "e", "a", "1", "f", "4", "7", "c", "2", "9", "d", "6", "8", "3" };
            Multi[12] = new string[16] { "0", "c", "b", "7", "5", "9", "e", "2", "a", "6", "1", "d", "f", "3", "4", "8" };
            Multi[13] = new string[16] { "0", "d", "9", "4", "1", "c", "8", "5", "2", "f", "b", "6", "3", "e", "a", "7" };
            Multi[14] = new string[16] { "0", "e", "f", "1", "d", "3", "2", "c", "9", "7", "6", "8", "4", "a", "b", "5" };
            Multi[15] = new string[16] { "0", "f", "d", "2", "9", "6", "4", "b", "1", "e", "c", "3", "8", "7", "5", "a" };
        }
        void SetAddtion()
        {
            Addtion[0] = new string[16] { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9", "a", "b", "c", "d", "e", "f" };
            Addtion[1] = new string[16] { "1", "0", "3", "2", "5", "4", "7", "6", "9", "8", "b", "a", "d", "c", "f", "e" };
            Addtion[2] = new string[16] { "2", "3", "0", "1", "6", "7", "4", "5", "a", "b", "8", "9", "e", "f", "c", "d" };
            Addtion[3] = new string[16] { "3", "2", "1", "0", "7", "6", "5", "4", "b", "a", "9", "8", "f", "e", "d", "c" };
            Addtion[4] = new string[16] { "4", "5", "6", "7", "0", "1", "2", "3", "c", "d", "e", "f", "8", "9", "a", "b" };
            Addtion[5] = new string[16] { "5", "4", "7", "6", "1", "0", "3", "2", "d", "c", "f", "e", "9", "8", "b", "a" };
            Addtion[6] = new string[16] { "6", "7", "4", "5", "2", "3", "0", "1", "e", "f", "c", "d", "a", "b", "8", "9" };
            Addtion[7] = new string[16] { "7", "6", "5", "4", "3", "2", "1", "0", "f", "e", "d", "c", "b", "a", "9", "8" };
            Addtion[8] = new string[16] { "8", "9", "a", "b", "c", "d", "e", "f", "0", "1", "2", "3", "4", "5", "6", "7" };
            Addtion[9] = new string[16] { "9", "8", "b", "a", "d", "c", "f", "e", "1", "0", "3", "2", "5", "4", "7", "6" };
            Addtion[10] = new string[16] { "a", "b", "8", "9", "e", "f", "c", "d", "2", "3", "0", "1", "6", "7", "4", "5" };
            Addtion[11] = new string[16] { "b", "a", "9", "8", "f", "e", "d", "c", "3", "2", "1", "0", "7", "6", "5", "4" };
            Addtion[12] = new string[16] { "c", "d", "e", "f", "8", "9", "a", "b", "4", "5", "6", "7", "0", "1", "2", "3" };
            Addtion[13] = new string[16] { "d", "c", "f", "e", "9", "8", "b", "a", "5", "4", "7", "6", "1", "0", "3", "2" };
            Addtion[14] = new string[16] { "e", "f", "c", "d", "a", "b", "8", "9", "6", "7", "4", "5", "2", "3", "0", "1" };
            Addtion[15] = new string[16] { "f", "e", "d", "c", "b", "a", "9", "8", "7", "6", "5", "4", "3", "2", "1", "0" };
        }
        void SetTable()//SubNib Table
        {
            Table[0] = new string[2] { "0000", "1001" };
            Table[1] = new string[2] { "0001", "0100" };

            Table[2] = new string[2] { "0010", "1010" };
            Table[3] = new string[2] { "0011", "1011" };
            Table[4] = new string[2] { "0100", "1101" };
            Table[5] = new string[2] { "0101", "0001" };
            Table[6] = new string[2] { "0110", "1000" };
            Table[7] = new string[2] { "0111", "0101" };

            Table[8] = new string[2] { "1000", "0110" };
            Table[9] = new string[2] { "1001", "0010" };
            Table[10] = new string[2] { "1010", "0000" };
            Table[11] = new string[2] { "1011", "0011" };
            Table[12] = new string[2] { "1100", "1100" };
            Table[13] = new string[2] { "1101", "1110" };
            Table[14] = new string[2] { "1110", "1111" };
            Table[15] = new string[2] { "1111", "0111" };

        }
        void SetBinToDe()//Bin = Hex
        {
            BinToDe[0] = new string[2] { "0000", "0" };
            BinToDe[1] = new string[2] { "0001", "1" };
            BinToDe[2] = new string[2] { "0010", "2" };
            BinToDe[3] = new string[2] { "0011", "3" };
            BinToDe[4] = new string[2] { "0100", "4" };
            BinToDe[5] = new string[2] { "0101", "5" };
            BinToDe[6] = new string[2] { "0110", "6" };
            BinToDe[7] = new string[2] { "0111", "7" };

            BinToDe[8] = new string[2] { "1000", "8" };
            BinToDe[9] = new string[2] { "1001", "9" };
            BinToDe[10] = new string[2] { "1010", "a" };
            BinToDe[11] = new string[2] { "1011", "b" };
            BinToDe[12] = new string[2] { "1100", "c" };
            BinToDe[13] = new string[2] { "1101", "d" };
            BinToDe[14] = new string[2] { "1110", "e" };
            BinToDe[15] = new string[2] { "1111", "f" };

        }
        string getBinn(string s)//return binary value
        {
            int v = 0;
            for (int i = 0; i < BinToDe.Count(); i++)
            {
                if (BinToDe[i][1] == s)
                {
                    return BinToDe[i][0];
                }
            }

            return null;
        }
        string getDes(string s)//return Hexdecimal value
        {
            int v = 0;
            for (int i = 0; i < BinToDe.Count(); i++)
            {
                if (BinToDe[i][0] == s)
                {
                    return BinToDe[i][1];
                }
            }

            return null;
        }
        public void setIndex()
        {
            Index[0] = new string[2] { "a", "10" };
            Index[1] = new string[2] { "b", "11" };
            Index[2] = new string[2] { "c", "12" };
            Index[3] = new string[2] { "d", "13" };
            Index[4] = new string[2] { "e", "14" };
            Index[5] = new string[2] { "f", "15" };
        }
        public int getIndex(string s)
        {
            int v = -1;
            for (int i = 0; i < Index.Count(); i++)
            {
                if (Index[i][0] == s)
                {
                    v = int.Parse(Index[i][1]);
                    break;

                }

            }
            return v;

        }
        void SetMS()
        {

            // mix columns 
            MS[0] = new string[2] { s1, s3 };
            MS[1] = new string[2] { s4, s2 };
            SetBinToDe();//Bin = Hex
            SetGM();//Set Me Matrix
            v1 = getDes(MS[0][0]);//return Hexdecimal value
            v2 = getDes(MS[0][1]);//return Hexdecimal value
            myM[0] = new string[2] { v1, v2 };
            v1 = getDes(MS[1][0]);
            v2 = getDes(MS[1][1]);

            myM[1] = new string[2] { v1, v2 };


            //MessageBox.Show(myM[0][0] + "      " + myM[0][ 1] + " \n" + myM[1][0] + "      " + myM[1][1] + " \n");
            SetMulti();//Multiplication Table
            SetAddtion();// Addition Table
            setIndex();
            MultiMatr();//(result of mix columns )1111 
                        // 

        }
        int IsNum(string s)
        {
            if (s[0] >= '0' && s[0] <= '9') { return 1; }

            return 0;
        }
        string sbox(string ham1, string ham2, int a, int b)
        {
            int k;
            int k2;
            string s00 = "";
            string s00p1 = "";
            string s00p2 = "";
            string s01 = "";
            string s10 = "";
            string s11 = "";
            int r;
            int c;
            //s00
            //check first half multi
            k = IsNum(ham1);
            if (k == 1)
            {
                s00p1 = Multi[a][int.Parse(ham1)];
            }
            else
            {
                s00p1 = Multi[a][getIndex(ham1)];
            }
            // check second half multi
            k = IsNum(ham2);
            if (k == 1)
            {
                s00p2 = Multi[b][int.Parse(ham2)];
            }
            else
            {
                //MessageBox.Show(ham2);
                s00p2 = Multi[b][getIndex(ham2)];
            }

            //check result of first half and second to addition
            k = IsNum(s00p1);
            k2 = IsNum(s00p2);
            if (k == 1 && k2 == 1)
            {
                s00 = Addtion[int.Parse(s00p1)][int.Parse(s00p2)];
            }
            else if ((k == 0 && k2 == 1))
            {
                s00 = Addtion[getIndex(s00p1)][int.Parse(s00p2)];
            }
            else if ((k == 1 && k2 == 0))
            {
                s00 = Addtion[int.Parse(s00p1)][getIndex(s00p2)];
            }
            else if ((k == 0 && k2 == 0))
            {
                s00 = Addtion[getIndex(s00p1)][getIndex(s00p2)];
            }
            return s00;
        }
        void MultiMatr()//(result of mix columns )
        {
            int k;
            int k2;
            string s00 = "";
            string s00p1 = "";
            string s00p2 = "";
            string s01 = "";
            string s10 = "";
            string s11 = "";

            //MessageBox.Show(myM[0][0] + myM[1][0] + myM[0][1] + myM[1][1]);
            s00 = sbox(myM[0][0], myM[1][0], 1, 0);
            s01 = sbox(myM[0][1], myM[1][1], 1, 0);
            s10 = sbox(myM[0][0], myM[1][0], 0, 1);
            s11 = sbox(myM[0][1], myM[1][1], 0, 1);

            step1 = getBinn(s00) + getBinn(s10) + getBinn(s01) + getBinn(s11);
            if (dec == 1)
                richTextBox2.Text += "mix columns " + s00 + s10 + s01 + s11 + "\n" + step1 + "\n";




        }
        public string searchW(string iss)//get Nibble Substitution (S-Box) value
        {
            string ooP = "";
            for (int i = 0; i < Table.Length; i++)
            {
                if (Table[i][0] == iss)
                {
                    ooP = Table[i][1];
                    return ooP;
                }
            }
            return null;
        }
        public string searchinverse(string ss)//get Nibble Substitution (S-Box) value
        {
            string oP = "";
            for (int i = 0; i < Table.Length; i++)
            {
                if (Table[i][1] == ss)
                {
                    oP = Table[i][0];
                    return oP;
                }
            }
            return null;
        }
        public void keygeneration()
        {
            SetTable();
            string temp = "";
            string oldtemp1 = "";
            string oldtemp2 = "";
            w1 = "";
            w0 = "";


            for (int j = 0; j < 8; j++)
            {
                w0 = w0 + key[j];
            }

            for (int j = 8; j < 16; j++)
            {
                w1 = w1 + key[j];
            }

            //rotnib w1
            for (int i = 0; i < w1.Length; i++)
            {
                if (i >= (w1.Length / 2))
                {

                    oldtemp1 += w1[i];
                }
                else
                {
                    oldtemp2 += w1[i];
                }
            }


            temp = searchW(oldtemp1) + searchW(oldtemp2);


            w2 = XoR(XoR(w0, "10000000"), temp);
            w3 = XoR(w1, w2);

            temp = "";
            oldtemp1 = "";
            oldtemp2 = "";
            for (int i = 0; i < w3.Length; i++)
            {
                if (i >= (w3.Length / 2))
                {

                    oldtemp1 += w3[i];
                }
                else
                {
                    oldtemp2 += w3[i];
                }
            }

            temp = searchW(oldtemp1) + searchW(oldtemp2);

            w4 = XoR(XoR(w2, "00110000"), temp);
            w5 = XoR(w3, w4);
            k0 = w0 + w1;
            k1 = w2 + w3;
            k2 = w4 + w5;
            if (dec == 1)
            {
                richTextBox2.Text += "w0= " + w0 + "\x0A" + "w1= " + w1 + "\x0A" + "w2= " + w2 + "\x0A" + "w3= " + w3 + "\x0A" + "w4= " + w4 + "\x0A" + "w5= " + w5 + "\x0A";
                richTextBox2.Text += "k0= " + k0 + "\x0A" + "k1= " + k1 + "\x0A" + "k2= " + k2 + "\x0A";
            }

        }
        void devideTo4()// S = S00,S10,S01,S11
        {
            s3 = "";
            s1 = "";
            s2 = "";
            s4 = "";
            for (int i = 0; i < step1.Length; i++)
            {
                if (i < 4)
                {
                    s1 += step1[i];
                }
                if (i >= 4 && i < 8)
                {
                    s2 += step1[i];
                }
                if (i >= 8 && i < 12)
                {
                    s3 += step1[i];
                }
                if (i >= 12 && i < 16)
                {
                    s4 += step1[i];
                }

            }

        }

        private string encryptionAES(string pt)
        {
            string all = makeit16bit(pt);
            keygeneration();
            string newall = "";
            string pt16 = "";
            string cipher = "";
            dec = 1;
            for (int i = 0; i < all.Length; i += 16)
            {
                s3 = "";
                s1 = "";
                s2 = "";
                s4 = "";
                pt16 = "";
                step1 = "";
                for (int k = i; k < i + 16; k++)
                {
                    pt16 = pt16 + all[k];
                }
                step1 = XoR(pt16, k0);
                if (dec == 1)
                    richTextBox2.Text += "P Xor K0= " + step1 + "\n";
                devideTo4();
                s1 = searchW(s1);
                s2 = searchW(s2);
                s3 = searchW(s3);
                s4 = searchW(s4);
                if (dec == 1)
                    richTextBox2.Text += "subnib " + s1 + s2 + s3 + s4 + "\n";
                SetMS();
                step1 = XoR(step1, k1);
                if (dec == 1)
                    richTextBox2.Text += "Xor k1= " + step1 + "\n";
                devideTo4();
                s1 = searchW(s1);
                s2 = searchW(s2);
                s3 = searchW(s3);
                s4 = searchW(s4);
                if (dec == 1)
                    richTextBox2.Text += "subnib " + s1 + s2 + s3 + s4 + "\n";
                step1 = s1 + s4 + s3 + s2;
                if (dec == 1)
                    richTextBox2.Text += "left shift= " + step1 + "\n";
                step1 = XoR(step1, k2);
                if (dec == 1)
                    richTextBox2.Text += "Xor k2 " + step1 + "\n";
                newall += step1;
            }


            return newall;
        }
        string key = "0100101011110101";
        private void button1_Click(object sender, EventArgs e)
        {

            key = textBox2.Text;
            StreamWriter SW = new StreamWriter("Text.txt", true);
            string plaintext = textBox1.Text;
            SW.WriteLine("2" + "," + encryptionAES(textBox1.Text) + "," + key);
            SW.Close();
            textBox1.Text = "";
        }
        public void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }
        private void richTextBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            StreamReader SR = new StreamReader("Text.txt");
            richTextBox1.Text = "";
            while (!SR.EndOfStream)
            {
                string line = SR.ReadLine();
                string[] split = line.Split(',');
                if (split[0] == "1")
                {

                    string ans = decryption(split[1], split[2]);
                    richTextBox1.Text += "\x0A" + "Me: " + ans;
                }



                if (split[0] == "2")
                    richTextBox1.Text += "\x0A" + "Friend: " + decryption(split[1], split[2]);

            }
            SR.Close();
        }

        public string BinaryToString(string binary)
        {
            if (string.IsNullOrEmpty(binary))
                throw new ArgumentNullException("binary");



            StringBuilder builder = new StringBuilder();
            for (int i = 0; i < binary.Length; i += 8)
            {
                string section = binary.Substring(i, 8);
                int ascii = 0;
                try
                {
                    ascii = Convert.ToInt32(section, 2);
                }
                catch
                {
                    throw new ArgumentException("Binary string contains invalid section: " + section, "binary");
                }
                builder.Append((char)ascii);
            }
            return builder.ToString();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
