using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//Отрисовка всего интерфейса игры
namespace ConsoleApp3
{
	class GameInterface
	{
		List<Figure> figuresOnInterface;
		List<Point> pointsOnInterface;
		public GameInterface()
		{
			
			figuresOnInterface = new List<Figure>();
			pointsOnInterface = new List<Point>();
		
			new Line(ref figuresOnInterface, LineType.Horizontal, 1, 0, 10, '─');
            new Line(ref figuresOnInterface, LineType.Vertical, 0, 1, 18, '│');
			new Line(ref figuresOnInterface, LineType.Vertical, 11, 1, 18, '│');
			new Line(ref figuresOnInterface, LineType.Horizontal, 1, 19, 10, '─');

			new Point(ref pointsOnInterface, 0, 0, '┌');
			new Point(ref pointsOnInterface, 11, 0, '┐');
			new Point(ref pointsOnInterface, 0, 19, '└');
			new Point(ref pointsOnInterface, 11, 19, '┘');

			new Point(ref pointsOnInterface, 13, 1, '┌');
			new Point(ref pointsOnInterface, 25, 1, '┐');
			new Line(ref figuresOnInterface, LineType.Vertical, 13, 2, 4, '│');
			new Line(ref figuresOnInterface, LineType.Vertical, 25, 2, 4, '│');
			new Point(ref pointsOnInterface, 13, 6, '└');
			new Point(ref pointsOnInterface, 25, 6, '┘');
			new Line(ref figuresOnInterface, LineType.Horizontal, 14, 6, 11, '─');
            
            new Point(ref pointsOnInterface, 13, 7, '┌');
			new Line(ref figuresOnInterface, LineType.Horizontal, 14, 7, 3, '─');
			new Point(ref pointsOnInterface, 25, 7, '┐');
			new Line(ref figuresOnInterface, LineType.Horizontal, 22, 7, 3, '─');
			new Line(ref figuresOnInterface, LineType.Vertical, 13, 7, 4, '│');
			new Line(ref figuresOnInterface, LineType.Vertical, 25, 7, 4, '│');
			new Point(ref pointsOnInterface, 13, 11, '└');
			new Point(ref pointsOnInterface, 25, 11, '┘');
			new Line(ref figuresOnInterface, LineType.Horizontal, 14, 11, 11, '─');

		}

		public void Draw()
		{
			foreach (var figure in figuresOnInterface)
			{
				figure.Draw();
			}

			foreach (var point in pointsOnInterface)
			{
				point.Draw();
			}
            new Text(3, 0, "TETRIS").Draw();
            new Text(17, 7, "SCORE").Draw();
            new Text(18, 9, "0").Draw();
            new Text(14, 1, "NEXT FIGURE").Draw();
            new Text(14, 12, "P - Pause/Easy mode").Draw();
            new Text(14, 13, "Spacebar - Rotate").Draw();
            new Text(14, 14, "L_ARROW - Move left").Draw();
            new Text(14, 15, "R_ARROW - Move right").Draw();
            new Text(14, 16, "D_ARROW - Move down").Draw();
        }
	}
}
