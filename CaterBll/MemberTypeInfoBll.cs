using CaterDal;
using CaterModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaterBll
{
    public partial class MemberTypeInfoBll
    {
        private MemberTypeInfoDal mtiDal ;

        public MemberTypeInfoBll()
        {
            mtiDal = new MemberTypeInfoDal();
        }
        public List<MemberTypeInfo> GetList()
        {
            return mtiDal.GetList();
        }
        public bool Add(MemberTypeInfo mti)
        {
            return mtiDal.Insert(mti) > 0;
        }
        public bool Edit(MemberTypeInfo mti)
        {
            return mtiDal.Update(mti) > 0;
        }
        public bool Remove(int id)
        {
            return mtiDal.Delete(id) > 0;
        }
    } 
}
