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
        public int StudentNumber { get { return studentNumber; } set { studentNumber = value; } }

        public Student(string firstName, string lastName, int studentNumber, DateTime birthDate)
        {
            Fullname = $"{firstName} {lastName}";
            this.firstName = firstName;
            this.lastName = lastName;
            this.studentNumber = studentNumber;
            grades = new List<Grade>();
        }

        public void setGrade(int examCode, double value)
        {
            var grades = this.grades.Where(x => x.ExamCode == examCode).ToList();
            var notFrozenGrade = grades.FirstOrDefault(x => !x.Frozen);

            if(notFrozenGrade != null)
            {
                notFrozenGrade.Value = value;
            }
            else
            {
                this.grades.Add(new Grade(value, examCode));
            }
        }

        public void setGrade(int examCode, double value, string note)
        {
            var grades = this.grades.Where(x => x.ExamCode == examCode).ToList();
            var notFrozenGrade = grades.FirstOrDefault(x => !x.Frozen);

            if (notFrozenGrade != null)
            {
                notFrozenGrade.Value = value;
            }
            else
            {
                this.grades.Add(new Grade(value, examCode, note));
            }
        }

        public void setGrade(int examCode, double value, DateTime date)
        {
            var grades = this.grades.Where(x => x.ExamCode == examCode).ToList();
            var notFrozenGrade = grades.FirstOrDefault(x => !x.Frozen);

            if (notFrozenGrade != null)
            {
                notFrozenGrade.Value = value;
            }
            else
            {
                this.grades.Add(new Grade(value, examCode, date));
            }
        }
        public void setGrade(int examCode, double value,string note, DateTime date)
        {
            var grades = this.grades.Where(x => x.ExamCode == examCode).ToList();
            var notFrozenGrade = grades.FirstOrDefault(x => !x.Frozen);

            if (notFrozenGrade != null)
            {
                notFrozenGrade.Value = value;
            }
            else
            {
                this.grades.Add(new Grade(value, examCode, note, date));
            }
        }

        public string toString()
        {
            return $"{Fullname} {studentNumber}";
        }

        public void printGrades()
        {
            var grades = this.grades.OrderBy(x => x.Date).ToList();
            Console.WriteLine("****************************************************");
            grades.ForEach(x =>
            {
                
                Console.WriteLine("Examcode" + x.ExamCode);
                Console.WriteLine("Date: " + x.Date);
                Console.WriteLine("Frozen; " + x.Frozen);
                Console.WriteLine("Note: " + x.Note);
                Console.WriteLine("Value: " + x.Value);
                Console.WriteLine("****************************************************");
            }
            );
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
