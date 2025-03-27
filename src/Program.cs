using src;


{
    Ship ship = new Ship("Titanic", 100, 1000, 4000, 0);
    Ship ship2 = new Ship("Titanic2", 100, 1000, 4000, 0);

    Container c1 = new GasContainer(200, 4.5, 1000);
    Container c2 = new LiquidContainer(250, 4.5, 800, false);
    Container c3 = new RefrigeratedContainer(300, 4.5, 600,
        [new Produkt("Banana", 0), new Produkt("Chocolate", 0), new Produkt("Butter", 0)], 18);
    Container c4 = new GasContainer(200, 4.5, 1000);

    Produkt gaz = new Produkt("Gaz", 900);
    Produkt gaz2 = new Produkt("Gaz", 800);
    Produkt liquid = new Produkt("Liquid", 700);
    Produkt banana = new Produkt("Banana", 500);

    c1.Loading(gaz);
    c2.Loading(liquid);
    c3.Loading(banana);
    c4.Loading(gaz2);
    Console.WriteLine();

    Console.WriteLine("Containers Loaded");
    Console.WriteLine(c1);
    Console.WriteLine(c2);
    Console.WriteLine(c3);
    Console.WriteLine();

    ship.LoadContainer(c1);
    ship.LoadContainer(c2);
    ship.LoadContainer(c3);

    ship.PrintInfo();
    Console.WriteLine();


    ship.ChangeShip(ship2, c1);
    ship.ChangeContainer(c1, c4);

    ship.PrintInfo();
    Console.WriteLine();

    ship2.PrintInfo();
    Console.WriteLine();

    Container c5 = new GasContainer(200, 4.5, 1000);
    gaz.Weight = 1001;
    c5.Loading(gaz);
}