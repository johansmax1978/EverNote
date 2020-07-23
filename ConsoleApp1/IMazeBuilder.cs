namespace ConsoleApp1
{
    partial class Program
    {
        public interface IMazeBuilder
        {
            bool[,] GetMaze(int mazeSize);
        }
    }
}