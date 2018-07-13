using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3
{
	class Point
	{
		public int x;
		public int y;
		public char sym;

		public Point(){}

		public Point(int x, int y, char sym)
		{
			this.x = x;
			this.y = y;
			this.sym = sym;
		}

		public Point(ref List<Point> pointsOnInterface, int x, int y, char sym)
		{
			this.x = x;
			this.y = y;
			this.sym = sym;
			pointsOnInterface.Add(this);
		}

		public void Draw()
		{
			Console.SetCursorPosition(x, y);
			Console.Write(sym);
		}

        
	}
}
