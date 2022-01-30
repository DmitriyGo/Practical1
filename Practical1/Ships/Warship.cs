namespace Practical1.Ships;

internal class Warship : Ship, IShoot
{
    private int damage;
    public Warship(string name, int length, (int, int) position, int velocity, bool isVertical, int damage) : base(name, length, position, velocity, isVertical)
    {
        this.Damage = damage;
    }

    public int Damage
    {
        get
        {
            return damage;
        }
        set
        {
            if (value > 0 && value < 1000)
            {
                damage = value;
            }
            else
            {
                damage = 100;
            }
        }
    }

    public void Shoot()
    {
        Console.WriteLine($"Корабль {Name} пальнул на {Damage} урона");
    }
}