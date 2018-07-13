using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3
{
	class Text
	{
		private int x;
		private int y;
		private String text;

		public Text() { }

		public Text(int x, int y, String text)
		{
			this.x = x;
			this.y = y;
			this.text = text;
		}

        public void Score(int score)
        {
            new Text(18, 9, "      ").Draw();
            new Text(18, 9, score.ToString()).Draw();
            
        }
		public void Draw()
		{
			Console.SetCursorPosition(x, y);
			Console.Write(text);
		}
	}
}
