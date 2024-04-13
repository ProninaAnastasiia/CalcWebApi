using CalcApp.Controllers;
using NUnit.Framework;

[TestFixture]
public class CalculatorServiceTests
{
    private CalculatorController _calculatorController;

    [SetUp]
    public void Setup()
    {
        _calculatorController = new CalculatorController();
    }

    [Test]
    public void Add_ReturnsRightAddition()
    {
        // Arrange
        double a = 2.5;
        double b = 3.7;
        double expectedSum = 6.2;

        // Act
        var actionResult = _calculatorController.Add(a, b);
        double result = (double)((Microsoft.AspNetCore.Mvc.OkObjectResult)actionResult).Value;

        // Assert
        Assert.AreEqual(expectedSum, result);
    }

    [Test]
    public void Subtract_ReturnsRightSubtraction()
    {
        // Arrange
        double a = 8.9;
        double b = 4.2;
        double expectedDifference = 4.7;

        // Act
        var actionResult = _calculatorController.Subtract(a, b);
        double result = (double)((Microsoft.AspNetCore.Mvc.OkObjectResult)actionResult).Value;

        // Assert
        Assert.AreEqual(expectedDifference, result);
    }

    [Test]
    public void Multiply_ReturnsRightMultiplication()
    {
        // Arrange
        double a = 2.5;
        double b = 3.2;
        double expectedProduct = 8.0;

        // Act
        var actionResult = _calculatorController.Multiply(a, b);
        double result = (double)((Microsoft.AspNetCore.Mvc.OkObjectResult)actionResult).Value;

        // Assert
        Assert.AreEqual(expectedProduct, result);
    }

    [Test]
    public void Divide_ReturnsRightDivision()
    {
        // Arrange
        double a = 9.6;
        double b = 2.4;
        double expectedQuotient = 4.0;

        // Act
        var actionResult = _calculatorController.Divide(a, b);
        double result = (double)((Microsoft.AspNetCore.Mvc.OkObjectResult)actionResult).Value;

        // Assert
        Assert.AreEqual(expectedQuotient, result);
    }

    [Test]
    public void Divide_WhenDivisorZero_ReturnsBadRequest()
    {
        // Arrange
        double a = 6;
        double b = 0;
        string expectedErrorMessage = "Деление на ноль невозможно";

        // Act
        var actionResult = _calculatorController.Divide(a, b);
        string result = (string)((Microsoft.AspNetCore.Mvc.BadRequestObjectResult)actionResult).Value;

        // Assert
        Assert.AreEqual(expectedErrorMessage, result);
    }
}