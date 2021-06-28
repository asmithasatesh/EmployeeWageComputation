using System;

namespace EmployeeWageComputation
{
    class Program
    {
        static void Main(string[] args)
        {
            int employeeState = 1;
            int dailyWage, wageperHour=20, hours=8;
            Random random = new Random();
            int Attendance = random.Next(0, 2);
            Console.WriteLine("Random number is :"+ Attendance);

            if (Attendance==employeeState)
            {
                Console.WriteLine("Employee is Present \n");
            }
            else
            {
                Console.WriteLine("Employee is Absent \n");

            }
            dailyWage = wageperHour * hours*Attendance;
            Console.WriteLine("Employee daily wage for 20/hr is : "+dailyWage);
        }
    }
}
