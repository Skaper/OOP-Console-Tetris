using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApp3
{
	class Program
	{
        Block block;
        static void Main(string[] args)
		{
            List<Point> allPoints = new List<Point>();
            Random rnd = new Random();
            GameInterface gameInterface = new GameInterface();
            Text text = new Text();

            int score = 0;

            
            
			gameInterface.Draw();
            
            int currentFigureNum = rnd.Next(0, 7);
            int nextFigureNum = rnd.Next(0, 7);

            Figure nextFigure = new Figure(nextFigureNum);

            Block block = new Block(allPoints, currentFigureNum);

            long currentTime = DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond;
            long prTime = currentTime;
            long timeInterval = 450;

            //Game
            while (!block.isGameOver())
			{
                if (block.check())
                {
                    allPoints = block.getAllPoints(ref score);
                    text.Score(score);
                    block = new Block(allPoints, nextFigureNum);
                    currentFigureNum = nextFigureNum;
                    nextFigure.ClearFigure();
                    nextFigureNum = rnd.Next(0 , 7);
                    nextFigure = new Figure(nextFigureNum);

                }
                if (Console.KeyAvailable)
				{
					ConsoleKeyInfo key = Console.ReadKey();
					if (key.Key == ConsoleKey.Escape)
					{
						break;
					} else if (key.Key == ConsoleKey.DownArrow)
					{
                        block.moveDown();
                    }
					else if (key.Key == ConsoleKey.RightArrow)
					{
                        block.moveRight();
					}
                    else if (key.Key == ConsoleKey.LeftArrow)
                    {
                        block.moveLeft();
                    }
                    else if (key.Key == ConsoleKey.Spacebar)
                    {
                        block.Rotate();
                    }
                }
                currentTime = DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond;
                if (currentTime - prTime >= timeInterval)
                {
                    block.moveDown();
                    prTime = currentTime;
                }

                Console.SetCursorPosition(13,12);
			}

            //Game OVER
            while (true)
            {
                for(int y=1; y<=18; y++)
                {
                    for(int x=1; x<=10; x++)
                    {
                        Console.SetCursorPosition(x, y);
                        Console.Write('¤');
                        
                    }
                    Thread.Sleep(100);
                }
                Console.SetCursorPosition(1, 9);
                Console.Write(" GAME END ");
                Console.ReadLine();
                break;

            }
		}

       
	}
}
