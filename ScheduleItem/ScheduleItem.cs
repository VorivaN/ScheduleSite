using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScheduleItemModel
{
    public class ScheduleItemInstance
    {
        string day = null;
        int lesson = 0;
        string classroom = null;
        string teacher = null;
        string subject = null;
        string group = null;

        public ScheduleItemInstance()
        {

        }
        public ScheduleItemInstance(string day, int lesson, string classroom, string teacher, string subject, string group)
        {
            this.day = day;
            this.classroom = classroom;
            this.lesson = lesson;
            this.teacher = teacher;
            this.group = group;
            this.subject = subject;
        }
        public string Day
        {
            get
            {
                return this.day;
            }
            set
            {
                if (value == null)
                    this.day = "";
                else
                    if (value.Length > 50)
                    this.day = value.Substring(0, 50);
                else
                    this.day = value;
            }
        }
        public int Lesson
        {
            get
            {
                return this.lesson;
            }
            set
            {
                this.lesson = value;
            }
        }
        public string Classroom
        {
            get
            {
                return this.classroom;
            }
            set
            {
                if (value == null)
                    this.classroom = "";
                else
                    if (value.Length > 50)
                    this.classroom = value.Substring(0, 50);
                else
                    this.classroom = value;
            }
        }
        public string Teacher
        {
            get
            {
                return this.teacher;
            }
            set
            {
                if (value == null)
                    this.teacher = "";
                else
                    if (value.Length > 50)
                    this.teacher = value.Substring(0, 50);
                else
                    this.teacher = value;
            }
        }
        public string Subject
        {
            get
            {
                return this.subject;
            }
            set
            {
                if (value == null)
                    this.subject = "";
                else
                    if (value.Length > 50)
                    this.subject = value.Substring(0, 50);
                else
                    this.subject = value;
            }
        }
        public string Group
        {
            get
            {
                return this.group;
            }
            set
            {
                if (value == null)
                    this.group = "";
                else
                    if (value.Length > 50)
                    this.group = value.Substring(0, 50);
                else
                    this.group = value;
            }
        }
    }
}
