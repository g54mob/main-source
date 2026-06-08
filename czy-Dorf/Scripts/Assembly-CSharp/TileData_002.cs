using System;
using System.Collections.Generic;
using Dorfromantik;
using UnityEngine;

[Serializable]
public class TileData_002 : TileData
{
	public int[] gridPos;

	public int rotationIndex;

	public int seed;

	public List<SegmentData001> segments;

	public string specialTileId;

	public QuestTileData_001 questTileData;

	public static Dictionary<string, SpecialTileId> SpecialTileIdByName = new Dictionary<string, SpecialTileId> { 
	{
		"watertrainstation_6A",
		SpecialTileId.WaterTrainStation
	} };

	public static Dictionary<SpecialTileId, string> SpecialTileNameById = new Dictionary<SpecialTileId, string> { 
	{
		SpecialTileId.WaterTrainStation,
		"watertrainstation_6A"
	} };

	public TileData_002(Tile tile)
	{
		version = 1;
		gridPos = new int[2]
		{
			tile.GridPos.x,
			tile.GridPos.y
		};
		rotationIndex = tile.RotationIndex;
		seed = tile.Seed;
		if (tile is QuestTile questTile)
		{
			questTileData = new QuestTileData_001(questTile);
			return;
		}
		if (tile is SpecialTile specialTile)
		{
			specialTileId = SpecialTileNameById[specialTile.specialTileId];
			return;
		}
		segments = new List<SegmentData001>();
		foreach (ElementGroupSegment allElementGroupSegment in tile.AllElementGroupSegments)
		{
			segments.Add(new SegmentData001(allElementGroupSegment));
		}
	}

	public TileData_002(TileData_001 oldTileData)
	{
		version = 1;
		gridPos = new int[2]
		{
			oldTileData.gridPos.x,
			oldTileData.gridPos.y
		};
		rotationIndex = oldTileData.rotationIndex;
		seed = oldTileData.seed;
		segments = new List<SegmentData001>(oldTileData.segments);
		if (oldTileData.questTileIndex != -1)
		{
			Debug.Log($"load quest Tile with index {oldTileData.questTileIndex}");
			questTileData = new QuestTileData_001();
			questTileData.questTileId = TileData_001.OldToNewQuestTileId[oldTileData.questTileIndex];
			questTileData.questActive = oldTileData.questActive;
			questTileData.questLevel = oldTileData.questLevel;
		}
	}
}
