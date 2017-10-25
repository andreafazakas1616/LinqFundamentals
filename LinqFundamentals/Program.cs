using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace LinqFundamentals
{
    class Program
    {
        static void Main(string[] args)
        {
            //UseGreedyOperators();
            //UseDeferredExecution();
            //UseExpressions();
            //UseDistinct();
            //UseJoin();
            //UseGroupjoin();
            Console.ReadLine();
        }

        private static void UseGroupjoin()
        {

            ClassRepository classRepository = new ClassRepository();
            StudentsRepository studentRepository = new StudentsRepository();

            var query = classRepository.GetAll().GroupJoin(studentRepository.GetAll(),
                                                       c => c.Id,
                                                       s => s.ClassId,
                                                       (c, sg) => new
                                                       {
                                                           Students=sg,
                                                           ClassName = c.Name
                                                       });

            foreach (var group in query)
            {
                Console.WriteLine("Class: {0}",group.ClassName);

                foreach (var student in group.Students)
                {
                    Console.WriteLine(student.Name);
                    
                }
                Console.WriteLine();
            }
        }

        private static void UseJoin()
        {
            ClassRepository classRepository = new ClassRepository();
            StudentsRepository studentRepository = new StudentsRepository();

            var query = classRepository.GetAll().Join(studentRepository.GetAll(),
                                                       c => c.Id,
                                                       s => s.ClassId,
                                                       (c, s) => new
                                                       {
                                                           StudentName = s.Name,
                                                           ClassName = c.Name
                                                       });

            foreach (var student in query)
            {
                Console.WriteLine("Class: {0}, Student: {1}", student.ClassName, student.StudentName);
            }
        }

        private static void UseDistinct()
        {
            List<Book> books = new List<Book>()
            {
                new Book {Id=1, Author ="Scott", Name="Programming"},
                new Book {Id=1, Author ="Scott", Name="Programming"},
                new Book {Id=1, Author ="Allen", Name="Engineering"}
            };

            Console.WriteLine("Result using Book objects: ");
            var query1 = books.Distinct();

            foreach (Book book in query1)
            {
                Console.WriteLine("Author :{0}, Name :{1}", book.Author, book.Name);
            }

            Console.WriteLine();
            Console.WriteLine("Result using anonymous objects: ");
            var query2 = books.Select(b=> new {BookName = b.Name, BookAuthor = b.Author }).Distinct();

            foreach (var book in query2)
            {
                Console.WriteLine("Author : {0}, Name :{1}", book.BookAuthor, book.BookName);
            }
        }

        private static void UseGreedyOperators()
        {
            EmployeeRepository repository = new EmployeeRepository();
            List<Employees> query = repository.GetAll().Where(e => e.Name.StartsWith("A")).ToList();

            repository.Add(new Employees { Id = 4, Name = "Andrew" });

            foreach (var employee in query)
            {

                Console.WriteLine(employee.Name);
            }
        }

        private static void UseExpressions()
        {
            Expression<Func<int, int, int>> multiply = (x, y) => x * y;
            //Compile() gives us the underlying delegate of the expression
            Func<int, int, int> mult = multiply.Compile();
            int z = mult(1, 2);
            Console.WriteLine(z);
        }

        private static void UseDeferredExecution()
        {
            EmployeeRepository repository = new EmployeeRepository();
            IEnumerable<Employees> query = repository.GetAll().Where(e => e.Name.StartsWith("A"));
           
            repository.Add(new Employees { Id = 4, Name = "Andrew" });
                        
            foreach (var employee in query)
            {
                
                Console.WriteLine(employee.Name);
            }

        }
    }
}
