namespace ClassLibrary
{
    public abstract class Kingdom: IMovement, IEvent   //абстрактный класс объединения фигур, включает в себя 2 интерфейса 
    {
        public string Name { get; protected set; }
        public Status Status { get; protected set; }
        public abstract void Move();
        public abstract void Task();
    }
}
