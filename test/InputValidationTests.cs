using System;
using Xunit;

namespace Agent5.Tests
{
    public class InputValidationTests
    {
        [Fact]
        public void ValidateInput_ThrowsArgumentException_ForNegativeNumbers()
        {
            // Arrange
            var input = -5;
            
            // Act & Assert
            Assert.Throws<ArgumentException>(() => ValidateInput(input));
        }

        [Fact]
        public void ValidateInput_ThrowsArgumentException_ForZero()
        {
            // Arrange
            var input = 0;
            
            // Act & Assert
            Assert.Throws<ArgumentException>(() => ValidateInput(input));
        }

        [Fact]
        public void ValidateInput_DoesNotThrow_ForPositiveIntegers()
        {
            // Arrange
            var input = 5;
            
            // Act & Assert
            Assert.Null(ValidateInput(input));
        }

        [Theory]
        [InlineData(1)]
        [InlineData(100)]
        [InlineData(int.MaxValue)]
        public void ValidateInput_ValidInputs_ReturnNull(int input)
        {
            // Act
            var result = ValidateInput(input);
            
            // Assert
            Assert.Null(result);
        }

        [Theory]
        [InlineData(-1)]
        [InlineData(-100)]
        [InlineData(int.MinValue)]
        public void ValidateInput_InvalidInputs_ThrowArgumentException(int input)
        {
            // Act & Assert
            Assert.Throws<ArgumentException>(() => ValidateInput(input));
        }

        private string ValidateInput(int input)
        {
            if (input <= 0)
                throw new ArgumentException("Input must be a positive integer.");
            
            return null;
        }
    }
}