using System.Collections.Generic;

public class AchievementDefinition
{
	public enum AchievementTypeEnum
	{
		GarbateOnScreen = 0,
		BreakARock = 1,
		Build2SameBuilding = 2,
		DestroyACloudManually = 3,
		GetMoneyP1 = 4,
		GetMoneyP2 = 5,
		GetMoneyP3 = 6,
		GetNewBuilding = 7,
		Get1RedShard = 8,
		Get1Book = 9,
		Open50Nodes = 10,
		GetYellowShardP1 = 11,
		GetYellowShardP2 = 12,
		GetBlueShardP1 = 13,
		GetBlueShardP2 = 14,
		Level10Building = 15,
		UseCompressor = 16,
		UseHelicopter = 17,
		UsePower = 18,
		UseTraining = 19,
		UseTemple = 20,
		UseDrone = 21,
		UseResearch = 22,
		UseHotAirStation = 23,
		UseAnAbility = 24,
		Make3Earthquake = 25,
		FinishGameBadEnding = 26,
		FinishGameGoodEnding = 27,
		BuildingStability5Times = 28,
		RpP1 = 29,
		RpP2 = 30,
		RpP3 = 31,
		PeonGarbageThrowP1 = 32,
		PeonGarbageThrowP2 = 33,
		PeonGarbageThrowP3 = 34,
		PeonThrow = 35,
		UseHouse = 36,
		UseCatapult = 37,
		UseIndustry = 38,
		WakeUpTheGolem = 39,
		Sacrifice = 40
	}

	public string SteamName;

	public string KongregateId;

	public string NewGroundsId;

	public AchievementTypeEnum AchievementType;

	public bool CanActivate;

	public bool IsActivated;

	public bool IsHidden;

	public int MaxValue = 99999;

	public int AmountGiven;

	public AchievementDefinition()
	{
	}

	public AchievementDefinition(AchievementTypeEnum type, int maxValue, int amountGiven, string steamName, string kongregateId, string newGroundsId)
	{
		AchievementType = type;
		MaxValue = maxValue;
		AmountGiven = amountGiven;
		SteamName = steamName;
		KongregateId = kongregateId;
		NewGroundsId = newGroundsId;
	}

	public AchievementDefinition(AchievementTypeEnum type, int maxValue, int amountGiven, string steamName, string kongregateId, string newGroundsId, bool isHidden)
	{
		AchievementType = type;
		MaxValue = maxValue;
		AmountGiven = amountGiven;
		SteamName = steamName;
		KongregateId = kongregateId;
		NewGroundsId = newGroundsId;
		IsHidden = isHidden;
	}

