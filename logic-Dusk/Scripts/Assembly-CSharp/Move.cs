using System.Collections.Generic;
using UnityEngine;

public class Move
{
	public Color moveTintColor = Color.red;

	public float moveTintLerp = 1f;

	private List<TileData> _allTiles = new List<TileData>();

	private List<TileData> tiles = new List<TileData>();

	public Move additionalMove;

	public Move previousMove;

	public PieceAnimationSpecialEnum specialAnim;

	public List<TileData> AllTiles
	{
		get
		{
			_allTiles.Clear();
			_allTiles.AddRange(tiles);
			if (additionalMove != null)
			{
				_allTiles.AddRange(additionalMove.AllTiles);
			}
			return _allTiles;
		}
	}

	public int TileCountLocal
	{
		get
		{
			return tiles.Count;
		}
	}

	public int MoveChainCount
	{
		get
		{
			if (additionalMove != null)
			{
				return 1 + additionalMove.MoveChainCount;
			}
			return 1;
		}
	}

	public Move()
	{
	}

	public Move(TileData tile)
	{
		tiles.Add(tile);
	}

	public void AddLocal(TileData tile)
	{
		tiles.Add(tile);
	}

	public void InsertLocal(int index, TileData tile)
	{
		tiles.Insert(index, tile);
	}

	public void Clear()
	{
		tiles.Clear();
		if (additionalMove != null)
		{
			additionalMove.Clear();
		}
	}

	public bool Contains(TileData tile)
	{
		if (additionalMove != null)
		{
			return tiles.Contains(tile) || additionalMove.Contains(tile);
		}
		return tiles.Contains(tile);
	}

	public bool ContainsLocal(TileData tile)
	{
		return tiles.Contains(tile);
	}

	public void highlightTiles()
	{
		foreach (TileData tile in tiles)
		{
			tile.visualComponent.SetTileHighLightColor(moveTintColor, moveTintLerp, "piece move");
		}
		if (additionalMove != null)
		{
			additionalMove.highlightTiles();
		}
	}

	public void highlightTilesAlternate()
	{
		foreach (TileData tile in tiles)
		{
			tile.visualComponent.SetTileHighLightColor(GlobalSettings.TileTints.altMoveColor, GlobalSettings.TileTints.altMoveLerp, "piece alternate move");
		}
		if (additionalMove != null)
		{
			additionalMove.highlightTilesAlternate();
		}
	}

	public void clearHighlight()
	{
		foreach (TileData tile in tiles)
		{
			tile.visualComponent.ClearTileHighLightColor("piece move");
		}
		if (additionalMove != null)
		{
			additionalMove.clearHighlight();
		}
	}

	public void clearHighlightAlternate()
	{
		foreach (TileData tile in tiles)
		{
			tile.visualComponent.ClearTileHighLightColor("piece alternate move");
		}
		if (additionalMove != null)
		{
			additionalMove.clearHighlightAlternate();
		}
	}

	public void addAdditionalMove(Move move)
	{
		if (additionalMove == null)
		{
			additionalMove = move;
			additionalMove.previousMove = this;
		}
		else
		{
			additionalMove.addAdditionalMove(move);
		}
	}

	public Move getLastMoveInChain()
	{
		if (additionalMove != null)
		{
			return additionalMove.getLastMoveInChain();
		}
		return this;
	}

	public TileData getLastTile()
	{
		if (additionalMove != null)
		{
			return additionalMove.getLastTile();
		}
		return tiles[tiles.Count - 1];
	}

	public TileData getLastTileLocal()
	{
		return tiles[tiles.Count - 1];
	}

	public TileData getNextToLastTile()
	{
		if (additionalMove != null)
		{
			return additionalMove.getNextToLastTile();
		}
		if (tiles.Count > 1)
		{
			return tiles[tiles.Count - 2];
		}
		if (previousMove != null)
		{
			return previousMove.getLastTileLocal();
		}
		return null;
	}

	public TileData getFirstTileLocal()
	{
		return tiles[0];
	}

	public TileData getSecondTileLocal()
	{
		if (tiles.Count > 1)
		{
			return tiles[1];
		}
		return null;
	}

	public Move getTruncatedMoveCopyLocal(TileData destTile)
	{
		if (tiles.Contains(destTile))
		{
			Move copy = getCopy();
			int num = copy.TileCountLocal - 1;
			bool flag = false;
			while (num > 0 && !flag)
			{
				if (copy.tiles[num] != destTile)
				{
					copy.tiles.RemoveAt(num);
					num--;
				}
				else
				{
					flag = true;
				}
			}
			return copy;
		}
		return null;
	}

	public Move getTruncatedMoveCopy(TileData tile)
	{
		if (Contains(tile))
		{
			if (ContainsLocal(tile))
			{
				return getTruncatedMoveCopyLocal(tile);
			}
			if (additionalMove != null)
			{
				Move copy = getCopy();
				copy.addAdditionalMove(additionalMove.getTruncatedMoveCopy(tile));
				return copy;
			}
			return null;
		}
		return null;
	}

	public Move getCopy()
	{
		Move move = new Move();
		foreach (TileData tile in tiles)
		{
			move.AddLocal(tile);
		}
		move.specialAnim = specialAnim;
		return move;
	}

	public int getChainCount()
	{
		if (additionalMove != null)
		{
			return 1 + additionalMove.getChainCount();
		}
		return 1;
	}

	public bool hasAdditionalMove()
	{
		return additionalMove != null;
	}

	public bool hasPreviouslMove()
	{
		return previousMove != null;
	}

	public TileData Lerp(float t)
	{
		if (tiles == null || tiles.Count == 0)
		{
			Debug.Log("Should not happen! Move.Lerp() -- has no tiles");
			return null;
		}
		if (t < 0f)
		{
			return tiles[0];
		}
		if (t >= 1f)
		{
			return tiles[tiles.Count - 1];
		}
		int index = (int)((float)tiles.Count * t);
		return tiles[index];
	}
}
