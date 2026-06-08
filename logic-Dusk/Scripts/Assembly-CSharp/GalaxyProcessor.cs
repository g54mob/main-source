using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using BoardEditor;
using UnityEngine;

public static class GalaxyProcessor
{
	public delegate void DungeonProcessorCB(StarSystemInfo starSystemInfo, DungeonInfo dungeonInfo);

	private const float MINIMUM_DUNGEON_DISTANCE = 75f;

	private const float MINIMUM_EARLYPLAY_DUNGEON_DISTANCE_MIN = 100f;

	private const float MINIMUM_EARLYPLAY_DUNGEON_DISTANCE_MAX = 150f;

	private const float MINIMUM_SYSTEM_DISTANCE = 200f;

	public const float STARSYS_DISTANCE_TO_RATIONS_FACTOR = 7.5f;

	private const float DUNGEON_COORDS_MIN_X = -250f;

	private const float DUNGEON_COORDS_MAX_X = 250f;

	private const float DUNGEON_COORDS_MIN_Y = -150f;

	private const float DUNGEON_COORDS_MAX_Y = 150f;

	public static UniverseMapManager universeMapManager;

	private static List<ShipInfestationType> unlockedInfestationTypes;

	public static string GalaxyFolderName { get; private set; }

	public static SettingsFile ObjectiveFile { get; private set; }

	public static SettingsFile ObjectiveProgressFile { get; private set; }

	public static void BuildUniverseGalaxies()
	{
		if (universeMapManager == null)
		{
			return;
		}
		List<UniverseNode> placedNodes = universeMapManager.GetPlacedNodes();
		foreach (UniverseNode item in placedNodes)
		{
			if (string.IsNullOrEmpty(UniverseSaveFile.Get(item.GroupKey, string.Empty)))
			{
				UniverseSaveFile.Save(item.GroupKey, "FILE", string.Format("gd_{0}", item.InternalID));
				GalaxySaveFile.InitSetting(item.InternalID);
			}
		}
	}

	public static void SetObjectiveFile(SettingsFile newObjective)
	{
		ObjectiveFile = newObjective;
	}

	public static void ClearObjective()
	{
		ObjectiveFile = null;
	}

	public static void SetObjectiveProgressFile(SettingsFile newObjective)
	{
		ObjectiveProgressFile = newObjective;
	}

	public static void ClearObjectiveProgress()
	{
		ObjectiveProgressFile = null;
	}

	public static bool InitalizeGalaxy(string galaxyFolderName)
	{
		GalaxyFolderName = galaxyFolderName;
		string dataGalaxyLocation = GameFileHelper.GetDataGalaxyLocation();
		string text = Path.Combine(dataGalaxyLocation, GalaxyFolderName);
		if (Directory.Exists(text))
		{
			string path = Path.Combine(text, "_mDM.png");
			if (File.Exists(path))
			{
				GalaxyMapManager.depthMapSourceTexture = ResourceManager.LoadPNG(path, 1024, 512);
				string path2 = Path.Combine(text, "_mTM.png");
				GalaxyMapManager.typeMapSourceTexture = ResourceManager.LoadPNG(path2, 1024, 512);
				string path3 = Path.Combine(text, "_mTDM.png");
				GalaxyMapManager.typeDensityMapSourceTexture = ResourceManager.LoadPNG(path3, 1024, 512);
				string path4 = Path.Combine(text, "_mDIM.png");
				GalaxyMapManager.difficultyMapSourceTexture = ResourceManager.LoadPNG(path4, 1024, 512);
				return true;
			}
		}
		return false;
	}

	public static void DeinitalizeGalaxy(string galaxyFolderName)
	{
		GalaxyFolderName = galaxyFolderName;
		string dataGalaxyLocation = GameFileHelper.GetDataGalaxyLocation();
		string text = Path.Combine(dataGalaxyLocation, GalaxyFolderName);
		if (Directory.Exists(text))
		{
			string text2 = Path.Combine(text, "_mDM.png");
			if (File.Exists(text2))
			{
				ResourceManager.UnloadAsset(text2);
				string resourcePath = Path.Combine(text, "_mTM.png");
				ResourceManager.UnloadAsset(resourcePath);
				string resourcePath2 = Path.Combine(text, "_mTDM.png");
				ResourceManager.UnloadAsset(resourcePath2);
				string resourcePath3 = Path.Combine(text, "_mDIM.png");
				ResourceManager.UnloadAsset(resourcePath3);
			}
		}
	}

	public static List<StarSystemInfo> BuildStarSystems(int systemSeed)
	{
		int countSystems = 0;
		return BuildStarSystems(systemSeed, false, out countSystems);
	}

	public static List<StarSystemInfo> BuildStarSystems(int systemSeed, bool countOnly, out int countSystems)
	{
		countSystems = 0;
		int seed = UnityEngine.Random.seed;
		bool flag = systemSeed == -1;
		UnityEngine.Random.seed = systemSeed;
		List<StarSystemInfo> list = new List<StarSystemInfo>();
		int width = GalaxyMapManager.depthMapSourceTexture.width;
		int height = GalaxyMapManager.depthMapSourceTexture.height;
		int num = 18;
		int num2 = 12;
		float num3 = width + num * 2;
		float num4 = height + num2 * 2;
		float num5 = num3 / (float)width;
		float num6 = num4 / (float)height;
		int num7 = 100000;
		int num8 = 1000;
		int num9 = 197;
		int num10 = 300;
		int num11 = 0;
		int num12 = 0;
		if (GlobalSettings.gameMode == GameModeEnum.DailyChallenge)
		{
			num10 = 1;
		}
		do
		{
			int num13 = UnityEngine.Random.Range(0, width);
			int num14 = UnityEngine.Random.Range(0, height);
			Color pixel = GalaxyMapManager.depthMapSourceTexture.GetPixel(num13, num14);
			if (pixel.r >= 0.1f && UnityEngine.Random.Range(0f, 1f) <= pixel.r)
			{
				float num15 = (float)num9 * (1f - pixel.r);
				int num16 = (int)(28f + num15);
				float x = (float)(num13 - width / 2) * num5;
				float y = (float)(num14 - height / 2) * num6;
				Vector3 vector = new Vector3(x, y, 0f);
				bool flag2 = true;
				if (list.Count > 0)
				{
					foreach (StarSystemInfo item in list)
					{
						float num17 = Vector3.Distance(vector, item.Coordinates);
						if (num17 < (float)num16)
						{
							flag2 = false;
							break;
						}
					}
				}
				if (flag2)
				{
					StarSystemInfo starSystemInfo = null;
					starSystemInfo = new StarSystemInfo(list);
					starSystemInfo.Coordinates = vector;
					starSystemInfo.TrueImageCoords = new Vector2(num13, num14);
					if (!countOnly)
					{
						starSystemInfo.IsNursery = GlobalSettings.gameMode == GameModeEnum.Normal && !GameSaveFile.Get("HARD", false) && !GameSaveFile.Get("URESET", false) && GalaxySaveFile.Get(starSystemInfo.GroupKey, "SS", false);
					}
					BuildStarSystemItems(ref starSystemInfo);
					list.Add(starSystemInfo);
					num11++;
					int num18 = 0;
					do
					{
						int num19 = UnityEngine.Random.Range(num16, num16 + (int)((float)num9 * num15));
						float x2 = UnityEngine.Random.Range(-1f, 1f);
						float y2 = UnityEngine.Random.Range(-1f, 1f);
						Vector2 vector2 = new Vector2(x2, y2);
						vector2.Normalize();
						Vector2 vector3 = starSystemInfo.TrueImageCoords + vector2 * num19;
						int num20 = (int)vector3.x;
						int num21 = (int)vector3.y;
						if (num20 >= 0 && num20 < width && num21 >= 0 && num21 < height)
						{
							pixel = GalaxyMapManager.depthMapSourceTexture.GetPixel(num20, num21);
							if (pixel.r >= 0.1f && UnityEngine.Random.Range(0f, 1f) <= pixel.r)
							{
								float num22 = (float)num9 * (1f - pixel.r);
								int num23 = (int)(28f + num22);
								x = (float)(num20 - width / 2) * num5;
								y = (float)(num21 - height / 2) * num6;
								Vector3 a = new Vector3(x, y, 0f);
								flag2 = true;
								if (list.Count > 0)
								{
									foreach (StarSystemInfo item2 in list)
									{
										float num24 = Vector3.Distance(a, item2.Coordinates);
										if (num24 < (float)num23)
										{
											flag2 = false;
											break;
										}
									}
								}
								if (flag2)
								{
									starSystemInfo = new StarSystemInfo(list);
									vector = new Vector3(x, y, 0f);
									starSystemInfo.Coordinates = vector;
									starSystemInfo.TrueImageCoords = new Vector2(num20, num21);
									if (!countOnly)
									{
										starSystemInfo.IsNursery = GlobalSettings.gameMode == GameModeEnum.Normal && !GameSaveFile.Get("HARD", false) && !GameSaveFile.Get("URESET", false) && GalaxySaveFile.Get(starSystemInfo.GroupKey, "SS", false);
									}
									BuildStarSystemItems(ref starSystemInfo);
									list.Add(starSystemInfo);
									num15 = num22;
									num16 = num23;
									num13 = num20;
									num14 = num21;
									num11++;
								}
							}
						}
						num18++;
					}
					while (num11 < num10 && num18 < num8);
					if (num11 >= num10)
					{
						break;
					}
				}
			}
			num12++;
		}
		while (num11 < num10 && num12 < num7);
		countSystems = num11;
		float num25 = GameSaveFile.Get("GAME_VER", 0f);
		if (num25 > 0f && num25 > 0.301f && flag)
		{
			UnityEngine.Random.seed = seed;
		}
		return list;
	}