	public static List<AchievementDefinition> GetDefinitions()
	{
		return new List<AchievementDefinition>
		{
			new AchievementDefinition(AchievementTypeEnum.GarbateOnScreen, 400, 1, "GarbateOnScreen", "", ""),
			new AchievementDefinition(AchievementTypeEnum.BreakARock, 3, 1, "BreakARock", "", ""),
			new AchievementDefinition(AchievementTypeEnum.Build2SameBuilding, 2, 1, "Build2SameBuilding", "", ""),
			new AchievementDefinition(AchievementTypeEnum.DestroyACloudManually, 10, 1000, "DestroyACloudManually", "", ""),
			new AchievementDefinition(AchievementTypeEnum.GetMoneyP1, 1000, 100, "GetMoneyP1", "", ""),
			new AchievementDefinition(AchievementTypeEnum.GetMoneyP2, 50000, 1000, "GetMoneyP2", "", ""),
			new AchievementDefinition(AchievementTypeEnum.GetMoneyP3, 500000, 10000, "GetMoneyP3", "", ""),
			new AchievementDefinition(AchievementTypeEnum.GetNewBuilding, 1, 1, "GetNewBuilding", "", ""),
			new AchievementDefinition(AchievementTypeEnum.Get1RedShard, 1, 1, "Get1RedShard", "", ""),
			new AchievementDefinition(AchievementTypeEnum.Get1Book, 1, 1, "Get1Book", "", ""),
			new AchievementDefinition(AchievementTypeEnum.Open50Nodes, 50, 0, "", "", "", isHidden: true),
			new AchievementDefinition(AchievementTypeEnum.GetYellowShardP1, 7, 1, "GetYellowShardP1", "", ""),
			new AchievementDefinition(AchievementTypeEnum.GetYellowShardP2, 20, 1, "GetYellowShardP2", "", ""),
			new AchievementDefinition(AchievementTypeEnum.GetBlueShardP1, 2, 1, "GetBlueShardP1", "", ""),
			new AchievementDefinition(AchievementTypeEnum.GetBlueShardP2, 5, 1, "GetBlueShardP2", "", ""),
			new AchievementDefinition(AchievementTypeEnum.Level10Building, 10, 1, "Level10Building", "", ""),
			new AchievementDefinition(AchievementTypeEnum.UseCompressor, 1000, 1, "UseCompressor", "", ""),
			new AchievementDefinition(AchievementTypeEnum.UseHelicopter, 1000, 1, "UseHelicopter", "", ""),
			new AchievementDefinition(AchievementTypeEnum.UsePower, 1000, 1, "UsePower", "", ""),
			new AchievementDefinition(AchievementTypeEnum.UseTraining, 1000, 1, "UseTraining", "", ""),
			new AchievementDefinition(AchievementTypeEnum.UseTemple, 1000, 1, "", "", "", isHidden: true),
			new AchievementDefinition(AchievementTypeEnum.UseDrone, 1000, 1, "UseDrone", "", ""),
			new AchievementDefinition(AchievementTypeEnum.UseResearch, 1000, 1, "UseResearch", "", ""),
			new AchievementDefinition(AchievementTypeEnum.UseHotAirStation, 1000, 1, "UseHotAirStation", "", ""),
			new AchievementDefinition(AchievementTypeEnum.UseAnAbility, 1, 1, "UseAnAbility", "", ""),
			new AchievementDefinition(AchievementTypeEnum.Make3Earthquake, 3, 5000, "Make3Earthquake", "", ""),
			new AchievementDefinition(AchievementTypeEnum.FinishGameBadEnding, 1, 0, "FinishGameBadEnding", "", "", isHidden: true),
			new AchievementDefinition(AchievementTypeEnum.FinishGameGoodEnding, 1, 0, "FinishGameGoodEnding", "", "", isHidden: true),
			new AchievementDefinition(AchievementTypeEnum.BuildingStability5Times, 5, 1, "BuildingStability5Times", "", ""),
			new AchievementDefinition(AchievementTypeEnum.RpP1, 500, 1000, "RpP1", "", ""),
			new AchievementDefinition(AchievementTypeEnum.RpP2, 2500, 5000, "RpP2", "", ""),
			new AchievementDefinition(AchievementTypeEnum.RpP3, 10000, 15000, "RpP3", "", ""),
			new AchievementDefinition(AchievementTypeEnum.PeonGarbageThrowP1, 500, 1, "PeonGarbageThrowP1", "", ""),
			new AchievementDefinition(AchievementTypeEnum.PeonGarbageThrowP2, 5000, 1, "PeonGarbageThrowP2", "", ""),
			new AchievementDefinition(AchievementTypeEnum.PeonGarbageThrowP3, 15000, 1, "PeonGarbageThrowP3", "", ""),
			new AchievementDefinition(AchievementTypeEnum.PeonThrow, 5, 500, "PeonThrow", "", ""),
			new AchievementDefinition(AchievementTypeEnum.UseHouse, 1000, 1, "UseHouse", "", ""),
			new AchievementDefinition(AchievementTypeEnum.UseCatapult, 1000, 1, "UseCatapult", "", ""),
			new AchievementDefinition(AchievementTypeEnum.UseIndustry, 1000, 1, "UseIndustry", "", ""),
			new AchievementDefinition(AchievementTypeEnum.WakeUpTheGolem, 1, 0, "WakeUpTheGolem", "", "", isHidden: true),
			new AchievementDefinition(AchievementTypeEnum.Sacrifice, 1, 0, "Sacrifice", "", "", isHidden: true)
		};
	}

	public static bool ProcessAchievements(List<AchievementDefinition> achievements)
	{
		bool result = false;
		foreach (AchievementDefinition achievement in achievements)
		{
			if (achievement.Verify())
			{
				result = true;
			}
		}
		return result;
	}

