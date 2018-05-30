using CaterDal;
using CaterModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaterBll
{
   public partial class MemberInfoBll
    {
        private MemberInfoDal miDal = new MemberInfoDal();
        public List<MemberInfo> GetList(Dictionary<string,string>dic)
        {
            return miDal.GetList(dic);
        }
    }
}
