using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Chess.Entities;
using Chess;
using System.Windows.Forms;
using System.Drawing;

namespace Chess.Managers
{
	public class SquareManager
	{
		public string[] CoordsX = new string[8] { "a", "b", "c", "d", "e", "f", "g", "h" };
		public string[] CoordsY = new string[8] { "1", "2", "3", "4", "5", "6", "7", "8" };

		public Square CreateSquare(int x, int y)
		{
			Square square = new Square();
			int SquareSize = square.SquareSize;
			square.x = x;
			square.y = y;
			square.Coordinate = CoordsX[x] + CoordsY[y];

			square.Pic = new PictureBox();
			square.Pic.BackgroundImageLayout = ImageLayout.Stretch;
			square.Pic.Width = SquareSize;
			square.Pic.Height = SquareSize;
			square.Pic.Left = x * SquareSize;
			square.Pic.Top = SquareSize * 7 - y * SquareSize;
			square.Pic.Image = null;

			if ((x + y) % 2 == 0) { square.Pic.BackColor = Color.FromArgb(118, 150, 86); }
			else { square.Pic.BackColor = Color.FromArgb(238, 238, 210); }

			return square;
		}
	}
}
