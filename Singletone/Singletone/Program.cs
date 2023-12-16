using System;

// Клас Singleton
public sealed class Singleton
{
    private static Singleton instance;
    private static readonly object lockObject = new object();

    // Приватний конструктор, щоб заборонити створення екземплярів поза класом
    private Singleton()
    {
        Console.WriteLine("Singleton instance created.");
    }

    // Публічний метод для отримання єдиного екземпляра класу
    public static Singleton Instance
    {
        get
        {
            // Перевірка, чи екземпляр вже існує
            if (instance == null)
            {
                // Захоплення блокування для потокобезпечності
                lock (lockObject)
                {
                    // Перевірка умови ще раз під час блокування
                    if (instance == null)
                    {
                        instance = new Singleton();
                    }
                }
            }
            return instance;
        }
    }

    // Додаткові методи класу Singleton
    public void DisplayMessage()
    {
        Console.WriteLine("Hello from Singleton!");
    }
}

class Program
{
    static void Main()
    {
        // Отримання єдиного екземпляра
        Singleton singleton1 = Singleton.Instance;
        Singleton singleton2 = Singleton.Instance;

        // Порівняння двох екземплярів (мають бути однакові)
        Console.WriteLine($"singleton1 == singleton2: {singleton1 == singleton2}");

        // Використання єдиного екземпляра
        singleton1.DisplayMessage();
        singleton2.DisplayMessage();
    }
}
