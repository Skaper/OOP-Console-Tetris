using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3
{
	class Figure
	{
        protected enum VectorMove { Down, Right, Left, All }
        protected bool isMove;
        protected bool isStop;
        protected bool gameOver = false;
		protected List<Point> pList;
        protected List<FiguresList> figuresLists;

        public Figure(){ }

        public Figure(int model)
        {
            FiguresList figures = new FiguresList();
            figuresLists = figures.GetList();
            figuresLists[1].Rotate();

            pList = String2Points(figuresLists[model].First(), 18, 2);
            Draw();

        }


		public void Draw()
		{
			foreach (Point p in pList)
			{
				p.Draw();
			}
		}
        public void MinPointYInList(List<Point> list, out int minY)
        {
            minY = 18;
            foreach(Point point in list)
            {
                if(point.y <= minY)
                {
                    minY = point.y;
                }
            }
        }

		public void MaxPointInList(List<Point> list, out int _x, out int _y)
		{
			_x = 0;
			_y = 0;
			foreach (Point point in list)
			{
				if (point.x >= _x)
				{
					_x = point.x;
				}
				if (point.y >= _y)
				{
					_y = point.y;
				}
			}

		}

        public int FigureHeight(string strFigure)
        {
            int height = 1;
            foreach(char sym in strFigure)
            {
                if(sym == 'n')
                {
                    height++;
                }
            }
            return height;
        }

        public List<Point> String2Points(String str, int startX, int startY)
        {
            List<Point> figure = new List<Point>();
            int x = startX;
            foreach(char sym in str)
            {
                if(sym == 'n')
                {
                    startY++;
                    x = startX;
                }
                else
                {
                    Point p = new Point(x, startY, sym);
                    figure.Add(p);
                    x++;
                    
                }
            }
            return figure;
        }

        public void ClearPoint(Point point)
        {
            Console.SetCursorPosition(point.x, point.y);
            if (point.sym == '¤')
            {
                Console.Write(' ');
            }
        }

        public void ClearFigure()
        {
            foreach (Point point in pList)
            {
                ClearPoint(point);
            }
        }

        public void scanPoints(ref List<Point> points, ref int score)
        {
            for (int y = 1; y <= 18; y++)
            {
                int xCount = 0;
                for (int x = 1; x <= 10; x++)
                {
                    bool match = points.Any(point => point.y == y && point.x == x && point.sym == '¤');
                    if (match)
                    {
                        xCount++;
                    }
                }
                if (xCount == 10)
                {
                    score += 10; //UPDATE SCORE
                    for (int x = 1; x <= 10; x++)
                    {
                        int index = points.FindIndex(glPoint =>
                               glPoint.x == x
                               && glPoint.y == y
                               && glPoint.sym == '¤');
                        points[index].sym = ' ';
                        points[index].Draw();
                        points.Remove(points[index]);

                    }
                    int targetY = y - 1;
                    moveAllDown(ref points, targetY);
                }
            }
        }
        private void moveAllDown(ref List<Point> points, int targetY)
        {
            for (int y=targetY; y>1; y--)
            {
                for(int x=1; x<=10; x++)
                {
                    int index = points.FindIndex(glPoint =>
                               glPoint.x == x
                               && glPoint.y == y);
                    
                    if (index != -1)
                    {
                            char tmpSym = points[index].sym;
                            points[index].sym = ' ';
                            points[index].Draw();
                            points[index].y += 1;
                            points[index].sym = tmpSym;
                            points[index].Draw();
                    }
                    
                }
            }
        }

    }
}
