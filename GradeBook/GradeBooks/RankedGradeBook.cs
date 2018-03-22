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
            Console.WriteLine("numStudentsPer20Percent {0}", numStudentsPer20Percent);
            int rankedGrade = sortedByGrades.FindIndex(a => a.AverageGrade == averageGrade) + 1;
            Console.WriteLine("rankedGrade {0}", rankedGrade);

            if (rankedGrade <= numStudentsPer20Percent)
            {
                Console.WriteLine("A");
                return 'A';
            }
            else if(rankedGrade <= numStudentsPer20Percent * 2)
            {
                Console.WriteLine("A");
                return 'B';
            }
            else if(rankedGrade <= numStudentsPer20Percent * 3)
            {
                Console.WriteLine("A");
                return 'C';
            }
            else if(rankedGrade <= numStudentsPer20Percent * 4)
            {
                Console.WriteLine("A");
                return 'D';
            }
            return 'F';
        }
    }
}