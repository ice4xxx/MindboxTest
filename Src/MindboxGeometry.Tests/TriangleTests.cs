using NUnit.Framework;

namespace MindboxGeometry.Tests;

public static class TriangleTests
{
    [TestCase(1, 2, 3, 0)]
    [TestCase(1, 2, 2, 0.968246)]
    [TestCase(2, 2, 2, 1.732051)]
    [TestCase(39, 12, 30, 134.831144)]
    [TestCase(1.542, 2.1231, 1.4214, 1.095558)]
    [TestCase(93.41234, 54.12345, 68.4125, 1830.207453)]
    [TestCase(9333.41234, 5444.12345, 6888.4125, 18582472.024476)]
    public static void Triangle_WithCorrectSides_ShouldGetCorrectSquare(double side1, double side2, double side3, double answer)
    {
        // arrange
        var triangle = new Triangle(side1, side2, side3);
        var tolerance = 0.00001;
        
        // act & assert
        Assert.Less(answer - triangle.GetSquare(), tolerance);
    }

    [TestCase(1, 2, 3.1)]
    [TestCase(1, 2, 3.0000001)]
    [TestCase(0,0,0)]
    [TestCase(0,0,0.1)]
    [TestCase(30,20,9)]
    [TestCase(-30,30, 30)]
    [TestCase(-30,-30, 30)]
    [TestCase(-30,-30, -30)]
    [TestCase(30,-30, 30)]
    [TestCase(30,-30, -30)]
    [TestCase(30,30, -30)]
    public static void Triangle_WithIncorrectSides_ShouldThrowArgumentException(double side1, double side2, double side3)
    {
        // act & assert
        Assert.Throws<ArgumentException>(() => new Triangle(side1, side2, side3));
    }

    [TestCase(3, 4, 5)]
    [TestCase(32, 60, 68)]
    [TestCase(15, 112, 113)]
    [TestCase(1.54161385, 1.89873511, 1.10843276)]
    public static void Triangle_RightAngledSides_ShouldRightAngled(double side1, double side2, double side3)
    {
        // assert
        var triangle = new Triangle(side1, side2, side3);
        
        // act & assert
        Assert.IsTrue(triangle.IsRightAngled());
    }
}