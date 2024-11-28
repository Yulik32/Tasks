using ClassLibrary;
namespace Tasks
{
    public class Rectangle : Kingdom  //класс 
    {
        public Rectangle()
        {
            Name = "Прямоугольник";
            Status = Status.connectingRegions;
        }

        public override void Move()
        {
            Console.WriteLine($"{Name} соединяет оттдаленные регионы, сторя мосты через препятствия.");
        }
        public override void Task()
        {
            Move();
            Status = Status.connectingRegions;
            Console.WriteLine($"{Name} обеспечивает доступность передвижение по королевству.");
        }
    }
}
