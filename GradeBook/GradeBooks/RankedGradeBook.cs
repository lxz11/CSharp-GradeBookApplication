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

            var studentBoundary = (int) Math.Ceiling(totalStudents * 0.2);
            var orderedGrades = Students.OrderByDescending(s => s.AverageGrade);

            var aGradeScore = orderedGrades.ElementAt(studentBoundary).AverageGrade;
            var bGradeScore = orderedGrades.ElementAt(studentBoundary*2).AverageGrade;
            var cGradeScore = orderedGrades.ElementAt(studentBoundary*3).AverageGrade;
            var dGradeScore = orderedGrades.ElementAt(studentBoundary*4).AverageGrade;

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

        public override void CalculateStatistics()
        {
            if (Students.Count < 5)
            {
                Console.WriteLine("Ranked grading requires at least 5 students with grades in order to properly calculate a student's overall grade.");
                return;
            }
            else
            {
                base.CalculateStatistics();
            }
        }

        public override void CalculateStudentStatistics(string name)
        {
            if (Students.Count < 5)
            {
                Console.WriteLine("Ranked grading requires at least 5 students with grades in order to properly calculate a student's overall grade.");
            }
            else
            {
                base.CalculateStudentStatistics(name);
            }
        }
    }
}
