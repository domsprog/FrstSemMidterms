using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Students
{
    public class StudentNode
    {
        public Student Data { get; set; }
        public StudentNode Next { get; set; }

        public StudentNode(Student student)
        {
            Data = student;
            Next = null;
        }
    }
}