	private static void BuildStarSystemItems(ref StarSystemInfo starSystemInfo)
	{
		bool flag = false;
		if (GalaxyMapManager.typeMapSourceTexture != null)
		{
			Color pixel = GalaxyMapManager.typeMapSourceTexture.GetPixel((int)starSystemInfo.TrueImageCoords.x, (int)starSystemInfo.TrueImageCoords.y);
			Color color = Color.black;
			Color color2 = Color.black;
			if (GalaxyMapManager.typeDensityMapSourceTexture != null)
			{
				color = GalaxyMapManager.typeDensityMapSourceTexture.GetPixel((int)starSystemInfo.TrueImageCoords.x, (int)starSystemInfo.TrueImageCoords.y);
			}
			else
			{
				color.r = UnityEngine.Random.Range(0f, 1f);
			}
			if (GalaxyMapManager.difficultyMapSourceTexture != null)
			{
				color2 = GalaxyMapManager.difficultyMapSourceTexture.GetPixel((int)starSystemInfo.TrueImageCoords.x, (int)starSystemInfo.TrueImageCoords.y);
			}
			if (pixel.r > 0f || pixel.g > 0f || pixel.b > 0f)
			{
				float num = pixel.r + pixel.g + pixel.b;
				int num2 = 18;
				int num3 = 2 + (int)((float)num2 * color.r);
				num3 *= 2;
				float num4 = pixel.r / num;
				float num5 = pixel.g / num;
				float num6 = pixel.b / num;
				int num7 = (int)((float)num3 * num4);
				int num8 = (int)((float)num3 * num5);
				int num9 = (int)((float)num3 * num6);
				int num10 = 0;
				float key = num4 % num;
				float num11 = num5 % num;
				float num12 = num6 % num;
				SortedList<float, int> sortedList = new SortedList<float, int>();
				if (pixel.r > 0f)
				{
					sortedList.Add(key, 0);
				}
				if (pixel.g > 0f)
				{
					if (sortedList.ContainsKey(num11))
					{
						num11 += 1E-05f;
					}
					sortedList.Add(num11, 1);
				}
				if (pixel.b > 0f)
				{
					if (sortedList.ContainsKey(num12))
					{
						num12 += 2E-05f;
					}
					sortedList.Add(num12, 2);
				}
				while (num7 + num8 + num9 < num3 && num10 < 100)
				{
					IEnumerator<KeyValuePair<float, int>> enumerator = sortedList.GetEnumerator();
					while (enumerator.MoveNext())
					{
						switch (enumerator.Current.Value)
						{
						case 0:
							num7++;
							break;
						case 1:
							num8++;
							break;
						case 2:
							num9++;
							break;
						}
						if (num7 + num8 + num9 >= num3)
						{
							break;
						}
					}
					num10++;
				}
				if (num7 + num8 + num9 > num3)
				{
					Debug.LogWarning(string.Format("Total objects ({0}) for starsystem (id={1}) exceeds the total number of items of {2}", num7 + num8 + num9, starSystemInfo.Id, num2));
				}
				starSystemInfo.NumberOfTradingPosts = num7;
				starSystemInfo.NumberOfOutposts = num8;
				if (GameSaveFile.Get("GAME_VER", 0f) > 0f && GameSaveFile.Get("GAME_VER", 0f) <= 0.292f)
				{
					starSystemInfo.NumberOfDungeons = num9;
				}
				else if (GlobalSettings.gameMode != GameModeEnum.DailyChallenge)
				{
					int num13 = 0;
					int num14 = 0;
					float f = (float)num9 * UnityEngine.Random.Range(0.7f, 1f);
					if (UnityEngine.Random.Range(0, 100) > 20)
					{
						num13 = Mathf.RoundToInt(f);
						num14 = num9 - num13;
					}
					else
					{
						num14 = Mathf.RoundToInt(f);
						num13 = num9 - num14;
					}
					starSystemInfo.NumberOfDungeons = num13;
					starSystemInfo.NumberOfStations = num14;
				}
				else
				{
					starSystemInfo.NumberOfTradingPosts = 0;
					starSystemInfo.NumberOfOutposts = 0;
					starSystemInfo.NumberOfDungeons = 1;
				}
				float num15 = color2.r;
				float num16 = color2.g;
				if (color2 == Color.black)
				{
					num15 = 0f;
					num16 = 1f;
				}
				if (num15 > num16)
				{
					Debug.LogWarning(string.Format("The difficulty defined at the position where star system {0} is located has a min color which is GREATER THAN the max color (R = {1}, G = {2}).  Flipping min/max values.", starSystemInfo.InternalId, num15, num16));
					float num17 = num15;
					num15 = num16;
					num16 = num17;
				}
				starSystemInfo.DifficultyMin = num15;
				starSystemInfo.DifficultyMax = num16;
				flag = true;
			}
		}
		if (!flag)
		{
			int num18 = UnityEngine.Random.Range(6, 11);
			starSystemInfo.NumberOfDungeons = (int)((float)num18 * 0.66999996f);
			starSystemInfo.NumberOfOutposts = num18 - starSystemInfo.NumberOfDungeons;
			starSystemInfo.NumberOfTradingPosts = UnityEngine.Random.Range(0, 3);
		}
	}

