using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using QuanLyCafe.DAO;
using QuanLyCafe.DTO;

namespace QuanLyCafe
{
    public partial class fAdmin : Form
    {
        BindingSource ListFood = new BindingSource();
        BindingSource ListCategory = new BindingSource();
        BindingSource ListTable = new BindingSource();
        BindingSource ListAccount = new BindingSource();

        public Account loginAccount;

        public fAdmin()
        {
            InitializeComponent();
            Load();
        }


        #region methods
        void Load()
        {
            dtgv_food.DataSource = ListFood;
            dtgv_Category.DataSource = ListCategory;
            dtgv_Table.DataSource = ListTable;
            dtgv_Account.DataSource = ListAccount;

            LoadDateTimePickerBill();
            LoadListBillByDate(dtp_fromDate.Value, dtp_toDate.Value);

            LoadListFood();
            LoadCategoryIntoCombobox(cb_foodCategory);
            AddFoodBinding();

            LoadListCategory();
            AddCategoryBinding();

            LoadListTable();
            AddTableBinding();

            AddAccountBinding();
            LoadAccount();
        }

        void LoadAccount()
        {
            ListAccount.DataSource = AccountDAO.Instance.GetListAccount();
        }
        void AddAccountBinding()
        {
            try
            {
                txt_userName.DataBindings.Add("Text", dtgv_Account.DataSource, "username", true, DataSourceUpdateMode.Never);
                txt_displayName.DataBindings.Add("Text", dtgv_Account.DataSource, "displayname", true, DataSourceUpdateMode.Never);
            }
            catch { }
        }

        void LoadListTable()
        {
            ListTable.DataSource = TableDAO.Instance.LoadTableList();
        }
        void AddTableBinding()
        {
            try
            {
                txt_TableID.DataBindings.Add("Text", dtgv_Table.DataSource, "id", true, DataSourceUpdateMode.Never);
                txt_TableName.DataBindings.Add("Text", dtgv_Table.DataSource, "name", true, DataSourceUpdateMode.Never);
            }
            catch { }
        }

        void LoadListCategory()
        {
            ListCategory.DataSource = CategoryDAO.Instance.GetListCategoryForDTGV();
        }
        void AddCategoryBinding()
        {
            try
            {
                txt_CategoryID.DataBindings.Add("Text", dtgv_Category.DataSource, "id", true, DataSourceUpdateMode.Never);
                txt_Category.DataBindings.Add("Text", dtgv_Category.DataSource, "Loại đồ uống", true, DataSourceUpdateMode.Never);
            }
            catch { }
        }

        List<Food> SearchFoodByName(string name)
        {
            List<Food> listFood = FoodDAO.Instance.SearchFoodByName(name);

            return listFood;
        }
        void LoadCategoryIntoCombobox(ComboBox cb)
        {
            cb.DataSource = CategoryDAO.Instance.GetListCategory();
            cb.DisplayMember = "name";
        }
        void AddFoodBinding()
        {
            txt_foodName.DataBindings.Add("Text", dtgv_food.DataSource, "name", true, DataSourceUpdateMode.Never);
            txt_foodID.DataBindings.Add("Text", dtgv_food.DataSource, "id", true, DataSourceUpdateMode.Never);
            nm_foodPrice.DataBindings.Add("Value", dtgv_food.DataSource, "price", true, DataSourceUpdateMode.Never);
        }
        void LoadListFood()
        {
            ListFood.DataSource = FoodDAO.Instance.GetListFood();
        }

        void LoadListBillByDate(DateTime checkIn, DateTime checkOut)
        {
            dtgv_bill.DataSource =  BillDAO.Instance.GetListBillByDate(checkIn, checkOut);
        }
        void LoadDateTimePickerBill()
        {
            DateTime today = DateTime.Now;
            dtp_fromDate.Value = new DateTime(today.Year, today.Month, 1);
            dtp_toDate.Value = dtp_fromDate.Value.AddMonths(1).AddDays(-1);
        }
        #endregion


        #region events
        private void btn_viewBill_Click(object sender, EventArgs e)
        {
            LoadListBillByDate(dtp_fromDate.Value, dtp_toDate.Value);
        }

