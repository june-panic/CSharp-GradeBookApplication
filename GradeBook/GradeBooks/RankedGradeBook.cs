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
    }
}