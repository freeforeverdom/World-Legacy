using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace boty
{
    public partial class basic : Form
    {
        son1 conponent1 = new son1();
        son2 conponent2 = new son2();
        static SoundPlayer bgm = new SoundPlayer("The World Legacy.wav");
        static SoundPlayer bgm1 = new SoundPlayer("Star Round.wav");

        private Form1 returnForm1 = null;

        public basic(Form1 form1)
        {
            InitializeComponent();
            this.returnForm1 = form1;
        }


        private void basic_Load(object sender, EventArgs e)
        {

        }

        private void 村庄地图ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            conponent1.Opacity = 0;
            conponent1.Show();
            conponent2.Hide();
            conponent1.MdiParent = this;
            conponent1.WindowState = FormWindowState.Maximized;
            conponent1.Opacity = 1;
            bgm1.PlayLooping();
        }

        private void 世界地图ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            conponent2.Opacity = 0;
            conponent2.Show();
            conponent1.Hide();
            conponent2.MdiParent = this;
            conponent2.WindowState = FormWindowState.Maximized;
            conponent2.Opacity = 1;
            bgm1.PlayLooping();
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void basic_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.returnForm1.Visible = true;
            bgm1.Stop();
            bgm.PlayLooping();
        }
    }
}


/*
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

   string m = "update score set 学号=2976 where ID=1 ";
            OleDbCommand comm = new OleDbCommand(m, conn);
            int a=comm.ExecuteNonQuery();
   string n = "delete from score where ID=1 ";
            OleDbCommand comm = new OleDbCommand(n, conn);
            int b = comm.ExecuteNonQuery();
*/