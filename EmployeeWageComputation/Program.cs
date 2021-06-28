using System;

namespace EmployeeWageComputation
{
    class Program
    {
        static void Main(string[] args)
        {   //Local Variables
            int dailyWage=0,totalHour=0,wageperHour=20, hours=8, partTimeHour=4,days=0;

            //Generate a random number in range [0,1,2]
            Random random = new Random();
            int Attendance = random.Next(0, 3);
            Console.WriteLine("Random number is :"+ Attendance);

            //Using Random methoud output to check attendance
            switch (Attendance)
            {
                case 1:
                    Console.WriteLine("Employee is Present \n");
                    break;
                case 2:
                    Console.WriteLine("Parttimer is Present \n");
                    hours = partTimeHour; Attendance = 1;
                    break;
                default:
                    Console.WriteLine("Employee is Absent \n");
                    break;
            }

            //Compute Daily wage
            Console.WriteLine("Employee Daily wage is : " + wageperHour*Attendance*hours);
            Console.WriteLine("\n");

            //Compute Monthly wage for 100hours (or) 20days
            while ((totalHour<=100 || days<=20) && Attendance!=0)
            {
                dailyWage+= wageperHour * hours;
                totalHour += hours;
                days += 1;
            }
            Console.WriteLine("Employee Monthly wage is : " + dailyWage);




        }
    }
}
