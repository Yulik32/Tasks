using ClassLibrary;
namespace Tasks
{
    public class Circle : Kingdom  //класс круг
    {
        public double Speed { get; set; }
        public Circle(double result)
        {
            Name = "Круг";
            Speed = result;
            Status = Status.clearPath;
        }

        public override void Move()
        {
            Console.WriteLine($"{Name} катится со скоростью {Speed} км/ч");

            if (Speed > 0)
            {
                Status = Status.clearPath;
                Console.WriteLine($"{Name} очищает путь от препятствий.");
            }

            else
            {
                Console.WriteLine($"{Name} столкнулся с препятствием и замедлился.");
            }
        }

        public override void Task()
        {
            Move();
        }
    }
}
