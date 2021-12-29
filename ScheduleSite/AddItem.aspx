<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="AddItem.aspx.cs" Inherits="AddItem" %>


<%@ Register src="~/ScheduleItemAdd.ascx" tagname="ScheduleItemAdd" tagprefix="uc1" %>

<asp:Content ID="AddItemContent" ContentPlaceHolderID="MainContentPlaceHolder" Runat="Server">
    <uc1:ScheduleItemAdd ID="ScheduleItemAdd" runat="server" />
</asp:Content>