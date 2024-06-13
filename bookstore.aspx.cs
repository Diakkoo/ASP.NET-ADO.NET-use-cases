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
            ds.ReadXml(Server.MapPath("booklibrary.xml"));
            DataRow row = ds.Tables[0].Rows[e.RowIndex];
            ds.Tables[0].Rows.Remove(row);
            WriteXmlFile(ds, "booklibrary.xml");
            GridViewDataBind("booklibrary.xml",-1);
        }

        protected void GVediting(object sender, GridViewEditEventArgs e)
        {
            GridViewDataBind("booklibrary.xml", e.NewEditIndex);
        }

        protected void GVupdating(object sender, GridViewUpdateEventArgs e)
        {
            DataSet ds = new DataSet();
            ds.ReadXml(Server.MapPath("booklibrary.xml"));
            int count = ds.Tables[0].Rows.Count;
            DataRow row;
            if (!btnInsert.Visible)
            {
                row = ds.Tables[0].NewRow();
                ds.Tables[0].Rows.Add(row);
                int No = Convert.ToInt32(ds.Tables[0].Rows[count - 2]["No"]) - 1;
                row["No"] = No;
                btnInsert.Visible = true;
            }
            else
            {
                row = ds.Tables[0].Rows[count - 1];
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
        private void GridViewDataBind(string xmlFileName, int editIndex)
        {
            DataSet ds2 = new DataSet();
            ds2.ReadXml(Server.MapPath(xmlFileName));
            GridView1.DataSource = ds2.Tables[0];
            GridView1.EditIndex = editIndex;
            GridView1.DataBind();
        }
        private void GridViewBind(string xmlFileName)
        {
            ds.ReadXml(Server.MapPath(xmlFileName));
            int count = ds.Tables[0].Rows.Count;
            int No = Convert.ToInt32(ds.Tables[0].Rows[count - 1]["No"]) + 1;
            ds.Tables[0].Rows.Add(No);
            GridView1.DataSource = ds.Tables[0];
            GridView1.EditIndex = count;
            GridView1.DataBind();
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