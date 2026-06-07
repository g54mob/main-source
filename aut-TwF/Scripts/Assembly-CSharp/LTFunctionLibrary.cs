using System;
using System.Collections.Generic;
using System.Linq;
using LightTower;
using Steamworks;
using UnityEngine;
using UnityEngine.Localization.Settings;

public class LTFunctionLibrary
{
	public enum ESeason
	{
		None = 0,
		Christmas = 1
	}

	public static LTGameManager GetLTGameManager()
	{
		return GameManager.instance as LTGameManager;
	}

	public static LTLevelController GetLTLevelController()
	{
		return GameManager.instance.CurrentLevelController as LTLevelController;
	}

	public static GameStatsManager GetGameStatsManager()
	{
		return GetLTGameManager().GameStatsManager;
	}

	public static TimeManager GetTimeManager()
	{
		return GetLTGameManager().TimeManager;
	}

	public static CyclesManager GetCyclesManager()
	{
		return GetLTGameManager().CyclesManager;
	}

	public static PlayerData GetPlayerData()
	{
		return GetLTGameManager()?.PlayerData;
	}

	public static StatsComponent GetPlayerStatsComponent()
	{
		return GetLTGameManager()?.PlayerStatsComponent;
	}

	public static Storage_ResourceData GetPlayerInventory()
	{
		return GetPlayerData()?.Inventory;
	}

	public static LTPlayerController GetLTPlayerController()
	{
		return GameManager.instance.PlayerController as LTPlayerController;
	}

	public static SpawnersManager GetSpawnersManager()
	{
		return SpawnersManager.instance;
	}

	public static PlayerUpgradesManager GetPlayerUpgradesManager()
	{
		return PlayerUpgradesManager.instance;
	}

	public static LevelsProgressionManager GetLevelsProgressionManager()
	{
		return LevelsProgressionManager.instance;
	}

	public static FogOfWarController GetFogOfWarController()
	{
		return FogOfWarController.instance;
	}

	public static MatchInfo GetMatchInfo()
	{
		return MatchInfo.instance;
	}

	public static Grid GetGrid()
	{
		return GetLTLevelController().Grid;
	}

	public static EOrientation GetOrientationBetweenPositions(Vector3 pos1, Vector3 pos2)
	{
		return (EOrientation)Mathf.Repeat(Mathf.RoundToInt(Vector3.SignedAngle(pos2.XZ().XZ() - pos1.XZ().XZ(), Vector3.forward, Vector3.up) / -90f), 4f);
	}

	public static Vector3 GetDirectionFromOrientation(EOrientation orientation)
	{
		return orientation switch
		{
			EOrientation.North => Vector3.forward, 
			EOrientation.East => Vector3.right, 
			EOrientation.South => Vector3.back, 
			EOrientation.West => Vector3.left, 
			_ => Vector3.zero, 
		};
	}

	public static Quaternion GetRotationFromToOrientation(EOrientation from, EOrientation to)
	{
		if (from == InverseOrientation(to))
		{
			return Quaternion.AngleAxis(180f, Vector3.up);
		}
		return Quaternion.FromToRotation(GetDirectionFromOrientation(from), GetDirectionFromOrientation(to));
	}

	public static EOrientation RightOrientation(EOrientation orientation)
	{
		return (EOrientation)Mathf.Repeat((float)(orientation + 1), 4f);
	}

	public static EOrientation LeftOrientation(EOrientation orientation)
	{
		return (EOrientation)Mathf.Repeat((float)(orientation - 1), 4f);
	}

	public static EOrientation InverseOrientation(EOrientation orientation)
	{
		return (EOrientation)Mathf.Repeat((float)(orientation + 2), 4f);
	}

	public static EOrientation OrientationToLocalSpace(EOrientation worldSpaceOrientation, Transform transform)
	{
		if (worldSpaceOrientation == EOrientation.None)
		{
			return EOrientation.None;
		}
		return (EOrientation)Mathf.Repeat((float)(Mathf.RoundToInt(transform.rotation.eulerAngles.y) / -90 + worldSpaceOrientation), 4f);
	}

