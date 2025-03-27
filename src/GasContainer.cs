namespace src;

public class GasContainer : Container, IHazardNotifier
{
    public GasContainer(double wieght, double height, double capacity) : base(wieght, height, capacity)
    {
        SerialNumber =  $"KON-G-{_idCounter++}";
    }

    public override void Loading(Produkt produkt)
    {
        try
        {
            base.Loading(produkt);
        }
        catch (OverfillException)
        {
            Notify("Hazard: Gas Container is over");
        }
    }

    public override void Emptying()
    {
        CurrLoad *= 0.05;
    }

    public void Notify(string message)
    {
        Console.WriteLine($"{SerialNumber}: {message}");
    }
}