        private void txt_foodID_TextChanged(object sender, EventArgs e)
        {
            if (dtgv_food.SelectedCells.Count > 0)
            {
                if (dtgv_food.SelectedCells[0].OwningRow.Cells["CategoryID"].Value == null)
                    return;
                int id = (int)dtgv_food.SelectedCells[0].OwningRow.Cells["CategoryID"].Value;
                Category category = CategoryDAO.Instance.GetCategoryByID(id);
                cb_foodCategory.Text = category.Name;
            }
        }
        private void btn_viewFood_Click(object sender, EventArgs e)
        {
            LoadListFood();
        }
        private void btn_addFood_Click(object sender, EventArgs e)
        {
            string name = txt_foodName.Text;
            int categogyID = (cb_foodCategory.SelectedItem as Category).Id;
            float price = (float)nm_foodPrice.Value;

            if(FoodDAO.Instance.InsertFood(name, categogyID, price))
            {
                MessageBox.Show("Thêm món thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.None);
                LoadListFood();
                if (insertFood != null)
                    insertFood(this, new EventArgs());
            }
            else
            {
                MessageBox.Show("Thêm thất bại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void btn_editFood_Click(object sender, EventArgs e)
        {
            string name = txt_foodName.Text;
            int categogyID = (cb_foodCategory.SelectedItem as Category).Id;
            float price = (float)nm_foodPrice.Value;
            int id = Convert.ToInt32(txt_foodID.Text);

            if (FoodDAO.Instance.UpdateFood(id, name, categogyID, price))
            {
                MessageBox.Show("Sửa món thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.None);
                LoadListFood();
                if (updateFood != null)
                    updateFood(this, new EventArgs());
            }
            else
            {
                MessageBox.Show("Sửa thất bại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void btn_deleteFood_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(txt_foodID.Text);

            if (FoodDAO.Instance.DeleteFood(id))
            {
                MessageBox.Show("Xoá món thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.None);
                LoadListFood();
                if (deleteFood != null)
                    deleteFood(this, new EventArgs());
            }
            else
            {
                MessageBox.Show("Xoá thất bại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void btn_searchFood_Click(object sender, EventArgs e)
        {
            ListFood.DataSource = SearchFoodByName(txt_searchfoodName.Text);
        }

        private event EventHandler insertFood;
        public event EventHandler InsertFood
        {
            add { insertFood += value; }
            remove { insertFood -= value; }
        }
        private event EventHandler deleteFood;
        public event EventHandler DeleteFood
        {
            add { deleteFood += value; }
            remove { deleteFood -= value; }
        }
        private event EventHandler updateFood;
        public event EventHandler UpdateFood
        {
            add { updateFood += value; }
            remove { updateFood -= value; }
        }


        private void btn_viewCategory_Click(object sender, EventArgs e)
        {
            LoadListCategory();
        }
        private void btn_addCategory_Click(object sender, EventArgs e)
        {
            string name = txt_Category.Text;

            if (CategoryDAO.Instance.InsertCategory(name))
            {
                MessageBox.Show("Thêm thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.None);
                LoadListCategory();
                LoadListFood();
                if (insertCategory != null)
                    insertCategory(this, new EventArgs());
            }
            else
            {
                MessageBox.Show("Thêm thất bại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void btn_editCategory_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(txt_CategoryID.Text);
            string name = txt_Category.Text;

            if (CategoryDAO.Instance.UpdateCategory(id, name))
            {
                MessageBox.Show("Sửa thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.None);
                LoadListCategory();
                LoadListFood();
                if (updateCategory != null)
                    updateCategory(this, new EventArgs());
            }
            else
            {
                MessageBox.Show("Sửa thất bại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void btn_deleteCategory_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(txt_CategoryID.Text);

            if (CategoryDAO.Instance.DeleteCategory(id))
            {
                MessageBox.Show("Xoá thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.None);
                LoadListCategory();
                LoadListFood();
                if (deleteCategory != null)
                    deleteCategory(this, new EventArgs());
            }
            else
            {
                MessageBox.Show("Xoá thất bại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private event EventHandler insertCategory;
        public event EventHandler InsertCategory
        {
            add { insertCategory += value; }
            remove { insertCategory -= value; }
        }
        private event EventHandler deleteCategory;
        public event EventHandler DeleteCategory
        {
            add { deleteCategory += value; }
            remove { deleteCategory -= value; }
        }
        private event EventHandler updateCategory;
        public event EventHandler UpdateCategory
        {
            add { updateCategory += value; }
            remove { updateCategory -= value; }
        }

        private void txt_TableID_TextChanged(object sender, EventArgs e)
        {
            if (dtgv_Table.SelectedCells.Count > 0)
            {
                if (dtgv_Table.SelectedCells[0].OwningRow.Cells["Status"].Value == null)
                    return;
                string status = dtgv_Table.SelectedCells[0].OwningRow.Cells["Status"].Value.ToString();
                cb_TableStatus.Text = status;
            }
        }
        private void btn_addTable_Click(object sender, EventArgs e)
        {
            string name = txt_TableName.Text;
            string status = cb_TableStatus.Text;

            if (TableDAO.Instance.InsertTable(name, status))
            {
                MessageBox.Show("Thêm thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.None);
                LoadListTable();
                if (insertTable != null)
                    insertTable(this, new EventArgs());
            }
            else
            {
                MessageBox.Show("Thêm thất bại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void btn_editTable_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(txt_TableID.Text);
            string name = txt_TableName.Text;

            if (TableDAO.Instance.UpdateTable(id, name))
            {
                MessageBox.Show("Sửa thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.None);
                LoadListTable();
                if (updateTable != null)
                    updateTable(this, new EventArgs());
                LoadListBillByDate(dtp_fromDate.Value, dtp_toDate.Value);
            }
            else
            {
                MessageBox.Show("Sửa thất bại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void btn_deleteTable_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(txt_TableID.Text);
            if (cb_TableStatus.Text == "Có người")
            {
                MessageBox.Show("Không thể xoá bàn có người!!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (TableDAO.Instance.Deletetable(id))
            {
                MessageBox.Show("Xoá thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.None);
                LoadListTable();
                if (deleteTable != null)
                    deleteTable(this, new EventArgs());
            }
            else
            {
                MessageBox.Show("Xoá thất bại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private event EventHandler insertTable;
        public event EventHandler InsertTable
        {
            add { insertTable += value; }
            remove { insertTable -= value; }
        }
        private event EventHandler deleteTable;
        public event EventHandler DeleteTable
        {
            add { deleteTable += value; }
            remove { deleteTable -= value; }
        }
        private event EventHandler updateTable;
        public event EventHandler UpdateTable
        {
            add { updateTable += value; }
            remove { updateTable -= value; }
        }

        private void txt_userName_TextChanged(object sender, EventArgs e)
        {
            if (dtgv_Account.SelectedCells.Count > 0)
            {
                if (dtgv_Account.SelectedCells[0].OwningRow.Cells["Type"].Value == null)
                    return;
                int type = (int)dtgv_Account.SelectedCells[0].OwningRow.Cells["Type"].Value;
                if (type == 0)
                    cb_AccountType.Text = "Nhân viên";
                else
                    cb_AccountType.Text = "Quản lý";
            }
        }
        private void btn_viewAccount_Click(object sender, EventArgs e)
        {
            LoadAccount();
        }
        private void btn_addAccount_Click(object sender, EventArgs e)
        {
            string name = txt_userName.Text;
            string displayname = txt_displayName.Text;
            int type;
            if (cb_AccountType.Text == "Quản lý")
                type = 1;
            else
                type = 0;

            try
            {
                AccountDAO.Instance.InsertAccount(name, displayname, type);
                MessageBox.Show("Thêm thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.None);
                LoadAccount();
            }
            catch
            {
                MessageBox.Show("Thêm thất bại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void btn_deleteAccount_Click(object sender, EventArgs e)
        {

            string name = txt_userName.Text;

            if (loginAccount.UserName == name)
            {
                MessageBox.Show("Không thể xoá tài khoản đang đăng nhập", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (AccountDAO.Instance.DeleteAccount(name))
            {
                MessageBox.Show("Xoá thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.None);
                LoadAccount();
            }
            else
            {
                MessageBox.Show("Xoá thất bại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void btn_editAccount_Click(object sender, EventArgs e)
        {
            string name = txt_userName.Text;
            string displayname = txt_displayName.Text;
            int type;
            if (cb_AccountType.Text == "Quản lý")
                type = 1;
            else
                type = 0;
            try
            {
                AccountDAO.Instance.UpdateAccount(name, displayname, type);
                MessageBox.Show("Sửa thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.None);
                LoadAccount();
            }
            catch
            {
                MessageBox.Show("Sửa thất bại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void btn_resertPassword_Click(object sender, EventArgs e)
        {
            string name = txt_userName.Text;
            try
            {
                AccountDAO.Instance.ResertPass(name);
                MessageBox.Show("Đặt lại mật khẩu thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.None);
            }
            catch
            {
                MessageBox.Show("Đặt lại mật khẩu thất bại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        #endregion

        private void fAdmin_Load(object sender, EventArgs e)
        {

            this.reportViewer1.RefreshReport();
        }
    }
}
