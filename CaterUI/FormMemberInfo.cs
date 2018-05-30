using CaterBll;
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
    public partial class FormMemberInfo : Form
    {
        public FormMemberInfo()
        {
            InitializeComponent();
        }
        MemberInfoBll miBll = new MemberInfoBll();
        private void FormMemberInfo_Load(object sender, EventArgs e)
        {
            LoadList();
        }
        private void LoadList()
        {
            //使用键值对存储条件
            Dictionary<string, string> dic = new Dictionary<string, string>();

            //收集用户名信息
            if (txtNameSearch.Text!="")
            {
                //需要根据名称搜索
                dic.Add("mname", txtNameSearch.Text);
            }
            //手机电话信息
            if (txtPhoneSearch.Text!="")
            {
                dic.Add("MPhone", txtPhoneSearch.Text);
            }
            //根据条件进行查询

            dgvList.AutoGenerateColumns = false;
            dgvList.DataSource = miBll.GetList(dic);
        }

        private void txtNameSearch_TextChanged(object sender, EventArgs e)
        {
            //内容改变事件
            LoadList();
        }

        private void txtNameSearch_Leave(object sender, EventArgs e)
        {
            //失去焦点事件
            LoadList();
        }

        private void btnSearchAll_Click(object sender, EventArgs e)
        {
            txtNameSearch.Text = "";
            txtPhoneSearch.Text = "";
            LoadList();
        }

        private void txtPhoneSearch_TextChanged(object sender, EventArgs e)
        {
            LoadList();
        }

        private void txtPhoneSearch_Leave(object sender, EventArgs e)
        {
            LoadList();
        }
    }
}
