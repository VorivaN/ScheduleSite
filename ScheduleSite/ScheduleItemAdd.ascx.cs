using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.Linq;
public partial class ScheduleItemAdd : System.Web.UI.UserControl
{
    ScheduleItemModel.ScheduleItem scheduleItem = null;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Page.IsPostBack)
        {
            Page.Validate();

            if (!Page.IsValid)
                return;
        }
        instantiateScheduleItem();
        populateUI();
    }

    protected void ScheduleItemCancelButton_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/ScheduleItems.aspx");
    }

    protected void ScheduleItemAddButton_Click(object sender, EventArgs e)
    {
        if (!Page.IsValid)
            return;

        using (var model = new ScheduleItemModel.ScheduleModelDataContext(ConfigurationManager.ConnectionStrings["ScheduleConnectionString"].ConnectionString))
        {

            var itemsInThisClassroom = from item in model.ScheduleItems
                                       where item.Lesson == scheduleItem.Lesson && item.Day.Equals(scheduleItem.Day) &&
                                       item.Classroom.Equals(scheduleItem.Classroom) &&
                                       !item.Teacher.Equals(scheduleItem.Teacher)
                                       select item;

            var itemsWithThisTeacher = from item in model.ScheduleItems
                                       where item.Lesson == scheduleItem.Lesson && item.Day.Equals(scheduleItem.Day) &&
                                       item.Teacher.Equals(scheduleItem.Teacher) &&
                                       (!item.Classroom.Equals(scheduleItem.Classroom) ||
                                       item.Classroom.Equals(scheduleItem.Classroom) && !item.Subject.Equals(scheduleItem.Subject))
                                       select item;

            var itemsWithThisGroup = from item in model.ScheduleItems
                                     where item.Lesson == scheduleItem.Lesson && item.Day.Equals(scheduleItem.Day) &&
                                     item.GroupName.Equals(scheduleItem.GroupName)
                                     select item;

            if (itemsInThisClassroom.Any())
            {
                AddError.Text = "This classroom is busy with another schedule item";
                AddError.Visible = true;
            }
            else if (itemsWithThisTeacher.Any())
            {
                AddError.Text = "This teacher is busy with another schedule item";
                AddError.Visible = true;
            }
            else if (itemsWithThisGroup.Any())
            {
                AddError.Text = "This group is busy with another schedule item";
                AddError.Visible = true;
            }
            else
            {
                model.ScheduleItems.InsertOnSubmit(scheduleItem);
                try
                {
                    model.SubmitChanges();
                    AddError.Visible = false;
                    scheduleItem = new ScheduleItemModel.ScheduleItem();
                    Response.Redirect("~/AddItem.aspx");
                }
                catch
                {
                    AddError.Text = "Unsupported add error!!!";
                    AddError.Visible = true;
                }
            }
        }
    }
    private void instantiateScheduleItem()
    {
        if (!this.IsPostBack)
            scheduleItem = new ScheduleItemModel.ScheduleItem();
        else
            scheduleItem = new ScheduleItemModel.ScheduleItem
            {
                Day = DayDropDownList.SelectedValue,
                Lesson = int.Parse(LessonDropdownList.SelectedValue),
                Classroom = ClassroomTextBox.Text,
                Teacher = TeacherTextBox.Text,
                Subject = SubjectTextBox.Text,
                GroupName = GroupTextBox.Text
            };
    }
    private void populateUI()
    {
        DayDropDownList.SelectedValue = scheduleItem.Day;
        LessonDropdownList.SelectedValue = scheduleItem.Lesson.ToString();
        ClassroomTextBox.Text = scheduleItem.Classroom;
        TeacherTextBox.Text = scheduleItem.Teacher;
        SubjectTextBox.Text = scheduleItem.Subject;
        GroupTextBox.Text = scheduleItem.GroupName;
    }
}