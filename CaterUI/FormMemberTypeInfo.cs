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
    public partial class FormMemberTypeInfo : Form
    {
        MemberTypeInfoBll mtiBll = new MemberTypeInfoBll();
        public  FormMemberTypeInfo()
        {
            InitializeComponent();
        }
       

        private void FormMemberTypeInfo_Load(object sender, EventArgs e)
        {
            LoadList();
        }
        private void LoadList()
        {
           
            dgvList.AutoGenerateColumns = false;
            dgvList.DataSource= mtiBll.GetList();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            MemberTypeInfo mti = new MemberTypeInfo()
            {
                MTitle = txtTitle.Text,
                MDiscount = Convert.ToDecimal(txtDiscount.Text),

            };
            if (txtId.Text.Equals("添加时无编号"))
            {
                //添加
               
                if (mtiBll.Add(mti))
                {
                    LoadList();
                }
                else
                {
                    MessageBox.Show("添加失败");
                }
            }
            else
            {
                //修改
                mti.MId = int.Parse(txtId.Text);
                //调用修改的方法
                if (mtiBll.Edit(mti))
                {
                    LoadList();
                }
                else
                {
                    MessageBox.Show("修改失败");
                }
                
            }
            //将控件还原
            txtId.Text = "添加时无编号";
            txtTitle.Text = "";
            txtDiscount.Text = "";
            btnSave.Text = "添加";
        }

        private void dgvList_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            var row = dgvList.Rows[e.RowIndex];
            txtId.Text = row.Cells[0].Value.ToString();
            txtTitle.Text = row.Cells[1].Value.ToString();
            txtDiscount.Text = row.Cells[2].Value.ToString();
            btnSave.Text = "修改";
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            var row=dgvList.SelectedRows[0];
            int id = Convert.ToInt32(row.Cells[0].Value);
            DialogResult result= MessageBox.Show("确定要删除吗?", "提示", MessageBoxButtons.OKCancel);
            if (result==DialogResult.Cancel)
            {
                return;
            }
            if (mtiBll.Remove(id))
            {
                LoadList();
            }
            else
            {
                MessageBox.Show("删除失败");
            }
        }

       
    }
}