	public static void GenerateDungeonInfo(StarSystemInfo starSystemInfo, bool inGameGeneration, DungeonProcessorCB enemyBuilder)
	{
		GalaxySaveFile.BeginBatch();
		string groupKey = starSystemInfo.GroupKey;
		bool flag = true;
		int num = -1;
		while (UnityEngine.Random.seed == -1)
		{
			UnityEngine.Random.seed = UnityEngine.Random.Range(int.MinValue, int.MaxValue);
		}
		int seed = UnityEngine.Random.seed;
		num = GalaxySaveFile.GetSystemSeed(groupKey, -1);
		if (num != -1)
		{
			UnityEngine.Random.seed = num;
			GlobalSettings.GameState.NextDungeonId = GalaxySaveFile.Get(groupKey, "FIRST_SHIP_ID", 0);
			if (GlobalSettings.GameState.NextDungeonId == 0 && inGameGeneration)
			{
				int num2 = UniverseSaveFile.Get<int>("LAST_SHIP_ID");
				if (num2 > 0)
				{
					GlobalSettings.GameState.NextDungeonId = num2;
				}
				else
				{
					GlobalSettings.GameState.NextDungeonId = 1;
				}
				GalaxySaveFile.Save(groupKey, "FIRST_SHIP_ID", GlobalSettings.GameState.NextDungeonId);
			}
			else
			{
				flag = false;
			}
		}
		else
		{
			Thread.Sleep(1);
			if (GlobalSettings.gameMode == GameModeEnum.Normal)
			{
				UnityEngine.Random.seed = (int)DateTime.Now.Ticks;
			}
			if (inGameGeneration)
			{
				int num3 = UniverseSaveFile.Get<int>("LAST_SHIP_ID");
				if (num3 > 0)
				{
					GlobalSettings.GameState.NextDungeonId = num3;
				}
				else
				{
					GlobalSettings.GameState.NextDungeonId = 1;
				}
				GalaxySaveFile.Save(groupKey, "FIRST_SHIP_ID", GlobalSettings.GameState.NextDungeonId);
			}
		}
		GalaxySaveFile.SaveSystemSeed(groupKey, UnityEngine.Random.seed);
		if (GlobalSettings.GameState.NextDungeonId == 0)
		{
			GlobalSettings.GameState.NextDungeonId = 1;
		}
		starSystemInfo.Dungeons = new List<DungeonInfo>();
		GenerateDungeonInfoForType(DungeonTypeEnum.Derelict, starSystemInfo, inGameGeneration, false);
		GenerateDungeonInfoForType(DungeonTypeEnum.Station, starSystemInfo, inGameGeneration, false);
		GenerateDungeonInfoForType(DungeonTypeEnum.Outpost, starSystemInfo, inGameGeneration, false);
		GenerateDungeonInfoForType(DungeonTypeEnum.AutoTrade, starSystemInfo, inGameGeneration, false);
		GenerateDungeonInfoForType(DungeonTypeEnum.Stargate, starSystemInfo, inGameGeneration, false);
		if (flag)
		{
			if (inGameGeneration)
			{
				UniverseSaveFile.Save("LAST_SHIP_ID", GlobalSettings.GameState.NextDungeonId);
			}
			if (inGameGeneration)
			{
				if (!starSystemInfo.IsNursery || GameSaveFile.Get("NC", false))
				{
					bool flag2 = false;
					float num4 = GameSaveFile.Get("GAME_VER", 0f);
					if (num4 > 0f && num4 < 0.321f)
					{
						flag2 = true;
					}
					foreach (DungeonInfo dungeon in starSystemInfo.Dungeons)
					{
						if (dungeon.DungeonType != DungeonTypeEnum.Derelict && dungeon.DungeonType != DungeonTypeEnum.Station && dungeon.DungeonType != DungeonTypeEnum.Outpost)
						{
							continue;
						}
						float num5 = 0.2f;
						int num6 = (int)(dungeon.CalculatedDifficultyValues.InfestationTypeValue / num5);
						int num7 = 0;
						while (unlockedInfestationTypes.Count < num6 && unlockedInfestationTypes.Count < 4 && num7 < 10)
						{
							UnlockNextInfestationType();
							num7++;
						}
						if (num7 == 10)
						{
							Debug.LogWarning(string.Format("Trying to unlock another infection type, but can't.  Number available/needed: {0}/{1}", unlockedInfestationTypes.Count, num6));
						}
						if (!flag2)
						{
							List<int> list = null;
							int num8 = GalaxySaveFile.Get(dungeon.GroupKey, "AI", 0);
							if (num8 == 3)
							{
								list = new List<int>(unlockedInfestationTypes.Count);
								int count = unlockedInfestationTypes.Count;
								int num9 = 0;
								for (int i = 0; i < count; i++)
								{
									num9 = ((unlockedInfestationTypes[i] != ShipInfestationType.Slime) ? (num9 + 10) : (num9 + 1));
									list.Add(num9);
								}
								dungeon.AddRangeInfestationType(RandomPickInfestationTypesWeighted(num6, unlockedInfestationTypes, list, num9));
							}
							else if (dungeon.IsQuarentined)
							{
								list = new List<int>(unlockedInfestationTypes.Count);
								int count2 = unlockedInfestationTypes.Count;
								int num10 = 0;
								for (int j = 0; j < count2; j++)
								{
									num10 = ((unlockedInfestationTypes[j] != ShipInfestationType.Slime) ? ((unlockedInfestationTypes[j] != ShipInfestationType.Brute) ? (num10 + 1) : (num10 + 10)) : (num10 + 10));
									list.Add(num10);
								}
								dungeon.AddRangeInfestationType(RandomPickInfestationTypesWeighted(num6, unlockedInfestationTypes, list, num10));
							}
							else
							{
								dungeon.AddRangeInfestationType(RandomPickInfestationTypes(num6, unlockedInfestationTypes));
							}
						}
						else
						{
							dungeon.AddRangeInfestationType(RandomPickInfestationTypes(num6, unlockedInfestationTypes));
						}
					}
				}
				else if (unlockedInfestationTypes.Count == 0)
				{
					UnlockNextInfestationType();
				}
			}
		}
		else
		{
			foreach (DungeonInfo dungeon2 in starSystemInfo.Dungeons)
			{
				dungeon2.ClearInfestationType();
				string text = GalaxySaveFile.Get(dungeon2.GroupKey, "ITYPE", string.Empty);
				if (string.IsNullOrEmpty(text))
				{
					continue;
				}
				string[] array = text.Split(',');
				string[] array2 = array;
				foreach (string text2 in array2)
				{
					try
					{
						ShipInfestationType infestationType = (ShipInfestationType)(int)Enum.Parse(typeof(ShipInfestationType), text2, false);
						dungeon2.AddInfestationType(infestationType);
					}
					catch (Exception ex)
					{
						Debug.LogError(string.Format("Invalid infection type found in the data: {0}\r\nException: {1}", text2, ex.Message));
					}
				}
			}
		}
		GalaxySaveFile.EndBatch();
	}

	private static void GenerateDungeonInfoForType(DungeonTypeEnum dungeonType, StarSystemInfo starSystemInfo, bool inGameGeneration, bool isNursery)
	{
		int num = 0;
		if (!isNursery)
		{
			switch (dungeonType)
			{
			case DungeonTypeEnum.Derelict:
				num = starSystemInfo.NumberOfDungeons;
				break;
			case DungeonTypeEnum.Station:
				num = starSystemInfo.NumberOfStations;
				break;
			case DungeonTypeEnum.Outpost:
				num = starSystemInfo.NumberOfOutposts;
				break;
			case DungeonTypeEnum.AutoTrade:
				num = starSystemInfo.NumberOfTradingPosts;
				break;
			case DungeonTypeEnum.Stargate:
				if (starSystemInfo.HasStargate)
				{
					num = 1;
				}
				break;
			}
		}
		else
		{
			num = 4;
		}
		for (int i = 0; i < num; i++)
		{
			int nextID = 0;
			if (inGameGeneration)
			{
				nextID = GlobalSettings.GameState.NextDungeonId++;
			}
			int seed = UnityEngine.Random.seed;
			DungeonInfo dungeonInfo = null;
			dungeonInfo = (isNursery ? BuildNurseryDungeon(seed, dungeonType, starSystemInfo, nextID, i) : BuildNormalDungeon(seed, dungeonType, starSystemInfo, nextID));
			string text = GalaxySaveFile.FindGroup("OBJ_", "ORIG_ID", dungeonInfo.GroupKey);
			if (text != string.Empty)
			{
				int result = -1;
				string[] array = text.Split('_');
				if (array.Length > 1 && int.TryParse(array[1], out result))
				{
					dungeonInfo.SetOverrideInternalID(result);
				}
				dungeonInfo.HaveVisited = GalaxySaveFile.Get(text, "VISITED", false);
				dungeonInfo.Name = GalaxySaveFile.Get(text, "NAME", dungeonInfo.Name);
				dungeonInfo.SetDifficulty(GalaxySaveFile.Get(text, "DMIN", dungeonInfo.DifficultyFactor));
				string text2 = GalaxySaveFile.Get(text, "DEFNAME", string.Empty);
				if (text2 == "Tech")
				{
					text2 = "MUTEKI";
				}
				string className = GalaxySaveFile.Get(text, "DEFCLASS", string.Empty);
				if (!string.IsNullOrEmpty(text2))
				{
					dungeonInfo.Definition = DungeonConfigurationManager.DungeonHelper.GetDungeonDefinition(dungeonType, text2, className);
				}
				dungeonInfo.ClearInfestationType();
			}
			GalaxySaveFile.Save(dungeonInfo.GroupKey, "SEED_D", seed);
			starSystemInfo.Dungeons.Add(dungeonInfo);
		}
	}

	public static DungeonInfo BuildNormalDungeon(int seed, DungeonTypeEnum dungeonType, StarSystemInfo starSystemInfo, int nextID)
	{
		return BuildNormalDungeon(seed, dungeonType, starSystemInfo, nextID, -1);
	}

