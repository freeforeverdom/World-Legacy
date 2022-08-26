using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;
using System.Diagnostics;

namespace boty
{
    public partial class Form1 : Form
    {
        private string connStr = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=E:\数据库\connectiontext1.accdb";

        private OleDbConnection conn = null;
        private OleDbDataAdapter adapter = null;
        private DataTable dt = null;
        private int nextcounts;
        public string content1;

        public Form1()
        {
            InitializeComponent();
            conn = new OleDbConnection(connStr);
            conn.Open();
            OleDbDataAdapter oleDapAdapter;
            DataSet ds = new DataSet();
            string max = "select * from score where id = (select max(id) from score)";
            oleDapAdapter = new OleDbDataAdapter(max,conn);
            oleDapAdapter.Fill(ds);
            string content = ds.Tables[0].Rows[0][0].ToString();
            nextcounts = Convert.ToInt32(content)+1;
            content1 = nextcounts + "";
            ds.Reset();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string sql = "insert into score(ID,姓名,木材,石材,机械材料,机械零件,机怪虫残骸,攻击力,生命值,进度,人口,陷阱,制作间,祭器能量)" +
                "values(" + content1 + ",'张三',0,0,0,0,0,0,0,0,1,0,0,0)";
            OleDbCommand comm = new OleDbCommand(sql, conn);
            comm.ExecuteNonQuery();
            adapter = new OleDbDataAdapter("Select*from score",conn);
            var cmd = new OleDbCommandBuilder(adapter);
            dt = new DataTable();
            adapter.Fill(dt);
            conn.Close();
            Close();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
   
     }
}
