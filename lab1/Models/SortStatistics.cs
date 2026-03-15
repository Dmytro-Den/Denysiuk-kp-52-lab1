using System;

namespace lab1.Models
{
    public class SortStatistics
    {
        public int ComparisonsCount { get; set; }
        public int CopiesCount { get; set; }
        public int PassesCount { get; set; }
        public TimeSpan ExecutionTime { get; set; }

        public void Reset()
        {
            ComparisonsCount = 0;
            CopiesCount = 0;
            PassesCount = 0;
            ExecutionTime = TimeSpan.Zero;
        }

        public override string ToString()
        {
            return "\n--- Статистика роботи алгоритму ---\n" +
                   $"Кількість порівнянь: {ComparisonsCount}\n" +
                   $"Кількість копіювань (переміщень): {CopiesCount}\n" +
                   $"Кількість проходів по масивах: {PassesCount}\n" +
                   $"Час виконання: {ExecutionTime.TotalMilliseconds} мс\n" +
                   "-----------------------------------";
        }
    }
}