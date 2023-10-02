using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exampleLaba
{
    //Класс `Node` представляет узел в очереди и содержит два поля
    public class Node
    {
        //`inf` типа `string`, которое хранит информацию об объекте
        public string inf;
        //`next` типа `Node`, которое указывает на следующий узел в очереди
        public Node next;
    }
    //Класс `Program` содержит два статических поля: 
    public class Program
    {
        //Представляет начало очереди
        public static Node head;
        //Представляет конец очереди
        public static Node last;

        //
        public static void Main(string[] args)
        {
            string menuOption;
            //В цикле выводится меню с опциями для выбора
            //Пользователь вводит выбранную опцию, и в зависимости от
            //этой опции вызывается соответствующий метод или выводится
            //сообщение об ошибке в случае некорректного выбора
            do
            {
                Console.WriteLine("Выберите опцию:");
                Console.WriteLine("1.Добавить элемент в очередь");
                Console.WriteLine("2.Посмотреть очередь");
                Console.WriteLine("3.Удалить элемент из очереди");
                Console.WriteLine("4.Выход");

                menuOption = Console.ReadLine();

                switch (menuOption)
                {
                    case "1":
                        Enqueue();
                        break;
                    case "2":
                        review();
                        break;
                    case "3":
                        Dequeue();
                        break;
                    case "4":
                        Console.WriteLine("Программа завершена");
                        break;
                    default:
                        Console.WriteLine("Неверная опция, попробуйте ещё раз");
                        break;
                }
                Console.WriteLine();
            } while (menuOption != "4");
        }

        //Метод добавляет новый узел в очередь.
        public static void Enqueue()
        {
            //Создается новый узел `p` с использованием метода `CreateNode()`
            Node p = CreateNode();
            //Если очередь пуста, то новый узел становится началом и концом очереди
            if (head == null && p != null)
            {
                head = p;
                last = p;
            }
            //Если очередь не пуста, то новый узел добавляется в конец очереди, а `last` указывает на него.
            else if (head != null && p != null)
            { 
                last.next = p;
                last = p;
            }
            return;
        }

        //Метод `CreateNode` создает новый узел и запрашивает у пользователя данные об объекте.
        public static Node CreateNode()
        {
            Node p = new Node();
            string s;

            Console.WriteLine("Введите название объекта:");
            s = Console.ReadLine();
            //Если пользователь не ввел название объекта, то возвращается `null`
            
            if (string.IsNullOrEmpty(s))
            {
                Console.WriteLine("Запись не была произведена");
                return null;
            }
            //Иначе, узел заполняется данными и возвращается.
            p.inf = s;

            p.next = null;

            return p;
        }

        //Метод `review` выводит содержимое очереди
        public static void review()
        {
            //Переменная `struc` указывает на первый узел в очереди
            Node struc = head;
            //Если очередь пуста, то выводится сообщение об этом
            if (head == null)
            {
                Console.WriteLine("Очередь пуста");
            }
            //Иначе, в цикле выводится название объекта из каждого узла, пока не достигнется конец очереди.
            while (struc != null)
            {
                Console.WriteLine("Имя - {0}", struc.inf);
                struc = struc.next;
            }
            return;
        }

        //Метод `Dequeue` удаляет первый узел из очереди.
        public static void Dequeue()
        {
            //Если очередь пуста, выводится сообщение об этом
            if (head == null)
            {
                Console.WriteLine("Очередь пуста");
                return;
            }
            //Иначе, первый узел удаляется из очереди, и информация об этом выводится на экран.
            Node dequeuedNode = head;
            head = head.next;
            dequeuedNode.next = null;

            Console.WriteLine("Элемент {0} удален из очереди", dequeuedNode.inf);
        }

        //Метод `Contains` проверяет, содержится ли объект с заданным именем в очереди
        public static bool Contains(string name)
        {
            //Переменная `struc` указывает на первый узел в очереди
            Node struc = head;
            // Если очередь пуста, выводится сообщение об этом
            if (head == null)
            {
                Console.WriteLine("Очередь пуста");
            }
            //Иначе, в цикле проверяется каждый узел на соответствие имени.
            while (struc != null)
            {
                //Если совпадение найдено, возвращается `true`
                if (name == struc.inf)
                {
                    return true;
                }
                struc = struc.next;
            }
            //Если цикл завершается без совпадений, возвращается `false`.
            return false;
        }
    }
}
