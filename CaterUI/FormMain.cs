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
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
        }

        private void FormMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            //将当前应用程序退出,而不仅是关闭当前窗体
            Application.Exit();
        }

        private void menuQuit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            //判断登陆进来的员工级别,确定是否显示管理图标
            int type = Convert.ToInt32(this.Tag);
            if (type==1)
            {
                //经理
            }
            else
            {
                //店员,管理菜单不需要显示
                menuManagerInfo.Visible = false;
            }
        }

        private void menuManagerInfo_Click(object sender, EventArgs e)
        {
            FormManagerInfo formManagerInfo = FormManagerInfo.Create();
            formManagerInfo.Show();
            formManagerInfo.Focus();
        }
    }
}
