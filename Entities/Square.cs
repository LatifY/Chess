using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Chess.Entities
{
	public class Square
	{
		public Square()
		{
			PossibleSquares = new string[2] { "a5","b6"};
		}

		public PictureBox Pic;
		public int Color; //-1 = white; 0 = null; 1 = black;
		public int SquareSize = 60;
		public string Coordinate;
		public int x, y;
		public string[] PossibleSquares;
	}
}
