using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using Xunit;
using Microsoft.Extensions.Logging;

namespace StringManipulation.Test
{
    public class StringOperationsTest
    {
        [Fact(Skip = "Ahora mismo esta prueba no es valida, ticket = 0011")]
        public void ConcatenateStrings()
        {
            //Arrange
            var strOperations = new StringOperations();
            
            //Act
            var result = strOperations.ConcatenateStrings("Hola", "platzi");
            
            //Assert
            Assert.NotNull(result);
            Assert.NotEmpty(result);
            Assert.Equal("Hola platzi", result);
        }
        [Theory]
        [InlineData("amma", "hello")]
        [InlineData("hooh", "hoho")]
        public void IsPalindrome_True(string word_true, string word_false)
        {
            //Arrange
            var isPalindrome = new StringOperations();
            
            //Act
            var result_true = isPalindrome.IsPalindrome(word_true);
            var result_false = isPalindrome.IsPalindrome(word_false);
            //Assert
            Assert.True(result_true);
            Assert.False(result_false);
        }
        
        [Fact]
        public void RemoveWhitespace()
        {
            //Arrange
            var removeWhitespace = new StringOperations();
            
            //Act
            var result = removeWhitespace.RemoveWhitespace("Hello World");
            
            //Assert
            Assert.NotNull(result);
            Assert.NotEmpty(result);
            Assert.DoesNotContain(" ",result);
        }
        [Theory]
        [InlineData("cat","cats", 10, "ten")]
        [InlineData("car","cars", 9, "nine")]
        public void QuantintyInWords(string word, string wordInPlural, int Length, string wordLength)
        {
            //Arrange
            var strOperations= new StringOperations();

            //Act
            var result = strOperations.QuantintyInWords(word, Length);
            
            //Assert
            Assert.StartsWith(wordLength, result);
            Assert.Contains(wordInPlural, result);

            
        }
            
        [Fact]
        public void GetStringLength_Exception()
        {
            var strOperations = new StringOperations(); 
            Assert.ThrowsAny<ArgumentNullException>(()=>strOperations.GetStringLength(null));
        }

        [Fact]
        public void TruncateString_Exception()
        {
            var strOperations = new StringOperations(); 
            Assert.ThrowsAny<ArgumentOutOfRangeException>(()=>strOperations.TruncateString("Hello", 0));
        }
        [Theory]
        [InlineData("V", 5)]
        [InlineData("III", 3)]
        [InlineData("X", 10)]
        public void FromRomanToNumber(string romanNumber, int expected)
        {
            var strOperations = new StringOperations();

            var result = strOperations.FromRomanToNumber(romanNumber);
            Assert.Equal(expected, result);
        }
        [Fact]
        public void CountOccurrences()
        {
            
            var mockLogger = new Mock<ILogger<StringOperations>>();
            var strOperations = new StringOperations(mockLogger.Object);

            var result = strOperations.CountOccurrences("Hello platzi", 'l');

            Assert.Equal(3, result);
            
        }
        [Fact]
        public void ReadFile()
        {
            var mockFileReader = new Mock<IFileReaderConector>();
            var strOperations = new StringOperations();
            mockFileReader.Setup(m => m.ReadString(It.IsAny<string>())).Returns("Reading file.");

            var result = strOperations.ReadFile(mockFileReader.Object, "file.txt");

            Assert.Equal("Reading file.", result);
        }
    }
    
}