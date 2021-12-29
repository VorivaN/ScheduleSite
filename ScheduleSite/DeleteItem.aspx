<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="DeleteItem.aspx.cs" Inherits="DeleteItem" %>

<%@ Register src="~/ScheduleItemDelete.ascx" tagname="ScheduleItemDelete" tagprefix="uc1" %>

<asp:Content ID="DeleteItemContent" ContentPlaceHolderID="MainContentPlaceHolder" Runat="Server">
     <uc1:ScheduleItemDelete ID="ScheduleItemDelete" runat="server" />
</asp:Content>
