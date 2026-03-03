using System;
using Xunit;

namespace Agent5.Tests
{
    public class ErrorHandlingTests
    {
        [Theory]
        [InlineData(-1)]
        [InlineData(-100)]
        [InlineData(int.MinValue)]
        public void ProcessInput_ThrowsArgumentException_ForInvalidInputs(int input)
        {
            // Act & Assert
            Assert.Throws<ArgumentException>(() => ProcessInput(input));
        }

        [Fact]
        public void ProcessInput_ThrowsArgumentException_ForZero()
        {
            // Act & Assert
            Assert.Throws<ArgumentException>(() => ProcessInput(0));
        }

        [Theory]
        [InlineData(1)]
        [InlineData(10)]
        [InlineData(100)]
        public void ProcessInput_SuccessfullyProcessesValidInputs(int input)
        {
            // Act
            var result = ProcessInput(input);
            
            // Assert
            Assert.NotNull(result);
            Assert.NotEmpty(result);
        }

        [Fact]
        public void ProcessInput_HandlesMaximumReasonableInput()
        {
            // Arrange
            var input = 1000; // Maximum reasonable input
            
            // Act
            var result = ProcessInput(input);
            
            // Assert
            Assert.NotNull(result);
            Assert.NotEmpty(result);
        }

        private string ProcessInput(int input)
        {
            if (input <= 0)
                throw new ArgumentException("Input must be a positive integer.");
            
            // Simulate some processing
            return $"Processed {input} successfully";
        }
    }
}