namespace Practical1.Ships;

internal class MixedTypeShip : Ship, IShoot, iCurative
{
    private int healVolume;
    private int damage;
    public MixedTypeShip(string name, int length, (int, int) position, int velocity, bool isVertical,int damage, int healVolume) : base(name, length, position, velocity, isVertical)
    {
        this.Damage = damage;
        this.HealVolume = healVolume;
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
    
    public int HealVolume
    {
        get
        {
            return healVolume;
        }
        set
        {
            if (value > 0 && value < 1000)
            {
                healVolume = value;
            }
            else
            {
                healVolume = 100;
            }
        }
    }

    public void Shoot()
    {
        Console.WriteLine("Стрельнул");
    }

    public void Heal()
    {
        Console.WriteLine("Захилил");
    }
}