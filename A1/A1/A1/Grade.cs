using System;
using System.Collections.Generic;
using System.Text;

namespace A1
{
    class Grade
    {
        private Double value;
        private readonly DateTime date;
        private readonly int examCode;
        private readonly string note;
        private bool frozen = false;

        public double Value { get { return value; } set { this.value = value; } }
        public DateTime Date { get { return date; } }
        public int ExamCode { get { return examCode; } }
        public string Note { get { return note; } }
        public bool Frozen { get { return frozen; } set { frozen = value; } }


        public Grade(double value, int examCode, string note, DateTime date)
        {
            this.value = Math.Round(value * 2, MidpointRounding.AwayFromZero) / 2;
            this.date = date;
            this.examCode = examCode;
            this.note = note;
        }
        public Grade(double value, int examCode, string note)
        {
            this.value = Math.Round(value * 2, MidpointRounding.AwayFromZero) / 2;
            date = DateTime.Now;
            this.examCode = examCode;
            this.note = note;
        }
        public Grade(double value, int examCode, DateTime date)
        {
            this.value = Math.Round(value * 2, MidpointRounding.AwayFromZero) / 2;
            this.date = date;
            this.examCode = examCode;
        }
        public Grade(double value, int examCode)
        {
            this.value = Math.Round(value * 2, MidpointRounding.AwayFromZero) / 2;
            date = DateTime.Now;
            this.examCode = examCode;
        }

        public string toString()
        {
            return examCode.ToString() + " on " + date.ToString() + ": " + value.ToString();
        }
    }
}
