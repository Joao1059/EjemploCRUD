using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EjemploCRUDGridViewInLine
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }


        protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            int IdRow = Convert.ToInt32(GridView1.Rows[e.RowIndex].Cells[1].Text);
            TextBox txtDescripcion = (TextBox)GridView1.Rows[e.RowIndex].Cells[2].Controls[0];
            
            SqlDataSource1.UpdateCommand = "UPDATE [dbo].[Pais] SET Descripcion = '" + txtDescripcion.Text.Trim() + "' WHERE id = " + IdRow;
            GridView1.DataBind();
        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int IdRow = Convert.ToInt32(GridView1.Rows[e.RowIndex].Cells[1].Text);

            SqlDataSource1.DeleteCommand = "DELETE FROM [dbo].[Pais] WHERE id =" + IdRow;
            GridView1.DataBind();
        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {

            if (e.CommandName == "New") {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "myscript", "alert('Crear nuevo registro');", true);
            }

        }
    }
}