	public static EOrientation OrientationToWorldSpace(EOrientation localSpaceOrientation, Transform transform)
	{
		return OrientationToWorldSpace(localSpaceOrientation, transform.rotation.eulerAngles.y);
	}

	public static EOrientation OrientationToWorldSpace(EOrientation localSpaceOrientation, float angleY)
	{
		if (localSpaceOrientation == EOrientation.None)
		{
			return EOrientation.None;
		}
		return (EOrientation)Mathf.Repeat((float)(Mathf.RoundToInt(angleY) / 90 + localSpaceOrientation), 4f);
	}

	public static float GetOrientationDot(EOrientation orientationA, EOrientation orientationB)
	{
		return Vector3.Dot(GetDirectionFromOrientation(orientationA), GetDirectionFromOrientation(orientationB));
	}

	public static bool CanBuyObject(PlacementComponent objectToBuy, bool singleClickBuy)
	{
		if (objectToBuy.CanBuildOnCurrentPosition(checkPositionVisible: true, singleClickBuy) && GetPlayerData().CanBuild(objectToBuy.MainObject))
		{
			return GetLTGameManager().CanAfford(objectToBuy.MainObject.ObjectData.BuyCost);
		}
		return false;
	}

	public static bool CanTargetEnemyType(Enemy.EEnemyType enemyType, TowerCombatComponent towerCombatComponent)
	{
		return (towerCombatComponent.ValidEnemyTypes & enemyType) > (Enemy.EEnemyType)0;
	}

	public static List<GameplayEffectData> GetGameplayEffectDatasToApplyToBuilding(GameplayObjectData buildingObjectData)
	{
		if (!GetLTPlayerController())
		{
			return null;
		}
		List<GameplayEffect> effects = GetLTPlayerController().ControlledCharacter.GetComponent<GameplayEffectsComponent>().GetEffects();
		List<GameplayEffectData> list = new List<GameplayEffectData>();
		foreach (GameplayEffect item2 in effects)
		{
			if (!(item2 is GE_GiveEffectToBuilding))
			{
				continue;
			}
			GE_GiveEffectToBuildingData gE_GiveEffectToBuildingData = (item2 as GE_GiveEffectToBuilding).EffectData as GE_GiveEffectToBuildingData;
			if (gE_GiveEffectToBuildingData.IsAffected(buildingObjectData))
			{
				GameplayEffectData[] effectsToApply = gE_GiveEffectToBuildingData.EffectsToApply;
				foreach (GameplayEffectData item in effectsToApply)
				{
					list.Add(item);
				}
			}
		}
		return list;
	}

	public static int GetMaxTierUnlocked()
	{
		return Mathf.RoundToInt(GetLTGameManager().PlayerTower.StatsComponent.GetStat(EStats.MaxUnlockedTier));
	}

	public static string GetStatDisplayName(EStats stat)
	{
		return stat switch
		{
			EStats.Speed => LocalizationSettings.StringDatabase.GetTableEntry("Stats", "Stat_speed").Entry.GetLocalizedString(), 
			EStats.Health => LocalizationSettings.StringDatabase.GetTableEntry("Stats", "Stat_health").Entry.GetLocalizedString(), 
			EStats.HealthMax => LocalizationSettings.StringDatabase.GetTableEntry("Stats", "Stat_maxHealth").Entry.GetLocalizedString(), 
			EStats.Armor => LocalizationSettings.StringDatabase.GetTableEntry("Stats", "Stat_armor").Entry.GetLocalizedString(), 
			EStats.ArmorMax => LocalizationSettings.StringDatabase.GetTableEntry("Stats", "Stat_maxArmor").Entry.GetLocalizedString(), 
			EStats.Shield => LocalizationSettings.StringDatabase.GetTableEntry("Stats", "Stat_shield").Entry.GetLocalizedString(), 
			EStats.ShieldMax => LocalizationSettings.StringDatabase.GetTableEntry("Stats", "Stat_maxShield").Entry.GetLocalizedString(), 
			EStats.BaseDamage => LocalizationSettings.StringDatabase.GetTableEntry("Stats", "Stat_damage").Entry.GetLocalizedString(), 
			EStats.AttackSpeed => LocalizationSettings.StringDatabase.GetTableEntry("Stats", "Stat_attackSpeed").Entry.GetLocalizedString(), 
			EStats.Range => LocalizationSettings.StringDatabase.GetTableEntry("Stats", "Stat_range").Entry.GetLocalizedString(), 
			EStats.MovementSpeed => LocalizationSettings.StringDatabase.GetTableEntry("Stats", "Stat_movementSpeed").Entry.GetLocalizedString(), 
			_ => "", 
		};
	}

