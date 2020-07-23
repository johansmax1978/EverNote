using System.Text;

namespace ConsoleApp1
{
    partial class Program
    {
        public class MazeDrawer : IMazeDrawer
        {
            public string DrawMap(bool[,] array, int mazeSize)
            {
                var sb = new StringBuilder();

                for (int i = 0; i < mazeSize; i++)
                {
                    for (int j = 0; j < mazeSize; j++)
                    {
                        sb.Append(array[i, j] ? "@" : " ");
                    }

                    sb.AppendLine("");
                }
                return sb.ToString();
            }
        }
    }
}