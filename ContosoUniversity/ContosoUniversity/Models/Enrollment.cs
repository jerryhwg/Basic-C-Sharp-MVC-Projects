using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ContosoUniversity.Models
{
    public enum Grade
    {
        A, B, C, D, F
    }

    public class Enrollment
    {
        public int EnrollmentID { get; set; } // primary key
        public int CourseID { get; set; } // foreign key (<navigation property name><primary key property name> interprted as a foreign key property)
        public int StudentID { get; set; } // foreign key (An 'Enrollment' entity associated with one 'Student' entity so can hold a single 'Student' entity)
        public Grade? Grade { get; set; } // ?: Grade property is nullable (unkonwn or not assigned)

        public virtual Course Course { get; set; }
        public virtual Student Student { get; set; }
    }
}