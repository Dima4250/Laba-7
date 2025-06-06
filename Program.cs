using Laba_7;
using System;

class Program
{
    static void Main(string[] args)
    {
        BinaryTree<int> tree = new BinaryTree<int>();

        Console.WriteLine("Введите целые числа для добавления в дерево (разделяйте пробелом):");
        string input = Console.ReadLine();

        if (!string.IsNullOrWhiteSpace(input))
        {
            string[] values = input.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            foreach (string value in values)
            {
                if (int.TryParse(value, out int number))
                {
                    tree.Add(number);
                }
                else
                {
                    Console.WriteLine($"Ошибка: '{value}' не является целым числом и будет пропущено.");
                }
            }
        }
        else
        {
            Console.WriteLine("Вы не ввели ни одного числа. Будут использованы значения по умолчанию.\n");
            tree.Add(5);
            tree.Add(3);
            tree.Add(8);
            tree.Add(9);
            tree.Add(10);
            tree.Add(11);
            tree.Add(6);
            tree.Add(2);
        }

        Console.WriteLine("Дерево в порядоке добавления эдементов (прямой обход):");
        foreach (var num in tree.GetPreOrderEnumerable())
            Console.Write(num + " ");

        Console.WriteLine("\n\nОтсортированное дерево (центральный обход):");
        foreach (var num in tree)
            Console.Write(num + " ");

        Console.WriteLine("\n\nОбратный обход:");
        foreach (var num in tree.GetPostOrderEnumerable())
            Console.Write(num + " ");

        Console.WriteLine("\n\nОбратная сортировка:");
        foreach (var num in tree.GetReverseEnumerator())
            Console.Write(num + " ");

        Console.WriteLine("\n");
    }
}