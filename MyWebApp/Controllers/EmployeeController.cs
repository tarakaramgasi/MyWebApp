using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyWebApp.Models;

namespace MyWebApp.Controllers
{
    public class EmployeeController : Controller
    {
        public static List<Employee> employees;
        static EmployeeController()
        {
            employees = new List<Employee>();
        }
        public EmployeeController() 
        {
            
        }
        // GET: Employee
        public ActionResult Index()
        {

            return View();
        }
        [HttpPost]
        public ActionResult Create(Employee employee)
        {
            if (ModelState.IsValid)
            {
                if (ModelState.IsValid)
                {
                    // Add the employee to the list
                    employees.Add(employee);

                    // Redirect to the Index action method
                    return RedirectToAction("Index");
                }
            }

            return View(employee);
        }
        [HttpGet]
        public ActionResult DisplyEmployees(Temp temp)
        {
            List<Employee> emp = new List<Employee>();
            foreach (var employee in employees)
            {
                if (employee.EmployeeName.ToLower()[0] == temp.InputValue.ToLower().ToCharArray()[0])
                    emp.Add(employee);

            }
            return View(emp);
        }
        
        public ActionResult Display() 
        {
            
            return View();
        }
        [HttpGet]
        public ActionResult Sort() 
        {
            return View(SortArray(employees, 0, employees.Count-1));
        }

        public ActionResult ListCountries()
        {
            List<string> countries = new List<string>() { "India", "USA", "China", "Australia" };
            return View(countries);
        }

        [NonAction]
        public List<Employee> SortArray(List<Employee> array, int leftIndex, int rightIndex)
        {
            var i = leftIndex;
            var j = rightIndex;
            var pivot = array[leftIndex].Salary;

            while (i <= j)
            {
                while (array[i].Salary < pivot)
                {
                    i++;
                }

                while (array[j].Salary > pivot)
                {
                    j--;
                }

                if (i <= j)
                {
                    var temp = array[i];
                    array[i] = array[j];
                    array[j] = temp;
                    i++;
                    j--;
                }
            }

            if (leftIndex < j)
                SortArray(array, leftIndex, j);

            if (i < rightIndex)
                SortArray(array, i, rightIndex);

            return array;
        }
    }
}