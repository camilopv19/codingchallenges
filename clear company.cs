using System;
using System.Linq;
using System.Collections.Generic;
/*
* Problem Description
* ===================
* 
* We have a flat list of employees that are retrieved from our database from the implemented method GetAllEmployees()
* Goal : Initialize and populate the DirectReports collection of every employee 
* that has at least one direct report in the Main() method 
*
* EXAMPLE 1
* ========
* GetAllEmployees() Returns - [{"Id":1,"ManagerId":4,"DirectReports":null},{"Id":2,"ManagerId":1,"DirectReports":null},{"Id":3,"ManagerId":1,"DirectReports":null},{"Id":4,"ManagerId":6,"DirectReports":null}]
* After populating DirectReports - [{"Id":1,"ManagerId":4,"DirectReports":[{"Id":2,"ManagerId":1,"DirectReports":[]},{"Id":3,"ManagerId":1,"DirectReports":[]}]},{"Id":2,"ManagerId":1,"DirectReports":[]},{"Id":3,"ManagerId":1,"DirectReports":[]},{"Id":4,"ManagerId":6,"DirectReports":[{"Id":1,"ManagerId":4,"DirectReports":[{"Id":2,"ManagerId":1,"DirectReports":[]},{"Id":3,"ManagerId":1,"DirectReports":[]}]}]}]

** GetAllEmployees ARRAY but pretty: [
	{"Id":1,"ManagerId":4,"DirectReports":
		[{"Id":2,"ManagerId":1,"DirectReports":[]},{"Id":3,"ManagerId":1,"DirectReports":[]}]
	},
	{"Id":2,"ManagerId":1,"DirectReports":[]},
	{"Id":3,"ManagerId":1,"DirectReports":[]},
	{"Id":4,"ManagerId":6,"DirectReports":[
		{"Id":1,"ManagerId":4,"DirectReports":[
			{"Id":2,"ManagerId":1,"DirectReports":[]},{"Id":3,"ManagerId":1,"DirectReports":[]}
			]
		}
	]}]
* 
* EXAMPLE 2
* =======
* GetAllEmployees() Returns -[{"Id":1,"ManagerId":4,"DirectReports":null}]
* After populating DirectReports - [{"Id":1,"ManagerId":4,"DirectReports":[]}]
*
* CONSTRAINTS
* ==========
* 0 <= GetEmployees().Count <= 1,000,000,000
*/

namespace MyCompiler
{
    class Program
    {
        public static void Main(string[] args)
        {
            var emps = GetAllEmployees();
            var directReports = GetDirectReports(emps);
            PrintEmployees(directReports, false);
        }

        private static List<Employee> GetAllEmployees()
        {
            var emps = new List<Employee>{
                new Employee{ Id=1, ManagerId=4, DirectReports=null },
                new Employee{ Id=2, ManagerId=1, DirectReports=null },
                new Employee{ Id=3, ManagerId=1, DirectReports=null },
                new Employee{ Id=4, ManagerId=6, DirectReports=null }
            };
            return emps;
        }

        public static List<Employee> GetDirectReports(List<Employee> emps)
        {
            // Transform the list into dictionary by their Id prop
            var empsDictionary = emps.ToDictionary(d => d.Id);

            foreach (Employee employee in emps)
            {
                // Validate if each employee's manager exists on the main list
                if (employee.ManagerId != 0 && empsDictionary.ContainsKey(employee.ManagerId))
                {
                    // Get the manager object from the list
                    var manager = empsDictionary[employee.ManagerId];

                    // Validate if this manager has DirecReports list, and if not, initialize it
                    if (manager.DirectReports == null) manager.DirectReports = new List<Employee>();

                    // Add the current employee to the manager
                    manager.DirectReports.Add(employee);
                }
            }
            return empsDictionary.Values.ToList();
        }


        private static void PrintEmployees(List<Employee> emps, bool isDirectReports)
        {
            if (emps.Count() == 0) return;
            foreach (var emp in emps)
            {
                Console.Write(isDirectReports ? "\n\t" : "\n");
                Console.Write($"Employee {emp.Id}, ManagerId {emp.ManagerId}, DirectReports: [");
                if (emp.DirectReports != null)
                {
                    PrintEmployees(emp.DirectReports, true);
                }
                Console.Write(isDirectReports ? "]," : "\n]");

            }
        }
    }
}

class Employee
{
    public long Id { get; set; }
    public long ManagerId { get; set; }
    public List<Employee>? DirectReports { get; set; }
}
