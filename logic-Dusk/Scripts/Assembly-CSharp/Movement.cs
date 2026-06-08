using System.Collections.Generic;
using UnityEngine;

public class Movement
{
	public List<Move> moves;

	public Piece piece;

	public bool stopAtAllPieces;

	protected BoardScript board;

	public Movement(Piece peice)
	{
		piece = peice;
		moves = new List<Move>();
		board = piece.board;
	}

	public virtual List<Move> updateMoves()
	{
		return null;
	}

	public Move getTruncatedMoveCopy(TileData tile)
	{
		List<Move> list = new List<Move>();
		foreach (Move move2 in moves)
		{
			if (move2.Contains(tile))
			{
				list.Add(move2.getTruncatedMoveCopy(tile));
			}
		}
		if (list.Count <= 0)
		{
			return null;
		}
		Move move = list[0];
		list.RemoveAt(0);
		foreach (Move item in list)
		{
			if (item.getChainCount() < move.getChainCount())
			{
				move = item;
			}
		}
		return move;
	}

	private TileData getTileRelative(int x, int z)
	{
		return piece.board.GetTileRelative(piece.tile, x, z);
	}

	public void highlightMoves()
	{
		foreach (Move move in moves)
		{
			move.highlightTiles();
		}
	}

	public void highlightMovesAlternate()
	{
		foreach (Move move in moves)
		{
			move.highlightTilesAlternate();
		}
	}

	public void clearHighlight()
	{
		foreach (Move move in moves)
		{
			move.clearHighlight();
		}
	}

	public void clearHighlightAlternate()
	{
		foreach (Move move in moves)
		{
			move.clearHighlightAlternate();
		}
	}

	protected Move updateMovesLinear(int Xstep, int Zstep)
	{
		return updateMovesLinear(Xstep, Zstep, piece.tile);
	}

	protected Move updateMovesLinear(int Xstep, int Zstep, TileData startTile)
	{
		Move move = new Move();
		int num = Xstep;
		int num2 = Zstep;
		int num3 = 0;
		bool flag = false;
		while (!flag)
		{
			TileData tileRelative = board.GetTileRelative(startTile, num, num2);
			if (tileRelative == null || !tileRelative.visualComponent.GetComponent<Renderer>().enabled)
			{
				break;
			}
			if (tileRelative.visualComponent.piece != null)
			{
				if (!stopAtAllPieces)
				{
				}
				break;
			}
			move.AddLocal(tileRelative);
			num3++;
			if (piece.MaxMoveStep > 0 && num3 >= piece.MaxMoveStep)
			{
				break;
			}
			num += Xstep;
			num2 += Zstep;
		}
		if (move.TileCountLocal > 0)
		{
			return move;
		}
		return null;
	}
}
