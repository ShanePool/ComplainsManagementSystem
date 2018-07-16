<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="CMS001._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron">
        <h3 style = "color: #008080" align="center">Complains management System</h3>
        
        <h4>
        </h4>
    </div>
    
    

    <div align="center" >
        <h3>Add Complaint</h3>
        
        <br />
        
        <asp:Label ID="Label9" runat="server" Text="ID" Width="80"></asp:Label>
        <asp:TextBox ID="TextBox9" runat="server"></asp:TextBox>
        <br />

        <asp:Label ID="Label1" runat="server" Text="Name" Width="80"></asp:Label>
        <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
        
        <br />
        <asp:Label ID="Label2" runat="server" Text="Address" Width="80"></asp:Label>
        <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
        <br />
        <asp:Label ID="Label3" runat="server" Text="Telephone" Width="80"></asp:Label>
        <asp:TextBox ID="TextBox4" runat="server"></asp:TextBox>
        <br />
        <asp:Label ID="Label4" runat="server" Text="Description" Width="80px" Height="80px"></asp:Label>
        <asp:TextBox ID="TextBox5" runat="server" Height="80px"></asp:TextBox>
        <br />
        <asp:Label ID="Label5" runat="server" Text="Category" Width="80"></asp:Label>
        <asp:TextBox ID="TextBox6" runat="server"></asp:TextBox>
        
        
        <asp:DropDownList ID="ddlCategory" runat="server" DataValueField="CatId" DataTextField="CatName" AppendDataBoundItems="True">
        </asp:DropDownList>
        
        
        <br />
        <asp:Label ID="Label6" runat="server" Text="Time" Width="80"></asp:Label>
        <asp:TextBox ID="TextBox7" runat="server"></asp:TextBox>
        <br />
        <asp:Label ID="Label7" runat="server" Text="Status" Width="80"></asp:Label>
        <asp:TextBox ID="TextBox8" runat="server"></asp:TextBox>
        <asp:DropDownList ID="ddlStatus" runat="server" DataValueField="StatId" DataTextField="StatName" AppendDataBoundItems="True"></asp:DropDownList>
        
        <br />
        <br />
        
        <asp:Button ID="btnSubmit" runat="server" Text="Confirm" OnClick="btnSubmit_Click" BorderWidth="20px" BorderColor="#006699" />
        <asp:Button ID="btnEdit" runat="server" Text="Edit" BorderStyle="Solid" BorderWidth="20px" Width="100px" BorderColor="#006699" OnClick="btnEdit_Click" />
        <asp:Button ID="btnDelete" runat="server" Text="Delete" BorderStyle="Solid" BorderWidth="20px" Width="100px" BorderColor="#006699" OnClick="btnDelete_Click" />
    </div>
    <br/>

    <div style="font-size: 16px; padding: 0px; margin: 5px; color: #008080" align="right">
        
        

        Filter by Name :<br />
        <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
        <asp:Button ID="go_btn" runat="server" Text="Filter" />
    </div>
    
    <div style="text-align: center" >
        <h3>Complaints List</h3>
        <asp:GridView ID="Grid_GetDetails" runat="server" Font-Size="12pt"  BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="10px" CellPadding="3" AutoGenerateColumns="False" HorizontalAlign="Center" Height="200px" OnRowCommand="Grid_GetDetails_RowCommand">
            <Columns>
                <asp:TemplateField HeaderText="ID">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("Id") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="lblId" runat="server" Text='<%# Bind("Id") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Name">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox3" runat="server" Text='<%# Bind("Name") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="lblName" runat="server" Text='<%# Bind("Name") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Address">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox4" runat="server" Text='<%# Bind("Address") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="lblAddress" runat="server" Text='<%# Bind("Address") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Telephone">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox5" runat="server" Text='<%# Bind("Tele") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="lblTelephone" runat="server" Text='<%# Bind("Tele") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Category">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox6" runat="server" Text='<%# Bind("Category") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="lblCategory" runat="server" Text='<%# Bind("Category") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Time">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox7" runat="server" Text='<%# Bind("Timestamp") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="lblTime" runat="server" Text='<%# Bind("Timestamp") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Description">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox8" runat="server" Text='<%# Bind("Description") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="lblDescription" runat="server" Text='<%# Bind("Description") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Status">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox9" runat="server" Text='<%# Bind("Status") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="lblStatus" runat="server" Text='<%# Bind("Status") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField>
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:LinkButton ID="lnkButton" runat="server" CommandName="SelectRecord" CommandArgument='<%# Bind("Id") %>'>Select</asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
            <FooterStyle BackColor="White" ForeColor="#000066" />
            <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
            <RowStyle ForeColor="#000066" />
            <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
            <SortedAscendingCellStyle BackColor="#F1F1F1" />
            <SortedAscendingHeaderStyle BackColor="#007DBB" />
            <SortedDescendingCellStyle BackColor="#CAC9C9" />
            <SortedDescendingHeaderStyle BackColor="#00547E" />
        </asp:GridView>
        
        

        <asp:HiddenField ID="hidId" runat="server"  />
        
        

        <br />
        
        

    </div>


    </asp:Content>
