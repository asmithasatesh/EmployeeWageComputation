using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeWageComputation
{
    class Program

    {
        public interface IEmployeeMethods
        {
            public void AddCompanyEmpWage(string company, int wagePerhour, int maxHoursPerMonth, int maxWorkingDays);
            public void ComputeEmpWage();
            abstract int ComputeEmpWage(CompanyEmpWage companyEmpWage);

        }
        public class EmpBuilderWage : IEmployeeMethods
        {

            public const int FULL_TIME = 1;
            public const int PART_TIME = 2;

            private LinkedList<CompanyEmpWage> companyEmpWageArray;
            private Dictionary<string, CompanyEmpWage> CompanyDictionary;

            public EmpBuilderWage()
            {
                this.companyEmpWageArray = new LinkedList<CompanyEmpWage>();
                this.CompanyDictionary = new Dictionary<string, CompanyEmpWage>();
            }


            public void AddCompanyEmpWage(string company, int wagePerhour, int maxHoursPerMonth, int maxWorkingDays)
            {
                CompanyEmpWage companyEmpWage = new CompanyEmpWage(company, wagePerhour, maxHoursPerMonth, maxWorkingDays);
                this.companyEmpWageArray.AddLast(companyEmpWage);
                this.CompanyDictionary.Add(company, companyEmpWage);

            }
            public void ComputeEmpWage()
            {
                foreach (CompanyEmpWage company in this.companyEmpWageArray)
                {
                    company.setTotalEmpWage(this.ComputeEmpWage(company));
                    Console.WriteLine(company.toString());
                }
            }
            public int ComputeEmpWage(CompanyEmpWage companyEmpWage)
            {
                //Console.WriteLine("Welcome to employee wage computation");
                //Creating a Random Function
                int empHours = 0, totalEmpHrs = 0, totalWorkingDays = 0;


                while (totalEmpHrs <= companyEmpWage.maxHoursPerMonth && totalWorkingDays < companyEmpWage.maxWorkingDays)
                {
                    //Calling the next method in Random Class
                    totalWorkingDays++;
                    Random r = new Random();
                    int empAttendance = r.Next(0, 3);
                    switch (empAttendance)
                    {
                        case FULL_TIME:
                            empHours = 8;
                            break;
                        case PART_TIME:
                            empHours = 4;
                            break;
                        default:
                            empHours = 0;
                            break;
                    }
                    totalEmpHrs += empHours;

                }
                //Printing total working days and working hours
                Console.WriteLine("\n---Company {0}---", companyEmpWage.company);
                Console.WriteLine("Total number of days worked : " + totalWorkingDays + "\nEmployee hours till now : " + totalEmpHrs);
                return totalEmpHrs * companyEmpWage.wagePerHour;
            }
            static void Main(string[] args)
            {
                Console.WriteLine("Enter the number of companies to add");
                int totalNumber = Convert.ToInt32(Console.ReadLine());
                EmpBuilderWage empBuilderWage = new EmpBuilderWage();
                while (totalNumber > 0)
                {
                    //get input from user
                    Console.WriteLine("Enter Company Name");
                    string company = Console.ReadLine();
                    Console.WriteLine("Enter wage per hour");
                    int wageperHour = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Enter total number of working days in a month");
                    int totalDays = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Enter maximum working hours in a month");
                    int totalHour = Convert.ToInt32(Console.ReadLine());
                    //Create object to call methods
                    
                    empBuilderWage.AddCompanyEmpWage(company, wageperHour, totalHour, totalDays);
                    
                    totalNumber--;
                }
                empBuilderWage.ComputeEmpWage();


            }
        }
    }
}