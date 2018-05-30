using CasterDal;
using CaterModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaterDal
{
   public partial class MemberInfoDal
    {
        public List<MemberInfo> GetList(Dictionary<string,string>dic)
        {
            string sql = "select mi.*,mti.mTitle as MTypeTitle " +
                               "from MemberInfo as mi " +
                               "inner join MemberTypeInfo as mti " +
                               "on mi.mTypeId = mti.mid " +
                               "where mi.mIsDelete=0 ";
            //拼接条件
            if (dic.Count>0)
            {
                foreach (var pair in dic)
                {
                    sql += " and " + pair.Key + " like '%" + pair.Value + "%' ";
                }
            }


            DataTable dt = SqliteHelper.GetDataTable(sql);
            List<MemberInfo> list = new List<MemberInfo>();
            foreach (DataRow row in dt.Rows)
            {
                list.Add(new MemberInfo()
                {
                    MId = Convert.ToInt32(row["mid"]),
                    MName = row["mname"].ToString(),
                    MPhone = row["mphone"].ToString(),
                    MMoney = Convert.ToDecimal(row["mmoney"]),
                    MTypeId = Convert.ToInt32(row["mTypeId"]),
                    MTypeTitle = row["MTypeTitle"].ToString()
                });
            }
            return list;
        }
    }
}
