using ClassLibrary;
namespace Tasks
{
    public class Triangle : Kingdom  //класс треугольник
    {
        public Triangle()
        {
            Name = "Треугольник";
            Status = Status.strengthenStructures;
        }

        public override void Move()
        {
            Console.WriteLine($"{Name} поднимается на горные вершины, укрепляя нестабильные конструкции местных шахт своими углами.");
        }
        public override void Task()
        {
            Move();
            Status = Status.strengthenStructures;
            Console.WriteLine($"{Name} укрепляет конструкции.");
        }
    }
}
