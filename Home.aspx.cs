﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Home : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void Page_PreInit(object sender, EventArgs e)
    {
        /*switch (Request.QueryString["theme"])
        {
            case "Dark":
                Page.Theme = "Dark";
                break;
            case "Red":
                Page.Theme = "Red";
                break;
        }*/
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
}