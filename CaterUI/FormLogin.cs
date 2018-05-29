using CaterBll;
using CaterModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CaterUI
{
    public partial class FormLogin : Form
    {
        public FormLogin()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            //获取用户输入的信息
            string name = txtName.Text;
            string pwd = txtPwd.Text;
            //调用代码
            ManagerInfoBll miBll = new ManagerInfoBll();
            LoginState loginState = miBll.Login(name, pwd);
            switch (loginState)
            {
                case LoginState.Ok:
                    FormMain main = new FormMain();
                    main.Show();
                    //将登陆窗体隐藏
                    this.Hide();
                    break;
                case LoginState.NameError:
                    MessageBox.Show("用户名错误");
                    break;
                case LoginState.PwdError:
                    MessageBox.Show("密码错误");
                    break;
              
            }
        }
    }
}
