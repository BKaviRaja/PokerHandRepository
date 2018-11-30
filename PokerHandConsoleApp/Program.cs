using System;

namespace PokerHandConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("PokerHand");            
            Console.WriteLine("Enter the value of cards");            
            var pokerHandInputValue = Console.ReadLine();
            PokerHandEvaluationClass pokerHand = new PokerHandEvaluationClass();
            bool isValidPokerHandInput = pokerHand.ValidatePokerHandInput(pokerHandInputValue);
            if (isValidPokerHandInput)
            {
                
                Console.WriteLine(pokerHand.Evaluate(pokerHandInputValue));
            }
            else
            {
                Console.WriteLine("Invalid Input");
            }            
            Console.ReadKey(true);
        }
    }
}
