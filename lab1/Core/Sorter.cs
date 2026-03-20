using System;
using System.Collections.Generic;
using System.Diagnostics;
using lab1.Models;

namespace lab1.Core
{
    public class Sorter
    {
        private List<Record> _records;
        private SortStatistics _statistics;

        public Sorter()
        {
            _records = new List<Record>();
            _statistics = new SortStatistics();
        }

        public void initCollection()
        {
            _records = new List<Record>();
            Console.WriteLine("Колекцію успішно очищено та ініціалізовано.");
        }

        public void addRecord(Record record)
        {
            _records.Add(record);
            Console.WriteLine($"Студента {record.Surname} успішно додано.");
        }

        public void removeRecord(int studentId)
        {
            for (int i = 0; i < _records.Count; i++)
            {
                if (_records[i].StudentId == studentId)
                {
                    Console.WriteLine($"Студента {_records[i].Surname} видалено.");
                    _records.RemoveAt(i);
                    return;
                }
            }
            Console.WriteLine("Студента з таким ID не знайдено.");
        }

        public void printCollection()
        {
            if (_records.Count == 0)
            {
                Console.WriteLine("Колекція порожня.");
                return;
            }

            Console.WriteLine("\n--- Список студентів ---");
            for (int i = 0; i < _records.Count; i++)
            {
                Console.WriteLine(_records[i].ToString());
            }
            Console.WriteLine("------------------------\n");
        }

        public void generateControlData()
        {
            initCollection();
            _records.Add(new Record(1, "Шевченко", "Алгоритми", 95));
            _records.Add(new Record(2, "Коваленко", "Алгоритми", 45));
            _records.Add(new Record(3, "Бойко", "Алгоритми", 78));
            _records.Add(new Record(4, "Ткаченко", "Алгоритми", 62));
            _records.Add(new Record(5, "Кравченко", "Алгоритми", 95));
            _records.Add(new Record(6, "Олійник", "Алгоритми", 88));
            _records.Add(new Record(7, "Марчук", "Алгоритми", 30));
            _records.Add(new Record(8, "Поліщук", "Алгоритми", 75));
            _records.Add(new Record(9, "Савченко", "Алгоритми", 60));
            _records.Add(new Record(10, "Лисенко", "Алгоритми", 90));
            Console.WriteLine("Контрольні дані успішно згенеровано (10 записів).");
        }

        public void sortCollection()
        {
            if (_records.Count <= 1) return;

            _statistics.Reset();
            Stopwatch timer = Stopwatch.StartNew();

            int maxScore = 100;
            int[] count = new int[maxScore + 1];
            Record[] output = new Record[_records.Count];

            for (int i = 0; i < _records.Count; i++)
            {
                count[_records[i].Score]++;
                _statistics.PassesCount++;
            }

            printIntermediateSteps(count, "Масив частот (скільки разів зустрічається кожен бал):");

            for (int i = maxScore - 1; i >= 0; i--)
            {
                count[i] += count[i + 1];
                _statistics.PassesCount++;
            }

            for (int i = _records.Count - 1; i >= 0; i--)
            {
                int score = _records[i].Score;
                output[count[score] - 1] = _records[i];
                count[score]--;
                
                _statistics.CopiesCount++;
                _statistics.PassesCount++;
            }

            for (int i = 0; i < _records.Count; i++)
            {
                _records[i] = output[i];
                _statistics.CopiesCount++;
                _statistics.PassesCount++;
            }

            timer.Stop();
            _statistics.ExecutionTime = timer.Elapsed;
            Console.WriteLine("\nСортування Counting Sort (за спаданням) завершено!");
        }

        public void printIntermediateSteps(int[] countArray, string message)
        {
            Console.WriteLine($"\n[Проміжний етап] {message}");
            for (int i = 0; i < countArray.Length; i++)
            {
                if (countArray[i] > 0)
                {
                    Console.Write($"Бал {i}: {countArray[i]} шт. | ");
                }
            }
            Console.WriteLine();
        }

        public void printStatistics()
        {
            Console.WriteLine(_statistics.ToString());
        }

        public void printAppliedTaskResults()
        {
            if (_records.Count == 0)
            {
                Console.WriteLine("Колекція порожня. Немає даних для аналізу.");
                return;
            }

            int fail = 0;
            int satisfactory = 0;
            int good = 0;
            int excellent = 0;

            int[] modeCount = new int[101];
            int maxFrequency = 0;
            int modeScore = 0;

            for (int i = 0; i < _records.Count; i++)
            {
                int score = _records[i].Score;

                if (score >= 90) excellent++;
                else if (score >= 75) good++;
                else if (score >= 60) satisfactory++;
                else fail++;

                modeCount[score]++;
                if (modeCount[score] > maxFrequency)
                {
                    maxFrequency = modeCount[score];
                    modeScore = score;
                }
            }

            double median;
            int middleIndex = _records.Count / 2;
            if (_records.Count % 2 == 0)
            {
                median = (_records[middleIndex - 1].Score + _records[middleIndex].Score) / 2.0;
            }
            else
            {
                median = _records[middleIndex].Score;
            }

            Console.WriteLine("\n=== АНАЛІЗ РЕЗУЛЬТАТІВ ІСПИТУ ===");
            Console.WriteLine("I & II. Ранжований список від найвищого до найнижчого балу: виконано (див. вивід колекції).");
            Console.WriteLine("III. Статистика успішності:");
            Console.WriteLine($"     Відмінно (90-100): {excellent} студ.");
            Console.WriteLine($"     Добре (75-89):     {good} студ.");
            Console.WriteLine($"     Задовільно (60-74): {satisfactory} студ.");
            Console.WriteLine($"     Не склали (0-59):  {fail} студ.");
            Console.WriteLine($"IV. Найчастіше значення балу (Мода): {modeScore} (зустрічається {maxFrequency} разів)");
            Console.WriteLine($"Додатково. Медіанний бал групи: {median:F1}");
            Console.WriteLine("=================================");
        }
    }
}