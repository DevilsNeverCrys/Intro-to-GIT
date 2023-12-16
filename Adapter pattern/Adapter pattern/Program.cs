using System;

// Інтерфейс, який визначає функціональність, яку клієнт очікує від адаптера
public interface ITarget
{
    void Request();
}

// Клас, який містить корисну функціональність, але не сумісний із ITarget
public class Adaptee
{
    public void SpecificRequest()
    {
        Console.WriteLine("SpecificRequest called.");
    }
}

// Адаптер, який дозволяє класу Adaptee взаємодіяти з ITarget
public class Adapter : ITarget
{
    private readonly Adaptee adaptee;

    public Adapter(Adaptee adaptee)
    {
        this.adaptee = adaptee;
    }

    public void Request()
    {
        adaptee.SpecificRequest();
    }
}

// Клієнтський код
class Program
{
    static void Main()
    {
        // Використання адаптера для спільної роботи класу Adaptee із ITarget
        Adaptee adaptee = new Adaptee();
        ITarget adapter = new Adapter(adaptee);

        // Виклик методу Request через ITarget
        adapter.Request();
    }
}
