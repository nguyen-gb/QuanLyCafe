using QuanLyCafe.DAO;
using QuanLyCafe.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Menu = QuanLyCafe.DTO.Menu;

namespace QuanLyCafe
{
    public partial class fTableManager : Form
    {
        private Account loginAccount;

        public Account LoginAccount { get => loginAccount; set => loginAccount = value;}

        public fTableManager(Account loginAccount)
        {
            this.LoginAccount = loginAccount;
            InitializeComponent();

            LoadTable();
            LoadCategogy();
            LoadComboBoxTable(cb_switchTable);
            ChangeAccount(loginAccount.Type);
        }

        

        #region Method

        void ChangeAccount(int type)
        {
            adminToolStripMenuItem.Enabled = type == 1;
            thoongToolStripMenuItem.Text += " (" + loginAccount.DisplayName + ")";
        }

        void LoadCategogy()
        {
            List<Category> listCategory = CategoryDAO.Instance.GetListCategory();
            cb_Category.DataSource = listCategory;
            cb_Category.DisplayMember = "Name";
        }

        void LoadFoodByCategoryID(int id)
        {
            List<Food> listFood = FoodDAO.Instance.GetListFoodByCategoryID(id);
            cb_Food.DataSource = listFood;
            cb_Food.DisplayMember = "Name";
        }

        void LoadTable()
        {
            flp_Talble.Controls.Clear();

            List<Table> tablelist = TableDAO.Instance.LoadTableList();

            foreach (Table item in tablelist)
            {
                Button btn = new Button() { Width = TableDAO.TableWidth, Height = TableDAO.TableHeight };
                btn.Click += Btn_Click;
                btn.Tag = item;
                btn.Text = item.Name + Environment.NewLine + item.Status;
                switch (item.Status)
                {
                    case "Trống":
                        btn.BackColor = Color.Aqua;
                        break;
                    case "trống":
                        btn.BackColor = Color.Aqua;
                        break;
                    default:
                        btn.BackColor = Color.LightPink;
                        break;
                }
                flp_Talble.Controls.Add(btn);
            }
        }

        void showBill(int id)
        {
            lv_Bill.Items.Clear();
            List<Menu> listMenu = MenuDAO.Instance.GetListMenubyTable(id);

            float totalPrice = 0;
            foreach (Menu item in listMenu)
            {
                ListViewItem lvItem = new ListViewItem(item.FoodName.ToString());
                lvItem.SubItems.Add(item.Count.ToString());
                lvItem.SubItems.Add(item.Price.ToString());
                lvItem.SubItems.Add(item.TotalPrice.ToString());
                totalPrice += item.TotalPrice;
                lv_Bill.Items.Add(lvItem);
            }
            CultureInfo culture = new CultureInfo("vi-VN");
            tb_totalPrice.Text = totalPrice.ToString("c", culture);
        }

        void LoadComboBoxTable(ComboBox cb)
        {
            cb.DataSource = TableDAO.Instance.LoadTableList();
            cb.DisplayMember = "name";
        }

        #endregion



        #region Events
        private void Btn_Click(object sender, EventArgs e)
        {
            int tableID = ((sender as Button).Tag as Table).ID;
            showBill(tableID);
            lv_Bill.Tag = (sender as Button).Tag;
        }

        private void đăngXuấtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void thôngTinCáNhânToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fAccountProfile f = new fAccountProfile(LoginAccount);
            f.UpdateAccount += F_UpdateAccount;
            f.ShowDialog();
        }

        private void F_UpdateAccount(object sender, fAccountProfile.AccountEvent e)
        {
            thoongToolStripMenuItem.Text = "Thông tin tài khoản (" + e.Acc.DisplayName + ")";
        }

        private void adminToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fAdmin f = new fAdmin();

            f.InsertFood += F_InsertFood;
            f.DeleteFood += F_DeleteFood;
            f.UpdateFood += F_UpdateFood;

            f.InsertCategory += F_InsertCategory;
            f.DeleteCategory += F_DeleteCategory;
            f.UpdateCategory += F_UpdateCategory;

            f.InsertTable += F_InsertTable;
            f.DeleteTable += F_DeleteTable;
            f.UpdateTable += F_UpdateTable;

            f.loginAccount = loginAccount;

