using System;

// Інтерфейс клонування
public interface ICloneable
{
    object Clone();
}

// Клас, який реалізує інтерфейс ICloneable
public class Car : ICloneable
{
    public string Make { get; set; }
    public string Model { get; set; }
    public int Year { get; set; }
    public string Color { get; set; }

    public Car(string make, string model, int year, string color)
    {
        Make = make;
        Model = model;
        Year = year;
        Color = color;
    }

    // Метод клонування
    public object Clone()
    {
        // Глибоке копіювання для примітивних типів даних
        return new Car(Make, Model, Year, Color);
    }

    public override string ToString()
    {
        return $"{Year} {Make} {Model}, Color: {Color}";
    }
}

class Program
{
    static void Main()
    {
        // Створення оригінального об'єкта
        Car originalCar = new Car("Toyota", "Camry", 2022, "Blue");
        Console.WriteLine("Original Car: " + originalCar);

        // Клонування об'єкта
        Car clonedCar = (Car)originalCar.Clone();
        Console.WriteLine("Cloned Car: " + clonedCar);

        // Змінюємо копію і перевіряємо, що оригінальний об'єкт залишився незмінним
        clonedCar.Color = "Red";
        Console.WriteLine("Original Car after cloning: " + originalCar);
        Console.WriteLine("Cloned Car after modification: " + clonedCar);
    }
}
