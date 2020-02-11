using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GradeBook.GradeBooks
{
    public class RankedGradeBook : BaseGradeBook
    {
        public RankedGradeBook(string name) : base(name)
        {
            Type = Enums.GradeBookType.Ranked;
        }

        public override char GetLetterGrade(double averageGrade)
        {
            var totalStudents = Students.Count;
            if (totalStudents < 5)
            {
                throw new InvalidOperationException($"Ranked grading requires a minimum of 5 students to work. This gradebook has {totalStudents} students.");
            }

            var studentBoundary = (int) Math.Floor(totalStudents * 0.2);

            var aGradeScore = Students.OrderByDescending(s => s.AverageGrade).ElementAt(studentBoundary).AverageGrade;
            var bGradeScore = Students.OrderByDescending(s => s.AverageGrade).ElementAt(studentBoundary*2).AverageGrade;
            var cGradeScore = Students.OrderByDescending(s => s.AverageGrade).ElementAt(studentBoundary*3).AverageGrade;
            var dGradeScore = Students.OrderByDescending(s => s.AverageGrade).ElementAt(studentBoundary*4).AverageGrade;

            if (averageGrade > aGradeScore)
            {
                return 'A';
            }
            else if (averageGrade > bGradeScore)
            {
                return 'B';
            }
            else if (averageGrade > cGradeScore)
            {
                return 'C';
            }
            else if (averageGrade > dGradeScore)
            {
                return 'D';
            }
            else
            {
                return 'F';
            }
        }
    }
}