	public static void ProcessSacrifice(List<AchievementDefinition> achievements)
	{
		foreach (AchievementDefinition achievement in achievements)
		{
			if (achievement.AchievementType == AchievementTypeEnum.Sacrifice)
			{
				achievement.ForceActivation();
			}
		}
	}

	public static void ProcessWakeUpTheGolem(List<AchievementDefinition> achievements)
	{
		foreach (AchievementDefinition achievement in achievements)
		{
			if (achievement.AchievementType == AchievementTypeEnum.WakeUpTheGolem)
			{
				achievement.ForceActivation();
			}
		}
	}

	public static void ProcessBadEnding(List<AchievementDefinition> achievements)
	{
		foreach (AchievementDefinition achievement in achievements)
		{
			if (achievement.AchievementType == AchievementTypeEnum.FinishGameBadEnding)
			{
				achievement.ForceActivation();
			}
		}
	}

	public static void ProcessGoodEnding(List<AchievementDefinition> achievements)
	{
		foreach (AchievementDefinition achievement in achievements)
		{
			if (achievement.AchievementType == AchievementTypeEnum.FinishGameGoodEnding)
			{
				achievement.ForceActivation();
			}
		}
	}

	public static int QuestButtonStatus(List<AchievementDefinition> achievements)
	{
		int num = 0;
		foreach (AchievementDefinition achievement in achievements)
		{
			if (!achievement.IsHidden && achievement.IsVisible())
			{
				if (achievement.CanActivate && !achievement.IsActivated)
				{
					num = 2;
				}
				if (num == 0 && achievement.IsActivated)
				{
					num = 1;
				}
			}
		}
		return num;
	}

	public static void ResubmitAll(List<AchievementDefinition> achievements)
	{
		foreach (AchievementDefinition achievement in achievements)
		{
			if (achievement.IsActivated || achievement.CanActivate)
			{
				achievement.GiveAchievement();
			}
		}
	}

	public static int CountQuestDone(List<AchievementDefinition> achievements)
	{
		int num = 0;
		int num2 = 0;
		int num3 = 0;
		foreach (AchievementDefinition achievement in GameController.Instance.Achievements)
		{
			if (!achievement.IsHidden)
			{
				if (achievement.CanActivate && !achievement.IsActivated)
				{
					num3++;
				}
				if (achievement.IsActivated)
				{
					num2++;
				}
				num++;
			}
		}
		return num2;
	}

	public static int CountQuestTotal(List<AchievementDefinition> achievements)
	{
		int num = 0;
		int num2 = 0;
		int num3 = 0;
		foreach (AchievementDefinition achievement in GameController.Instance.Achievements)
		{
			if (!achievement.IsHidden)
			{
				if (achievement.CanActivate && !achievement.IsActivated)
				{
					num3++;
				}
				if (achievement.IsActivated)
				{
					num2++;
				}
				num++;
			}
		}
		return num;
	}

