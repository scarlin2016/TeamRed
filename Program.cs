using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Chapter9Exercise4
{
    class Program
    {
        static void Main(string[] args)
        {//START
            int EXIT = -999;            
            int vc;
            vc = houseKeeping();
            while (vc != EXIT) 
            {
                vc = detailedLoop(vc);
            }
            endOfTask();

        }//STOP
        public static int houseKeeping()
    {//body of houseKeeping
        int vacationCost;
        Console.WriteLine("Welcome to the program. This will display the amount you must save per month to go on your vocation");
        Console.WriteLine("Please enter the cost of your vacation");
        vacationCost = Convert.ToInt32(Console.ReadLine());
        return vacationCost;
    }//end of houseKeeping

        public static int detailedLoop(int vacationCost)
        {//body of detailedLoop 
            int monthsUntilVacation;
            int savingsPerMonth;

            Console.WriteLine("Please enter how months until your vacation");
            monthsUntilVacation = Convert.ToInt32(Console.ReadLine());
            savingsPerMonth = vacationCost / monthsUntilVacation;
            Console.WriteLine("you must save $" + savingsPerMonth + " each month to afford your vacation");
            Console.WriteLine("Please enter the cost of your vacation or enter -999 to exit the program");
            vacationCost = Convert.ToInt32(Console.ReadLine());
            return vacationCost;
        }//end of detailedLoop

        public static void endOfTask()
        {//body of endOfTask 
            Console.WriteLine("Thank you for using the program");
            Console.ReadLine();

            return;
        }//end of endOfTask
    }
}
