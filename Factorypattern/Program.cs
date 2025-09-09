using System;

// 1. 
public interface ICar
{
    string Model { get; }
    string Color { get; }
    int Power { get; }
    string GetInfo();
}

// 2. 
public class Sedan : ICar
{
    public string Model => "Sedan";
    public string Color { get; }
    public int Power { get; }

    public Sedan(string color, int power)
    {
        Color = color;
        Power = power;
    }

    public string GetInfo()
    {
        return $"Model: {Model}, Farbe: {Color}, Motorleistung: {Power} PS.";
    }
}

public class Truck : ICar
{
    public string Model => "Truck";
    public string Color { get; }
    public int Power { get; }

    public Truck(string color, int power)
    {
        Color = color;
        Power = power;
    }

    public string GetInfo()
    {
        return $"Model: {Model}, Farbe: {Color}, Motorleistung: {Power} PS.";
    }
}

public class ElectricCar : ICar
{
    public string Model => "ElectricCar";
    public string Color { get; }
    public int Power { get; }

    public ElectricCar(string color, int power)
    {
        Color = color;
        Power = power;
    }

    public string GetInfo()
    {
        return $"Model: {Model}, Farbe: {Color}, Motorleistung: {Power} kW.";
    }
}

// 3.
public enum CarType
{
    Sedan,
    Truck,
    Electric
}

// 4. 
public abstract class CarFactory
{
    public abstract ICar CreateCar(string color, int power);
}

// 5. 
public class SedanFactory : CarFactory
{
    public override ICar CreateCar(string color, int power)
    {
        return new Sedan(color, power);
    }
}

public class TruckFactory : CarFactory
{
    public override ICar CreateCar(string color, int power)
    {
        return new Truck(color, power);
    }
}

public class ElectricCarFactory : CarFactory
{
    public override ICar CreateCar(string color, int power)
    {
        return new ElectricCar(color, power);
    }
}

// 6. 
public class CarOrder
{
    private readonly CarFactory _factory;

    public CarOrder(CarFactory factory)
    {
        _factory = factory;
    }

    public ICar OrderCar(string color, int power)
    {
        return _factory.CreateCar(color, power);
    }
}

// 7. 
class Program
{
    static void Main()
    {
        // 
        CarFactory factory = SelectFactory(CarType.Electric);

        // 
        CarOrder order = new CarOrder(factory);
        ICar car = order.OrderCar("Rot", 150);

        Console.WriteLine(car.GetInfo());

        // 
        factory = SelectFactory(CarType.Sedan);
        order = new CarOrder(factory);
        car = order.OrderCar("Blau", 120);
        Console.WriteLine(car.GetInfo());

        factory = SelectFactory(CarType.Truck);
        order = new CarOrder(factory);
        car = order.OrderCar("Weiß", 300);
        Console.WriteLine(car.GetInfo());
    }

    static CarFactory SelectFactory(CarType type)
    {
        switch (type)
        {
            case CarType.Sedan: return new SedanFactory();
            case CarType.Truck: return new TruckFactory();
            case CarType.Electric: return new ElectricCarFactory();
            default: throw new ArgumentException("Unbekannter Maschinentyp");
        }
    }
}