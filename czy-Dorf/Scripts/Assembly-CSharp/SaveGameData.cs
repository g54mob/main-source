using System;
using System.Collections.Generic;

[Serializable]
public abstract class SaveGameData
{
	public int version;

	public abstract void SaveTiles(List<Tile> tilesToSave);

	public abstract void SaveTileStack(List<Tile> stackedTilesToSave);
}
