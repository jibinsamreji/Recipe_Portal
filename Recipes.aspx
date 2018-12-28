<%@ Page  Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Recipes.aspx.cs" Inherits="Recipes" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <!-- <link href="Content/recipe.css" rel="stylesheet" />-->
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

     <div><h1>Recipes</h1>
         
     </div><div class="datagrid">
         <asp:GridView ID="RecipeGrid" runat="server" AutoGenerateColumns="False" CellPadding="4" CellSpacing="4" EnableTheming="True" ForeColor="#000099" GridLines="None" HorizontalAlign="Center" OnSelectedIndexChanged="RecipeGrid_SelectedIndexChanged" Width="1049px">
             <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
             <Columns>
                 <asp:BoundField HeaderText="Name" DataField="Name" HtmlEncode="False"></asp:BoundField>
                 <asp:BoundField HeaderText="SubmittedBy" DataField="SubmittedBy" InsertVisible="False"></asp:BoundField>
                 <asp:BoundField HeaderText="Category" DataField="Category"></asp:BoundField>
                 <asp:BoundField DataField="CookTime" HeaderText="Cook Time" />
                 <asp:BoundField DataField="noservings" HeaderText="Number of Servings" />
                 <asp:BoundField DataField="description" HeaderText="Description" />
                 <asp:ButtonField CommandName="Select" ShowHeader="True" Text="Details"></asp:ButtonField>
             </Columns>
             
             <EditRowStyle BackColor="#999999" />
             <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
             <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
             <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
             <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
             <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
             <SortedAscendingCellStyle BackColor="#E9E7E2" />
             <SortedAscendingHeaderStyle BackColor="#506C8C" />
             <SortedDescendingCellStyle BackColor="#FFFDF8" />
             <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
             
         </asp:GridView>
    
   </div>
    
</asp:Content>

