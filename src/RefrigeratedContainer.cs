namespace src;

public class RefrigeratedContainer : Container
{
    public string CurrProdukt { get; }
    public List<Produkt> Produkts { get; }
    public double Temperature { get; set; }


    public RefrigeratedContainer(double wieght, double height, double capacity, List<Produkt> produkts,
        double temperature) : base(wieght, height, capacity)
    {
        Temperature = temperature;
        Produkts = produkts;
        SerialNumber = $"KON-R-{_idCounter++}";
    }
    
    public override void Loading(Produkt produkt)
    {
        if (!Produkts.Contains(produkt) && CurrLoad + produkt.Weight > Capacity && CurrProdukt != produkt.Name)
        {
            throw new OverfillException($"For container with serial number {SerialNumber} is too big");
        }

        CurrLoad += produkt.Weight;
        Console.WriteLine($"{SerialNumber}: Wieght = {produkt.Weight}; Capacity = {CurrLoad}");
    }
}