            f.ShowDialog();
        }

        private void F_UpdateTable(object sender, EventArgs e)
        {
            LoadTable();
            
        }
        private void F_DeleteTable(object sender, EventArgs e)
        {
            LoadTable();
        }
        private void F_InsertTable(object sender, EventArgs e)
        {
            LoadTable();
        }

        private void F_UpdateCategory(object sender, EventArgs e)
        {
            LoadCategogy();
            if (lv_Bill.Tag != null)
                showBill((lv_Bill.Tag as Table).ID);
        }
        private void F_DeleteCategory(object sender, EventArgs e)
        {
            LoadCategogy();
            if (lv_Bill.Tag != null)
                showBill((lv_Bill.Tag as Table).ID);
            LoadTable();
        }
        private void F_InsertCategory(object sender, EventArgs e)
        {
            LoadCategogy();
            if (lv_Bill.Tag != null)
                showBill((lv_Bill.Tag as Table).ID);
        }

        private void F_UpdateFood(object sender, EventArgs e)
        {
            LoadFoodByCategoryID((cb_Category.SelectedItem as Category).Id);
            if (lv_Bill.Tag != null)
                showBill((lv_Bill.Tag as Table).ID);
        }
        private void F_DeleteFood(object sender, EventArgs e)
        {
            LoadFoodByCategoryID((cb_Category.SelectedItem as Category).Id);
            if (lv_Bill.Tag != null)
                showBill((lv_Bill.Tag as Table).ID);
            LoadTable();
        }
        private void F_InsertFood(object sender, EventArgs e)
        {
            LoadFoodByCategoryID((cb_Category.SelectedItem as Category).Id);
            if (lv_Bill.Tag != null)
                showBill((lv_Bill.Tag as Table).ID);
        }

        private void cb_Category_SelectedIndexChanged(object sender, EventArgs e)
        {
            int id = 0;

            ComboBox cb = sender as ComboBox;

            if (cb.SelectedItem == null)
                return;

            Category selected = cb.SelectedItem as Category;
            id = selected.Id;

            LoadFoodByCategoryID(id);
        }

        private void btn_addFood_Click(object sender, EventArgs e)
        {
            Table table = lv_Bill.Tag as Table;

            if (table == null)
            {
                MessageBox.Show("Vui lòng chọn bàn!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int idBill = BillDAO.Instance.getUncheckBillIDbyTableID(table.ID);
            int idFood = (cb_Food.SelectedItem as Food).Id;
            int count = (int)nm_foodCount.Value;

            if (idBill == -1)
            {
                BillDAO.Instance.InsertBill(table.ID);
                BillInfoDAO.Instance.InsertBillInfo(BillDAO.Instance.getMaxBillID(), idFood, count);
            }
            else
            {
                BillInfoDAO.Instance.InsertBillInfo(idBill, idFood, count);
            }

            showBill(table.ID);
            LoadTable();
        }

        private void btn_check_Click(object sender, EventArgs e)
        {
            Table table = lv_Bill.Tag as Table;
            int idBill = -1;
            if (table != null)
                idBill = BillDAO.Instance.getUncheckBillIDbyTableID(table.ID);
            else
            {
                MessageBox.Show("Vui lòng chọn bàn cần thanh toán", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            int discount = (int)nm_disCount.Value;

            double totalPrice = 1000*Convert.ToDouble(tb_totalPrice.Text.ToString().Split(',')[0]);
            double finalTotalPrice = totalPrice - (totalPrice / 100) * discount;

            if (idBill != -1)
            {
                if (MessageBox.Show(string.Format("Hoá đơn cho {0} là: {1}\nSau khi giảm {2}% còn lại: {3}\nBạn có chắc muốn thanh toán hoá đơn không?", table.Name, totalPrice, discount, finalTotalPrice), "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                {
                    BillDAO.Instance.CheckOut(idBill, discount, (float)finalTotalPrice);
                    showBill(table.ID);
                    LoadTable();
                }
            }
            else
            {
                MessageBox.Show("Bàn hiện không có hoá đơn", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btn_swicthTable_Click(object sender, EventArgs e)
        {
            if(lv_Bill.Tag as Table == null)
            {
                MessageBox.Show("Vui lòng chọn bàn cần chuyển", "Thông báo", MessageBoxButtons.OK ,MessageBoxIcon.Error);
                return;
            }
            int id1 = (lv_Bill.Tag as Table).ID;
            int id2 = (cb_switchTable.SelectedItem as Table).ID;

            if (MessageBox.Show(string.Format("Bạn có thật sự muốn chuyển bàn {0} qua bàn {1} không?", (lv_Bill.Tag as Table).Name, (cb_switchTable.SelectedItem as Table).Name), "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                TableDAO.Instance.SwitchTable(id1, id2);

                LoadTable();
            }
        }
        #endregion
    }
}
