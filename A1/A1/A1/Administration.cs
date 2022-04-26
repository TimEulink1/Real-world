using System;
using System.Collections.Generic;
using System.Text;

namespace A1
{
    class Administration
    {
        List<Student> Students;

        public void addStudent(string firstname, string lastname, int studentNumber, DateTime birthDate)
        {
            var student = new Student(firstname, lastname, studentNumber, birthDate);
            Students.Add(student);
        }


    }
}