	public int GetCurrentValue()
	{
		int num = -1;
		if (IsActivated || CanActivate)
		{
			return MaxValue;
		}
		switch (AchievementType)
		{
		case AchievementTypeEnum.GarbateOnScreen:
			num = GameController.Instance.GarbageController.GetTotalGarbageOnScreen();
			break;
		case AchievementTypeEnum.BreakARock:
			num = GameController.Instance.ColumnsController.GetColumns().Count - 5;
			if (num < 0)
			{
				num = 0;
			}
			break;
		case AchievementTypeEnum.Build2SameBuilding:
		{
			List<ColumnController> columns = GameController.Instance.ColumnsController.GetColumns();
			for (int i = 0; i < columns.Count - 1; i++)
			{
				if (!(columns[i].Buildings != null))
				{
					continue;
				}
				for (int j = i + 1; j < columns.Count; j++)
				{
					if (columns[j].Buildings != null && columns[i].Buildings.BuildingType == columns[j].Buildings.BuildingType)
					{
						num = 2;
						break;
					}
				}
			}
			break;
		}
		case AchievementTypeEnum.DestroyACloudManually:
			num = GameController.TotalCloudClickDestroyed;
			break;
		case AchievementTypeEnum.GetMoneyP1:
			num = GameController.Instance.Money.TotalAmount;
			break;
		case AchievementTypeEnum.GetMoneyP2:
			num = GameController.Instance.Money.TotalAmount;
			break;
		case AchievementTypeEnum.GetMoneyP3:
			num = GameController.Instance.Money.TotalAmount;
			break;
		case AchievementTypeEnum.GetNewBuilding:
			num = 0;
			if (Compressor.GlobalInfo.LevelUpAttribute.IsEnabled)
			{
				num++;
			}
			if (Helicopter.GlobalInfo.LevelUpAttribute.IsEnabled)
			{
				num++;
			}
			if (Power.GlobalInfo.LevelUpAttribute.IsEnabled)
			{
				num++;
			}
			if (Training.GlobalInfo.LevelUpAttribute.IsEnabled)
			{
				num++;
			}
			if (Temple.GlobalInfo.LevelUpAttribute.IsEnabled)
			{
				num++;
			}
			if (Drone.GlobalInfo.LevelUpAttribute.IsEnabled)
			{
				num++;
			}
			if (Research.GlobalInfo.LevelUpAttribute.IsEnabled)
			{
				num++;
			}
			if (HotAirStation.GlobalInfo.LevelUpAttribute.IsEnabled)
			{
				num++;
			}
			break;
		case AchievementTypeEnum.Get1RedShard:
			num = GameController.Instance.RedPoint.TotalAmount;
			break;
		case AchievementTypeEnum.Get1Book:
			num = GameController.Instance.Book.TotalAmount;
			break;
		case AchievementTypeEnum.GetYellowShardP1:
			num = GameController.Instance.YellowPoint.TotalAmount;
			break;
		case AchievementTypeEnum.GetYellowShardP2:
			num = GameController.Instance.YellowPoint.TotalAmount;
			break;
		case AchievementTypeEnum.GetBlueShardP1:
			num = GameController.Instance.BluePoint.TotalAmount;
			break;
		case AchievementTypeEnum.GetBlueShardP2:
			num = GameController.Instance.BluePoint.TotalAmount;
			break;
		case AchievementTypeEnum.Level10Building:
			foreach (ColumnController column in GameController.Instance.ColumnsController.GetColumns())
			{
				if (column.Buildings != null && num < column.Buildings.GetLevel())
				{
					num = column.Buildings.GetLevel();
				}
			}
			break;
		case AchievementTypeEnum.UseCompressor:
			num = Compressor.GlobalInfo.TotalExecutionCount;
			break;
		case AchievementTypeEnum.UseHelicopter:
			num = Helicopter.GlobalInfo.TotalExecutionCount;
			break;
		case AchievementTypeEnum.UsePower:
			num = Power.GlobalInfo.TotalExecutionCount;
			break;
		case AchievementTypeEnum.UseTraining:
			num = Training.GlobalInfo.TotalExecutionCount;
			break;
		case AchievementTypeEnum.UseTemple:
			num = Temple.GlobalInfo.TotalExecutionCount;
			break;
		case AchievementTypeEnum.UseDrone:
			num = Drone.GlobalInfo.TotalExecutionCount;
			break;
		case AchievementTypeEnum.UseResearch:
			num = Research.GlobalInfo.TotalExecutionCount;
			break;
		case AchievementTypeEnum.UseHotAirStation:
			num = HotAirStation.GlobalInfo.TotalExecutionCount;
			break;
		case AchievementTypeEnum.UseAnAbility:
			num = 0;
			foreach (Ability ability in GameController.Instance.Abilities)
			{
				num += ability.UseCount;
			}
			break;
		case AchievementTypeEnum.Make3Earthquake:
			num = GameController.Instance.PrestigeCount;
			break;
		case AchievementTypeEnum.BuildingStability5Times:
			if (num < Compressor.GlobalInfo.StabilityLevel)
			{
				num = Compressor.GlobalInfo.StabilityLevel;
			}
			if (num < Helicopter.GlobalInfo.StabilityLevel)
			{
				num = Helicopter.GlobalInfo.StabilityLevel;
			}
			if (num < Power.GlobalInfo.StabilityLevel)
			{
				num = Power.GlobalInfo.StabilityLevel;
			}
			if (num < Training.GlobalInfo.StabilityLevel)
			{
				num = Training.GlobalInfo.StabilityLevel;
			}
			if (num < Temple.GlobalInfo.StabilityLevel)
			{
				num = Temple.GlobalInfo.StabilityLevel;
			}
			if (num < Drone.GlobalInfo.StabilityLevel)
			{
				num = Drone.GlobalInfo.StabilityLevel;
			}
			if (num < Research.GlobalInfo.StabilityLevel)
			{
				num = Research.GlobalInfo.StabilityLevel;
			}
			if (num < HotAirStation.GlobalInfo.StabilityLevel)
			{
				num = HotAirStation.GlobalInfo.StabilityLevel;
			}
			if (num < Catapult.GlobalInfo.StabilityLevel)
			{
				num = Catapult.GlobalInfo.StabilityLevel;
			}
			if (num < House.GlobalInfo.StabilityLevel)
			{
				num = House.GlobalInfo.StabilityLevel;
			}
			if (num < Industry.GlobalInfo.StabilityLevel)
			{
				num = Industry.GlobalInfo.StabilityLevel;
			}
			num++;
			break;
		case AchievementTypeEnum.RpP1:
			num = GameController.Instance.ResearchPoint.TotalAmount;
			break;
		case AchievementTypeEnum.RpP2:
			num = GameController.Instance.ResearchPoint.TotalAmount;
			break;
		case AchievementTypeEnum.RpP3:
			num = GameController.Instance.ResearchPoint.TotalAmount;
			break;
		case AchievementTypeEnum.PeonGarbageThrowP1:
			num = GameController.TotalPeonTrashThrow;
			break;
		case AchievementTypeEnum.PeonGarbageThrowP2:
			num = GameController.TotalPeonTrashThrow;
			break;
		case AchievementTypeEnum.PeonGarbageThrowP3:
			num = GameController.TotalPeonTrashThrow;
			break;
		case AchievementTypeEnum.PeonThrow:
			num = GameController.TotalPeonThrow;
			break;
		case AchievementTypeEnum.UseHouse:
			num = House.GlobalInfo.TotalExecutionCount;
			break;
		case AchievementTypeEnum.UseCatapult:
			num = Catapult.GlobalInfo.TotalExecutionCount;
			break;
		case AchievementTypeEnum.UseIndustry:
			num = Industry.GlobalInfo.TotalExecutionCount;
			break;
		}
		return num;
	}

