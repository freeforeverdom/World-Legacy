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
        private string connStr = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|\connectiontext1.accdb";

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
            
            conn.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OleDbDataAdapter oleDapAdapter;
            DataSet ds = new DataSet();
            string max = "select * from score where id = (select max(id) from score)";
            oleDapAdapter = new OleDbDataAdapter(max, conn);
            oleDapAdapter.Fill(ds);
            string content = ds.Tables[0].Rows[0][0].ToString();
            nextcounts = Convert.ToInt32(content) + 1;
            content1 = nextcounts + "";
            ds.Reset();

            string sql = "insert into score(ID,姓名,木材,石材,机械材料,机械零件,机怪虫残骸,攻击力,生命值,进度,人口,陷阱,制作间,祭器能量)" +
                "values(" + content1 + ",'张三',0,0,0,0,0,0,0,0,1,0,0,0)";
            OleDbCommand comm = new OleDbCommand(sql, conn);
            comm.ExecuteNonQuery();
            adapter = new OleDbDataAdapter("Select*from score",conn);
            var cmd = new OleDbCommandBuilder(adapter);
            dt = new DataTable();
            adapter.Fill(dt);
            conn.Close();
            basic basic1=new basic(this);
            basic1.Show();
            this.Hide();
        }

        #region 控件大小随窗体大小等比例缩放
        private float x;//定义当前窗体的宽度
        private float y;//定义当前窗体的高度

        /// <summary>
        /// 将控件的宽，高，左边距，顶边距和字体大小暂存到tag属性中
        /// </summary>
        /// <param name="cons">递归控件中的控件</param>
        private void setTag(Control cons)
        {
            foreach (Control con in cons.Controls)
            {
                con.Tag = con.Width + ";" + con.Height + ";" + con.Left + ";" + con.Top + ";" + con.Font.Size;
                if (con.Controls.Count > 0)
                {
                    setTag(con);
                }
            }
        }


        /// <summary>
        /// 重新设置控件的属性
        /// </summary>
        /// <param name="newx">设置后新的x坐标</param>
        /// <param name="newy">设置后新的y坐标</param>
        /// <param name="cons">递归控件中的控件</param>
        private void setControls(float newx, float newy, Control cons)
        {
            //遍历窗体中的控件，重新设置控件的值
            foreach (Control con in cons.Controls)
            {
                //获取控件的Tag属性值，并分割后存储字符串数组
                if (con.Tag != null)
                {
                    string[] mytag = con.Tag.ToString().Split(new char[] { ';' });
                    //根据窗体缩放的比例确定控件的值
                    con.Width = Convert.ToInt32(System.Convert.ToSingle(mytag[0]) * newx);//宽度
                    con.Height = Convert.ToInt32(System.Convert.ToSingle(mytag[1]) * newy);//高度
                    con.Left = Convert.ToInt32(System.Convert.ToSingle(mytag[2]) * newx);//左边距
                    con.Top = Convert.ToInt32(System.Convert.ToSingle(mytag[3]) * newy);//顶边距
                    Single currentSize = System.Convert.ToSingle(mytag[4]) * newy;//字体大小
                    con.Font = new Font(con.Font.Name, currentSize, con.Font.Style, con.Font.Unit);
                    if (con.Controls.Count > 0)
                    {
                        setControls(newx, newy, con);
                    }
                }
            }
        }


        /// <summary>
        /// 窗体变化大小方法
        /// </summary>
        private void Form1_Resize(object sender, EventArgs e)
        {
            float newx = (this.Width) / x;
            float newy = (this.Height) / y;
            setControls(newx, newy, this);
            this.Resize += new System.EventHandler(this.Form1_Resize);
        }

        #endregion

        private void Form1_Load(object sender, EventArgs e)
        {
            x = this.Width;
            y = this.Height;
            setTag(this);
            Form1_Resize(new object(), new EventArgs());
        }

        private void Form1_VisibleChanged(object sender, EventArgs e)
        {
            if(this.Visible==true)
            conn.Open();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            OleDbDataAdapter oleDapAdapter;
            DataSet ds = new DataSet();
            string max = "select * from score where id = (select max(id) from score)";
            oleDapAdapter = new OleDbDataAdapter(max, conn);
            oleDapAdapter.Fill(ds);
            string content = ds.Tables[0].Rows[0][0].ToString();
            nextcounts = Convert.ToInt32(content) + 1;
            content1 = nextcounts + "";
            ds.Reset();

            adapter = new OleDbDataAdapter("Select*from score", conn);
            var cmd = new OleDbCommandBuilder(adapter);
            dt = new DataTable();
            adapter.Fill(dt);
            conn.Close();
            basic basic1 = new basic(this);
            basic1.Show();
            this.Hide();
        }
    }
}
