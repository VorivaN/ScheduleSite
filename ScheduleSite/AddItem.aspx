<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="AddItem.aspx.cs" Inherits="AddItem" %>


<%@ Register src="~/ScheduleItem.ascx" tagname="ScheduleItem" tagprefix="uc1" %>

<asp:Content ID="AddItemContent" ContentPlaceHolderID="MainContentPlaceHolder" Runat="Server">
    <uc1:ScheduleItem ID="ScheduleItem1" runat="server" />
</asp:Content>

