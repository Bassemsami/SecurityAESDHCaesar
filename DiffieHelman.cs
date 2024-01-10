using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace project_network_S_DES
{
    public partial class DiffieHelman : Form
    {


        public DiffieHelman()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            diffieH.startpoint(int.Parse(textBox1.Text), int.Parse(textBox2.Text), int.Parse(textBox3.Text), int.Parse(textBox4.Text));
            label5.Text += " \n" + "Ya = " + diffieH.Ya;
            label5.Text += " \n" + "Yb = " + diffieH.Yb;
           
            label5.Text += " \n" + "Ka = " + diffieH.Ka;
            label5.Text += " \n" + "Kb = " + diffieH.Kb;

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }


        private void label5_Click(object sender, EventArgs e)
        {

        }
    }
}
