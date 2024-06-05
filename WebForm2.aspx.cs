using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace E6

{
    
    public partial class WebForm2 : System.Web.UI.Page
    {
        //实例化ADO.NET的类
        SqlConnection con;
        SqlCommand cmd;
        SqlDataAdapter sda;
        DataSet ds;

        protected void Page_Load(object sender, EventArgs e)
        {
            //用关键字new把已经实例化的ADO.NET类初始化
            string sqlcon = ConfigurationManager.ConnectionStrings["db_studyConnectionString2"].ConnectionString; //将你连接数据库的连接字符串修改至[]中
            con = new SqlConnection(sqlcon);
            cmd = new SqlCommand();
            cmd.Connection = con;
            sda = new SqlDataAdapter("select * from tb_student", con);//tb_student为连接的数据库中创建的表
            ds = new DataSet();
            sda.Fill(ds, "tb_student");//tb_student为DataSet的DataTable数据表对象
            con.Open();
        }

        protected void Insert_click(object sender, EventArgs e)
        {
            //创建sda对象的IsertCommand命令，Parameters的字符类型要和连接的数据库的数据表每个字段的数据类型一一对应
            sda.InsertCommand = new SqlCommand("insert into tb_student (sno,sname,sex,age,dept) values(@Sno,@Sname,@Sex,@Age,@Dept)",con);
            sda.InsertCommand.Parameters.Add("@Sno", SqlDbType.Int, 50, "sno");
            sda.InsertCommand.Parameters.Add("@Sname", SqlDbType.VarChar, 50, "sname");
            sda.InsertCommand.Parameters.Add("@Sex", SqlDbType.VarChar, 50, "sex");
            sda.InsertCommand.Parameters.Add("@Age", SqlDbType.VarChar, 50, "age");
            sda.InsertCommand.Parameters.Add("@Dept", SqlDbType.VarChar, 50, "dept");
            DataRow Insert_row;
            Insert_row = ds.Tables["tb_student"].NewRow();
            Insert_row["sno"] = TextBox1.Text;
            Insert_row["sname"] = TextBox2.Text;
            Insert_row["sex"] = DropDownList1.SelectedValue;
            Insert_row["age"] = TextBox3.Text;
            Insert_row["dept"] = TextBox4.Text;
            ds.Tables["tb_student"].Rows.Add(Insert_row);
            if (sda.Update(ds, "tb_student") > 0)
            {
                Label6.Text = "信息添加成功";
            }
            else
            {
                Label6.Text = "添加失败，请重试";
            }

        }

        protected void Update_click(object sender, EventArgs e)
        {
            sda.UpdateCommand = new SqlCommand("update tb_student set sname=@Sname,sex=@Sex,age=@Age,dept=@Dept where sno=@Sno", con);
            sda.UpdateCommand.Parameters.Add("@Sname", SqlDbType.VarChar, 50, "sname");
            sda.UpdateCommand.Parameters.Add("@Sno", SqlDbType.Int, 50, "sno");
            sda.UpdateCommand.Parameters.Add("@Sex", SqlDbType.VarChar, 50, "sex");
            sda.UpdateCommand.Parameters.Add("@Dept", SqlDbType.VarChar, 50, "dept");
            sda.UpdateCommand.Parameters.Add("@Age", SqlDbType.VarChar, 50, "age");
            DataRow Update_row;
            for (int i = 0; i < ds.Tables["tb_student"].Rows.Count; i++)
            {
                Update_row = ds.Tables["tb_student"].Rows[i];
                if (Update_row["sno"].ToString() == TextBox1.Text)
                {
                    Update_row["sname"] = TextBox2.Text;
                    Update_row["sex"] = DropDownList1.Text;
                    Update_row["sex"] = TextBox3.Text;
                    Update_row["dept"] = TextBox4.Text;
                }
            
            }
            if (sda.Update(ds,"tb_student") > 0)
            {
                Label6.Text = "信息修改成功";
            }
            else
            {
                Label6.Text = "修改失败，请重试";
            }
        }

        protected void Delete_click(object sender, EventArgs e)
        {
            sda.DeleteCommand = new SqlCommand("delete from tb_student where sno=@Sno", con);
            sda.DeleteCommand.Parameters.Add("@Sno", SqlDbType.Int, 50, "sno");
            DataRow Delete_row;
            for (int i = 0; i < ds.Tables["tb_student"].Rows.Count; i++)
            {
                Delete_row = ds.Tables["tb_student"].Rows[i];
                if (Delete_row["sno"].ToString() == TextBox1.Text)
                {
                    Delete_row.Delete();
                }
            }
            if (sda.Update(ds, "tb_student") > 0)
            {
                Label6.Text = "信息删除成功";
            }
            else
            {
                Label6.Text = "删除失败，请重试";
            }
        }
    }
}