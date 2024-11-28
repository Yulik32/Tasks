using ClassLibrary;
namespace Tasks
{
    public class Square: Kingdom  //класс квадрат
    {
        public Square()
        {
            Name = "Квадрат";
            Status = Status.strongStructures;
        }
        public override void Move()
        {
            Console.WriteLine($"{Name} создает прочные структуры на равнинах.");
        }
        public override void Task()
        {
            Move();
            Status = Status.strongStructures;
            Console.WriteLine($"{Name} обеспечивает надежность.");
        }
    }
}
