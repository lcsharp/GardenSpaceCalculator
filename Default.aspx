<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>


<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="jumbotron">
        <h2>Garden Space Calculator</h2>
        <h3>How much space will you need?</h3>
        <p class="lead">Choose a vegetable from the list and then enter<br />
                        the quantity you intend to plant of that vegetable.<br /> 
                        Click the "Add To List" button and the vegetable <br />
                        and quantity will be added to the list and the total <br />
                        square footage requirement will be updated.
        </p>
        <asp:Panel ID="Panel1" runat="server" CssClass="floatLeft" Width="176px">
            <asp:DropDownList ID="vegetableList" runat="server" Height="32px" Width="146px" ToolTip="Choose a vegetable">
                <asp:ListItem Value="Peppers">Peppers</asp:ListItem>
                <asp:ListItem Value="Tomatoes">Tomatoes</asp:ListItem>
                <asp:ListItem Value="Beans">Beans</asp:ListItem>
                <asp:ListItem>Squash</asp:ListItem>
            </asp:DropDownList>
            <br />
            <asp:TextBox ID="quantityInput" runat="server" TextMode="Number" ToolTip="Enter a quantity" Width="146px" Height="30px">1</asp:TextBox>           
            <br />
            <asp:Button ID="addButton" runat="server" CssClass=marginLeft45 Text="Add To List" ToolTip="Add vegetable and quantity to list" Font-Size="Medium" Height="30px" OnClick="addButton_Click" />  
            <br />
            <asp:Button ID="clearButton" runat="server" CssClass=marginLeft80 Text="Reset" ToolTip="Remove all vegetables and start over" Font-Size="Medium" Height="30px" OnClick="clearButton_Click" />         
        </asp:Panel>
        <asp:Panel ID="Panel2" runat="server" CssClass="paddingTop">
            <asp:ListBox ID="vegetableListBox" runat="server" Width="174px" Font-Size="Medium">
            </asp:ListBox>
            <br />
        

        </asp:Panel>
        <br />
        <br />
        <br />
        <asp:Label ID="Label1" runat="server" Text="Total: "></asp:Label>
        <asp:Label ID="total" runat="server">0</asp:Label>
        <br />
        <br />
    </div>
</asp:Content>
