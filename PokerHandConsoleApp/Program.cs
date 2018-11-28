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
            Console.WriteLine(PokerHandObj.ValidatePokerHandInput(PokerHandInputValue));
            Console.WriteLine(PokerHandObj.Evaluate(PokerHandInputValue));
            Console.ReadKey(true);


        }
    }
}
