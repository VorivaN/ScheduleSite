<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ScheduleItemAdd.ascx.cs" Inherits="ScheduleItemAdd" %>

<div>
    <div>
        <div>
            <asp:Label ID="ItemDay" runat="server" Text="Day:"></asp:Label>
        </div>
        <div>
            <asp:DropDownList ID="DayDropDownList" runat="server">
                <asp:ListItem Text="Monday" Value="Monday"></asp:ListItem>
                <asp:ListItem Text="Tuesday" Value="Tuesday"></asp:ListItem>
                <asp:ListItem Text="Wednesday" Value="Wednesday"></asp:ListItem>
                <asp:ListItem Text="Thursday" Value="Thursday"></asp:ListItem>
                <asp:ListItem Text="Friday" Value="Friday"></asp:ListItem>
                <asp:ListItem Text="Saturday" Value="Saturday"></asp:ListItem>
                <asp:ListItem Text="Sunday" Value="Sunday"></asp:ListItem>
            </asp:DropDownList>
        </div>
        <div>
            <div>
                <asp:Label ID="ItemLesson" runat="server" Text="Lesson:"></asp:Label>
            </div>
            <div>
                <asp:DropDownList ID="LessonDropdownList" runat="server">
                    <asp:ListItem Text="1" Value="1"></asp:ListItem>
                    <asp:ListItem Text="2" Value="2"></asp:ListItem>
                    <asp:ListItem Text="3" Value="3"></asp:ListItem>
                    <asp:ListItem Text="4" Value="4"></asp:ListItem>
                    <asp:ListItem Text="5" Value="5"></asp:ListItem>
                </asp:DropDownList>
            </div>
        </div>

        <div>
            <div>
                <asp:Label ID="ItemClassroom" runat="server" Text="Classroom:"></asp:Label>
            </div>
            <div>
                <asp:TextBox ID="ClassroomTextBox" runat="server" MaxLength="50"></asp:TextBox>
                <asp:RequiredFieldValidator ID="ClassroomRequiredFieldValidator" EnableClientScript="false" ControlToValidate="ClassroomTextBox"
                    runat="server" ErrorMessage="Item Lesson must be filled." Text="*"></asp:RequiredFieldValidator>
            </div>
        </div>

        <div>
            <div>
                <asp:Label ID="ItemTeacher" runat="server" Text="Teacher:"></asp:Label>
            </div>
            <div>
                <asp:TextBox ID="TeacherTextBox" runat="server" MaxLength="50"></asp:TextBox>
                <asp:RequiredFieldValidator ID="TeacherRequiredFieldValidator" EnableClientScript="false" ControlToValidate="TeacherTextBox"
                    runat="server" ErrorMessage="Item Teacher must be filled." Text="*"></asp:RequiredFieldValidator>
            </div>
        </div>

        <div>
            <div>
                <asp:Label ID="ItemSubject" runat="server" Text="Subject:"></asp:Label>
            </div>
            <div>
                <asp:TextBox ID="SubjectTextBox" runat="server" MaxLength="50"></asp:TextBox>
                <asp:RequiredFieldValidator ID="SubjectRequiredFieldValidator" EnableClientScript="false" ControlToValidate="SubjectTextBox"
                    runat="server" ErrorMessage="Item Subject must be filled." Text="*"></asp:RequiredFieldValidator>
            </div>
        </div>

        <div>
            <div>
                <asp:Label ID="ItemGroup" runat="server" Text="Group:"></asp:Label>
            </div>
            <div>
                <asp:TextBox ID="GroupTextBox" runat="server" MaxLength="50"></asp:TextBox>
                <asp:RequiredFieldValidator ID="GroupRequiredFieldValidator" EnableClientScript="false" ControlToValidate="GroupTextBox"
                    runat="server" ErrorMessage="Item Group name must be filled." Text="*"></asp:RequiredFieldValidator>
            </div>
        </div>
    </div>

    <div>
        <asp:Label ID="AddError" runat="server" Visible="false"> </asp:Label>
        <br>
        <asp:ValidationSummary ID="ScheduleItemValidationSummary" runat="server"></asp:ValidationSummary>
        <asp:Button ID="ScheduleItemAddButton" runat="server" Text="Add" OnClick="ScheduleItemAddButton_Click" />
        &nbsp;<asp:Button ID="ScheduleItemCancelButton" runat="server" Text="Cancel" CausesValidation="false" OnClick="ScheduleItemCancelButton_Click" />
    </div>
</div>
