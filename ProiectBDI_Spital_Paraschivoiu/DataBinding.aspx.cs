using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection.Emit;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProiectBDI_Spital_Paraschivoiu
{
    public partial class DataBinding : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedRow = DropDownList1.SelectedValue;
            Label1.Text = "Doctorii spitalului cu specializarea " + selectedRow + " sunt:";

        }

        protected void GridView2_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow selectedRow = GridView2.SelectedRow;
/*            Label5.Text = "You have selected category " + selectedRow.Cells[2].Text + ", having " + selectedRow.Cells[3].Text + " units in stock.";
*/
            //using DataSource select method
            /*DataSourceSelectArguments args = new DataSourceSelectArguments();
            GridViewDS.SelectParameters["pret"].DefaultValue = txtPret.Text;
            DataView dataView = (DataView)GridViewDS.Select(args);

            DataTable table = dataView.ToTable();
            DataSet ds = new DataSet();
            ds.Tables.Add(table);
            GridView1.DataSourceID = null;
            GridView1.DataSource = ds;
            GridView1.DataBind();*/

            //using DataAdapter with fill method
            DataTable dt = new DataTable();
            string conn = System.Configuration.ConfigurationManager.ConnectionStrings["spitalCS"].ToString();
            using (SqlConnection sqlconn = new SqlConnection(conn))
            {
                using (SqlDataAdapter adapter = new SqlDataAdapter(programariDS.SelectCommand, sqlconn))
                {
                    adapter.SelectCommand.CommandType = CommandType.Text;
                    adapter.SelectCommand.Parameters.AddWithValue("@idDoctor", GridView2.SelectedValue);
                  //  SELECT* FROM[Produs] WHERE(([idCategorie] = @idCategorie) AND([pret] > @pret))                   
                    adapter.Fill(dt);
                    GridView3.DataSourceID = null;
                    GridView3.DataSource = dt;
                    GridView3.DataBind();
                }
            }
        }

        protected void btnInsert_Click(object sender, EventArgs e)
        {
            SqlConnection sqlConnection = new SqlConnection(doctorDS.ConnectionString);
            sqlConnection.Open();
            SqlCommand sqlCommand = new SqlCommand("INSERT INTO Doctor(numeDoctor, specializare) VALUES" +
                "(@numeDoctor, @specializare)", sqlConnection);
           /* DropDownList ddDoctor = (DropDownList)GridView2.FooterRow.FindControl("ddDoctor");*/
            TextBox txtNumeDoctor = (TextBox)GridView2.FooterRow.FindControl("TextBoxNumeDoctorInsert");
            TextBox txtSpecializare = (TextBox)GridView2.FooterRow.FindControl("TextBoxSpecializareInsert");
            sqlCommand.Parameters.Add("specializare", System.Data.SqlDbType.NVarChar);
            sqlCommand.Parameters.Add("numeDoctor", System.Data.SqlDbType.NVarChar);
          /*  sqlCommand.Parameters.Add("idDoctor", System.Data.SqlDbType.Int);*/

            sqlCommand.Parameters["specializare"].Value = txtSpecializare.Text;
            sqlCommand.Parameters["numeDoctor"].Value = txtNumeDoctor.Text;
           /* sqlCommand.Parameters["idDoctor"].Value = ddDoctor.SelectedValue;
*/
            sqlCommand.ExecuteNonQuery();

            GridView2.DataBind();
        }
    }
}