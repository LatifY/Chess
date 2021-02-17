using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Chess.Entities;
using Chess.Managers;

namespace Chess
{
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();
		}

		public int SquareSize = 60;
		SquareManager squareManager = new SquareManager();
		BoardManager boardManager = new BoardManager();

		private void Form1_Load(object sender, EventArgs e)
		{
			Square[,] squares = boardManager.CreateBoard();

			foreach (var square in squares)
			{
				board.Controls.Add(square.Pic);
				square.Pic.Click += new EventHandler(delegate { Change(sender,e,square); });
				square.Pic.MouseMove += new MouseEventHandler(delegate { Mouse(sender, e, square); });

				square.Pic.BringToFront();
			}
			boardManager.SetBoard();

		}

		public void Mouse(object sender, EventArgs e, Square square)
		{
			if (square.Pic.BackgroundImage != null)
			{
				Cursor.Current = Cursors.Hand;

			}
			else
			{
				Cursor.Current = Cursors.Default;
			}
		}

		Square from = new Square();
		Square to = new Square();
		Color fromBgColor = new Color();
		int fromColor;
		bool x = true;
		private void Change(object sender, EventArgs e, Square square)
		{
			if (x)
			{
				if (square.Pic.BackgroundImage != null && boardManager.CanMove(square))
				{
					from = square;
					/*
					foreach (var c in from.PossibleSquares)
					{
						boardManager.FindSquareWithText(c).Pic.BackgroundImage = Chess.Properties.Resources.possible_square;
					}
					*/
					fromBgColor = from.Pic.BackColor;
					fromColor = from.Color;
					from.Pic.BackColor = ControlPaint.LightLight(from.Pic.BackColor);

					x = false;
				}
			}
			else if (!x && from.Coordinate == square.Coordinate)
			{
				from.Pic.BackColor = fromBgColor;
				from = null;
				to = null;
				x = true;
			}
			else
			{
				if (from != null && from.Color != square.Color)
				{
					to = square;
					from.Pic.BackColor = fromBgColor;
					from.Color = 0;
					to.Color = fromColor;
					boardManager.Move(from.Coordinate, to.Coordinate);
					moves.Text += $"\n{boardManager.MoveCounter}) {from.Coordinate}-{to.Coordinate}";		
					x = true;
				}
			}
		}

	}
}
