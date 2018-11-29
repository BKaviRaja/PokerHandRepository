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
                char[] PokerHandRankValueArray = { 'A', '2', '3', '4', '5', '6', '7', '8', '9', 'T', 'J', 'K', 'Q' };
                char suit = (PokersHandInputArray[0])[1];
                char rank = (PokersHandInputArray[0])[0];
                char[] RoyalFlushValueArray = { 'A', 'K', 'Q', 'J', 'T' };
                
                //Logic to evaluate Poker Hand type 
                if (PokerHandType == false)
                {
                    Dictionary<char, int> PokerHandKRankdict = new Dictionary<char, int>();
                    PokerHandKRankdict.Add((PokersHandInputArray[0])[0], 1);
                    Dictionary<char, int> PokerHandSuitdict = new Dictionary<char, int>();
                    PokerHandSuitdict.Add((PokersHandInputArray[0])[1], 1);
                    for (int i = 1; i < PokersHandInputArray.Length; i++)
                    {
                        if (PokerHandKRankdict.ContainsKey((PokersHandInputArray[i])[0]))
                        {
                            PokerHandKRankdict[(PokersHandInputArray[i])[0]] += 1;
                        }
                        else
                        {
                            PokerHandKRankdict.Add((PokersHandInputArray[i])[0], 1);
                        }
                        if (PokerHandSuitdict.ContainsKey((PokersHandInputArray[i])[1]))
                        {
                            PokerHandSuitdict[(PokersHandInputArray[i])[1]] += 1;
                        }
                        else
                        {
                            PokerHandSuitdict.Add((PokersHandInputArray[i])[1], 1);
                        }
                    }
                    if (PokerHandKRankdict.ContainsValue(5))
                    {
                        PokerHandOutput = "Invalid Data";
                    }
                    else if (PokerHandKRankdict.ContainsValue(4))
                    {
                        PokerHandOutput = "Four of a Kind";
                    }
                    else if (PokerHandKRankdict.ContainsValue(3))
                    {
                        if (PokerHandKRankdict.ContainsValue(2))
                        {
                            PokerHandOutput = "Full House";
                        }
                        else
                        {
                            PokerHandOutput = "Three of a Kind";
                        }
                    }
                    else if (PokerHandKRankdict.ContainsValue(2))
                    {
                        int sum = PokerHandKRankdict.Sum(x => x.Value );                        
                        var PokerHandPairList = PokerHandKRankdict.Where(PokerHandPair => PokerHandPair.Value== 2);                       
                        
                        if (PokerHandPairList.Count() == 2)
                        {
                            PokerHandOutput = "Two Pair";
                        }
                        else
                        {
                            PokerHandOutput = "Pair";
                        }
                    }
                    else
                    {
                        int PokerHandRankMaxValueIndex = Array.IndexOf<char>(PokerHandRankValueArray, (PokersHandInputArray[0])[0]);
                        int PokerHandRoyalFlushSequenceCount = 0;
                        if (PokerHandRankMaxValueIndex >= 4)
                        {
                            int j = PokerHandRankMaxValueIndex;
                            int i = 0;
                            int PokerHandRankSequenceCount = 0;

                            for (i = 0; i < PokersHandInputArray.Length && j >= 0; i++)
                            {
                                if (PokerHandRankValueArray[j] == (PokersHandInputArray[i])[0])
                                {
                                    PokerHandRankSequenceCount += 1;
                                    j--;
                                }
                                //else if (RoyalFlushValueArray[i] == (PokersHandInputArray[i])[0])
                                //{
                                //    PokerHandRoyalFlushSequenceCount += 1;
                                //    j--;
                                //}
                            }
                            if (PokerHandRankSequenceCount == 5 && PokerHandSuitdict.ContainsValue(5))
                            {
                                PokerHandOutput = "Straight Flush";
                            }
                            else if (PokerHandRankSequenceCount == 5 && !PokerHandSuitdict.ContainsValue(5))
                            {
                                PokerHandOutput = "Straight";
                            }
                            else if (PokerHandRankSequenceCount != 5 && PokerHandSuitdict.ContainsValue(5))
                            {
                                PokerHandOutput = "Flush";
                            }
                            else if (PokerHandRoyalFlushSequenceCount == 5)
                            {
                                PokerHandOutput = "Royal Flush";
                            }
                        }
                        else
                        {
                            for (int i = 0; i < PokersHandInputArray.Length; i++)
                            {
                                if (RoyalFlushValueArray[i] == (PokersHandInputArray[i])[0])
                                {
                                    PokerHandRoyalFlushSequenceCount += 1;
                                }
                            }
                            if (PokerHandRoyalFlushSequenceCount == 5 && PokerHandSuitdict.ContainsValue(5))
                            {
                                PokerHandOutput = "Royal Flush";
                            }
                            else if(PokerHandSuitdict.ContainsValue(5))
                            {
                                PokerHandOutput = "Flush";
                            }
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

        //public static string GetEnumDescription(Enum value)
        //{
        //    FieldInfo fi = value.GetType().GetField(value.ToString());

        //    DescriptionAttribute[] attributes =
        //        (DescriptionAttribute[])fi.GetCustomAttributes(typeof(DescriptionAttribute), false);

        //    if (attributes != null && attributes.Length > 0)
        //        return attributes[0].Description;
        //    else
        //        return value.ToString();
        //}
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
