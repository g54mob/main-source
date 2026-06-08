using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using UnityEngine;

public static class LogManager
{
	public enum LogTypeEnum
	{
		Unknown = 0,
		Log = 1,
		Objective = 2
	}

	private class LogInfo
	{
		private string _groupKeyBase = "LOG";

		public string GroupKey
		{
			get
			{
				return string.Format("{0}_{1}", GroupKeyBase, InternalID);
			}
		}

		public string GroupKeyBase
		{
			get
			{
				return _groupKeyBase;
			}
			set
			{
				_groupKeyBase = value;
			}
		}

		public int InternalID { get; set; }

		public int LogID { get; set; }

		public string LogData { get; set; }

		public string LogHeaderData { get; set; }

		public string LogFooterData { get; set; }

		public string OriginalFileName { get; set; }

		public LogTypeEnum LogType { get; private set; }

		public LogInfo(string originalFileName, string data)
			: this(originalFileName, data, LogTypeEnum.Unknown)
		{
		}

		public LogInfo(string originalFileName, string data, LogTypeEnum logType)
		{
			OriginalFileName = originalFileName;
			InternalID = -1;
			LogID = 0;
			LogHeaderData = string.Empty;
			LogData = data;
			LogType = logType;
		}
	}

	private const int CHANCE_OF_SCRIPTED_LOG = 33;

	private const int CHANCE_OF_UNIVERSE_STORY = 50;

	private static List<string> MedicalPriorityLogQueue = null;

	private static List<string> MedicalNormalLogQueue = null;

	private static List<string> MilitaryPriorityLogQueue = null;

	private static List<string> MilitaryPriorityOutpostLogQueue = null;

	private static List<string> MilitaryNormalDerelictLogQueue = null;

	private static List<string> MilitaryNormalOutpostLogQueue = null;

	private static List<string> GreyGooPriorityLogQueue = null;

	private static List<string> GreyGooNormalLogQueue = null;

	private static List<string> CosmicEventPriorityLogQueue = null;

	private static List<string> CosmicEventNormalLogQueue = null;

	private static List<string> SingularityPriorityLogQueue = null;

	private static List<string> SingularityNormalLogQueue = null;

	private static bool isMedicalQueueIntalized = false;

	private static bool isMilitaryQueueIntalized = false;

	private static bool isGreyGooQueueIntalized = false;

	private static bool isCosmicEventQueueIntalized = false;

	private static bool isSingularityQueueIntalized = false;

	private static System.Random _random = new System.Random();

	private static List<string> _entireShipsLogsDirectory = null;

	private static List<string> _availableShipNames = null;

	private static List<string> _historyOfGeneratedLogText = new List<string>();

	public static DataFile LogDataFile { get; private set; }

	public static void InitManager()
	{
		if (LogDataFile == null)
		{
			LogDataFile = new DataFile();
			LogDataFile.InitSettingInstance(GameFileHelper.GetDataUniverseLogLocation(), "~data.txt");
		}
	}

	public static void DeInitManager()
	{
		if (LogDataFile != null)
		{
			LogDataFile = null;
		}
		DeInitalizeMedicalLogQueue();
		DeInitalizeMilitaryLogQueue();
		DeInitalizeGreyGoo();
		DeInitalizeCosmicEvent();
		DeInitalizeSigularity();
	}

	public static void InitalizeMedicalLogQueue()
	{
		if (!isMedicalQueueIntalized)
		{
			MedicalPriorityLogQueue = new List<string>();
			MedicalNormalLogQueue = new List<string>();
			if (LogDataFile.GetGroup("OBJ_", "FILE", "Holmes_algorithm_log") == string.Empty)
			{
				MedicalPriorityLogQueue.Add("Pandemic/Holmes_algorithm_log");
			}
			if (LogDataFile.GetValue("pandemic", "stepC", 0) != 0 && LogDataFile.GetGroup("OBJ_", "FILE", "Holmes_ISHO_03_log") == string.Empty)
			{
				MedicalPriorityLogQueue.Add("Pandemic/Holmes_ISHO_03_log");
			}
			if (LogDataFile.GetValue("pandemic", "stepD", 0) != 0 && LogDataFile.GetGroup("OBJ_", "FILE", "Holmes_outro_02_log") == string.Empty)
			{
				MedicalPriorityLogQueue.Add("Pandemic/Holmes_outro_02_log");
			}
			if (LogDataFile.GetGroup("OBJ_", "FILE", "Holmes_ISHO_01_log") == string.Empty)
			{
				MedicalNormalLogQueue.Add("Pandemic/Holmes_ISHO_01_log");
			}
			if (LogDataFile.GetGroup("OBJ_", "FILE", "Holmes_ISHO_02_log") == string.Empty)
			{
				MedicalNormalLogQueue.Add("Pandemic/Holmes_ISHO_02_log");
			}
			if (LogDataFile.GetGroup("OBJ_", "FILE", "ISHO_DB_derelicts_log") == string.Empty)
			{
				MedicalNormalLogQueue.Add("Pandemic/ISHO_DB_derelicts_log");
			}
			if (LogDataFile.GetGroup("OBJ_", "FILE", "ISHO_DB_ouposts_log") == string.Empty)
			{
				MedicalNormalLogQueue.Add("Pandemic/ISHO_DB_ouposts_log");
			}
			if (LogDataFile.GetGroup("OBJ_", "FILE", "Holmes_Obsession_log") == string.Empty)
			{
				MedicalNormalLogQueue.Add("Pandemic/Holmes_Obsession_log");
			}
			if (LogDataFile.GetGroup("OBJ_", "FILE", "Holmes_Confession_log") == string.Empty)
			{
				MedicalNormalLogQueue.Add("Pandemic/Holmes_Confession_log");
			}
			isMedicalQueueIntalized = true;
		}
	}

	public static void DeInitalizeMedicalLogQueue()
	{
		if (isMedicalQueueIntalized)
		{
			MedicalPriorityLogQueue = null;
			MedicalNormalLogQueue = null;
			isMedicalQueueIntalized = false;
		}
	}

	public static void InitalizeMilitaryLogQueue()
	{
		if (isMilitaryQueueIntalized)
		{
			return;
		}
		MilitaryPriorityLogQueue = new List<string>();
		MilitaryPriorityOutpostLogQueue = new List<string>();
		MilitaryNormalDerelictLogQueue = new List<string>();
		MilitaryNormalOutpostLogQueue = new List<string>();
		if (LogDataFile.GetGroup("OBJ_", "FILE", "CE_Intro_Log") == string.Empty)
		{
			MilitaryPriorityLogQueue.Add("Cosmic Event/CE_Intro_Log");
		}
		if (LogDataFile.GetValue("cosmic", "stepA", 0) != 0 && LogDataFile.GetGroup("OBJ_", "FILE", "CE_A_Log") == string.Empty)
		{
			MilitaryPriorityLogQueue.Add("Cosmic Event/CE_A_Log");
		}
		if (LogDataFile.GetValue("cosmic", "stepA", 0) != 0 && LogDataFile.GetGroup("OBJ_", "FILE", "SP_Intro_Log") == string.Empty)
		{
			MilitaryPriorityLogQueue.Add("Super-Predator/SP_Intro_Log");
		}
		if (LogDataFile.GetValue("superpredator", "stepA", 0) != 0 && LogDataFile.GetGroup("OBJ_", "FILE", "SP_03_Log") == string.Empty && LogDataFile.GetGroup("OBJ_", "FILE", "SP_Start_Log") == string.Empty)
		{
			MilitaryPriorityLogQueue.Add("Super-Predator/SP_03_Log");
		}
		if (GameSaveFile.Get("GAME_VER", 0f) >= 0.321f)
		{
			if (LogDataFile.GetValue("superpredator", "stepB", 0) != 0 && LogDataFile.GetGroup("OBJ_", "FILE", "SP_04_Log") == string.Empty)
			{
				MilitaryPriorityOutpostLogQueue.Add("Super-Predator/SP_04_Log");
			}
			if (LogDataFile.GetValue("superpredator", "stepD", 0) != 0 && LogDataFile.GetGroup("OBJ_", "FILE", "SP_06_Log") == string.Empty)
			{
				MilitaryPriorityOutpostLogQueue.Add("Super-Predator/SP_06_Log");
			}
		}
		if (LogDataFile.GetValue("superpredator", "stepA", 0) != 0)
		{
			if (LogDataFile.GetGroup("OBJ_", "FILE", "SP_Color_Derelict1_Log") == string.Empty)
			{
				MilitaryNormalDerelictLogQueue.Add("Super-Predator/SP_Color_Derelict1_Log");
			}
			if (LogDataFile.GetGroup("OBJ_", "FILE", "SP_Color_Derelict2_Log") == string.Empty)
			{
				MilitaryNormalDerelictLogQueue.Add("Super-Predator/SP_Color_Derelict2_Log");
			}
			if (LogDataFile.GetGroup("OBJ_", "FILE", "SP_Color_Derelict3_Log") == string.Empty)
			{
				MilitaryNormalDerelictLogQueue.Add("Super-Predator/SP_Color_Derelict3_Log");
			}
			if (LogDataFile.GetGroup("OBJ_", "FILE", "SP_Color_Outposts1_Log") == string.Empty)
			{
				MilitaryNormalOutpostLogQueue.Add("Super-Predator/SP_Color_Outposts1_Log");
			}
			if (LogDataFile.GetGroup("OBJ_", "FILE", "SP_Color_Outposts2_Log") == string.Empty)
			{
				MilitaryNormalOutpostLogQueue.Add("Super-Predator/SP_Color_Outposts2_Log");
			}
		}
		isMilitaryQueueIntalized = true;
	}

	public static void DeInitalizeMilitaryLogQueue()
	{
		if (isMilitaryQueueIntalized)
		{
			MilitaryPriorityLogQueue = null;
			MilitaryPriorityOutpostLogQueue = null;
			MilitaryNormalDerelictLogQueue = null;
			MilitaryNormalOutpostLogQueue = null;
			isMilitaryQueueIntalized = false;
		}
	}

	public static void InitalizeGreyGooLogQueue()
	{
		if (isGreyGooQueueIntalized)
		{
			return;
		}
		GreyGooPriorityLogQueue = new List<string>();
		GreyGooNormalLogQueue = new List<string>();
		if (LogDataFile.GetGroup("OBJ_", "FILE", "GG_A_Log") == string.Empty)
		{
			GreyGooPriorityLogQueue.Add("Grey Goo/GG_A_Log");
		}
		if (LogDataFile.GetValue("greygoo", "stepA", 0) != 0 && LogDataFile.GetGroup("OBJ_", "FILE", "GG_C_Log") == string.Empty)
		{
			GreyGooPriorityLogQueue.Add("Grey Goo/GG_C_Log");
		}
		if (LogDataFile.GetValue("greygoo", "stepA", 0) != 0)
		{
			if (LogDataFile.GetGroup("OBJ_", "FILE", "GG_ColorB1_Log") == string.Empty)
			{
				GreyGooNormalLogQueue.Add("Grey Goo/GG_ColorB1_Log");
			}
			if (LogDataFile.GetGroup("OBJ_", "FILE", "GG_ColorB2_Log") == string.Empty)
			{
				GreyGooNormalLogQueue.Add("Grey Goo/GG_ColorB2_Log");
			}
			if (LogDataFile.GetGroup("OBJ_", "FILE", "GG_ColorB3_Log") == string.Empty)
			{
				GreyGooNormalLogQueue.Add("Grey Goo/GG_ColorB3_Log");
			}
			if (LogDataFile.GetGroup("OBJ_", "FILE", "GG_ColorB4_Log") == string.Empty)
			{
				GreyGooNormalLogQueue.Add("Grey Goo/GG_ColorB4_Log");
			}
		}
		isGreyGooQueueIntalized = true;
	}

	public static void DeInitalizeGreyGoo()
	{
		if (isGreyGooQueueIntalized)
		{
			GreyGooPriorityLogQueue = null;
			GreyGooNormalLogQueue = null;
			isGreyGooQueueIntalized = false;
		}
	}

