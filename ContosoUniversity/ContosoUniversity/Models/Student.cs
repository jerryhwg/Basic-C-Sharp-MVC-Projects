using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ContosoUniversity.Models
{
    public class Student
    {
        public int ID { get; set; } // primary key (default)
        public string LastName { get; set; }
        public string FirstMidName { get; set; }
        public DateTime EnrollmentDate { get; set; }

        public virtual ICollection<Enrollment> Enrollments { get; set; } // navigation property typically defined as 'virtual': hold other entities related to this entity 
        // ('Enrollments' property of a 'Student' entity will hold all of the 'Enrollment' entities related to the 'Student' entity) 
        // if a navigation property can hold multiple entities, ICollection
    }
}