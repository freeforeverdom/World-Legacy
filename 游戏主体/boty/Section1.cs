using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace boty
{
    public partial class Section1 : Form
    {
        //初始化
        private string connStr = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|\connectiontext1.accdb";
        private OleDbConnection conn = null;
        private OleDbDataAdapter adapter = null;
        private DataTable dt = null;
        private static int i = 0;
        private static int flag = 0;
        public Section1()
        {
            InitializeComponent();
        }

        private void Section1_Load(object sender, EventArgs e)
        {
            //连接数据库，并把数据表放在内存里
            conn = new OleDbConnection(connStr);
            conn.Open();
            adapter = new OleDbDataAdapter("Select * from dialog1", conn);
            var cmd = new OleDbCommandBuilder(adapter);
            dt = new DataTable();
            adapter.Fill(dt);
            //标签文本初始化
            label1.Text = "";
            label2.Text = "";
            label5.Text = dt.Rows[i][1].ToString();
            PictureLeft1.BackColor = Color.Transparent;
            PictureLeft2.BackColor = Color.Transparent;
            PictureLeft3.BackColor = Color.Transparent;
            Picture4.BackColor = Color.Transparent;
            PictureRight1.BackColor = Color.Transparent;
            PictureRight2.BackColor = Color.Transparent;
            PictureRight3.BackColor = Color.Transparent;
            label1.BackColor = Color.FromArgb(122, 40, 40, 40);
            label2.BackColor = Color.FromArgb(122, 40, 40, 40);
            label5.BackColor = Color.FromArgb(122, 40, 40, 40);
            picture_leftunvisual(PictureLeft1, PictureLeft2, PictureLeft3, Picture4);
            picture_rightunvisual(PictureRight1, PictureRight2, PictureRight3);
        }

        private void label3_Click(object sender, EventArgs e)
        {
            //点击继续，剧情推进，并在剧情跑完时进行关闭操作
            try
            {
                i++;
                label1.Text = dt.Rows[i][0].ToString();
                label2.Text = dt.Rows[i][2].ToString();
                label5.Text = dt.Rows[i][1].ToString();
                if (dt.Rows[i][3].ToString() != dt.Rows[i - 1][3].ToString())
                {
                    if (dt.Rows[i][3].ToString() != "")
                    {
                        PictureRight1.Parent = this;
                        PictureRight2.Parent = this;
                        PictureRight3.Parent = this;
                        picture_leftunvisual(PictureLeft1, PictureLeft2, PictureLeft3, Picture4);
                        picture_rightvis(PictureRight1, PictureRight2, PictureRight3, out flag);
                        if (flag == 1)
                        {
                            switch (dt.Rows[i][3].ToString())
                            {
                                case "奥拉姆":
                                    PictureLeft1.Visible = true;
                                    PictureLeft1.Parent = picture_rightvis(PictureRight1, PictureRight2, PictureRight3, out flag);
                                    label_parent(PictureLeft1, label1, label2, label5);
                                    break;
                                case "夏娃":
                                    PictureLeft2.Visible = true;
                                    PictureLeft2.Parent = picture_rightvis(PictureRight1, PictureRight2, PictureRight3, out flag);
                                    label_parent(PictureLeft2, label1, label2, label5);
                                    break;
                                case "宁吉尔苏":
                                    PictureLeft3.Visible = true;
                                    PictureLeft3.Parent = picture_rightvis(PictureRight1, PictureRight2, PictureRight3, out flag);
                                    label_parent(PictureLeft3, label1, label2, label5);
                                    break;
                                case "伊姆杜克":
                                    Picture4.Visible = true;
                                    Picture4.Parent = picture_rightvis(PictureRight1, PictureRight2, PictureRight3, out flag);
                                    label_parent(Picture4, label1, label2, label5);
                                    break;
                            }
                        }
                        else
                        {
                            switch (dt.Rows[i][3].ToString())
                            {
                                case "奥拉姆":
                                    PictureLeft1.Visible = true;
                                    label_parent(PictureLeft1, label1, label2, label5);
                                    break;
                                case "夏娃":
                                    PictureLeft2.Visible = true;
                                    label_parent(PictureLeft2, label1, label2, label5);
                                    break;
                                case "宁吉尔苏":
                                    PictureLeft3.Visible = true;
                                    label_parent(PictureLeft3, label1, label2, label5);
                                    break;
                                case "伊姆杜克":
                                    Picture4.Visible = true;
                                    label_parent(Picture4, label1, label2, label5);
                                    break;
                            }
                        }
                    }
                }
                if (dt.Rows[i][4].ToString() != dt.Rows[i - 1][4].ToString())
                {
                    if (dt.Rows[i][4].ToString() != "")
                    {
                        PictureLeft1.Parent = this;
                        PictureLeft2.Parent = this;
                        PictureLeft3.Parent = this;
                        Picture4.Parent = this;
                        picture_rightunvisual(PictureRight1, PictureRight2, PictureRight3);
                        picture_leftvis(PictureLeft1, PictureLeft2, PictureLeft3, Picture4, out flag);
                        if (flag == 0)
                        {
                            switch (dt.Rows[i][4].ToString())
                            {
                                case "奥拉姆":
                                    PictureRight1.Visible = true;
                                    label_parent(PictureRight1, label1, label2, label5);
                                    break;
                                case "夏娃":
                                    PictureRight2.Visible = true;
                                    label_parent(PictureRight2, label1, label2, label5);
                                    break;
                                case "宁吉尔苏":
                                    PictureRight3.Visible = true;
                                    label_parent(PictureRight3, label1, label2, label5);
                                    break;
                            }
                        }
                        else
                        {
                            switch (dt.Rows[i][4].ToString())
                            {
                                case "奥拉姆":
                                    PictureRight1.Visible = true;
                                    PictureRight1.Parent = picture_leftvis(PictureLeft1, PictureLeft2, PictureLeft3, Picture4, out flag);
                                    label_parent(PictureRight1, label1, label2, label5);
                                    break;
                                case "夏娃":
                                    PictureRight2.Visible = true;
                                    PictureRight2.Parent = picture_leftvis(PictureLeft1, PictureLeft2, PictureLeft3, Picture4, out flag);
                                    label_parent(PictureRight2, label1, label2, label5);
                                    break;
                                case "宁吉尔苏":
                                    PictureRight3.Visible = true;
                                    PictureRight3.Parent = picture_leftvis(PictureLeft1, PictureLeft2, PictureLeft3, Picture4, out flag);
                                    label_parent(PictureRight3, label1, label2, label5);
                                    break;

                            }
                        }
                    }

                }

            }
            catch { i = 0; this.Close(); }
            finally {  }
        }
        private void label4_Click(object sender, EventArgs e)
        {
            //点击跳过，关闭窗口
            i = 0;
            this.Close();
        }
        private static void label_parent(PictureBox a, Label b, Label c, Label d)
        {
            b.Parent = a;
            c.Parent = a;
            d.Parent = a;
        }
        //使多个图像不可见
        private static void picture_leftunvisual(PictureBox a, PictureBox b, PictureBox c, PictureBox d)
        {
            a.Visible = false;
            b.Visible = false;
            c.Visible = false;
            d.Visible = false;
        }
        private static void picture_rightunvisual(PictureBox a, PictureBox b, PictureBox c)
        {
            a.Visible = false;
            b.Visible = false;
            c.Visible = false;
        }
        private static PictureBox picture_leftvis(PictureBox a, PictureBox b, PictureBox c, PictureBox d, out int flag)
        {
            PictureBox[] pictureBoxes = { a, b, c, d };
            foreach (PictureBox pictureBox in pictureBoxes)
            {
                if (pictureBox.Visible)
                {
                    flag = 1;
                    return pictureBox;
                }
            }
            flag = 0;
            return null;
        }
        private static PictureBox picture_rightvis(PictureBox a, PictureBox b, PictureBox c, out int flag)
        {
            PictureBox[] pictureBoxes = { a, b, c };
            foreach (PictureBox pictureBox in pictureBoxes)
            {
                if (pictureBox.Visible)
                {
                    flag = 1;
                    return pictureBox;
                }
            }
            flag = 0;
            return null;
        }


    }
}
