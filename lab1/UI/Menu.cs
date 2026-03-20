using System;
using lab1.Core;
using lab1.Models;

namespace lab1.UI
{
    public class Menu
    {
        private Sorter _sorter;

        public Menu()
        {
            _sorter = new Sorter();
        }

        public void Run()
        {
            bool isRunning = true;

            while (isRunning)
            {
                Console.WriteLine("\n=== ЛАБОРАТОРНА РОБОТА №1: COUNTING SORT ===");
                Console.WriteLine("1. Створити порожню колекцію (initCollection)");
                Console.WriteLine("2. Додати новий результат іспиту (addRecord)");
                Console.WriteLine("3. Видалити результат за ID (removeRecord)");
                Console.WriteLine("4. Вивести поточну колекцію (printCollection)");
                Console.WriteLine("5. Згенерувати контрольні дані (generateControlData)");
                Console.WriteLine("6. Виконати сортування та показати проміжні етапи (sortCollection)");
                Console.WriteLine("7. Вивести статистику алгоритму (printStatistics)");
                Console.WriteLine("8. Вивести результати прикладної задачі (Аналіз іспиту)");
                Console.WriteLine("0. Вихід з програми");
                Console.Write("Оберіть дію: ");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1": _sorter.initCollection(); break;
                    case "2": AddRecordMenu(); break;
                    case "3": RemoveRecordMenu(); break;
                    case "4": _sorter.printCollection(); break;
                    case "5": _sorter.generateControlData(); break;
                    case "6": _sorter.sortCollection(); break;
                    case "7": _sorter.printStatistics(); break;
                    case "8": _sorter.printAppliedTaskResults(); break;
                    case "0": 
                        isRunning = false; 
                        Console.WriteLine("Завершення роботи програми..."); 
                        break;
                    default: 
                        Console.WriteLine("Помилка: Невідома команда. Будь ласка, оберіть номер з меню."); 
                        break;
                }
            }
        }

        private void AddRecordMenu()
        {
            Console.WriteLine("\n--- Додавання нового результату ---");
            int id = ReadInt("Введіть ID студента (ціле число): ");
            
            Console.Write("Введіть прізвище: ");
            string surname = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(surname)) surname = "Невідомо";

            Console.Write("Введіть дисципліну: ");
            string discipline = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(discipline)) discipline = "Невідомо";

            int score = ReadInt("Введіть бал (від 0 до 100): ", 0, 100);

            Record newRecord = new Record(id, surname, discipline, score);
            _sorter.addRecord(newRecord);
        }

        private void RemoveRecordMenu()
        {
            int id = ReadInt("\nВведіть ID студента для видалення: ");
            _sorter.removeRecord(id);
        }

        private int ReadInt(string prompt, int min = int.MinValue, int max = int.MaxValue)
        {
            int result;
            while (true)
            {
                Console.Write(prompt);
                string input = Console.ReadLine();
                if (int.TryParse(input, out result) && result >= min && result <= max)
                {
                    return result;
                }
                Console.WriteLine($"Помилка: Введіть коректне ціле число від {min} до {max}. Спробуйте ще раз.");
            }
        }
    }
}