using System;
using System.Collections.Generic;
using System.Linq;
using GradeBook.Enums;

namespace GradeBook.GradeBooks
{
    public class RankedGradeBook : BaseGradeBook
    {
        public RankedGradeBook(string name)
            : base(name)
        {
            Type = GradeBookType.Ranked;
        }

        public override char GetLetterGrade(double averageGrade)
        {
            if (Students.Count < 5)
                throw new InvalidOperationException("Ranked Grading requires a minimum of 5 students to work");

            List<Student> sortedByGrades = Students.OrderByDescending(o => o.AverageGrade).ToList();
            double numStudentsPer20Percent = sortedByGrades.Count * .2;
            int rankedGrade = sortedByGrades.FindIndex(a => a.AverageGrade == averageGrade) + 1;

            if (rankedGrade <= numStudentsPer20Percent)
                return 'A';
            else if(rankedGrade <= numStudentsPer20Percent * 2)
                return 'B';
            else if(rankedGrade <= numStudentsPer20Percent * 3)
                return 'C';
            else if(rankedGrade <= numStudentsPer20Percent * 4)
                return 'D';

            return 'F';
        }

        public override void CalculateStatistics()
        {
            if (Students.Count < 5)
            {
                Console.WriteLine("Ranked grading requires at least 5 students with grades in order to properly calculate a student's overall grade.");
                return;
            }
            
            base.CalculateStatistics();
        }

        public override void CalculateStudentStatistics(string name)
        {
            if (Students.Count < 5)
            {
                Console.WriteLine("Ranked grading requires at least 5 students with grades in order to properly calculate a student's overall grade.");
                return;
            }

            base.CalculateStudentStatistics(name);
        }
    }
}