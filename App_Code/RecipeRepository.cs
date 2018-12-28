using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Oracle.ManagedDataAccess.Client;
using Oracle.ManagedDataAccess.Types;
using System.Data;
/// <summary>
/// Summary description for RecipeRepository
/// </summary>
public class RecipeRepository
{
    public RecipeRepository()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    public void insertRecipe(Recipe recipe)
    { 
        String conString = System.Configuration.ConfigurationManager.ConnectionStrings["recipeBook"].ToString();
        OracleConnection conn=new OracleConnection(conString);
        OracleCommand cmd=new OracleCommand();

        try
        {

            cmd = new OracleCommand();
            cmd.Connection = conn;
            cmd.CommandText = "PROC_INSERTRECIPE";
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.Add("NAME", OracleDbType.Varchar2, System.Data.ParameterDirection.Input).Value = recipe.name;
            cmd.Parameters.Add("SUBMITTEDBY", OracleDbType.Varchar2, System.Data.ParameterDirection.Input).Value = recipe.submittedBy;
            cmd.Parameters.Add("category", OracleDbType.Varchar2, System.Data.ParameterDirection.Input).Value = recipe.category;
            cmd.Parameters.Add("COOKTIME", OracleDbType.Int32, System.Data.ParameterDirection.Input).Value = recipe.time;
            cmd.Parameters.Add("NOSERVINGS", OracleDbType.Int32, System.Data.ParameterDirection.Input).Value = recipe.servings;
            cmd.Parameters.Add("DESCRIPTION", OracleDbType.Varchar2, System.Data.ParameterDirection.Input).Value = recipe.description;
            cmd.Connection.Open();
            cmd.ExecuteNonQuery();
            foreach(Ingridients ingredient in recipe.ingredients)
            {
                OracleCommand cmd1=new OracleCommand();
                cmd1.Connection = conn;
                cmd1.CommandText = "PROC_INSERTINGREDIENTS";
                cmd1.CommandType = System.Data.CommandType.StoredProcedure;
                cmd1.Parameters.Add("NAME", OracleDbType.Varchar2, System.Data.ParameterDirection.Input).Value = ingredient.name;
                cmd1.Parameters.Add("QUANTITY",OracleDbType.Double, System.Data.ParameterDirection.Input).Value = ingredient.Quantity;
                cmd1.Parameters.Add("MEASUREUNITS", OracleDbType.Varchar2, System.Data.ParameterDirection.Input).Value = ingredient.measureUnit;
                cmd1.ExecuteNonQuery();
        
            }
            conn.Close();

        }
        catch(Exception e)
        {

        }
        finally
        {
          conn.Close();
            cmd.Dispose();
            
        }
       
    }
    public DataTable getIngredients()
    {
        String conString = System.Configuration.ConfigurationManager.ConnectionStrings["recipeBook"].ToString();
        OracleConnection conn = new OracleConnection(conString);

        // create the command for the stored procedure
        OracleCommand cmd = new OracleCommand();
        cmd.Connection = conn;
        cmd.CommandText = "PROC_GETINGREDIENTS";
        cmd.CommandType = System.Data.CommandType.StoredProcedure;

        // add the parameters for the stored procedure including the REF CURSOR
        // to retrieve the result set
        cmd.Parameters.Add("p_cursor", OracleDbType.RefCursor).Direction =
            System.Data.ParameterDirection.Output;
        // open the connection and create the DataReader
        conn.Open();
        OracleDataAdapter ad = new OracleDataAdapter(cmd);

        DataTable dt = new DataTable();
        ad.Fill(dt);
        return dt;
    }
    public DataTable SearchRecipe(String Name, String Submittedby, String ingredients)
    {
        String conString = System.Configuration.ConfigurationManager.ConnectionStrings["recipeBook"].ToString();
        OracleConnection conn = new OracleConnection(conString);
        OracleCommand cmd = new OracleCommand();
        cmd.Connection = conn;
        cmd.CommandText = "PROC_GETSEARCHEDRECIPE ";
        cmd.CommandType = System.Data.CommandType.StoredProcedure;
        cmd.Parameters.Add("RNAME", OracleDbType.Varchar2, System.Data.ParameterDirection.Input).Value = Name;
        cmd.Parameters.Add("SUBMITTEDBY", OracleDbType.Varchar2, System.Data.ParameterDirection.Input).Value = Submittedby;
        cmd.Parameters.Add("INAME", OracleDbType.Varchar2, System.Data.ParameterDirection.Input).Value = ingredients;
        cmd.Parameters.Add("p_cursor", OracleDbType.RefCursor).Direction =
            System.Data.ParameterDirection.Output;
        conn.Open();
        OracleDataAdapter ad = new OracleDataAdapter(cmd);

        DataTable dt = new DataTable();
        ad.Fill(dt);
        conn.Close();
        return dt;
    }