	public static void InitalizeCosmicEventLogQueue()
	{
		if (isCosmicEventQueueIntalized)
		{
			return;
		}
		CosmicEventPriorityLogQueue = new List<string>();
		CosmicEventNormalLogQueue = new List<string>();
		if (LogDataFile.GetValue("cosmic", "stepB", 0) != 0 && LogDataFile.GetGroup("OBJ_", "FILE", "CE_C_Log") == string.Empty)
		{
			CosmicEventPriorityLogQueue.Add("Cosmic Event/CE_C_Log");
		}
		if (LogDataFile.GetValue("cosmic", "stepA", 0) != 0)
		{
			if (LogDataFile.GetGroup("OBJ_", "FILE", "CE_ColorB1_Log") == string.Empty)
			{
				CosmicEventNormalLogQueue.Add("Cosmic Event/CE_ColorB1_Log");
			}
			if (LogDataFile.GetGroup("OBJ_", "FILE", "CE_ColorB2_Log") == string.Empty)
			{
				CosmicEventNormalLogQueue.Add("Cosmic Event/CE_ColorB2_Log");
			}
			if (LogDataFile.GetGroup("OBJ_", "FILE", "CE_ColorB3_Log") == string.Empty)
			{
				CosmicEventNormalLogQueue.Add("Cosmic Event/CE_ColorB3_Log");
			}
			if (LogDataFile.GetGroup("OBJ_", "FILE", "CE_ColorB4_Log") == string.Empty)
			{
				CosmicEventNormalLogQueue.Add("Cosmic Event/CE_ColorB4_Log");
			}
		}
		isCosmicEventQueueIntalized = true;
	}

	public static void DeInitalizeCosmicEvent()
	{
		if (isCosmicEventQueueIntalized)
		{
			CosmicEventPriorityLogQueue = null;
			CosmicEventNormalLogQueue = null;
			isCosmicEventQueueIntalized = false;
		}
	}

	public static void InitalizeSingularityLogQueue()
	{
		if (isSingularityQueueIntalized)
		{
			return;
		}
		SingularityPriorityLogQueue = new List<string>();
		SingularityNormalLogQueue = new List<string>();
		if (LogDataFile.GetGroup("OBJ_", "FILE", "SING_A_Log") == string.Empty)
		{
			SingularityPriorityLogQueue.Add("Singularity/SING_A_Log");
		}
		if (LogDataFile.GetValue("singularity", "stepA", 0) != 0 && LogDataFile.GetGroup("OBJ_", "FILE", "SING_C_Log") == string.Empty)
		{
			SingularityPriorityLogQueue.Add("Singularity/SING_C_Log");
		}
		if (LogDataFile.GetValue("singularity", "stepB", 0) != 0 && LogDataFile.GetGroup("OBJ_", "FILE", "SING_D_Log") == string.Empty)
		{
			SingularityPriorityLogQueue.Add("Singularity/SING_D_Log");
		}
		if (LogDataFile.GetValue("singularity", "stepC", 0) != 0 && LogDataFile.GetGroup("OBJ_", "FILE", "SING_E_Log") == string.Empty)
		{
			SingularityPriorityLogQueue.Add("Singularity/SING_E_Log");
		}
		if (LogDataFile.GetValue("singularity", "stepA", 0) != 0)
		{
			if (LogDataFile.GetGroup("OBJ_", "FILE", "SING_ColorB1_Log") == string.Empty)
			{
				SingularityNormalLogQueue.Add("Singularity/SING_ColorB1_Log");
			}
			if (LogDataFile.GetGroup("OBJ_", "FILE", "SING_ColorB2_Log") == string.Empty)
			{
				SingularityNormalLogQueue.Add("Singularity/SING_ColorB2_Log");
			}
			if (LogDataFile.GetGroup("OBJ_", "FILE", "SING_ColorB3_Log") == string.Empty)
			{
				SingularityNormalLogQueue.Add("Singularity/SING_ColorB3_Log");
			}
		}
		if (LogDataFile.GetValue("singularity", "stepB", 0) != 0)
		{
			if (LogDataFile.GetGroup("OBJ_", "FILE", "SING_ColorD1_Log") == string.Empty)
			{
				SingularityNormalLogQueue.Add("Singularity/SING_ColorD1_Log");
			}
			if (LogDataFile.GetGroup("OBJ_", "FILE", "SING_ColorD2_Log") == string.Empty)
			{
				SingularityNormalLogQueue.Add("Singularity/SING_ColorD2_Log");
			}
			if (LogDataFile.GetGroup("OBJ_", "FILE", "SING_ColorD3_Log") == string.Empty)
			{
				SingularityNormalLogQueue.Add("Singularity/SING_ColorD3_Log");
			}
			if (LogDataFile.GetGroup("OBJ_", "FILE", "SING_ColorD4_Log") == string.Empty)
			{
				SingularityNormalLogQueue.Add("Singularity/SING_ColorD4_Log");
			}
		}
		isSingularityQueueIntalized = true;
	}

	public static void DeInitalizeSigularity()
	{
		if (isSingularityQueueIntalized)
		{
			SingularityPriorityLogQueue = null;
			SingularityNormalLogQueue = null;
			isSingularityQueueIntalized = false;
		}
	}

	public static string GetNextShipLog(Room revealedRoom, RevealedRoomType revealedRoomType, string infestationCount)
	{
		LogInfo logInfo = null;
		bool flag = false;
		bool flag2 = 33 >= _random.Next(1, 101);
		bool flag3 = GlobalSettings.NumLogsAfterTutorial == 1;
		int num = GameSaveFile.Get("MISSIONS", 0);
		bool flag4 = num <= 1;
		bool flag5 = true;
		bool skipLogID = false;
		if (GlobalSettings.GameState.ThePlayer.CurrentDockedDungeon.Definition.Key.name.StartsWith("Medical") && !ObjectiveManual.IsObjectiveActive("pandemic") && !LogDataFile.GetValue("pandemic", "COMPLETED", false))
		{
			logInfo = GetStoryLogData("Pandemic/storyDusker_01_Holmes_intro_log");
		}
		else if (GlobalSettings.GameState.ThePlayer.CurrentDockedDungeon.Definition.Key.name.StartsWith("Military") && !ObjectiveManual.IsObjectiveActive("cosmic") && !LogDataFile.GetValue("cosmic", "COMPLETED", false))
		{
			logInfo = GetStoryLogData("Cosmic Event/CE_Intro_Log");
		}
		else if ((GlobalSettings.GameState.ThePlayer.CurrentDockedDungeon.Definition.Key.name.StartsWith("Space") || GlobalSettings.GameState.ThePlayer.CurrentDockedDungeon.Definition.Key.name.StartsWith("Fuel")) && !ObjectiveManual.IsObjectiveActive("greygoo") && !LogDataFile.GetValue("greygoo", "COMPLETED", false))
		{
			logInfo = GetStoryLogData("Grey Goo/GG_A_Log");
		}
		else if (GlobalSettings.GameState.ThePlayer.CurrentDockedDungeon.Definition.Key.name.StartsWith("MUTEKI") && !ObjectiveManual.IsObjectiveActive("singularity") && !LogDataFile.GetValue("singularity", "COMPLETED", false))
		{
			logInfo = GetStoryLogData("Singularity/SING_A_Log");
		}
		if (logInfo == null)
		{
			bool flag6 = false;
			if (num == 2 && GameSaveFile.Get("PLAYS", 0) == 1 && !GameSaveFile.Get("FIRST_CLR_LG", false))
			{
				flag6 = true;
			}
			if (flag6 || UnityEngine.Random.Range(0, 100) < 25)
			{
				logInfo = GetRandomColorLog();
			}
			if (num <= 2 && logInfo != null)
			{
				GameSaveFile.Save("FIRST_CLR_LG", true);
			}
		}
		else if (num <= 2 && logInfo != null)
		{
			GameSaveFile.Save("FIRST_CLR_LG", true);
		}
		if (logInfo == null)
		{
			logInfo = new LogInfo("GENERATED", string.Empty);
			logInfo.LogHeaderData = GetGeneratedLog(revealedRoom, revealedRoomType, infestationCount);
			flag = true;
		}
		else
		{
			logInfo.LogHeaderData = GetLogHeader(revealedRoom, revealedRoomType, infestationCount, true);
			logInfo.LogHeaderData += "[Begin Communication]\n\n";
			logInfo.LogFooterData += "\n\n[End Communication]";
			if (logInfo.OriginalFileName.Contains("storyDusker_01_Holmes_intro_log"))
			{
				skipLogID = true;
				logInfo.GroupKeyBase = "OBJ";
				LogDataFile.SaveValue("pandemic", "stepA", 1);
			}
			else if (logInfo.OriginalFileName.Contains("CE_Intro_Log"))
			{
				skipLogID = true;
				logInfo.GroupKeyBase = "OBJ";
				LogDataFile.SaveValue("cosmic", "stepA", 1);
				PushLogOntoPriorityMilitaryQueue("Super-Predator/SP_Intro_Log");
			}
			else if (logInfo.OriginalFileName.Contains("GG_A_Log"))
			{
				skipLogID = true;
				logInfo.GroupKeyBase = "OBJ";
				LogDataFile.SaveValue("greygoo", "stepA", 1);
				PushLogOntoPriorityGreyGooQueue("Grey Goo/GG_C_Log");
			}
			else if (logInfo.OriginalFileName.Contains("SING_A_Log"))
			{
				skipLogID = true;
				logInfo.GroupKeyBase = "OBJ";
				LogDataFile.SaveValue("singularity", "stepA", 1);
				PushLogOntoPrioritySigularityQueue("Singularity/SING_C_Log");
			}
		}
		if (logInfo != null)
		{
			ReplaceVariables(ref logInfo);
		}
		if (flag5 && !flag && logInfo != null)
		{
			BakeLog(logInfo, skipLogID);
		}
		if (!string.IsNullOrEmpty(logInfo.LogHeaderData))
		{
			logInfo.LogHeaderData = string.Format("<color={0}>{1}</color> ", "#1aff11", logInfo.LogHeaderData);
		}
		if (!string.IsNullOrEmpty(logInfo.LogFooterData))
		{
			logInfo.LogFooterData = string.Format("<color={0}>{1}</color> ", "#1aff11", logInfo.LogFooterData);
		}
		return logInfo.LogHeaderData + logInfo.LogData + logInfo.LogFooterData;
	}

	public static string GetCorruptedLog(Room revealedRoom, RevealedRoomType revealedRoomType, string infestationCount)
	{
		LogInfo logInfo = null;
		logInfo = new LogInfo("GENERATED", string.Empty);
		logInfo.LogHeaderData = GetGeneratedLog(revealedRoom, revealedRoomType, infestationCount);
		if (logInfo != null)
		{
			ReplaceVariables(ref logInfo);
		}
		if (!string.IsNullOrEmpty(logInfo.LogHeaderData))
		{
			logInfo.LogHeaderData = string.Format("<color={0}>{1}</color> ", "#1aff11", logInfo.LogHeaderData);
		}
		if (!string.IsNullOrEmpty(logInfo.LogFooterData))
		{
			logInfo.LogFooterData = string.Format("<color={0}>{1}</color> ", "#1aff11", logInfo.LogFooterData);
		}
		return logInfo.LogHeaderData + logInfo.LogData + logInfo.LogFooterData;
	}

