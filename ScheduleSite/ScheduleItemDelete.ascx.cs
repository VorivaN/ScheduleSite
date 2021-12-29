using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ScheduleItemDelete : System.Web.UI.UserControl
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

    protected void ScheduleItemDeleteButton_Click(object sender, EventArgs e)
    {
        if (!Page.IsValid)
            return;

        using (var model = new ScheduleItemModel.ScheduleModelDataContext(ConfigurationManager.ConnectionStrings["ScheduleConnectionString"].ConnectionString))
        {
            var items = from item in model.ScheduleItems
                        where item.Lesson == scheduleItem.Lesson && item.Day.Equals(scheduleItem.Day) &&
                        item.Classroom.Equals(scheduleItem.Classroom) && item.Teacher.Equals(scheduleItem.Teacher) &&
                        item.Subject.Equals(scheduleItem.Subject) && item.GroupName.Equals(scheduleItem.GroupName)
                        select item;

            if (!items.Any())
            {
                DeleteError.Text = "No items found";
                DeleteError.Visible = true;
            }
            else if (items.Count() > 1)
            {
                DeleteError.Text = "Found more then one item";
                DeleteError.Visible = true;
            }
            else
            {
                model.ScheduleItems.DeleteOnSubmit(items.First());
                try
                {
                    model.SubmitChanges();
                    DeleteError.Visible = false;
                    scheduleItem = new ScheduleItemModel.ScheduleItem();
                    Response.Redirect("~/AddItem.aspx");
                }
                catch
                {
                    DeleteError.Text = "Unsupported add error!!!";
                    DeleteError.Visible = true;
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