namespace src;

public class Produkt
{
    public string Name { get; set; }
    public double Weight {get;set; }

    public Produkt(string name, double weight)
    {
        Name = name;
        Weight = weight;
    }
}