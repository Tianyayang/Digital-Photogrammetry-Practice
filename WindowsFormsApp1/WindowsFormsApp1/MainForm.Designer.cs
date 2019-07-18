namespace WindowsFormsApp1
{
    partial class MainForm
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.文件ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.加载左片ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.加载右片ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.加载左片同名点坐标ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.加载右片同名点坐标ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.加载内外方位元素ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.内定向ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.进行内定向ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.输出内定向结果ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.空间直角坐标系的旋转变换ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.输出变换结果ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.连续像对像对定向ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.计算右片相对左片的方位元素ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.同名核线ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.绘制同名核线ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.保存左片ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.保存右片ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.openFileDialog2 = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.saveFileDialog2 = new System.Windows.Forms.SaveFileDialog();
            this.saveFileDialog3 = new System.Windows.Forms.SaveFileDialog();
            this.saveFileDialog4 = new System.Windows.Forms.SaveFileDialog();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.文件ToolStripMenuItem,
            this.内定向ToolStripMenuItem,
            this.连续像对像对定向ToolStripMenuItem,
            this.同名核线ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1445, 28);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 文件ToolStripMenuItem
            // 
            this.文件ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.加载左片ToolStripMenuItem,
            this.加载右片ToolStripMenuItem,
            this.加载左片同名点坐标ToolStripMenuItem,
            this.加载右片同名点坐标ToolStripMenuItem,
            this.加载内外方位元素ToolStripMenuItem});
            this.文件ToolStripMenuItem.Name = "文件ToolStripMenuItem";
            this.文件ToolStripMenuItem.Size = new System.Drawing.Size(81, 24);
            this.文件ToolStripMenuItem.Text = "加载数据";
            // 
            // 加载左片ToolStripMenuItem
            // 
            this.加载左片ToolStripMenuItem.Name = "加载左片ToolStripMenuItem";
            this.加载左片ToolStripMenuItem.Size = new System.Drawing.Size(219, 26);
            this.加载左片ToolStripMenuItem.Text = "加载左片";
            this.加载左片ToolStripMenuItem.Click += new System.EventHandler(this.加载左片ToolStripMenuItem_Click);
            // 
            // 加载右片ToolStripMenuItem
            // 
            this.加载右片ToolStripMenuItem.Name = "加载右片ToolStripMenuItem";
            this.加载右片ToolStripMenuItem.Size = new System.Drawing.Size(219, 26);
            this.加载右片ToolStripMenuItem.Text = "加载右片";
            this.加载右片ToolStripMenuItem.Click += new System.EventHandler(this.加载右片ToolStripMenuItem_Click);
            // 
            // 加载左片同名点坐标ToolStripMenuItem
            // 
            this.加载左片同名点坐标ToolStripMenuItem.Name = "加载左片同名点坐标ToolStripMenuItem";
            this.加载左片同名点坐标ToolStripMenuItem.Size = new System.Drawing.Size(219, 26);
            this.加载左片同名点坐标ToolStripMenuItem.Text = "加载左片同名点坐标";
            this.加载左片同名点坐标ToolStripMenuItem.Click += new System.EventHandler(this.加载左片同名点坐标ToolStripMenuItem_Click);
            // 
            // 加载右片同名点坐标ToolStripMenuItem
            // 
            this.加载右片同名点坐标ToolStripMenuItem.Name = "加载右片同名点坐标ToolStripMenuItem";
            this.加载右片同名点坐标ToolStripMenuItem.Size = new System.Drawing.Size(219, 26);
            this.加载右片同名点坐标ToolStripMenuItem.Text = "加载右片同名点坐标";
            this.加载右片同名点坐标ToolStripMenuItem.Click += new System.EventHandler(this.加载右片同名点坐标ToolStripMenuItem_Click);
            // 
            // 加载内外方位元素ToolStripMenuItem
            // 
            this.加载内外方位元素ToolStripMenuItem.Name = "加载内外方位元素ToolStripMenuItem";
            this.加载内外方位元素ToolStripMenuItem.Size = new System.Drawing.Size(219, 26);
            this.加载内外方位元素ToolStripMenuItem.Text = "加载内外方位元素";
            this.加载内外方位元素ToolStripMenuItem.Click += new System.EventHandler(this.加载内外方位元素ToolStripMenuItem_Click);
            // 
            // 内定向ToolStripMenuItem
            // 
            this.内定向ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.进行内定向ToolStripMenuItem,
            this.输出内定向结果ToolStripMenuItem,
            this.空间直角坐标系的旋转变换ToolStripMenuItem,
            this.输出变换结果ToolStripMenuItem});
            this.内定向ToolStripMenuItem.Name = "内定向ToolStripMenuItem";
            this.内定向ToolStripMenuItem.Size = new System.Drawing.Size(81, 24);
            this.内定向ToolStripMenuItem.Text = "坐标转换";
            // 
            // 进行内定向ToolStripMenuItem
            // 
            this.进行内定向ToolStripMenuItem.Name = "进行内定向ToolStripMenuItem";
            this.进行内定向ToolStripMenuItem.Size = new System.Drawing.Size(264, 26);
            this.进行内定向ToolStripMenuItem.Text = "进行内定向";
            this.进行内定向ToolStripMenuItem.Click += new System.EventHandler(this.进行内定向ToolStripMenuItem_Click);
            // 
            // 输出内定向结果ToolStripMenuItem
            // 
            this.输出内定向结果ToolStripMenuItem.Name = "输出内定向结果ToolStripMenuItem";
            this.输出内定向结果ToolStripMenuItem.Size = new System.Drawing.Size(264, 26);
            this.输出内定向结果ToolStripMenuItem.Text = "输出内定向结果";
            this.输出内定向结果ToolStripMenuItem.Click += new System.EventHandler(this.输出内定向结果ToolStripMenuItem_Click);
            // 
            // 空间直角坐标系的旋转变换ToolStripMenuItem
            // 
            this.空间直角坐标系的旋转变换ToolStripMenuItem.Name = "空间直角坐标系的旋转变换ToolStripMenuItem";
            this.空间直角坐标系的旋转变换ToolStripMenuItem.Size = new System.Drawing.Size(264, 26);
            this.空间直角坐标系的旋转变换ToolStripMenuItem.Text = "空间直角坐标系的旋转变换";
            this.空间直角坐标系的旋转变换ToolStripMenuItem.Click += new System.EventHandler(this.空间直角坐标系的旋转变换ToolStripMenuItem_Click);
            // 
            // 输出变换结果ToolStripMenuItem
            // 
            this.输出变换结果ToolStripMenuItem.Name = "输出变换结果ToolStripMenuItem";
            this.输出变换结果ToolStripMenuItem.Size = new System.Drawing.Size(264, 26);
            this.输出变换结果ToolStripMenuItem.Text = "输出变换结果";
            this.输出变换结果ToolStripMenuItem.Click += new System.EventHandler(this.输出变换结果ToolStripMenuItem_Click);
            // 
            // 连续像对像对定向ToolStripMenuItem
            // 
            this.连续像对像对定向ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.计算右片相对左片的方位元素ToolStripMenuItem});
            this.连续像对像对定向ToolStripMenuItem.Name = "连续像对像对定向ToolStripMenuItem";
            this.连续像对像对定向ToolStripMenuItem.Size = new System.Drawing.Size(141, 24);
            this.连续像对像对定向ToolStripMenuItem.Text = "连续像对相对定向";
            // 
            // 计算右片相对左片的方位元素ToolStripMenuItem
            // 
            this.计算右片相对左片的方位元素ToolStripMenuItem.Name = "计算右片相对左片的方位元素ToolStripMenuItem";
            this.计算右片相对左片的方位元素ToolStripMenuItem.Size = new System.Drawing.Size(279, 26);
            this.计算右片相对左片的方位元素ToolStripMenuItem.Text = "计算右片相对左片的方位元素";
            this.计算右片相对左片的方位元素ToolStripMenuItem.Click += new System.EventHandler(this.计算右片相对左片的方位元素ToolStripMenuItem_Click);
            // 
            // 同名核线ToolStripMenuItem
            // 
            this.同名核线ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.绘制同名核线ToolStripMenuItem,
            this.保存左片ToolStripMenuItem,
            this.保存右片ToolStripMenuItem});
            this.同名核线ToolStripMenuItem.Name = "同名核线ToolStripMenuItem";
            this.同名核线ToolStripMenuItem.Size = new System.Drawing.Size(81, 24);
            this.同名核线ToolStripMenuItem.Text = "同名核线";
            // 
            // 绘制同名核线ToolStripMenuItem
            // 
            this.绘制同名核线ToolStripMenuItem.Name = "绘制同名核线ToolStripMenuItem";
            this.绘制同名核线ToolStripMenuItem.Size = new System.Drawing.Size(174, 26);
            this.绘制同名核线ToolStripMenuItem.Text = "绘制同名核线";
            this.绘制同名核线ToolStripMenuItem.Click += new System.EventHandler(this.绘制同名核线ToolStripMenuItem_Click);
            // 
            // 保存左片ToolStripMenuItem
            // 
            this.保存左片ToolStripMenuItem.Name = "保存左片ToolStripMenuItem";
            this.保存左片ToolStripMenuItem.Size = new System.Drawing.Size(174, 26);
            this.保存左片ToolStripMenuItem.Text = "保存左片";
            this.保存左片ToolStripMenuItem.Click += new System.EventHandler(this.保存左片ToolStripMenuItem_Click);
            // 
            // 保存右片ToolStripMenuItem
            // 
            this.保存右片ToolStripMenuItem.Name = "保存右片ToolStripMenuItem";
            this.保存右片ToolStripMenuItem.Size = new System.Drawing.Size(174, 26);
            this.保存右片ToolStripMenuItem.Text = "保存右片";
            this.保存右片ToolStripMenuItem.Click += new System.EventHandler(this.保存右片ToolStripMenuItem_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.Filter = " JPG文件|*.jpg";
            this.openFileDialog1.Title = "加载相片";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 28);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.AutoScroll = true;
            this.splitContainer1.Panel1.Controls.Add(this.pictureBox1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.AutoScroll = true;
            this.splitContainer1.Panel2.Controls.Add(this.pictureBox2);
            this.splitContainer1.Size = new System.Drawing.Size(1445, 525);
            this.splitContainer1.SplitterDistance = 698;
            this.splitContainer1.TabIndex = 3;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(12, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(668, 501);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Location = new System.Drawing.Point(19, 12);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(668, 501);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 0;
            this.pictureBox2.TabStop = false;
            // 
            // openFileDialog2
            // 
            this.openFileDialog2.Filter = "txt文件|*.txt";
            this.openFileDialog2.Title = "加载同名点坐标";
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.FileName = "内定向结果";
            this.saveFileDialog1.Filter = "txt文件|*.txt";
            // 
            // saveFileDialog2
            // 
            this.saveFileDialog2.FileName = "空间直角坐标系的旋转变换结果";
            this.saveFileDialog2.Filter = "txt文件|*.txt";
            // 
            // saveFileDialog3
            // 
            this.saveFileDialog3.FileName = "保存左片";
            this.saveFileDialog3.Filter = "jpg文件|*.jpg";
            // 
            // saveFileDialog4
            // 
            this.saveFileDialog4.FileName = "保存右片";
            this.saveFileDialog4.Filter = "jpg文件|*.jpg";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1445, 553);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.Text = "摄影测量实习";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 文件ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 加载左片ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 加载右片ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 连续像对像对定向ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 同名核线ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 绘制同名核线ToolStripMenuItem;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.OpenFileDialog openFileDialog2;
        private System.Windows.Forms.ToolStripMenuItem 加载左片同名点坐标ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 加载右片同名点坐标ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 加载内外方位元素ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 计算右片相对左片的方位元素ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 内定向ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 进行内定向ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 输出内定向结果ToolStripMenuItem;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.ToolStripMenuItem 空间直角坐标系的旋转变换ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 输出变换结果ToolStripMenuItem;
        private System.Windows.Forms.SaveFileDialog saveFileDialog2;
        private System.Windows.Forms.ToolStripMenuItem 保存左片ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 保存右片ToolStripMenuItem;
        private System.Windows.Forms.SaveFileDialog saveFileDialog3;
        private System.Windows.Forms.SaveFileDialog saveFileDialog4;
    }
}

