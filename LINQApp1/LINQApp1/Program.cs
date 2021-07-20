using System;
using System.Collections.Generic;
using System.Linq;

namespace LINQApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            //Using Query Syntax
            List<Employee> basicQuery = (from emp in Employee.GetEmployees()
                                         select emp).ToList();
            foreach (Employee emp in basicQuery)
            {
                Console.WriteLine($"ID : {emp.ID} Name : {emp.FirstName} {emp.LastName}");
            }
            //Using Method Syntax
            IEnumerable<Employee> basicMethod = Employee.GetEmployees().ToList();
            foreach (Employee emp in basicMethod)
            {
                Console.WriteLine($"ID : {emp.ID} Name : {emp.FirstName} {emp.LastName}");
            }

            Console.WriteLine("----------");
            //  Select individual field

            List<string> basicQuery1 = (from emp in Employee.GetEmployees()
                                          select emp.FirstName).ToList();
            foreach (var empFName in basicQuery1)
            {
                Console.WriteLine($"ID : {empFName}" );
            }

            IEnumerable<int> basicPropMethod = Employee.GetEmployees()
                                              .Select(emp => emp.ID);

            foreach (var id in basicPropMethod)
            {
                Console.WriteLine($"ID : {id}");
            }
            Console.WriteLine("----------");
            // Select individual field

            IEnumerable<Employee> selectQuery2 = (from emp in Employee.GetEmployees()
                                                 select new Employee()
                                                 {
                                                     FirstName = emp.FirstName,
                                                     LastName = emp.LastName,
                                                     Salary = emp.Salary
                                                 });

            foreach (var emp in selectQuery2)
            {
                Console.WriteLine($" Name : {emp.FirstName} {emp.LastName} Salary : {emp.Salary} ");
            }

            //Method Syntax
            List<Employee> selectMethod2 = Employee.GetEmployees().
                                          Select(emp => new Employee()
                                          {
                                              FirstName = emp.FirstName,
                                              LastName = emp.LastName,
                                              Salary = emp.Salary
                                          }).ToList();
            foreach (var emp in selectMethod2)
            {
                Console.WriteLine($" Name : {emp.FirstName} {emp.LastName} Salary : {emp.Salary} ");
            }

            Console.WriteLine("-----------");

      
            // Select field and assign to other class

            var selectQuery3 = (from emp in Employee.GetEmployees()
                                                  select new EmployeeBasicInfo()
                                                  {
                                                      FName = emp.FirstName,
                                                      LName = emp.LastName,
                                                      Salary = emp.Salary
                                                  });

            foreach (var emp in selectQuery3)
            {
                Console.WriteLine($" Name : {emp.FName} {emp.LName} Salary : {emp.Salary} ");
            }

            //Method Syntax
            var selectMethod3 = Employee.GetEmployees().
                                          Select(emp => new EmployeeBasicInfo()
                                          {
                                              FName = emp.FirstName,
                                              LName = emp.LastName,
                                              Salary = emp.Salary
                                          }).ToList();
            foreach (var emp in selectMethod3)
            {
                Console.WriteLine($" Name : {emp.FName} {emp.LName} Salary : {emp.Salary} ");
            }

            Console.WriteLine("----------");
            //   // Select field and assign to other anonymous class and alculate Annual salary

            var selectQuery4 = (from emp in Employee.GetEmployees()
                                select new 
                                {
                                    FName = emp.FirstName,
                                    LName = emp.LastName,
                                    AnnualSalary = emp.Salary * 12
                                });

            foreach (var emp in selectQuery4)
            {
                Console.WriteLine($" Name : {emp.FName} {emp.LName} Salary : {emp.AnnualSalary} ");
            }

            //Method Syntax
            var selectMethod4 = Employee.GetEmployees().
                                          Select(emp => new 
                                          {
                                              FName = emp.FirstName,
                                              LName = emp.LastName,
                                              AnnualSalary = emp.Salary * 12
                                          }).ToList();
            foreach (var emp in selectMethod4)
            {
                Console.WriteLine($" Name : {emp.FName} {emp.LName} Salary : {emp.AnnualSalary} ");
            }

            Console.WriteLine("----------");
            //   // Select field and assign to other anonymous class 

            var selectQuery5 = (from emp in Employee.GetEmployees()
                                select new
                                {
                                    emp.FirstName,
                                    emp.LastName,
                                    emp.Salary
                                });

            foreach (var emp in selectQuery5)
            {
                Console.WriteLine($" Name : {emp.FirstName} {emp.LastName} Salary : {emp.Salary} ");
            }

            //Method Syntax
            var selectMethod6 = Employee.GetEmployees().
                                          Select(emp => new
                                          {
                                             emp.FirstName,
                                             emp.LastName,
                                             emp.Salary
                                          }).ToList();
            foreach (var emp in selectMethod6)
            {
                Console.WriteLine($" Name : {emp.FirstName} {emp.LastName} Salary : {emp.Salary} ");
            }

            //   // Select field and assign to other anonymous class and alculate Annual salary and get the index

            var selectQuery7 = (from emp in Employee.GetEmployees().Select((value, index)
                                => new { value, index})
                                select new
                                {
                                    IndexPosition = emp.index,
                                    FName = emp.value.FirstName,
                                    LName = emp.value.LastName,
                                    AnnualSalary = emp.value.Salary * 12
                                }).ToList();

            foreach (var emp in selectQuery7)
            {
                Console.WriteLine($" Index position {emp.IndexPosition} Name : {emp.FName} {emp.LName} Salary : {emp.AnnualSalary} ");
            }

            //Method Syntax
            var selectMethod7 = Employee.GetEmployees().
                                          Select((emp, index) => new
                                          {
                                              IndexPosition = index,
                                              FName = emp.FirstName,
                                              LName = emp.LastName,
                                              AnnualSalary = emp.Salary * 12
                                          }).ToList();
            foreach (var emp in selectMethod7)
            {
                Console.WriteLine($" Index position {emp.IndexPosition} Name : {emp.FName} {emp.LName} Salary : {emp.AnnualSalary} ");
            }

            Console.WriteLine("----------");
            

            // Select Many
            //Using Method Syntax
            List<string> MethodSyntax = Employee.GetEmployees().
                                         SelectMany(std => std.Programming)
                                         .Distinct()
                                         .ToList();
            //Using Query Syntax
            IEnumerable<string> QuerySyntax = from std in Employee.GetEmployees()
                                              from program in std.Programming
                                              select program;
            //Printing the values
            foreach (string program in MethodSyntax)
            {
                Console.WriteLine(program);
            }

            //  to retrieve the employee name along with the program language name.

            //Using Method Syntax
            var MethodSyntax1 = Employee.GetEmployees()
                                        .SelectMany(std => std.Programming,
                                             (std, prg) => new
                                             {
                                                 StudentName = std.FirstName,
                                                 ProgramName1 = prg
                                             }
                                             )
                                        .ToList();
            //Using Query Syntax
            var QuerySyntax1 = (from std in Employee.GetEmployees()
                               from program in std.Programming
                               select new
                               {
                                   StudentName = std.FirstName,
                                   ProgramName1 = program
                               }).ToList();
            //Printing the values
            foreach (var item in QuerySyntax1)
            {
                Console.WriteLine(item.StudentName + " => " + item.ProgramName1);
            }

             Console.WriteLine("-----Group By illustration ----");
            // Illustrations for Group By

            //Using Method Syntax
            var GroupByMS = Employee.GetEmployees().GroupBy(s => s.Branch);
            //Using Query Syntax
            IEnumerable<IGrouping<string, Employee>> GroupByQS = (from std in Employee.GetEmployees()
                                                                  group std by std.Branch);
            //It will iterate through each groups
            foreach (var group in GroupByMS)
            {
                Console.WriteLine(group.Key + " : " + group.Count());
                //Iterate through each student of a group
                foreach (var emp in group)
                {
                    Console.WriteLine("  Name :" + emp.FirstName +  ", Gender :" + emp.Gender);
                }
            }



            var GroupByMS1 = Employee.GetEmployees().GroupBy(s => s.Gender)
                           //First sorting the data based on key in Descending Order
                           .OrderByDescending(c => c.Key)
                           .Select(emp => new
                           {
                               Key = emp.Key,
                                //Sorting the data based on name in descending order
                                Employees = emp.OrderBy(x => x.FirstName)
                           });
            //Using Query Syntax
            var GroupByQS1 = from emp in Employee.GetEmployees()
                            group emp by emp.Gender into stdGroup
                            orderby stdGroup.Key descending
                            select new
                            {
                                Key = stdGroup.Key,
                                Employees = stdGroup.OrderBy(x => x.FirstName)
                            };
            //It will iterate through each groups
            foreach (var group in GroupByQS1)
            {
                Console.WriteLine(group.Key + " : " + group.Employees.Count());
                //Iterate through each student of a group
                foreach (var emp in group.Employees)
                {
                    Console.WriteLine("  Name :" + emp.FirstName + ", Branch :" + emp.Branch);
                }
            }

            // Group By Clause with mmultiple keys

              //Using Method Syntax
                var GroupByMultipleKeysMS = Employee.GetEmployees()
                                            .GroupBy(x => new { x.Branch, x.Gender })
                                            .OrderByDescending(g => g.Key.Branch).ThenBy(g => g.Key.Gender)
                                            .Select(g => new
                                            {
                                                Branch = g.Key.Branch,
                                                Gender = g.Key.Gender,
                                                Students = g.OrderBy(x => x.FirstName)
                                            });
                //Using Query Syntax
                var GroupByMultipleKeysQS = from student in Employee.GetEmployees()
                                            group student by new
                                            {
                                                student.Branch,
                                                student.Gender
                                            } into stdGroup
                                            orderby stdGroup.Key.Branch descending,
                                                    stdGroup.Key.Gender ascending
                                            select new
                                            {
                                                Branch = stdGroup.Key.Branch,
                                                Gender = stdGroup.Key.Gender,
                                                Students = stdGroup.OrderBy(x => x.FirstName)
                                            };
                //It will iterate through each group
                foreach (var group in GroupByMultipleKeysQS)
                {
                    Console.WriteLine($"Barnch : {group.Branch} Gender: {group.Gender} No of Students = {group.Students.Count()}");
                    //It will iterate through each item of a group
                    foreach (var student in group.Students)
                    {
                        Console.WriteLine($"  ID: {student.ID}, Name: {student.FirstName}");
                    }
                    Console.WriteLine();
                }               




}


    }
    
      


    

    public class Employee
    {
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Salary { get; set; }
        public List<string> Programming { get; set; }
        public string Branch { get; set; }

        public string Gender { get; set; }
 
        public static List<Employee> GetEmployees()
        {
            List<Employee> employees = new List<Employee>
            {
                new Employee {ID = 101, FirstName = "Preety", LastName = "Tiwary", Salary = 60000, Programming = new List<string>() { "C#", "Jave", "C++"}, Gender = "Female", Branch = "CSE"},
                new Employee {ID = 102, FirstName = "Priyanka", LastName = "Dewangan", Salary = 70000, Programming = new List<string>() { "WCF", "SQL Server", "C#" }, Gender = "Male",
                                         Branch = "ETC"},
                new Employee {ID = 103, FirstName = "Hina", LastName = "Sharma", Salary = 80000, Programming = new List<string>() { "MVC", "Jave", "LINQ"}, Gender = "Male",
                                         Branch = "CSE"},
                new Employee {ID = 104, FirstName = "Anurag", LastName = "Mohanty", Salary = 90000, Programming = new List<string>() { "ADO.NET", "C#", "LINQ" }, Gender = "Male",
                                         Branch = "CSE"},
                new Employee {ID = 105, FirstName = "Sambit", LastName = "Satapathy", Salary = 100000, Programming = new List<string>() { "MVC", "Jave", "LINQ"}, Gender = "Female",
                                         Branch = "ETC"},
                new Employee {ID = 106, FirstName = "Sushanta", LastName = "Jena", Salary = 160000, Programming = new List<string>() { "MVC", "Jave", "LINQ"}, Gender = "Female",
                                         Branch = "CSE"}
            };
            return employees;
        }
    }

    public class EmployeeBasicInfo
    {
        public string FName { get; set; }
        public string LName { get; set; }
        public int Salary { get; set; }
    }
}
