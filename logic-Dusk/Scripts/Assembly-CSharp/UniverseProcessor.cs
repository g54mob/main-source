using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;

public class UniverseProcessor : MonoBehaviour
{
	private enum ProcessingEnum
	{
		None = 0,
		Preparing = 1,
		Processing = 2,
		SpecialProcessing = 3,
		BuildAlphaObjectives = 4,
		BuildScavengerHunt = 5
	}

	public static int SeedDailyChallengeDungeon = -1;

	private bool isFirstFrame = true;

	private float timerUntilFirstFrame = 0.5f;

	private bool isProcessingGalaxies;

	private List<string> galaxyList;

	private int processingIdx;

	private string processingFolderName = string.Empty;

	private ProcessingEnum currentProcessing;

	private List<StarSystemInfo> processingCompleteSystemList;

	private Dictionary<int, List<string>> techDungeonsInUniverse;

	private Dictionary<int, List<string>> predatorSystemsInUniverse;

	private Dictionary<int, List<string>> predatorMilitaryOutpostsInUniverse;

	private Dictionary<int, List<string>> pandemicMedicalShipsInUniverse;

	private DataFile sourceObjectiveFile;

	private Rect messageRect = new Rect(0f, 0f, 0f, 80f);

	private float processingPercent;

	private float percentPerGalaxyBuild;

	private float percentPerGalaxyProcess;

	private float percentForObjectivesProcessing;

	private float percentForSpecialProcessing;

	private float percentForScavengerBuildPass1;

	private float percentForScavengerBuildPass2;

	private float percentForScavengerBuildPass3;

	private System.Random rnd;

	private string[] statusTextMessages = new string[19]
	{
		"Transferring Data...", "Mapping Star System...", "Bringing Systems online...", "Evaluating Data Integrity...", "Re-registering Anomaly...", "Connecting navigation module...", "Projecting stellar orientation...", "Plotting navigational matrix...", "Capacitor warm-up sequence initiated...", "Banking processed data...",
		"Calculating local acceleration...", "Correcting current trajectory...", "Beginning dronebay startup diagnostics", "Switch-gates 1-3 active...", "Detecting local objects...", "Loading banked coordinates...", "Running local diagnostics...", "Assessing LN2 storage levels...", "Repressurizing pod..."
	};

	private float timerNextStatusMessage;

	private int previousLoopSeed = -1;

	private void Start()
	{
		if (!ResourceManager.OneTimeGalaxyLoadPerformed)
		{
			ResourceManager.OneTimeGalaxyResourceLoad();
		}
		LoadingUI.Instance.SetValue(0.05f);
		ShowRandomStatusMessage();
	}

	private void StartLoading()
	{
		StartUniverse();
		CleanUpData();
		GalaxyProcessor.BuildUniverseGalaxies();
		GameFileHelper.EnsureGameFileDirectoriesExist();
		string dataGalaxyLocation = GameFileHelper.GetDataGalaxyLocation();
		StreamWriter streamWriter = File.AppendText(Path.Combine(dataGalaxyLocation, "log.txt"));
		string text = "~map";
		if (GameSaveFile.Get("UNIVERSE_ID", "DEFAULT") != "DEFAULT")
		{
			text += "_ch";
		}
		text += ".txt";
		if (Directory.Exists(dataGalaxyLocation))
		{
			string[] directories = Directory.GetDirectories(dataGalaxyLocation, "*.*", SearchOption.TopDirectoryOnly);
			string[] array = directories;
			foreach (string text2 in array)
			{
				string[] files = Directory.GetFiles(text2, "_mDM.png", SearchOption.TopDirectoryOnly);
				if (files.Length <= 0)
				{
					continue;
				}
				files = Directory.GetFiles(text2, text, SearchOption.TopDirectoryOnly);
				if (files.Length == 0)
				{
					if (galaxyList == null)
					{
						galaxyList = new List<string>();
					}
					galaxyList.Add(text2);
				}
			}
		}
		else
		{
			streamWriter.WriteLine(string.Format("{0}:Destination Galaxy Path Not Found! {1}", DateTime.Now.ToString(), dataGalaxyLocation));
		}
		streamWriter.Close();
		if (galaxyList == null || galaxyList.Count == 0)
		{
			LoadingUI.Instance.SetValue(0.95f);
			ShowRandomStatusMessage();
			LaunchGame();
			return;
		}
		processingIdx = 0;
		LoadingUI.Instance.SetValue(0.05f);
		percentPerGalaxyBuild = 0.4f / (float)galaxyList.Count;
		percentPerGalaxyProcess = 0.4f / (float)galaxyList.Count;
		percentForObjectivesProcessing = 0.1f;
		percentForSpecialProcessing = 0.02f;
		percentForScavengerBuildPass1 = 0.02f;
		percentForScavengerBuildPass2 = 0.005f;
		percentForScavengerBuildPass3 = 0.005f;
		ShowRandomStatusMessage();
		isProcessingGalaxies = true;
	}

