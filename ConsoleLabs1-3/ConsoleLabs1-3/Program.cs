using System;

bool exit = false;

while (!exit)
{
    Console.Clear();
    Console.WriteLine("=== ГЛАВНОЕ МЕНЮ ===");
    Console.WriteLine("1. Площадь прямоугольника");
    Console.WriteLine("2. Площадь треугольника");
    Console.WriteLine("3. Площадь круга");
    Console.WriteLine("4. Выход");
    Console.Write("\nВыберите пункт: ");

    string choice = Console.ReadLine();

    switch (choice)
    {
        case "1": CalculateRectangle(); break;
        case "2": CalculateTriangle(); break;
        case "3": CalculateCircle(); break;
        case "4": exit = true; break;
        default:
            Console.WriteLine("Ошибка: выберите пункт от 1 до 4.");
            Console.ReadKey();
            break;
    }
}

void CalculateRectangle()
{
    do
    {
        Console.WriteLine("\n[ПРЯМОУГОЛЬНИК]");
        double a = ReadDouble("Введите сторону A: ");
        double b = ReadDouble("Введите сторону B: ");

        if (a <= 0 || b <= 0) Console.WriteLine("Некорректный ввод: значения должны быть > 0");
        else Console.WriteLine($"Результат: Площадь = {a * b:F2}");

    } while (AskToContinue());
}

void CalculateTriangle()
{
    do
    {
        Console.WriteLine("\n[ТРЕУГОЛЬНИК]");
        double a = ReadDouble("Сторона A: ");
        double b = ReadDouble("Сторона B: ");
        double c = ReadDouble("Сторона C: ");

        if (a <= 0 || b <= 0 || c <= 0) Console.WriteLine("Некорректный ввод");
        else if (a + b <= c || a + c <= b || b + c <= a) Console.WriteLine("Вычисление невозможно");
        else
        {
            double p = (a + b + c) / 2;
            double s = Math.Sqrt(p * (p - a) * (p - b) * (p - c));
            Console.WriteLine($"Результат: Площадь = {s:F2}");
        }
    } while (AskToContinue());
}

void CalculateCircle()
{
    do
    {
        Console.WriteLine("\n[КРУГ]");
        double r = ReadDouble("Введите радиус: ");

        if (r <= 0) Console.WriteLine("Некорректный ввод");
        else Console.WriteLine($"Результат: Площадь = {Math.PI * Math.Pow(r, 2):F2}");

    } while (AskToContinue());
}

double ReadDouble(string message)
{
    double result;
    Console.Write(message);
    while (!double.TryParse(Console.ReadLine(), out result))
    {
        Console.Write("Ошибка! Введите числовое значение: ");
    }
    return result;
}

bool AskToContinue()
{
    Console.Write("Продолжить вычисление (Y/N)? ");
    char key = char.ToUpper(Console.ReadKey().KeyChar);
    Console.WriteLine();
    return key != 'N';
}
