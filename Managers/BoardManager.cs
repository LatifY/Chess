using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Chess.Entities;

namespace Chess.Managers
{
	public class BoardManager
	{
		SquareManager squareManager = new SquareManager();
		public Square[,] squares = new Square[8, 8];
		public int SquareSize = 60;
		public int Turn = -1; //-1 = white; 0 = null; 1 = black;
		public int MoveCounter;

		Image[] pieces = new Image[12] {
				Chess.Properties.Resources.rook_w, //0
				Chess.Properties.Resources.knight_w, //1
				Chess.Properties.Resources.bishop_w, //2
				Chess.Properties.Resources.queen_w, //3
				Chess.Properties.Resources.king_w, //4
				Chess.Properties.Resources.pawn_w, //5

				Chess.Properties.Resources.rook_b, //6
				Chess.Properties.Resources.knight_b, //7
				Chess.Properties.Resources.bishop_b, //8
				Chess.Properties.Resources.queen_b, //9
				Chess.Properties.Resources.king_b, //10
				Chess.Properties.Resources.pawn_b, //11
		};

		public string[] SquaresW = new string[16]
		{			
			"a2","b2","c2","d2","e2","f2","g2","h2",
			"a1","b1","c1","d1","e1","f1","g1","h1"
		};

		public int[] PiecesW = new int[16]
		{
			5,5,5,5,5,5,5,5,
			0,1,2,3,4,2,1,0
		};

		public string[] SquaresB = new string[16]
		{
			"a7","b7","c7","d7","e7","f7","g7","h7",
			"a8","b8","c8","d8","e8","f8","g8","h8"
		};

		public int[] PiecesB = new int[16]
		{
			11,11,11,11,11,11,11,11,
			6,7,8,9,10,8,7,6
		};

		public Square[,] CreateBoard()
		{
			for (int x = 0; x < 8; x++)
			{
				for (int y = 0; y < 8; y++)
				{
					squares[x, y] = squareManager.CreateSquare(x,y);
				}
			}
			return squares;
		}

		public void SetBoard()
		{
			//White
			for (int i = 0; i < 16; i++)
			{
				Square square = FindSquareWithText(SquaresW[i]);
				square.Pic.BackgroundImage = pieces[PiecesW[i]];
				square.Color = -1;
			}

			//Black
			for (int i = 0; i < 16; i++)
			{
				Square square = FindSquareWithText(SquaresB[i]);
				square.Pic.BackgroundImage = pieces[PiecesB[i]];
				square.Color = 1;
			}
		}

		public void Move(string fromCoordinate, string toCoordinate)
		{
			Square from = FindSquareWithText(fromCoordinate);
			Square to = FindSquareWithText(toCoordinate);

			Image fromPic = from.Pic.BackgroundImage;
			Image toPic = to.Pic.BackgroundImage;
			if (to.Pic != null)
			{
				toPic = null;
			}
			from.Pic.BackgroundImage = toPic;
			to.Pic.BackgroundImage = fromPic;

			MoveCounter++;
			Turn = Turn * -1;
		}

		public bool CanMove(Square square)
		{
			if (square.Color == Turn)
			{
				return true;
			}
			else
			{
				return false;
			}
		}

		public Square FindSquare(int x, int y)
		{
			return squares[x, y];
		}

		public Square FindSquareWithText(string Coordinate)
		{
			for (int x = 0; x < 8; x++)
			{
				for (int y = 0; y < 8; y++)
				{
					if (squares[x, y].Coordinate == Coordinate)
					{
						return squares[x, y];
					}	
				}
			}
			return null;
		}
	}
}
