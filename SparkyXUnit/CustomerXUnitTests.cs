using System;
using Xunit;

namespace Sparky
{

    public class CustomerXUnitTests
    {
        private Customer customer;

      
        public  CustomerXUnitTests()
        {
            customer = new Customer();
        }

        [Fact]
        public void CombineName_InputFirstAndLastName_ReturnFullName()
        {
            //Arrange
            //  var customer = new Customer();
            //Act
            customer.GreetAndCombineNames("Ben", "Spark");
            //Assert
            Assert.Equal("Hello, Ben Spark", customer.GreetMessage);
            Assert.Contains("ben Spark".ToLower(), customer.GreetMessage.ToLower());
            Assert.StartsWith("Hello", customer.GreetMessage);
            Assert.EndsWith("Spark", customer.GreetMessage);
            Assert.Matches("Hello, [A-Z]{1}[a-z]+ [A-Z]{1}[a-z]", customer.GreetMessage);

          




        }
        [Fact]
        public void GreetMessage_InputFirstAndLastName_ReturnsNull()
        {
            //arrange
            //  var customer = new Customer();

            //act -> empty bc we do not need to send anything, just check value

            //assert
            Assert.Null(customer.GreetMessage);

        }

        [Fact]
        public void DiscountCheck_DefaultCustomer_ReturnsDiscountInRange()
        {
            int result = customer.Discount;
            Assert.InRange(result,10, 25);
        }

        [Fact]
        public void GreetMessage_GreetedWithoutLastName_ReturnsNotNull()
        {
            customer.GreetAndCombineNames("ben", "");
            Assert.NotNull(customer.GreetMessage);
            Assert.False(string.IsNullOrEmpty(customer.GreetMessage));

        }

        [Fact]
        public void GreetChecker_EmptyFirstName_ThrowsException()
        {
            var exceptionDetails = Assert.Throws<ArgumentException>(() => customer.GreetAndCombineNames("", "Spark"));
            Assert.Equal("Empty First Name", exceptionDetails.Message);
            Assert.Throws<ArgumentException>(() =>customer.GreetAndCombineNames("", "Spark"));
          

        }

        [Fact]

        public void CustomerTypr_CreateCustomerWithLessThan100Order_ReturnBasicCustomer()
        {
            customer.OrderTotal = 10;
            var result = customer.GetCustomerDetails();
            Assert.IsType<BasicCustomer>(result);
        }

        [Fact]

        public void CustomerTypr_CreateCustomerWithMoreThan100Order_ReturnBasicCustomer()
        {
            customer.OrderTotal = 110;
            var result = customer.GetCustomerDetails();
            Assert.IsType<PlatinumCustomer>(result);
        }
    }
}
