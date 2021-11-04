using System;

namespace bankTellerApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            Teller Nelson = new Teller();

            Nelson.RegisterClient();
            Nelson.ShowCummulativeSummary();
        }
    }

    class Teller
    {
        public string UserChoice { get; set; }
        public double UserDeposit { get; set; }
        public string UserName { get; set; }

        public void RegisterClient()
        {
            Console.WriteLine("Enter your name:");
            UserName = Console.ReadLine();
            //get other details

            Console.WriteLine("Hello " + UserName + "! \nPlease select an account type. \nInput a number to choose:");
            Console.WriteLine("1. Savings \n2. Current \n3. Kids \n4.Corporate");
            int answerIndex = int.Parse(Console.ReadLine());

            switch (answerIndex)
            {
                case 1:
                    UserChoice = "savings";
                    break;
                case 2:
                    UserChoice = "current";
                    break;
                case 3:
                    UserChoice = "kids";
                    break;
                case 4:
                    UserChoice = "corporate";
                    break;
                default:
                    UserChoice = "error";
                    break;
            }
            Console.WriteLine("Enter your initial amount: ");
            UserDeposit = double.Parse(Console.ReadLine());
        }

         private double GetRate()
        {
            if (UserChoice == "savings")
            {
                return 5.3/100;
            }
            else if (UserChoice == "current")
            {
                return 7.4/100;
            }
            else if (UserChoice == "kids")
            {
                return 2.5/100;
            }
            else if (UserChoice == "corporate")
            {
                return 8.5/100;
            }
            else return 0.00;
        }

        private double CalculateCummulative(int month, double rate, double initial)
        {
            double interest;
            double vat = 7.5 / 100;
            double currentAmount = initial;

            for (int i = 0; i < month; i++)
            {
                interest = (rate * currentAmount);
                interest = interest - (vat * interest);
                currentAmount = currentAmount + interest;
            }

            return Math.Round(currentAmount, 3);
        }

        public void DisplayAccountType(string accountType)
        {
            Console.WriteLine("For a " + accountType + " account: ");
        }

        public void DisplayCummulative(int numberOfMonths)
        {
            Console.WriteLine("Your gross amount after " + numberOfMonths + " months will be $" + CalculateCummulative(numberOfMonths,GetRate(),UserDeposit));
        }

        public void ShowCummulativeSummary()
        {
            int[] monthDurations = {2, 9 ,12, 24, 60};
            switch (UserChoice)
            {
                case "savings":
                    DisplayAccountType("savings");
                    foreach(int duration in monthDurations)
                    {
                        DisplayCummulative(duration);
                    }
                    break;
                case "current":
                    DisplayAccountType("current");
                    foreach (int duration in monthDurations)
                    {
                        DisplayCummulative(duration);
                    }
                    break;
                case "kids":
                    DisplayAccountType("kids");
                    foreach (int duration in monthDurations)
                    {
                        DisplayCummulative(duration);
                    }
                    break;
                case "corporate":
                    DisplayAccountType("corporate");
                    foreach (int duration in monthDurations)
                    {
                        DisplayCummulative(duration);
                    }
                    break;
                default:
                    Console.WriteLine("Something went wrong, please restart registeration");
                    break;
            }
        }
    }
}
