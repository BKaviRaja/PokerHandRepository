using System;
using Xunit;
using PokerHandConsoleApp;



namespace PokerHandTestProject
{
    public class PokerHandUnitTest
    {
        PokerHandEvaluationClass PKObj = new PokerHandEvaluationClass();


        [Theory]
        [InlineData("Ac Kc Qc Jc Tc", "Valid Data")]
        [InlineData("8c 7c 6c 5c 4p", "Invalid Data")]
        public void PokerHandInputValidTestEvaluation(string PokerHandValue, string expectedOutput)
        {
            //act and assert
            Assert.Equal(expectedOutput, (PKObj.ValidatePokerHandInput(PokerHandValue)));
        }
        [Theory]
        [InlineData("Ac Kc Qc Jc Tc", "Royal Flush")]
        [InlineData("Ac As Jc Tc Ts", "")]
        public void PokerHandRoyalFlushEvaluation(string PokerHandValue, string expectedOutput)
        {
            //act and assert
            Assert.Equal(expectedOutput, PKObj.Evaluate(PokerHandValue));
        }
        [Theory]
        [InlineData("8c 7c 6c 5c 4c", "Straigh Flush")]
        [InlineData("Ac Kc Qc Jc Ts", "")]
        public void PokerHandStraightFlushEvaluation(string PokerHandValue, string expectedOutput)
        {
            //act and assert
            Assert.Equal(expectedOutput, PKObj.Evaluate(PokerHandValue));
        }
        [Theory]
        [InlineData("Jh Jd Js Jc 7d", "")]
        [InlineData("Ac Kc Qc Jc Ts", "")]
        public void PokerHandFourOfKindEvaluation(string PokerHandValue, string expectedOutput)
        {
            //act and assert
            Assert.Equal(expectedOutput, PKObj.Evaluate(PokerHandValue));
        }
        [Theory]
        [InlineData("Th Td Ts 9c 9d", "")]
        [InlineData("Ac Kc Qc Jc Ts", "")]
        public void PokerHandFullHouseEvaluation(string PokerHandValue, string expectedOutput)
        {
            //act and assert
            Assert.Equal(expectedOutput, PKObj.Evaluate(PokerHandValue));
        }
        [Theory]
        [InlineData("4s Js 8s 2s 9s", "")]
        [InlineData("Ac Kc Qc Jc Ts", "")]
        public void PokerHandFlushEvaluation(string PokerHandValue, string expectedOutput)
        {
            //act and assert
            Assert.Equal(expectedOutput, PKObj.Evaluate(PokerHandValue));
        }
        [Theory]
        [InlineData("9c 8d 7s 6s 5h", "")]
        [InlineData("Ac Kc Qc Jc Ts", "")]
        public void PokerHandStraightEvaluation(string PokerHandValue, string expectedOutput)
        {
            //act and assert
            Assert.Equal(expectedOutput, PKObj.Evaluate(PokerHandValue));
        }
        [Theory]
        [InlineData("J7c 7d 7s Kc 3d", "")]
        [InlineData("Ac Kc Qc Jc Ts", "")]
        public void PokerHandThreeOfaKindEvaluation(string PokerHandValue, string expectedOutput)
        {
            //act and assert
            Assert.Equal(expectedOutput, PKObj.Evaluate(PokerHandValue));
        }
        [Theory]
        [InlineData("4c 4s 3c 3d Qc", "")]
        [InlineData("Ac Kc Qc Jc Ts", "")]
        public void PokerHandTwoPairEvaluation(string PokerHandValue, string expectedOutput)
        {
            //act and assert
            Assert.Equal(expectedOutput, PKObj.Evaluate(PokerHandValue));
        }
        [Theory]
        [InlineData("Ah Ad 8c 4s 7h", "")]
        [InlineData("Ac Kc Qc Jc Ts", "")]
        public void PokerHandOnePairEvaluation(string PokerHandValue, string expectedOutput)
        {
            //act and assert
            Assert.Equal(expectedOutput, PKObj.Evaluate(PokerHandValue));
        }
        [Theory]
        [InlineData("3d Jc 8s 4h 2s", "")]
        [InlineData("Ac Kc Qc Jc Ts", "")]
        public void PokerHandHighCardEvaluation(string PokerHandValue, string expectedOutput)
        {
            //act and assert
            Assert.Equal(expectedOutput, PKObj.Evaluate(PokerHandValue));
        }

    }
}
