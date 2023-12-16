using System;

// Інтерфейс для створення продуктів першого типу
public interface IProductA
{
    string GetName();
}

// Конкретний продукт першого типу
public class ConcreteProductA1 : IProductA
{
    public string GetName()
    {
        return "ConcreteProductA1";
    }
}

// Інтерфейс для створення продуктів другого типу
public interface IProductB
{
    string GetName();
}

// Конкретний продукт другого типу
public class ConcreteProductB1 : IProductB
{
    public string GetName()
    {
        return "ConcreteProductB1";
    }
}

// Абстрактна фабрика для створення сімейства пов'язаних продуктів
public interface IAbstractFactory
{
    IProductA CreateProductA();
    IProductB CreateProductB();
}

// Конкретна фабрика, яка реалізує абстрактну фабрику
public class ConcreteFactory1 : IAbstractFactory
{
    public IProductA CreateProductA()
    {
        return new ConcreteProductA1();
    }

    public IProductB CreateProductB()
    {
        return new ConcreteProductB1();
    }
}

// Клієнтський код, який використовує фабрику
class Program
{
    static void Main()
    {
        // Створення конкретної фабрики
        IAbstractFactory factory = new ConcreteFactory1();

        // Виклик методів фабрики для створення продуктів
        IProductA productA = factory.CreateProductA();
        IProductB productB = factory.CreateProductB();

        // Виведення результату
        Console.WriteLine(productA.GetName()); // Виведе "ConcreteProductA1"
        Console.WriteLine(productB.GetName()); // Виведе "ConcreteProductB1"
    }
}
