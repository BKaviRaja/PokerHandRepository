using System;
using Xunit;
using PokerHandConsoleApp;



namespace PokerHandTestProject
{
    public class PokerHandUnitTest
    {
        PokerHandEvaluationClass PokerHandEvaluation = new PokerHandEvaluationClass();


        [Theory]
        [InlineData("Ac Kc Qc Jc Tc", true)] 
        [InlineData("8c 7c 7c 5c 4p", false)]
        public void PokerHandInputValidTestEvaluation(string PokerHandValue, bool expectedOutput)
        {
            //act and assert
            Assert.Equal(expectedOutput, (PokerHandEvaluation.ValidatePokerHandInput(PokerHandValue)));
        }       
        [Theory]
        [InlineData("Ac Kc Qc Jc Tc", "Royal Flush")]        
        public void PokerHandRoyalFlushEvaluation(string PokerHandValue, string expectedOutput)
        {
            //act and assert
            Assert.Equal(expectedOutput, PokerHandEvaluation.Evaluate(PokerHandValue));
        }
        [Theory]
        [InlineData("8c 7c 6c 5c 4c", "Straight Flush")]      
        public void PokerHandStraightFlushEvaluation(string PokerHandValue, string expectedOutput)
        {
            //act and assert
            Assert.Equal(expectedOutput, PokerHandEvaluation.Evaluate(PokerHandValue));
        }
        [Theory]
        [InlineData("Jh Jd Js Jc 7d", "Four of a Kind")]        
        public void PokerHandFourOfKindEvaluation(string PokerHandValue, string expectedOutput)
        {
            //act and assert
            Assert.Equal(expectedOutput, PokerHandEvaluation.Evaluate(PokerHandValue));
        }
        [Theory]
       [InlineData("Th Td Ts 9c 9d", "Full House")]      
        public void PokerHandFullHouseEvaluation(string PokerHandValue, string expectedOutput)
        {
            //act and assert
            Assert.Equal(expectedOutput, PokerHandEvaluation.Evaluate(PokerHandValue));
        }
        [Theory]
        [InlineData("4s Js 8s 2s 9s", "Flush")]       
        public void PokerHandFlushEvaluation(string PokerHandValue, string expectedOutput)
        {
            //act and assert
            Assert.Equal(expectedOutput, PokerHandEvaluation.Evaluate(PokerHandValue));
        }
        [Theory]
        [InlineData("9c 8d 7s 6s 5h", "Straight")]
        public void PokerHandStraightEvaluation(string PokerHandValue, string expectedOutput)
        {
            //act and assert
            Assert.Equal(expectedOutput, PokerHandEvaluation.Evaluate(PokerHandValue));
        }
        [Theory]
        [InlineData("7c 7d 7s Kc 3d", "Three of a Kind")]
        public void PokerHandThreeOfaKindEvaluation(string PokerHandValue, string expectedOutput)
        {
            //act and assert
            Assert.Equal(expectedOutput, PokerHandEvaluation.Evaluate(PokerHandValue));
        }
        [Theory]
        [InlineData("2c 2s 3c 3d Qc", "Two Pair")]
        public void PokerHandTwoPairEvaluation(string PokerHandValue, string expectedOutput)
        {
            //act and assert
            Assert.Equal(expectedOutput, PokerHandEvaluation.Evaluate(PokerHandValue));
        }
        [Theory]
        [InlineData("Ah Ad 8c 4s 7h", "Pair")]
        public void PokerHandOnePairEvaluation(string PokerHandValue, string expectedOutput)
        {
            //act and assert
            Assert.Equal(expectedOutput, PokerHandEvaluation.Evaluate(PokerHandValue));
        }
        //[Theory]
        //[InlineData("3d Jc 8s 4h 2s", "")]
        //[InlineData("Ac Kc Qc Jc Ts", "")]
        //public void PokerHandHighCardEvaluation(string PokerHandValue, string expectedOutput)
        //{
        //    //act and assert
        //    Assert.Equal(expectedOutput, PKObj.Evaluate(PokerHandValue));
        //}
        [Theory]        
        [InlineData("Ac Kc Qc Jc Ts", "No Match")]
        public void PokerHandNoMatchEvaluation(string PokerHandValue, string expectedOutput)
        {
            //act and assert
            Assert.Equal(expectedOutput, PokerHandEvaluation.Evaluate(PokerHandValue));
        }

    }
}
