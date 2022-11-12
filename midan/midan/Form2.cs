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
using System.Data.Sql;
using System.Data.SqlClient;

namespace midan
{
    public partial class Form2 : Form
    {
        SqlCommand cmd , cd;
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\user\Desktop\N-project\midan\midan\midnn.mdf;Integrated Security=True");

        SqlDataAdapter da;
        int idd = 1;
        int genr_per = 100;
        char Night_day = '0';
        char CLEAR_COUNTER = '0';
        char UP_down = '0';
        char CLOSE = '0';
        int prog_type = 2;
        decimal timee = 0;
        decimal num = 0;
        decimal timee1 = 0;
        decimal num1 = 0;
        int roun_level = 1;
        int coun_T1 = 0, coun_T2 = 0, coun_T3 = 0, coun_T4 = 0, coun_T5 = 0, coun_T6 = 0, coun_T7 = 0, coun_T8 = 0;

        public Form2()
        {
            InitializeComponent();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void delay(int time)
        {
            for (int i = 0; i < time * 100000000; i++) ;
        }

        void newMethod()
        {
            try
            {
                int x = 1;
                EndPoint endPoint = new IPEndPoint(IPAddress.Any, 8000);
                Socket serverSocket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
                serverSocket.Bind(endPoint);
                while (true)
                {
                    x = 1;

                    while (x > 0)
                    {
                        // conecting lable
                        if (genr_per == 0)
                        {
                            label1.BackColor = Color.LightSteelBlue;
                            label2.BackColor = Color.LightSteelBlue;
                            label3.BackColor = Color.LightSteelBlue;
                            label4.BackColor = Color.LightSteelBlue;
                            label5.BackColor = Color.LightSteelBlue;
                            label6.BackColor = Color.LightSteelBlue;
                            label7.BackColor = Color.LightSteelBlue;
                            label8.BackColor = Color.LightSteelBlue;
                            genr_per = 100;
                        }
                        genr_per++;

                        // strt comuni 
                        byte[] msgFromClient = new byte[4096];
                        int length = serverSocket.ReceiveFrom(msgFromClient, ref endPoint);
                        string msg = Encoding.ASCII.GetString(msgFromClient, 0, length);
                        /////////////////////     target 1
                        if (msg[0] == '1')
                        {
                            label1.BackColor = Color.Lime;
                            if (msg[1] == '0')
                                label23.Text = "up";
                            if (msg[2] == '0')
                                label23.Text = "down";
                            if (msg[3] >= '1' && roun_level == 1)
                            { coun_T1++; if (prog_type == 3) UP_down = '0'; }
                            if (msg[3] >= '2' && roun_level == 2)
                            { coun_T1++; if (prog_type == 3) UP_down = '0'; }
                            if (msg[3] == '3' && roun_level == 3)
                            { coun_T1++; if (prog_type == 3) UP_down = '0'; }
                            label9.Text = coun_T1.ToString();
                        }
                        /////////////////////     target 2
                        if (msg[0] == '2')
                        {
                            label2.BackColor = Color.Lime;
                            if (msg[1] == '0')
                                label24.Text = "up";
                            if (msg[2] == '0')
                                label24.Text = "down";
                            if (msg[3] >= '1' && roun_level == 1)
                            { coun_T2++; if (prog_type == 3) UP_down = '0'; }
                            if (msg[3] >= '2' && roun_level == 2)
                                coun_T2++;
                            if (msg[3] == '3' && roun_level == 3)
                                coun_T2++;
                            label10.Text = coun_T2.ToString();
                        }
                        /////////////////////     target 3
                        if (msg[0] == '3')
                        {
                            label3.BackColor = Color.Lime;
                            if (msg[1] == '0')
                                label25.Text = "up";
                            if (msg[2] == '0')
                                label25.Text = "down";
                            if (msg[3] >= '1' && roun_level == 1)
                            { coun_T3++; if (prog_type == 3) UP_down = '0'; }
                            if (msg[3] >= '2' && roun_level == 2)
                                coun_T3++;
                            if (msg[3] == '3' && roun_level == 3)
                                coun_T3++;
                            label11.Text = coun_T3.ToString();
                        }
                        /////////////////////     target 4
                        if (msg[0] == '4')
                        {
                            label4.BackColor = Color.Lime;
                            if (msg[1] == '0')
                                label26.Text = "up";
                            if (msg[2] == '0')
                                label26.Text = "down";
                            if (msg[3] >= '1' && roun_level == 1)
                            { coun_T4++; if (prog_type == 3) UP_down = '0'; }
                            if (msg[3] >= '2' && roun_level == 2)
                                coun_T4++;
                            if (msg[3] == '3' && roun_level == 3)
                                coun_T4++;
                            label12.Text = coun_T4.ToString();
                        }
                        /////////////////////     target 5
                        if (msg[0] == '5')
                        {
                            label8.BackColor = Color.Lime;
                            if (msg[1] == '0')
                                label27.Text = "up";
                            if (msg[2] == '0')
                                label27.Text = "down";
                            if (msg[3] >= '1' && roun_level == 1)
                            { coun_T5++; if (prog_type == 3) UP_down = '0'; }
                            if (msg[3] >= '2' && roun_level == 2)
                                coun_T5++;
                            if (msg[3] == '3' && roun_level == 3)
                                coun_T5++;
                            label13.Text = coun_T5.ToString();
                        }
                        /////////////////////     target 6
                        if (msg[0] == '6')
                        {
                            label7.BackColor = Color.Lime;
                            if (msg[1] == '0')
                                label28.Text = "up";
                            if (msg[2] == '0')
                                label28.Text = "down";
                            if (msg[3] >= '1' && roun_level == 1)
                            { coun_T6++; if (prog_type == 3) UP_down = '0'; }
                            if (msg[3] >= '2' && roun_level == 2)
                                coun_T6++;
                            if (msg[3] == '3' && roun_level == 3)
                                coun_T6++;
                            label14.Text = coun_T6.ToString();
                        }
                        /////////////////////     target 7
                        if (msg[0] == '7')
                        {
                            label6.BackColor = Color.Lime;
                            if (msg[1] == '0')
                                label29.Text = "up";
                            if (msg[2] == '0')
                                label29.Text = "down";
                            if (msg[3] >= '1' && roun_level == 1)
                            { coun_T7++; if (prog_type == 3) UP_down = '0'; }
                            if (msg[3] >= '2' && roun_level == 2)
                                coun_T7++;
                            if (msg[3] == '3' && roun_level == 3)
                                coun_T7++;
                            label15.Text = coun_T7.ToString();
                        }
                        /////////////////////     target 6
                        if (msg[0] == '8')
                        {
                            label5.BackColor = Color.Lime;
                            if (msg[1] == '0')
                                label30.Text = "up";
                            if (msg[2] == '0')
                                label30.Text = "down";
                            if (msg[3] >= '1' && roun_level == 1)
                            { coun_T8++; if (prog_type == 3) UP_down = '0'; }
                            if (msg[3] >= '2' && roun_level == 2)
                                coun_T8++;
                            if (msg[3] == '3' && roun_level == 3)
                                coun_T8++;
                            label16.Text = coun_T8.ToString();
                        }




                        // progg type num 2
                        if (prog_type == 2 && timee == 0 && num > 0)
                        {
                            if (UP_down == '0')
                                UP_down = '1';
                            else
                                UP_down = '0';
                            num--;
                            timee = timee1;
                        }
                        timee--;


                        // setup senging msg  
                        string msgToall = "";
                        if (checkBox1.Checked) msgToall += '1'; else msgToall += '0'; // which trgt choosen by user
                        if (checkBox2.Checked) msgToall += '1'; else msgToall += '0';
                        if (checkBox3.Checked) msgToall += '1'; else msgToall += '0';
                        if (checkBox4.Checked) msgToall += '1'; else msgToall += '0';
                        if (checkBox5.Checked) msgToall += '1'; else msgToall += '0';
                        if (checkBox6.Checked) msgToall += '1'; else msgToall += '0';
                        if (checkBox7.Checked) msgToall += '1'; else msgToall += '0';
                        if (checkBox8.Checked) msgToall += '1'; else msgToall += '0';
                        msgToall += UP_down;
                        msgToall += Night_day;

                        // send to clint
                        byte[] msgToServerArr = Encoding.ASCII.GetBytes(msgToall);
                        int msgLength = serverSocket.SendTo(msgToServerArr, endPoint);

                    }
                    serverSocket.Close();


                }
            }
            catch {  }
        }

        Thread newThread;
        private void Form2_Load(object sender, EventArgs e)
        {
            button14.Hide();
            button13.Hide();
            
            newThread = new Thread(new ThreadStart(newMethod));
            newThread.Start();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            button1.BackColor = Color.Chartreuse;
            button2.BackColor = Color.White;
            Night_day = '1';
        }

        private void button2_Click(object sender, EventArgs e)
        {
            button2.BackColor = Color.Chartreuse;
            button1.BackColor = Color.White;
            Night_day = '0';
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form2.ActiveForm.Close();
            newThread.Abort();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            Form2.ActiveForm.Hide();
            Form3 F3 = new Form3();
            F3.ShowDialog();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            button5.BackColor = Color.Chartreuse;
            button4.BackColor = Color.White;
            button6.BackColor = Color.White;
            roun_level = 2;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            button4.BackColor = Color.Chartreuse;
            button5.BackColor = Color.White;
            button6.BackColor = Color.White;
            roun_level = 3;
        }

        private void button12_Click(object sender, EventArgs e)
        {

            // get the lst id to increament it by 1 
            con.Open();
            cmd = new SqlCommand("SELECT Id FROM castom ORDER BY Id Desc", con);
            SqlDataReader drr = cmd.ExecuteReader();
            if (drr.Read())
            {
                //MessageBox.Show(drr[0].ToString());
                idd = int.Parse(drr[0].ToString()) + 1;
                drr.Close();
            }
            cmd.ExecuteNonQuery();
            con.Close();


            // add anew raw to the new player
            con.Open();
            cmd = new SqlCommand("INSERT INTO castom (Id,name,score,rank,military_unit) VALUES (@Id,@name,@score,@rank,@military_unit)", con);
            cmd.Parameters.Add("@Id", idd);
            cmd.Parameters.Add("@name", textBox3.Text);
            cmd.Parameters.Add("@score", coun_T1 + coun_T2 + coun_T3 + coun_T4 + coun_T5 + coun_T6 + coun_T7 + coun_T8);
            cmd.Parameters.Add("@rank", textBox1.Text);
            cmd.Parameters.Add("@military_unit", textBox2.Text);
            cmd.ExecuteNonQuery();
            con.Close();

            // clear
            coun_T1 = 0;
            coun_T2 = 0;
            coun_T3 = 0;
            coun_T4 = 0;
            coun_T5 = 0;
            coun_T6 = 0;
            coun_T7 = 0;
            coun_T8 = 0;
        }

        private void button15_Click(object sender, EventArgs e)
        {
            coun_T1 = 0;
            coun_T2 = 0;
            coun_T3 = 0;
            coun_T4 = 0;
            coun_T5 = 0;
            coun_T6 = 0;
            coun_T7 = 0;
            coun_T8 = 0;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            button6.BackColor = Color.Chartreuse;
            button4.BackColor = Color.White;
            button5.BackColor = Color.White;
            roun_level = 1;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            prog_type = 3;
            button7.BackColor = Color.Chartreuse;
            button8.BackColor = Color.White;
            button9.BackColor = Color.White;
            button11.Hide();
            label21.Hide();
            label22.Hide();
            numericUpDown1.Hide();
            numericUpDown2.Hide();

            button14.Hide();
            button13.Hide();

        }

        private void button8_Click(object sender, EventArgs e)
        {
            prog_type = 2;
            button8.BackColor = Color.Chartreuse;
            button7.BackColor = Color.White;
            button9.BackColor = Color.White;
            button11.Show();
            label21.Show();
            label22.Show();
            numericUpDown1.Show();
            numericUpDown2.Show();
            button14.Hide();
            button13.Hide();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            prog_type = 1;
            button9.BackColor = Color.Chartreuse;
            button8.BackColor = Color.White;
            button7.BackColor = Color.White;
            button11.Hide();
            label21.Hide();
            label22.Hide();
            numericUpDown1.Hide();
            numericUpDown2.Hide();
            button14.Show();
            button13.Show();
        }

        private void button14_Click(object sender, EventArgs e)
        {
            UP_down = '1';
            button14.Hide();
            button13.Show();
        }

        private void button13_Click(object sender, EventArgs e)
        {
            UP_down = '0';
            button13.Hide();
            button14.Show();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            timee = numericUpDown1.Value * 10;
            num = (numericUpDown2.Value) * 2;
            timee1 = numericUpDown1.Value * 10;
            num1 = (numericUpDown2.Value) * 2;
        }
    }
}
