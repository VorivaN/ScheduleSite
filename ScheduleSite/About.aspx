<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeFile="About.aspx.cs" Inherits="About" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContentPlaceHolder" runat="server">
    <h3>This is a site for managing school schedule.</h3>
    <p>There are you can view all schedule for week, add or delete schedule items.</p>
    <p>Information about each schedule item: day of the week (Monday - Sunday), pair number (maximum 5), subject name, teacher name, classroom number, student group name.</p>
    <asp:Label runat="server">Some restristions:</asp:Label>
    <ul runat="server">
        <li>at any given time, the group must be in a maximum of one lesson</li>
        <li>at any given time, the teacher must teach a maximum of one subject, in a maximum of one place, for any number of groups of students.</li>
        <li>at any given time, a maximum of one subject, with a maximum of one teacher, for any number of groups of students can be taught in the classroom.</li>

    </ul>
</asp:Content>
