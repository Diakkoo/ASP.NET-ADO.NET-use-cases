简单的ADO.NET示例代码  
通过ADO.NET控件实现网页对数据库的操作  

## 使用规范  
下载项目后，首先将“.vs”文件删除，再用Visual Studio重新生成，避免项目无法正常运行  
（如果找不到“.vs”文件，将隐藏的项目设为可见）  
![Screenshot 2024-06-05 184927](https://github.com/Diakkoo/ASP.NET-ADO.NET-use-cases/assets/167406000/a367127f-263c-44be-8f78-33ca9921dc50)    

*************

连接你的数据库，将你的连接字符串填入并覆盖WebForm2.aspx.cs的Page_Load事件中的"db_studyConnectionString2"  


```
protected void Page_Load(object sender, EventArgs e)
        {
            //用关键字new把已经实例化的ADO.NET类初始化
            string sqlcon = ConfigurationManager.ConnectionStrings["db_studyConnectionString2"].ConnectionString; //将你连接数据库的连接字符串修改至[]中
```