	public static string GetObjectiveLog()
	{
		string text = null;
		if (GalaxyProcessor.ObjectiveFile != null)
		{
			if (_random.Next(0, 100) > 100)
			{
				return null;
			}
			List<string> groupsByName = GalaxyProcessor.ObjectiveFile.GetGroupsByName("LOG_");
			if (groupsByName.Count == 0)
			{
				return null;
			}
			bool flag = _random.Next(0, 100) <= 30;
			IEnumerable<string> enumerable = null;
			if (flag)
			{
				InitManager();
				List<string> groupsByName2 = LogDataFile.GetGroupsByName("LOG_");
				enumerable = groupsByName2.Where((string x) => x != null && LogDataFile.GetSetting(x, "TYPE", 0) == 2);
			}
			if (enumerable == null || enumerable.Count() == 0)
			{
				flag = false;
				enumerable = groupsByName.Where((string x) => x != null && !GalaxyProcessor.ObjectiveFile.GetSetting(x, "VIEWED", false));
			}
			if (enumerable.Count() == 0)
			{
				return null;
			}
			List<string> sourceList = enumerable.ToList();
			string text2 = CommonMethods.PickRandomItem(sourceList, _random);
			if (text2 != null)
			{
				string empty = string.Empty;
				if (!flag)
				{
					empty = GalaxyProcessor.ObjectiveFile.GetSetting(text2, "FILE", string.Empty);
					if (empty == null)
					{
					}
				}
				else
				{
					empty = LogDataFile.GetSetting(text2, "FILE", string.Empty);
				}
				LogInfo logInfo = new LogInfo(empty, text, LogTypeEnum.Objective);
				if (!string.IsNullOrEmpty(empty))
				{
					string dataUniverseLogLocation = GameFileHelper.GetDataUniverseLogLocation();
					string path = dataUniverseLogLocation;
					string arg = (flag ? "bkd" : "txt");
					if (Directory.Exists(dataUniverseLogLocation))
					{
						dataUniverseLogLocation = Path.Combine(path, string.Format("{0}.{1}", empty, arg));
						bool flag2 = false;
						TextReader textReader = null;
						try
						{
							textReader = File.OpenText(dataUniverseLogLocation);
							logInfo.LogData = textReader.ReadToEnd();
							ReplaceVariables(ref logInfo);
							text = logInfo.LogHeaderData + logInfo.LogData;
							if (!flag)
							{
								GalaxyProcessor.ObjectiveFile.SaveValue(text2, "VIEWED", true);
							}
							flag2 = true;
						}
						catch (Exception ex)
						{
							Debug.LogError(string.Format("ERROR trying to read in a log file: {0}\r\nException: {1}", dataUniverseLogLocation, ex.Message));
						}
						finally
						{
							if (textReader != null)
							{
								textReader.Close();
							}
						}
						if (!flag2)
						{
							return null;
						}
						if (!flag)
						{
							BakeLog(logInfo, false);
						}
					}
				}
			}
		}
		return text;
	}

	public static string GetLogFromResource(string fullPath, bool bake)
	{
		return GetLogFromResource(fullPath, bake, false);
	}

	public static string GetLogFromResource(string fullPath, bool bake, bool isObjective)
	{
		LogInfo logInfo = new LogInfo(Path.GetFileName(fullPath), null);
		try
		{
			TextAsset textAsset = ResourceManager.LoadAsset<TextAsset>(fullPath);
			if (textAsset != null)
			{
				logInfo.LogData = textAsset.text;
				if (isObjective)
				{
					logInfo.GroupKeyBase = "OBJ";
				}
				ReplaceVariables(ref logInfo);
				if (bake)
				{
					BakeLog(logInfo, isObjective);
				}
			}
			else
			{
				Debug.LogError(string.Format("Was not able to loag log from resources (got a null error): {0}", fullPath));
			}
		}
		catch (Exception ex)
		{
			Debug.LogError(string.Format("ERROR trying to read in a Resource log file: {0}\r\nException: {1}", fullPath, ex.Message));
			Debug.LogException(ex);
		}
		return logInfo.LogHeaderData + logInfo.LogData;
	}

	public static string GetLogFromFile(string fullPath)
	{
		LogInfo logInfo = new LogInfo("N/A", null);
		TextReader textReader = null;
		try
		{
			textReader = File.OpenText(fullPath);
			logInfo.LogData = textReader.ReadToEnd();
			ReplaceVariables(ref logInfo);
		}
		catch (Exception ex)
		{
			Debug.LogError(string.Format("ERROR trying to read in a log file: {0}\r\nException: {1}", fullPath, ex.Message));
			Debug.LogException(ex);
		}
		finally
		{
			if (textReader != null)
			{
				textReader.Close();
			}
		}
		return logInfo.LogHeaderData + logInfo.LogData;
	}

	public static bool DoesBakedVersionExist(string fileNameWithoutExt)
	{
		string path = Path.Combine(GameFileHelper.GetDataUniverseLogLocation(), string.Format("{0}.bkd", fileNameWithoutExt));
		return File.Exists(path);
	}

	private static void BakeLog(LogInfo logInfoData, bool skipLogID)
	{
		if (LogDataFile == null)
		{
			InitManager();
		}
		bool flag = false;
		string fileName = Path.GetFileName(logInfoData.OriginalFileName);
		if (LogDataFile.GetGroupWithSettings(logInfoData.GroupKeyBase, "FILE", fileName) != string.Empty)
		{
			flag = true;
		}
		TextWriter textWriter = null;
		string text = string.Empty;
		bool flag2 = false;
		int num = 0;
		if (!flag)
		{
			int num2 = 0;
			if (!skipLogID)
			{
				num2 = ((logInfoData.LogType != LogTypeEnum.Objective) ? LogDataFile.GetValue("LAST_LOG_ID", 0) : LogDataFile.GetValue("LAST_NOTICE_ID", 0));
				num2++;
				if (logInfoData.LogType == LogTypeEnum.Objective)
				{
					LogDataFile.SaveValue("LAST_NOTICE_ID", num2);
				}
				else
				{
					LogDataFile.SaveValue("LAST_LOG_ID", num2);
				}
			}
			do
			{
				num = UnityEngine.Random.Range(1, int.MaxValue);
				if (!LogDataFile.GroupExists(string.Format("LOG_{0}", num)))
				{
					flag2 = true;
				}
			}
			while (!flag2);
			logInfoData.InternalID = num;
			logInfoData.LogID = num2;
		}
		try
		{
			if (logInfoData.LogData[0] == 'Ê')
			{
				if (!flag)
				{
					LogDataFile.SaveValue(logInfoData.GroupKey, "TEMP", true);
				}
				logInfoData.LogData = logInfoData.LogData.Substring(1);
			}
			else if (logInfoData.LogData[0] == 'Ë')
			{
				if (!flag)
				{
					LogDataFile.SaveValue(logInfoData.GroupKey, "RFSH", true);
				}
				logInfoData.LogData = logInfoData.LogData.Substring(1);
			}
			text = Path.GetFileName(logInfoData.OriginalFileName);
			fileName = text;
			text = Path.Combine(GameFileHelper.GetDataUniverseLogLocation(), string.Format("{0}.bkd", text));
			textWriter = File.CreateText(text);
			textWriter.Write(logInfoData.LogData);
			if (!flag)
			{
				LogDataFile.SaveValue(logInfoData.GroupKey, "FILE", fileName);
				if (!skipLogID)
				{
					LogDataFile.SaveValue(logInfoData.GroupKey, "LOGID", logInfoData.LogID);
				}
				LogDataFile.SaveValue(logInfoData.GroupKey, "TYPE", (int)logInfoData.LogType);
			}
		}
		catch (Exception ex)
		{
			Debug.LogError(string.Format("ERROR trying to write baked log file: {0}\r\nException: {1}", text, ex.Message));
		}
		finally
		{
			if (textWriter != null)
			{
				textWriter.Close();
			}
		}
	}

	private static int GetCurrentStoryGroupNumber()
	{
		int id = GlobalSettings.GameState.ThePlayer.CurrentStarSystem.Id;
		if (!GlobalSettings.SystemIdToGroupNumberMapping.ContainsKey(id))
		{
			GlobalSettings.SystemIdToGroupNumberMapping[id] = GlobalSettings.NextStoryGroupNumber++;
		}
		return GlobalSettings.SystemIdToGroupNumberMapping[id];
	}

	private static LogInfo GetRandomColorLog()
	{
		LogInfo result = null;
		List<string> list = new List<string>();
		IEnumerable<string> entireShipsLogDirectory = GetEntireShipsLogDirectory();
		int num = entireShipsLogDirectory.Count();
		for (int i = 0; i < num; i++)
		{
			string text = entireShipsLogDirectory.ElementAt(i);
			if (!GlobalSettings.LogFilesAlreadyViewed.Contains(text) && (!GlobalSettings.GameState.ThePlayer.CurrentStarSystem.IsNursery || text != "storyUniverse_01_001"))
			{
				list.Add(text);
			}
		}
		string text2 = CommonMethods.PickRandomItem(list, _random);
		if (text2 != null)
		{
			Debug.Log(string.Format("Attempting to display log: {0}", text2));
			result = GetStoryLogData(text2);
		}
		return result;
	}

	private static LogInfo GetRandomUniverseStory(int storyGroup)
	{
		LogInfo result = null;
		string filePrefix = GetStoryUniversePrefix(storyGroup);
		List<string> list = new List<string>();
		IEnumerable<string> enumerable = from x in GetEntireShipsLogDirectory()
			where x.Contains(filePrefix)
			select x;
		foreach (string item in enumerable)
		{
			if (!GlobalSettings.LogFilesAlreadyViewed.Contains(item) && (!GlobalSettings.GameState.ThePlayer.CurrentStarSystem.IsNursery || item != "storyUniverse_01_001"))
			{
				list.Add(item);
			}
		}
		string text = CommonMethods.PickRandomItem(list, _random);
		if (text != null)
		{
			Debug.Log(string.Format("Attempting to display log: {0}", text));
			result = GetStoryLogData(text);
		}
		return result;
	}

	private static LogInfo GetRandomDuskerStory(int storyGroup)
	{
		string filePrefix = GetStoryDuskerPrefix(storyGroup);
		List<string> list = new List<string>();
		foreach (string item in from x in GetEntireShipsLogDirectory()
			where x.Contains(filePrefix)
			select x)
		{
			if (!GlobalSettings.LogFilesAlreadyViewed.Contains(item))
			{
				list.Add(item);
			}
		}
		string text = CommonMethods.PickRandomItem(list, _random);
		if (text != null)
		{
			return GetStoryLogData(text);
		}
		return null;
	}

