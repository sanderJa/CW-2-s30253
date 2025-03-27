namespace src;

public abstract class Container
{
    public static int _idCounter = 1;
    public double Wieght { get; }
    public double Height { get; }
    public double CurrLoad{ get; set; }
    public string SerialNumber { get; set; }
    public double Capacity { get; }

    public Container(double wieght, double height, double capacity)
    {
        CurrLoad = 0;
        Wieght = wieght;
        Height = height;
        Capacity = capacity;
    }

    public virtual void Emptying()
    {
        CurrLoad = 0;
        Console.WriteLine("Emptying Kontener");
    }

    public virtual void Loading(Produkt produkt)
    {
        if (CurrLoad + produkt.Weight > Capacity)
        {
            throw new OverfillException($"For container with serial number {SerialNumber} is too big");
        }
        CurrLoad += produkt.Weight;
        Console.WriteLine($"{SerialNumber}: Wieght = {produkt.Weight}; Capacity = {CurrLoad}");
    }

    public override string ToString()
    {
        return $"{SerialNumber}: Wieght: {Wieght}, Height: {Height}, Capacity: {Capacity}";
    }
}