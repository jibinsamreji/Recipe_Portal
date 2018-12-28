using System;
using System.Web;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;


public partial class AddRecipe : System.Web.UI.Page
{
    RecipeRepository _objrepositary=new RecipeRepository();
    protected void Page_PreInit(object sender, EventArgs e)
    {
       
        this.Theme = "Light";
        HttpCookie myCookie = Request.Cookies["myCookie"];
        if (myCookie != null)
        {
            if (!string.IsNullOrEmpty(myCookie.Values["theme"]))
            {
                string theme = myCookie.Values["theme"].ToString();
                this.Theme = theme;
            }
        }
    }
    protected int NumberOfControls
    {
        get { return (int)ViewState["NumControls"]; }
        set { ViewState["NumControls"] = value; }
    }
  protected void Page_PreRender(object sender, EventArgs e)
    {
        foreach (Control item in IngConatainer.Controls.OfType<InlistControl>())
        {

            
                
        }

        if (!Page.IsPostBack)
        {
            this.NumberOfControls = 0;
        }
        else
        {
            foreach (Control item in IngConatainer.Controls.OfType<InlistControl>())
            {

                IngConatainer.Controls.Remove(item);

            }

            this.createIngredientControl();
        }
    }
    
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            this.NumberOfControls = 0;
        }
        else
        {
            this.createIngredientControl();
        }
    }
    private void createIngredientControl()
    {
        int count = this.NumberOfControls;

        for (int i = 1; i <= count; i++)
        {
            InlistControl tx = (InlistControl)LoadControl("~/InlistControl.ascx");
            tx.ID = "UserControlIn" + i.ToString();
            tx.EnableViewState = true;
          IngConatainer.Controls.Add(tx);
        }
    }
    public void Button_Add(object sender,EventArgs e)
    {
        if (this.NumberOfControls+1 < 15)
        {
            this.NumberOfControls++;
        }
        else
        {
            Status.Text = "Cant add more than 15 ingredients";
        }
    }
    public void Button_Remove(object sender, EventArgs e)
    {
   
        this.NumberOfControls--;
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        int time;
        List<Ingridients> ingredients1 = new List<Ingridients>();
        for (int i = 0; i <= this.NumberOfControls; i++)
        {
            string con = "UserControlIn" + i.ToString();
            InlistControl tx = (InlistControl)IngConatainer.FindControl(con);
            ingredients1.Add(new Ingridients { name = tx.TxtName, Quantity = Convert.ToInt32(tx.TxInQuantity), measureUnit = tx.IngMeasure });
        }

        if (txtCooktm.Text == "")
        {
            time = 0;
        }
        else
        {
            time = Convert.ToInt32(txtCooktm.Text);
        } 
       
        
        Recipe _objRecipe = new Recipe();
        _objRecipe.name = txtName.Text;
        _objRecipe.submittedBy = txtSubmittedby.Text;
        _objRecipe.category = txtCategory.Text;
        _objRecipe.servings = Convert.ToInt32(txtServings.Text);
        _objRecipe.time = time;
        _objRecipe.description = txtDescription.Text;
        _objRecipe.ingredients = ingredients1;
        _objrepositary.insertRecipe(_objRecipe);
        Status.Text = "Recipe added sucessfully";
    }
}