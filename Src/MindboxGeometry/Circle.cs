namespace MindboxGeometry;

public sealed class Circle : IFigure
{
    public Circle(double radius)
    {
        if (radius < 0)
        {
            throw new ArgumentException("Radius must be not negative");
        }
        
        Radius = radius;
    }
    
    public double GetSquare()
    {
        return Radius * Radius * Math.PI;
    }
    
    public double Radius { get; }
}