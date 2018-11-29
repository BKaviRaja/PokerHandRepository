using System;

namespace PokerHandConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("PokerHand");
            Console.WriteLine("Enter the value of cards");
            var PokerHandInputValue = Console.ReadLine();
            PokerHandEvaluationClass PokerHandObj = new PokerHandEvaluationClass();
            var PokerHandInputData = PokerHandObj.ValidatePokerHandInput(PokerHandInputValue);
            if (PokerHandInputData == "Valid Data")
            {
                Console.WriteLine();
                Console.WriteLine(PokerHandObj.Evaluate(PokerHandInputValue));
            }
            else
            {
                Console.WriteLine(PokerHandInputData);
            }
            
            Console.ReadKey(true);


        }
    }
}
