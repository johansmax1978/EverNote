namespace ConsoleApp1
{
    partial class Program
    {
        public class Factory
        {
            public IMazeBuilder GetBuilder() => new MazeBuilder();
            public IMazeDrawer GetDrawer() => new MazeDrawer();
        }
    }
}