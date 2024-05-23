namespace MindboxGeometry;

public class Triangle : IFigure
{
    public Triangle(
        double side1,
        double side2,
        double side3)
    {
        Side1 = CheckSide(side1);
        Side2 = CheckSide(side2);
        Side3 = CheckSide(side3);

        var longestSide = Side1;

        if (longestSide < Side2)
        {
            longestSide = Side2;
        }
        if (longestSide < Side3)
        {
            longestSide = Side3;
        }

        if (longestSide * 2 - Side1 - Side2 - Side3 > 0)
        {
            throw new ArgumentException("Invalid triangle sides. Large side of triangle should be less or equals than sum of the other two");
        }
    }

    public double GetSquare()
    {
        double p = (Side1 + Side2 + Side3) / 2;

        return Math.Sqrt(p * (p - Side1) * (p - Side2) * (p - Side3));
    }

    public bool IsRightAngled()
    {
        double hypotenuse = Side1;
        double leg1 = Side2;
        double leg2 = Side3;

        if (hypotenuse < Side2)
        {
            leg1 = hypotenuse;
            hypotenuse = Side2;
        }

        if (hypotenuse < Side3)
        {
            leg2 = hypotenuse;
            hypotenuse = Side3;
        }

        return leg1 * leg1 + leg2 * leg2 - hypotenuse * hypotenuse < Tolerance;
    }

    private double CheckSide(double side)
    {
        if (side <= 0)
        {
            throw new ArgumentException("Side of triangle must be positive");
        }

        return side;
    }
    
    public double Side1 { get; }
    
    public double Side2 { get; }
    
    public double Side3 { get; }

    private const double Tolerance = 0.00001;
}