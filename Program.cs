using System;
class QuadraticEquation
{
    protected double b2, b1, b0;

    // Віртуальний метод введення коефіцієнтів
    public virtual void Input()
    {
        Console.Write("Введіть коефіцієнти b2, b1, b0: ");
        b2 = double.Parse(Console.ReadLine());
        b1 = double.Parse(Console.ReadLine());
        b0 = double.Parse(Console.ReadLine());
    }

    // Віртуальний метод виведення
    public virtual void Print()
    {
        Console.WriteLine($"Рівняння: {b2}*x^2 + {b1}*x + {b0} = 0");
    }

    // Перевірка: чи задовольняє число x рівняння
    public virtual bool CheckX(double x)
    {
        double y = b2 * x * x + b1 * x + b0;
        return Math.Abs(y) < 1e-6;
    }

    // Метод пошуку коренів квадратного рівняння
    public virtual void Solve()
    {
        double D = b1 * b1 - 4 * b2 * b0;
        Console.WriteLine($"Дискримінант D = {D}");

        if (D < 0)
        {
            Console.WriteLine("Коренів немає");
        }
        else if (Math.Abs(D) < 1e-9)
        {
            double x = -b1 / (2 * b2);
            Console.WriteLine($"Один корінь: x = {x}");
        }
        else
        {
            double x1 = (-b1 + Math.Sqrt(D)) / (2 * b2);
            double x2 = (-b1 - Math.Sqrt(D)) / (2 * b2);
            Console.WriteLine($"Два корені: x1 = {x1}, x2 = {x2}");
        }
    }
}


// ===================================================================
// Похідний клас Кубічне рівняння: a3*x^3 + a2*x^2 + a1*x + a0 = 0
// ===================================================================
class CubicEquation : QuadraticEquation
{
    protected double a3, a2, a1, a0;

    public override void Input()
    {
        Console.Write("Введіть коефіцієнти a3, a2, a1, a0: ");
        a3 = double.Parse(Console.ReadLine());
        a2 = double.Parse(Console.ReadLine());
        a1 = double.Parse(Console.ReadLine());
        a0 = double.Parse(Console.ReadLine());
    }

    public override void Print()
    {
        Console.WriteLine($"Рівняння: {a3}*x^3 + {a2}*x^2 + {a1}*x + {a0} = 0");
    }

    public override bool CheckX(double x)
    {
        double y = a3 * x * x * x + a2 * x * x + a1 * x + a0;
        return Math.Abs(y) < 1e-6;
    }

    // Спрощений пошук коренів кубічного рівняння (демонстраційний)
    public override void Solve()
    {
        Console.WriteLine("Пошук коренів кубічного рівняння.");
        Console.WriteLine("(Точний алгоритм можна додати пізніше)");
    }
}


// ===================================================================
// Головна програма
// ===================================================================
class Program
{
    static void Main(string[] args)
    {
        Console.Write("Оберіть тип рівняння (1 - квадратне, 2 - кубічне): ");
        char userChoose = Console.ReadKey().KeyChar;
        Console.WriteLine();

        // Поліморфізм: оголошуємо посилання на базовий клас
        QuadraticEquation equation;

        // Динамічне створення об’єкта
        if (userChoose == '1')
        {
            equation = new QuadraticEquation();
            Console.WriteLine("Створено об'єкт квадратного рівняння.");
        }
        else
        {
            equation = new CubicEquation();
            Console.WriteLine("Створено об'єкт кубічного рівняння.");
        }

        // Робота через віртуальні методи
        equation.Input();
        equation.Print();
        equation.Solve();

        Console.Write("\nВведіть число x для перевірки: ");
        double xCheck = double.Parse(Console.ReadLine());

        if (equation.CheckX(xCheck))
            Console.WriteLine("Число x задовольняє рівняння!");
        else
            Console.WriteLine("Число x НЕ задовольняє рівняння!");

        Console.ReadLine();
    }
}
