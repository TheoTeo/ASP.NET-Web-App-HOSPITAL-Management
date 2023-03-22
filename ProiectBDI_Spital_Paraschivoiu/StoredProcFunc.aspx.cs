using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection.Emit;
using System.Web;
using System.Web.DynamicData;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProiectBDI_Spital_Paraschivoiu
{
    public partial class StoredProcFunc : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnCreareProc_Click(object sender, EventArgs e)
        {
            string sqlCreate = "CREATE PROCEDURE getPacienti(@varsta INT,  @rowCount INT OUT) AS " +
               "SELECT * FROM Pacient WHERE varsta > @varsta SET @rowCount = @@ROWCOUNT";
            string connString = System.Configuration.ConfigurationManager.ConnectionStrings["spitalCS"].ToString();
            using (SqlConnection connection = new SqlConnection(connString))
            {
                connection.Open();
                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = connection;
                sqlCommand.CommandType = System.Data.CommandType.Text;
                try
                {
                    sqlCommand.CommandText = "DROP PROCEDURE getPacienti";
                    sqlCommand.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    Label1.Text = ex.Message;
                }

                sqlCommand.CommandText = sqlCreate;
                sqlCommand.ExecuteNonQuery();
                Label1.Text = "Procedura creata cu succes!";
            }
        }

        protected void btnApelProc_Click(object sender, EventArgs e)
        {
           
            string connString = System.Configuration.ConfigurationManager.ConnectionStrings["spitalCS"].ToString();
            SqlConnection connection = new SqlConnection(connString);
            connection.Open();

            SqlCommand sqlCommand = new SqlCommand("getPacienti", connection);
            sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
            sqlCommand.Parameters.Add("@varsta", System.Data.SqlDbType.Int);
            sqlCommand.Parameters[0].Direction = System.Data.ParameterDirection.Input;
            sqlCommand.Parameters[0].Value = TextBox1.Text;
            sqlCommand.Parameters.Add("@rowCount", System.Data.SqlDbType.Int);
            sqlCommand.Parameters[1].Direction = System.Data.ParameterDirection.Output;

            using (SqlDataReader dr = sqlCommand.ExecuteReader())
            {
                GridView1.DataSource = dr;
                GridView1.DataBind();
                Label3.Text = "Numarul pacientilor cu varsta peste " + TextBox1.Text+" de ani este:";
            }

            int rowCount = (int)sqlCommand.Parameters["@rowCount"].Value;
            TextBox2.Text = rowCount.ToString();

            connection.Close();
        }
    }
}