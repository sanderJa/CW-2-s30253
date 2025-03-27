namespace src;

public class LiquidContainer : Container, IHazardNotifier
{
    public bool isHazard { get; }

    public LiquidContainer(double wieght, double height, double capacity, bool isHazard) : base(wieght, height,
        capacity)
    {
        this.isHazard = isHazard;
        SerialNumber = $"KON-L-{_idCounter++}";
    }

    public override void Loading(Produkt produkt)
    {
        if (isHazard && CurrLoad + produkt.Weight > Capacity / 2)
        {
            Notify("Hazardous");
            throw new OverfillException($"For container with serial number {SerialNumber} is too big");
        }
        if (CurrLoad + produkt.Weight > Capacity * 0.9)
        {
            Notify("Hazardous");
            throw new OverfillException($"For container with serial number {SerialNumber} is too big");
        }
        CurrLoad += produkt.Weight;
        Console.WriteLine($"{SerialNumber}: Wieght = {produkt.Weight}; Capacity = {CurrLoad}");
    }

    public void Notify(string message)
    {
        Console.WriteLine($"{SerialNumber}: {message}");
    }
}