namespace ConsoleApp1
{
    partial class Program
    {
        public class MazeBuilder : IMazeBuilder
        {
            private enum enumDirection
            {
                up,
                down,
                right,
                left

            }

            private int Row { get; set; }
            private int Column { get; set; }

            private int _mazeSize;

            private enumDirection Direction { get; set; }

            public void Init(int mazeSize)
            {
                _mazeSize = mazeSize;
                Row = 0;
                Column = 0;
                Direction = enumDirection.down;
            }

            void PrintDebug()
            {
                System.Diagnostics.Debug.WriteLine($"{Row},{Column} {Direction}");

            }
            public bool GetNext(bool[,] array)
            {
                switch (Direction)
                {
                    case enumDirection.down:
                        Row++;
                        if (Row == _mazeSize ||(Row!= _mazeSize-1 && array[Row + 1, Column]))
                        {
                            Row--;
                            Column++;
                            Direction = enumDirection.right;
                            return IsStop(array);
                        }
                        break;
                    case enumDirection.up:
                        Row--;
                        if (Row == -1 || (Row>0 && array[Row - 1, Column]))
                        {
                            Row++;
                            Column--;
                            Direction = enumDirection.left;
                            return IsStop(array);
                        }

                        break;

                    case enumDirection.left:
                        Column--;
                        if (Column == -1 ||(Column>0 && array[Row, Column - 1]))
                        {
                            Row++;
                            Column++;
                            Direction = enumDirection.down;
                            return IsStop(array);
                        }

                        break;

                    case enumDirection.right:
                        Column++;
                        if (Column == _mazeSize ||(Column +1<_mazeSize && array[Row, Column + 1]))
                        {
                            Row--;
                            Column--;
                            Direction = enumDirection.up;
                            return IsStop(array);
                        }

                        break;
                    default:
                        return true;

                }

                return false;

            }

            public bool IsStop(bool[,] array)
            {
                switch (Direction)
                {
                    case enumDirection.down:
                        return (Row+2<_mazeSize && array[Row + 2, Column]) || (Row + 1 < _mazeSize && array[Row + 1, Column]);
                        
                    case enumDirection.up:
                        return (Row-2>=0 && array[Row - 2, Column]) || (Row - 1 >= 0 && array[Row - 1, Column]);

                    case enumDirection.left:
                        return (Column-2>=0 && array[Row, Column-2]) || (Column - 1 >= 0 && array[Row, Column - 1]);


                    case enumDirection.right:
                        return (Column+2<_mazeSize && array[Row, Column+2]) ||(Column + 1 < _mazeSize && array[Row, Column + 1]);

                }

                return true;
            }

            public bool[,] GetMaze(int mazeSize)
            {
                var result = new bool[mazeSize, mazeSize];
                Init(mazeSize);
                var max = mazeSize * mazeSize;
                int i = 0;
                bool stop = false;
                while (!stop && i<max)
                {
                    PrintDebug();
                    result[Row, Column] = true;
                    stop = GetNext(result);
                    i++;
                }
                return result;
            }
        }
    }
}