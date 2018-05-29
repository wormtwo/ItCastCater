using CaterDal;
using CaterModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaterBll
{
    public partial class ManagerInfoBll
    {
        ManagerInfoDal miDal = new ManagerInfoDal();
        public List<ManagerInfo> GetList()
        {
            return miDal.GetList();
        }

        public bool Add(ManagerInfo mi)
        {
            //调用dal层的insert方法
            return miDal.Insert(mi) > 0;
        }
        public bool Edit(ManagerInfo mi)
        {
            return miDal.Update(mi) > 0;
        }
        public bool Remove(int id)
        {
            return miDal.Delete(id) > 0;
        }
    }
}