	public static string GetNextMedicalLog(Room revealedRoom, RevealedRoomType revealedRoomType, string infestationCount, out bool isCorrupted)
	{
		isCorrupted = false;
		if (!isMedicalQueueIntalized)
		{
			InitalizeMedicalLogQueue();
		}
		string text = string.Empty;
		string text2 = string.Empty;
		LogInfo logInfo = null;
		bool flag = false;
		if (MedicalPriorityLogQueue != null && GalaxySaveFile.Get(GlobalSettings.GameState.ThePlayer.CurrentDockedDungeon.GroupKey, "pd1", 0) != 0)
		{
			int count = MedicalPriorityLogQueue.Count;
			for (int i = 0; i < count; i++)
			{
				if (MedicalPriorityLogQueue[i] == "Pandemic/Holmes_outro_02_log")
				{
					text = MedicalPriorityLogQueue[i];
					MedicalPriorityLogQueue.RemoveAt(i);
					flag = true;
				}
			}
		}
		int num = 50;
		if (GlobalSettings.GameState.ThePlayer.CurrentDockedDungeon.DungeonType == DungeonTypeEnum.Outpost)
		{
			num = 20;
		}
		if (flag || UnityEngine.Random.Range(0, 100) > num)
		{
			if (!flag)
			{
				if (MedicalPriorityLogQueue != null && MedicalPriorityLogQueue.Count > 0 && UnityEngine.Random.Range(0, 100) < 50)
				{
					int index = UnityEngine.Random.Range(0, MedicalPriorityLogQueue.Count);
					text = MedicalPriorityLogQueue[index];
					if (true)
					{
						MedicalPriorityLogQueue.RemoveAt(index);
					}
					else
					{
						isCorrupted = true;
						logInfo = new LogInfo("GENERATED", string.Empty);
						logInfo.LogHeaderData = GetGeneratedLog(revealedRoom, revealedRoomType, infestationCount);
					}
				}
				else if (MedicalNormalLogQueue != null && MedicalNormalLogQueue.Count > 0 && GlobalSettings.GameState.ThePlayer.CurrentDockedDungeon.Definition.Key.name.Contains("Medical"))
				{
					int index2 = UnityEngine.Random.Range(0, MedicalNormalLogQueue.Count);
					text = MedicalNormalLogQueue[index2];
					MedicalNormalLogQueue.RemoveAt(index2);
				}
				else
				{
					isCorrupted = true;
					logInfo = new LogInfo("GENERATED", string.Empty);
					logInfo.LogHeaderData = GetGeneratedLog(revealedRoom, revealedRoomType, infestationCount);
				}
			}
		}
		else
		{
			isCorrupted = true;
			logInfo = new LogInfo("GENERATED", string.Empty);
			logInfo.LogHeaderData = GetGeneratedLog(revealedRoom, revealedRoomType, infestationCount);
		}
		if (!string.IsNullOrEmpty(text))
		{
			if (ObjectiveManual.IsObjectiveStepActive("pandemic", "stepA") && text == "Pandemic/Holmes_algorithm_log")
			{
				LogDataFile.SaveValue("pandemic", "stepA", 3);
				LogDataFile.SaveValue("pandemic", "stepB", 1);
			}
			else if (ObjectiveManual.IsObjectiveStepActive("pandemic", "stepC") && text == "Pandemic/Holmes_ISHO_03_log")
			{
				LogDataFile.SaveValue("pandemic", "stepC", 3);
				LogDataFile.SaveValue("pandemic", "stepD", 1);
				PushLogOntoPriorityMedicalQueue("Pandemic/Holmes_outro_02_log");
			}
			else if (ObjectiveManual.IsObjectiveStepActive("pandemic", "stepD") && text == "Pandemic/Holmes_outro_02_log")
			{
				LogDataFile.SaveValue("pandemic", "stepD", 3);
				LogDataFile.SaveValue("pandemic", "stepE", 3);
			}
			switch (text)
			{
			case "Pandemic/Holmes_ISHO_01_log":
			case "Pandemic/Holmes_ISHO_02_log":
			case "Pandemic/ISHO_DB_derelicts_log":
			case "Pandemic/ISHO_DB_ouposts_log":
			case "Pandemic/Holmes_Confession_log":
			case "Pandemic/Holmes_Obsession_log":
			case "Pandemic/Holmes_outro_02_log":
			{
				bool flag2 = LogDataFile.GetValue("pandemic", "noteA", 0) != 0;
				bool flag3 = LogDataFile.GetValue("pandemic", "noteB", 0) != 0;
				bool flag4 = LogDataFile.GetValue("pandemic", "noteC", 0) != 0;
				bool flag5 = LogDataFile.GetValue("pandemic", "noteD", 0) != 0;
				bool flag6 = LogDataFile.GetValue("pandemic", "noteE", 0) != 0;
				bool flag7 = LogDataFile.GetValue("pandemic", "noteF", 0) != 0;
				bool flag8 = LogDataFile.GetValue("pandemic", "noteG", 0) != 0;
				if (!flag2)
				{
					text2 = "noteA";
				}
				else if (!flag3)
				{
					text2 = "noteB";
				}
				else if (!flag4)
				{
					text2 = "noteC";
				}
				else if (!flag5)
				{
					text2 = "noteD";
				}
				else if (!flag6)
				{
					text2 = "noteE";
				}
				else if (!flag7)
				{
					text2 = "noteF";
				}
				else if (!flag8)
				{
					text2 = "noteG";
				}
				if (text2 != string.Empty)
				{
					LogDataFile.SaveValue("pandemic", text2, 4);
				}
				break;
			}
			}
			logInfo = GetStoryLogData(text);
			logInfo.GroupKeyBase = "OBJ";
			logInfo.LogHeaderData = GetLogHeader(revealedRoom, revealedRoomType, infestationCount, true);
			logInfo.LogHeaderData += "[Begin Communication]\n\n";
			logInfo.LogFooterData += "\n\n[End Communication]";
		}
		if (logInfo != null)
		{
			ReplaceVariables(ref logInfo);
		}
		if (logInfo != null && logInfo.GroupKeyBase == "OBJ")
		{
			BakeLog(logInfo, true);
			if (text2 != string.Empty)
			{
				LogDataFile.SaveValue(logInfo.GroupKey, "ITEM", string.Format("{0}_pandemic", text2));
			}
		}
		if (!string.IsNullOrEmpty(logInfo.LogHeaderData))
		{
			logInfo.LogHeaderData = string.Format("<color={0}>{1}</color> ", "#1aff11", logInfo.LogHeaderData);
		}
		if (!string.IsNullOrEmpty(logInfo.LogFooterData))
		{
			logInfo.LogFooterData = string.Format("<color={0}>{1}</color> ", "#1aff11", logInfo.LogFooterData);
		}
		return logInfo.LogHeaderData + logInfo.LogData + logInfo.LogFooterData;
	}

	public static void PushLogOntoPriorityMedicalQueue(string fileName)
	{
		string fileName2 = Path.GetFileName(fileName);
		if (LogDataFile.GetGroup("OBJ_", "FILE", fileName2) == string.Empty)
		{
			if (MedicalPriorityLogQueue == null)
			{
				MedicalPriorityLogQueue = new List<string>();
			}
			MedicalPriorityLogQueue.Add(fileName);
		}
	}

	public static string GetNextMilitaryLog(Room revealedRoom, RevealedRoomType revealedRoomType, string infestationCount, out bool isCorrupted)
	{
		isCorrupted = false;
		if (!isMilitaryQueueIntalized)
		{
			InitalizeMilitaryLogQueue();
		}
		string text = string.Empty;
		string text2 = string.Empty;
		LogInfo logInfo = null;
		int num = 50;
		if (GlobalSettings.GameState.ThePlayer.CurrentDockedDungeon.DungeonType == DungeonTypeEnum.Outpost)
		{
			num = 20;
		}
		bool flag = false;
		if (GalaxySaveFile.Get(GlobalSettings.GameState.ThePlayer.CurrentDockedDungeon.GroupKey, "px30", 0) != 0)
		{
			int count = MilitaryPriorityOutpostLogQueue.Count;
			for (int i = 0; i < count; i++)
			{
				if (MilitaryPriorityOutpostLogQueue[i] == "Super-Predator/SP_06_Log")
				{
					text = MilitaryPriorityOutpostLogQueue[i];
					MilitaryPriorityOutpostLogQueue.RemoveAt(i);
					flag = true;
				}
			}
		}
		if (flag || UnityEngine.Random.Range(0, 100) > num)
		{
			if (!flag)
			{
				if ((MilitaryPriorityLogQueue.Count > 0 || MilitaryPriorityOutpostLogQueue.Count > 0) && UnityEngine.Random.Range(0, 100) < 60)
				{
					if (!flag)
					{
						if (MilitaryPriorityLogQueue.Count > 0)
						{
							int index = UnityEngine.Random.Range(0, MilitaryPriorityLogQueue.Count);
							text = MilitaryPriorityLogQueue[index];
							MilitaryPriorityLogQueue.RemoveAt(index);
						}
						else if (GlobalSettings.GameState.ThePlayer.CurrentDockedDungeon.DungeonType == DungeonTypeEnum.Outpost && MilitaryPriorityOutpostLogQueue.Count > 0)
						{
							int index2 = UnityEngine.Random.Range(0, MilitaryPriorityOutpostLogQueue.Count);
							text = MilitaryPriorityOutpostLogQueue[index2];
							if (true)
							{
								MilitaryPriorityOutpostLogQueue.RemoveAt(index2);
							}
							else
							{
								isCorrupted = true;
								logInfo = new LogInfo("GENERATED", string.Empty);
								logInfo.LogHeaderData = GetGeneratedLog(revealedRoom, revealedRoomType, infestationCount);
							}
						}
						else
						{
							isCorrupted = true;
							logInfo = new LogInfo("GENERATED", string.Empty);
							logInfo.LogHeaderData = GetGeneratedLog(revealedRoom, revealedRoomType, infestationCount);
						}
					}
				}
				else if (MilitaryNormalDerelictLogQueue != null && GlobalSettings.GameState.ThePlayer.CurrentDockedDungeon.DungeonType == DungeonTypeEnum.Derelict && MilitaryNormalDerelictLogQueue.Count > 0)
				{
					int index3 = UnityEngine.Random.Range(0, MilitaryNormalDerelictLogQueue.Count);
					text = MilitaryNormalDerelictLogQueue[index3];
					MilitaryNormalDerelictLogQueue.RemoveAt(index3);
				}
				else if (GlobalSettings.GameState.ThePlayer.CurrentDockedDungeon.DungeonType == DungeonTypeEnum.Outpost && MilitaryNormalOutpostLogQueue.Count > 0)
				{
					int index4 = UnityEngine.Random.Range(0, MilitaryNormalOutpostLogQueue.Count);
					text = MilitaryNormalOutpostLogQueue[index4];
					MilitaryNormalOutpostLogQueue.RemoveAt(index4);
				}
				else
				{
					isCorrupted = true;
					logInfo = new LogInfo("GENERATED", string.Empty);
					logInfo.LogHeaderData = GetGeneratedLog(revealedRoom, revealedRoomType, infestationCount);
				}
			}
		}
		else
		{
			isCorrupted = true;
			logInfo = new LogInfo("GENERATED", string.Empty);
			logInfo.LogHeaderData = GetGeneratedLog(revealedRoom, revealedRoomType, infestationCount);
		}
		if (!string.IsNullOrEmpty(text))
		{
			if (ObjectiveManual.IsObjectiveStepActive("cosmic", "stepA") && text == "Cosmic Event/CE_A_Log")
			{
				LogDataFile.SaveValue("cosmic", "stepA", 3);
				LogDataFile.SaveValue("cosmic", "stepB", 1);
				PushLogOntoPriorityCosmicEventQueue("Cosmic Event/CE_C_Log");
			}
			else if (text == "Super-Predator/SP_Intro_Log")
			{
				LogDataFile.SaveValue("superpredator", "stepA", 1);
				PushLogOntoPriorityMilitaryQueue("Super-Predator/SP_03_Log");
				PushLogOntoNormalMilitaryQueue("Super-Predator/SP_Color_Derelict1_Log", DungeonTypeEnum.Derelict);
				PushLogOntoNormalMilitaryQueue("Super-Predator/SP_Color_Derelict2_Log", DungeonTypeEnum.Derelict);
				PushLogOntoNormalMilitaryQueue("Super-Predator/SP_Color_Derelict3_Log", DungeonTypeEnum.Derelict);
				PushLogOntoNormalMilitaryQueue("Super-Predator/SP_Color_Outposts1_Log", DungeonTypeEnum.Outpost);
				PushLogOntoNormalMilitaryQueue("Super-Predator/SP_Color_Outposts2_Log", DungeonTypeEnum.Outpost);
			}
			else if (ObjectiveManual.IsObjectiveStepActive("superpredator", "stepA") && text == "Super-Predator/SP_03_Log")
			{
				LogDataFile.SaveValue("superpredator", "stepA", 3);
				LogDataFile.SaveValue("superpredator", "stepB", 1);
				PushLogOntoPriorityOutpostMilitaryQueue("Super-Predator/SP_04_Log");
			}
			else if (ObjectiveManual.IsObjectiveStepActive("superpredator", "stepB") && text == "Super-Predator/SP_04_Log")
			{
				LogDataFile.SaveValue("superpredator", "stepB", 3);
				LogDataFile.SaveValue("superpredator", "stepC", 1);
			}
			else if (ObjectiveManual.IsObjectiveStepActive("superpredator", "stepC") && text == "Super-Predator/SP_05_Log")
			{
				LogDataFile.SaveValue("superpredator", "stepC", 3);
				LogDataFile.SaveValue("superpredator", "stepD", 1);
			}
			else if (ObjectiveManual.IsObjectiveStepActive("superpredator", "stepD") && text == "Super-Predator/SP_06_Log")
			{
				LogDataFile.SaveValue("superpredator", "stepD", 3);
				LogDataFile.SaveValue("superpredator", "stepE", 1);
			}
			else if (ObjectiveManual.IsObjectiveActive("superpredator"))
			{
				bool flag2 = false;
				switch (text)
				{
				case "Super-Predator/SP_Color_Derelict1_Log":
				case "Super-Predator/SP_Color_Derelict2_Log":
				case "Super-Predator/SP_Color_Derelict3_Log":
					if (GlobalSettings.GameState.ThePlayer.CurrentDockedDungeon.DungeonType == DungeonTypeEnum.Derelict)
					{
						flag2 = true;
					}
					break;
				case "Super-Predator/SP_Color_Outposts1_Log":
				case "Super-Predator/SP_Color_Outposts2_Log":
					if (GlobalSettings.GameState.ThePlayer.CurrentDockedDungeon.DungeonType == DungeonTypeEnum.Outpost)
					{
						flag2 = true;
					}
					break;
				}
				if (flag2)
				{
					bool flag3 = LogDataFile.GetValue("superpredator", "noteA", 0) != 0;
					bool flag4 = LogDataFile.GetValue("superpredator", "noteB", 0) != 0;
					bool flag5 = LogDataFile.GetValue("superpredator", "noteC", 0) != 0;
					bool flag6 = LogDataFile.GetValue("superpredator", "noteD", 0) != 0;
					bool flag7 = LogDataFile.GetValue("superpredator", "noteE", 0) != 0;
					bool flag8 = LogDataFile.GetValue("superpredator", "noteF", 0) != 0;
					if (!flag3)
					{
						text2 = "noteA";
					}
					else if (!flag4)
					{
						text2 = "noteB";
					}
					else if (!flag5)
					{
						text2 = "noteC";
					}
					else if (!flag6)
					{
						text2 = "noteD";
					}
					else if (!flag7)
					{
						text2 = "noteE";
					}
					else if (!flag8)
					{
						text2 = "noteF";
					}
					if (text2 != string.Empty)
					{
						LogDataFile.SaveValue("superpredator", text2, 4);
					}
				}
			}
			logInfo = GetStoryLogData(text);
			logInfo.GroupKeyBase = "OBJ";
			logInfo.LogHeaderData = GetLogHeader(revealedRoom, revealedRoomType, infestationCount, true);
			logInfo.LogHeaderData += "[Begin Communication]\n\n";
			logInfo.LogFooterData += "\n\n[End Communication]";
		}
		if (logInfo != null)
		{
			ReplaceVariables(ref logInfo);
		}
		if (logInfo != null && logInfo.GroupKeyBase == "OBJ")
		{
			BakeLog(logInfo, true);
			if (text2 != string.Empty)
			{
				LogDataFile.SaveValue(logInfo.GroupKey, "ITEM", string.Format("{0}_superpredator", text2));
			}
		}
		if (!string.IsNullOrEmpty(logInfo.LogHeaderData))
		{
			logInfo.LogHeaderData = string.Format("<color={0}>{1}</color> ", "#1aff11", logInfo.LogHeaderData);
		}
		if (!string.IsNullOrEmpty(logInfo.LogFooterData))
		{
			logInfo.LogFooterData = string.Format("<color={0}>{1}</color> ", "#1aff11", logInfo.LogFooterData);
		}
		return logInfo.LogHeaderData + logInfo.LogData + logInfo.LogFooterData;
	}

