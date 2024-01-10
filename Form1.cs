using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace project_network_S_DES
{
    public partial class Form1 : Form
    {
        
        public static Form des = new Form2();
        public static Form des2 = new Form3();
        public static Form ceaser = new ceaser1();
        public static Form ceaser2 = new ceaser2();
        public static Form DH = new DiffieHelman();
        public Form1()
        {
          
            
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
           
            des.Show();
            des2.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ceaser.Show();
            ceaser2.Show();
            
            DH.Show();
            this.Hide();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
