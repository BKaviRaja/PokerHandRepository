using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;

namespace PokerHandConsoleApp
{
    public class PokerHandEvaluationClass
    {
        public String Evaluate(string PokersHandInput)
        {
            String PokerHandOutput = string.Empty;
            bool PokerHandType = false;
            try
            {
                string[] PokersHandInputArray = PokersHandInput.Split(null);
                char suit = (PokersHandInputArray[0])[1];
                char rank = (PokersHandInputArray[0])[0];
                char[] RoyalFlushValueArray = { 'A', 'K', 'Q', 'J', 'T' };
                for (int i = 0; i < PokersHandInputArray.Length; i++)
                {
                    if (suit == (PokersHandInputArray[i])[1] && RoyalFlushValueArray[i] == (PokersHandInputArray[i])[0])
                    {
                        PokerHandOutput = "Royal Flush";
                        PokerHandType = true;
                    }
                    else
                    {
                        PokerHandType = false;
                        PokerHandOutput = "No Match";
                        i = PokersHandInputArray.Length;
                    }
                }
                if (PokerHandType == false)
                {
                    for (int i = 1; i < PokersHandInputArray.Length; i++)
                    {

                        if (suit == (PokersHandInputArray[i])[1] && rank > (PokersHandInputArray[i])[0])
                        {
                            rank = (PokersHandInputArray[i])[0];
                            PokerHandOutput = "Straigh Flush";
                            PokerHandType = true;
                        }
                        else
                        {
                            PokerHandType = false;
                            PokerHandOutput = "No Match";
                            i = PokersHandInputArray.Length;
                        }
                    }

                }
                return PokerHandOutput;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static string GetEnumDescription(Enum value)
        {
            FieldInfo fi = value.GetType().GetField(value.ToString());

            DescriptionAttribute[] attributes =
                (DescriptionAttribute[])fi.GetCustomAttributes(typeof(DescriptionAttribute), false);

            if (attributes != null && attributes.Length > 0)
                return attributes[0].Description;
            else
                return value.ToString();
        }
        public string ValidatePokerHandInput(string PokerHandInputValue)
        {
            char[] PokerHandRankValueArray = { 'A', '2', '3', '4', '5', '6', '7', '8', '9', 'T', 'J', 'K', 'Q' };
            string[] PokersHandInputArray = PokerHandInputValue.Split(null);
            String PokerHandOutput = string.Empty;

            if (PokersHandInputArray.Length == 5)
            {
                for (int i = 0; i < PokersHandInputArray.Length; i++)
                {
                    if (PokersHandInputArray[i].Length == 2)
                    {
                        if (!PokerHandRankValueArray.Contains((PokersHandInputArray[i])[0]))
                        {
                            i = PokersHandInputArray.Length;
                            PokerHandOutput = "Invalid Data";
                        }
                        if (!Enum.IsDefined(typeof(PokerHandData.Suit), ((PokersHandInputArray[i])[1]).ToString()))
                        {
                            i = PokersHandInputArray.Length;
                            PokerHandOutput = "Invalid Data";
                        }
                        
                    }
                    else
                    {
                        i = PokersHandInputArray.Length;
                        PokerHandOutput = "Invalid Data";
                    }
                }
            }
            else
            {
                PokerHandOutput = "Invalid Data";
            }
            if (PokerHandOutput != "Invalid Data")
                PokerHandOutput = "Valid Data";
            return PokerHandOutput;
        }
    }


}
