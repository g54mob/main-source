using System.Collections.Generic;
using UnityEngine.Localization.Settings;

public class MatchSettings : ISavable
{
	public enum EMatchDifficulty
	{
		Easy = 0,
		Medium = 1,
		Hard = 2
	}

	private bool allowPause = true;

	[Savable("buildDuringPause", true, false)]
	private bool buildDuringPause = true;

	[Savable("matchDifficulty", true, false)]
	private EMatchDifficulty matchDifficulty = EMatchDifficulty.Medium;

	[Savable("mapSize", true, false)]
	private EMapSize mapSize;

	private float firstRoundDelay;

	private float defaultRoundDelay;

	private int maxCrystalFindersAmount = -1;

	private float goldenCoinMultiplierChests = 1f;

	private float goldenCoinMultiplierCycles = 1f;

	private float goldenCoinMultiplierVictory = 1f;

	public bool AllowPause
	{
		get
		{
			return allowPause;
		}
		set
		{
			allowPause = value;
		}
	}

	public bool BuildDuringPause
	{
		get
		{
			return buildDuringPause;
		}
		set
		{
			buildDuringPause = value;
		}
	}

	public EMatchDifficulty MatchDifficulty
	{
		get
		{
			return matchDifficulty;
		}
		set
		{
			matchDifficulty = value;
		}
	}

	public EMapSize MapSize
	{
		get
		{
			return mapSize;
		}
		set
		{
			mapSize = value;
		}
	}

	public float FirstRoundDelay
	{
		get
		{
			return firstRoundDelay;
		}
		set
		{
			firstRoundDelay = value;
		}
	}

	public float DefaultRoundDelay
	{
		get
		{
			return defaultRoundDelay;
		}
		set
		{
			defaultRoundDelay = value;
		}
	}

	public int MaxCrystalFindersAmount
	{
		get
		{
			return maxCrystalFindersAmount;
		}
		set
		{
			maxCrystalFindersAmount = value;
		}
	}

	public float GoldenCoinMultiplierChests
	{
		get
		{
			return goldenCoinMultiplierChests;
		}
		set
		{
			goldenCoinMultiplierChests = value;
		}
	}

	public float GoldenCoinMultiplierCycles
	{
		get
		{
			return goldenCoinMultiplierCycles;
		}
		set
		{
			goldenCoinMultiplierCycles = value;
		}
	}

	public float GoldenCoinMultiplierVictory
	{
		get
		{
			return goldenCoinMultiplierVictory;
		}
		set
		{
			goldenCoinMultiplierVictory = value;
		}
	}

	public float EnemyLifeMultiplier => GetEnemyLifeMultiplier(matchDifficulty);

	public static float GetEnemyLifeMultiplier(EMatchDifficulty matchDifficulty)
	{
		return matchDifficulty switch
		{
			EMatchDifficulty.Easy => 0.66f, 
			EMatchDifficulty.Medium => 1f, 
			EMatchDifficulty.Hard => 2f, 
			_ => 1f, 
		};
	}

	public static string GetDifficultyName(EMatchDifficulty difficulty)
	{
		return difficulty switch
		{
			EMatchDifficulty.Easy => LocalizationSettings.StringDatabase.GetLocalizedString("UI_Common", "UI_Common_difficulty_easy", null, FallbackBehavior.UseProjectSettings), 
			EMatchDifficulty.Medium => LocalizationSettings.StringDatabase.GetLocalizedString("UI_Common", "UI_Common_difficulty_normal", null, FallbackBehavior.UseProjectSettings), 
			EMatchDifficulty.Hard => LocalizationSettings.StringDatabase.GetLocalizedString("UI_Common", "UI_Common_difficulty_hard", null, FallbackBehavior.UseProjectSettings), 
			_ => "?", 
		};
	}

	public static string GetMapSizeName(EMapSize mapSize)
	{
		return mapSize switch
		{
			EMapSize.XS => LocalizationSettings.StringDatabase.GetLocalizedString("UI_Common", "UI_Common_mapSize_xs", null, FallbackBehavior.UseProjectSettings), 
			EMapSize.S => LocalizationSettings.StringDatabase.GetLocalizedString("UI_Common", "UI_Common_mapSize_s", null, FallbackBehavior.UseProjectSettings), 
			EMapSize.M => LocalizationSettings.StringDatabase.GetLocalizedString("UI_Common", "UI_Common_mapSize_m", null, FallbackBehavior.UseProjectSettings), 
			EMapSize.L => LocalizationSettings.StringDatabase.GetLocalizedString("UI_Common", "UI_Common_mapSize_l", null, FallbackBehavior.UseProjectSettings), 
			EMapSize.XL => LocalizationSettings.StringDatabase.GetLocalizedString("UI_Common", "UI_Common_mapSize_xl", null, FallbackBehavior.UseProjectSettings), 
			_ => "?", 
		};
	}

	public void ApplyGameMode(GameMode gameMode)
	{
		allowPause = gameMode.AllowPause;
		if (gameMode.OverrideBuildDuringPause)
		{
			buildDuringPause = gameMode.BuildDuringPause;
		}
		if (gameMode.OverrideMatchDifficulty)
		{
			matchDifficulty = gameMode.MatchDifficulty;
		}
		firstRoundDelay = gameMode.FirstRoundDelay;
		defaultRoundDelay = gameMode.DefaultRoundDelay;
		maxCrystalFindersAmount = gameMode.MaxCrystalFindersAmount;
		goldenCoinMultiplierChests = gameMode.GoldenCoinMultiplierChests;
		goldenCoinMultiplierCycles = gameMode.GoldenCoinMultiplierCycles;
		goldenCoinMultiplierVictory = gameMode.GoldenCoinMultiplierVictory;
	}

	public void OnSave()
	{
	}

	public void OnPreLoad()
	{
	}

	public void OnLoad(Dictionary<string, object> data, bool hasLoadedSomething)
	{
	}
}
