using System;
using System.Collections.Generic;
using System.Linq;

namespace LinqExercise
{
    class Program
    {
        //Static array of integers
        private static int[] numbers = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 0 };

        static void Main(string[] args)
        {
            /*
             * 
             * Complete every task using Method OR Query syntax.
             *
             * HINT: Use the List of Methods defined in the Lecture Material Google Doc ***********
             *
             * You may find that Method syntax is easier to use since it is most like C#
             * Every one of these can be completed using Linq and then printing with a foreach loop.
             * Push to your github when completed!
             * 
             */

            //Print the Sum and Average of numbers
            Console.WriteLine(numbers.Sum());
            Console.WriteLine(numbers.Average());
            Console.WriteLine("_____________________________");

            //Order numbers in ascending order and decsending order. Print each to console.
            var sortedNum = numbers.OrderBy(x => x).ToList();
            Console.WriteLine("ascending and descending");
            for (int i = 0; i < sortedNum.Count; i++)
            {
                Console.Write(sortedNum[i]);
            }
            Console.WriteLine();
            sortedNum.Reverse();
            for (int i = 0; i < sortedNum.Count; i++)
            { Console.Write(sortedNum[i]);}
            Console.WriteLine();

            Console.WriteLine("_____________________________");

            //Print to the console only the numbers greater than 6
            var aboveSix = numbers.Where(x => x > 6).ToList();
            foreach(int i in aboveSix) 
                { Console.Write(i);}    
            
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("----------------------------------");

            //Order numbers in any order (acsending or desc) but only print 4 of them **foreach loop only!**
            var fourList = sortedNum.Take(4).ToList();
            foreach (int num in fourList)
            { Console.Write(num); }
            Console.WriteLine();
            Console.WriteLine("----------------------------------");
            //Change the value at index 4 to your age, then print the numbers in decsending order
            numbers.SetValue(28, 4);
            Console.WriteLine("My Age in 4th Index then, ordered by descending");
            var subMyAge = numbers.OrderByDescending(x => x).ToList();
            for (int i = 0; i < subMyAge.Count; i++)
            { Console.Write(subMyAge[i]+ " ");}
            Console.WriteLine();

            Console.WriteLine("----------------------------------");
            // List of employees ***Do not remove this***
            var employees = CreateEmployees();


            //Print all the employees' FullName properties to the console only if their FirstName starts with a C OR an S.
            //Order this in acesnding order by FirstName.
            Console.WriteLine("Employee List \"c\" and \"s\"");
            var sortWorkers = employees.Where(person => person.FirstName.ToLower().StartsWith('c') || person.FirstName.ToLower()[0]== 's')
                .OrderBy(person => person.FirstName);
            foreach(var person in sortWorkers)
            {
                Console.WriteLine(person.FirstName);
            }
            Console.WriteLine();
            Console.WriteLine("----------------------------------");
            //Print all the employees' FullName and Age who are over the age 26 to the console.
            //Order this by Age first and then by FirstName in the same result.
            Console.WriteLine("Employees over 26 y/o");
            var twentSix = employees.Where(x => x.Age>26).OrderBy(x => x.Age).ThenBy(person => person.FirstName);
            foreach(var worker in twentSix)
            { Console.WriteLine("Employee Name:"+worker.FullName + " "+"Employee Age:" +worker.Age); }
            Console.WriteLine();
            Console.WriteLine("----------------------------------");

            //Print the Sum and then the Average of the employees' YearsOfExperience
            //if their YOE is less than or equal to 10 AND Age is greater than 35
            var experienceList = employees.Where(person => person.YearsOfExperience >= 10 && person.Age > 35);

            var yOe = experienceList.Select(x => x.Age).ToList();
            
           
            Console.WriteLine("Sum:"+yOe.Sum() + " " +"Average:"+ yOe.Average());
            Console.WriteLine("----------------------------------");
            //Add an employee to the end of the list without using employees.Add()
            employees = employees.Append(new Employee { FirstName = "Daniel", Age = 22, LastName = " Kaluuya", YearsOfExperience=2 }).ToList(); 
            foreach (var employee in employees)
            {
                Console.WriteLine(employee.FirstName+ " "+ employee.LastName);
            }
            Console.WriteLine();

            Console.ReadLine();
        }

        #region CreateEmployeesMethod
        private static List<Employee> CreateEmployees()
        {
            List<Employee> employees = new List<Employee>();
            employees.Add(new Employee("Cruz", "Sanchez", 25, 10));
            employees.Add(new Employee("Steven", "Bustamento", 56, 5));
            employees.Add(new Employee("Micheal", "Doyle", 36, 8));
            employees.Add(new Employee("Daniel", "Walsh", 72, 22));
            employees.Add(new Employee("Jill", "Valentine", 32, 43));
            employees.Add(new Employee("Yusuke", "Urameshi", 14, 1));
            employees.Add(new Employee("Big", "Boss", 23, 14));
            employees.Add(new Employee("Solid", "Snake", 18, 3));
            employees.Add(new Employee("Chris", "Redfield", 44, 7));
            employees.Add(new Employee("Faye", "Valentine", 32, 10));

            return employees;
        }
        #endregion
    }
}
