using Realms;
using System;

namespace DatabaseDefinitionAndStorage
{
    public class Class1
    {
        public class Students : RealmObject
        {
            [PrimaryKey]
            public int StudID { get; set; }
            public string FamilyName { get; set; }
            public string FirstName { get; set; }
            public string FathersName { get; set; }
            public int Grade { get; set; }
            public int Group { get; set; }
            public string PhoneNumber { get; set; }
            public string TypeOfEducation { get; set; }
            public string OrderOfAcceptance { get; set; }
        }

        public class GuestsOfAdministration : RealmObject
        {
            [PrimaryKey]
            public int PersonID { get; set; }
            public string FamilyName { get; set; }
            public string FirstName { get; set; }
            public string FathersName { get; set; }
            public DateTimeOffset DateOfBirth { get; set; }
            public string EMail { get; set; }
            public string PhoneNumber { get; set; }
            public string Relation { get; set; }
            public int RelationToStudID { get; set; }
        }

        public class RequestsForPermission : RealmObject
        {
            [PrimaryKey]
            public int RecordID { get; set; }
            public int StudID { get; set; }
            public DateTimeOffset DateOfRequest { get; set; }
            public int NumberOfMissedClasses { get; set; }
            public string ListOfDatesMissed { get; set; }
            public string MissedDepartment { get; set; }
            public int PermissionType { get; set; }
            public string Explanation { get; set; }
            public DateTimeOffset ValidTill { get; set; }
            public bool HasArrived { get; set; }
            public bool IsAllowed { get; set; }
            public bool HasRecieved { get; set; }
        }

        public class RequestsForCertificates : RealmObject
        {
            [PrimaryKey]
            public int RequestID { get; set; }
            public int StudID { get; set; }
            public DateTimeOffset DateOfRequest { get; set; }
            public string RequestingOrganisation { get; set; }
            public bool HasArrived { get; set; }
            public bool IsAllowed { get; set; }
            public bool HasRecieved { get; set; }
        }

        public class DeansRecord : RealmObject
        {
            [PrimaryKey]
            public int RecordID { get; set; }
            public bool IsStudent { get; set; }
            public int PersonID { get; set; }
            public DateTimeOffset DateOfRequest { get; set; }
            public DateTimeOffset DateOfReciept { get; set; }
            public string Reason { get; set; }
            public bool HasArrived { get; set; }
            public bool IsAllowed { get; set; }
        }

        public class DeansTimeTable : RealmObject
        {
            [PrimaryKey]
            public int TableID { get; set; }
            public int RecordID { get; set; }
            public string TableName { get; set; }
            public DateTimeOffset DateTimeRecord { get; set; }
        }

        public class OfficeTimeTable : RealmObject
        {
            [PrimaryKey]
            public int TableID { get; set; }
            public int RecordID { get; set; }
            public string TableName { get; set; }
            public DateTimeOffset DateTimeRecord { get; set; }
        }
    }
}
