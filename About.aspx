<%@ Page Title="About" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="About.aspx.cs" Inherits="ExamenParcialWeb.About" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row">
        <h2>
             <center>   
                 <asp:GridView ID="GridView1" runat="server">
                 </asp:GridView>
             </center>
        </h2>
    </div>
    <div class="row">
        <div class="col-md-4">
            <p>
                <center>

                    <asp:Button ID="Button1" runat="server" Text="Ordena goles" OnClick="Button1_Click" />

                </center>
            </p>
        </div>
        <div class="col-md-4">
            <p>
                <center>

                    <asp:Button ID="Button2" runat="server" Text="Restablecer" OnClick="Button2_Click" />

                </center>
            </p>
        </div>
        <div class="col-md-4">
            <p>
                <center>

                    <asp:Button ID="Button3" runat="server" Text="Promedio de goles" OnClick="Button3_Click" />

                </center>
            </p>
        </div>
    </div>
    <div class="row">
        <center>
            <asp:Label ID="Label1" runat="server" Text="Promedio de Goles : "></asp:Label>
        </center>  
    </div>
</asp:Content>