	public static string GetNextGreyGooLog(Room revealedRoom, RevealedRoomType revealedRoomType, string infestationCount, out bool isCorrupted)
	{
		isCorrupted = false;
		if (!isGreyGooQueueIntalized)
		{
			InitalizeGreyGooLogQueue();
		}
		string text = string.Empty;
		string text2 = string.Empty;
		LogInfo logInfo = null;
		int num = 50;
		if (GlobalSettings.GameState.ThePlayer.CurrentDockedDungeon.DungeonType == DungeonTypeEnum.Outpost)
		{
			num = 20;
		}
		if (UnityEngine.Random.Range(0, 100) > num)
		{
			if (GreyGooPriorityLogQueue != null && GreyGooPriorityLogQueue.Count > 0 && UnityEngine.Random.Range(0, 100) < 60)
			{
				int index = UnityEngine.Random.Range(0, GreyGooPriorityLogQueue.Count);
				text = GreyGooPriorityLogQueue[index];
				GreyGooPriorityLogQueue.RemoveAt(index);
			}
			else if (GreyGooNormalLogQueue != null && GreyGooNormalLogQueue.Count > 0)
			{
				int index2 = UnityEngine.Random.Range(0, GreyGooNormalLogQueue.Count);
				text = GreyGooNormalLogQueue[index2];
				GreyGooNormalLogQueue.RemoveAt(index2);
			}
			else
			{
				isCorrupted = true;
				logInfo = new LogInfo("GENERATED", string.Empty);
				logInfo.LogHeaderData = GetGeneratedLog(revealedRoom, revealedRoomType, infestationCount);
			}
		}
		else
		{
			isCorrupted = true;
			logInfo = new LogInfo("GENERATED", string.Empty);
			logInfo.LogHeaderData = GetGeneratedLog(revealedRoom, revealedRoomType, infestationCount);
		}
		if (!string.IsNullOrEmpty(text))
		{
			if (ObjectiveManual.IsObjectiveStepActive("greygoo", "stepA") && text == "Grey Goo/GG_C_Log")
			{
				LogDataFile.SaveValue("greygoo", "stepA", 3);
				LogDataFile.SaveValue("greygoo", "stepB", 1);
			}
			if (ObjectiveManual.IsObjectiveActive("greygoo"))
			{
				bool flag = false;
				switch (text)
				{
				case "Grey Goo/GG_ColorB1_Log":
				case "Grey Goo/GG_ColorB2_Log":
				case "Grey Goo/GG_ColorB3_Log":
				case "Grey Goo/GG_ColorB4_Log":
					flag = true;
					break;
				}
				if (flag)
				{
					bool flag2 = LogDataFile.GetValue("greygoo", "noteA", 0) != 0;
					bool flag3 = LogDataFile.GetValue("greygoo", "noteB", 0) != 0;
					bool flag4 = LogDataFile.GetValue("greygoo", "noteC", 0) != 0;
					bool flag5 = LogDataFile.GetValue("greygoo", "noteD", 0) != 0;
					if (!flag2)
					{
						text2 = "noteA";
					}
					else if (!flag3)
					{
						text2 = "noteB";
					}
					else if (!flag4)
					{
						text2 = "noteC";
					}
					else if (!flag5)
					{
						text2 = "noteD";
					}
					if (text2 != string.Empty)
					{
						LogDataFile.SaveValue("greygoo", text2, 4);
					}
				}
			}
			logInfo = GetStoryLogData(text);
			logInfo.GroupKeyBase = "OBJ";
			logInfo.LogHeaderData = GetLogHeader(revealedRoom, revealedRoomType, infestationCount, true);
			logInfo.LogHeaderData += "[Begin Communication]\n\n";
			logInfo.LogFooterData += "\n\n[End Communication]";
		}
		if (logInfo != null)
		{
			ReplaceVariables(ref logInfo);
		}
		if (logInfo != null && logInfo.GroupKeyBase == "OBJ")
		{
			BakeLog(logInfo, true);
			if (text2 != string.Empty)
			{
				LogDataFile.SaveValue(logInfo.GroupKey, "ITEM", string.Format("{0}_greygoo", text2));
			}
		}
		if (!string.IsNullOrEmpty(logInfo.LogHeaderData))
		{
			logInfo.LogHeaderData = string.Format("<color={0}>{1}</color> ", "#1aff11", logInfo.LogHeaderData);
		}
		if (!string.IsNullOrEmpty(logInfo.LogFooterData))
		{
			logInfo.LogFooterData = string.Format("<color={0}>{1}</color> ", "#1aff11", logInfo.LogFooterData);
		}
		return logInfo.LogHeaderData + logInfo.LogData + logInfo.LogFooterData;
	}

	public static string GetNextCosmicEventLog(Room revealedRoom, RevealedRoomType revealedRoomType, string infestationCount, out bool isCorrupted)
	{
		isCorrupted = false;
		if (!isCosmicEventQueueIntalized)
		{
			InitalizeCosmicEventLogQueue();
		}
		string text = string.Empty;
		string text2 = string.Empty;
		LogInfo logInfo = null;
		int num = 50;
		if (GlobalSettings.GameState.ThePlayer.CurrentDockedDungeon.DungeonType == DungeonTypeEnum.Outpost)
		{
			num = 20;
		}
		if (UnityEngine.Random.Range(0, 100) > num)
		{
			if (CosmicEventPriorityLogQueue != null && CosmicEventPriorityLogQueue.Count > 0 && UnityEngine.Random.Range(0, 100) < 60)
			{
				int index = UnityEngine.Random.Range(0, CosmicEventPriorityLogQueue.Count);
				text = CosmicEventPriorityLogQueue[index];
				CosmicEventPriorityLogQueue.RemoveAt(index);
			}
			else if (CosmicEventNormalLogQueue != null && CosmicEventNormalLogQueue.Count > 0)
			{
				int index2 = UnityEngine.Random.Range(0, CosmicEventNormalLogQueue.Count);
				text = CosmicEventNormalLogQueue[index2];
				CosmicEventNormalLogQueue.RemoveAt(index2);
			}
			else
			{
				isCorrupted = true;
				logInfo = new LogInfo("GENERATED", string.Empty);
				logInfo.LogHeaderData = GetGeneratedLog(revealedRoom, revealedRoomType, infestationCount);
			}
		}
		else
		{
			isCorrupted = true;
			logInfo = new LogInfo("GENERATED", string.Empty);
			logInfo.LogHeaderData = GetGeneratedLog(revealedRoom, revealedRoomType, infestationCount);
		}
		if (!string.IsNullOrEmpty(text))
		{
			if (ObjectiveManual.IsObjectiveStepActive("cosmic", "stepB") && text == "Cosmic Event/CE_C_Log")
			{
				LogDataFile.SaveValue("cosmic", "stepB", 3);
				LogDataFile.SaveValue("cosmic", "stepC", 1);
			}
			if (ObjectiveManual.IsObjectiveActive("cosmic"))
			{
				bool flag = false;
				switch (text)
				{
				case "Cosmic Event/CE_ColorB1_Log":
				case "Cosmic Event/CE_ColorB2_Log":
				case "Cosmic Event/CE_ColorB3_Log":
				case "Cosmic Event/CE_ColorB4_Log":
					flag = true;
					break;
				}
				if (flag)
				{
					bool flag2 = LogDataFile.GetValue("cosmic", "noteA", 0) != 0;
					bool flag3 = LogDataFile.GetValue("cosmic", "noteB", 0) != 0;
					bool flag4 = LogDataFile.GetValue("cosmic", "noteC", 0) != 0;
					bool flag5 = LogDataFile.GetValue("cosmic", "noteD", 0) != 0;
					if (!flag2)
					{
						text2 = "noteA";
					}
					else if (!flag3)
					{
						text2 = "noteB";
					}
					else if (!flag4)
					{
						text2 = "noteC";
					}
					else if (!flag5)
					{
						text2 = "noteD";
					}
					if (text2 != string.Empty)
					{
						LogDataFile.SaveValue("cosmic", text2, 4);
					}
				}
			}
			logInfo = GetStoryLogData(text);
			logInfo.GroupKeyBase = "OBJ";
			logInfo.LogHeaderData = GetLogHeader(revealedRoom, revealedRoomType, infestationCount, true);
			logInfo.LogHeaderData += "[Begin Communication]\n\n";
			logInfo.LogFooterData += "\n\n[End Communication]";
		}
		if (logInfo != null)
		{
			ReplaceVariables(ref logInfo);
		}
		if (logInfo != null && logInfo.GroupKeyBase == "OBJ")
		{
			BakeLog(logInfo, true);
			if (text2 != string.Empty)
			{
				LogDataFile.SaveValue(logInfo.GroupKey, "ITEM", string.Format("{0}_cosmic", text2));
			}
		}
		if (!string.IsNullOrEmpty(logInfo.LogHeaderData))
		{
			logInfo.LogHeaderData = string.Format("<color={0}>{1}</color> ", "#1aff11", logInfo.LogHeaderData);
		}
		if (!string.IsNullOrEmpty(logInfo.LogFooterData))
		{
			logInfo.LogFooterData = string.Format("<color={0}>{1}</color> ", "#1aff11", logInfo.LogFooterData);
		}
		return logInfo.LogHeaderData + logInfo.LogData + logInfo.LogFooterData;
	}

