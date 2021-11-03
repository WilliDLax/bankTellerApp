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
            Nelson.ShowCummulative();
        }
    }

    class Teller
    {
        public int UserChoice { get; set; }
        public double UserDeposit { get; set; }

        public void RegisterClient()
        {
            Console.WriteLine("Enter your name:");
            //get the name
            //get other details

            Console.WriteLine("Please select account type. \nInput a number to choose:");
            Console.WriteLine("1. Savings \n2. Current \n3. Kids \n4. Corporate");
            UserChoice = int.Parse(Console.ReadLine());
            Console.WriteLine("Please enter your initial amount: ");
            UserDeposit = double.Parse(Console.ReadLine());
        }

        double CalculateCummulative(int month, double rate, double initial)
        {
            double interest;
            double currentAmount = initial;

            for (int i = 0; i < month; i++)
            {
                interest = ((rate / 100) * currentAmount);
                currentAmount = currentAmount + interest;
            }

            return currentAmount;
        }

        public void ShowCummulative()
        {
            switch (UserChoice)
            {
                case 1:
                    Console.WriteLine("Your final amount after 2 months will be $" + CalculateCummulative(2, 1.7, UserDeposit));
                    break;
                case 2:
                    Console.WriteLine("Your final amount after 6 months will be $" + CalculateCummulative(6, 2.5, UserDeposit));
                    break;
                case 3:
                    Console.WriteLine("Your final amount after 6 months will be $" + CalculateCummulative(6, 0.7, UserDeposit));
                    break;
                case 4:
                    Console.WriteLine("Your final amount after 6 months will be $" + CalculateCummulative(6, 5.7, UserDeposit));
                    break;
                default:
                    Console.WriteLine("Gerrout!");
                    break;
            }
        }
    }
}
