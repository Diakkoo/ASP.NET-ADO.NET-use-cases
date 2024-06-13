using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Xml;

namespace E6
{
    
    public partial class bookstore : System.Web.UI.Page
    {
        DataSet ds;
        protected void Page_Load(object sender, EventArgs e)
        {
            ds = new DataSet();
            if (!IsPostBack)  //如果页面第一次加载
            {
                GridViewDataBind("booklibrary.xml",-1);
            }
        }


        protected void GVdeleting(object sender, GridViewDeleteEventArgs e)
        {
            ds.ReadXml(Server.MapPath("booklibrary.xml"));  //将路径里的xml文件的内容填充到ds 
            DataRow row = ds.Tables[0].Rows[e.RowIndex];    //获取要删除的数据
            ds.Tables[0].Rows.Remove(row);                  //在ds中删除row对应的数据
            WriteXmlFile(ds, "booklibrary.xml");            //对booklibrary.xml更新数据
            GridViewDataBind("booklibrary.xml",-1);         //显示执行删除后的表
        }

        protected void GVediting(object sender, GridViewEditEventArgs e)
        {
            GridViewDataBind("booklibrary.xml", e.NewEditIndex);
        }

        protected void GVupdating(object sender, GridViewUpdateEventArgs e)
        {
            DataSet ds = new DataSet();                      //重新将ds初始化
            ds.ReadXml(Server.MapPath("booklibrary.xml"));
            int count = ds.Tables[0].Rows.Count;
            DataRow row;
            if (!btnInsert.Visible)                          //如果按钮不可视
            {
                row = ds.Tables[0].NewRow();                 //为受编辑的数据行创建新一行
                ds.Tables[0].Rows.Add(row);                  //将新一行添加进ds
                int No = Convert.ToInt32(ds.Tables[0].Rows[count - 2]["No"]) + 1;
                row["No"] = No;
                btnInsert.Visible = true;
            }
            else                                             //如果按钮可视
            {
                row = ds.Tables[0].Rows[count - 1];          //将最后一行数据修改为编辑后的数据
            }
            row["title"] = e.NewValues[0];
            row["author"] = e.NewValues[1];
            row["price"] = e.NewValues[2];
            row["genre"] = e.NewValues[3];
            row["ISBN"] = e.NewValues[4];
            WriteXmlFile(ds, "booklibrary.xml");
            GridViewDataBind("booklibrary.xml", -1);
        }

        protected void btnInsert_Click(object sender, EventArgs e)
        {
            btnInsert.Visible = false;
            GridViewBind("booklibrary.xml");
        }

        protected void GVcancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GridViewDataBind("booklibrary.xml", -1);
        }
        private void GridViewDataBind(string xmlFileName, int editIndex)          //定义了一个名为 GridViewDataBind 的对象，用于绑定数据到 GridView 控件
        {
            DataSet ds2 = new DataSet();
            ds2.ReadXml(Server.MapPath(xmlFileName));                             //将路径里的xml文件的内容填充到ds2
            GridView1.DataSource = ds2.Tables[0];                                 //将GridView的数据源绑定在ds2的第一个表
            GridView1.EditIndex = editIndex;                                      //将编辑事件的索引值设为指定的索引值
            GridView1.DataBind();                                                 // 绑定数据到 GridView
        }
        private void GridViewBind(string xmlFileName)
        {
            ds.ReadXml(Server.MapPath(xmlFileName));                              //将路径里的xml文件的内容填充到ds
            int count = ds.Tables[0].Rows.Count;
            int No = Convert.ToInt32(ds.Tables[0].Rows[count - 1]["No"]) + 1;     // 获取最后一行的 "No" 列的值，并将其转换为整数，然后加 1
            ds.Tables[0].Rows.Add(No);                                            //在ds的第一个表中添加一行数据
            GridView1.DataSource = ds.Tables[0];                                  //将GridView的数据源绑定在ds2的第一个表
            GridView1.EditIndex = count;                                          //将编辑事件的索引值设为count
            GridView1.DataBind();                                                 // 绑定数据到 GridView
        }
        public void WriteXmlFile(DataSet ds, string xmlFilePath)
        {
            //string filePath = Server.MapPath(xmlFilePath);
            if (ds.Tables[0].Rows.Count > 0)
            {
                string xmlstring = "<?xml version='1.0' encoding='utf-8' ?><booklibrary></booklibrary>";
                XmlDocument xml = new XmlDocument();
                xml.LoadXml(xmlstring);
                XmlDocumentFragment xdf = xml.CreateDocumentFragment();
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    string xmlst = string.Format("<book genre='{0}' ISBN='{1}'><No>{2}</No> <title>{3}</title> <author>{4}</author> <price>{5}</price> </book>", ds.Tables[0].Rows[i]["genre"], ds.Tables[0].Rows[i]["ISBN"], ds.Tables[0].Rows[i]["No"], ds.Tables[0].Rows[i]["title"], ds.Tables[0].Rows[i]["author"], ds.Tables[0].Rows[i]["price"]);
                    xdf.InnerXml = xmlst;
                    xml.DocumentElement.AppendChild(xdf);
                }
                xml.Save(Server.MapPath(xmlFilePath));
            }
        }


    }
    
}