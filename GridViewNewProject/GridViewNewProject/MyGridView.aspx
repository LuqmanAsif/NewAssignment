<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MyGridView.aspx.cs" Inherits="GridViewNewProject.MyGridView" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">

        <div style="text-align:center; padding:10px 10px 10px 10px; display:flex">
            <div>
                <span style="font-size:18px; color:black;">Envionment: </span>
            </div>
            <div>
                <asp:DropDownList ID="ddlenviornment" runat="server"></asp:DropDownList>
            </div>
        </div>

        <div>
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" OnRowEditing="GridView1_RowEditing" OnRowUpdating="GridView1_RowUpdating">
              <Columns>
                  <asp:BoundField DataField="name" HeaderText="Name" ReadOnly="True" />
                  <asp:TemplateField HeaderText="Deploy">
                    <ItemTemplate>
                        <asp:CheckBox ID="deploy" runat="server" Enabled="false" />
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:CheckBox ID="deployPropertyEdit" runat="server" />
                    </EditItemTemplate>
                  </asp:TemplateField>
                  <asp:TemplateField HeaderText="UpdateProperties">
                    <ItemTemplate>
                        <asp:CheckBox ID="updateproperties" runat="server" Enabled="false" />
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:CheckBox ID="updatePropertyEdit" runat="server" />
                    </EditItemTemplate>
                </asp:TemplateField>
                  <asp:TemplateField HeaderText="UpdateSharing">
                      <ItemTemplate>
                          <asp:CheckBox ID="updatesharing" runat="server" Enabled="false" />
                      </ItemTemplate>
                      <EditItemTemplate>
                          <asp:CheckBox ID="updatesharingPropertyEdit" runat="server" />
                      </EditItemTemplate>
                    </asp:TemplateField>
                  <asp:TemplateField HeaderText="UpdateCaching">
                      <ItemTemplate>
                          <asp:CheckBox ID="updatecaching" runat="server" Enabled="false" />
                      </ItemTemplate>
                      <EditItemTemplate>
                          <asp:CheckBox ID="cachingPropertyEdit" runat="server" />
                      </EditItemTemplate>
                    </asp:TemplateField>
                  <asp:TemplateField HeaderText="Tags">
                    <ItemTemplate>
                        <asp:Label ID="tags" runat="server" Text='<%# Eval("tags") %>'></asp:Label>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:TextBox ID="tagsPropertyEdit" runat="server" Text='<%# Eval("tags") %>'></asp:TextBox>
                    </EditItemTemplate>
                </asp:TemplateField>
                <asp:CommandField ShowEditButton="True" />
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:Image alt="" ImageUrl="~/Images/red.png" runat="server" ID="redimg" style="width:20%" visible="false" title="This is an red Image." />
                        <asp:Image alt="" ImageUrl="~/Images/green.png" runat="server" ID="greenimg" style="width:20%" visible="false" title="This is an red Image." />
                        <asp:Image alt="" ImageUrl="~/Images/yellow.png" runat="server" ID="yellowimg" style="width:20%" visible="false" title="This is an red Image." />
                    </ItemTemplate>
                </asp:TemplateField>

              </Columns>
            </asp:GridView>
        </div>
         <div style="align-content:center">
                <asp:Button ID="deploybutton" OnClick="deploybutton_Click" runat="server" Text="DEPLOY" />
         </div>
    </form>
    
   
</body>
</html>
