using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;
using System.Data.OleDb;

namespace boty
{
    public partial class son2 : Form
    {
        private string connStr = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|\connectiontext1.accdb";
        private OleDbConnection conn = null;
        private OleDbDataAdapter adapter = null;
        private DataTable dt = null;
        private DataSet ds = new DataSet();
        private int counts;
        private int coun;
        public son2()
        {
            InitializeComponent();

            
        }

        private void son2_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {
            Section1 section1 = new Section1();
            section1.Show();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            Section2 section2 = new Section2();
            section2.Show();
        }

        private void son2_VisibleChanged(object sender, EventArgs e)
        {
            conn = new OleDbConnection(connStr);
            conn.Open();
            OleDbDataAdapter oleDapAdapter;
            string max = "select * from score where ID = (select max(ID) from score)";
            oleDapAdapter = new OleDbDataAdapter(max, conn);
            oleDapAdapter.Fill(ds);
            //打开表最大一行并储存在表内
            string content = ds.Tables[0].Rows[0][0].ToString();
            counts = Convert.ToInt32(content) - 1;
            coun = counts + 1;
            //读取最大一行的序号
            adapter = new OleDbDataAdapter("Select*from score", conn);
            var cmd = new OleDbCommandBuilder(adapter);
            dt = new DataTable();
            adapter.Fill(dt);
            //读取所有行
            label2.Visible = false;
            pictureBox2.Visible = false;
            string speed = dt.Rows[counts][9].ToString();
            double sp = Convert.ToDouble(speed);
            sp = sp * 100;
            int n = (int)sp;
            int pin = 100;
            if (n == pin)
            {
                label2.Visible = true;
                pictureBox2.Visible = true;
            }
        }
    }
}
