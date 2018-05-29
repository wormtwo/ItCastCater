using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Configuration;
using System.Data.SQLite;

namespace _01复习
{
    public static class SqliteHelper
    {
        //从配置文件中读取链接字符串
        private static string connStr = ConfigurationManager.ConnectionStrings["itcastCater"].ConnectionString;
        //执行命令的方法:insert ,update,delete
        //params:可变参数,目的是省略了手动构造数组的过程,直接指定对象,编译器会帮助我们构造数组,并将对象加入数组中,传递过来.
        public static int ExecuteNonQuery(string sql,params SQLiteParameter[] ps)
        {
            //创建链接对象
            using(SQLiteConnection conn=new SQLiteConnection(connStr))
            {
                //创建命令对象
                SQLiteCommand cmd = new SQLiteCommand(sql, conn);
                //填加参数
                cmd.Parameters.AddRange(ps);
                //打开链接
                conn.Open();
                //执行命令,并返回受影响的行数
                return cmd.ExecuteNonQuery();
            }
        }
        //获取首行首列值的方法
        public static object ExecuteScalar(string sql,params SQLiteParameter[] ps)
        {
            using (SQLiteConnection conn = new SQLiteConnection(connStr))
            {
                SQLiteCommand cmd = new SQLiteCommand(sql, conn);
                cmd.Parameters.AddRange(ps);
                //打开链接
                conn.Open();
                //执行命令,获取查询结果中的首行首列的值,返回
                return cmd.ExecuteScalar();
            }
        }

        //获取结果集
        public static DataTable GetDataTable(string sql,params SQLiteParameter[] ps)
        {
            using (SQLiteConnection conn = new SQLiteConnection(connStr))
            {
                //构造适配器对象
                SQLiteDataAdapter adapter = new SQLiteDataAdapter(sql, conn);
                //构造数据表,用于接收查询结果
                DataTable dt = new DataTable();
                //填加参数
                adapter.SelectCommand.Parameters.AddRange(ps);
                //执行结果
                adapter.Fill(dt);
                //返回结果集
                return dt;
            }
        }

        public static DataSet ExecuteQuery(string cmdText, params object[] p)
        {
            using (SQLiteConnection conn = new SQLiteConnection(connStr))
            {
                using (SQLiteCommand command = new SQLiteCommand())
                {
                    DataSet ds = new DataSet();
                    //PrepareCommand(command, conn, cmdText, p);
                    SQLiteDataAdapter da = new SQLiteDataAdapter(cmdText,conn);
                    da.Fill(ds);
                    return ds;
                }
            }
        }
    }
}
