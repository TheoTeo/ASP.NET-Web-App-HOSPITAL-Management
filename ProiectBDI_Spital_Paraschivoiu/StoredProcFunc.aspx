<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="StoredProcFunc.aspx.cs" Inherits="ProiectBDI_Spital_Paraschivoiu.StoredProcFunc" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Button ID="btnCreareProc" runat="server" OnClick="btnCreareProc_Click" Text="Creare Procedura" />
            <asp:Label ID="Label1" runat="server" Text="Status Procedura"></asp:Label>
            <br />
            <br />
            <asp:Label ID="Label2" runat="server" Text="Introduceti varsta minima a pacientilor pe care doriti sa ii vizualizati:"></asp:Label>
            <br />
            <asp:TextBox ID="TextBox1" runat="server" AutoPostBack="True"></asp:TextBox>
            <br />
            <br />
            <asp:Button ID="btnApelProc" runat="server" OnClick="btnApelProc_Click" Text="Apelare Procedura" />
            <br />
            <br />
            <asp:GridView ID="GridView1" runat="server" AllowSorting="False" PageSize="150" CellPadding="4" ForeColor="#333333" GridLines="None" Width="340px">
                <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
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
            <br />
            <asp:Label ID="Label3" runat="server" Text="Numarul pacientilor cu varsta peste:"></asp:Label>
        </div>
        <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
    </form>
</body>
</html>
