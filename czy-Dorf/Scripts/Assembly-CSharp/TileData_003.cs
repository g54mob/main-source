using System;
using System.Collections.Generic;
using Dorfromantik;

[Serializable]
public class TileData_003 : TileData
{
	public int[] gridPos;

	public int rotation;

	public int seed;

	public List<SegmentData002> segments;

	public SpecialTileId specialTileId;

	public QuestTileData_002 questTileData;

	public TileData_003(Tile tile)
	{
		version = 3;
		gridPos = new int[2]
		{
			tile.GridPos.x,
			tile.GridPos.y
		};
		rotation = tile.RotationIndex;
		seed = tile.Seed;
		if (tile is QuestTile questTile)
		{
			questTileData = new QuestTileData_002(questTile);
			return;
		}
		if (tile is SpecialTile specialTile)
		{
			specialTileId = specialTile.specialTileId;
			return;
		}
		segments = new List<SegmentData002>();
		foreach (ElementGroupSegment allElementGroupSegment in tile.AllElementGroupSegments)
		{
			segments.Add(new SegmentData002(allElementGroupSegment));
		}
	}

	public TileData_003(TileData_002 oldTileData)
	{
		version = 3;
		gridPos = oldTileData.gridPos;
		rotation = oldTileData.rotationIndex;
		seed = oldTileData.seed;
		segments = new List<SegmentData002>();
		if (oldTileData.segments != null)
		{
			foreach (SegmentData001 segment in oldTileData.segments)
			{
				segments.Add(new SegmentData002(segment));
			}
		}
		if (!string.IsNullOrWhiteSpace(oldTileData.specialTileId))
		{
			specialTileId = TileData_002.SpecialTileIdByName[oldTileData.specialTileId];
		}
		if (oldTileData.questTileData != null && QuestTileData_001.questTileIdByName.ContainsKey(oldTileData.questTileData.questTileId))
		{
			questTileData = new QuestTileData_002(oldTileData.questTileData);
		}
	}
}
