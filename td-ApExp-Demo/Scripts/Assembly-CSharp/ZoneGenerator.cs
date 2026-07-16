using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public static class ZoneGenerator
{
	private const float POS_FACTOR_X = 48f;

	private const float POS_FACTOR_Y = 40f;

	private const float RANDOM_RANGE = 10f;

	private const int MAX_STRAIGHT_PATHS = 4;

	private const float FOUR_ROWS_WEIGHT = 0.25f;

	private const float THREE_ROWS_WEIGHT = 0.6f;

	private const float TWO_ROWS_WEIGHT = 0.15f;

	private static int[] _currentRowsPerColumn;

	private static int _currentStandardRows;

	public static List<LevelData> GenerateLevelDataList(ZoneDefinition def)
	{
		List<LevelData> list = new List<LevelData>();
		List<LevelData> list2 = CreatePreGridNodes(def);
		list.AddRange(list2);
		List<LevelData> list3 = CreateGridNodes(def);
		int count = list.Count;
		for (int i = 0; i < list3.Count; i++)
		{
			list3[i].index = count + i;
		}
		list.AddRange(list3);
		List<LevelData> list4 = CreatePostGridNodes(def);
		int count2 = list.Count;
		for (int j = 0; j < list4.Count; j++)
		{
			list4[j].index = count2 + j;
		}
		list.AddRange(list4);
		ConnectPreNodesToEachOther(list2);
		ConnectPreToGrid(list2, list3, def);
		ConnectGridNeighbors(list3, def);
		ConnectGridToPost(list3, list4, def);
		ConnectPostNodes(list4);
		PreventConnectedShops(list);
		PreventConnectedMysteryLocations(list);
		return list;
	}

	private static void PreventConnectedShops(List<LevelData> levels)
	{
		for (int i = 0; i < levels.Count; i++)
		{
			if (levels[i].lootType != LootType.Shop)
			{
				continue;
			}
			foreach (int item in levels[i].connectivity)
			{
				if (levels[item].lootType == LootType.Shop)
				{
					levels[item].lootType = LootType.Upgrade;
				}
			}
		}
	}

	private static void PreventConnectedMysteryLocations(List<LevelData> levels)
	{
		for (int i = 0; i < levels.Count; i++)
		{
			if (levels[i].lootType != LootType.MysteryLocation)
			{
				continue;
			}
			foreach (int item in levels[i].connectivity)
			{
				if (levels[item].lootType == LootType.MysteryLocation)
				{
					levels[item].lootType = LootType.Upgrade;
				}
			}
		}
	}

	private static List<LevelData> CreatePreGridNodes(ZoneDefinition def)
	{
		List<LevelData> list = new List<LevelData>();
		if (def.PreGridScriptedLevels == null)
		{
			return list;
		}
		for (int i = 0; i < def.PreGridScriptedLevels.Count; i++)
		{
			ScriptedLevel scriptedLevel = def.PreGridScriptedLevels[i];
			LevelData levelData = scriptedLevel.CreateLevelData();
			levelData.index = i;
			levelData.scriptedLevel = scriptedLevel;
			int col = -def.PreGridScriptedLevels.Count + i;
			int row = def.MapSize.y / 2;
			levelData.position = GenerateRandomPosition(col, row, def.MapSize.y);
			list.Add(levelData);
		}
		return list;
	}

	private static List<LevelData> CreateGridNodes(ZoneDefinition def)
	{
		List<LevelData> list = new List<LevelData>();
		int zoneIndex = ZoneManager.Instance.GetZoneIndex(def);
		int x = def.MapSize.x;
		int num = (_currentStandardRows = def.MapSize.y);
		int[] array = new int[x];
		for (int i = 0; i < x; i++)
		{
			if (def.ZoneName == "T0_Tutorial")
			{
				array[i] = 1;
				continue;
			}
			if (i == 0)
			{
				array[i] = 3;
				continue;
			}
			int weightedIndex = LootUtils.GetWeightedIndex(new float[3] { 0.15f, 0.6f, 0.25f });
			array[i] = weightedIndex + 2;
		}
		_currentRowsPerColumn = array;
		for (int j = 0; j < x; j++)
		{
			int num2 = array[j];
			int num3 = (num - num2) / 2;
			for (int k = 0; k < num2; k++)
			{
				int row = k + num3;
				LevelData item = new LevelData
				{
					name = LevelUtils.GetRandomLevelName(),
					levelType = LevelType.Waves,
					lootType = LootUtils.GetWeightedLootType(zoneIndex, x, j),
					difficulty = LevelUtils.GetWeightedLevelDifficulty(def, j),
					connectivity = new List<int>(),
					position = GenerateRandomPosition(j, row, num),
					column = j + 1,
					savedModifiers = new List<float>()
				};
				list.Add(item);
			}
		}
		return list;
	}

	private static List<LevelData> CreatePostGridNodes(ZoneDefinition def)
	{
		List<LevelData> list = new List<LevelData>();
		if (def.PostGridScriptedLevels == null)
		{
			return list;
		}
		for (int i = 0; i < def.PostGridScriptedLevels.Count; i++)
		{
			ScriptedLevel scriptedLevel = def.PostGridScriptedLevels[i];
			LevelData levelData = scriptedLevel.CreateLevelData();
			levelData.scriptedLevel = scriptedLevel;
			int col = def.MapSize.x + i;
			int row = def.MapSize.y / 2;
			levelData.position = GenerateRandomPosition(col, row, def.MapSize.y);
			list.Add(levelData);
		}
		return list;
	}

	private static void ConnectPreNodesToEachOther(List<LevelData> preNodes)
	{
		for (int i = 0; i < preNodes.Count - 1; i++)
		{
			AddConnection(preNodes[i], preNodes[i + 1]);
		}
	}

	private static void ConnectPreToGrid(List<LevelData> preNodes, List<LevelData> gridNodes, ZoneDefinition def)
	{
		if (preNodes.Count == 0 || gridNodes.Count == 0)
		{
			return;
		}
		LevelData a = preNodes[preNodes.Count - 1];
		int[] array = _currentRowsPerColumn ?? Enumerable.Repeat(def.MapSize.y, def.MapSize.x).ToArray();
		int num = array[0];
		for (int i = 0; i < num; i++)
		{
			int nodeIndex = GetNodeIndex(0, i, array);
			if (nodeIndex < gridNodes.Count)
			{
				AddConnection(a, gridNodes[nodeIndex]);
			}
		}
	}

	private static void ConnectGridNeighbors(List<LevelData> gridNodes, ZoneDefinition def)
	{
		int x = def.MapSize.x;
		int y = def.MapSize.y;
		int[] array = _currentRowsPerColumn ?? Enumerable.Repeat(y, x).ToArray();
		int?[,] array2 = new int?[y, x];
		int num = 0;
		for (int i = 0; i < x; i++)
		{
			int num2 = array[i];
			int num3 = (y - num2) / 2;
			for (int j = 0; j < num2; j++)
			{
				int num4 = j + num3;
				array2[num4, i] = num;
				num++;
			}
		}
		for (int k = 0; k < x - 1; k++)
		{
			int num5 = array[k];
			int num6 = array[k + 1];
			int num7 = (y - num5) / 2;
			int num8 = (y - num6) / 2;
			for (int l = 0; l < num5; l++)
			{
				int num9 = l + num7;
				int? num10 = array2[num9, k];
				if (!num10.HasValue)
				{
					continue;
				}
				LevelData levelData = gridNodes[num10.Value];
				if (levelData.scriptedLevel != null)
				{
					continue;
				}
				int num11 = -1;
				float num12 = float.MaxValue;
				for (int m = 0; m < num6; m++)
				{
					int num13 = m + num8;
					float num14 = Mathf.Abs(num9 - num13);
					if (num14 < num12)
					{
						num12 = num14;
						num11 = m;
					}
				}
				if (num11 < 0)
				{
					continue;
				}
				int num15 = num11 + num8;
				int? num16 = array2[num15, k + 1];
				if (num16.HasValue)
				{
					LevelData levelData2 = gridNodes[num16.Value];
					if (levelData2.scriptedLevel == null)
					{
						AddConnection(levelData, levelData2);
					}
				}
			}
			for (int n = 0; n < num6; n++)
			{
				int num17 = n + num8;
				int? num18 = array2[num17, k + 1];
				if (!num18.HasValue)
				{
					continue;
				}
				LevelData levelData3 = gridNodes[num18.Value];
				if (levelData3.scriptedLevel != null)
				{
					continue;
				}
				bool flag = false;
				for (int num19 = 0; num19 < num5; num19++)
				{
					int num20 = num19 + num7;
					int? num21 = array2[num20, k];
					if (num21.HasValue && AreConnected(levelData3, gridNodes[num21.Value]))
					{
						flag = true;
						break;
					}
				}
				if (flag)
				{
					continue;
				}
				int num22 = -1;
				float num23 = float.MaxValue;
				for (int num24 = 0; num24 < num5; num24++)
				{
					int num25 = num24 + num7;
					float num26 = Mathf.Abs(num17 - num25);
					if (num26 < num23)
					{
						num23 = num26;
						num22 = num24;
					}
				}
				if (num22 < 0)
				{
					continue;
				}
				int num27 = num22 + num7;
				int? num28 = array2[num27, k];
				if (num28.HasValue)
				{
					LevelData levelData4 = gridNodes[num28.Value];
					if (levelData4.scriptedLevel == null)
					{
						AddConnection(levelData4, levelData3);
					}
				}
			}
		}
		for (int num29 = 0; num29 < x - 1; num29++)
		{
			int num30 = array[num29];
			int num31 = array[num29 + 1];
			int num32 = (y - num30) / 2;
			int num33 = (y - num31) / 2;
			int num34 = Mathf.Max(num32, num33);
			int num35 = Mathf.Min(num32 + num30 - 1, num33 + num31 - 1);
			for (int num36 = num34; num36 < num35; num36++)
			{
				int? num37 = array2[num36, num29];
				int? num38 = array2[num36, num29 + 1];
				int? num39 = array2[num36 + 1, num29];
				int? num40 = array2[num36 + 1, num29 + 1];
				if (!num37.HasValue || !num38.HasValue || !num39.HasValue || !num40.HasValue)
				{
					continue;
				}
				LevelData levelData5 = gridNodes[num37.Value];
				LevelData levelData6 = gridNodes[num38.Value];
				LevelData levelData7 = gridNodes[num39.Value];
				LevelData levelData8 = gridNodes[num40.Value];
				if (levelData5.scriptedLevel != null || levelData6.scriptedLevel != null || levelData7.scriptedLevel != null || levelData8.scriptedLevel != null)
				{
					continue;
				}
				if (DRNG.Instance.NextFloat01() < 0.5f)
				{
					if (!AreConnected(levelData5, levelData8))
					{
						AddConnection(levelData5, levelData8);
					}
				}
				else if (!AreConnected(levelData6, levelData7))
				{
					AddConnection(levelData6, levelData7);
				}
			}
		}
	}

	private static bool AreConnected(LevelData a, LevelData b)
	{
		if (!a.connectivity.Contains(b.index))
		{
			return b.connectivity.Contains(a.index);
		}
		return true;
	}

	private static void ConnectGridToPost(List<LevelData> gridNodes, List<LevelData> postNodes, ZoneDefinition def)
	{
		if (gridNodes.Count == 0 || postNodes.Count == 0)
		{
			return;
		}
		LevelData b = postNodes[0];
		int[] array = _currentRowsPerColumn ?? Enumerable.Repeat(def.MapSize.y, def.MapSize.x).ToArray();
		int num = array[def.MapSize.x - 1];
		for (int i = 0; i < num; i++)
		{
			int nodeIndex = GetNodeIndex(def.MapSize.x - 1, i, array);
			if (nodeIndex < gridNodes.Count)
			{
				AddConnection(gridNodes[nodeIndex], b);
			}
		}
	}

	private static void ConnectPostNodes(List<LevelData> postNodes)
	{
		for (int i = 0; i < postNodes.Count - 1; i++)
		{
			AddConnection(postNodes[i], postNodes[i + 1]);
		}
	}

	private static void AddConnection(LevelData a, LevelData b)
	{
		if (a.connectivity == null)
		{
			a.connectivity = new List<int>();
		}
		if (b.connectivity == null)
		{
			b.connectivity = new List<int>();
		}
		if (!a.connectivity.Contains(b.index))
		{
			a.connectivity.Add(b.index);
		}
		if (!b.connectivity.Contains(a.index))
		{
			b.connectivity.Add(a.index);
		}
	}

	private static Vector2 GenerateRandomPosition(int col, int row, int totalRows)
	{
		float num = DRNG.Instance.NextFloat(-10f, 10f);
		float num2 = DRNG.Instance.NextFloat(-10f, 10f);
		float num3 = (float)totalRows * 0.5f - 0.5f;
		float x = (float)col * 48f + num;
		float y = ((float)row - num3) * 40f + num2;
		return new Vector2(x, y);
	}

	private static int GetNodeIndex(int col, int localRow, int[] rowsPerColumn)
	{
		int num = 0;
		for (int i = 0; i < col; i++)
		{
			num += rowsPerColumn[i];
		}
		return num + localRow;
	}
}
