using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    partial class Program
    {
        static void Main(string[] args)
        {
            var factory = new Factory();

            var maze= factory.GetBuilder().GetMaze(9);

            var mazeString = factory.GetDrawer().DrawMap(maze, 9);

            Console.WriteLine(mazeString);
            Console.ReadLine();
        }
    }
}
