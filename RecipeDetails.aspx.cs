using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Oracle.ManagedDataAccess.Client;
using System.Data;

public partial class RecipeDetails : System.Web.UI.Page
{
    RecipeRepository _objrepositry=new RecipeRepository();
    protected void Page_Load(object sender, EventArgs e)
    {
        String recipeName = Session["recipeName"].ToString();
        DataTable dr=_objrepositry.getDetails(recipeName);
        DetailsView1.HeaderText = recipeName;
        DetailsView1.DataSource = dr;
        int id=0;
        for (int i = 0; i < dr.Rows.Count;i++ )
        {
            id = Convert.ToInt32(dr.Rows[i]["recipeid"]);
        }
        DataTable dr1 = _objrepositry.getDIngredientDetails(id);
        DetailsView1.DataBind();
        DetailsView2.DataSource = dr1;
        DetailsView2.DataBind();




    }
    protected void DetailsView1_PageIndexChanging(object sender, DetailsViewPageEventArgs e)
    {

    }
    protected void Delete_Click(object sender, EventArgs e)
    {
        String recipeName = Session["recipeName"].ToString();
        _objrepositry.DeleteRecipe(recipeName);
        Label1.Text = "Recipe Sucessfully Deleted";
    }
}