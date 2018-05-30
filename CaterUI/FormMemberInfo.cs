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
    public partial class FormMemberInfo : Form
    {
        public FormMemberInfo()
        {
            InitializeComponent();
        }
        MemberInfoBll miBll = new MemberInfoBll();
        private void FormMemberInfo_Load(object sender, EventArgs e)
        {
            //加载会员信息
            LoadList();
            //加载会员分类信息
            LoadTypeList();
        }
        private void LoadTypeList()
        {
            MemberTypeInfoBll mtiBll = new MemberTypeInfoBll();
            List<MemberTypeInfo> list = mtiBll.GetList();
            ddlType.DataSource = list;
            //设置显示值
            ddlType.DisplayMember = "mtitle";
            //设置value值
            ddlType.ValueMember = "mid";
            
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

        private void btnSave_Click(object sender, EventArgs e)
        {
            //值的有效性判断
            if (txtNameAdd.Text=="")
            {
                MessageBox.Show("请输入会员名称");
                txtNameAdd.Focus();
                return;
            }
            //接收用户输入的数据
            MemberInfo mi = new MemberInfo()
            {
                MName=txtNameAdd.Text,
                MPhone=txtPhoneAdd.Text,
                MMoney=Convert.ToDecimal(txtMoney.Text),
                MTypeId=Convert.ToInt32(ddlType.SelectedValue)
                
            };
            if (txtId.Text.Equals("添加时无编号"))
            {
                #region 添加
                if(miBll.Add(mi))
                {
                    LoadList();
                }
                else
                {
                    MessageBox.Show("添加失败,请稍后重试");
                }
                #endregion
            }
            else
            {
                #region 修改
                mi.MId = int.Parse(txtId.Text);
                if (miBll.Edit(mi))
                {
                    LoadList();
                }
                else
                {
                    MessageBox.Show("修改失败");
                }
                #endregion
            }
            //回复控件的值
            txtId.Text = "添加时无编号";
            txtNameAdd.Text = "";
            txtPhoneAdd.Text = "";
            txtMoney.Text = "";
            ddlType.SelectedIndex = 0;
            btnSave.Text = "添加";
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            //回复控件的值
            txtId.Text = "添加时无编号";
            txtNameAdd.Text = "";
            txtPhoneAdd.Text = "";
            txtMoney.Text = "";
            ddlType.SelectedIndex = 0;
            btnSave.Text = "添加";
        }

        private void dgvList_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
           var row= dgvList.Rows[e.RowIndex];
            txtId.Text = row.Cells[0].Value.ToString();
            txtNameAdd.Text = row.Cells[1].Value.ToString();
            ddlType.Text = row.Cells[2].Value.ToString();
            txtPhoneAdd.Text = row.Cells[3].Value.ToString();
            txtMoney.Text = row.Cells[4].Value.ToString();
            btnSave.Text = "修改";
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(dgvList.SelectedRows[0].Cells[0].Value);
            //先提示确认
            DialogResult result = MessageBox.Show("确定要删除吗?", "提示", MessageBoxButtons.OKCancel);
            if (result==DialogResult.Cancel)
            {
                return;
            }
            if (miBll.Remove(id))
            {
                LoadList();
            }
            else
            {
                MessageBox.Show("失败");
            }
        }

        private void btnAddType_Click(object sender, EventArgs e)
        {
            FormMemberTypeInfo formMti = new FormMemberTypeInfo();
            formMti.ShowDialog();
            LoadTypeList();
        }
    }
}
