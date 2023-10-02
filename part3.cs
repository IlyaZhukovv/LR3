using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laba3Stek
{
    //Класс `Node` представляет узел в стеке и содержит два поля
    public class Node
    {
        //поле `inf`, которое хранит информацию об объекте
        public string inf;
        //поле `next', которое указывает на следующий узел в стеке
        public Node next;
    }

    public class Program
    {
        //определено статическое поле `top`, которое представляет верхний элемент стека
        public static Node top;

        public static void Main(string[] args)
        {
            string menuOption;
            //цикл выводит меню с опциями для выбора
            //пользователь вводит выбранную опцию, и в зависимости от этой опции
            //вызывается соответствующий метод или выводится сообщение об ошибке в случае некорректного выбора
            do
            {
                Console.WriteLine("Выберите опцию:");
                Console.WriteLine("1.Добавить элемент в стек");
                Console.WriteLine("2.Просмотреть стек");
                Console.WriteLine("3.Удалить элемент из стека");
                Console.WriteLine("4.Выход");

                menuOption = Console.ReadLine();

                switch (menuOption)
                {
                    case "1":
                        Push();
                        break;
                    case "2":
                        ViewStack();
                        break;
                    case "3":
                        Pop();
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
        //метод добавляет новый узел в стек
        public static void Push()
        {
            //создается новый узел `p` с использованием метода `CreateNode`
            Node p = CreateNode();
            //Если узел `p` не равен `null`, то узел `p` становится новой вершиной стека
            //а предыдущая вершина стека становится следующим узлом для новой вершины
            if (p != null)
            {
                p.next = top;
                top = p;
            }
            return;
        }

        //Метод создает новый узел и запрашивает у пользователя данные об объекте
        public static Node CreateNode()
        {
            Node p = new Node();
            string s;

            Console.WriteLine("Введите название объекта:");
            s = Console.ReadLine();
            //если пользователь не ввел название объекта, то возвращается `null`
            if (string.IsNullOrEmpty(s))
            {
                Console.WriteLine("Запись не была произведена");
                return null;
            }
            //иначе узел заполняется данными и возвращается
            p.inf = s;

            p.next = null;

            return p;
        }

        //метод выводит содержимое стека
        public static void ViewStack()
        {
            //переменная `struc` указывает на вершину стека
            Node struc = top;
            //если стек пуст, то выводится соответствующее сообщение
            if (top == null)
            {
                Console.WriteLine("Стек пуст");
            }

            //иначе, в цикле выводится название объекта из каждого узла, пока не достигнется конец стека
            while (struc != null)
            {
                Console.WriteLine("Имя - {0}", struc.inf);
                struc = struc.next;
            }
            return;
        }

        //метод удаляет верхний элемент из стека
        public static void Pop()
        {
            //если стек пуст, выводится сообщение об этом
            if (top == null)
            {
                Console.WriteLine("Стек пуст");
                return;
            }
            //иначе, верхний узел удаляется из стека, и информация об этом выводится на экран
            Node poppedNode = top;
            top = top.next;
            poppedNode.next = null;

            Console.WriteLine("Элемент {0} удален из стека", poppedNode.inf);
        }

        //метод проверяет, содержится ли объект с заданным именем в стеке
        public static bool Contains(string name)
        {
            //переменная `struc` указывает на вершину стека
            Node struc = top;
            //если стек пуст, выводится сообщение об этом
            if (top == null)
            {
                Console.WriteLine("Стек пуст");
            }
            //иначе, в цикле проверяется каждый узел на соответствие имени
            while (struc != null)
            {
                //если совпадение найдено, возвращается `true`
                if (name == struc.inf)
                {
                    return true;
                }
                struc = struc.next;
            }
            //если цикл завершается без совпадений, возвращается `false`
            return false;
        }
    }
}