	public static float GetDayPercentTime()
	{
		if (GetCyclesManager().CurrentCycleMode == ECycleMode.Wave)
		{
			return 0f;
		}
		return (float)(GetTimeManager().GetTimeMilliseconds() - GetCyclesManager().CurrentCycleStartTimeMilli) / ((float)GetCyclesManager().RoundTime * 1000f);
	}

	public static long GetDayRemainingMilliseconds()
	{
		return GetCyclesManager().RoundTime * 1000 - (GetTimeManager().GetTimeMilliseconds() - GetCyclesManager().CurrentCycleStartTimeMilli);
	}

	public static List<Vector2> GetRandomGridBasedPositions(Vector2 gridSize, int desiredSubdivisions, float distanceFromBorders, float randomOffsetBias, List<(Vector3 position, float radius)> invalidAreas, int maxIterations = 5, float minDistanceBetweenPositions = 0f)
	{
		List<Vector2> list = new List<Vector2>();
		randomOffsetBias = Mathf.Clamp01(randomOffsetBias);
		maxIterations = Mathf.Max(maxIterations, 1);
		gridSize.x -= distanceFromBorders * 2f;
		gridSize.y -= distanceFromBorders * 2f;
		float num = Mathf.Max(gridSize.x, gridSize.y) / (float)desiredSubdivisions;
		Vector2 vector = default(Vector2);
		vector.x = gridSize.x / (float)Mathf.CeilToInt(gridSize.x / num);
		vector.y = gridSize.y / (float)Mathf.CeilToInt(gridSize.y / num);
		Vector2Int zero = Vector2Int.zero;
		zero.x = Mathf.RoundToInt(gridSize.x / vector.x);
		zero.y = Mathf.RoundToInt(gridSize.y / vector.y);
		for (int i = 0; i < zero.x; i++)
		{
			for (int j = 0; j < zero.y; j++)
			{
				list.Add(new Vector2((float)i * vector.x + vector.x / 2f + distanceFromBorders, (float)j * vector.y + vector.y / 2f + distanceFromBorders));
			}
		}
		Vector2 vector2 = default(Vector2);
		vector2.x = randomOffsetBias * vector.x * 0.5f;
		vector2.y = randomOffsetBias * vector.y * 0.5f;
		Vector2 vector3 = Vector2.zero;
		for (int num2 = list.Count - 1; num2 >= 0; num2--)
		{
			int k = 0;
			bool flag = false;
			for (; k < maxIterations; k++)
			{
				if (flag)
				{
					break;
				}
				vector3 = list[num2] + new Vector2(UnityEngine.Random.Range(0f - vector2.x, vector2.x), UnityEngine.Random.Range(0f - vector2.y, vector2.y));
				flag = true;
				if (invalidAreas != null)
				{
					foreach (var invalidArea in invalidAreas)
					{
						if (FunctionLibrary.IsPositionInsideCircle(vector3, invalidArea.position.XZ(), invalidArea.radius))
						{
							flag = false;
							break;
						}
					}
				}
				if (!flag || !(minDistanceBetweenPositions > 0f))
				{
					continue;
				}
				for (int num3 = list.Count - 1; num3 > num2; num3--)
				{
					if (FunctionLibrary.IsPositionInsideCircle(vector3, list[num3], minDistanceBetweenPositions))
					{
						flag = false;
						break;
					}
				}
			}
			if (!flag)
			{
				list.RemoveAt(num2);
			}
			else
			{
				list[num2] = vector3;
			}
		}
		return list;
	}