	public static DungeonInfo BuildNormalDungeon(int seed, DungeonTypeEnum dungeonType, StarSystemInfo starSystemInfo, int nextID, int internalIDOverride)
	{
		UnityEngine.Random.seed = seed;
		DungeonInfo dungeonInfo = null;
		switch (dungeonType)
		{
		case DungeonTypeEnum.Derelict:
		case DungeonTypeEnum.Station:
		{
			DungeonInfo dungeonInfo2 = new DungeonInfo(starSystemInfo, nextID, internalIDOverride);
			dungeonInfo2.DungeonType = dungeonType;
			dungeonInfo = dungeonInfo2;
			if (dungeonType == DungeonTypeEnum.Station && GameSaveFile.Get("GAME_VER", 0f) > 0.292f)
			{
				dungeonInfo.Definition = DungeonConfigurationManager.DungeonHelper.GetRandomStationClass();
			}
			else
			{
				dungeonInfo.Definition = DungeonConfigurationManager.DungeonHelper.GetRandomShipClass();
			}
			dungeonInfo.HideDisplayCount = UnityEngine.Random.Range(0, 5) == 0;
			dungeonInfo.SceneName = "DungeonScene_Generated_Pro";
			if (GameSaveFile.Get("GAME_VER", 0f) > 0.272f)
			{
				dungeonInfo.ScrapMax = UnityEngine.Random.Range(dungeonInfo.Definition.Value.scrapContainerMin, dungeonInfo.Definition.Value.scrapContainerMax + 1);
			}
			else
			{
				dungeonInfo.ScrapMax = 999;
			}
			if (GameSaveFile.Get("GAME_VER", 0f) > 0.281f)
			{
				dungeonInfo.PFuelMax = UnityEngine.Random.Range(dungeonInfo.Definition.Value.pfuelChargeContainerMin, dungeonInfo.Definition.Value.pfuelReserveContainerMax + 1);
			}
			else
			{
				dungeonInfo.PFuelMax = 999;
			}
			if (GameSaveFile.Get("GAME_VER", 0f) > 0.292f && dungeonInfo.Definition.Value.chanceOfQuarentineOverride > 0)
			{
				dungeonInfo.IsQuarentined = UnityEngine.Random.Range(0, 100) < dungeonInfo.Definition.Value.chanceOfQuarentineOverride;
			}
			dungeonInfo.FixedShipUpgradeType = ShipUpgradeType.PermCannon;
			break;
		}
		case DungeonTypeEnum.Outpost:
		{
			DungeonInfo dungeonInfo2 = new DungeonInfo(starSystemInfo, nextID, internalIDOverride);
			dungeonInfo2.DungeonType = dungeonType;
			dungeonInfo = dungeonInfo2;
			dungeonInfo.Definition = DungeonConfigurationManager.DungeonHelper.GetRandomOutpostClass();
			dungeonInfo.HideDisplayCount = UnityEngine.Random.Range(0, 5) == 0;
			dungeonInfo.SceneName = "DungeonScene_Generated_Pro";
			dungeonInfo.BackgroundImageID = UnityEngine.Random.Range(0, 5);
			if (GameSaveFile.Get("GAME_VER", 0f) > 0.292f && dungeonInfo.Definition.Key.chanceOfQuarentine > 0)
			{
				dungeonInfo.IsQuarentined = UnityEngine.Random.Range(0, 100) < dungeonInfo.Definition.Key.chanceOfQuarentine;
			}
			break;
		}
		case DungeonTypeEnum.AutoTrade:
		{
			TradingPostInfo tradingPostInfo = new TradingPostInfo(starSystemInfo, nextID);
			tradingPostInfo.DungeonType = dungeonType;
			dungeonInfo = tradingPostInfo;
			dungeonInfo.Definition = new KeyValuePair<DungeonConfigurationManager.DungeonHelper.DungeonDefinition, DungeonConfigurationManager.DungeonHelper.DungeonClassDefinition>(new DungeonConfigurationManager.DungeonHelper.DungeonDefinition("Trading Post", DungeonTypeEnum.AutoTrade), null);
			break;
		}
		case DungeonTypeEnum.Stargate:
		{
			DungeonInfo dungeonInfo2 = new DungeonInfo(starSystemInfo, nextID);
			dungeonInfo2.DungeonType = dungeonType;
			dungeonInfo = dungeonInfo2;
			break;
		}
		default:
			Debug.LogError(string.Format("Invalid dungeon type!!!! {0}", dungeonType));
			dungeonInfo = new DungeonInfo(null, 0);
			break;
		}
		if (dungeonInfo.OriginalDifficultyMin < 0f)
		{
			dungeonInfo.OriginalDifficultyMin = starSystemInfo.DifficultyMin;
		}
		if (dungeonInfo.OriginalDifficultyMax < 0f)
		{
			dungeonInfo.OriginalDifficultyMax = starSystemInfo.DifficultyMax;
		}
		dungeonInfo.SetDifficulty(UnityEngine.Random.Range(dungeonInfo.OriginalDifficultyMin, dungeonInfo.OriginalDifficultyMax));
		if (dungeonType == DungeonTypeEnum.AutoTrade || dungeonType == DungeonTypeEnum.Stargate)
		{
			dungeonInfo.ClearInfestationType();
		}
		float num = 1f / 3f;
		dungeonInfo.HullIntegrity = (HullIntegrity)(dungeonInfo.CalculatedDifficultyValues.HullIntegrityValue / num);
		dungeonInfo.HaveVisited = GalaxySaveFile.Get(dungeonInfo.GroupKey, "VISITED", false);
		Vector3 randomCoords = Vector3.zero;
		if (starSystemInfo != null && starSystemInfo.Dungeons != null)
		{
			int num2 = 0;
			bool flag;
			do
			{
				float x = UnityEngine.Random.Range(-250f, 250f);
				float y = UnityEngine.Random.Range(-150f, 150f);
				randomCoords = new Vector3(x, y, 0f);
				flag = starSystemInfo.Dungeons.Any((DungeonInfo dungeonInfo3) => Vector3.Distance(randomCoords, dungeonInfo3.Coordinates) < 75f);
			}
			while (num2++ <= 100 && flag);
		}
		dungeonInfo.Coordinates = randomCoords;
		return dungeonInfo;
	}

	public static DungeonInfo BuildNurseryDungeon(int seed, DungeonTypeEnum dungeonType, StarSystemInfo starSystemInfo, int nextID, int earlyPlayIdx)
	{
		UnityEngine.Random.seed = seed;
		DungeonInfo dungeonInfo = null;
		float earlyPlayDistMin = 100f;
		float num = 150f;
		DungeonConfigurationManager.EarlyPlayConfiguration[] earlyPlayDifficultyValues = DungeonConfigurationManager.GetEarlyPlayDifficultyValues();
		switch (dungeonType)
		{
		case DungeonTypeEnum.Derelict:
		case DungeonTypeEnum.Station:
		{
			if (GameSaveFile.Get("GAME_VER", 0f) > 0f && GameSaveFile.Get("GAME_VER", 0f) <= 0.292f)
			{
				dungeonType = DungeonTypeEnum.Derelict;
			}
			DungeonInfo dungeonInfo2 = new DungeonInfo(starSystemInfo, nextID);
			dungeonInfo2.DungeonType = dungeonType;
			dungeonInfo = dungeonInfo2;
			dungeonInfo.Definition = DungeonConfigurationManager.DungeonHelper.GetRandomEarlyPlayShipClass(earlyPlayDifficultyValues[earlyPlayIdx].ShipTypes);
			dungeonInfo.SceneName = "DungeonScene_Generated_Pro";
			break;
		}
		case DungeonTypeEnum.Outpost:
		{
			DungeonInfo dungeonInfo2 = new DungeonInfo(starSystemInfo, nextID);
			dungeonInfo2.DungeonType = dungeonType;
			dungeonInfo = dungeonInfo2;
			dungeonInfo.Definition = DungeonConfigurationManager.DungeonHelper.GetRandomOutpostClass();
			dungeonInfo.HideDisplayCount = UnityEngine.Random.Range(0, 5) == 0;
			dungeonInfo.SceneName = "DungeonScene_Generated_Pro";
			break;
		}
		case DungeonTypeEnum.AutoTrade:
		{
			TradingPostInfo tradingPostInfo = new TradingPostInfo(starSystemInfo, nextID);
			tradingPostInfo.DungeonType = dungeonType;
			dungeonInfo = tradingPostInfo;
			dungeonInfo.Definition = new KeyValuePair<DungeonConfigurationManager.DungeonHelper.DungeonDefinition, DungeonConfigurationManager.DungeonHelper.DungeonClassDefinition>(new DungeonConfigurationManager.DungeonHelper.DungeonDefinition("Trading Post", DungeonTypeEnum.AutoTrade), null);
			break;
		}
		case DungeonTypeEnum.Stargate:
		{
			DungeonInfo dungeonInfo2 = new DungeonInfo(starSystemInfo, nextID);
			dungeonInfo2.DungeonType = dungeonType;
			dungeonInfo = dungeonInfo2;
			break;
		}
		default:
			Debug.LogError(string.Format("Invalid dungeon type!!!! {0}", dungeonType));
			dungeonInfo = new DungeonInfo(null, 0);
			break;
		}
		dungeonInfo.SetEarlyPlayProperties(earlyPlayDifficultyValues[earlyPlayIdx]);
		float num2 = 0f;
		if (dungeonType == DungeonTypeEnum.AutoTrade || dungeonType == DungeonTypeEnum.Stargate)
		{
			dungeonInfo.ClearInfestationType();
		}
		if (!dungeonInfo.IsDesignedShip)
		{
			num2 = 1f / 3f;
			dungeonInfo.HullIntegrity = (HullIntegrity)(dungeonInfo.CalculatedDifficultyValues.HullIntegrityValue / num2);
		}
		else
		{
			switch (GlobalSettings.GameState.ThePlayer.CurrentDockedDungeon.GetMetaData("hulltype"))
			{
			case "0":
				dungeonInfo.HullIntegrity = HullIntegrity.Good;
				break;
			case "1":
				dungeonInfo.HullIntegrity = HullIntegrity.Medium;
				break;
			case "2":
				dungeonInfo.HullIntegrity = HullIntegrity.Poor;
				break;
			}
		}
		dungeonInfo.HaveVisited = GalaxySaveFile.Get(dungeonInfo.GroupKey, "VISITED", false);
		Vector3 randomCoords = Vector3.zero;
		GalaxySaveFile.Save(dungeonInfo.GroupKey, "SD", true);
		GalaxySaveFile.Save(dungeonInfo.GroupKey, "EPIDX", earlyPlayIdx);
		if (starSystemInfo != null && starSystemInfo.Dungeons != null)
		{
			if (earlyPlayIdx == 0)
			{
				int num3 = 0;
				bool flag;
				do
				{
					float x = UnityEngine.Random.Range(-250f, 250f);
					float y = UnityEngine.Random.Range(-150f, 150f);
					randomCoords = new Vector3(x, y, 0f);
					flag = starSystemInfo.Dungeons.Any((DungeonInfo dungeonInfo3) => Vector3.Distance(randomCoords, dungeonInfo3.Coordinates) < 75f);
				}
				while (num3++ <= 100 && flag);
			}
			else
			{
				Vector3 coordinates = starSystemInfo.Dungeons[earlyPlayIdx - 1].Coordinates;
				int num4 = 0;
				bool flag2;
				do
				{
					float x2 = UnityEngine.Random.Range(-1f, 1f);
					float y2 = UnityEngine.Random.Range(-1f, 1f);
					Vector3 zero = Vector3.zero;
					zero.x = x2;
					zero.y = y2;
					zero.Normalize();
					randomCoords = coordinates + zero * UnityEngine.Random.Range(earlyPlayDistMin, num);
					flag2 = !(randomCoords.x >= -250f) || !(randomCoords.x < 250f) || !(randomCoords.y >= -150f) || !(randomCoords.y <= 150f) || starSystemInfo.Dungeons.Any((DungeonInfo dungeonInfo3) => Vector3.Distance(randomCoords, dungeonInfo3.Coordinates) < earlyPlayDistMin);
				}
				while (num4++ <= 100 && flag2);
				earlyPlayDistMin += 75f;
				num += 75f;
			}
		}
		dungeonInfo.Coordinates = randomCoords;
		return dungeonInfo;
	}

