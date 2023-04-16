
namespace QuanLyCafe
{
    partial class fTableManager
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
            this.adminToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.thoongToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.thôngTinCáNhânToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.đăngXuấtToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lv_Bill = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.panel3 = new System.Windows.Forms.Panel();
            this.tb_totalPrice = new System.Windows.Forms.TextBox();
            this.nm_disCount = new System.Windows.Forms.NumericUpDown();
            this.btn_swicthTable = new System.Windows.Forms.Button();
            this.cb_switchTable = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.btn_disCount = new System.Windows.Forms.Button();
            this.btn_check = new System.Windows.Forms.Button();
            this.panel4 = new System.Windows.Forms.Panel();
            this.nm_foodCount = new System.Windows.Forms.NumericUpDown();
            this.btn_addFood = new System.Windows.Forms.Button();
            this.cb_Food = new System.Windows.Forms.ComboBox();
            this.cb_Category = new System.Windows.Forms.ComboBox();
            this.flp_Talble = new System.Windows.Forms.FlowLayoutPanel();
            this.menuStrip1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nm_disCount)).BeginInit();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nm_foodCount)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.adminToolStripMenuItem,
            this.thoongToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1213, 28);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // adminToolStripMenuItem
            // 
            this.adminToolStripMenuItem.Name = "adminToolStripMenuItem";
            this.adminToolStripMenuItem.Size = new System.Drawing.Size(67, 24);
            this.adminToolStripMenuItem.Text = "Admin";
            this.adminToolStripMenuItem.Click += new System.EventHandler(this.adminToolStripMenuItem_Click);
            // 
            // thoongToolStripMenuItem
            // 
            this.thoongToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.thôngTinCáNhânToolStripMenuItem,
            this.đăngXuấtToolStripMenuItem});
            this.thoongToolStripMenuItem.Name = "thoongToolStripMenuItem";
            this.thoongToolStripMenuItem.Size = new System.Drawing.Size(151, 24);
            this.thoongToolStripMenuItem.Text = "Thông tin tài khoản";
            // 
            // thôngTinCáNhânToolStripMenuItem
            // 
            this.thôngTinCáNhânToolStripMenuItem.Name = "thôngTinCáNhânToolStripMenuItem";
            this.thôngTinCáNhânToolStripMenuItem.Size = new System.Drawing.Size(210, 26);
            this.thôngTinCáNhânToolStripMenuItem.Text = "Thông tin cá nhân";
            this.thôngTinCáNhânToolStripMenuItem.Click += new System.EventHandler(this.thôngTinCáNhânToolStripMenuItem_Click);
            // 
            // đăngXuấtToolStripMenuItem
            // 
            this.đăngXuấtToolStripMenuItem.Name = "đăngXuấtToolStripMenuItem";
            this.đăngXuấtToolStripMenuItem.Size = new System.Drawing.Size(210, 26);
            this.đăngXuấtToolStripMenuItem.Text = "Đăng xuất";
            this.đăngXuấtToolStripMenuItem.Click += new System.EventHandler(this.đăngXuấtToolStripMenuItem_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.lv_Bill);
            this.panel2.Location = new System.Drawing.Point(656, 100);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(545, 480);
            this.panel2.TabIndex = 2;
            // 
            // lv_Bill
            // 
            this.lv_Bill.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4});
            this.lv_Bill.GridLines = true;
            this.lv_Bill.HideSelection = false;
            this.lv_Bill.Location = new System.Drawing.Point(3, 3);
            this.lv_Bill.Name = "lv_Bill";
            this.lv_Bill.Size = new System.Drawing.Size(539, 474);
            this.lv_Bill.TabIndex = 0;
            this.lv_Bill.UseCompatibleStateImageBehavior = false;
            this.lv_Bill.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Tên đồ uống";
            this.columnHeader1.Width = 127;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Số lượng";
            this.columnHeader2.Width = 70;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Đơn giá";
            this.columnHeader3.Width = 70;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Thành tiền";
            this.columnHeader4.Width = 82;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.tb_totalPrice);
            this.panel3.Controls.Add(this.nm_disCount);
            this.panel3.Controls.Add(this.btn_swicthTable);
            this.panel3.Controls.Add(this.cb_switchTable);
            this.panel3.Controls.Add(this.button1);
            this.panel3.Controls.Add(this.btn_disCount);
            this.panel3.Controls.Add(this.btn_check);
            this.panel3.Location = new System.Drawing.Point(657, 586);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(544, 66);
            this.panel3.TabIndex = 3;
            // 
            // tb_totalPrice
            // 
            this.tb_totalPrice.Location = new System.Drawing.Point(283, 39);
            this.tb_totalPrice.Name = "tb_totalPrice";
            this.tb_totalPrice.ReadOnly = true;
            this.tb_totalPrice.Size = new System.Drawing.Size(114, 22);
            this.tb_totalPrice.TabIndex = 3;
            this.tb_totalPrice.Text = "0";
            this.tb_totalPrice.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // nm_disCount
            // 
            this.nm_disCount.Location = new System.Drawing.Point(146, 39);
            this.nm_disCount.Name = "nm_disCount";
            this.nm_disCount.Size = new System.Drawing.Size(114, 22);
            this.nm_disCount.TabIndex = 2;
            this.nm_disCount.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btn_swicthTable
            // 
            this.btn_swicthTable.Location = new System.Drawing.Point(3, 6);
            this.btn_swicthTable.Name = "btn_swicthTable";
            this.btn_swicthTable.Size = new System.Drawing.Size(114, 29);
            this.btn_swicthTable.TabIndex = 1;
            this.btn_swicthTable.Text = "Chuyển bàn";
            this.btn_swicthTable.UseVisualStyleBackColor = true;
            this.btn_swicthTable.Click += new System.EventHandler(this.btn_swicthTable_Click);
            // 
            // cb_switchTable
            // 
            this.cb_switchTable.FormattingEnabled = true;
            this.cb_switchTable.Location = new System.Drawing.Point(3, 36);
            this.cb_switchTable.Name = "cb_switchTable";
            this.cb_switchTable.Size = new System.Drawing.Size(114, 24);
            this.cb_switchTable.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(283, 6);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(114, 29);
            this.button1.TabIndex = 1;
            this.button1.Text = "Tổng";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // btn_disCount
            // 
            this.btn_disCount.Location = new System.Drawing.Point(146, 6);
            this.btn_disCount.Name = "btn_disCount";
            this.btn_disCount.Size = new System.Drawing.Size(114, 29);
            this.btn_disCount.TabIndex = 1;
            this.btn_disCount.Text = "Giảm giá";
            this.btn_disCount.UseVisualStyleBackColor = true;
            // 
            // btn_check
            // 
            this.btn_check.Location = new System.Drawing.Point(426, 6);
            this.btn_check.Name = "btn_check";
            this.btn_check.Size = new System.Drawing.Size(114, 54);
            this.btn_check.TabIndex = 1;
            this.btn_check.Text = "Thanh toán";
            this.btn_check.UseVisualStyleBackColor = true;
            this.btn_check.Click += new System.EventHandler(this.btn_check_Click);
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.nm_foodCount);
            this.panel4.Controls.Add(this.btn_addFood);
            this.panel4.Controls.Add(this.cb_Food);
            this.panel4.Controls.Add(this.cb_Category);
            this.panel4.Location = new System.Drawing.Point(656, 31);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(544, 63);
            this.panel4.TabIndex = 4;
            // 
            // nm_foodCount
            // 
            this.nm_foodCount.Location = new System.Drawing.Point(354, 35);
            this.nm_foodCount.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
            this.nm_foodCount.Name = "nm_foodCount";
            this.nm_foodCount.Size = new System.Drawing.Size(66, 22);
            this.nm_foodCount.TabIndex = 2;
            this.nm_foodCount.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // btn_addFood
            // 
            this.btn_addFood.Location = new System.Drawing.Point(427, 5);
            this.btn_addFood.Name = "btn_addFood";
            this.btn_addFood.Size = new System.Drawing.Size(114, 54);
            this.btn_addFood.TabIndex = 1;
            this.btn_addFood.Text = "Thêm món";
            this.btn_addFood.UseVisualStyleBackColor = true;
            this.btn_addFood.Click += new System.EventHandler(this.btn_addFood_Click);
            // 
            // cb_Food
            // 
            this.cb_Food.FormattingEnabled = true;
            this.cb_Food.Location = new System.Drawing.Point(4, 34);
            this.cb_Food.Name = "cb_Food";
            this.cb_Food.Size = new System.Drawing.Size(344, 24);
            this.cb_Food.TabIndex = 0;
            // 
            // cb_Category
            // 
            this.cb_Category.FormattingEnabled = true;
            this.cb_Category.Location = new System.Drawing.Point(4, 4);
            this.cb_Category.Name = "cb_Category";
            this.cb_Category.Size = new System.Drawing.Size(344, 24);
            this.cb_Category.TabIndex = 0;
            this.cb_Category.SelectedIndexChanged += new System.EventHandler(this.cb_Category_SelectedIndexChanged);
            // 
            // flp_Talble
            // 
            this.flp_Talble.AutoScroll = true;
            this.flp_Talble.Location = new System.Drawing.Point(12, 31);
            this.flp_Talble.Name = "flp_Talble";
            this.flp_Talble.Size = new System.Drawing.Size(642, 621);
            this.flp_Talble.TabIndex = 5;
            // 
            // fTableManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1213, 678);
            this.Controls.Add(this.flp_Talble);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "fTableManager";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Phần mền quản lý quán Cà phê";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nm_disCount)).EndInit();
            this.panel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.nm_foodCount)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem adminToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem thoongToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem thôngTinCáNhânToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem đăngXuấtToolStripMenuItem;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ListView lv_Bill;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.ComboBox cb_Category;
        private System.Windows.Forms.NumericUpDown nm_disCount;
        private System.Windows.Forms.Button btn_swicthTable;
        private System.Windows.Forms.ComboBox cb_switchTable;
        private System.Windows.Forms.Button btn_check;
        private System.Windows.Forms.NumericUpDown nm_foodCount;
        private System.Windows.Forms.Button btn_addFood;
        private System.Windows.Forms.ComboBox cb_Food;
        private System.Windows.Forms.FlowLayoutPanel flp_Talble;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.TextBox tb_totalPrice;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btn_disCount;
    }
}