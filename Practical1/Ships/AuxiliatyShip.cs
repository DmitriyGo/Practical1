namespace Practical1.Ships;

internal class AuxiliatyShip : Ship, iCurative
{
    private int healVolume;
    public AuxiliatyShip(string name, int length, (int, int) position, int velocity, bool isVertical, int healVolume) : base(name, length, position, velocity, isVertical)
    {
        this.HealVolume = healVolume;
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

    public void Heal()
    {
        Console.WriteLine($"{Name} захилил на {HealVolume}хп");
    }
}