	private static DungeonInfo BuildNurseryDungeonData(int seed, int earlyPlayIdx)
	{
		UnityEngine.Random.seed = seed;
		DungeonInfo dungeonInfo = null;
		DungeonConfigurationManager.EarlyPlayConfiguration[] earlyPlayDifficultyValues = DungeonConfigurationManager.GetEarlyPlayDifficultyValues();
		DungeonInfo dungeonInfo2 = new DungeonInfo(null, 0);
		dungeonInfo2.TempFlagAsNursery = true;
		dungeonInfo2.DungeonType = DungeonTypeEnum.Derelict;
		dungeonInfo = dungeonInfo2;
		dungeonInfo.SetEarlyPlayProperties(earlyPlayDifficultyValues[earlyPlayIdx]);
		UniverseSaveFile.Save(dungeonInfo.GroupKey, "SD", true);
		UniverseSaveFile.Save(dungeonInfo.GroupKey, "EPIDX", earlyPlayIdx);
		UniverseSaveFile.Save(dungeonInfo.GroupKey, "SEED_D", seed);
		UniverseSaveFile.Save(dungeonInfo.GroupKey, "VISITED", false);
		return dungeonInfo;
	}

	public static void GenerateNurseryDungeonsForData()
	{
		UniverseSaveFile.BeginBatch();
		UnityEngine.Random.seed = (int)DateTime.Now.Ticks;
		UniverseSaveFile.Save("SYS_NURSERY", "SEED", UnityEngine.Random.seed);
		int num = UniverseSaveFile.Get<int>("LAST_SHIP_ID");
		if (num > 0)
		{
			GlobalSettings.GameState.NextDungeonId = num;
		}
		else
		{
			GlobalSettings.GameState.NextDungeonId = 1;
		}
		if (GlobalSettings.GameState.NextDungeonId == 0)
		{
			GlobalSettings.GameState.NextDungeonId = 1;
		}
		List<DungeonInfo> list = new List<DungeonInfo>();
		for (int i = 0; i < 4; i++)
		{
			int seed = UnityEngine.Random.seed;
			DungeonInfo dungeonInfo = BuildNurseryDungeonData(seed, i);
			dungeonInfo.Name = NameGenerator.NextDerelictName();
			dungeonInfo.HaveVisited = false;
			list.Add(dungeonInfo);
			UniverseSaveFile.Save(dungeonInfo.GroupKey, "P", "SYS_NURSERY");
		}
		foreach (DungeonInfo item in list)
		{
			if (!item.IsDesignedShip)
			{
				item.ClearInfestationType();
				if (item.EarlyPlayProperties.EnemyTypes != null)
				{
					ShipInfestationType[] enemyTypes = item.EarlyPlayProperties.EnemyTypes;
					foreach (ShipInfestationType infestationType in enemyTypes)
					{
						item.AddInfestationType(infestationType);
					}
				}
				continue;
			}
			foreach (IGEObject designedBoardObject in item.designedBoardObjects)
			{
				if (designedBoardObject.objectType != GEObjectTypeEnum.Room)
				{
					continue;
				}
				string metaDataValue = designedBoardObject.GetMetaDataValue("enemy");
				if (!(metaDataValue != "0"))
				{
					continue;
				}
				switch (metaDataValue)
				{
				case "1":
					if (item.InfestationType == null || !item.InfestationType.Contains(ShipInfestationType.PatrolBot))
					{
						item.AddInfestationType(ShipInfestationType.PatrolBot);
					}
					break;
				case "2":
					if (item.InfestationType == null || !item.InfestationType.Contains(ShipInfestationType.Swarm))
					{
						item.AddInfestationType(ShipInfestationType.Swarm);
					}
					break;
				case "3":
					if (item.InfestationType == null || !item.InfestationType.Contains(ShipInfestationType.Brute))
					{
						item.AddInfestationType(ShipInfestationType.Brute);
					}
					break;
				case "4":
					if (item.InfestationType == null || !item.InfestationType.Contains(ShipInfestationType.Slime))
					{
						item.AddInfestationType(ShipInfestationType.Slime);
					}
					break;
				}
			}
		}
		UniverseSaveFile.EndBatch();
		UniverseSaveFile.BeginBatch();
		List<string> allGroups = UniverseSaveFile.GetAllGroups("OBJN_");
		foreach (string item2 in allGroups)
		{
			List<KeyValuePair<string, string>> groupDataItems = UniverseSaveFile.GetGroupDataItems(item2);
			foreach (KeyValuePair<string, string> item3 in groupDataItems)
			{
				UniverseSaveFile.Save("COPY_" + item2, item3.Key, item3.Value);
			}
		}
		UniverseSaveFile.EndBatch();
	}

	public static void RevertNurseryFromCopy()
	{
		List<string> allGroups = UniverseSaveFile.GetAllGroups("OBJN_");
		foreach (string item in allGroups)
		{
			UniverseSaveFile.ClearGroup(item);
		}
		allGroups = UniverseSaveFile.GetAllGroups("COPY_OBJN_");
		int count = allGroups.Count;
		for (int num = count - 1; num >= 0; num--)
		{
			foreach (string item2 in allGroups)
			{
				if (UniverseSaveFile.Get(item2, "EPIDX", -1) != num)
				{
					continue;
				}
				List<KeyValuePair<string, string>> groupDataItems = UniverseSaveFile.GetGroupDataItems(item2);
				foreach (KeyValuePair<string, string> item3 in groupDataItems)
				{
					UniverseSaveFile.Save(item2.Replace("COPY_", string.Empty), item3.Key, item3.Value);
				}
			}
		}
	}

