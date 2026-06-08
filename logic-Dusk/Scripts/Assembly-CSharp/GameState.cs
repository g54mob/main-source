using System;
using System.Collections.Generic;

public class GameState
{
	public LocalPlayer ThePlayer;

	public List<StarSystemInfo> StarSystems;

	private int _nextSystemId = 1;

	public int NextDungeonId = 1;

	private Random _random = new Random();

	public SkinEnum CurrentSkin
	{
		get
		{
			return (SkinEnum)GameSaveFile.Get("SKN", 0);
		}
		set
		{
			GameSaveFile.Save("SKN", (int)value);
		}
	}

	public int NextSystemId
	{
		get
		{
			return _nextSystemId;
		}
		set
		{
			if (!GlobalSettings.IsTutorial && UniverseSaveFile.Get("LAST_SYS_ID", 0) < value)
			{
				UniverseSaveFile.Save("LAST_SYS_ID", value);
			}
			_nextSystemId = value;
		}
	}

	public void CreateDefault()
	{
		EventManager.Initialize();
		ThePlayer = new LocalPlayer(0, false);
		StarSystems = new List<StarSystemInfo>();
		StarSystemInfo starSystemInfo = new StarSystemInfo(StarSystems);
		starSystemInfo.DifficultyMin = 0f;
		starSystemInfo.DifficultyMax = 1f;
		StarSystemInfo starSystemInfo2 = starSystemInfo;
		StarSystems.Add(starSystemInfo2);
		DungeonInfo dungeonInfo = new DungeonInfo(starSystemInfo2, 1);
		dungeonInfo.DungeonType = DungeonTypeEnum.Derelict;
		dungeonInfo.Definition = DungeonConfigurationManager.DungeonHelper.GetDungeonDefinition(DungeonTypeEnum.Derelict, "Government", "A");
		dungeonInfo.AddInfestationType(ShipInfestationType.PatrolBot);
		starSystemInfo2.Dungeons = new List<DungeonInfo>();
		starSystemInfo2.Dungeons.Add(dungeonInfo);
		ThePlayer.CurrentDockedDungeon = dungeonInfo;
		DungeonConfigurationManager.CalculateOverallDifficulty(ThePlayer.CurrentDockedDungeon);
		int num = _random.Next(1, 101);
		if (num <= 33)
		{
			ThePlayer.CurrentDockedDungeon.HullIntegrity = HullIntegrity.Poor;
		}
		else if (num <= 66)
		{
			ThePlayer.CurrentDockedDungeon.HullIntegrity = HullIntegrity.Medium;
		}
		else
		{
			ThePlayer.CurrentDockedDungeon.HullIntegrity = HullIntegrity.Good;
		}
	}
}
