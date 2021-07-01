using System;

namespace EmployeeWageComputation
{
    class Program
    {
        static void Main(string[] args)
        {
            //Local variables
            int employeeState = 1;
            Random random = new Random();
            //Generate random -> (0,1)
            int Attendance = random.Next(0, 2);
            Console.WriteLine("Random number is :"+ Attendance);
            //Check if employee is present
            if (Attendance==employeeState)
            {
                Console.WriteLine("Employee is Present \n");
            }
            else
            {
                Console.WriteLine("Employee is Absent \n");

            }
        }
    }
}
