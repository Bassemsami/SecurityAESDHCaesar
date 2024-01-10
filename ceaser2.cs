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
    public partial class ceaser2 : Form
    {
        List<char> x = "abcdefghijklmnopqrstuvwxyz".ToList();
        List<char> y = new List<char>();
        char c;
        int f;
        Timer tt = new Timer();
        int ct =0;
        public ceaser2()
        {
            tt.Tick += Tt_Tick;
            tt.Start();
            InitializeComponent();
            
        }

        private void Tt_Tick(object sender, EventArgs e)
        {
            ct++;
            if (ct % 10 == 0)
            {
                richTextBox1.Text = " ";
                StreamReader SR = new StreamReader("TextCeaser2.txt");

                while (!SR.EndOfStream)
                {
                    string line = SR.ReadLine();
                    string[] split = line.Split(',');
                    if (split[0] == "1")
                        richTextBox1.Text += "\x0A" + "Me: " + split[1];
                    if (split[0] == "2")
                        richTextBox1.Text += "\x0A" + "Friend: " + split[1];

                }
                SR.Close();
            }
        }

        private void button1_Click(object sender, EventArgs e)



        {
            string ci = "";
            y.Clear();
            int key = diffieH.Ka;


            for (int i = key; i < x.Count; i++)
            {
                y.Add(x[i]);
            }
            for (int i = 0; i < key; i++)
            {
                y.Add(x[i]);
            }
            for (int i = 0; i < textBox1.Text.Length; i++)
            {
                c = textBox1.Text[i];
                if (char.IsWhiteSpace(c))
                {
                    ci += c.ToString();
                }
                else if (c.ToString() == ".")
                {
                    ci += c.ToString();
                }
                else
                {
                    if (char.IsUpper(c))
                    {
                        c = char.ToLower(c);
                        f = 1;
                    }
                    for (int j = 0; j < x.Count(); j++)
                    {
                        if (c == x[j])
                        {
                            if (f == 1)
                            {
                                char c2 = y[j];
                                ci += char.ToUpper(c2).ToString();
                                f = 0;
                            }
                            else
                            {
                                ci += y[j].ToString();
                            }
                            break;
                        }
                    }
                }
            }
            StreamWriter SW = new StreamWriter("TextCeaser2.txt", true);
            string plaintext = textBox1.Text;
            SW.WriteLine("1" + "," + textBox1.Text + "," + key);
            SW.Close();
            richTextBox2.Text += "encr. " + ci + "\n";
            diffieH.cip = ci;
            textBox1.Text = "";

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)


        {
            int key = diffieH.Ka;
            string pt = "";
            y.Clear();
            for (int i = key; i < x.Count; i++)
            {
                y.Add(x[i]);
            }
            for (int i = 0; i < key; i++)
            {
                y.Add(x[i]);
            }
            for (int i = 0; i < diffieH.cip.Length; i++)
            {
                c = diffieH.cip[i];
                if (char.IsWhiteSpace(c))
                {
                    pt += c.ToString();
                }
                else if (c.ToString() == ".")
                {
                    pt += c.ToString();
                }
                else
                {
                    if (char.IsUpper(c))
                    {
                        c = char.ToLower(c);
                        f = 1;
                    }
                    for (int j = 0; j < y.Count(); j++)
                    {
                        if (c == y[j])
                        {
                            if (f == 1)
                            {
                                char c2 = x[j];
                                pt += char.ToUpper(c2).ToString();
                                f = 0;
                            }
                            else
                            {
                                pt += x[j].ToString();
                            }
                            break;
                        }
                    }
                }
            }
            richTextBox2.Text += "from encr. " + diffieH.cip + " to: " + pt + "\n";
            StreamWriter SW = new StreamWriter("TextCeaser2.txt", true);
            string plaintext = pt;
            SW.WriteLine("2" + "," + pt + "," + key);
            SW.Close();
            diffieH.cip = "";
            textBox1.Text = "";

        }
    }
}
