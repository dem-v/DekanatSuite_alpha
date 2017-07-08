using System;
using System.Xml;

namespace ConnectionLayerExternal
{
    class Program
    {
        public static string IncomeRequestFolder = "/";

        public class RequestCollector //variable class for input request from FRONTEND.
        {
            public string FamilyName;
            public string FirstName;
            public string FathersName;
            public int Grade = 0, Group = 0;
            public DateTime DesiredScheduleDateTime;
            public int ReasonCode=0;
        }

        public class ResponseCollector //variable class for output from BACKEND
        {
            public int ID = 0;
            public DateTime ScheduledDateTime;
            public int DurationOfAppointment = 0;
            public bool nameIsWrong = false;
            public bool groupOrGradeIsWrong = false;
            public bool scheduledSuccessfully = false;

        }

        public static RequestCollector GetIncomeReader()
        {
            XmlDocument xml = new XmlDocument();
            try { xml.Load(IncomeRequestFolder + "income.xml"); } catch (Exception) { return null; }
            XmlNode node = xml.DocumentElement.LastChild; //TODO:New Nodes to be APPENDED!!!!
            RequestCollector rc = new RequestCollector();
            string[] s = new string[6];
            int i = -1;
            foreach (XmlNode n in node)
            {
                i++;
                s[i] = n.InnerText;
            }
            rc.FamilyName = s[0];
            rc.FirstName = s[1];
            rc.FathersName = s[2];
            rc.Grade = Int32.Parse(s[3]);
            rc.Group = Int32.Parse(s[4]);
            rc.DesiredScheduleDateTime = DateTime.Parse(s[5]);
            rc.ReasonCode = Int32.Parse(s[6]);
            return rc;

        }

        public static bool VerifyAndGetID(RequestCollector req,ResponseCollector resp)
        {
            int ID = DatabaseController.Class1.StudentList.GetIDByName(req.FamilyName, req.FirstName, req.FathersName, req.Grade, req.Group);
            switch (ID)
            {
                case 0:
                    resp.nameIsWrong = true;
                    return false;
                case -1:
                    resp.groupOrGradeIsWrong = true;
                    return false;
                default:
                    resp.ID = ID;
                    resp.nameIsWrong = false;
                    return true;
            }
        }


        static void Main(string[] args)
        {
            Console.WriteLine(DatabaseController.Class1.StudentList.GetIDByName("A", "B", "C", 1, 2));
            Console.ReadKey();
        }
    }
}
