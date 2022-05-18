using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sparky
{
    [TestFixture]
    public class CustomerNUnitTests
    {
        private Customer customer;

        [SetUp]
        public void SetUp()
        {
            customer = new Customer();
        }

        [Test]
        public void CombineName_InputFirstAndLastName_ReturnFullName()
        {
            //Arrange
            //  var customer = new Customer();
            //Act
            customer.GreetAndCombineNames("Ben", "Spark");
            //Assert
            Assert.Multiple(() =>
            {
                Assert.That(customer.GreetMessage, Is.EqualTo("Hello, Ben Spark"));
                Assert.AreEqual(customer.GreetMessage, "Hello, Ben Spark");
                Assert.That(customer.GreetMessage, Does.Contain("ben Spark").IgnoreCase);
                Assert.That(customer.GreetMessage, Does.StartWith("Hello"));
                Assert.That(customer.GreetMessage, Does.EndWith("Spark"));

                Assert.That(customer.GreetMessage, Does.Match("Hello, [A-Z]{1}[a-z]+ [A-Z]{1}[a-z]"));

            });
           



        }
        [Test]
        public void GreetMessage_InputFirstAndLastName_ReturnsNull()
        {
            //arrange
            //  var customer = new Customer();

            //act -> empty bc we do not need to send anything, just check value

            //assert
            Assert.IsNull(customer.GreetMessage);

        }

        [Test]
        public void DiscountCheck_DefaultCustomer_ReturnsDiscountInRange()
        {
            int result = customer.Discount;
            Assert.That(result, Is.InRange(10, 25));
        }

        [Test]
        public void GreetMessage_GreetedWithoutLastName_ReturnsNotNull()
        {
            customer.GreetAndCombineNames("ben", "");
            Assert.IsNotNull(customer.GreetMessage);
            Assert.IsFalse(string.IsNullOrEmpty(customer.GreetMessage));

        }

        [Test]
        public void GreetChecker_EmptyFirstName_ThrowsException()
        {
            var exceptionDetails =
                Assert.Throws<ArgumentException>(() =>
                customer.GreetAndCombineNames("", "Spark"));

           
            Assert.AreEqual("Empty First Name", exceptionDetails.Message);
            
            Assert.That(() => customer.GreetAndCombineNames("", "Spark"),
            Throws.ArgumentException.With.Message.EqualTo("Empty First Name"));



           
               Assert.Throws<ArgumentException>(() =>
               customer.GreetAndCombineNames("", "Spark"));


            Assert.AreEqual("Empty First Name", exceptionDetails.Message);

            Assert.That(() => customer.GreetAndCombineNames("", "Spark"),
            Throws.ArgumentException);

        }

        [Test]

        public void CustomerTypr_CreateCustomerWithLessThan100Order_ReturnBasicCustomer()
        {
            customer.OrderTotal = 10;
           var result= customer.GetCustomerDetails();
            Assert.That(result, Is.TypeOf<BasicCustomer>());
        }

        [Test]

        public void CustomerTypr_CreateCustomerWithMoreThan100Order_ReturnBasicCustomer()
        {
            customer.OrderTotal = 110;
            var result = customer.GetCustomerDetails();
            Assert.That(result, Is.TypeOf<PlatinumCustomer>());
        }
    }
}