	public bool Verify()
	{
		if (!IsVisible())
		{
			return false;
		}
		if (!CanActivate)
		{
			int currentValue = GetCurrentValue();
			if (currentValue == -1)
			{
				return false;
			}
			if (currentValue >= MaxValue)
			{
				CanActivate = true;
				GiveAchievement();
				return true;
			}
		}
		return false;
	}

	public bool Activate()
	{
		if (!IsVisible())
		{
			return false;
		}
		if (CanActivate && !IsActivated)
		{
			IsActivated = true;
			switch (AchievementType)
			{
			case AchievementTypeEnum.GarbateOnScreen:
				GameController.Instance.CanViewOnTop = true;
				break;
			case AchievementTypeEnum.BreakARock:
				GameController.Instance.YellowPoint.AddAmount(AmountGiven);
				break;
			case AchievementTypeEnum.Build2SameBuilding:
				GameController.Instance.YellowPoint.AddAmount(AmountGiven);
				break;
			case AchievementTypeEnum.DestroyACloudManually:
				GameController.Instance.Money.AddAmount(AmountGiven);
				break;
			case AchievementTypeEnum.GetMoneyP1:
				GameController.Instance.Money.AddAmount(AmountGiven);
				break;
			case AchievementTypeEnum.GetMoneyP2:
				GameController.Instance.Money.AddAmount(AmountGiven);
				break;
			case AchievementTypeEnum.GetMoneyP3:
				GameController.Instance.Money.AddAmount(AmountGiven);
				break;
			case AchievementTypeEnum.GetNewBuilding:
				GameController.Instance.SeeAllNodes = true;
				SkillTreePanel.DisplayAllNodes = true;
				break;
			case AchievementTypeEnum.Get1RedShard:
				GameController.Instance.BluePoint.AddAmount(AmountGiven);
				break;
			case AchievementTypeEnum.Get1Book:
				GameController.Instance.BluePoint.AddAmount(AmountGiven);
				break;
			case AchievementTypeEnum.GetYellowShardP1:
				GameController.Instance.YellowPoint.AddAmount(AmountGiven);
				break;
			case AchievementTypeEnum.GetYellowShardP2:
				GameController.Instance.BluePoint.AddAmount(AmountGiven);
				break;
			case AchievementTypeEnum.GetBlueShardP1:
				GameController.Instance.YellowPoint.AddAmount(AmountGiven);
				break;
			case AchievementTypeEnum.GetBlueShardP2:
				GameController.Instance.YellowPoint.AddAmount(AmountGiven);
				break;
			case AchievementTypeEnum.Level10Building:
				GameController.Instance.YellowPoint.AddAmount(AmountGiven);
				GameController.Instance.BluePoint.AddAmount(AmountGiven);
				break;
			case AchievementTypeEnum.UseCompressor:
				ExecuteAirplant();
				break;
			case AchievementTypeEnum.UseHelicopter:
				ExecuteAirplant();
				break;
			case AchievementTypeEnum.UsePower:
				ExecuteAirplant();
				break;
			case AchievementTypeEnum.UseTraining:
				ExecuteAirplant();
				break;
			case AchievementTypeEnum.UseTemple:
				ExecuteAirplant();
				break;
			case AchievementTypeEnum.UseDrone:
				ExecuteAirplant();
				break;
			case AchievementTypeEnum.UseResearch:
				ExecuteAirplant();
				break;
			case AchievementTypeEnum.UseHotAirStation:
				ExecuteAirplant();
				break;
			case AchievementTypeEnum.UseAnAbility:
				ExecuteAirplant();
				break;
			case AchievementTypeEnum.Make3Earthquake:
				GameController.Instance.Money.AddAmount(AmountGiven);
				break;
			case AchievementTypeEnum.BuildingStability5Times:
				GameController.Instance.YellowPoint.AddAmount(AmountGiven);
				break;
			case AchievementTypeEnum.RpP1:
				GameController.Instance.Money.AddAmount(AmountGiven);
				break;
			case AchievementTypeEnum.RpP2:
				GameController.Instance.Money.AddAmount(AmountGiven);
				break;
			case AchievementTypeEnum.RpP3:
				GameController.Instance.Money.AddAmount(AmountGiven);
				break;
			case AchievementTypeEnum.PeonGarbageThrowP1:
				GameController.Instance.YellowPoint.AddAmount(AmountGiven);
				break;
			case AchievementTypeEnum.PeonGarbageThrowP2:
				GameController.Instance.YellowPoint.AddAmount(AmountGiven);
				break;
			case AchievementTypeEnum.PeonGarbageThrowP3:
				GameController.Instance.YellowPoint.AddAmount(AmountGiven);
				break;
			case AchievementTypeEnum.PeonThrow:
				GameController.Instance.Money.AddAmount(AmountGiven);
				break;
			case AchievementTypeEnum.UseHouse:
				ExecuteAirplant();
				break;
			case AchievementTypeEnum.UseCatapult:
				ExecuteAirplant();
				break;
			case AchievementTypeEnum.UseIndustry:
				ExecuteAirplant();
				break;
			}
			return true;
		}
		return false;
	}

	private void ExecuteAirplant()
	{
		if (GameController.GlobalInfo.CanAbilityAirplaneMoreAttribute.IsEnabled)
		{
			GameController.Instance.ExecuteAirplane(smallGarbage: false, mediumGarbage: false, largeGarbage: true);
		}
		else
		{
			GameController.Instance.ExecuteAirplane(smallGarbage: false, mediumGarbage: true, largeGarbage: false);
		}
	}

	public bool IsVisible()
	{
		if (Installation.IsDemo())
		{
			if (AchievementType == AchievementTypeEnum.GetNewBuilding)
			{
				return true;
			}
			if (AchievementType == AchievementTypeEnum.GarbateOnScreen)
			{
				return true;
			}
			return false;
		}
		return true;
	}

	public bool ForceActivation()
	{
		if (!IsActivated)
		{
			if (!CanActivate)
			{
				GiveAchievement();
			}
			CanActivate = true;
			IsActivated = true;
			return true;
		}
		return false;
	}

	private void GiveAchievement()
	{
		if (Installation.CurrentInstallation != Installation.InstallationType.SteamDemo)
		{
			ApiManager.Instance.SetAchievement(this);
		}
	}
}
