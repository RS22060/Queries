
using System;
using System.Linq;

namespace Queries
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var context = new PlutoContext())
            {
                var authors = context.Authors;

                Console.WriteLine("All authors");
                foreach (var auth in authors)
                {
                    Console.WriteLine($"{auth.Id} {auth.Name}");
                }

                Console.WriteLine();

                var courses = context.Courses.Where(c => c.AuthorId == context.Authors.FirstOrDefault().Id);
                Console.WriteLine($"Courses by ${courses.FirstOrDefault().Author.Name}");
                foreach (var course in courses)
                {
                    Console.WriteLine($"{course.Id} {course.Name} {course.FullPrice}");
                }

                Console.WriteLine();

                var csharpCourses = context.Courses.Where(c => c.Tags.Any(t => t.Name == "C#"));
                Console.WriteLine($"C# courses");
                foreach (var course in csharpCourses)
                {
                    Console.WriteLine($"{course.Id} {course.Name} {course.FullPrice}");
                }
            }

            Console.ReadKey();
        }
    }
}
