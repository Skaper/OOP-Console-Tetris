using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3
{
	class Line: Figure
	{

		public Line(ref List<Figure> figuresOnInterface, LineType lineType, int xStart, int yStart, int length, char sym)
		{
			if (lineType == LineType.Horizontal)
			{
				pList = new List<Point>();
				for (int x = xStart; x < xStart+ length; x++)
				{
					Point p = new Point(x, yStart, sym);
					pList.Add(p);
				}

			}
			else if (lineType == LineType.Vertical)
			{
				pList = new List<Point>();
				for (int y = yStart; y < yStart+length; y++)
				{
					Point p = new Point(xStart, y, sym);
					pList.Add(p);
				}
			}
			figuresOnInterface.Add(this);

		}
	}
}
