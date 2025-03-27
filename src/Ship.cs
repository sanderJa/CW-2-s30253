namespace src;
public class Ship
{
    public string Name { get; }
    public double MaxSpeed { get; set; }
    public int MaxContainerCount { get; }
    public double MaxWeight { get; }
    public double CurrentWeight { get; set; }
    private List<Container> Containers;

    public Ship(string name, double maxSpeed, int maxContainerCount, double maxWeight, double currentWeight)
    {
        Name = name;
        MaxSpeed = maxSpeed;
        MaxContainerCount = maxContainerCount;
        MaxWeight = maxWeight;
        CurrentWeight = currentWeight;
        Containers = new List<Container>();
    }

    public void LoadContainer(List<Container> containers)
    {
        foreach (Container container in containers)
        {
            if (Containers.Count >= MaxContainerCount || CurrentWeight + container.CurrLoad > MaxWeight)
                throw new OverfillException(
                    $"Ship with name {Name} already has a maximum of containers or of their weight");
            Containers.Add(container);
            CurrentWeight += container.CurrLoad;
        }
    }

    public void ChangeContainer(Container container,Container newContainer)
    {
        if (CurrentWeight - container.CurrLoad + newContainer.CurrLoad > MaxWeight)
        {
            throw new OverfillException("Cannot change container too much weight");
        }
        Containers.Remove(container);
        Containers.Add(newContainer);
    }

    public void ChangeShip(Ship newShip, Container container)
    {
        if (newShip.CurrentWeight + container.CurrLoad > newShip.MaxWeight)
        {
            throw new OverfillException("Cannot change ship too much weight");
        }
        Containers.Remove(container);
        CurrentWeight -= container.CurrLoad;
        newShip.Containers.Add(container);
    }

    public void LoadContainer(Container container)
    {
        if (Containers.Count >= MaxContainerCount || CurrentWeight + container.CurrLoad > MaxWeight)
            throw new OverfillException(
                $"Ship with name {Name} already has a maximum of containers or of their weight");
        Containers.Add(container);
        CurrentWeight += container.CurrLoad;
    }

    public void UnloadContainer(Container container)
    {
        Containers.Remove(container);
        CurrentWeight -= container.CurrLoad;
    }

    public void PrintInfo()
    {
        Console.WriteLine(
            $"Statek: {Name}, Prędkość: {MaxSpeed} węzłów, Kontenery: {Containers.Count}/{MaxContainerCount}");
        foreach (var container in Containers)
        {
            Console.WriteLine($"- {container.SerialNumber}, Załadowano: {container.CurrLoad}/{container.Capacity}");
        }
    }
}