	public static string GetNextSingularityLog(Room revealedRoom, RevealedRoomType revealedRoomType, string infestationCount, out bool isCorrupted)
	{
		isCorrupted = false;
		if (!isSingularityQueueIntalized)
		{
			InitalizeSingularityLogQueue();
		}
		string text = string.Empty;
		string text2 = string.Empty;
		LogInfo logInfo = null;
		int num = 50;
		if (GlobalSettings.GameState.ThePlayer.CurrentDockedDungeon.DungeonType == DungeonTypeEnum.Outpost)
		{
			num = 20;
		}
		if (UnityEngine.Random.Range(0, 100) > num)
		{
			if (SingularityPriorityLogQueue != null && SingularityPriorityLogQueue.Count > 0 && UnityEngine.Random.Range(0, 100) < 60)
			{
				int index = UnityEngine.Random.Range(0, SingularityPriorityLogQueue.Count);
				text = SingularityPriorityLogQueue[index];
				SingularityPriorityLogQueue.RemoveAt(index);
			}
			else if (SingularityNormalLogQueue != null && SingularityNormalLogQueue.Count > 0)
			{
				int index2 = UnityEngine.Random.Range(0, SingularityNormalLogQueue.Count);
				text = SingularityNormalLogQueue[index2];
				SingularityNormalLogQueue.RemoveAt(index2);
			}
			else
			{
				isCorrupted = true;
				logInfo = new LogInfo("GENERATED", string.Empty);
				logInfo.LogHeaderData = GetGeneratedLog(revealedRoom, revealedRoomType, infestationCount);
			}
		}
		else
		{
			isCorrupted = true;
			logInfo = new LogInfo("GENERATED", string.Empty);
			logInfo.LogHeaderData = GetGeneratedLog(revealedRoom, revealedRoomType, infestationCount);
		}
		if (!string.IsNullOrEmpty(text))
		{
			if (ObjectiveManual.IsObjectiveStepActive("singularity", "stepA") && text == "Singularity/SING_C_Log")
			{
				LogDataFile.SaveValue("singularity", "stepA", 3);
				LogDataFile.SaveValue("singularity", "stepB", 1);
				PushLogOntoPrioritySigularityQueue("Singularity/SING_D_Log");
				PushLogOntoNormalSigularityQueue("Singularity/SING_ColorD1_Log");
				PushLogOntoNormalSigularityQueue("Singularity/SING_ColorD2_Log");
				PushLogOntoNormalSigularityQueue("Singularity/SING_ColorD3_Log");
				PushLogOntoNormalSigularityQueue("Singularity/SING_ColorD4_Log");
			}
			else if (ObjectiveManual.IsObjectiveStepActive("singularity", "stepB") && text == "Singularity/SING_D_Log")
			{
				LogDataFile.SaveValue("singularity", "stepB", 3);
				LogDataFile.SaveValue("singularity", "stepC", 1);
				PushLogOntoPrioritySigularityQueue("Singularity/SING_E_Log");
			}
			else if (ObjectiveManual.IsObjectiveStepActive("singularity", "stepC") && text == "Singularity/SING_E_Log")
			{
				LogDataFile.SaveValue("singularity", "stepC", 3);
				LogDataFile.SaveValue("singularity", "stepD", 1);
			}
			if (ObjectiveManual.IsObjectiveActive("singularity"))
			{
				bool flag = false;
				switch (text)
				{
				case "Singularity/SING_ColorB1_Log":
				case "Singularity/SING_ColorB2_Log":
				case "Singularity/SING_ColorB3_Log":
				case "Singularity/SING_ColorD1_Log":
				case "Singularity/SING_ColorD2_Log":
				case "Singularity/SING_ColorD3_Log":
				case "Singularity/SING_ColorD4_Log":
					flag = true;
					break;
				}
				if (flag)
				{
					bool flag2 = LogDataFile.GetValue("singularity", "noteA", 0) != 0;
					bool flag3 = LogDataFile.GetValue("singularity", "noteB", 0) != 0;
					bool flag4 = LogDataFile.GetValue("singularity", "noteC", 0) != 0;
					bool flag5 = LogDataFile.GetValue("singularity", "noteD", 0) != 0;
					bool flag6 = LogDataFile.GetValue("singularity", "noteE", 0) != 0;
					bool flag7 = LogDataFile.GetValue("singularity", "noteF", 0) != 0;
					bool flag8 = LogDataFile.GetValue("singularity", "noteG", 0) != 0;
					if (!flag2)
					{
						text2 = "noteA";
					}
					else if (!flag3)
					{
						text2 = "noteB";
					}
					else if (!flag4)
					{
						text2 = "noteC";
					}
					else if (!flag5)
					{
						text2 = "noteD";
					}
					else if (!flag6)
					{
						text2 = "noteE";
					}
					else if (!flag7)
					{
						text2 = "noteF";
					}
					else if (!flag8)
					{
						text2 = "noteG";
					}
					if (text2 != string.Empty)
					{
						LogDataFile.SaveValue("singularity", text2, 4);
					}
				}
			}
			logInfo = GetStoryLogData(text);
			logInfo.GroupKeyBase = "OBJ";
			logInfo.LogHeaderData = GetLogHeader(revealedRoom, revealedRoomType, infestationCount, true);
			logInfo.LogHeaderData += "[Begin Communication]\n\n";
			logInfo.LogFooterData += "\n\n[End Communication]";
		}
		if (logInfo != null)
		{
			ReplaceVariables(ref logInfo);
		}
		if (logInfo != null && logInfo.GroupKeyBase == "OBJ")
		{
			BakeLog(logInfo, true);
			if (text2 != string.Empty)
			{
				LogDataFile.SaveValue(logInfo.GroupKey, "ITEM", string.Format("{0}_singularity", text2));
			}
		}
		if (!string.IsNullOrEmpty(logInfo.LogHeaderData))
		{
			logInfo.LogHeaderData = string.Format("<color={0}>{1}</color> ", "#1aff11", logInfo.LogHeaderData);
		}
		if (!string.IsNullOrEmpty(logInfo.LogFooterData))
		{
			logInfo.LogFooterData = string.Format("<color={0}>{1}</color> ", "#1aff11", logInfo.LogFooterData);
		}
		return logInfo.LogHeaderData + logInfo.LogData + logInfo.LogFooterData;
	}

	public static void PushLogOntoPriorityMilitaryQueue(string fileName)
	{
		string fileName2 = Path.GetFileName(fileName);
		if (LogDataFile.GetGroup("OBJ_", "FILE", fileName2) == string.Empty)
		{
			if (MilitaryPriorityLogQueue == null)
			{
				MilitaryPriorityLogQueue = new List<string>();
			}
			MilitaryPriorityLogQueue.Add(fileName);
		}
	}

	public static void PushLogOntoPriorityOutpostMilitaryQueue(string fileName)
	{
		string fileName2 = Path.GetFileName(fileName);
		if (LogDataFile.GetGroup("OBJ_", "FILE", fileName2) == string.Empty)
		{
			if (MilitaryPriorityOutpostLogQueue == null)
			{
				MilitaryPriorityOutpostLogQueue = new List<string>();
			}
			MilitaryPriorityOutpostLogQueue.Add(fileName);
		}
	}

	public static void PushLogOntoNormalMilitaryQueue(string fileName, DungeonTypeEnum objectType)
	{
		string fileName2 = Path.GetFileName(fileName);
		if (!(LogDataFile.GetGroup("OBJ_", "FILE", fileName2) == string.Empty))
		{
			return;
		}
		switch (objectType)
		{
		case DungeonTypeEnum.Derelict:
			if (MilitaryNormalDerelictLogQueue == null)
			{
				MilitaryNormalDerelictLogQueue = new List<string>();
			}
			MilitaryNormalDerelictLogQueue.Add(fileName);
			break;
		case DungeonTypeEnum.Outpost:
			if (MilitaryNormalOutpostLogQueue == null)
			{
				MilitaryNormalOutpostLogQueue = new List<string>();
			}
			MilitaryNormalOutpostLogQueue.Add(fileName);
			break;
		default:
			Debug.LogWarning("Invalid ship type categorization pushed into PushLogOntoNormalMilitaryQueue()");
			break;
		}
	}

	public static void PushLogOntoPriorityGreyGooQueue(string fileName)
	{
		string fileName2 = Path.GetFileName(fileName);
		if (LogDataFile.GetGroup("OBJ_", "FILE", fileName2) == string.Empty)
		{
			if (GreyGooPriorityLogQueue == null)
			{
				GreyGooPriorityLogQueue = new List<string>();
			}
			GreyGooPriorityLogQueue.Add(fileName);
		}
	}

	public static void PushLogOntoPriorityCosmicEventQueue(string fileName)
	{
		string fileName2 = Path.GetFileName(fileName);
		if (LogDataFile.GetGroup("OBJ_", "FILE", fileName2) == string.Empty)
		{
			if (CosmicEventPriorityLogQueue == null)
			{
				CosmicEventPriorityLogQueue = new List<string>();
			}
			CosmicEventPriorityLogQueue.Add(fileName);
		}
	}

	public static void PushLogOntoPrioritySigularityQueue(string fileName)
	{
		string fileName2 = Path.GetFileName(fileName);
		if (LogDataFile.GetGroup("OBJ_", "FILE", fileName2) == string.Empty)
		{
			if (SingularityPriorityLogQueue == null)
			{
				SingularityPriorityLogQueue = new List<string>();
			}
			SingularityPriorityLogQueue.Add(fileName);
		}
	}

	public static void PushLogOntoNormalSigularityQueue(string fileName)
	{
		string fileName2 = Path.GetFileName(fileName);
		if (LogDataFile.GetGroup("OBJ_", "FILE", fileName2) == string.Empty)
		{
			if (SingularityNormalLogQueue == null)
			{
				SingularityNormalLogQueue = new List<string>();
			}
			SingularityNormalLogQueue.Add(fileName);
		}
	}

	private static string GetStoryUniversePrefix(int storyGroup)
	{
		return string.Format("storyUniverse_{0:00}_", storyGroup);
	}

	private static string GetStoryDuskerPrefix(int storyGroup)
	{
		return string.Format("storyDusker_{0:00}_", storyGroup);
	}

	private static List<string> GetEntireShipsLogDirectory()
	{
		if (_entireShipsLogsDirectory == null)
		{
			_entireShipsLogsDirectory = new List<string>();
			TextAsset textAsset = ResourceManager.LoadAsset<TextAsset>("Data/ShipsLogs/ships_log_directory");
			string[] array = textAsset.text.Split(new string[2] { "\n", "\r" }, StringSplitOptions.RemoveEmptyEntries);
			foreach (string item in array)
			{
				_entireShipsLogsDirectory.Add(item);
			}
		}
		return _entireShipsLogsDirectory;
	}

	public static string GetStoryLogText(string filename, bool bake)
	{
		LogInfo logInfo = GetStoryLogData(filename);
		if (logInfo != null)
		{
			if (logInfo != null)
			{
				ReplaceVariables(ref logInfo);
			}
			if (bake && logInfo != null)
			{
				BakeLog(logInfo, false);
			}
			return logInfo.LogData;
		}
		return string.Empty;
	}

	private static LogInfo GetStoryLogData(string filename)
	{
		string resourcePath = "Data/ShipsLogs/" + filename;
		string empty = string.Empty;
		if (!GlobalSettings.LogFilesAlreadyViewed.Contains(filename))
		{
			GlobalSettings.LogFilesAlreadyViewed.Add(filename);
			GameSaveFile.SaveStoryFilesReadList(GlobalSettings.LogFilesAlreadyViewed);
		}
		try
		{
			TextAsset textAsset = ResourceManager.LoadAsset<TextAsset>(resourcePath);
			empty = textAsset.text;
		}
		catch (Exception ex)
		{
			Debug.LogError(string.Format("Could not find story entry {0}; error: {1}", filename, ex.Message));
			return null;
		}
		return new LogInfo(filename, empty, LogTypeEnum.Log);
	}

	private static string GetGeneratedLog(Room revealedRoom, RevealedRoomType revealedRoomType, string infestationCount)
	{
		string logHeader = GetLogHeader(revealedRoom, revealedRoomType, infestationCount, false);
		for (int i = 0; i < 100; i++)
		{
			if (!_historyOfGeneratedLogText.Contains(logHeader))
			{
				break;
			}
			logHeader = GetLogHeader(revealedRoom, revealedRoomType, infestationCount, false);
		}
		logHeader += "[No uncorrupted communications found]";
		_historyOfGeneratedLogText.Add(logHeader);
		return logHeader;
	}

