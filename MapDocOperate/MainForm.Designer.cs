namespace MapDocOperate
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
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.文档操作ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.打开ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.新建ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.保存ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.地图操作ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.放大ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.缩小ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.复位ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.移动ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.添加地图ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.选择ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.图层操作地图为地图视图中显示的地图ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.添加图层ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.删除地图中第一个图层ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.查看地图中第一个图层的属性记录ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.闪烁ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.添加图层ToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.splitContainer1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 25);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Resize += new System.EventHandler(this.splitContainer1_Panel2_Resize);
            this.splitContainer1.Size = new System.Drawing.Size(568, 398);
            this.splitContainer1.SplitterDistance = 185;
            this.splitContainer1.TabIndex = 0;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.文档操作ToolStripMenuItem,
            this.地图操作ToolStripMenuItem,
            this.图层操作地图为地图视图中显示的地图ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(568, 25);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 文档操作ToolStripMenuItem
            // 
            this.文档操作ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.打开ToolStripMenuItem,
            this.新建ToolStripMenuItem,
            this.保存ToolStripMenuItem});
            this.文档操作ToolStripMenuItem.Name = "文档操作ToolStripMenuItem";
            this.文档操作ToolStripMenuItem.Size = new System.Drawing.Size(68, 21);
            this.文档操作ToolStripMenuItem.Text = "文档操作";
            // 
            // 打开ToolStripMenuItem
            // 
            this.打开ToolStripMenuItem.Name = "打开ToolStripMenuItem";
            this.打开ToolStripMenuItem.Size = new System.Drawing.Size(100, 22);
            this.打开ToolStripMenuItem.Text = "打开";
            this.打开ToolStripMenuItem.Click += new System.EventHandler(this.打开ToolStripMenuItem_Click);
            // 
            // 新建ToolStripMenuItem
            // 
            this.新建ToolStripMenuItem.Name = "新建ToolStripMenuItem";
            this.新建ToolStripMenuItem.Size = new System.Drawing.Size(100, 22);
            this.新建ToolStripMenuItem.Text = "新建";
            this.新建ToolStripMenuItem.Click += new System.EventHandler(this.新建ToolStripMenuItem_Click);
            // 
            // 保存ToolStripMenuItem
            // 
            this.保存ToolStripMenuItem.Name = "保存ToolStripMenuItem";
            this.保存ToolStripMenuItem.Size = new System.Drawing.Size(100, 22);
            this.保存ToolStripMenuItem.Text = "保存";
            this.保存ToolStripMenuItem.Click += new System.EventHandler(this.保存ToolStripMenuItem_Click);
            // 
            // 地图操作ToolStripMenuItem
            // 
            this.地图操作ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.放大ToolStripMenuItem,
            this.缩小ToolStripMenuItem,
            this.复位ToolStripMenuItem,
            this.移动ToolStripMenuItem,
            this.添加地图ToolStripMenuItem,
            this.选择ToolStripMenuItem,
            this.闪烁ToolStripMenuItem,
            this.添加图层ToolStripMenuItem1});
            this.地图操作ToolStripMenuItem.Name = "地图操作ToolStripMenuItem";
            this.地图操作ToolStripMenuItem.Size = new System.Drawing.Size(68, 21);
            this.地图操作ToolStripMenuItem.Text = "地图操作";
            // 
            // 放大ToolStripMenuItem
            // 
            this.放大ToolStripMenuItem.Name = "放大ToolStripMenuItem";
            this.放大ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.放大ToolStripMenuItem.Text = "放大";
            this.放大ToolStripMenuItem.Click += new System.EventHandler(this.放大ToolStripMenuItem_Click);
            // 
            // 缩小ToolStripMenuItem
            // 
            this.缩小ToolStripMenuItem.Name = "缩小ToolStripMenuItem";
            this.缩小ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.缩小ToolStripMenuItem.Text = "缩小";
            this.缩小ToolStripMenuItem.Click += new System.EventHandler(this.缩小ToolStripMenuItem_Click);
            // 
            // 复位ToolStripMenuItem
            // 
            this.复位ToolStripMenuItem.Name = "复位ToolStripMenuItem";
            this.复位ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.复位ToolStripMenuItem.Text = "复位";
            this.复位ToolStripMenuItem.Click += new System.EventHandler(this.复位ToolStripMenuItem_Click);
            // 
            // 移动ToolStripMenuItem
            // 
            this.移动ToolStripMenuItem.Name = "移动ToolStripMenuItem";
            this.移动ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.移动ToolStripMenuItem.Text = "移动";
            this.移动ToolStripMenuItem.Click += new System.EventHandler(this.移动ToolStripMenuItem_Click);
            // 
            // 添加地图ToolStripMenuItem
            // 
            this.添加地图ToolStripMenuItem.Name = "添加地图ToolStripMenuItem";
            this.添加地图ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.添加地图ToolStripMenuItem.Text = "添加地图";
            this.添加地图ToolStripMenuItem.Click += new System.EventHandler(this.添加地图ToolStripMenuItem_Click);
            // 
            // 选择ToolStripMenuItem
            // 
            this.选择ToolStripMenuItem.Name = "选择ToolStripMenuItem";
            this.选择ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.选择ToolStripMenuItem.Text = "选择";
            this.选择ToolStripMenuItem.Click += new System.EventHandler(this.选择ToolStripMenuItem_Click);
            // 
            // 图层操作地图为地图视图中显示的地图ToolStripMenuItem
            // 
            this.图层操作地图为地图视图中显示的地图ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.添加图层ToolStripMenuItem,
            this.删除地图中第一个图层ToolStripMenuItem,
            this.查看地图中第一个图层的属性记录ToolStripMenuItem});
            this.图层操作地图为地图视图中显示的地图ToolStripMenuItem.Name = "图层操作地图为地图视图中显示的地图ToolStripMenuItem";
            this.图层操作地图为地图视图中显示的地图ToolStripMenuItem.Size = new System.Drawing.Size(239, 21);
            this.图层操作地图为地图视图中显示的地图ToolStripMenuItem.Text = "图层操作---地图为地图视图中显示的地图";
            // 
            // 添加图层ToolStripMenuItem
            // 
            this.添加图层ToolStripMenuItem.Name = "添加图层ToolStripMenuItem";
            this.添加图层ToolStripMenuItem.Size = new System.Drawing.Size(256, 22);
            this.添加图层ToolStripMenuItem.Text = "添加图层";
            this.添加图层ToolStripMenuItem.Click += new System.EventHandler(this.添加图层ToolStripMenuItem_Click);
            // 
            // 删除地图中第一个图层ToolStripMenuItem
            // 
            this.删除地图中第一个图层ToolStripMenuItem.Name = "删除地图中第一个图层ToolStripMenuItem";
            this.删除地图中第一个图层ToolStripMenuItem.Size = new System.Drawing.Size(256, 22);
            this.删除地图中第一个图层ToolStripMenuItem.Text = "删除地图中第一个图层";
            this.删除地图中第一个图层ToolStripMenuItem.Click += new System.EventHandler(this.删除地图中第一个图层ToolStripMenuItem_Click);
            // 
            // 查看地图中第一个图层的属性记录ToolStripMenuItem
            // 
            this.查看地图中第一个图层的属性记录ToolStripMenuItem.Name = "查看地图中第一个图层的属性记录ToolStripMenuItem";
            this.查看地图中第一个图层的属性记录ToolStripMenuItem.Size = new System.Drawing.Size(256, 22);
            this.查看地图中第一个图层的属性记录ToolStripMenuItem.Text = "查看地图中第一个图层的属性记录";
            this.查看地图中第一个图层的属性记录ToolStripMenuItem.Click += new System.EventHandler(this.查看地图中第一个图层的属性记录ToolStripMenuItem_Click);
            // 
            // 闪烁ToolStripMenuItem
            // 
            this.闪烁ToolStripMenuItem.Name = "闪烁ToolStripMenuItem";
            this.闪烁ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.闪烁ToolStripMenuItem.Text = "闪烁";
            this.闪烁ToolStripMenuItem.Click += new System.EventHandler(this.闪烁ToolStripMenuItem_Click);
            // 
            // 添加图层ToolStripMenuItem1
            // 
            this.添加图层ToolStripMenuItem1.Name = "添加图层ToolStripMenuItem1";
            this.添加图层ToolStripMenuItem1.Size = new System.Drawing.Size(152, 22);
            this.添加图层ToolStripMenuItem1.Text = "添加图层";
            this.添加图层ToolStripMenuItem1.Click += new System.EventHandler(this.添加图层ToolStripMenuItem1_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(568, 423);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.Text = "地图文档操作";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.splitContainer1.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 文档操作ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 打开ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 新建ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 地图操作ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 放大ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 缩小ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 复位ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 移动ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 保存ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 添加地图ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 图层操作地图为地图视图中显示的地图ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 添加图层ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 查看地图中第一个图层的属性记录ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 删除地图中第一个图层ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 选择ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 闪烁ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 添加图层ToolStripMenuItem1;
    }
}

