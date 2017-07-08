using System;
using Realms;
using System.Data;
using System.Data.Linq;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using static DatabaseDefinitionAndStorage.DatabaseRealm;

namespace DatabaseController
{
    public class Class1
    {

        public static string getDBLocation()
        {
            string executable = System.Reflection.Assembly.GetExecutingAssembly().Location;
            string path = (System.IO.Path.GetDirectoryName(executable));
            AppDomain.CurrentDomain.SetData("DataDirectory", path);
//            return "Data Source=|DataDirectory|\\maindb";
/*            UriBuilder u = new UriBuilder();
            u.Path = path + "\\maindb";
            return u.Uri;
            */
            return path+"\\maindb";

        }

        public class StudentList
        {

            public static int GetIDByName(Realm realm, string fam, string fir, string fath, int grade, int groupid)
            {
                /*
                //TODO:This works. Now back to LINQ!!!
                SQLiteConnection StudDBConn = new SQLiteConnection(getDBLocation());
                StudDBConn.Open();
                SQLiteCommand mycommand = new SQLiteCommand(StudDBConn)
                {
                    CommandText = "SELECT ID FROM StudentsList WHERE (FamilyName = @fam) AND (FirstName = @fir) AND (FathersName = @fath)"
//                                  "' AND Grade = " + grade.ToString("D") + " AND GroupID = " + @group.ToString("D")
                };
                mycommand.Parameters.AddWithValue("@fam", fam);
                mycommand.Parameters.AddWithValue("@fir", fir);
                mycommand.Parameters.AddWithValue("@fath", fath);
                int cnt = mycommand.ExecuteNonQuery();
                Console.WriteLine(cnt);
                if (cnt < 0)
                {
                    return -1;
                }
                var result = mycommand.ExecuteScalar().ToString();
                StudDBConn.Close();
                return Int32.Parse(result);
                *///TODO:This is working!!!


                /*
                
                DataContext db = new DataContext(getDBLocation()); // TODO:Wrong schema of context!!!
                IQueryable<StudentsList> Students = db.GetTable<StudentsList>();
                
                int cnt = Students.Count(stud => ((stud.FamilyName).SimplifyCompar() == fam.SimplifyCompar()) &&
                                                 ((stud.FirstName).SimplifyCompar() == fir.SimplifyCompar()) &&
                                                 ((stud.FathersName).SimplifyCompar() == fath.SimplifyCompar()));
                if (cnt == 0) return 0;
                {
                    if (cnt == 1)
                    {
                        var student =
                            Students.Single(stud => ((stud.FamilyName).SimplifyCompar() == fam.SimplifyCompar()) &&
                                                    ((stud.FirstName).SimplifyCompar() == fir.SimplifyCompar()) &&
                                                    ((stud.FathersName).SimplifyCompar() == fath.SimplifyCompar()));

                        return (int) student.ID;
                        //
//                        var query = Students.Where(stud => (stud.FamilyName).SimplifyCompar() == fam.SimplifyCompar() &&
//                                                           (stud.FirstName).SimplifyCompar() == fir.SimplifyCompar() &&
//                                                           (stud.FathersName).SimplifyCompar() == fath.SimplifyCompar());
                    }
                    if (cnt <= 1) return 0;
                    
                    var query = Students.First(studd => (studd.FamilyName).SimplifyCompar() == fam.SimplifyCompar() &&
                                                       (studd.FirstName).SimplifyCompar() == fir.SimplifyCompar() &&
                                                       (studd.FathersName).SimplifyCompar() == fath.SimplifyCompar() &&
                                                       (studd.Grade == grade) && studd.GroupID == group);
                    try
                    {
                        return (int) query.ID;
                    }
                    catch (System.Exception)
                    {
                        return -1;
                    }
                }*/

                var firstOrDefault = realm
                    .All<Students>().FirstOrDefault(p => p.FamilyName == fam && p.FirstName == fir && p.FathersName == fath &&
                                p.Grade == grade && p.GroupID == groupid);
                if (firstOrDefault != null)
                    return firstOrDefault.StudID;
                return -1;
            }
        }
    }

        public static class StringExtensions
        {
            public static string SimplifyCompar(this string str)
            {
                return Regex.Replace(str, @"[^\w\d\s]", "").ToLowerInvariant();
            }
        }

    internal class OperatingOnRealm
    {
        public static Realm CreateOrOpenRealmDB()
        {
            if (!File.Exists("current.realm"))
            {
                RealmConfiguration rc = new RealmConfiguration("current.realm");
                return Realm.GetInstance(rc);
            }
            return Realm.GetInstance("current.realm");
        }

    }
    
}