	public static List<Vector2> GetRandomCircleBasedPositions(int positionsAmount, Vector2 gridSize, Vector3 centerPosition, Vector2 minMaxDistance, float distanceFromBorders, List<(Vector3 position, float radius)> invalidAreas, int maxIterations = 5, float minDistanceBetweenPositions = 0f)
	{
		List<Vector2> list = new List<Vector2>();
		maxIterations = Mathf.Max(maxIterations, 1);
		int num = 0;
		Vector2 zero = Vector2.zero;
		while (list.Count < positionsAmount && num < maxIterations)
		{
			num++;
			zero = centerPosition.XZ() + UnityEngine.Random.insideUnitCircle * (minMaxDistance.y + 1f - minMaxDistance.x);
			zero += (zero - centerPosition.XZ()).normalized * minMaxDistance.x;
			bool flag = true;
			if (zero.x < distanceFromBorders || zero.y < distanceFromBorders || zero.x > gridSize.x - distanceFromBorders - 1f || zero.y > gridSize.y - distanceFromBorders - 1f)
			{
				continue;
			}
			if (invalidAreas != null)
			{
				foreach (var invalidArea in invalidAreas)
				{
					if (FunctionLibrary.IsPositionInsideCircle(zero, invalidArea.position.XZ(), invalidArea.radius))
					{
						flag = false;
						break;
					}
				}
			}
			if (!flag)
			{
				continue;
			}
			if (minDistanceBetweenPositions > 0f)
			{
				for (int i = 0; i < list.Count; i++)
				{
					if (FunctionLibrary.IsPositionInsideCircle(zero, list[i], minDistanceBetweenPositions))
					{
						flag = false;
						break;
					}
				}
			}
			if (flag)
			{
				list.Add(zero);
			}
		}
		return list;
	}

	public static List<PathTile> GetNextPathTiles(PathTile pathTile, EOrientation startOrientation, ICollection<PathTile> allPathTiles)
	{
		List<PathTile> list = new List<PathTile>();
		bool flag = false;
		foreach (PathTile allPathTile in allPathTiles)
		{
			if (allPathTile == pathTile)
			{
				continue;
			}
			foreach (Path allPath in pathTile.GetAllPaths())
			{
				if (GetOrientationBetweenPositions(pathTile.transform.position, pathTile.transform.TransformPoint(allPath.positions[allPath.positions.Length - 1])) == startOrientation)
				{
					continue;
				}
				flag = false;
				foreach (Path allPath2 in allPathTile.GetAllPaths())
				{
					if ((pathTile.transform.TransformPoint(allPath.positions[allPath.positions.Length - 1]) - allPathTile.transform.TransformPoint(allPath2.positions[0])).sqrMagnitude < 0.01f)
					{
						list.Add(allPathTile);
						flag = true;
						break;
					}
				}
				if (flag)
				{
					break;
				}
			}
		}
		return list;
	}

	public static IEnumerable<GridCell> GetGridCellsAroundPosition(Grid grid, IEnumerable<Vector3> centerPositions, int radius)
	{
		Vector2Int minPosition = Vector2Int.one * int.MaxValue;
		Vector2Int maxPosition = Vector2Int.one * int.MinValue;
		foreach (Vector3 centerPosition in centerPositions)
		{
			minPosition.x = Mathf.Min(minPosition.x, Mathf.RoundToInt(centerPosition.x));
			minPosition.y = Mathf.Min(minPosition.y, Mathf.RoundToInt(centerPosition.z));
			maxPosition.x = Mathf.Max(maxPosition.x, Mathf.RoundToInt(centerPosition.x));
			maxPosition.y = Mathf.Max(maxPosition.y, Mathf.RoundToInt(centerPosition.z));
		}
		minPosition -= Vector2Int.one * radius;
		maxPosition += Vector2Int.one * radius;
		for (int i = minPosition.x; i <= maxPosition.x; i++)
		{
			for (int j = minPosition.y; j <= maxPosition.y; j++)
			{
				if (!centerPositions.Contains(new Vector3(i, j)))
				{
					yield return grid.GetGridCell(i, j);
				}
			}
		}
	}

