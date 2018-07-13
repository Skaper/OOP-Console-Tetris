using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3
{
	class Block:Figure
	{
		private List<Point> allPoints;
        private int figureNum;
		private int maxX;
		private int maxY;
        private List<Point> pList_temp;
        delegate void Deligate(Point point, int value);

        public Block(List<Point> allPoints, int figureNum)
        {
            this.figureNum = figureNum;
            this.allPoints = allPoints;
            pList = new List<Point>();
            pList_temp = new List<Point>();
            isMove = true;
            isStop = false;

            FiguresList figures = new FiguresList();
            figuresLists = figures.GetList();

            string stringFigure = figuresLists[figureNum].First();
            int height = FigureHeight(stringFigure);

            int minY;
            MinPointYInList(allPoints, out minY);
            pList = String2Points(stringFigure, 4, 1);

            Draw();

            if (minY <= height)
            {
                isStop = true;
                gameOver = true;
            }
        }
        
        public void Rotate()
        {
            pList_temp = String2Points(figuresLists[figureNum].Rotate(), pList.First().x, pList.First().y);
            MaxPointInList(pList_temp, out maxX, out maxY);
            int minX = pList_temp.First().x;
            if (!checkCollisions(VectorMove.All, pList_temp) && maxX<=10 && minX>=1 && maxY <=18)
            {
                ClearFigure();
                pList = pList_temp;
                ForeachBlock((point, value) => 
                {
                    point.Draw();
                    removeSpace(point);
                }, -1);
                }
            else
            {
                figuresLists[figureNum].CancelRotate();
            }
            

        }

        private void ForeachBlock(Deligate deligate, int value)
        {
            foreach (Point point in pList)
            {
                deligate(point, value);
            }
        }

        public void moveDown()
        {
            MaxPointInList(pList, out maxX, out maxY);
            ClearFigure();
            if(!checkCollisions(VectorMove.Down))
            {
                ForeachBlock((point, value) => 
                {
                    if (maxY < 18)
                    {
                        point.y += 1;
                    }
                    point.Draw();
                    removeSpace(point);
                }, maxY);
            }
            
            if (maxY == 18) { isStop = true; }
        }
        public void removeSpace(Point point, bool end=false)
        {
            bool match = allPoints.Any(glPoint =>
                          glPoint.x == point.x
                          && glPoint.y == point.y
                          && glPoint.sym == '¤'
                          && point.sym == ' ');
            Point backgroundPoint = new Point();
            if (match)
            {
                int index = allPoints.FindIndex(glPoint =>
                   glPoint.x == point.x
                   && glPoint.y == point.y
                   && glPoint.sym == '¤');
                if (end)
                {
                    allPoints[index].sym = '¤';
                    allPoints[index].Draw();
                }
                else
                {
                    backgroundPoint = allPoints[index];
                    backgroundPoint.sym = '¤';
                    backgroundPoint.Draw();
                }
                
            }else if (end && point.sym== '¤')
            {
                point.Draw();
                allPoints.Add(point);
            }
        }

		public void moveRight()
		{
            //maxX = pList.Last().x;
            MaxPointInList(pList, out maxX, out maxY);
            if (!checkCollisions(VectorMove.Right))
            {
                ForeachBlock((point, value) =>
                {
                    if (maxX < 10)
                    {
                        ClearPoint(point);
                    }
                }, maxX);

                ForeachBlock((point, value) => 
                    {
                        if (maxX < 10)
                        {
                            point.x += 1;
                            point.Draw();
                        }
                        removeSpace(point);
                    }, maxX);
            }
		}
        public void moveLeft()
        {
            if (!checkCollisions(VectorMove.Left))
            {
                int minX = pList.First().x;
                ForeachBlock((point, value) => 
                    {
                        if (minX > 1)
                        {
                            ClearPoint(point);
                        }
                    }, minX);

                ForeachBlock((point, value) =>
                    {
                        if (value > 1)
                        {
                            point.x -= 1;
                            point.Draw();
                            removeSpace(point);
                        }
                    }, minX);
            }
        }


        public List<Point> getAllPoints(ref int score)
        {
            ForeachBlock((point, value) => { removeSpace(point, true); }, -1);
            scanPoints(ref allPoints, ref score);
            return allPoints;
        }

        public bool check(){ return isStop; }
        public bool isGameOver() { return gameOver; }

        private bool checkCollisions(VectorMove vector, List<Point> fig = null)
        {
            if (fig == null)
            {
                fig = pList;
            }
            if (allPoints != null)
            {
                foreach (Point p in fig)
                {
                    switch (vector)
                    {
                        case VectorMove.Down:
                        {
                            if (CollisionsMatchDown(p.x, p.y, p.sym))
                            {
                                isStop = true;
                                return true;
                            }
                            break;
                        }
                        case VectorMove.Right:
                        {
                            if (CollisionsMatcRight(p.x, p.y, p.sym)) return true;
                            break;
                        }
                        case VectorMove.Left:
                        {
                            if (CollisionsMatcLeft(p.x, p.y, p.sym)) return true;
                            break;
                        }
                        case VectorMove.All:
                        {
                            if (CollisionsMatchDown(p.x, p.y, p.sym, 0) || CollisionsMatcLeft(p.x, p.y, p.sym, 0) || CollisionsMatcRight(p.x, p.y, p.sym, 0))
                            {
                                return true;
                            }   
                            
                            break;
                        }
                    }
                    

                }

            }
            return false;
        }

        private bool CollisionsMatchDown(int x, int y, char sym, int dist = 1)
        {
            return allPoints.Any(point =>
                                sym == '¤'
                                && point.y == y + dist
                                && point.x == x
                                && point.sym == sym);
        }

        private bool CollisionsMatcRight(int x, int y, char sym, int dist = 1)
        {
            return allPoints.Any(point =>
                                sym == '¤'
                                && point.x == x + dist
                                && point.sym == sym
                                && point.y == y);
        }

        private bool CollisionsMatcLeft(int x, int y, char sym, int dist = 1)
        {
            return allPoints.Any(point =>
                                sym == '¤'
                                && point.x == x - dist
                                && point.sym == sym
                                && point.y == y);
        }

    }
}