	private static string GetLogHeader(Room revealedRoom, RevealedRoomType revealedRoomType, string infestationCount, bool hasUncorruptedLog)
	{
		string empty = string.Empty;
		string directive;
		string cargo;
		if (!GetDirectiveAndCargoByShipType(out directive, out cargo))
		{
			GetRandomDirectiveAndCargo(out directive, out cargo);
		}
		int num = _random.Next(1, 11);
		int num2 = _random.Next(1, 11);
		string text = null;
		string empty2 = string.Empty;
		if (revealedRoom != null)
		{
			switch (revealedRoomType)
			{
			case RevealedRoomType.DeadDrone:
			case RevealedRoomType.Loot:
				empty2 += string.Format("{0} found in room {1}. Updating Schematic.", CommonMethods.GetRevealedRoomDescription(revealedRoomType), revealedRoom.Label);
				break;
			default:
				empty2 += "Inconclusive";
				break;
			}
		}
		else
		{
			empty2 += "Inconclusive";
		}
		string text2 = string.Format("{0}", (GlobalSettings.GameState.ThePlayer.CurrentDockedDungeon == null) ? HullIntegrity.None : GlobalSettings.GameState.ThePlayer.CurrentDockedDungeon.HullIntegrity);
		string text3 = string.Format("{0} ({1})", (GlobalSettings.GameState.ThePlayer.CurrentDockedDungeon == null) ? "?" : GlobalSettings.GameState.ThePlayer.CurrentDockedDungeon.Age.ToString(), (GlobalSettings.GameState.ThePlayer.CurrentDockedDungeon == null) ? "?" : GlobalSettings.GameState.ThePlayer.CurrentDockedDungeon.AgeText);
		int minValue = 3;
		int maxValue = 7;
		float min = 0f;
		float max = 0f;
		switch (GlobalSettings.GameState.ThePlayer.CurrentDockedDungeon.DungeonType)
		{
		case DungeonTypeEnum.Derelict:
			empty = "derelict";
			minValue = 5000;
			maxValue = 100000;
			min = 0.8f;
			max = 0.98f;
			break;
		case DungeonTypeEnum.Station:
			empty = "station";
			minValue = 5000;
			maxValue = 100000;
			min = 0.8f;
			max = 0.98f;
			break;
		case DungeonTypeEnum.Outpost:
			empty = "outpost";
			minValue = 100000;
			maxValue = 500000;
			min = 0.8f;
			max = 0.98f;
			break;
		case DungeonTypeEnum.AutoTrade:
			empty = "trading";
			break;
		default:
		{
			empty = GetRandomShipName();
			string shipClass = GetShipClass();
			text = string.Format(">[SCANNING]...{6}\n> Infestation types detected: {7}\n> Hull integrity: {8}, Age: {9}\n> Name: {0}\n> Class: {1}\n> Directive: {2}\n> Crew: {3} Hold: {4} (Rigel System: Sector {5})\n\n\n", empty, shipClass, directive, num, cargo, num2, empty2, infestationCount, text2, text3);
			break;
		}
		}
		if (text == null)
		{
			text = "\n======== Initial Vessel Report ========\n";
			string text4 = GlobalSettings.GameState.ThePlayer.CurrentDockedDungeon.Definition.Key.name;
			if (GlobalSettings.GameState.ThePlayer.CurrentDockedDungeon.Definition.Value != null)
			{
				text4 = text4 + " " + GlobalSettings.GameState.ThePlayer.CurrentDockedDungeon.Definition.Value.name;
			}
			text += string.Format("> [SCANNING]...{4}\n> Infestation types detected: {5}\n> Hull integrity: {6}, Age: {7}\n> Name: [{0}:this.this.this]\n> Class: {8},  Directive: {1}\n> Crew: {2},  Hold: {3}\n\n", empty, directive, num, cargo, empty2, infestationCount, text2, text3, text4);
		}
		int num3 = _random.Next(minValue, maxValue);
		int num4 = ((!hasUncorruptedLog) ? num3 : ((int)(UnityEngine.Random.Range(min, max) * (float)num3)));
		return text + string.Format("{0} communications found in archive, {1} corrupted\n\n", num3, num4);
	}

	private static string GetShipClass()
	{
		string result = "<n/a>";
		if (GlobalSettings.GameState.ThePlayer != null)
		{
			result = GlobalSettings.GameState.ThePlayer.CurrentDockedDungeon.DisplayName;
		}
		return result;
	}

	private static string GetRandomShipName()
	{
		if (_availableShipNames == null || _availableShipNames.Count == 0)
		{
			_availableShipNames = new List<string>();
			TextAsset textAsset = ResourceManager.LoadAsset<TextAsset>("Data/ShipsLogs/ship_name_dictionary");
			_availableShipNames.AddRange(textAsset.text.Split(new char[2] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries));
		}
		string text = CommonMethods.PickRandomItem(_availableShipNames, _random);
		_availableShipNames.Remove(text);
		return text;
	}

	private static bool GetDirectiveAndCargoByShipType(out string directive, out string cargo)
	{
		directive = string.Empty;
		cargo = string.Empty;
		switch (GlobalSettings.GameState.ThePlayer.CurrentDockedDungeon.Definition.Key.name)
		{
		case "Military":
		{
			List<string> sourceList27 = new List<string>(new string[7] { "Sector patrol", "Reconnaisance", "On standby", "Tactical exercises", "Classified", "Command ship", "Blockading" });
			directive = CommonMethods.PickRandomItem(sourceList27, _random);
			List<string> sourceList28 = new List<string>(new string[4] { "Multiple magazines", "Landing craft", "Unknown", "Classified" });
			cargo = CommonMethods.PickRandomItem(sourceList28, _random);
			return true;
		}
		case "Space station":
		{
			List<string> sourceList25 = new List<string>(new string[5] { "Commerce center", "Equipment storage depot", "Pleasure port", "Satellite control center", "Communication relay" });
			directive = CommonMethods.PickRandomItem(sourceList25, _random);
			List<string> sourceList26 = new List<string>(new string[3] { "Commercial databanks", "Unknown", "Transfer cargo" });
			cargo = CommonMethods.PickRandomItem(sourceList26, _random);
			return true;
		}
		case "Fuel Depot":
		{
			List<string> sourceList23 = new List<string>(new string[4] { "Refinery", "Collection facility", "Commercial distribution", "Refueling station" });
			directive = CommonMethods.PickRandomItem(sourceList23, _random);
			List<string> sourceList24 = new List<string>(new string[4] { "Class 3 chemical compounds", "Radiating equipment", "Refining materials", "Unknown" });
			cargo = CommonMethods.PickRandomItem(sourceList24, _random);
			return true;
		}
		case "Salvage":
		{
			List<string> sourceList21 = new List<string>(new string[4] { "Shipbreaker", "Repairs and maintenance", "Potentially illicit", "Recycling" });
			directive = CommonMethods.PickRandomItem(sourceList21, _random);
			List<string> sourceList22 = new List<string>(new string[4] { "Heavy metals", "Random junk", "Unknown", "Electronics" });
			cargo = CommonMethods.PickRandomItem(sourceList22, _random);
			return true;
		}
		case "MUTEKI":
		{
			List<string> sourceList19 = new List<string>(new string[5] { "Personnel transport", "Research vessel", "Data transfer", "Classified", "Corporate espionage" });
			directive = CommonMethods.PickRandomItem(sourceList19, _random);
			List<string> sourceList20 = new List<string>(new string[5] { "Private databanks", "Unknown", "Classified", "Research equipment", "Electronics" });
			cargo = CommonMethods.PickRandomItem(sourceList20, _random);
			return true;
		}
		case "Private":
		{
			List<string> sourceList17 = new List<string>(new string[5] { "Luxury vessel", "Passenger transport", "Personal yacht", "Bounty hunter", "Exploration" });
			directive = CommonMethods.PickRandomItem(sourceList17, _random);
			List<string> sourceList18 = new List<string>(new string[3] { "Personal effects", "Unknown", "Various supplies" });
			cargo = CommonMethods.PickRandomItem(sourceList18, _random);
			return true;
		}
		case "Barge":
		{
			List<string> sourceList15 = new List<string>(new string[5] { "Heavy cargo transport", "Commercial shipments", "Shipyard delivery", "General transport", "Equipment transfer" });
			directive = CommonMethods.PickRandomItem(sourceList15, _random);
			List<string> sourceList16 = new List<string>(new string[4] { "Finished goods", "Commercial goods", "Raw materials", "Unknown" });
			cargo = CommonMethods.PickRandomItem(sourceList16, _random);
			return true;
		}
		case "Medical":
		{
			List<string> sourceList13 = new List<string>(new string[4] { "Hospital ship", "Patient transfer", "Relief vessel", "Fleet support" });
			directive = CommonMethods.PickRandomItem(sourceList13, _random);
			List<string> sourceList14 = new List<string>(new string[4] { "Medical supplies", "Surgical robotic equipment", "Unknown", "Surgical supplies" });
			cargo = CommonMethods.PickRandomItem(sourceList14, _random);
			return true;
		}
		case "Government":
		{
			List<string> sourceList11 = new List<string>(new string[6] { "Prisoner transport", "Civic enforcement", "Personnel transport", "Diplomatic vessel", "Classified", "Espionage" });
			directive = CommonMethods.PickRandomItem(sourceList11, _random);
			List<string> sourceList12 = new List<string>(new string[4] { "Personal effects", "Unknown", "Classified", "Various supplies" });
			cargo = CommonMethods.PickRandomItem(sourceList12, _random);
			return true;
		}
		case "Industrial Outpost":
		{
			List<string> sourceList9 = new List<string>(new string[5] { "Heavy manufacturing", "Heavy metal smelting", "Large-scale manufacturing", "Raw materials production", "Robotics center" });
			directive = CommonMethods.PickRandomItem(sourceList9, _random);
			List<string> sourceList10 = new List<string>(new string[4] { "Robotic equipment", "Raw materials", "Outbound shipment", "Heavy machinery" });
			cargo = CommonMethods.PickRandomItem(sourceList10, _random);
			return true;
		}
		case "Mining Outpost":
		{
			List<string> sourceList7 = new List<string>(new string[5] { "Asteroid retrieval and breakdown", "Core sampling and excavation", "Subsurface tunnel outlet", "Heavy metal extraction", "Heavy equipment storage" });
			directive = CommonMethods.PickRandomItem(sourceList7, _random);
			List<string> sourceList8 = new List<string>(new string[4] { "Excavating equipment", "Demolitions", "Heavy machinery", "Outbound shipment" });
			cargo = CommonMethods.PickRandomItem(sourceList8, _random);
			return true;
		}
		case "Military Outpost":
		{
			List<string> sourceList5 = new List<string>(new string[5] { "Patrol way-station", "Recruitment center", "Fleet logistics control", "Munitions storage", "Weapons depot" });
			directive = CommonMethods.PickRandomItem(sourceList5, _random);
			List<string> sourceList6 = new List<string>(new string[4] { "Ammunition", "Unknown", "Classified", "Communications equipment" });
			cargo = CommonMethods.PickRandomItem(sourceList6, _random);
			return true;
		}
		case "Medical Outpost":
		{
			List<string> sourceList3 = new List<string>(new string[4] { "Private hospital", "Patient transfer station", "Disease control center", "Classified" });
			directive = CommonMethods.PickRandomItem(sourceList3, _random);
			List<string> sourceList4 = new List<string>(new string[4] { "Medical supplies", "Surgical robotic equipment", "Unknown", "Surgical supplies" });
			cargo = CommonMethods.PickRandomItem(sourceList4, _random);
			return true;
		}
		case "Research Outpost":
		{
			List<string> sourceList = new List<string>(new string[4] { "Stellar monitoring", "Deep space sensor relay", "Anomalous event detection", "Quantum routing refinement" });
			directive = CommonMethods.PickRandomItem(sourceList, _random);
			List<string> sourceList2 = new List<string>(new string[4] { "Unknown", "Classified", "Research equipment", "Unstable compounds" });
			cargo = CommonMethods.PickRandomItem(sourceList2, _random);
			return true;
		}
		default:
			return false;
		}
	}

	private static void GetRandomDirectiveAndCargo(out string directive, out string cargo)
	{
		List<string> sourceList = new List<string>(new string[8] { "Prisoner Transport", "Exploration", "Military Patrol", "Intelligence", "Royal Transport", "Transporting Goods", "Bounty Hunting", "Pirate Vessel" });
		directive = CommonMethods.PickRandomItem(sourceList, _random);
		switch (directive)
		{
		case "Prisoner Transport":
			cargo = string.Format("{0} prisoners", _random.Next(10, 91));
			break;
		case "Exploration":
			cargo = string.Format("{0} scientists", _random.Next(3, 20));
			break;
		case "Military Patrol":
		case "Intelligence":
			cargo = string.Format("{0} government employees", _random.Next(3, 20));
			break;
		case "Transporting Goods":
			cargo = string.Format("{0} units of various supplies", _random.Next(20, 99));
			break;
		default:
			cargo = "Unknown";
			break;
		}
	}

