using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace StudentexportData
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void btnExportCsv_Click(object sender, EventArgs e)
        {
            List<StudentInfo> students = new List<StudentInfo>();
            using (StudentEntities student = new StudentEntities())
            {
                students = student.StudentInfoes.ToList();
            }
            if (students.Count > 0)
            {
                string header = @"StudentId" + "|" + "FirstName" + "LastName" + "|" + "DOB" + "|" + "Address" + "|" + "City" + "|" + "State" + "|" + "Email" + "|" + "MaritalStatus" + "\n";


                StringBuilder stringBuilder = new StringBuilder();

                stringBuilder.Append(header);

                foreach (var i in students)
                {
                    stringBuilder.AppendLine(string.Join("|",
                        string.Format(@"{0}", i.StudentId),
                        string.Format(@"{0}", i.FirstName),
                        string.Format(@"{0}", i.LastName),
                        string.Format(@"{0}", i.DOB),
                        string.Format(@"{0}", i.Adddress),
                        string.Format(@"{0}", i.City),
                        string.Format(@"{0}", i.State),
                        string.Format(@"{0}", i.Email),
                        string.Format(@"{0}", i.MaterialStatus)));
                }

                //Download here

                HttpContext context = HttpContext.Current;
                context.Response.Write(stringBuilder.ToString());
                context.Response.ContentType = "txt/csv";
                context.Response.AddHeader("Content-Disposition", "attachment; filename=StudentData.csv");
                context.Response.End();
            }

        }


    }
}