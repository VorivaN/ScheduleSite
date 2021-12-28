<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="ScheduleItems.aspx.cs" Inherits="ScheduleItems" %>

<asp:Content ID="ScheduleItems" ContentPlaceHolderID="MainContentPlaceHolder" runat="Server">
     <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ScheduleConnectionString %>" SelectCommand="SELECT * FROM [ScheduleItems]"></asp:SqlDataSource>
<asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="Day,Lesson,Classroom,Teacher,Subject,GroupName" DataSourceID="SqlDataSource1">
    <Columns>
        <asp:BoundField DataField="Day" HeaderText="Day" ReadOnly="True" SortExpression="Day" />
        <asp:BoundField DataField="Lesson" HeaderText="Lesson" ReadOnly="True" SortExpression="Lesson" />
        <asp:BoundField DataField="Classroom" HeaderText="Classroom" ReadOnly="True" SortExpression="Classroom" />
        <asp:BoundField DataField="Teacher" HeaderText="Teacher" ReadOnly="True" SortExpression="Teacher" />
        <asp:BoundField DataField="Subject" HeaderText="Subject" ReadOnly="True" SortExpression="Subject" />
        <asp:BoundField DataField="GroupName" HeaderText="GroupName" ReadOnly="True" SortExpression="GroupName" />
    </Columns>
</asp:GridView>
</asp:Content>
