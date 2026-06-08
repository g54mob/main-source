using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class TileData_001 : TileData
{
	public Vector2Int gridPos;

	public int rotationIndex;

	public int seed;

	public int questTileIndex;

	public List<SegmentData001> segments;

	public bool questActive;

	public int questLevel;

	public static Dictionary<int, string> OldToNewQuestTileId = new Dictionary<int, string>
	{
		{ 0, "fields_base_2A_2AV_1AV" },
		{ 1, "fields_windmill_6A" },
		{ 2, "forest_base_1A" },
		{ 3, "forest_base_4A" },
		{ 4, "train_locomotive_2C" },
		{ 5, "train_base_4C_1AF_1AF" },
		{ 6, "village_base_2A" },
		{ 7, "water_boat_2C" },
		{ 8, "water_base_6A" },
		{ 9, "train_base_2B_3AF_1AF" }
	};

	public static Dictionary<string, int> NewToOldQuestTileId = new Dictionary<string, int>
	{
		{ "fields_base_2A_2AV_1AV", 0 },
		{ "fields_windmill_6A", 1 },
		{ "forest_base_1A", 2 },
		{ "forest_base_4A", 3 },
		{ "train_base_4C_1AF_1AF", 5 },
		{ "train_locomotive_2C", 4 },
		{ "village_base_2A", 6 },
		{ "water_boat_2C", 7 },
		{ "water_base_6A", 8 },
		{ "train_base_2B_3AF_3AF", 9 }
	};

	public TileData_001(Tile tile)
	{
		version = 1;
		gridPos = tile.GridPos;
		rotationIndex = tile.RotationIndex;
		seed = tile.Seed;
		if (tile is QuestTile questTile)
		{
			questTileIndex = NewToOldQuestTileId[questTile.questTileId];
			questLevel = questTile.level;
			if (questTile.QuestWatcher.Watching)
			{
				questActive = true;
			}
			return;
		}
		segments = new List<SegmentData001>();
		foreach (ElementGroupSegment allElementGroupSegment in tile.AllElementGroupSegments)
		{
			segments.Add(new SegmentData001(allElementGroupSegment));
		}
	}
}
