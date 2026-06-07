using System;

[Serializable]
public class BaseChunkInst
{
	public bool IsPurchased;

	public int X;

	public int Y;

	[NonSerialized]
	public BuildingInst[][] Buildings;

	public BaseTileType[][] Tiles;

	[NonSerialized]
	public ChunkCoverObj CoverObj;

	public BaseChunkInst(int x, int y)
	{
	}

	public void RegisterBuilding(BuildingInst b, bool add, bool allowRecurse)
	{
	}

	public void Clear()
	{
	}
}
