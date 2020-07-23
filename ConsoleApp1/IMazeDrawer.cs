namespace ConsoleApp1
{
    partial class Program
    {
        public interface IMazeDrawer
        {
            string DrawMap(bool[,] array, int mazeSize);

        }
    }
}