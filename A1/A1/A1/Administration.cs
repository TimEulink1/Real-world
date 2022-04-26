using System;
using System.Collections.Generic;
using System.Linq;
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

        public void removeGrade(int studentNumber, int examCode)
        {
            var student = Students.SingleOrDefault(x => x.getStudentNumber() == studentNumber);
            if (student == null) return;
            var grade = student.grades.Remove(student.grades.FirstOrDefault(x => !x.Frozen && x.getExamCode() == examCode));
        }
    }
}
