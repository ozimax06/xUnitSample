using System;
using System.Collections.Generic;
using Xunit;
using SUT = BrokerageLib;

namespace BrokerageLib.xUnit {
	public class XUnitParams {

		[Theory]
		[MemberData("GetTestNumbers")]
		public void ReturnTrue_WhenThereIsAOddDigit(int candidate) {
			// arrange
			var analyzer = new SUT.NumberAnalyzer(candidate);

			// act
			var result = analyzer.ContainsOddDigit();

			// assert
			Assert.True(result);

		}

        [Theory]
        [MemberData("GetTestNumbersToBeCounted")]
        public void ReturnTrue_WhenNumberContainsTwoDigitFour(int candidate)
        {
            // arrange
            var analyzer = new SUT.NumberAnalyzer(candidate);

            // act
            var result = analyzer.GetTheCountOfThisDigit(4);

            // assert
            Assert.Equal(2, result);
        }


        [Fact]
        [MemberData("GetTestNumbersToBeCounted")]
        public void ReturnThrow_WhenDividingByZero()
        {
            // arrange
            var analyzer = new SUT.NumberAnalyzer(100);

            // act
            //var result = analyzer.Divide(0);

            // assert
            Assert.Throws<DivideByZeroException>(() => analyzer.Divide(0));
     
           // Assert.Equal(ex.Message, "Message");

        }

        public static IEnumerable<object> GetTestNumbers() {
			for (int i = 1; i < 6; i += 2)
			{
				yield return new object[] { i };
			}
		}

        public static IEnumerable<object> GetTestNumbersToBeCounted()
        {
            int[] arr = new int[] { 4400, 4134, 4204, 8443 };

            for (int i = 0; i < arr.Length; i++)
            {
                yield return new object[] { arr[i] };
            }
        }

    }
}
