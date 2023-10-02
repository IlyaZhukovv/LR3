using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3laba
{
    public class PriorityQueue<T>
    {
        //объявление приватного поля `queue`, которое будет использоваться для
        //хранения элементов и их приоритетов в виде списка кортежей.
        private List<Tuple<T, int>> queue;
        //конструктор класса, который инициализирует список `queue`.
        public PriorityQueue()
        {
            queue = new List<Tuple<T, int>>();
        }

        //метод, который добавляет элемент и его приоритет в очередь
        public void Enqueue(T item, int priority)
        {
            //Кортеж добавляется в список `queue`.
            queue.Add(new Tuple<T, int>(item, priority));
            //Список сортируется в порядке убывания приоритетов элементов.
            queue.Sort((x,y) => y.Item2.CompareTo(x.Item2));
        }

        //метод извлекает элемент с наивысшим приоритетом из очереди
        public T Dequeue()
        {
            //Проверяется, что список `queue` не пустой, иначе вызывается исключение.
            if (queue.Count == 0)
                throw new InvalidOperationException("Queue is empty");
            //Извлекается элемент с наивысшим приоритетом из списка `queue`.
            T item = queue[0].Item1;
            //Элемент удаляется из списка `queue`.
            queue.RemoveAt(0);
            //Извлеченный элемент возвращается.
            return item;
        }
        //свойство `Count`, которое возвращает количество элементов в очереди.
        public int Count
        {
            get { return queue.Count; }
        }
        //свойство `IsEmpty`, которое возвращает `true`, если очередь пуста, иначе `false`.
        public bool IsEmpty
        {
            get { return queue.Count == 0; }
        }

        public void Clear()
        {
            queue.Clear();
        }
    }
    public class Program
    {
        public static void Main(string[] args)
        {
            //создание экземпляра класса
            PriorityQueue<string> queue = new PriorityQueue<string>();

            //вызов метода `Enqueue` для добавления элемента "Item 1" с приоритетом 3 в очередь.
            queue.Enqueue("Item 1", 3);
            //вызов метода `Enqueue` для добавления элемента "Item 2" с приоритетом 1 в очередь.
            queue.Enqueue("Item 2", 1);
            //вызов метода `Enqueue` для добавления элемента "Item 3" с приоритетом 2 в очередь.
            queue.Enqueue("Item 3", 2);

            //цикл будет выполняться, пока очередь не пуста
            while (!queue.IsEmpty)
            {
                //вызов метода `Dequeue` для извлечения элемента с наивысшим приоритетом из очереди и присваивание его переменной `item`
                string item = queue.Dequeue();
                Console.WriteLine(item);
            }    
        }
    }
}
