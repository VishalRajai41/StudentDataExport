<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="StudentexportData._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <h3>Student Data Export</h3>

    <div>
       <br />
        <asp:Button ID="btnExportCsv" runat="server" Text="Export Data" OnClick="btnExportCsv_Click" />
    </div>
</asp:Content>
