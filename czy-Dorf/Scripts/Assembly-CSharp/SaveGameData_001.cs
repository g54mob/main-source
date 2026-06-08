using System;
using System.Collections.Generic;

[Serializable]
public class SaveGameData_001 : SaveGameData
{
	public int level;

	public int score;

	public int biomeSeed;

	public List<TileData_001> tiles;

	public List<TileData_001> tileStack;

	public int tileStackCount = 30;

	public SaveGameData_001()
	{
		version = 1;
		tiles = new List<TileData_001>();
		tileStack = new List<TileData_001>();
	}

	public override void SaveTiles(List<Tile> tilesToSave)
	{
		foreach (Tile item in tilesToSave)
		{
			if (!item.IsInitialTile)
			{
				tiles.Add(new TileData_001(item));
			}
		}
	}

	public override void SaveTileStack(List<Tile> stackedTilesToSave)
	{
		foreach (Tile item in stackedTilesToSave)
		{
			tileStack.Add(new TileData_001(item));
		}
	}
}
