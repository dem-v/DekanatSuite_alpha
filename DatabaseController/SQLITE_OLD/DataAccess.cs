//This code was generated by a tool.
//Changes to this file will be lost if the code is regenerated.
// See the blog post here for help on using the generated code: http://erikej.blogspot.dk/2014/10/database-first-with-sqlite-in-universal.html
using SQLite.Net;
using System;
using SQLite.Net.Attributes;
using SQLite.Net.Interop;

namespace DatabaseController
{
    public class SQLiteDb
    {
        string _path;
        public SQLiteDb(string path)
        {
            _path = path;
        }
        
//         public void Create()
//        {
//            using (SQLiteConnection db = new SQLiteConnection(PlatformID.Win32NT,_path) )
//            {
//                db.CreateTable<CertificateRequest>();
//                db.CreateTable<ScheduledForMissing>();
//                db.CreateTable<ScheduledToDean>();
//                db.CreateTable<StudentsList>();
//            }
//        }
    }
    public partial class CertificateRequest
    {
        [PrimaryKey, AutoIncrement]
        public Int64 RecordID { get; set; }
        
        [NotNull]
        public Int64 ID { get; set; }
        
        [NotNull]
        public DateTime RequestDateTime { get; set; }
        
        [NotNull]
        public String RequestedTo { get; set; }
        
        [NotNull]
        public Byte IsCompleted { get; set; }
        
        [NotNull]
        public String Comment { get; set; }
        
    }
    
    public partial class ScheduledForMissing
    {
        [PrimaryKey, AutoIncrement]
        public Int64 RecordID { get; set; }
        
        [NotNull]
        public Int64 ID { get; set; }
        
        [NotNull]
        public DateTime DateTimeScheduled { get; set; }
        
        [NotNull]
        public Int64 NumberOfMissedClasses { get; set; }
        
        [NotNull]
        public String MissedClass { get; set; }
        
        [NotNull]
        public Int64 ReasonCode { get; set; }
        
        [NotNull]
        public Byte HasArrived { get; set; }
        
    }
    
    public partial class ScheduledToDean
    {
        [PrimaryKey, AutoIncrement]
        public Int64 RecordID { get; set; }
        
        [NotNull]
        public String FullName { get; set; }
        
        [NotNull]
        public DateTime ScheduledDateTime { get; set; }
        
        [NotNull]
        public String Reason { get; set; }
        
        [NotNull]
        public Byte HasArrived { get; set; }
        
    }
    
    public partial class StudentsList
    {
        [PrimaryKey, AutoIncrement]
        public Int64 ID { get; set; }
        
        [NotNull]
        public String FamilyName { get; set; }
        
        [NotNull]
        public String FirstName { get; set; }
        
        public String FathersName { get; set; }
        
        [NotNull]
        public Int64 Grade { get; set; }
        
        [NotNull]
        public Int64 GroupID { get; set; }
        
    }
    
}