	public static void GenerateNurseryDungeonsFromData(StarSystemInfo starSystemInfo)
	{
		List<string> allGroups = UniverseSaveFile.GetAllGroups("OBJN_", "P", "SYS_NURSERY");
		starSystemInfo.Dungeons = new List<DungeonInfo>();
		DungeonConfigurationManager.EarlyPlayConfiguration[] earlyPlayDifficultyValues = DungeonConfigurationManager.GetEarlyPlayDifficultyValues();
		foreach (string item in allGroups)
		{
			string text = item.Replace("OBJN_", "OBJ_");
			List<KeyValuePair<string, string>> groupDataItems = UniverseSaveFile.GetGroupDataItems(item);
			foreach (KeyValuePair<string, string> item2 in groupDataItems)
			{
				GalaxySaveFile.Save(text, item2.Key, item2.Value);
			}
			GalaxySaveFile.Save(text, "P", starSystemInfo.GroupKey);
			int seed = GalaxySaveFile.Get(text, "SEED_D", -1);
			UnityEngine.Random.seed = seed;
			int num = GalaxySaveFile.Get(text, "EPIDX", -1);
			int id = GlobalSettings.GameState.NextDungeonId++;
			string[] array = text.Split('_');
			int result = -1;
			int.TryParse(array[1], out result);
			DungeonInfo dungeonInfo = new DungeonInfo(starSystemInfo, id, result);
			dungeonInfo.SceneName = "DungeonScene_Generated_Pro";
			dungeonInfo.SetEarlyPlayProperties(earlyPlayDifficultyValues[num]);
			if (!dungeonInfo.IsDesignedShip)
			{
				dungeonInfo.Definition = DungeonConfigurationManager.DungeonHelper.GetRandomEarlyPlayShipClass(dungeonInfo.EarlyPlayProperties.ShipTypes);
				float num2 = 1f / 3f;
				dungeonInfo.HullIntegrity = (HullIntegrity)(dungeonInfo.CalculatedDifficultyValues.HullIntegrityValue / num2);
			}
			else
			{
				string metaData = dungeonInfo.GetMetaData("duntype");
				string metaData2 = dungeonInfo.GetMetaData("classtype");
				if (metaData != "0")
				{
					dungeonInfo.Definition = DungeonConfigurationManager.DungeonHelper.GetDungeonDefinition(DungeonTypeEnum.Derelict, metaData, metaData2);
				}
				else
				{
					dungeonInfo.Definition = DungeonConfigurationManager.DungeonHelper.GetRandomEarlyPlayShipClass(dungeonInfo.EarlyPlayProperties.ShipTypes);
				}
				switch (dungeonInfo.GetMetaData("hulltype"))
				{
				case "0":
					dungeonInfo.HullIntegrity = HullIntegrity.Good;
					break;
				case "1":
					dungeonInfo.HullIntegrity = HullIntegrity.Medium;
					break;
				case "2":
					dungeonInfo.HullIntegrity = HullIntegrity.Poor;
					break;
				}
			}
			dungeonInfo.HaveVisited = GalaxySaveFile.Get(dungeonInfo.GroupKey, "VISITED", false);
			string text2 = UniverseSaveFile.Get(item, "ITYPE", string.Empty);
			if (!string.IsNullOrEmpty(text2))
			{
				string[] array2 = text2.Split(',');
				string[] array3 = array2;
				foreach (string text3 in array3)
				{
					try
					{
						ShipInfestationType infestationType = (ShipInfestationType)(int)Enum.Parse(typeof(ShipInfestationType), text3, false);
						dungeonInfo.AddInfestationType(infestationType);
					}
					catch (Exception ex)
					{
						Debug.LogError(string.Format("Invalid infection type found in the data: {0}\r\nException: {1}", text3, ex.Message));
					}
				}
			}
			starSystemInfo.Dungeons.Add(dungeonInfo);
			float earlyPlayDistMin = 100f;
			float num3 = 150f;
			Vector3 randomCoords = Vector3.zero;
			if (num == 0)
			{
				int num4 = 0;
				bool flag;
				do
				{
					float x = UnityEngine.Random.Range(-250f, 250f);
					float y = UnityEngine.Random.Range(-150f, 150f);
					randomCoords = new Vector3(x, y, 0f);
					flag = starSystemInfo.Dungeons.Any((DungeonInfo dungeonInfo2) => Vector3.Distance(randomCoords, dungeonInfo2.Coordinates) < 75f);
				}
				while (num4++ <= 100 && flag);
			}
			else if (num > 0)
			{
				Vector3 coordinates = starSystemInfo.Dungeons[num - 1].Coordinates;
				int num5 = 0;
				bool flag2;
				do
				{
					float x2 = UnityEngine.Random.Range(-1f, 1f);
					float y2 = UnityEngine.Random.Range(-1f, 1f);
					Vector3 zero = Vector3.zero;
					zero.x = x2;
					zero.y = y2;
					zero.Normalize();
					randomCoords = coordinates + zero * UnityEngine.Random.Range(earlyPlayDistMin, num3);
					flag2 = !(randomCoords.x >= -250f) || !(randomCoords.x < 250f) || !(randomCoords.y >= -150f) || !(randomCoords.y <= 150f) || starSystemInfo.Dungeons.Any((DungeonInfo dungeonInfo2) => Vector3.Distance(randomCoords, dungeonInfo2.Coordinates) < earlyPlayDistMin);
				}
				while (num5++ <= 100 && flag2);
				earlyPlayDistMin += 75f;
				num3 += 75f;
			}
			dungeonInfo.Coordinates = randomCoords;
		}
	}

	public static void ClearUnloackedInfectionTypeList()
	{
		if (unlockedInfestationTypes != null)
		{
			unlockedInfestationTypes.Clear();
		}
	}

	public static void LoadUnlockedInfestationTypeList()
	{
		if (unlockedInfestationTypes != null && unlockedInfestationTypes.Count > 0)
		{
			return;
		}
		if (unlockedInfestationTypes == null)
		{
			unlockedInfestationTypes = new List<ShipInfestationType>();
		}
		else
		{
			unlockedInfestationTypes.Clear();
		}
		List<string> list = null;
		list = ((!(GameSaveFile.Get("GAME_VER", 1.041f) <= 0.0302f)) ? GameSaveFile.GetAllGroups("EN_", "P", "GSTATE") : UniverseSaveFile.GetAllGroups("EN_", "P", "GSTATE"));
		foreach (string item2 in list)
		{
			string[] array = item2.Split(new char[1] { '_' }, StringSplitOptions.RemoveEmptyEntries);
			if (array.Length == 2)
			{
				ShipInfestationType item = (ShipInfestationType)(int)Enum.Parse(typeof(ShipInfestationType), array[1]);
				bool flag = false;
				if (GameSaveFile.Get("GAME_VER", 1.041f) <= 0.0302f)
				{
					if (UniverseSaveFile.Get(item2, "STATE", 1) == 1)
					{
						flag = true;
					}
				}
				else if (GameSaveFile.Get(item2, "STATE", 1) == 1)
				{
					flag = true;
				}
				if (flag)
				{
					unlockedInfestationTypes.Add(item);
				}
			}
			else
			{
				Debug.LogWarning(string.Format("Invalid enemy game state key found: {0}.  Expected format: EN_XXXXX", item2));
			}
		}
	}

	public static void UnlockNextInfestationType()
	{
		int highestUnlockedInfectionType = GetHighestUnlockedInfectionType();
		if (highestUnlockedInfectionType < 4)
		{
			ShipInfestationType shipInfestationType = ShipInfestationType.None;
			switch (highestUnlockedInfectionType)
			{
			case 0:
				shipInfestationType = ShipInfestationType.PatrolBot;
				break;
			case 1:
				shipInfestationType = ShipInfestationType.Brute;
				break;
			case 2:
				shipInfestationType = ShipInfestationType.Swarm;
				break;
			case 3:
				shipInfestationType = ShipInfestationType.Slime;
				break;
			}
			if (shipInfestationType == ShipInfestationType.None)
			{
				int num = 0;
				num++;
			}
			unlockedInfestationTypes.Add(shipInfestationType);
			if (GameSaveFile.Get("GAME_VER", 1.041f) <= 0.0302f)
			{
				UniverseSaveFile.Save(string.Format("EN_{0}", shipInfestationType), "P", "GSTATE");
				UniverseSaveFile.Save(string.Format("EN_{0}", shipInfestationType), "STATE", 1);
			}
			else
			{
				GameSaveFile.Save(string.Format("EN_{0}", shipInfestationType), "P", "GSTATE");
				GameSaveFile.Save(string.Format("EN_{0}", shipInfestationType), "STATE", 1);
			}
		}
	}

