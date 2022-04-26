using System;
using System.Collections.Generic;
using System.Text;

namespace A1
{
    class Grade
    {
        private Double Value;
        private readonly DateTime Date;
        private readonly int ExamCode;
        private readonly string Note;
        public bool Frozen = false;

        public Grade(double value, int examCode, string note, DateTime date)
        {
            Value = value;
            Date = date;
            ExamCode = examCode;
            Note = note;
        }
        public Grade(double value, int examCode, string note)
        {
            Value = value;
            Date = DateTime.Now;
            ExamCode = examCode;
            Note = note;
        }
        public Grade(double value, int examCode)
        {
            Value = value;
            Date = DateTime.Now;
            ExamCode = examCode;
        }

        public string toString()
        {
            return ExamCode.ToString() + " on " + Date.ToString() + ": " + Value.ToString();
        }

        public void setGrade(double value)
        {
            if (!Frozen) Value = value;
        }

        public double getValue()
        {
            return Value;
        }

        public int getExamCode()
        {
            return ExamCode;
        }

        public DateTime GetDate()
        {
            return Date;
        }

        public string getNote()
        {
            return Note;
        }
    }
}
