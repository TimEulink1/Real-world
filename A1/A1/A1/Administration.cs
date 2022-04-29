using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace A1
{
    class Administration
    {
        private List<Student> Students;

        public Administration()
        {
            Students = new List<Student>();
        }

        public void addStudent(string firstname, string lastname, int studentNumber, DateTime birthDate)
        {
            var student = new Student(firstname, lastname, studentNumber, birthDate);
            Students.Add(student);
        }
        public void removeStudent(int studentNumber)
        {
            Students = Students.Where(x => x.StudentNumber != studentNumber).ToList();
        }

        public void checkGrades(int studentNumber)
        {
            var student = Students.SingleOrDefault(X => X.StudentNumber == studentNumber);
            if (student != null) student.printGrades();
        }

        public void removeGrade(int studentNumber, int examCode)
        {
            var student = Students.SingleOrDefault(x => x.StudentNumber == studentNumber);
            if (student == null) return;
            var grade = student.grades.SingleOrDefault(x => !x.Frozen && x.ExamCode == examCode);
            if(grade != null) student.grades.Remove(grade);
        }

        public void addGrade(int studentNumber, int examCode, double value, string note, DateTime examDate)
        {
            var student = Students.SingleOrDefault(x => x.StudentNumber == studentNumber);
            student.setGrade(examCode, value, note, examDate);
        }
        public void addGrade(int studentNumber, int examCode, double value, DateTime examDate)
        {
            var student = Students.SingleOrDefault(x => x.StudentNumber == studentNumber);
            student.setGrade(examCode, value, examDate);

        }
        public void addGrade(int studentNumber, int examCode, double value, string note)
        {
            var student = Students.SingleOrDefault(x => x.StudentNumber == studentNumber);
            student.setGrade(examCode, value, note);

        }
        public void addGrade(int studentNumber, int examCode, double value)
        {
            var student = Students.SingleOrDefault(x => x.StudentNumber == studentNumber);
            student.setGrade(examCode, value);
        }

        public void freezeGrade(int studentNumber, int eexamCode)
        {
            var student = Students.SingleOrDefault(x => x.StudentNumber == studentNumber);
            if (student == null) return;
            var grade = student.grades.FirstOrDefault(x => x.ExamCode == eexamCode & !x.Frozen);
            if (grade != null) grade.Frozen = true;
        }

        public void displayMenu()
        {
            Console.WriteLine("Please choose an option");
            Console.WriteLine("1: Add student");
            Console.WriteLine("2: remove student");
            Console.WriteLine("3: Add student grade");
            Console.WriteLine("4: Remove student grade");
            Console.WriteLine("5: Display student Grades");
            Console.WriteLine("6: Freeze student Grades");
            int option = Convert.ToInt32(Console.ReadLine());

            switch (option)
            {
                case 1:
                    Console.WriteLine("First name: ");
                    string firstName = Console.ReadLine();
                    Console.WriteLine("Last name: ");
                    string lastName = Console.ReadLine();
                    Console.WriteLine("StudentNumber: ");
                    int studentNumber = int.Parse(Console.ReadLine());
                    Console.WriteLine("Enter birth date");
                    Console.Write("Enter a month: ");
                    int month = int.Parse(Console.ReadLine());
                    Console.Write("Enter a day: ");
                    int day = int.Parse(Console.ReadLine());
                    Console.Write("Enter a year: ");
                    int year = int.Parse(Console.ReadLine());
                    DateTime inputtedDate = new DateTime(year, month, day);
                    addStudent(firstName, lastName, studentNumber, inputtedDate);
                    break;
                case 2:
                    Console.WriteLine("StudentNumber:");
                    int studentNumber2 = int.Parse(Console.ReadLine());
                    removeStudent(studentNumber2);
                    break;
                case 3:
                    Console.WriteLine("StudentNumber:");
                    int studentNumber3 = int.Parse(Console.ReadLine());
                    Console.WriteLine("Examcode:");
                    int Examcode = int.Parse(Console.ReadLine());
                    Console.WriteLine("Grade:");
                    int grade = int.Parse(Console.ReadLine());
                    Console.WriteLine("Note:");
                    string note = Console.ReadLine();
                    Console.WriteLine("Enter exam date or type: 0");
                    Console.Write("Enter a month: ");
                    int gradeMonth = int.Parse(Console.ReadLine());
                    Console.Write("Enter a day: ");
                    int gradeDay = int.Parse(Console.ReadLine());
                    Console.Write("Enter a year: ");
                    int gradeYear = int.Parse(Console.ReadLine());
                    if ((gradeMonth == 0 || gradeDay == 0 || gradeYear == 0) && note == "")
                    {
                        addGrade(studentNumber3, Examcode, grade);
                    }
                    else if(gradeMonth == 0 || gradeDay == 0 || gradeYear == 0)
                    {
                        addGrade(studentNumber3, Examcode, grade, note);
                    }
                    else if (note == "")
                    {
                        DateTime gradeInputtedDate = new DateTime(gradeYear, gradeMonth, gradeDay);
                        addGrade(studentNumber3, Examcode, grade, gradeInputtedDate);
                    }
                    else
                    {
                        DateTime gradeInputtedDate = new DateTime(gradeYear, gradeMonth, gradeDay);
                        addGrade(studentNumber3, Examcode, grade, note, gradeInputtedDate);
                    }
                    break;
                case 4:
                    Console.WriteLine("StudentNumber:");
                    int studentNumber4 = int.Parse(Console.ReadLine());
                    Console.WriteLine("Examcode:");
                    int Examcode4 = int.Parse(Console.ReadLine());
                    removeGrade(studentNumber4, Examcode4);
                    break;
                case 5:
                    Console.WriteLine("StudentNumber:");
                    int studentNumber5 = int.Parse(Console.ReadLine());
                    var student = Students.SingleOrDefault(x => x.StudentNumber == studentNumber5);
                    student.printGrades();
                    break;
                case 6:
                    Console.WriteLine("StudentNumber:");
                    int studentNumber6 = int.Parse(Console.ReadLine());
                    Console.WriteLine("Examcode:");
                    int Examcode6 = int.Parse(Console.ReadLine());
                    freezeGrade(studentNumber6, Examcode6);
                    break;
                default:
                    break;
            }
        }

    }
}
