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
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void get_data_click(object sender, EventArgs e)
        {
            string sqlConnStr = ConfigurationManager.ConnectionStrings["db_studyConnectionString"].ConnectionString;
            SqlConnection con = new SqlConnection(sqlConnStr);
            DataSet ds = new DataSet();
            SqlDataAdapter sda = new SqlDataAdapter("select * from tb_student", con);
            sda.Fill(ds, "tb_study");
            DataRow nrow;
            Label1.Text += "   学号   " + "姓名  " + "性别  " + "年龄  " + "部门  " + "<br />"; ;
            for (int i = 0;i < ds.Tables["tb_study"].Rows.Count;i++)
            {
                nrow = ds.Tables["tb_study"].Rows[i];
                Label1.Text += nrow[0] + " ";
                Label1.Text += nrow[1] + " ";
                Label1.Text += nrow[2] + " ";
                Label1.Text += nrow[3] + " ";
                Label1.Text += nrow[4] + "<br/>";
            }
            con.Dispose();
            sda.Dispose();

        }
    }
}