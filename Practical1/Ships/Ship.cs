namespace Practical1.Ships;

public abstract class Ship
{
    private (int x, int y) position;
    private int length;
    private int velocity;
    private bool isVertical;
    private string name;

    public Ship(string name, int length,(int,int) position, int velocity, bool isVertical)
    {
        this.Name = name;
        this.Length = length;
        this.position = position;
        this.velocity = velocity;
        this.isVertical = isVertical;
    }

    public string Name
    {
        get
        {
            return name;
        }
        set
        {
            if (value.Length < 18)
            {
                name = value;
            }
        }
    }
    public int Length
    {
        get
        {
            return length;
        }
        set
        {
            if (value >= 1 && value <= 5 && value % 2 != 0)
            {
                length = value;
            }
            else
            {
                length = 1;
            }
        }
    }
    
    public (int X, int Y) Position
    {
        get => position;
        set => position = value;
    }
    
    public int Velocity
    {
        get => velocity;
        set
        {
            if (value < 0)
            {
                velocity = 1;
            }
            else
            {
                velocity = value;
            }
        }
    }
    
    public bool IsVertical
    {
        get => isVertical;
        set => isVertical = value;
    }
    
    public static bool operator ==(Ship? s1, Ship? s2)
    {
        if (s1 is null)
        {
            return s2 is null;
        }

        return s1.Equals(s2);
    }

    public static bool operator !=(Ship s1, Ship s2)
    {
        return !(s1 == s2);
    }

    public bool Equals(Ship? other)
    {
        if (ReferenceEquals(null, other))
        {
            return false;
        }

        if (ReferenceEquals(this, other))
        {
            return true;
        }

        return this.Length == other.Length && this.Velocity == other.Velocity && this.GetType() == other.GetType() && this.IsVertical == other.IsVertical;
    }

    public override bool Equals(object? obj)
    {
        if (ReferenceEquals(null, obj))
        {
            return false;
        }

        if (ReferenceEquals(this, obj))
        {
            return true;
        }

        if (obj.GetType() != this.GetType())
        {
            return false;
        }

        return this.Equals((Ship)obj);
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(this.Length, this.Velocity);
    }

    public override string ToString()
    {
        return $"{this.Name} is a {this.GetType()}, length: {this.Length}";
    }
}