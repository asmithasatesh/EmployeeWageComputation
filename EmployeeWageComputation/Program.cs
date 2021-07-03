using System;

namespace EmployeeWageComputation
{
    class Program
    {
        public string company;
        public int wageperHour;
        public int totalHour;
        public int totalDays;

        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to employee wage computation");

            //get input from user
            Console.WriteLine("Enter Company Name");
            string company=Console.ReadLine();
            Console.WriteLine("Enter wage per hour");
            int wageperHour = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter total number of days");
            int totalDays = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter maximum hours");
            int totalHour = Convert.ToInt32(Console.ReadLine());

            Program companies = new Program(company, wageperHour, totalDays, totalHour);
            companies.ComputeWage();


        }
        public Program(string company, int wage_per_hour, int max_working_days, int maxHoursPerMonth)
        {
            this.company = company;
            this.wageperHour = wage_per_hour;
            this.totalDays = max_working_days;
            this.totalHour = maxHoursPerMonth;
        }
        public void ComputeWage()
        {   //Local Variables
            int workingDays=0, hours=0,dailyWage=0,totalWage=0,workingHour=0;

            //Generate a random number in range [0,1,2]
            Random random = new Random();

            //Using Random methoud output to check attendance
            while (workingDays < totalDays && hours <= totalHour)
            {
                //Calling the next method in Random Class
                int Attendance = random.Next(0, 3);
               // Console.WriteLine("Random number is :" + Attendance);
                switch (Attendance)
                {
                    case 1:
                        //Console.WriteLine("Employee is Present \n");
                        hours = 8;
                        break;
                    case 2:
                       // Console.WriteLine("Parttimer is Present \n");
                        hours = 4;Attendance = 1;
                        break;
                    default:
                        // Console.WriteLine("Employee is Absent \n");
                        hours = 1;
                        break;

                }


                //Calculation
                dailyWage = hours * wageperHour*Attendance;
                totalWage += dailyWage;
                workingHour += hours;
                if (Attendance != 0)
                {
                    workingDays++;
                }
            }
            //Print all Details
                Console.WriteLine("Company Name:" + company);
                Console.WriteLine("Working Hours :" + workingHour);
                Console.WriteLine("Employee Wage Per day :" + dailyWage);
                Console.WriteLine("Working days in a month :" + workingDays);
                Console.WriteLine("Employee Wage for 20 working days :" + totalWage);
                Console.WriteLine("\n");




        }
    }
}