	private void StartUniverse()
	{
		if (GalaxyProcessor.universeMapManager == null)
		{
			UniverseMapManager universeMapManager = new UniverseMapManager(false, false);
			universeMapManager.NumberOfGalaxyNodes = ((GlobalSettings.gameMode != GameModeEnum.Normal) ? 1 : 10);
			universeMapManager.BreakDownDepth = 3;
			universeMapManager.BreakDownChanceOf = 2;
			universeMapManager.DistanceBetweenShortConnections = 100;
			universeMapManager.DistanceBetweenLongConnections = 250;
			universeMapManager.biasFactor = 10;
			universeMapManager.maxShortConnections = 3;
			universeMapManager.maxLongConnections = 1;
			universeMapManager.reduceLongConnectionsFactor = 4;
			GalaxyProcessor.universeMapManager = universeMapManager;
			GalaxyProcessor.universeMapManager.GenerateUniverse();
		}
		else
		{
			GalaxyProcessor.universeMapManager.Initialize();
		}
	}

	private void CleanUpData()
	{
		if (GameSaveFile.Get("NC", false))
		{
			return;
		}
		int num = UniverseSaveFile.Get("CUR_GLXY", -1);
		if (num <= 0)
		{
			return;
		}
		GalaxySaveFile.InitSetting(num);
		string text = GalaxySaveFile.FindGroup("SYS_", "SS", true);
		string text2 = GalaxySaveFile.FindGroup("OBJ_", "NAME", "The Justice Ryder");
		if (!string.IsNullOrEmpty(text2))
		{
			GalaxySaveFile.ClearGroup(text2);
			string text3 = UniverseSaveFile.Get("PLAYER", "SHIP_ID", string.Empty);
			if (!string.IsNullOrEmpty(text3))
			{
				UniverseSaveFile.ClearGroup(text3);
				UniverseSaveFile.Clear("PLAYER", "SHIP_ID");
			}
		}
	}

