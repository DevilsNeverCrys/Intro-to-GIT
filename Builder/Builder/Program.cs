using System;

// Клас, який представляє об'єкт "Автомобіль"
public class Car
{
    public string Make { get; set; }
    public string Model { get; set; }
    public int Year { get; set; }
    public string Color { get; set; }

    public override string ToString()
    {
        return $"{Year} {Make} {Model}, Color: {Color}";
    }
}

// Інтерфейс для білдера
public interface ICarBuilder
{
    ICarBuilder SetMake(string make);
    ICarBuilder SetModel(string model);
    ICarBuilder SetYear(int year);
    ICarBuilder SetColor(string color);
    Car Build();
}

// Клас, який відповідає за конструювання об'єкта "Автомобіль"
public class CarBuilder : ICarBuilder
{
    private Car car;

    public CarBuilder()
    {
        car = new Car();
    }

    public ICarBuilder SetMake(string make)
    {
        car.Make = make;
        return this;
    }

    public ICarBuilder SetModel(string model)
    {
        car.Model = model;
        return this;
    }

    public ICarBuilder SetYear(int year)
    {
        car.Year = year;
        return this;
    }

    public ICarBuilder SetColor(string color)
    {
        car.Color = color;
        return this;
    }

    public Car Build()
    {
        return car;
    }
}

// Клас, який використовує білдер для конструювання об'єкта "Автомобіль"
public class Director
{
    public static Car ConstructSportsCar(ICarBuilder builder)
    {
        return builder.SetMake("SportsMake").SetModel("SportsModel").SetYear(2023).SetColor("Red").Build();
    }
}

// Приклад використання
class Program
{
    static void Main()
    {
        // Використання білдера
        ICarBuilder carBuilder = new CarBuilder();
        Car sportsCar = Director.ConstructSportsCar(carBuilder);

        // Виведення результату
        Console.WriteLine(sportsCar);
    }
}
