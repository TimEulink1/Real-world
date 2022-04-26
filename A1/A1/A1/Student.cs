using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace A1
{
    class Student
    {
        public readonly string Fullname;
        private string FirstName;
        private string LastName;
        private int StudentNumber;
        private readonly DateTime BirthDate;
        private List<Grade> Grades;
        
        public Student(string firstName, string lastName, int studentNumber, DateTime birthDate)
        {
            Fullname = $"{firstName} {lastName}";
            FirstName = firstName;
            LastName = lastName;
            StudentNumber = studentNumber;
        }

        void addGrade(int examCode, double value)
        {
            value = Math.Round(value * 2, MidpointRounding.AwayFromZero) / 2;
            var grades = Grades.Where(x => x.ExamCode == examCode);
            var notFrozenGrade = grades.FirstOrDefault(x => !x.Frozen);
            if(notFrozenGrade != null)
            {
                notFrozenGrade.setGrade(value);
            }
            else
            {
                Grades.Add(new Grade(value, examCode));
            }
        }

        public string toString()
        {
            return $"{Fullname} {StudentNumber}";
        }

        public void printGrades()
        {
            var grades = Grades.OrderBy(x => x.Date).ToList();
            grades.ForEach(x => Console.WriteLine(x));
        }

        public void printGrades(DateTime startDate, DateTime endTime)
        {
            var grades = Grades
                .Where(x => x.Date >= startDate && x.Date <= endTime)
                .OrderBy(x => x.Date)
                .ToList();

            grades.ForEach(x => Console.WriteLine(x));
        }
        public List<Grade> gradesFor(int examcode)
        {
            return Grades.Where(x => x.ExamCode == examcode).ToList();
        }

        public double gradePointAverage()
        {
            return Grades.Average(x => x.getValue());
        }
    }
}
