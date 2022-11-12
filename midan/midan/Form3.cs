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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            using (SqlConnection slcon = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\user\Desktop\N-project\midan\midan\midnn.mdf;Integrated Security=True"))
            {
                slcon.Open();
                SqlDataAdapter sd = new SqlDataAdapter("SELECT * FROM castom", slcon);
                DataTable dt = new DataTable();
                sd.Fill(dt);
                dataGridView1.DataSource = dt;

            }
        }
        private void button3_Click(object sender, EventArgs e)
        {
            Form3.ActiveForm.Hide();
            Form1 F1 = new Form1();
            F1.ShowDialog();
        }

        private void customerDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void castomDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