	public static int GetHighestUnlockedInfectionType()
	{
		int result = 0;
		if (unlockedInfestationTypes.Any((ShipInfestationType x) => x == ShipInfestationType.Slime))
		{
			result = 4;
		}
		else if (unlockedInfestationTypes.Any((ShipInfestationType x) => x == ShipInfestationType.Swarm))
		{
			result = 3;
		}
		else if (unlockedInfestationTypes.Any((ShipInfestationType x) => x == ShipInfestationType.Brute))
		{
			result = 2;
		}
		else if (unlockedInfestationTypes.Any((ShipInfestationType x) => x == ShipInfestationType.PatrolBot))
		{
			result = 1;
		}
		return result;
	}

	public static List<ShipInfestationType> RandomPickInfestationTypes(int numberOfTypes, List<ShipInfestationType> infestationTypeChoices)
	{
		ShipInfestationType[] collection = infestationTypeChoices.ToArray();
		List<ShipInfestationType> list = new List<ShipInfestationType>(collection);
		List<ShipInfestationType> list2 = new List<ShipInfestationType>();
		if (infestationTypeChoices.Count < numberOfTypes)
		{
			numberOfTypes = infestationTypeChoices.Count;
		}
		bool flag = false;
		while (!flag && list2.Count < numberOfTypes)
		{
			int index = UnityEngine.Random.Range(0, list.Count);
			list2.Add(list[index]);
			list.RemoveAt(index);
		}
		return list2;
	}

	public static List<ShipInfestationType> RandomPickInfestationTypesWeighted(int numberOfTypes, List<ShipInfestationType> infestationTypeChoices, List<int> weightList, int totalWeight)
	{
		ShipInfestationType[] collection = infestationTypeChoices.ToArray();
		List<ShipInfestationType> list = new List<ShipInfestationType>(collection);
		List<ShipInfestationType> list2 = new List<ShipInfestationType>();
		if (infestationTypeChoices.Count < numberOfTypes)
		{
			numberOfTypes = infestationTypeChoices.Count;
		}
		bool flag = false;
		while (!flag && list2.Count < numberOfTypes)
		{
			int num = -1;
			int num2 = UnityEngine.Random.Range(0, totalWeight);
			int count = list.Count;
			for (int i = 0; i < count; i++)
			{
				if (num2 >= weightList[i])
				{
					continue;
				}
				num = i;
				List<int> list3 = new List<int>(weightList.Count);
				for (int j = 0; j < weightList.Count; j++)
				{
					list3.Add(weightList[j]);
				}
				int num3 = weightList[i];
				if (weightList.Count - 1 > i)
				{
					int count2 = weightList.Count;
					for (int k = i + 1; k < count2; k++)
					{
						weightList[k] = list3[k] - list3[k - 1];
						if (k - 1 >= i + 1)
						{
							weightList[k] = weightList[k - 1] + weightList[k];
						}
					}
				}
				weightList.RemoveAt(i);
				if (weightList.Count > 0)
				{
					totalWeight = weightList[weightList.Count - 1];
				}
				break;
			}
			if (num > -1)
			{
				list2.Add(list[num]);
				list.RemoveAt(num);
				continue;
			}
			int num4 = 0;
			num4++;
			break;
		}
		return list2;
	}

	public static void DetermineStargateStarSystems(UniverseNode node, List<StarSystemInfo> galaxyStarSystems, int galaxySeed)
	{
		if (node == null)
		{
			return;
		}
		UnityEngine.Random.seed = galaxySeed;
		int countNodes = node.CountNodes;
		if (countNodes > 0)
		{
			List<UniverseNode> allConnectionNodes = node.GetAllConnectionNodes();
			IEnumerable<StarSystemInfo> source = galaxyStarSystems.Where((StarSystemInfo x) => x != null && !x.IsNursery);
			List<StarSystemInfo> list = source.ToList();
			int count = list.Count;
			do
			{
				if (list.Count == 0)
				{
					if (galaxyStarSystems != null)
					{
						Debug.LogError(string.Format("ID: {3} - This star system required more stargates ({0}) than it had non-nursery star systems remaining.  There were {1} systems when starting, but all have been given one.  This system as a total of {2} systems.  This failure means at least one star gate will not find an outbound gate when jumping into this system!", countNodes, count, galaxyStarSystems.Count, node.GroupKey));
					}
					else
					{
						Debug.LogError(string.Format("ID: {3} - This star system required more stargates ({0}) than it had non-nursery star systems remaining.  There were {1} systems when starting, but all have been given one.  This system as a total of {2} systems.  This failure means at least one star gate will not find an outbound gate when jumping into this system!", countNodes, count, 9999, node.GroupKey));
					}
					break;
				}
				int index = UnityEngine.Random.Range(0, list.Count);
				StarSystemInfo starSystemInfo = list[index];
				list.RemoveAt(index);
				starSystemInfo.HasStargate = true;
				index = UnityEngine.Random.Range(0, allConnectionNodes.Count);
				if (allConnectionNodes[index] == node.parent)
				{
					starSystemInfo.IsChildGate = true;
					starSystemInfo.StargateConnection = node.edgeToParent;
				}
				else
				{
					starSystemInfo.StargateConnection = allConnectionNodes[index].edgeToParent;
				}
				allConnectionNodes.RemoveAt(index);
			}
			while (allConnectionNodes.Count > 0);
		}
		else
		{
			Debug.LogWarning("No connections on current universe node!  Should be impossible...");
		}
		if (GlobalSettings.gameMode == GameModeEnum.Normal)
		{
			UnityEngine.Random.seed = (int)DateTime.Now.Ticks;
		}
	}

	public static void BuildStargatesFromData(List<StarSystemInfo> galaxyStarSystems)
	{
		List<string> allGroups = GalaxySaveFile.GetAllGroups("SYS_", "SG", true);
		List<UniverseNode> allChildrenNodes = universeMapManager.CurrentUniverseNode.GetAllChildrenNodes();
		List<UniverseNode.ConnectionEdge> list = new List<UniverseNode.ConnectionEdge>();
		if (universeMapManager.CurrentUniverseNode.edgeToParent != null)
		{
			list.Add(universeMapManager.CurrentUniverseNode.edgeToParent);
		}
		foreach (UniverseNode item in allChildrenNodes)
		{
			if (item.edgeToParent != null)
			{
				list.Add(item.edgeToParent);
			}
		}
		foreach (string groupKey in allGroups)
		{
			StarSystemInfo starSystemInfo = galaxyStarSystems.FirstOrDefault((StarSystemInfo x) => x.GroupKey == groupKey);
			string edgeGroupKey = GalaxySaveFile.Get(groupKey, "GXE_P", string.Empty);
			UniverseNode.ConnectionEdge connectionEdge = list.FirstOrDefault((UniverseNode.ConnectionEdge x) => x.GroupKey == edgeGroupKey);
			if (starSystemInfo != null && connectionEdge != null)
			{
				starSystemInfo.StargateConnection = connectionEdge;
				continue;
			}
			if (starSystemInfo == null)
			{
				Debug.LogError(string.Format("BuildStargatesFromData: Did not find a system with the group id of {0}.  This should be impossible, since we got the group list directly from the current data - this is a bug in the code or the data has become corrupted", groupKey));
			}
			if (connectionEdge == null)
			{
				if (starSystemInfo == null)
				{
					Debug.LogError(string.Format("BuildStargatesFromData: Couldn't find an edge in the UniverseSaveFile with the groupKey of '{0}'.  Wasn't able to build this stargate, and a null exception will happen if the player access it.  The system was ALSO null, which is probably part of the problem.", edgeGroupKey));
				}
				else if (GlobalSettings.gameMode == GameModeEnum.Normal)
				{
					Debug.LogError(string.Format("BuildStargatesFromData: Couldn't find an edge in the UniverseSaveFile with the groupKey of '{0}'.  Wasn't able to build this stargate, and a null exception will happen if the player access it.  The system: {1}", edgeGroupKey, starSystemInfo.GroupKey));
				}
			}
		}
	}

