using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace A1
{
    class Student
    {
        public readonly string Fullname;
        private string firstName;
        private string lastName;
        private int studentNumber;
        private readonly DateTime birthDate;
        public List<Grade> grades;
        
        public string FirstName { get { return firstName; } set { firstName = value; } }
        public string LastName { get { return lastName; } set { lastName = value; } }

        public Student(string firstName, string lastName, int studentNumber, DateTime birthDate)
        {
            Fullname = $"{firstName} {lastName}";
            this.firstName = firstName;
            this.lastName = lastName;
            this.studentNumber = studentNumber;
        }

        void addGrade(int examCode, double value)
        {
            value = Math.Round(value * 2, MidpointRounding.AwayFromZero) / 2;
            var grades = this.grades.Where(x => x.ExamCode == examCode);
            var notFrozenGrade = grades.FirstOrDefault(x => !x.frozen);
            if(notFrozenGrade != null)
            {
                notFrozenGrade.setGrade(value);
            }
            else
            {
                this.grades.Add(new Grade(value, examCode));
            }
        }

        public string toString()
        {
            return $"{Fullname} {studentNumber}";
        }

        public void printGrades()
        {
            var grades = this.grades.OrderBy(x => x.Date).ToList();
            grades.ForEach(x => Console.WriteLine(x));
        }

        public void printGrades(DateTime startDate, DateTime endTime)
        {
            var grades = this.grades
                .Where(x => x.Date >= startDate && x.Date <= endTime)
                .OrderBy(x => x.Date)
                .ToList();

            grades.ForEach(x => Console.WriteLine(x));
        }
        public List<Grade> gradesFor(int examcode)
        {
            return grades.Where(x => x.ExamCode == examcode).ToList();
        }

        public double gradePointAverage()
        {
            return grades.Average(x => x.Value);
        }
    }
}
