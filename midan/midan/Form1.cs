using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.IO;
using System.Net.Sockets;
using System.Net;

namespace midan
{
    public partial class Form1 : Form
    {
        

        public Form1()
        {
            InitializeComponent();
        }
        

        private void delay(int time)
        {
            for (int i = 0; i < time * 100000000; i++) ;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form1.ActiveForm.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            Form1.ActiveForm.Hide();
            Form2 F2 = new Form2();
            F2.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form1.ActiveForm.Hide();
            Form3 F3 = new Form3();
            F3.ShowDialog();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
