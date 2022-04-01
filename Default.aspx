<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="ExamenParcialWeb._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="row">
        <div class="col-md-3">
            <h2>Jugador</h2>
            <p>
                <asp:ListBox ID="ListBoxjuga" runat="server"></asp:ListBox>
            </p>
        </div>
        <div class="col-md-3">
            <h2>Fecha</h2>
            <p>
                <asp:Calendar ID="Calendar1" runat="server"></asp:Calendar>
            </p>
        </div>
        <div class="col-md-3">
            <h2>Nombre del equipo al que anoto</h2>
            <p>
                <asp:TextBox ID="TextBoxnombreequipo" runat="server"></asp:TextBox>
            </p>
        </div>
        <div class="col-md-3">
            <h2>Goles Anotados</h2>
            <p>
                <asp:TextBox ID="TextBoxgolesanotados" runat="server"></asp:TextBox>
            </p>
        </div>
    </div>
    <div class="row"> 
        <center>
                <asp:Button ID="Button1" runat="server" Text="Ingresar" OnClick="Button1_Click" /> 
        </center>   
    </div>
    
</asp:Content>
