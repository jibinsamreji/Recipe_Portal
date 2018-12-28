using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Oracle.ManagedDataAccess.Client;
using System.Data;


public partial class vs_RecipeBook_Search : System.Web.UI.Page
{
    RecipeRepository _objRecipe = new RecipeRepository();
    protected void Page_Load(object sender, EventArgs e)
    {
        BindDropdown();
    }

    public void BindDropdown()
    {
        int i = 0;
        DataTable obj = _objRecipe.getRecipies();
        for(int j=0;j<obj.Rows.Count;j++)
        {
            Name.Items.Add(new ListItem { Text = obj.Rows[j]["Name"].ToString(), Value = i.ToString() });
            SubmittedBy.Items.Add(new ListItem { Text = obj.Rows[j]["SUBMITTEDBY"].ToString(), Value = i.ToString() });
        }
        Name.DataBind();
        SubmittedBy.DataBind();
        DataTable obj1 = _objRecipe.getIngredients();
        for (int j = 0; j < obj1.Rows.Count; j++)
        {
            Ingredients.Items.Add(new ListItem { Text = obj1.Rows[j]["NAME"].ToString(), Value = i.ToString() });
        }
        Ingredients.DataBind();
    }
    protected void submit_Click(object sender, EventArgs e)
    {
        DataTable obj = _objRecipe.SearchRecipe(Name.SelectedItem.Text, SubmittedBy.SelectedItem.Text, Ingredients.SelectedItem.Text);
        searchGrid.DataSource = obj;
        searchGrid.DataBind();
    }
}