	public static bool CanBuildAroundPosition(Grid grid, IEnumerable<Vector3> centerPositions, int radius, Tile.ETileType[] excludedTileTypes, bool checkTotallyFree = false)
	{
		foreach (GridCell item in GetGridCellsAroundPosition(grid, centerPositions, radius))
		{
			if (item != null && (excludedTileTypes == null || excludedTileTypes.Length == 0 || !excludedTileTypes.Contains(item.Tile.TileType)) && (!item.CanBuild() || (checkTotallyFree && !item.IsFree())))
			{
				return false;
			}
		}
		return true;
	}

	public static IEnumerable<Vector3> GetGridCellsBetween(Vector3Int start, Vector3Int end)
	{
		Vector3Int vector3Int = end - start;
		int stepX = Mathf.RoundToInt(Mathf.Sign(vector3Int.x));
		int stepZ = Mathf.RoundToInt(Mathf.Sign(vector3Int.z));
		Vector3Int currentCell = start;
		float tDeltaX;
		float tMaxX;
		if ((float)vector3Int.x != 0f)
		{
			tDeltaX = 1f / (float)Mathf.Abs(vector3Int.x);
			tMaxX = tDeltaX;
		}
		else
		{
			tDeltaX = float.PositiveInfinity;
			tMaxX = float.PositiveInfinity;
		}
		float tDeltaZ;
		float tMaxZ;
		if ((float)vector3Int.z != 0f)
		{
			tDeltaZ = 1f / (float)Mathf.Abs(vector3Int.z);
			tMaxZ = tDeltaZ;
		}
		else
		{
			tDeltaZ = float.PositiveInfinity;
			tMaxZ = float.PositiveInfinity;
		}
		int maxSteps = 50;
		int steps = 0;
		while (currentCell != end && steps < maxSteps)
		{
			if (tMaxX < tMaxZ)
			{
				currentCell.x += stepX;
				tMaxX += tDeltaX;
			}
			else
			{
				currentCell.z += stepZ;
				tMaxZ += tDeltaZ;
			}
			yield return currentCell;
			steps++;
		}
	}

	public static int CompareVersionNumbers(string version1, string version2)
	{
		try
		{
			string[] array = version1.Substring(1).Split('-');
			string[] array2 = version2.Substring(1).Split('-');
			int[] array3 = Array.ConvertAll(array[0].Split('.'), int.Parse);
			int[] array4 = Array.ConvertAll(array2[0].Split('.'), int.Parse);
			for (int i = 0; i < 3; i++)
			{
				if (array3[i] != array4[i])
				{
					return array3[i].CompareTo(array4[i]);
				}
			}
			if (array.Length == 1 && array2.Length == 1)
			{
				return 0;
			}
			if (array.Length == 1)
			{
				return 1;
			}
			if (array2.Length == 1)
			{
				return -1;
			}
			if (array[1].StartsWith("testing") && array2[1].StartsWith("testing"))
			{
				int num = int.Parse(array[1].Split('_')[1]);
				int value = int.Parse(array2[1].Split('_')[1]);
				return num.CompareTo(value);
			}
			if (!array[1].StartsWith("testing") && !array2[1].StartsWith("testing"))
			{
				return 0;
			}
			if (!array[1].StartsWith("testing"))
			{
				return 1;
			}
			if (!array2[1].StartsWith("testing"))
			{
				return -1;
			}
			return 0;
		}
		catch (IndexOutOfRangeException)
		{
			return 0;
		}
	}

	public static ESeason GetCurrentSeason()
	{
		uint num = 0u;
		if (SteamManager.Initialized)
		{
			num = SteamUtils.GetServerRealTime();
		}
		DateTime dateTime = ((num == 0) ? DateTime.Now : DateTimeOffset.FromUnixTimeSeconds(num).DateTime);
		DateTime dateTime2 = new DateTime(dateTime.Year, 12, 18);
		DateTime dateTime3 = new DateTime(dateTime.Year, 12, 31);
		if (dateTime >= dateTime2 && dateTime <= dateTime3)
		{
			return ESeason.Christmas;
		}
		return ESeason.None;
	}
}
