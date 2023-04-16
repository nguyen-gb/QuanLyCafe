using QuanLyCafe.DAO;
using QuanLyCafe.DTO;
using System;
using System.Windows.Forms;

namespace QuanLyCafe
{
    public partial class fAccountProfile : Form
    {
        private Account loginAccount;
        public fAccountProfile(Account acc)
        {
            InitializeComponent();
            this.LoginAccount = acc;
            ChangeAccount(acc);
        }

        public Account LoginAccount { get => loginAccount; set => loginAccount = value; }
        public bool AccoutDAO { get; private set; }

        private void btn_Exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        void ChangeAccount(Account loginAccount)
        {
            txt_UserName.Text = loginAccount.UserName;
            txt_displayName.Text = loginAccount.DisplayName;
        }

        void UpdateAccountInfo()
        {
            string displayName = txt_displayName.Text;
            string password = txt_PassWork.Text;
            string newPassword = txt_newPassWork.Text;
            string reEnterPass = txt_reEnterPass.Text;
            string userName = txt_UserName.Text;
            if (!newPassword.Equals(reEnterPass))
            {
                MessageBox.Show("Vui lòng nhập lại mật khẩu đúng với mật khẩu mới", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                if (AccountDAO.Instance.UpdateAccount(userName, displayName, password, newPassword))
                {
                    MessageBox.Show("Cập nhật thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.None);
                    if (updateAccount != null)
                    {
                        updateAccount(this, new AccountEvent(AccountDAO.Instance.GetAccountByUserName(userName)));
                    }
                }
                else
                {
                    MessageBox.Show("Vui lòng nhập đúng mật khẩu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void btn_Update_Click(object sender, EventArgs e)
        {
            UpdateAccountInfo();
        }

        private event EventHandler<AccountEvent> updateAccount;
        public event EventHandler<AccountEvent> UpdateAccount
        {
            add { updateAccount += value; }
            remove { updateAccount += value; }
        }

        public class AccountEvent : EventArgs
        {
            private Account acc;

            public Account Acc { get => acc; set => acc = value; }

            public AccountEvent(Account acc)
            {
                this.Acc = acc;
            }
        }
        private void fAccountProfile_Load(object sender, EventArgs e)
        {
            txt_PassWork.Focus();
        }
    }
}
