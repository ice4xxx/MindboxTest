using NUnit.Framework;

namespace MindboxGeometry.Tests;

public static class CircleTests
{
    [TestCase(0, 0)]
    [TestCase(1, Math.PI)]
    [TestCase(1.1234, 3.9647765110105304)]
    [TestCase(50.5555, 8029.46653909834)]
    [TestCase(1000.991231, 3147823.8282920183)]
    public static void Circle_WithCorrectRadius_ShouldGetCorrectSquare(double radius, double answer)
    {
        // arrange
        var circle = new Circle(radius);
        var tolerance = 0.001;
        
        // act & assert
        Assert.LessOrEqual(Math.Abs(answer - circle.GetSquare()), tolerance);
    }

    [Test]
    public static void Circle_WithNegativeRadius_ShouldThrowArgumentException()
    {
        // act & assert
        Assert.Throws<ArgumentException>(() => new Circle(-12.55));
    }
}