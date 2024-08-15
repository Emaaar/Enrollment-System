using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace april30
{
    public class Student
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        public string StudentNumber { get; set; }
        public string ProgramCourse { get; set; }
        public int YearLevel { get; set; }
        public double NumberOfUnitsEnrolled { get; set; }
        public double TuitionFee { get; set; }
        public double DownPayment { get; set; }
        public double Balance { get; set; }
    }
}