	private static bool ReplaceVariables(ref LogInfo logInfo)
	{
		string text = logInfo.LogHeaderData;
		string text2 = logInfo.LogData;
		bool flag = ReplaceVariables(ref text);
		bool result = ReplaceVariables(ref text2);
		logInfo.LogHeaderData = text;
		logInfo.LogData = text2;
		return result;
	}

	public static bool ReplaceVariables(ref string text)
	{
		return ReplaceVariables(ref text, false);
	}

	public static bool ReplaceVariables(ref string text, bool skipCorruptedCharacterReplacement)
	{
		if (text.Contains("{/") && text.Contains("}"))
		{
			List<string> list = new List<string>();
			int num = 0;
			int num2 = 0;
			string text2 = text;
			while (text2.Contains("{/") && text2.Contains("}"))
			{
				num = text2.IndexOf("{/");
				num2 = text2.IndexOf("}", num);
				if (num < 0 || num2 < num)
				{
					break;
				}
				string item = text2.Substring(num, num2 - num + 1);
				if (!list.Contains(item))
				{
					list.Add(item);
				}
				text2 = text2.Substring(num2 + 1);
			}
			if (list.Count > 0)
			{
				foreach (string item4 in list)
				{
					string text3 = item4.Replace("{/", string.Empty).Replace("}", string.Empty);
					string newValue = "<color=#62ddf9>///[JIL]: " + text3 + "</color>";
					text = text.Replace(item4, newValue);
				}
			}
		}
		if (text.Contains('[') && text.Contains(']'))
		{
			List<string> list2 = new List<string>();
			int num3 = 0;
			int num4 = 0;
			string text4 = text;
			while (text4.Contains('[') && text4.Contains(']'))
			{
				num3 = text4.IndexOf('[');
				num4 = text4.IndexOf(']', num3);
				if (num3 < 0 || num4 < num3)
				{
					break;
				}
				string item2 = text4.Substring(num3, num4 - num3 + 1);
				if (!list2.Contains(item2))
				{
					list2.Add(item2);
				}
				text4 = text4.Substring(num4 + 1);
			}
			if (list2.Count > 0)
			{
				DataManager.LoadQueryableRespository();
				int count = list2.Count;
				for (int i = 0; i < count; i++)
				{
					string text5 = list2[i];
					string text6 = text5.ToLower();
					int length = text6.Length;
					for (int num5 = length - 1; num5 >= 0; num5--)
					{
						if (text6[num5] == '[' || text6[num5] == ']')
						{
							text6 = text6.Remove(num5, 1);
						}
					}
					bool flag = false;
					bool flag2 = true;
					string text7 = string.Empty;
					switch (text6)
					{
					case ".":
						text7 = 'Ç'.ToString();
						flag = true;
						break;
					case "@":
						text7 = 'Ê'.ToString();
						flag = true;
						break;
					case "r":
						text7 = 'Ë'.ToString();
						flag = true;
						break;
					}
					if (!flag)
					{
						bool hasDataTagBack = false;
						string dataTagBackValue = string.Empty;
						if (text6.Contains('^'))
						{
							string[] array = text6.Split('^');
							hasDataTagBack = true;
							dataTagBackValue = array[1];
						}
						string[] array2 = text6.Split('#');
						string[] array3 = array2[0].Split(':');
						string[] array4 = array3[0].Split('.');
						string text8 = array4[0];
						string variableID = text8;
						string externalReference = string.Empty;
						string text9 = "name";
						string tag = string.Empty;
						if (text8.Contains('@'))
						{
							string[] array5 = text8.Split('@');
							text8 = array5[0];
							variableID = array5[0];
							externalReference = array5[1];
						}
						if (text8.Contains('+'))
						{
							tag = text8.Substring(text8.IndexOf('+') + 1);
							text8 = text8.Substring(0, text8.IndexOf('+'));
							variableID = text8;
						}
						if (text8.Contains('_'))
						{
							string[] array6 = text8.Split('_');
							text8 = array6[0];
						}
						if (array4.Length > 1)
						{
							text9 = array4[1];
						}
						string text10 = "any";
						string text11 = "any";
						string text12 = "any";
						if (array3.Length > 1)
						{
							string[] array7 = array3[1].Split('.');
							if (array7[0] != "?")
							{
								text10 = array7[0];
							}
							if (array7.Length > 1 && array7[1] != "?")
							{
								text11 = array7[1];
							}
							if (array7.Length > 2 && array7[2] != "?")
							{
								text12 = array7[2];
							}
						}
						if (text10 == "this")
						{
							text10 = UniverseMapManager.Instance.CurrentUniverseNode.GroupKey;
						}
						if (text11 == "this")
						{
							text11 = GlobalSettings.GameState.ThePlayer.CurrentStarSystem.GroupKey;
						}
						if (text12 == "this")
						{
							text12 = GlobalSettings.GameState.ThePlayer.CurrentDockedDungeon.GroupKey;
						}
						string[] filters = ((array2.Length != 2) ? null : array2[1].Split(':'));
						switch (text8)
						{
						case "outpost":
							text7 = DataManager.FindDungeon(DungeonTypeEnum.Outpost, variableID, text10, text11, text12, text9, externalReference, tag, hasDataTagBack, dataTagBackValue, filters);
							break;
						case "derelict":
							text7 = DataManager.FindDungeon(DungeonTypeEnum.Derelict, variableID, text10, text11, text12, text9, externalReference, tag, hasDataTagBack, dataTagBackValue, filters);
							break;
						case "station":
							text7 = DataManager.FindDungeon(DungeonTypeEnum.Station, variableID, text10, text11, text12, text9, externalReference, tag, hasDataTagBack, dataTagBackValue, filters);
							break;
						case "trading":
							text7 = DataManager.FindDungeon(DungeonTypeEnum.AutoTrade, variableID, text10, text11, text12, text9, externalReference, tag, hasDataTagBack, dataTagBackValue, filters);
							break;
						case "system":
							text7 = DataManager.FindSystem(variableID, text10, text11, text9, externalReference, filters);
							break;
						case "galaxy":
							text7 = DataManager.FindGalaxy(variableID, text10, text9, externalReference, filters);
							break;
						case "header":
						{
							bool flag3 = true;
							string directive;
							string cargo;
							if (!GetDirectiveAndCargoByShipType(out directive, out cargo))
							{
								GetRandomDirectiveAndCargo(out directive, out cargo);
							}
							switch (text9.ToLower())
							{
							case "dungeon":
								if (GlobalSettings.GameState.ThePlayer.CurrentDockedDungeon.DungeonType == DungeonTypeEnum.Derelict)
								{
									text7 = string.Format("Name: [{0}_header:this.this.this]\nClass: [{0}_header.type:this.this.this]\nDirective: {1}\nCrew: {2} Hold: {3}\n", "derelict", directive, _random.Next(1, 11), cargo);
								}
								else if (GlobalSettings.GameState.ThePlayer.CurrentDockedDungeon.DungeonType == DungeonTypeEnum.Station)
								{
									text7 = string.Format("Name: [{0}_header:this.this.this]\nClass: [{0}_header.type:this.this.this]\nDirective: {1}\nCrew: {2} Hold: {3}\n", "station", directive, _random.Next(1, 11), cargo);
								}
								else if (GlobalSettings.GameState.ThePlayer.CurrentDockedDungeon.DungeonType == DungeonTypeEnum.Outpost)
								{
									text7 = string.Format("Name: [{0}_header:this.this.this]\nClass: [{0}_header.type:this.this.this]\nDirective: {1}\nCrew: {2} Hold: {3}\n", "outpost", directive, _random.Next(1, 11), cargo);
								}
								else
								{
									text7 = "#INVLD_HDR 'dungeon' only valid on Derelict and Outpost";
									flag3 = false;
								}
								break;
							case "derelict":
							case "outpost":
								text7 = string.Format("Name: [{0}:this.this.this]\nClass: [{0}.type:this.this.this]\nDirective: {1}\nCrew: {2} Hold: {3}\n", text9, directive, _random.Next(1, 11), cargo);
								break;
							case "scientist":
								text7 = string.Format("From: I'm a Scientist\nTo: You\n");
								break;
							case "access":
							{
								text7 = "\nLogs:";
								int num6 = _random.Next(3, 7);
								int num7 = _random.Next(0, num6);
								List<int> list3 = new List<int>();
								for (int j = 0; j < num6; j++)
								{
									list3.Add(_random.Next(100, 1000));
								}
								IOrderedEnumerable<int> source = list3.OrderByDescending((int x) => x);
								int num8 = source.Count();
								for (int num9 = 0; num9 < num8; num9++)
								{
									string empty = string.Empty;
									if (num9 == num7 || (num9 > num7 && UnityEngine.Random.Range(0, 4) == 0))
									{
										int num10 = 0;
										num10 = ((!text10.StartsWith("in")) ? (text10.StartsWith("mod") ? 1 : UnityEngine.Random.Range(0, 2)) : 0);
										empty = ((num10 != 0) ? "??Modified" : "Intact");
									}
									else
									{
										empty = "Corrupted";
									}
									text7 += string.Format("\n{0} - {1}", source.ElementAt(num9), empty);
								}
								text7 += string.Format("\n\nMost Recent Intact Log:\nLog {0}\n", source.ElementAt(num7));
								break;
							}
							default:
								text7 = "#INVLD_HDR";
								flag3 = false;
								break;
							}
							if (flag3)
							{
								text = text.Replace(text5, string.Empty);
								while (text.StartsWith("\n"))
								{
									text = text.Substring(1);
								}
								LogInfo logInfo = new LogInfo("N/A", text7);
								ReplaceVariables(ref logInfo);
								flag2 = false;
							}
							break;
						}
						case "color":
							flag2 = false;
							break;
						case "yn":
							flag2 = true;
							text7 = 'È' + array2[1] + 'É';
							break;
						default:
							flag2 = false;
							break;
						}
					}
					if (flag2)
					{
						if (text7 != null)
						{
							text = text.Replace(text5, text7);
						}
						else
						{
							text = text.Replace(text5, "#ERR");
						}
					}
				}
				DataManager.Unload();
			}
		}
		if (text.Contains('{') && text.Contains('}'))
		{
			List<string> list4 = new List<string>();
			int num11 = 0;
			int num12 = 0;
			string text13 = text;
			while (text13.Contains('{') && text13.Contains('}'))
			{
				num11 = text13.IndexOf('{');
				num12 = text13.IndexOf('}', num11);
				if (num11 < 0 || num12 < num11)
				{
					break;
				}
				string item3 = text13.Substring(num11, num12 - num11 + 1);
				if (!list4.Contains(item3))
				{
					list4.Add(item3);
				}
				text13 = text13.Substring(num12 + 1);
			}
			if (list4.Count > 0)
			{
				foreach (string item5 in list4)
				{
					string text14 = item5.Replace("{", string.Empty).Replace("}", string.Empty);
					int length2 = text14.Length;
					StringBuilder stringBuilder = new StringBuilder(length2);
					for (int num13 = 0; num13 < length2; num13++)
					{
						char c = item5[num13];
						c = ((UnityEngine.Random.Range(0, 3) != 0) ? ((char)UnityEngine.Random.Range(204, 255)) : ((char)UnityEngine.Random.Range(128, 198)));
						stringBuilder.Append(c);
					}
					text14 = stringBuilder.ToString();
					text = text.Replace(item5, text14);
				}
			}
		}
		if (!skipCorruptedCharacterReplacement && text.Contains('*'))
		{
			int length3 = text.Length;
			StringBuilder stringBuilder2 = new StringBuilder(length3);
			for (int num14 = 0; num14 < length3; num14++)
			{
				char value = text[num14];
				if (text[num14] == '*')
				{
					value = ((UnityEngine.Random.Range(0, 3) != 0) ? ((char)UnityEngine.Random.Range(204, 255)) : ((char)UnityEngine.Random.Range(128, 200)));
				}
				stringBuilder2.Append(value);
			}
			text = stringBuilder2.ToString();
		}
		return true;
	}
}
