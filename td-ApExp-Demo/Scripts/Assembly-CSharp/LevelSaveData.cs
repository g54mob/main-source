using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class LevelSaveData
{
	public string Name;

	public int Index;

	public int WorldIndex;

	public LevelType LevelType;

	public Vector2 MapPosition;

	public List<int> Connectivity;

	public string TooltipString;

	public LootType LootType;

	public LevelDifficulty Difficulty;

	public int TrackCount;

	public TrackTypes[] TrackTypes;

	public int TrackCountOverride;

	public TrackTypes[] TrackTypesOverride;

	public int Column;

	public List<float> SavedModifiers;

	public LevelSaveData(Level level)
	{
		Name = level.Name;
		Index = level.Index;
		WorldIndex = level.WorldIndex;
		LevelType = level.LevelType;
		MapPosition = level.MapPosition;
		Connectivity = new List<int>(level.Connectivity);
		TooltipString = level.TooltipString;
		LootType = level.LootType;
		Difficulty = level.Difficulty;
		TrackCount = level.TrackCount;
		TrackTypes = level.TrackTypes;
		TrackCountOverride = level.TrackCount;
		TrackTypesOverride = level.TrackTypes;
		Column = level.Column;
		SavedModifiers = new List<float>(level.SavedModifiers);
	}
}
