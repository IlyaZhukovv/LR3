using System;
using System.Collections.Generic;

public class PriorityQueue<T>
{
    //объявляет приватное поле queue типа List<T> для хранения элементов очереди
    private List<T> queue;
    //oбъявляет приватное поле priorities типа List<int> для хранения приоритетов элементов очереди.
    private List<int> priorities;

    //Создает новые экземпляры List<T> и List<int> для queue и priorities соответственно.
    public PriorityQueue()
    {
        queue = new List<T>();
        priorities = new List<int>();
    }

    //метод для добавления элемента item с приоритетом priority в очередь.
    //Он находит правильную позицию в очереди, основываясь на приоритете, и вставляет элемент и приоритет в соответствующие списки.
    public void Enqueue(T item, int priority)
    {
        int index = queue.Count;
        while (index > 0 && priority <= priorities[index - 1])
        {
            index--;
        }

        queue.Insert(index, item);
        priorities.Insert(index, priority);
    }

    //метод для удаления и возврата первого элемента очереди
    public T Dequeue()
    {
        //Он выбрасывает исключение InvalidOperationException, если очередь пуста.
        if (queue.Count == 0)
            throw new InvalidOperationException("Queue is empty");

        T item = queue[0];
        queue.RemoveAt(0);
        priorities.RemoveAt(0);
        return item;
    }

    //свойство, возвращающее количество элементов в очереди.
    public int Count
    {
        get { return queue.Count; }
    }

    //свойство, возвращающее значение true, если очередь пуста, и false в противном случае.
    public bool IsEmpty
    {
        get { return queue.Count == 0; }
    }

    public void Clear()
    {
        queue.Clear();
        priorities.Clear();
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        PriorityQueue<string> queue = new PriorityQueue<string>();

        Console.WriteLine("Введите элементы очереди (для завершения введите 'end'):");
        string input;
        while ((input = Console.ReadLine()) != "end")
        {
            Console.Write("Введите приоритет: ");
            int priority;
            while (!int.TryParse(Console.ReadLine(), out priority) || priority < 0)
            {
                    Console.WriteLine("Некорректный ввод, попробуйте еще раз:");
            }
            queue.Enqueue(input, priority);
        }

        Console.WriteLine("Очередь с приоритетами:");

        while (!queue.IsEmpty)
        {
            string item = queue.Dequeue();
            Console.WriteLine(item);
        }
    }
}