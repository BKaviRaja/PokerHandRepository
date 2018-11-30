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
        public bool ValidatePokerHandInput(string PokerHandInputValue)
        {
            char[] PokerHandRankValueArray = { 'A', '2', '3', '4', '5', '6', '7', '8', '9', 'T', 'J', 'K', 'Q' };

            var PokersHandInputArray = PokerHandInputValue.Split(null);
            bool isValidPokerHandValue = false;

            if (PokersHandInputArray.Length == 5)
            {
                for (int i = 0; i < PokersHandInputArray.Length; i++)
                {
                    if (PokersHandInputArray[i].Length == 2)
                    {
                        if (PokerHandRankValueArray.Contains((PokersHandInputArray[i])[0]))
                        {
                            if (PokersHandInputArray.Distinct().Count() == PokersHandInputArray.Count())
                            {
                                if (Enum.IsDefined(typeof(PokerHandData.PokerHandSuitValues), ((PokersHandInputArray[i])[1]).ToString()))
                                {
                                    isValidPokerHandValue = true;
                                }
                                else
                                {
                                    isValidPokerHandValue = false;
                                    i = PokersHandInputArray.Length;
                                }
                            }
                            else
                            {
                                isValidPokerHandValue = false;
                                i = PokersHandInputArray.Length;
                            }
                        }
                        else
                        {
                            isValidPokerHandValue = false;
                            i = PokersHandInputArray.Length;
                        }
                    }
                    else
                    {
                        isValidPokerHandValue = false;
                        i = PokersHandInputArray.Length;
                        
                    }
                }
            }
            else
            {
                isValidPokerHandValue = false;
            }

            return isValidPokerHandValue;
        }
        public String Evaluate(string PokersHandInput)
        {
            String pokerHandOutput ="No Match";
            bool pokerHandType = false;
            try
            {
                string[] pokersHandInputArray = PokersHandInput.Split(null);
                char[] pokerHandRankValueArray = { 'A', '2', '3', '4', '5', '6', '7', '8', '9', 'T', 'J', 'K', 'Q' };               
                char suit = (pokersHandInputArray[0])[1];
                char rank = (pokersHandInputArray[0])[0];
                char[] royalFlushValueArray = { 'A', 'K', 'Q', 'J', 'T' };
                
                //Logic to evaluate Poker Hand type 
                if (pokerHandType == false)
                {
                    Dictionary<char, int> pokerHandKRankdict = new Dictionary<char, int>();
                    pokerHandKRankdict.Add((pokersHandInputArray[0])[0], 1);
                    Dictionary<char, int> pokerHandSuitdict = new Dictionary<char, int>();
                    pokerHandSuitdict.Add((pokersHandInputArray[0])[1], 1);
                    for (int i = 1; i < pokersHandInputArray.Length; i++)
                    {
                        if (pokerHandKRankdict.ContainsKey((pokersHandInputArray[i])[0]))
                        {
                            pokerHandKRankdict[(pokersHandInputArray[i])[0]] += 1;
                        }
                        else
                        {
                            pokerHandKRankdict.Add((pokersHandInputArray[i])[0], 1);
                        }
                        if (pokerHandSuitdict.ContainsKey((pokersHandInputArray[i])[1]))
                        {
                            pokerHandSuitdict[(pokersHandInputArray[i])[1]] += 1;
                        }
                        else
                        {
                            pokerHandSuitdict.Add((pokersHandInputArray[i])[1], 1);
                        }
                    }
                    if (pokerHandKRankdict.ContainsValue(5))
                    {
                        pokerHandOutput = "Invalid Data";
                    }
                    else if (pokerHandKRankdict.ContainsValue(4))
                    {
                        pokerHandOutput = "Four of a Kind";
                    }
                    else if (pokerHandKRankdict.ContainsValue(3))
                    {
                        if (pokerHandKRankdict.ContainsValue(2))
                        {
                            pokerHandOutput = "Full House";
                        }
                        else
                        {
                            pokerHandOutput = "Three of a Kind";
                        }
                    }
                    else if (pokerHandKRankdict.ContainsValue(2))
                    {
                        int sum = pokerHandKRankdict.Sum(x => x.Value );                        
                        var PokerHandPairList = pokerHandKRankdict.Where(PokerHandPair => PokerHandPair.Value== 2);                       
                        
                        if (PokerHandPairList.Count() == 2)
                        {
                            pokerHandOutput = "Two Pair";
                        }
                        else
                        {
                            pokerHandOutput = "Pair";
                        }
                    }
                    else
                    {
                        int pokerHandRankMaxValueIndex = Array.IndexOf<char>(pokerHandRankValueArray, (pokersHandInputArray[0])[0]);
                        int pokerHandRoyalFlushSequenceCount = 0;
                        if (pokerHandRankMaxValueIndex >= 4)
                        {
                            int j = pokerHandRankMaxValueIndex;
                            int i = 0;
                            int PokerHandRankSequenceCount = 0;

                            for (i = 0; i < pokersHandInputArray.Length && j >= 0; i++)
                            {
                                if (pokerHandRankValueArray[j] == (pokersHandInputArray[i])[0])
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
                            if (PokerHandRankSequenceCount == 5 && pokerHandSuitdict.ContainsValue(5))
                            {
                                pokerHandOutput = "Straight Flush";
                            }
                            else if (PokerHandRankSequenceCount == 5 && !pokerHandSuitdict.ContainsValue(5))
                            {
                                pokerHandOutput = "Straight";
                            }
                            else if (PokerHandRankSequenceCount != 5 && pokerHandSuitdict.ContainsValue(5))
                            {
                                pokerHandOutput = "Flush";
                            }
                            else if (pokerHandRoyalFlushSequenceCount == 5)
                            {
                                pokerHandOutput = "Royal Flush";
                            }
                        }
                        else
                        {
                            for (int i = 0; i < pokersHandInputArray.Length; i++)
                            {
                                if (royalFlushValueArray[i] == (pokersHandInputArray[i])[0])
                                {
                                    pokerHandRoyalFlushSequenceCount += 1;
                                }
                            }
                            if (pokerHandRoyalFlushSequenceCount == 5 && pokerHandSuitdict.ContainsValue(5))
                            {
                                pokerHandOutput = "Royal Flush";
                            }
                            else if(pokerHandSuitdict.ContainsValue(5))
                            {
                                pokerHandOutput = "Flush";
                            }
                        }
                            
                    }
                }
                return pokerHandOutput;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

       
       
    }
}
