using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;


namespace WebApplication1
{
    public partial class demo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void sp_clear()
        {
            this.cname.Text = "";
            this.zage.Text = "";
            this.birthday.Text = "";

        }

        protected void go_Click(object sender, EventArgs e)
        {

            string cname = (this.cname.Text.Trim());
            string zage = (this.zage.Text.Trim());
            string birthday = (this.birthday.Text.Trim());
            string kind = this.go.Text;

            string sql = "";

            if (kind == "建立帳號")
            {
                string sn = DateTime.Now.ToString("yyyyMMddHHmmss");
                sql = $"insert demo.dbo.tb1 (sn,cname, zage,birthday) values ('{sn}' ,'{cname}','{zage}','{birthday}')";
                DataTable dt = sp_executesql(sql);
                sp_clear();
            }
            if (kind == "修改帳號")
            {
                string sn = this.sn.Value;
                sql = $"update demo.dbo.tb1 set cname = '{cname }', zage ='{zage}', birthday ='{birthday}' where sn = '{sn}'";
                DataTable dt = sp_executesql(sql);
                this.go.Text = "建立帳號";
                sp_clear();
            }




            DataTable dt2 = sp_executesql("select sn, cname, zage,format(birthday,'yyyy/MM/dd') as birthday from demo.dbo.tb1");

            this.GridView1.DataSource = dt2;
            this.GridView1.DataBind();



        }

        public DataTable sp_executesql(string sql)
        {
            DataTable dt = new DataTable();
            string connstring = "Data Source=home.john0955.idv.tw,60001;User ID=demo;Password=demo;";
            using (SqlConnection conn = new SqlConnection(connstring))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(sql, conn);
                SqlDataReader dr = cmd.ExecuteReader();
                dt.Load(dr);
                conn.Close();
            }
            return dt;

        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "zedit")
            {

                int index = Convert.ToInt32(e.CommandArgument);
                GridViewRow row = GridView1.Rows[index];
                this.cname.Text = row.Cells[0].Text;
                this.zage.Text = row.Cells[1].Text;
                this.birthday.Text = row.Cells[2].Text;
                this.sn.Value = row.Cells[3].Text;

                this.go.Text = "修改帳號";
            }

            if (e.CommandName.ToString() == "zdelete")
            {
                int index = Convert.ToInt32(e.CommandArgument);
                GridViewRow row = GridView1.Rows[index];
                this.sn.Value = row.Cells[3].Text;
                string sn = this.sn.Value;

                string sql = $"delete demo.dbo.tb1 where sn = '{sn}'";
                DataTable dt = sp_executesql(sql);
                DataTable dt2 = sp_executesql("select sn, cname, zage,format(birthday,'yyyy/MM/dd') as birthday from demo.dbo.tb1");
                this.GridView1.DataSource = dt2;
                this.GridView1.DataBind();

            }

        }
    }
}