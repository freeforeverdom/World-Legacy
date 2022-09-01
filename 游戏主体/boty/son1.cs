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
    public partial class son1 : Form
    {
        private string connStr = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|\connectiontext1.accdb";
        private OleDbConnection conn = null;
        private OleDbDataAdapter adapter = null;
        private DataTable dt = null;
        private DataSet ds = new DataSet();
        private int counts;
        private int coun;
        public string content1;
        int i;
        public son1()
        {
            InitializeComponent();
            //初始化
            conn = new OleDbConnection(connStr);
            conn.Open();
            OleDbDataAdapter oleDapAdapter;
            string max = "select * from score where ID = (select max(ID) from score)";
            oleDapAdapter = new OleDbDataAdapter(max, conn);
            oleDapAdapter.Fill(ds);
            //打开表最大一行并储存在表内
            string content = ds.Tables[0].Rows[0][0].ToString();
            counts = Convert.ToInt32(content)-1;
            coun = counts + 1;
            //读取最大一行的序号
            adapter = new OleDbDataAdapter("Select*from score", conn);
            var cmd = new OleDbCommandBuilder(adapter);
            dt = new DataTable();
            adapter.Fill(dt);
            //读取所有行
            label5.Visible = false;
            label6.Visible = false;
            timer3.Start();
            timer4.Start();
        }

       

        private void son1_Load(object sender,EventArgs e)
        {
            Timer1.Interval = 3000;
            Timer1.Enabled = true;
            timer2.Interval = 10000;
            timer2.Enabled = true;
            timer3.Interval = 5000;
            timer3.Enabled = true;
            timer3.Interval = 100;
            timer3.Enabled = true;

            
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (label1.Visible == false)
            { 
                label1.Visible = true; 
            }
            if(label2.Visible == false)
            { 
                label2.Visible = true;
            }
            if (label4.Visible == false)
            {
                label4.Visible = true;
            }
            Timer1.Stop();
        }
        private void timer2_Tick(object sender, EventArgs e)
        {
            if (label3.Visible == false)
            {
                label3.Visible = true;
            }
            timer2.Stop();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            string energy = dt.Rows[counts][13].ToString();
            double ene = Convert.ToDouble(energy);
            label1.Visible = false;
            Timer1.Start();
            if (ene >= 0.1)
            {
                ene = ene - 0.1;
                string m = Convert.ToString(ene);
                dt.Rows[counts][13] = m;
                try
                {
                    adapter.Update(dt);
                    dt.Clear();
                    adapter.Fill(dt);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {

                }
            }
            else 
            {
                MessageBox.Show("不可进行结界修复！");
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {
            string wood = dt.Rows[counts][2].ToString();
            string stone = dt.Rows[counts][3].ToString();
            double wo = Convert.ToDouble(wood);
            double st = Convert.ToDouble(stone);
            label2.Visible = false;
            Timer1.Start();
            wo = wo + 50;
            st = st + 20;
            string m = Convert.ToString(wo);
            dt.Rows[counts][2] = m;
            string n = Convert.ToString(st); 
            dt.Rows[counts][3] = n;
            try
            {
                adapter.Update(dt);
                dt.Clear();
                adapter.Fill(dt);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {

            }
        }

        private void label3_Click(object sender, EventArgs e)
        {
            string trap = dt.Rows[counts][11].ToString();
            string wreckage = dt.Rows[counts][6].ToString();
            string material = dt.Rows[counts][4].ToString();
            string parts = dt.Rows[counts][5].ToString();
            int tr = Convert.ToInt32(trap);
            int wr = Convert.ToInt32(wreckage);
            int ma = Convert.ToInt32(material);
            int pa = Convert.ToInt32(parts);
            int tr1 = tr * 10;
            Random rand1 = new Random();
            Random rand2 = new Random();
            Random rand3 = new Random();
            int a = rand1.Next(0,tr1);
            int b = rand2.Next(0, tr1);
            int c = rand3.Next(0, tr1);
            label3.Visible = false;
            timer2.Start();
            wr = wr + a;
            ma = ma + b;
            pa = pa + c;
            string wr1 = Convert.ToString(wr);
            dt.Rows[counts][6] = wr1;
            string ma1 = Convert.ToString(ma);
            dt.Rows[counts][4] = ma1;
            string pa1 = Convert.ToString(pa);
            dt.Rows[counts][5] = pa1;
            label3.Visible = false;
            try
            {
                adapter.Update(dt);
                dt.Clear();
                adapter.Fill(dt);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {

            }

        }

        private void label4_Click(object sender, EventArgs e)
        {
            string energy = dt.Rows[counts][13].ToString();
            string speed = dt.Rows[counts][9].ToString();
            double ene = Convert.ToDouble(energy);
            double sp = Convert.ToDouble(speed);
            label4.Visible = false;
            Timer1.Start();
            if (ene >= 0.2)
            {
                ene = ene - 0.2;
                sp = sp + 0.05;
                string m = Convert.ToString(ene);
                string n = Convert.ToString(sp);
                dt.Rows[counts][13] = m;
                dt.Rows[counts][9] = n;
                try
                {
                    adapter.Update(dt);
                    dt.Clear();
                    adapter.Fill(dt);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {

                }
            }
            else
            {
                MessageBox.Show("不可进行星杯激活！");
            }
        }

        private void label5_Click(object sender, EventArgs e)
        {
            string wreckage = dt.Rows[counts][6].ToString();
            string material = dt.Rows[counts][4].ToString();
            string parts = dt.Rows[counts][5].ToString();
            int wr = Convert.ToInt32(wreckage);
            int ma = Convert.ToInt32(material);
            int pa = Convert.ToInt32(parts);
            label5.Visible = false;
            if( wr>=100 && ma>=50 && pa>=150 )
            {
                int wr1 = wr - 100;
                int ma1 = ma - 50;
                int pa1 = pa - 150;
                string wr2 = Convert.ToString(wr);
                dt.Rows[counts][6] = wr2;
                string ma2 = Convert.ToString(ma);
                dt.Rows[counts][4] = ma2;
                string pa2 = Convert.ToString(pa);
                dt.Rows[counts][5] = pa2;
                string attack = dt.Rows[counts][7].ToString();
                int at = Convert.ToInt32(attack);
                at = at + 200;
                string at1 = Convert.ToString(at);
                dt.Rows[counts][7] = at1;
                try
                {
                    adapter.Update(dt);
                    dt.Clear();
                    adapter.Fill(dt);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {

                }
            }
            else
            {
                label5.Visible = true;
                MessageBox.Show("不可以进行武器制作！");
            }
        }

        private void label6_Click(object sender, EventArgs e)
        {
            string wreckage = dt.Rows[counts][6].ToString();
            string material = dt.Rows[counts][4].ToString();
            string parts = dt.Rows[counts][5].ToString();
            int wr = Convert.ToInt32(wreckage);
            int ma = Convert.ToInt32(material);
            int pa = Convert.ToInt32(parts);
            label6.Visible = false;
            if (wr >= 100 && ma >= 150 && pa >= 50)
            {
                int wr1 = wr - 100;
                int ma1 = ma - 150;
                int pa1 = pa - 50;
                string wr2 = Convert.ToString(wr);
                dt.Rows[counts][6] = wr2;
                string ma2 = Convert.ToString(ma);
                dt.Rows[counts][4] = ma2;
                string pa2 = Convert.ToString(pa);
                dt.Rows[counts][5] = pa2;
                string life = dt.Rows[counts][8].ToString();
                int li = Convert.ToInt32(life);
                li = li + 200;
                string li1 = Convert.ToString(li);
                dt.Rows[counts][8] = li1;
                try
                {
                    adapter.Update(dt);
                    dt.Clear();
                    adapter.Fill(dt);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {

                }
            }
            else
            {
                label6.Visible = true;
                MessageBox.Show("不可以进行铠甲制作！");
            }
        }

        private void label7_Click(object sender, EventArgs e)
        {
            string people = dt.Rows[counts][10].ToString();
            string wood = dt.Rows[counts][2].ToString();
            int a = Convert.ToInt32(people);
            int wo = Convert.ToInt32(wood);
            int cost = 50 + 50 * a;
            if(a>=20)
            {
                label7.Visible = false;
                MessageBox.Show("你不可以继续扩建村子！");
            }
            else
            {
                if(wo >= cost)
                {
                    int sma = wo - cost;
                    string sma1 = Convert.ToString(sma);
                    dt.Rows[counts][2] = sma1;
                    a = a + 1;
                    string a1 = Convert.ToString(a);
                    dt.Rows[counts][10] = a1;
                    try
                    {
                        adapter.Update(dt);
                        dt.Clear();
                        adapter.Fill(dt);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    finally
                    {

                    }
                }
                else
                {
                    MessageBox.Show("你没有足够的资源扩建村子！");
                }
            }
        }

        private void label8_Click(object sender, EventArgs e)
        {
            string trap = dt.Rows[counts][11].ToString();
            int tr = Convert.ToInt32(trap);
            string wood = dt.Rows[counts][2].ToString();
            int wo = Convert.ToInt32(wood);
            int cost = 30 + 20 * tr;
            if (tr>=10)
            {
                label8.Visible = false;
                MessageBox.Show("你不可以继续设置陷阱！");
            }
            else
            {
                if(wo >= cost)
                {
                    int sma = wo - cost;
                    string sma1 = Convert.ToString(sma);
                    dt.Rows[counts][2] = sma1;
                    tr = tr + 1;
                    string tr1 = Convert.ToString(tr);
                    dt.Rows[counts][11] = tr1;
                    try
                    {
                        adapter.Update(dt);
                        dt.Clear();
                        adapter.Fill(dt);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    finally
                    {

                    }
                }
                else
                {
                    MessageBox.Show("你没有足够的资源设置陷阱！");
                }
            }
        }

        private void label9_Click(object sender, EventArgs e)
        {
            string wood = dt.Rows[counts][2].ToString();
            string stone = dt.Rows[counts][3].ToString();
            string material = dt.Rows[counts][4].ToString();
            string house = dt.Rows[counts][12].ToString();
            int wo = Convert.ToInt32(wood);
            int st = Convert.ToInt32(stone);
            int ma = Convert.ToInt32(material);
            int ho = Convert.ToInt32(house);
            if(wo >= 800 && st >= 300 && ma >= 100)
            {
                int wo1 = wo - 800;
                int st1 = st - 300;
                int ma1 = ma - 100;
                ho = ho + 1;
                label9.Visible = false;
                label5.Visible = true;
                label6.Visible = true;
                string wo2 = Convert.ToString(wo1);
                dt.Rows[counts][2] = wo2;
                string st2 = Convert.ToString(st1);
                dt.Rows[counts][3] = st2;
                string ma2 = Convert.ToString(ma1);
                dt.Rows[counts][4] = ma2;
                string ho2 = Convert.ToString(ho);
                dt.Rows[counts][12] = ho2;
                try
                {
                    adapter.Update(dt);
                    dt.Clear();
                    adapter.Fill(dt);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {

                }
            }
            else
            {
                MessageBox.Show("你没有足够的资源建造制造间！");
            }
        }

        private void timer3_Tick(object sender, EventArgs e)
        {
            string energy = dt.Rows[counts][13].ToString();
            double ene = Convert.ToDouble(energy);
            if(ene<1)
            {
                ene = ene + 0.02;
            }
            else { }
            string ene1 = Convert.ToString(ene);
            dt.Rows[counts][13] = ene;
            try
            {
                adapter.Update(dt);
                dt.Clear();
                adapter.Fill(dt);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {

            }
            
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void timer4_Tick(object sender, EventArgs e)
        {
            string energy = dt.Rows[counts][13].ToString();
            double ene = Convert.ToDouble(energy);
            string name = dt.Rows[counts][1].ToString();
            string wood = dt.Rows[counts][2].ToString();
            string stone = dt.Rows[counts][3].ToString();
            string material = dt.Rows[counts][4].ToString();
            string parts = dt.Rows[counts][5].ToString();
            string wreckage = dt.Rows[counts][6].ToString();
            string people = dt.Rows[counts][10].ToString();
            string trap = dt.Rows[counts][11].ToString();
            string house = dt.Rows[counts][12].ToString();
            double energy1 = ene * 100;
            string energy2 = Convert.ToString(energy1);
            richTextBox1.Text = "木材： " + wood + "\n" + "石材： " + stone + "\n" + "祭器能量： " + energy2
                + "%" + "\n" + "机械材料： " + material + "\n" + "机械零件： " + parts + "\n" + "机怪虫残骸： " + wreckage + "\n";
            richTextBox2.Text = "人口： " + people + "\n" + "陷阱： " + trap + "\n" + "制造间： " + house
                + "\n";
            string speed = dt.Rows[counts][9].ToString();
            double sp = Convert.ToDouble(speed);
            sp = sp * 100;
            string sp1 = Convert.ToString(sp);
            int u = (int)(sp / 4.0);
            if (i == u)
            { 
            
            }
            else 
            {
                i = (int)(sp / 4.0);
                int j = 0;
                progressBar1.Value = 0;
                while (j < i)
                {
                    progressBar1.PerformStep();
                    j++;
                }
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void progressBar1_MouseHover(object sender, EventArgs e)
        {
            string speed = dt.Rows[counts][9].ToString();
            double sp = Convert.ToDouble(speed);
            sp = sp * 100;
            string sp1 = Convert.ToString(sp);
            ToolTip toolTip1 = new ToolTip();
            // 设置显示样式
            toolTip1.AutoPopDelay = 5000;//提示信息的可见时间
            toolTip1.InitialDelay = 500;//事件触发多久后出现提示
            toolTip1.ReshowDelay = 500;//指针从一个控件移向另一个控件时，经过多久才会显示下一个提示框
            toolTip1.ShowAlways = true;//是否显示提示框
            //  设置伴随的对象.
            toolTip1.SetToolTip(progressBar1, sp1 + "%");
        }
    }
}