    public DataTable getDIngredientDetails(int id)
    {
        String conString = System.Configuration.ConfigurationManager.ConnectionStrings["recipeBook"].ToString();
        OracleConnection conn = new OracleConnection(conString);
        OracleCommand cmd = new OracleCommand();
        cmd.Connection = conn;
        cmd.CommandText = "PROC_RECIPEDETAILS";
        cmd.CommandType = System.Data.CommandType.StoredProcedure;
        cmd.Parameters.Add("rid", OracleDbType.Int32, System.Data.ParameterDirection.Input).Value = id;
        cmd.Parameters.Add("p_cursor", OracleDbType.RefCursor).Direction =
            System.Data.ParameterDirection.Output;
        conn.Open();
        OracleDataAdapter ad = new OracleDataAdapter(cmd);

        DataTable dt = new DataTable();
        ad.Fill(dt);
        conn.Close();
        return dt;
    }
    public DataTable getDetails(String Name)
    {
        String conString = System.Configuration.ConfigurationManager.ConnectionStrings["recipeBook"].ToString();
        OracleConnection conn = new OracleConnection(conString);
        OracleCommand cmd = new OracleCommand();
        cmd.Connection = conn;
        cmd.CommandText = "PROC_RECIPEDETAILS";
        cmd.CommandType = System.Data.CommandType.StoredProcedure;
        cmd.Parameters.Add("RNAME", OracleDbType.Varchar2, System.Data.ParameterDirection.Input).Value = Name;
        cmd.Parameters.Add("p_cursor", OracleDbType.RefCursor).Direction =
            System.Data.ParameterDirection.Output;
        conn.Open();
        OracleDataAdapter ad = new OracleDataAdapter(cmd);

        DataTable dt = new DataTable();
        ad.Fill(dt);
        conn.Close();
        return dt;
    }
    public void DeleteRecipe(String Name)
    {
        String conString = System.Configuration.ConfigurationManager.ConnectionStrings["recipeBook"].ToString();
        OracleConnection conn = new OracleConnection(conString);
        OracleCommand cmd = new OracleCommand();
        cmd.Connection = conn;
        cmd.CommandText = "PROC_DELETERECIPE";
        cmd.CommandType = System.Data.CommandType.StoredProcedure;
        cmd.Parameters.Add("RNAME", OracleDbType.Varchar2, System.Data.ParameterDirection.Input).Value = Name;
        conn.Open();
        cmd.ExecuteNonQuery();
        conn.Close();
        
    }
    public DataTable getRecipies()
    {
        String conString = System.Configuration.ConfigurationManager.ConnectionStrings["recipeBook"].ToString();
        OracleConnection conn = new OracleConnection(conString);

        // create the command for the stored procedure
        OracleCommand cmd = new OracleCommand();
        cmd.Connection = conn;
        cmd.CommandText = "PROC_GETRECIPIES";
        cmd.CommandType = System.Data.CommandType.StoredProcedure;

        // add the parameters for the stored procedure including the REF CURSOR
        // to retrieve the result set
        cmd.Parameters.Add("p_cursor", OracleDbType.RefCursor).Direction =
            System.Data.ParameterDirection.Output;

        // open the connection and create the DataReader
        conn.Open();
        OracleDataAdapter ad=new OracleDataAdapter(cmd);
 
        DataTable dt=new DataTable();
        ad.Fill(dt);
     

        conn.Close();
        return dt;
    }
}