	private void Update()
	{
		if (isFirstFrame)
		{
			timerUntilFirstFrame -= Time.deltaTime;
			if (timerUntilFirstFrame <= 0f)
			{
				isFirstFrame = false;
				StartLoading();
			}
		}
		else
		{
			if (!isProcessingGalaxies)
			{
				return;
			}
			if (GlobalSettings.gameMode != GameModeEnum.Normal && previousLoopSeed != -1)
			{
				UnityEngine.Random.seed = previousLoopSeed;
			}
			timerNextStatusMessage -= Time.deltaTime;
			if (timerNextStatusMessage <= 0f)
			{
				ShowRandomStatusMessage();
			}
			switch (currentProcessing)
			{
			case ProcessingEnum.None:
				if (processingIdx < galaxyList.Count)
				{
					currentProcessing = ProcessingEnum.Preparing;
				}
				else
				{
					currentProcessing = ProcessingEnum.BuildAlphaObjectives;
				}
				break;
			case ProcessingEnum.Preparing:
			{
				currentProcessing = ProcessingEnum.Processing;
				string text5 = galaxyList[processingIdx];
				string text6 = "~map";
				if (GameSaveFile.Get("UNIVERSE_ID", "DEFAULT") != "DEFAULT")
				{
					text6 += "_ch";
				}
				text6 += ".txt";
				DataFile.InitSetting(text5, text6);
				if (processingIdx > 0)
				{
					GalaxyProcessor.DeinitalizeGalaxy(Path.GetFileName(galaxyList[processingIdx - 1]));
				}
				processingFolderName = Path.GetFileName(text5);
				GalaxyProcessor.InitalizeGalaxy(processingFolderName);
				processingPercent += percentPerGalaxyBuild;
				LoadingUI.Instance.SetValue(processingPercent);
				break;
			}
			case ProcessingEnum.Processing:
			{
				currentProcessing = ProcessingEnum.None;
				int num10 = -1;
				num10 = ((GlobalSettings.gameMode != GameModeEnum.Normal && SeedDailyChallengeDungeon != -1) ? SeedDailyChallengeDungeon : UnityEngine.Random.seed);
				List<StarSystemInfo> list2 = GalaxyProcessor.BuildStarSystems(num10);
				if (processingCompleteSystemList == null)
				{
					processingCompleteSystemList = new List<StarSystemInfo>();
				}
				processingCompleteSystemList.AddRange(list2);
				float num11 = float.MaxValue;
				float num12 = float.MinValue;
				float num13 = 0f;
				int num14 = 0;
				int num15 = 0;
				int num16 = 0;
				int num17 = 0;
				int num18 = 0;
				int num19 = 0;
				int num20 = 0;
				int num21 = 0;
				foreach (StarSystemInfo item in list2)
				{
					int num22 = item.NumberOfDungeons + item.NumberOfOutposts + item.NumberOfTradingPosts;
					num20 += num22;
				}
				num21 = num20 / list2.Count;
				foreach (StarSystemInfo item2 in list2)
				{
					num14 = item2.NumberOfDungeons;
					num15 = item2.NumberOfOutposts;
					num16 = item2.NumberOfTradingPosts;
					num17 += num14;
					num18 += num15;
					num19 += num16;
					int num23 = num14 + num15 + num16;
					float num24 = (float)num23 / (float)num21;
					float num25 = (item2.DifficultyMin + item2.DifficultyMax) / 2f;
					num13 += num25 * num24;
					if (item2.DifficultyMin < num11)
					{
						num11 = item2.DifficultyMin;
					}
					if (item2.DifficultyMax > num12)
					{
						num12 = item2.DifficultyMax;
					}
				}
				DataFile.Save("DIFF_MIN", num11);
				DataFile.Save("DIFF_AVG", num13 / (float)list2.Count);
				DataFile.Save("DIFF_MAX", num12);
				DataFile.Save("NUM_DER", num17);
				DataFile.Save("NUM_OUT", num18);
				DataFile.Save("NUM_TP", num19);
				bool flag2 = false;
				int foundInternalID = 0;
				List<string> allGroups3 = UniverseSaveFile.GetAllGroups("GX_");
				foreach (string item3 in allGroups3)
				{
					string[] array3 = item3.Split('_');
					if (array3.Length == 2 && int.TryParse(array3[1], out foundInternalID))
					{
						GalaxySaveFile.InitSetting(foundInternalID);
						if (GalaxySaveFile.Get("DATA", string.Empty) == processingFolderName)
						{
							flag2 = true;
							break;
						}
					}
				}
				if (flag2)
				{
					GalaxySaveFile.SaveGalaxySeed(num10);
					bool flag3 = false;
					bool flag4 = false;
					if (Convert.ToBoolean(GameSaveFile.Get("SP", "scn1", "false")) && Convert.ToBoolean(GameSaveFile.Get("SP", "scn2", "false")) && Convert.ToBoolean(GameSaveFile.Get("SP", "scn3", "false")))
					{
						flag3 = true;
					}
					if (LogManager.LogDataFile == null)
					{
						LogManager.InitManager();
					}
					if (ObjectiveManual.IsObjectiveStepActive("pandemic", "stepD"))
					{
						flag4 = true;
					}
					foreach (StarSystemInfo item4 in list2)
					{
						GalaxyProcessor.GenerateDungeonInfo(item4, false, null);
						foreach (DungeonInfo dungeon in item4.Dungeons)
						{
							if (dungeon.DungeonType == DungeonTypeEnum.Derelict)
							{
								dungeon.Name = NameGenerator.NextDerelictName();
								if (flag4 && dungeon.Definition.Key.name.StartsWith("Private"))
								{
									if (pandemicMedicalShipsInUniverse == null)
									{
										pandemicMedicalShipsInUniverse = new Dictionary<int, List<string>>();
									}
									if (!pandemicMedicalShipsInUniverse.ContainsKey(foundInternalID))
									{
										pandemicMedicalShipsInUniverse.Add(foundInternalID, new List<string>());
									}
									pandemicMedicalShipsInUniverse[foundInternalID].Add(dungeon.GroupKey);
								}
							}
							else if (dungeon.DungeonType == DungeonTypeEnum.Station)
							{
								dungeon.Name = NameGenerator.NextOutpostName();
							}
							else if (dungeon.DungeonType == DungeonTypeEnum.Outpost)
							{
								dungeon.Name = NameGenerator.NextOutpostName();
								if (flag3 && dungeon.Definition.Key.name.StartsWith("Military Outpost"))
								{
									if (predatorMilitaryOutpostsInUniverse == null)
									{
										predatorMilitaryOutpostsInUniverse = new Dictionary<int, List<string>>();
									}
									if (!predatorMilitaryOutpostsInUniverse.ContainsKey(foundInternalID))
									{
										predatorMilitaryOutpostsInUniverse.Add(foundInternalID, new List<string>());
									}
									predatorMilitaryOutpostsInUniverse[foundInternalID].Add(dungeon.GroupKey);
								}
							}
							if (dungeon.Definition.Key.name.StartsWith("MUTEKI") && (dungeon.Definition.Value == null || dungeon.Definition.Value.name.ToLower() != "a"))
							{
								if (techDungeonsInUniverse == null)
								{
									techDungeonsInUniverse = new Dictionary<int, List<string>>();
								}
								if (!techDungeonsInUniverse.ContainsKey(foundInternalID))
								{
									techDungeonsInUniverse.Add(foundInternalID, new List<string>());
								}
								techDungeonsInUniverse[foundInternalID].Add(dungeon.GroupKey);
							}
						}
						item4.Name = NameGenerator.NextSystemName();
					}
					UniverseNode universeNode = GalaxyProcessor.universeMapManager.GetPlacedNodes().FirstOrDefault((UniverseNode x) => x != null && x.InternalID == foundInternalID);
					if (universeNode != null)
					{
						int num26 = GalaxySaveFile.Get("GALAXY_SEED", -1);
						if (GlobalSettings.gameMode == GameModeEnum.Normal)
						{
							GalaxyProcessor.DetermineStargateStarSystems(universeNode, list2, num26);
							if (predatorSystemsInUniverse == null)
							{
								predatorSystemsInUniverse = new Dictionary<int, List<string>>();
							}
							if (!predatorSystemsInUniverse.ContainsKey(foundInternalID))
							{
								predatorSystemsInUniverse.Add(foundInternalID, new List<string>());
							}
							int count = list2.Count;
							for (int num27 = 0; num27 < count; num27++)
							{
								if (list2[num27].HasStargate)
								{
									predatorSystemsInUniverse[foundInternalID].Add(list2[num27].GroupKey);
								}
							}
						}
						else if (GlobalSettings.gameMode == GameModeEnum.WeeklyChallenge)
						{
							UnityEngine.Random.seed = num26;
							int index2 = UnityEngine.Random.Range(0, list2.Count);
							list2[index2].HasStargate = true;
						}
					}
				}
				GlobalSettings.GameState.StarSystems = null;
				GlobalSettings.GameStateIsLoaded = false;
				UniverseSaveFile.Clear("LAST_SHIP_ID");
				DataFile.Detach();
				processingIdx++;
				processingPercent += percentPerGalaxyProcess;
				LoadingUI.Instance.SetValue(processingPercent);
				break;
			}
			case ProcessingEnum.BuildAlphaObjectives:
			{
				currentProcessing = ProcessingEnum.SpecialProcessing;
				List<UniverseNode> placedNodes2 = GalaxyProcessor.universeMapManager.GetPlacedNodes();
				Dictionary<string, KeyValuePair<string, string>> dictionary2 = new Dictionary<string, KeyValuePair<string, string>>();
				foreach (UniverseNode item5 in placedNodes2)
				{
					GalaxySaveFile.InitSetting(item5.InternalID);
					List<string> allGroups4 = GalaxySaveFile.GetAllGroups("OBJ_", "DTYPE", 2);
					if (allGroups4.Count <= 0)
					{
						continue;
					}
					foreach (string item6 in allGroups4)
					{
						string text8 = GalaxySaveFile.Get(item6, "P", string.Empty);
						if (!string.IsNullOrEmpty(text8) && GalaxySaveFile.Get(item6, "DEFNAME", string.Empty).ToLower() == "defense")
						{
							dictionary2.Add(item6, new KeyValuePair<string, string>(text8, item5.GroupKey));
						}
					}
				}
				int count2 = dictionary2.Count;
				if (count2 > 0)
				{
					int index11 = UnityEngine.Random.Range(0, count2);
					string[] array5 = dictionary2.ElementAt(index11).Value.Value.Split('_');
					if (array5.Length == 2)
					{
						int result2 = 0;
						if (int.TryParse(array5[1], out result2))
						{
							GalaxySaveFile.InitSetting(result2);
							GalaxySaveFile.Save(dictionary2.ElementAt(index11).Key, "OBJPAN", 1);
						}
						int num35 = 0;
						num35++;
					}
				}
				else
				{
					Debug.LogWarning("Was unable to find a Defense outpost in the current universe for the Pandemic objective.  That will be unbeatable.");
				}
				processingPercent += percentForObjectivesProcessing;
				LoadingUI.Instance.SetValue(processingPercent);
				break;
			}
			case ProcessingEnum.SpecialProcessing:
			{
				if (GlobalSettings.gameMode == GameModeEnum.Normal && !GameSaveFile.Get("URESET", false))
				{
					GalaxyProcessor.GenerateNurseryDungeonsForData();
				}
				string dataGalaxyLocation2 = GameFileHelper.GetDataGalaxyLocation();
				dataGalaxyLocation2 = Path.Combine(dataGalaxyLocation2, "Objectives");
				if (Directory.Exists(dataGalaxyLocation2))
				{
					string[] files2 = Directory.GetFiles(dataGalaxyLocation2, "~obj*.txt");
					string[] array4 = files2;
					foreach (string text7 in array4)
					{
						DataFile.InitSetting(text7);
						if (DataFile.Get("TYPE", string.Empty).ToUpper() == "SCAVENGER")
						{
							Debug.Log(string.Format("Objective file: {0}", text7));
							sourceObjectiveFile = new DataFile();
							sourceObjectiveFile.InitSettingInstance(text7);
							currentProcessing = ProcessingEnum.BuildScavengerHunt;
							break;
						}
					}
				}
				else
				{
					Debug.LogError("Couldn't find the Objectives folder!");
					LaunchGame();
				}
				if (GlobalSettings.gameMode == GameModeEnum.Normal)
				{
					if (techDungeonsInUniverse != null)
					{
						for (int num29 = 0; num29 < 3; num29++)
						{
							int num30 = 3;
							int num31 = techDungeonsInUniverse.Count;
							for (int num32 = 0; num32 < num30; num32++)
							{
								int index3 = UnityEngine.Random.Range(0, num31);
								try
								{
									KeyValuePair<int, List<string>> keyValuePair = techDungeonsInUniverse.ElementAt(index3);
									int index4 = UnityEngine.Random.Range(0, keyValuePair.Value.Count);
									GalaxySaveFile.InitSetting(keyValuePair.Key);
									GalaxySaveFile.Save(keyValuePair.Value[index4], "AI", num29 + 1);
									keyValuePair.Value.RemoveAt(index4);
									if (keyValuePair.Value.Count == 0)
									{
										techDungeonsInUniverse.Remove(keyValuePair.Key);
										num31--;
									}
								}
								catch (Exception)
								{
									int num33 = 0;
									num33++;
								}
							}
						}
					}
					if (predatorSystemsInUniverse != null)
					{
						for (int num34 = 0; num34 < 3; num34++)
						{
							int index5 = UnityEngine.Random.Range(0, predatorSystemsInUniverse.Count);
							int index6 = UnityEngine.Random.Range(0, predatorSystemsInUniverse.ElementAt(index5).Value.Count);
							GalaxySaveFile.InitSetting(predatorSystemsInUniverse.ElementAt(index5).Key);
							GalaxySaveFile.Save(predatorSystemsInUniverse.ElementAt(index5).Value[index6], "SP", num34 + 1);
							if (predatorMilitaryOutpostsInUniverse != null && predatorMilitaryOutpostsInUniverse.ContainsKey(predatorSystemsInUniverse.ElementAt(index5).Key))
							{
								predatorMilitaryOutpostsInUniverse.Remove(predatorSystemsInUniverse.ElementAt(index5).Key);
							}
							predatorSystemsInUniverse.Remove(predatorSystemsInUniverse.ElementAt(index5).Key);
						}
					}
					if (Convert.ToBoolean(GameSaveFile.Get("SP", "scn1", "false")) && Convert.ToBoolean(GameSaveFile.Get("SP", "scn2", "false")) && Convert.ToBoolean(GameSaveFile.Get("SP", "scn3", "false")) && predatorMilitaryOutpostsInUniverse != null)
					{
						int index7 = UnityEngine.Random.Range(0, predatorMilitaryOutpostsInUniverse.Count);
						int index8 = UnityEngine.Random.Range(0, predatorMilitaryOutpostsInUniverse.ElementAt(index7).Value.Count);
						GalaxySaveFile.InitSetting(predatorMilitaryOutpostsInUniverse.ElementAt(index7).Key);
						GalaxySaveFile.Save(predatorMilitaryOutpostsInUniverse.ElementAt(index7).Value[index8], "px30", 1);
					}
					if (ObjectiveManual.IsObjectiveStepActive("pandemic", "stepD") && pandemicMedicalShipsInUniverse != null)
					{
						int index9 = UnityEngine.Random.Range(0, pandemicMedicalShipsInUniverse.Count);
						int index10 = UnityEngine.Random.Range(0, pandemicMedicalShipsInUniverse.ElementAt(index9).Value.Count);
						GalaxySaveFile.InitSetting(pandemicMedicalShipsInUniverse.ElementAt(index9).Key);
						GalaxySaveFile.Save(pandemicMedicalShipsInUniverse.ElementAt(index9).Value[index10], "PD1", 1);
					}
				}
				processingPercent += percentForSpecialProcessing;
				LoadingUI.Instance.SetValue(processingPercent);
				break;
			}
			case ProcessingEnum.BuildScavengerHunt:
			{
				if (processingCompleteSystemList == null)
				{
					string message = "UniverseProcessor reached 'BuildScavengerHunt' step, but processingCompleteSystemList = null.  Make sure to run 'Processing' before this step.  Breaking out of the processing code.";
					Debug.LogError(message);
					LaunchGame();
				}
				string currentDataUniverseLocation = GameFileHelper.GetCurrentDataUniverseLocation();
				int setting = sourceObjectiveFile.GetSetting("RO", "MIN", 0);
				int setting2 = sourceObjectiveFile.GetSetting("RO", "MAX", setting);
				int num = 20;
				int num2 = 30;
				float num3 = 0.8f;
				float num4 = 1f;
				List<UniverseNode> placedNodes = GalaxyProcessor.universeMapManager.GetPlacedNodes();
				List<string> list = new List<string>();
				Dictionary<string, KeyValuePair<string, string>> dictionary = new Dictionary<string, KeyValuePair<string, string>>();
				DataFile.Detach();
				DataFile.InitSetting(currentDataUniverseLocation, "~objscvngr.txt");
				DataFile.Save("TYPE", "SCAVENGER");
				DataFile.Save("KD", "MIN", sourceObjectiveFile.GetSetting("KD", "MIN", 0));
				string dataGalaxyLocation = GameFileHelper.GetDataGalaxyLocation();
				dataGalaxyLocation = Path.Combine(dataGalaxyLocation, "Objectives");
				int num5 = 0;
				int num6 = 0;
				if (Directory.Exists(dataGalaxyLocation))
				{
					string[] files = Directory.GetFiles(dataGalaxyLocation, "~log_scavenger*.txt");
					num5 = files.Length;
					string[] array = files;
					foreach (string text in array)
					{
						string fileName = Path.GetFileName(text);
						string text2 = fileName.Replace(".txt", string.Empty);
						int result = 0;
						string[] array2 = text2.Split('_');
						if (array2.Length != 3 || !int.TryParse(array2[2], out result))
						{
							continue;
						}
						string text3 = Path.Combine(currentDataUniverseLocation, "Logs");
						try
						{
							if (!Directory.Exists(text3))
							{
								Directory.CreateDirectory(text3);
							}
							text3 = Path.Combine(text3, fileName);
							File.Copy(text, text3, true);
							DataFile.Save(string.Format("LOG_{0}", result), "FILE", text2);
							num6++;
						}
						catch (Exception)
						{
						}
					}
				}
				percentForScavengerBuildPass1 /= placedNodes.Count;
				percentForScavengerBuildPass2 /= placedNodes.Count;
				foreach (UniverseNode item7 in placedNodes)
				{
					GalaxySaveFile.InitSetting(item7.InternalID);
					List<string> allGroups = GalaxySaveFile.GetAllGroups("OBJ_", "DTYPE", 1);
					foreach (string item8 in allGroups)
					{
						int num7 = GalaxySaveFile.Get(item8, "SEED_D", -1);
						if (num7 == -1)
						{
							continue;
						}
						string sysGroupKey = GalaxySaveFile.Get(item8, "P", string.Empty);
						StarSystemInfo starSystemInfo = processingCompleteSystemList.FirstOrDefault((StarSystemInfo x) => x != null && x.GroupKey == sysGroupKey);
						if (starSystemInfo != null)
						{
							DungeonInfo dungeonInfo = GalaxyProcessor.BuildNormalDungeon(num7, DungeonTypeEnum.Derelict, starSystemInfo, 0);
							float weightedDifficulty = dungeonInfo.CalculatedDifficultyValues.GetWeightedDifficulty();
							if (weightedDifficulty >= num3 && weightedDifficulty <= num4 && !list.Contains(item7.GroupKey))
							{
								list.Add(item7.GroupKey);
								break;
							}
						}
						else
						{
							Debug.LogWarning(string.Format("Couldn't find a star system in 'processingSystemList' for the following key: {0}", sysGroupKey));
						}
					}
					processingPercent += percentForScavengerBuildPass1;
					LoadingUI.Instance.SetValue(processingPercent);
				}
				dictionary.Clear();
				foreach (UniverseNode item9 in placedNodes)
				{
					GalaxySaveFile.InitSetting(item9.InternalID);
					List<string> allGroups2 = GalaxySaveFile.GetAllGroups("OBJ_", "DTYPE", 2);
					if (allGroups2.Count > 0)
					{
						foreach (string item10 in allGroups2)
						{
							string text4 = GalaxySaveFile.Get(item10, "P", string.Empty);
							if (!string.IsNullOrEmpty(text4) && !list.Contains(item9.GroupKey))
							{
								dictionary.Add(item10, new KeyValuePair<string, string>(text4, item9.GroupKey));
							}
						}
					}
					processingPercent += percentForScavengerBuildPass2;
					LoadingUI.Instance.SetValue(processingPercent);
				}
				if (GlobalSettings.gameMode == GameModeEnum.Normal)
				{
					if (dictionary.Count > 0)
					{
						int num8 = UnityEngine.Random.Range(setting, setting2 + 1);
						if (num8 > dictionary.Count)
						{
							string message2 = string.Format("We calculated to create {0} research outposts, but we only have {1} outposts in the universe as a whole.", num8, dictionary.Count);
							Debug.LogWarning(message2);
							num8 = dictionary.Count;
						}
						int num9 = 0;
						percentForScavengerBuildPass3 /= num8;
						do
						{
							bool flag = true;
							int index = UnityEngine.Random.Range(0, dictionary.Count);
							string key = dictionary.ElementAt(index).Key;
							if (DataFile.GetAllGroups("RO_", "SYS", dictionary[key].Key).Count > 0)
							{
								flag = false;
							}
							if (flag)
							{
								string groupKey = string.Format("RO_{0}", key);
								DataFile.Save(groupKey, "KEY", key);
								DataFile.Save(groupKey, "SYS", dictionary[key].Key);
								DataFile.Save(groupKey, "GXY", dictionary[key].Value);
								num9++;
								processingPercent += percentForScavengerBuildPass3;
								LoadingUI.Instance.SetValue(processingPercent);
							}
							dictionary.Remove(key);
						}
						while (dictionary.Count != 0 && num9 < num8);
					}
					else
					{
						string message3 = string.Format("No outposts found in the entire universe!  That can't be right, and means we can't properly complete the SCAVENGER objective build out.", num3, num2);
						Debug.LogError(message3);
					}
				}
				DataFile.Detach();
				LaunchGame();
				break;
			}
			}
			if (GlobalSettings.gameMode != GameModeEnum.Normal)
			{
				previousLoopSeed = UnityEngine.Random.seed;
			}
		}
	}

	private void LaunchGame()
	{
		isProcessingGalaxies = false;
		DataFile dataFile = new DataFile();
		string currentDataUniverseLocation = GameFileHelper.GetCurrentDataUniverseLocation();
		dataFile.InitSettingInstance(currentDataUniverseLocation, "~objscvngr.txt");
		GalaxyProcessor.SetObjectiveFile(dataFile);
		Application.LoadLevel("GalaxyMapScene");
	}

	private void ShowRandomStatusMessage()
	{
		if (rnd == null)
		{
			rnd = new System.Random();
		}
		timerNextStatusMessage = rnd.Next(2, 4);
		int num = rnd.Next(0, statusTextMessages.Length);
		LoadingUI.Instance.SetStatusText(statusTextMessages[num]);
	}
}
