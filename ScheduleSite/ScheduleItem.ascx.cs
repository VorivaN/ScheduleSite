using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ScheduleItem : System.Web.UI.UserControl
{
    ScheduleItemModel.ScheduleItemInstance scheduleItem = null;

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


        using (SqlConnection connection = new SqlConnection())
        {
            connection.ConnectionString =
                ConfigurationManager.ConnectionStrings["ScheduleConnectionString"].ConnectionString;

            connection.Open();

            SqlDataAdapter dataAdapter = new SqlDataAdapter();

            SqlCommand selectCommand = new SqlCommand("SELECT * FROM ScheduleItems", connection);

            SqlCommand insertCommand = new SqlCommand("INSERT INTO ScheduleItems (Day, Lesson, Classroom, Teacher, Subject, GroupName) VALUES(@Day, @Lesson, @Classroom, @Teacher, @Subject, @GroupName)", connection);

            dataAdapter.SelectCommand = selectCommand;
            dataAdapter.InsertCommand = insertCommand;

            SqlParameter insertDayParameter = new SqlParameter("@Day", SqlDbType.NVarChar, 50, "Day");
            SqlParameter insertLessonParameter = new SqlParameter("@Lesson", SqlDbType.Int, 30, "Lesson");
            SqlParameter insertClassroomParameter = new SqlParameter("@Classroom", SqlDbType.NVarChar, 50, "Classroom");
            SqlParameter insertTeacherParameter = new SqlParameter("@Teacher", SqlDbType.NVarChar, 50, "Teacher");
            SqlParameter insertSubjectParameter = new SqlParameter("@Subject", SqlDbType.NVarChar, 50, "Subject");
            SqlParameter insertGroupParameter = new SqlParameter("@GroupName", SqlDbType.NVarChar, 50, "GroupName");


            insertCommand.Parameters.Add(insertDayParameter);
            insertCommand.Parameters.Add(insertLessonParameter);
            insertCommand.Parameters.Add(insertClassroomParameter);
            insertCommand.Parameters.Add(insertTeacherParameter);
            insertCommand.Parameters.Add(insertSubjectParameter);
            insertCommand.Parameters.Add(insertGroupParameter);



            DataSet dataSet = new DataSet("ScheduleDataSet");

            dataAdapter.FillSchema(dataSet, SchemaType.Source, "ScheduleItems");
            dataAdapter.MissingSchemaAction = MissingSchemaAction.AddWithKey;
            dataAdapter.MissingMappingAction = MissingMappingAction.Passthrough;

            dataAdapter.Fill(dataSet, "ScheduleItems");

            DataRow newScheduleItemDataRow = dataSet.Tables["ScheduleItems"].NewRow();

            newScheduleItemDataRow["Day"] = scheduleItem.Day;
            newScheduleItemDataRow["Lesson"] = scheduleItem.Lesson;
            newScheduleItemDataRow["Classroom"] = scheduleItem.Classroom;
            newScheduleItemDataRow["Teacher"] = scheduleItem.Teacher;
            newScheduleItemDataRow["Subject"] = scheduleItem.Subject;
            newScheduleItemDataRow["GroupName"] = scheduleItem.Group;

           
            try
            {
                dataSet.Tables["ScheduleItems"].Rows.Add(newScheduleItemDataRow);
                if (dataAdapter.Update(dataSet, "ScheduleItems") == 1)
                {
                    scheduleItem = new ScheduleItemModel.ScheduleItemInstance();
                    Response.Redirect("~/AddItem.aspx");
                }
                AddError.Visible = false;
            }
            catch
            {
                AddError.Text = "Same schedule item already exisits";
                AddError.Visible = true;
            }
        }
    }
    private void instantiateScheduleItem()
    {
        if (!this.IsPostBack)
            scheduleItem = new ScheduleItemModel.ScheduleItemInstance();
        else
            scheduleItem = new ScheduleItemModel.ScheduleItemInstance(
             DayDropDownList.SelectedValue, int.Parse(LessonDropdownList.SelectedValue),
             ClassroomTextBox.Text, TeacherTextBox.Text, SubjectTextBox.Text, GroupTextBox.Text);
    }
    private void populateUI()
    {
        DayDropDownList.SelectedValue = scheduleItem.Day;
        LessonDropdownList.SelectedValue = scheduleItem.Lesson.ToString();
        ClassroomTextBox.Text = scheduleItem.Classroom;
        TeacherTextBox.Text = scheduleItem.Teacher;
        SubjectTextBox.Text = scheduleItem.Subject;
        GroupTextBox.Text = scheduleItem.Group;
    }
}