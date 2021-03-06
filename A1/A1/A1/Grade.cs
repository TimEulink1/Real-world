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
            value = Math.Round(value * 2, MidpointRounding.AwayFromZero) / 2;
            if (value > 10) this.value = 10;
            else if (value < 1) this.value = 1;
            else this.value = value;
            this.date = date;
            this.examCode = examCode;
            this.note = note;
        }
        public Grade(double value, int examCode, string note)
        {
            value = Math.Round(value * 2, MidpointRounding.AwayFromZero) / 2;
            if (value > 10) this.value = 10;
            else if (value < 1) this.value = 1;
            else this.value = value;
            date = DateTime.Now;
            this.examCode = examCode;
            this.note = note;
        }
        public Grade(double value, int examCode, DateTime date)
        {
            value = Math.Round(value * 2, MidpointRounding.AwayFromZero) / 2;
            if (value > 10) this.value = 10;
            else if (value < 1) this.value = 1;
            else this.value = value;
            this.date = date;
            this.examCode = examCode;
        }
        public Grade(double value, int examCode)
        {
            value = Math.Round(value * 2, MidpointRounding.AwayFromZero) / 2;
            if (value > 10) this.value = 10;
            else if (value < 1) this.value = 1;
            else this.value = value;
            date = DateTime.Now;
            this.examCode = examCode;
        }

        public string toString()
        {
            return examCode.ToString() + " on " + date.ToString() + ": " + value.ToString();
        }
    }
}
