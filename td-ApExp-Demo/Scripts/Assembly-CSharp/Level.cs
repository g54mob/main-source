using System;
using System.Collections.Generic;
using UnityEngine;

public class Level
{
	[NonSerialized]
	public float EnemyDamageModifier;

	[NonSerialized]
	public float WaveSpawnTimeModifier;

	[NonSerialized]
	public float StormSpawnTimeModifier;

	[NonSerialized]
	public float StormDamageModifier;

	[NonSerialized]
	public float ArmoredEnemiesAmount;

	[NonSerialized]
	public float AdditionalEnemies;

	[NonSerialized]
	public float ResourceGainModifier;

	[NonSerialized]
	public Dictionary<string, float> DifficultyModifiers;

	public List<float> SavedModifiers;

	public Zone Zone { get; private set; }

	public string Name { get; private set; }

	public int Index { get; set; }

	public LevelType LevelType { get; private set; }

	public int Column { get; private set; }

	public bool Discovered { get; set; }

	public Vector2 MapPosition { get; private set; }

	public List<int> Connectivity { get; private set; }

	public string TooltipString { get; protected set; }

	public LootType LootType { get; private set; }

	public LevelLoot Loot { get; private set; }

	public bool IsLooted { get; set; }

	public LevelDifficulty Difficulty { get; private set; }

	public int WorldIndex { get; set; }

	public int StartIndex { get; set; }

	public int EndIndex => StartIndex + TrackTypes.Length - 1;

	public int TrackCount { get; private set; }

	public float LevelDistance => (float)TrackCount * 4.8f;

	public float GlobalStartDistance { get; set; }

	public float GlobalEndDistance { get; set; }

	public TrackTypes[] TrackTypes { get; set; }

	public List<TrackEventSwitch> Switches { get; private set; }

	public List<TrackEventResource> Resources { get; private set; }

	public ScriptedLevel ScriptedLevel { get; set; }

	public LevelData SourceData { get; set; }

	public static event Action OnLevelStarted;

	public void OnStarting()
	{
		ScriptedLevel?.OnLevelStarting();
	}

	public void OnPlaying()
	{
		ScriptedLevel?.OnLevelPlaying();
		Level.OnLevelStarted?.Invoke();
	}

	public void OnSlowing()
	{
		ScriptedLevel?.OnLevelSlowing();
	}

	public Level(Zone zone, string name, int index, Vector2 mapPosition, List<int> connectivity, LevelType levelType, LootType lootType, int column, LevelDifficulty difficulty, List<float> savedModifiers, string tooltipStringOverride = "", int trackCountOverride = -1, TrackTypes[] trackTypesOverride = null, LevelLoot lootOverride = null)
	{
		Zone = zone;
		Name = (string.IsNullOrEmpty(name) ? LevelUtils.GetRandomLevelName() : name);
		Index = index;
		MapPosition = mapPosition;
		Connectivity = new List<int>(connectivity);
		LevelType = levelType;
		LootType = lootType;
		Column = column;
		Difficulty = difficulty;
		SavedModifiers = new List<float>(savedModifiers);
		if (SavedModifiers == null || SavedModifiers.Count == 0)
		{
			Difficulty.Initialize(this);
			DifficultyModifiers = new Dictionary<string, float>();
			DifficultyModifiers.Add("Enemy Damage", EnemyDamageModifier);
			DifficultyModifiers.Add("Wave Spawn Time", WaveSpawnTimeModifier);
			DifficultyModifiers.Add("Storm Spawn Time", StormSpawnTimeModifier);
			DifficultyModifiers.Add("Storm Damage", StormDamageModifier);
			DifficultyModifiers.Add("Armored Enemies", ArmoredEnemiesAmount);
			DifficultyModifiers.Add("Additional Enemies Count", AdditionalEnemies);
			DifficultyModifiers.Add("Scrap Gain", ResourceGainModifier);
		}
		else
		{
			DifficultyModifiers = new Dictionary<string, float>();
			DifficultyModifiers.Add("Enemy Damage", savedModifiers[0]);
			DifficultyModifiers.Add("Wave Spawn Time", savedModifiers[1]);
			DifficultyModifiers.Add("Storm Spawn Time", savedModifiers[2]);
			DifficultyModifiers.Add("Storm Damage", savedModifiers[3]);
			DifficultyModifiers.Add("Armored Enemies", savedModifiers[4]);
			DifficultyModifiers.Add("Additional Enemies Count", savedModifiers[5]);
			DifficultyModifiers.Add("Scrap Gain", savedModifiers[6]);
		}
		SavedModifiers.Clear();
		foreach (float value in DifficultyModifiers.Values)
		{
			SavedModifiers.Add(value);
		}
		Switches = new List<TrackEventSwitch>();
		Resources = new List<TrackEventResource>();
		Loot = lootOverride ?? LootManager.Instance.GetLootByLootType(LootType, ZoneManager.Instance.GetZoneIndex(zone.Definition));
		TooltipString = (string.IsNullOrEmpty(tooltipStringOverride) ? ("<color=#" + ColorUtility.ToHtmlStringRGB(difficulty.Color) + ">" + difficulty.GetLocalizedName() + "</color>\n" + Loot.TooltipString) : tooltipStringOverride);
		TrackCount = ((trackCountOverride == -1) ? GetRandomTrackCount() : trackCountOverride);
		if (trackTypesOverride != null && trackTypesOverride.Length != 0)
		{
			TrackTypes = trackTypesOverride;
			TrackGenerator.GenerateLevelEvents(this, zone.Definition.ZoneName == "T0_Tutorial" && index <= 1, zone.Definition.ZoneName == "T0_Tutorial" && index <= 2);
		}
		else
		{
			TrackTypes = TrackGenerator.GenerateLevelTracksAndEvents(this, zone.Definition.ZoneName == "T0_Tutorial" && index <= 1, zone.Definition.ZoneName == "T0_Tutorial" && index <= 2);
		}
	}

	private int GetRandomTrackCount()
	{
		return (int)((float)Mathf.FloorToInt((float)(24 + DRNG.Instance.NextInt(-8, 8)) + (float)(Column + 2) * 8.7f) * LevelManager.Instance.Config.ZonesLevelLengthCurve[ZoneManager.Instance.CurrentZoneIndex].Evaluate(Column) * GameManager.Instance.GameSpeedModifier);
	}
}
