using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Localization.Settings;
using UnityEngine.Localization.Tables;
using UnityEngine.ResourceManagement.AsyncOperations;

public static class LevelUtils
{
	private const int PrefixCount = 105;

	private const int SuffixCount = 75;

	private const string PrefixKeyFormat = "LocationName{0}";

	private const string SuffixKeyFormat = "Location2Name{0}";

	private const string TableName = "LocalizationTable";

	public static List<string> LocalizedPrefixes { get; private set; } = new List<string>();

	public static List<string> LocalizedSuffixes { get; private set; } = new List<string>();

	public static async void PreloadLevelNameParts()
	{
		await LocalizationSettings.InitializationOperation.Task;
		AsyncOperationHandle<StringTable> handle = LocalizationSettings.StringDatabase.GetTableAsync("LocalizationTable");
		await handle.Task;
		StringTable result = handle.Result;
		if (result == null)
		{
			Debug.LogError("Localization table not found!");
			return;
		}
		LocalizedPrefixes.Clear();
		for (int i = 1; i <= 105; i++)
		{
			StringTableEntry entry = result.GetEntry($"LocationName{i}");
			if (entry != null)
			{
				LocalizedPrefixes.Add(entry.LocalizedValue);
			}
		}
		LocalizedSuffixes.Clear();
		for (int j = 1; j <= 75; j++)
		{
			StringTableEntry entry2 = result.GetEntry($"Location2Name{j}");
			if (entry2 != null)
			{
				LocalizedSuffixes.Add(entry2.LocalizedValue);
			}
		}
	}

	public static string GetRandomLevelName()
	{
		if (LocalizedPrefixes.Count == 0 || LocalizedSuffixes.Count == 0)
		{
			return "Loading...";
		}
		string text = LocalizedPrefixes[DRNG.Instance.NextInt(0, LocalizedPrefixes.Count)];
		string text2 = LocalizedSuffixes[DRNG.Instance.NextInt(0, LocalizedSuffixes.Count)];
		return text + " " + text2;
	}

	public static Level GetLevelAtGlobalIndex(int index)
	{
		return LevelManager.Instance.LevelHistory.Select((int levelIndex) => LevelManager.Instance.Levels[levelIndex]).FirstOrDefault((Level l) => l.TrackTypes != null && index >= l.StartIndex && index < l.StartIndex + l.TrackTypes.Length);
	}

	public static Level GetLevelByIndex(int index)
	{
		return LevelManager.Instance.Levels[index];
	}

	public static TrackTypes GetTrackTypeAtGlobalIndex(int index)
	{
		Level levelAtGlobalIndex = GetLevelAtGlobalIndex(index);
		if (levelAtGlobalIndex == null)
		{
			return TrackTypes.SS;
		}
		return levelAtGlobalIndex.TrackTypes[index - levelAtGlobalIndex.StartIndex];
	}

	public static LevelDifficulty GetWeightedLevelDifficulty(ZoneDefinition def, int col)
	{
		LevelConfig config = LevelManager.Instance.Config;
		LevelDifficulty[] levelDifficulties = config.LevelDifficulties;
		float difficultyVariance = config.DifficultyVariance;
		float time = (float)col / (float)(def.MapSize.x - 1);
		float num = def.DifficultyCurveEasy.Evaluate(time) * config.LevelDifficulties[0].Prob;
		float num2 = def.DifficultyCurveMed.Evaluate(time) * config.LevelDifficulties[1].Prob;
		float num3 = def.DifficultyCurveHard.Evaluate(time) * config.LevelDifficulties[2].Prob;
		num += DRNG.Instance.NextFloat(0f - difficultyVariance, difficultyVariance);
		num2 += DRNG.Instance.NextFloat(0f - difficultyVariance, difficultyVariance);
		num3 += DRNG.Instance.NextFloat(0f - difficultyVariance, difficultyVariance);
		num = Mathf.Max(0f, num);
		num2 = Mathf.Max(0f, num2);
		num3 = Mathf.Max(0f, num3);
		int weightedIndex = LootUtils.GetWeightedIndex(new float[3] { num, num2, num3 });
		return levelDifficulties[Mathf.Clamp(weightedIndex, 0, levelDifficulties.Length - 1)];
	}
}
