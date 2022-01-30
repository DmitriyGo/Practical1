using Practical1.Ships;

namespace Practical1;

public class GameProperties
{
    public int[,] Field;
    public List<Ship> ShipsOnField = new List<Ship>();
    public List<Ship> ShipsOnFieldSorted = new List<Ship>();

    public GameProperties(int fieldSize)
    {
        if (fieldSize < 0)
        {
            Field = new int[10, 10];
        }
        else
        {
            Field = new int[fieldSize, fieldSize];
        }
    }

    public Ship this[(int x, int y) position]
    {
        get
        {
            for (int i = 0; i < ShipsOnField.Count; i++)
            {
                if (ShipsOnField[i].Position == position)
                {
                    return ShipsOnField[i];
                }
            }

            return null;
        }
    }
    public double LengthBetweenPoints((double x, double y) point1, (double x, double y) point2)
    {
        return Math.Sqrt(Math.Pow(point2.x - point1.x, 2) + Math.Pow(point2.y - point1.y, 2));
    }
}