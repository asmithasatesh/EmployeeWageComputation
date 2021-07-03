using System;

namespace EmployeeWageComputation
{
    class Program
    {


        public class EmpBuilderWage
        {

            public const int FULL_TIME = 1;
            public const int PART_TIME = 2;
            private int numOfCompany = 0;
            private CompanyEmpWage[] companyEmpWageArray;


            public EmpBuilderWage()
            {
                this.companyEmpWageArray = new CompanyEmpWage[5];
            }
            public void addCompanyEmpWage(string company, int wagePerhour, int maxHoursPerMonth, int maxWorkingDays)
            {
                companyEmpWageArray[this.numOfCompany] = new CompanyEmpWage(company, wagePerhour, maxHoursPerMonth, maxWorkingDays);
                numOfCompany++;
            }
            public void ComputeEmpWage()
            {
                for (int i = 0; i < numOfCompany; i++)
                {
                    companyEmpWageArray[i].setTotalEmpWage(this.ComputeEmpWage(this.companyEmpWageArray[i]));
                    Console.WriteLine(this.companyEmpWageArray[i].toString());
                }
            }
            private int ComputeEmpWage(CompanyEmpWage companyEmpWage)
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
                Console.WriteLine("Total number of days worked " + totalWorkingDays + "\nEmployee hours till now : " + totalEmpHrs+"\n");
                return totalEmpHrs * companyEmpWage.wagePerHour;
            }
            static void Main(string[] args)
            {
                //get input from user
                Console.WriteLine("Enter Company Name");
                string company = Console.ReadLine();
                Console.WriteLine("Enter wage per hour");
                int wageperHour = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Enter total number of days");
                int totalDays = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Enter maximum hours");
                int totalHour = Convert.ToInt32(Console.ReadLine());
                //Create object to call methods
                EmpBuilderWage empBuilderWage = new EmpBuilderWage();
                empBuilderWage.addCompanyEmpWage(company, wageperHour, totalHour, totalDays);
                empBuilderWage.ComputeEmpWage();


            }
        }
    }
}