	public static List<StarSystemInfo> FilterStarSystemByDifficulty(float minDifficulty, float maxDifficulty, int minMatches, bool findClosestIfNone, out int numberMatchesInOriginalRange, out float minDifficultyBestMatch, out float maxDifficultyBestMatch)
	{
		List<StarSystemInfo> result = null;
		minDifficultyBestMatch = -1f;
		maxDifficultyBestMatch = -1f;
		numberMatchesInOriginalRange = 0;
		IEnumerable<StarSystemInfo> enumerable = GlobalSettings.GameState.StarSystems.Where((StarSystemInfo x) => x != null && x.DifficultyMin >= minDifficulty && x.DifficultyMax <= maxDifficulty);
		int num = 0;
		if (enumerable != null)
		{
			numberMatchesInOriginalRange = enumerable.Count();
		}
		if ((enumerable == null || enumerable.Count() == 0 || enumerable.Count() < minMatches) && findClosestIfNone)
		{
			int num2 = 0;
			int num3 = 0;
			do
			{
				num2 = num3;
				float num4 = maxDifficulty - minDifficulty;
				minDifficultyBestMatch = float.MaxValue;
				maxDifficultyBestMatch = float.MaxValue;
				foreach (StarSystemInfo starSystem in GlobalSettings.GameState.StarSystems)
				{
					float num5 = 0f;
					num5 = Mathf.Abs(starSystem.DifficultyMin - minDifficulty);
					if (num5 < minDifficultyBestMatch)
					{
						minDifficultyBestMatch = starSystem.DifficultyMin;
					}
				}
				float num6 = minDifficultyBestMatch + num4;
				if (num6 < maxDifficulty)
				{
					num6 = maxDifficulty;
				}
				foreach (StarSystemInfo starSystem2 in GlobalSettings.GameState.StarSystems)
				{
					float num7 = 0f;
					if (starSystem2.DifficultyMax >= num6)
					{
						num7 = starSystem2.DifficultyMax - maxDifficulty;
						if (num7 < maxDifficultyBestMatch)
						{
							maxDifficultyBestMatch = starSystem2.DifficultyMax;
						}
					}
				}
				if (maxDifficultyBestMatch > 1f)
				{
					maxDifficultyBestMatch = 1f;
				}
				if (minMatches > 0)
				{
					float newMinDif = minDifficultyBestMatch;
					float newMaxDif = maxDifficultyBestMatch;
					enumerable = GlobalSettings.GameState.StarSystems.Where((StarSystemInfo x) => x != null && x.DifficultyMin >= newMinDif && x.DifficultyMax <= newMaxDif);
					num3 = ((enumerable != null) ? enumerable.Count() : 0);
					minDifficulty = newMinDif;
					maxDifficulty = newMaxDif;
					Debug.Log(string.Format("Expanded range to {0}-{1}, and found {2} nodes", newMinDif, newMaxDif, num3));
					if (minDifficulty - 1E-06f >= 0f)
					{
						minDifficulty -= 1E-06f;
					}
					if (maxDifficulty + 1E-06f <= 1f)
					{
						maxDifficulty += 1E-06f;
					}
				}
				num++;
			}
			while (minMatches != 0 && num3 < minMatches && num < GlobalSettings.GameState.StarSystems.Count);
			if (num >= GlobalSettings.GameState.StarSystems.Count)
			{
				Debug.LogWarning(string.Format("Gave up trying to filter star systems by difficulty.  After {0} passes, wasn't able to find a range of difficulties that encompased the specified minimum number of systems of {1}.  Returning NO systems", num, minMatches));
			}
		}
		else
		{
			result = enumerable.ToList();
		}
		return result;
	}

	public static bool IsValidStartingStarSystem(StarSystemInfo starSystem)
	{
		if (starSystem.NumberOfDungeons >= 2)
		{
			if (GalaxySaveFile.Exists(starSystem.GroupKey))
			{
				List<string> allGroups = GalaxySaveFile.GetAllGroups("OBJ", "P", starSystem.GroupKey);
				int num = 0;
				if (allGroups.Count > 0)
				{
					foreach (string item in allGroups)
					{
						if (!GalaxySaveFile.Get(item, "VISITED", false))
						{
							num++;
							if (num >= 2)
							{
								break;
							}
						}
					}
				}
				else
				{
					num = starSystem.NumberOfDungeons;
				}
				if (num < 2)
				{
					return false;
				}
			}
			if (GalaxyMapManager.depthMapSourceTexture.GetPixel((int)starSystem.TrueImageCoords.x, (int)starSystem.TrueImageCoords.y).r <= 0.6f)
			{
				return false;
			}
			return true;
		}
		return false;
	}

	public static List<StarSystemInfo> FilterStarSystemsByPotentialHops(int minHops, List<StarSystemInfo> sourceList, out int bestHopCount)
	{
		bestHopCount = 0;
		List<StarSystemInfo> list = null;
		IEnumerable<StarSystemInfo> source = sourceList.Where(IsValidStartingStarSystem);
		IEnumerable<StarSystemInfo> starSystems = GlobalSettings.GameState.StarSystems;
		if (source.Count() > 0)
		{
			List<StarSystemInfo> list2 = source.ToList();
			List<StarSystemInfo> validStarSystems = starSystems.ToList();
			List<StarSystemInfo> list3 = new List<StarSystemInfo>(list2.Count);
			foreach (StarSystemInfo item in list2)
			{
				list3.Clear();
				int longestHopCountFromStarSystemRecursive = GetLongestHopCountFromStarSystemRecursive(item, validStarSystems, list3);
				if (longestHopCountFromStarSystemRecursive >= minHops)
				{
					if (list == null)
					{
						list = new List<StarSystemInfo>();
					}
					list.Add(item);
				}
				if (longestHopCountFromStarSystemRecursive > bestHopCount)
				{
					bestHopCount = longestHopCountFromStarSystemRecursive;
				}
			}
		}
		return list;
	}

	private static int GetLongestHopCountFromStarSystemRecursive(StarSystemInfo startingStarSystem, List<StarSystemInfo> validStarSystems, List<StarSystemInfo> visitedSystems)
	{
		int result = 0;
		if (!visitedSystems.Contains(startingStarSystem))
		{
			visitedSystems.Add(startingStarSystem);
			IEnumerable<StarSystemInfo> enumerable = validStarSystems.Where((StarSystemInfo x) => x != null && !visitedSystems.Contains(x) && Mathf.CeilToInt(Vector3.Distance(x.Coordinates, startingStarSystem.Coordinates) / 7.5f) <= 14);
			int num = 0;
			if (enumerable != null && enumerable.Count() > 0)
			{
				List<StarSystemInfo> list = enumerable.ToList();
				foreach (StarSystemInfo item in list)
				{
					int longestHopCountFromStarSystemRecursive = GetLongestHopCountFromStarSystemRecursive(item, validStarSystems, visitedSystems);
					if (longestHopCountFromStarSystemRecursive > 0 && longestHopCountFromStarSystemRecursive > num)
					{
						num = longestHopCountFromStarSystemRecursive;
					}
				}
			}
			result = 1 + num;
		}
		return result;
	}

	public static bool CanReachStargateInCurrentGalaxy(List<StarSystemInfo> qualifiedSystemList)
	{
		IEnumerable<StarSystemInfo> source = GlobalSettings.GameState.StarSystems.Where((StarSystemInfo x) => x != null && x.HasStargate);
		if (source.Count() > 0)
		{
			List<StarSystemInfo> list = source.ToList();
			List<StarSystemInfo> list2 = new List<StarSystemInfo>();
			int num = 0;
			foreach (StarSystemInfo qualifiedSystem in qualifiedSystemList)
			{
				list2.Clear();
				if (qualifiedSystem.HasStargate)
				{
					num++;
					continue;
				}
				if (CanReachStargateRecursive(qualifiedSystem, GlobalSettings.GameState.StarSystems, list2))
				{
					num++;
					continue;
				}
				int num2 = 0;
				num2++;
			}
			if (num == qualifiedSystemList.Count)
			{
				return true;
			}
		}
		return false;
	}

	private static bool CanReachStargateRecursive(StarSystemInfo startingStarSystem, List<StarSystemInfo> validStarSystems, List<StarSystemInfo> visitedSystems)
	{
		if (!visitedSystems.Contains(startingStarSystem))
		{
			visitedSystems.Add(startingStarSystem);
			IEnumerable<StarSystemInfo> enumerable = validStarSystems.Where((StarSystemInfo x) => x != null && !visitedSystems.Contains(x) && Mathf.CeilToInt(Vector3.Distance(x.Coordinates, startingStarSystem.Coordinates) / 7.5f) <= 14);
			if (enumerable != null && enumerable.Count() > 0)
			{
				List<StarSystemInfo> list = enumerable.ToList();
				foreach (StarSystemInfo item in list)
				{
					if (item.HasStargate)
					{
						return true;
					}
					if (CanReachStargateRecursive(item, validStarSystems, visitedSystems))
					{
						return true;
					}
				}
			}
		}
		return false;
	}
}
