using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace A1
{
    class Administration
    {
        private List<Student> students;

        public void addStudent(string firstname, string lastname, int studentNumber, DateTime birthDate)
        {
            var student = new Student(firstname, lastname, studentNumber, birthDate);
            students.Add(student);
        }

        public void removeGrade(int studentNumber, int examCode)
        {
            var student = students.SingleOrDefault(x => x.StudentNumber == studentNumber);
            if (student == null) return;
            var grade = student.grades.Remove(student.grades.FirstOrDefault(x => !x.Frozen && x.ExamCode == examCode));
        }

        public void addGrade(int studentNumber, int examCode, double value, string note, DateTime examDate)
        {
            var student = students.SingleOrDefault(x => x.StudentNumber == studentNumber);
            student.setGrade(examCode, value, note, examDate);
        }
        public void addGrade(int studentNumber, int examCode, double value, DateTime examDate)
        {
            var student = students.SingleOrDefault(x => x.StudentNumber == studentNumber);
            student.setGrade(examCode, value, examDate);

        }
        public void addGrade(int studentNumber, int examCode, double value, string note)
        {
            var student = students.SingleOrDefault(x => x.StudentNumber == studentNumber);
            student.setGrade(examCode, value, note);

        }
        public void addGrade(int studentNumber, int examCode, double value)
        {
            var student = students.SingleOrDefault(x => x.StudentNumber == studentNumber);
            student.setGrade(examCode, value);
        }

    }
}
