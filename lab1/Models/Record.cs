namespace lab1.Models
{
    public class Record
    {
        public int StudentId { get; set; }
        public string Surname { get; set; }
        public string Discipline { get; set; }
        public int Score { get; set; }

        public Record(int studentId, string surname, string discipline, int score)
        {
            StudentId = studentId;
            Surname = surname;
            Discipline = discipline;
            Score = score;
        }

        public override string ToString()
        {
            return $"ID: {StudentId,-5} | Прізвище: {Surname,-15} | Дисципліна: {Discipline,-20} | Бал: {Score,3}";
        }
    }
}