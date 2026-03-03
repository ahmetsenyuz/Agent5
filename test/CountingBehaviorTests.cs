using System;
using Xunit;

namespace Agent5.Tests
{
    public class CountingBehaviorTests
    {
        [Theory]
        [InlineData(1, "1")]
        [InlineData(2, "1,2")]
        [InlineData(5, "1,2,3,4,5")]
        public void CountUpTo_ReturnsCorrectSequence(int input, string expected)
        {
            // Act
            var result = CountUpTo(input);
            
            // Assert
            Assert.Equal(expected, result);
        }

        [Fact]
        public void CountUpTo_ThrowsArgumentException_ForNegativeNumbers()
        {
            // Arrange
            var input = -5;
            
            // Act & Assert
            Assert.Throws<ArgumentException>(() => CountUpTo(input));
        }

        [Fact]
        public void CountUpTo_ThrowsArgumentException_ForZero()
        {
            // Arrange
            var input = 0;
            
            // Act & Assert
            Assert.Throws<ArgumentException>(() => CountUpTo(input));
        }

        [Theory]
        [InlineData(1)]
        [InlineData(100)]
        [InlineData(int.MaxValue)]
        public void CountUpTo_ValidInputs_ReturnCorrectSequence(int input)
        {
            // Act
            var result = CountUpTo(input);
            
            // Assert
            var expected = string.Join(",", Enumerable.Range(1, input));
            Assert.Equal(expected, result);
        }

        private string CountUpTo(int n)
        {
            if (n <= 0)
                throw new ArgumentException("Input must be a positive integer.");
            
            return string.Join(",", Enumerable.Range(1, n));
        }
    }
}