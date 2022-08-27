namespace boty
{
    partial class basic
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.村庄地图ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.世界地图ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.村庄地图ToolStripMenuItem,
            this.世界地图ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(4, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(1008, 25);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            this.menuStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.menuStrip1_ItemClicked);
            // 
            // 村庄地图ToolStripMenuItem
            // 
            this.村庄地图ToolStripMenuItem.Name = "村庄地图ToolStripMenuItem";
            this.村庄地图ToolStripMenuItem.Size = new System.Drawing.Size(68, 21);
            this.村庄地图ToolStripMenuItem.Text = "村庄地图";
            this.村庄地图ToolStripMenuItem.Click += new System.EventHandler(this.村庄地图ToolStripMenuItem_Click);
            // 
            // 世界地图ToolStripMenuItem
            // 
            this.世界地图ToolStripMenuItem.Name = "世界地图ToolStripMenuItem";
            this.世界地图ToolStripMenuItem.Size = new System.Drawing.Size(68, 21);
            this.世界地图ToolStripMenuItem.Text = "世界地图";
            this.世界地图ToolStripMenuItem.Click += new System.EventHandler(this.世界地图ToolStripMenuItem_Click);
            // 
            // basic
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1008, 651);
            this.Controls.Add(this.menuStrip1);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "basic";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "主界面";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.basic_FormClosing);
            this.Load += new System.EventHandler(this.basic_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 村庄地图ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 世界地图ToolStripMenuItem;
    }
}