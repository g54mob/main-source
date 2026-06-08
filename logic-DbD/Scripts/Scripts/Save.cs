using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using UnityEngine;

public static class Save
{
	[XmlRoot]
	public class SaveData
	{
		[XmlElement]
		public int currentSearchResult { get; set; }

		[XmlElement]
		public int currLevel { get; set; }

		[XmlElement]
		public byte[] databaseCode { get; set; }

		[XmlElement]
		public byte[] saveCode { get; set; }

		[XmlElement]
		public byte[] t1 { get; set; }

		[XmlElement]
		public byte[] t2 { get; set; }

		[XmlElement]
		public byte[] s1 { get; set; }

		[XmlElement]
		public byte[] s2 { get; set; }

		[XmlElement]
		public HashSet<string> iconsClicked { get; set; }

		[XmlElement]
		public List<string> iconsMoved { get; set; }

		[XmlElement]
		public List<Vector2Int> iconPositions { get; set; }

		[XmlElement]
		public string culpritFirstName { get; set; }

		[XmlElement]
		public string culpritLastName { get; set; }

		[XmlElement]
		public bool rydl { get; set; }

		[XmlElement]
		public bool rydr { get; set; }

		[XmlElement]
		public bool lzua { get; set; }

		[XmlElement]
		public HashSet<string> gl { get; set; }

		[XmlElement]
		public int queryHintsGiven { get; set; }

		[XmlElement]
		public int queryHintState { get; set; }

		[XmlElement]
		public int hintsGiven { get; set; }

		[XmlElement]
		public int hintState { get; set; }

		[XmlElement]
		public bool playedIntro { get; set; }

		[XmlElement]
		public bool playedTutorial { get; set; }

		[XmlElement]
		public bool searchTip { get; set; }

		[XmlElement]
		public int sclass { get; set; }

		[XmlElement]
		public int scclass { get; set; }

		[XmlElement]
		public List<int> messages { get; set; }

		[XmlElement]
		public string sIP { get; set; }

		[XmlElement]
		public bool hbw { get; set; }

		[XmlElement]
		public bool hbwsqrd { get; set; }

		[XmlElement]
		public bool lzul { get; set; }

		[XmlElement]
		public bool sssl { get; set; }

		[XmlElement]
		public bool lztl { get; set; }

		[XmlElement]
		public bool hasFailed { get; set; }

		[XmlElement]
		public bool unlockSelector { get; set; }

		[XmlElement]
		public HashSet<string> websites { get; set; }

		[XmlElement]
		public bool askedForMoreHelp { get; set; }

		[XmlElement]
		public bool initialGreeting { get; set; }
	}

	public static readonly string SAVE_PATH = Application.persistentDataPath + "/SQLGame.save";

	public static readonly string SAVES_DATABASE = "SavedData";

	public static readonly string PERSISTENT_SAVES_DATABASE = "PersistentSavedData";

	public static readonly string SAVED_TRADERS_TABLE = "RetailTraders";

	public static readonly string NIMBY_TABLE = "NimbySaves";

	public static readonly string EVERYONE_TABLE = "Everyone";

	public static readonly string ARRESTED_TABLE = "Arrested";

	public static readonly string APPEARANCES_TABLE = "Appearances";

	public static SaveData GLOBAL_SAVE = new SaveData();

	public static void SaveGame()
	{
		Debug.Log("Saving game...");
		SaveEssentials();
		FileStream fileStream = File.Create(SAVE_PATH);
		new XmlSerializer(typeof(SaveData)).Serialize(fileStream, GLOBAL_SAVE);
		fileStream.Close();
		Debug.Log("Game data saved!");
	}

	public static bool LoadGame()
	{
		Debug.Log("Save file located at " + SAVE_PATH);
		bool num = File.Exists(SAVE_PATH);
		if (num)
		{
			XmlSerializer xmlSerializer = new XmlSerializer(typeof(SaveData));
			FileStream fileStream = File.Open(SAVE_PATH, FileMode.Open);
			fileStream.Position = 0L;
			GLOBAL_SAVE = (SaveData)xmlSerializer.Deserialize(fileStream);
			fileStream.Close();
			TableNameGenerator.resultId = GLOBAL_SAVE.currentSearchResult;
			LevelManager.SetLevel(GLOBAL_SAVE.currLevel);
			Debug.Log($"Game data loaded! Current Level: {GLOBAL_SAVE.currLevel}");
			return num;
		}
		Debug.Log("No save found!");
		return num;
	}

	private static void SaveEssentials()
	{
		GLOBAL_SAVE.currentSearchResult = TableNameGenerator.resultId;
		GLOBAL_SAVE.currLevel = LevelManager.GetCurrLevel();
		GLOBAL_SAVE.culpritFirstName = "Frog";
		GLOBAL_SAVE.culpritLastName = "Man";
	}

	public static void SaveIconClick(string iconName)
	{
		if (GLOBAL_SAVE.iconsClicked == null)
		{
			GLOBAL_SAVE.iconsClicked = new HashSet<string>();
		}
		GLOBAL_SAVE.iconsClicked.Add(iconName);
		Debug.Log("Saved " + iconName);
		SaveGame();
	}

	public static void ClearIconClicks()
	{
		GLOBAL_SAVE.iconsClicked = new HashSet<string>();
		SaveGame();
	}

	public static void RemoveIconPosition(string iconName, bool debug = false)
	{
		if (GLOBAL_SAVE.iconPositions == null || GLOBAL_SAVE.iconsMoved == null)
		{
			GLOBAL_SAVE.iconsMoved = new List<string>();
			GLOBAL_SAVE.iconPositions = new List<Vector2Int>();
		}
		if (debug)
		{
			Debug.Log("iconsMoved BEFORE -> " + string.Join(",", GLOBAL_SAVE.iconsMoved));
			Debug.Log("iconPositions BEFORE -> " + string.Join(",", GLOBAL_SAVE.iconPositions));
		}
		if (GLOBAL_SAVE.iconsMoved.Contains(iconName))
		{
			int index = GLOBAL_SAVE.iconsMoved.IndexOf(iconName);
			GLOBAL_SAVE.iconsMoved.RemoveAt(index);
			GLOBAL_SAVE.iconPositions.RemoveAt(index);
		}
		if (debug)
		{
			Debug.Log("iconsMoved AFTER -> " + string.Join(",", GLOBAL_SAVE.iconsMoved));
			Debug.Log("iconPositions AFTER -> " + string.Join(",", GLOBAL_SAVE.iconPositions));
		}
		SaveGame();
	}

	public static void SaveIconPosition(string iconName, Vector2Int iconPosition, bool debug = false)
	{
		Debug.Log($"Saving icon position -> {iconPosition}");
		RemoveIconPosition(iconName);
		GLOBAL_SAVE.iconsMoved.Add(iconName);
		GLOBAL_SAVE.iconPositions.Add(iconPosition);
		if (debug)
		{
			Debug.Log("iconsMoved AFTER -> " + string.Join(",", GLOBAL_SAVE.iconsMoved));
			Debug.Log("iconPositions AFTER -> " + string.Join(",", GLOBAL_SAVE.iconPositions));
		}
		SaveGame();
	}

	public static Vector2Int GetIconPosition(string iconName)
	{
		if (GLOBAL_SAVE.iconPositions == null || GLOBAL_SAVE.iconsMoved == null)
		{
			return new Vector2Int(-1, -1);
		}
		if (GLOBAL_SAVE.iconPositions.Count != GLOBAL_SAVE.iconsMoved.Count)
		{
			return new Vector2Int(-1, -1);
		}
		int index = GLOBAL_SAVE.iconsMoved.IndexOf(iconName);
		return GLOBAL_SAVE.iconPositions[index];
	}

	public static bool IsIconClicked(string iconName)
	{
		if (GLOBAL_SAVE.iconsClicked == null)
		{
			return false;
		}
		return GLOBAL_SAVE.iconsClicked.Contains(iconName);
	}

	public static bool IsIconMoved(string iconName)
	{
		if (GLOBAL_SAVE.iconsMoved == null)
		{
			return false;
		}
		return GLOBAL_SAVE.iconsMoved.Contains(iconName);
	}

	public static void AddGuilds(string guildName)
	{
		if (GLOBAL_SAVE.gl == null)
		{
			GLOBAL_SAVE.gl = new HashSet<string>();
		}
		GLOBAL_SAVE.gl.Add(guildName);
		SaveGame();
	}

	public static HashSet<string> GetGuilds()
	{
		if (GLOBAL_SAVE.gl == null)
		{
			GLOBAL_SAVE.gl = new HashSet<string>();
		}
		return GLOBAL_SAVE.gl;
	}

	public static bool ContainsWebsite(string website)
	{
		if (GLOBAL_SAVE.websites == null)
		{
			GLOBAL_SAVE.websites = new HashSet<string>();
		}
		bool result = GLOBAL_SAVE.websites.Contains(website);
		GLOBAL_SAVE.websites.Add(website);
		SaveGame();
		return result;
	}

	public static void SaveCulprit(string person1, string person2)
	{
		GLOBAL_SAVE.databaseCode = EncodeString(person1);
		GLOBAL_SAVE.saveCode = EncodeString(person2);
		SaveGame();
	}

	public static void SaveSuitTie(string suitFirst, string suitLast, string tieFirst, string tieLast)
	{
		GLOBAL_SAVE.t1 = EncodeString(tieFirst);
		GLOBAL_SAVE.t2 = EncodeString(tieLast);
		GLOBAL_SAVE.s1 = EncodeString(suitFirst);
		GLOBAL_SAVE.s2 = EncodeString(suitLast);
		Debug.Log("Saved Suit and Tie");
	}

	public static void EraseSave()
	{
		if (File.Exists(SAVE_PATH))
		{
			File.Delete(SAVE_PATH);
			GLOBAL_SAVE = new SaveData();
			Debug.Log("Data reset complete!");
		}
		PlayerPrefs.DeleteAll();
	}

	public static void SetIntroPlayed(bool value = true)
	{
		GLOBAL_SAVE.playedIntro = value;
		SaveGame();
	}

	public static bool HasPlayedIntro()
	{
		return GLOBAL_SAVE.playedIntro;
	}

	public static void SetTutorialSeen(bool val = true)
	{
		GLOBAL_SAVE.playedTutorial = val;
		SaveGame();
	}

	public static bool HasSeenTutorial()
	{
		return GLOBAL_SAVE.playedTutorial;
	}

	public static void SetSearchTip()
	{
		GLOBAL_SAVE.searchTip = true;
		SaveGame();
	}

	public static bool GetSearchTip()
	{
		return GLOBAL_SAVE.searchTip;
	}

	public static void SaveQueryHintState(int queryHintState)
	{
		GLOBAL_SAVE.queryHintState = queryHintState;
		SaveGame();
	}

	public static void SaveQueryHintGiven(int queryHintsGiven)
	{
		GLOBAL_SAVE.queryHintsGiven = queryHintsGiven;
		SaveGame();
	}

	public static int GetQueryHintState()
	{
		return GLOBAL_SAVE.queryHintState;
	}

	public static int GetQueryHintsGiven()
	{
		return GLOBAL_SAVE.queryHintsGiven;
	}

	public static void SaveHintState(int hintState)
	{
		GLOBAL_SAVE.hintState = hintState;
		SaveGame();
	}

	public static void SaveHintsGiven(int hintsGiven)
	{
		GLOBAL_SAVE.hintsGiven = hintsGiven;
		SaveGame();
	}

	public static int GetHintState()
	{
		return GLOBAL_SAVE.hintState;
	}

	public static int GetHintsGiven()
	{
		return GLOBAL_SAVE.hintsGiven;
	}

	public static string GetLevel5SuspectIP()
	{
		return GLOBAL_SAVE.sIP;
	}

	public static void SetLevel5SuspectIP(string ip)
	{
		GLOBAL_SAVE.sIP = ip;
		SaveGame();
	}

	public static bool GetHasBeenWrong()
	{
		return GLOBAL_SAVE.hbw;
	}

	public static void SetHasBeenWrong(bool hbw = true)
	{
		GLOBAL_SAVE.hbw = hbw;
		SaveGame();
	}

	public static bool LevelSelectorUnlocked()
	{
		return GLOBAL_SAVE.unlockSelector;
	}

	public static void SetLevelSelectorUnlocked()
	{
		GLOBAL_SAVE.unlockSelector = true;
		SaveGame();
	}

	public static bool GetHasBeenWrongAgain()
	{
		return GLOBAL_SAVE.hbwsqrd;
	}

	public static void SetHasBeenWrongAgain(bool hbwa = true)
	{
		GLOBAL_SAVE.hbwsqrd = hbwa;
		SaveGame();
	}

	public static bool GetHasRecentlyFailed()
	{
		return GLOBAL_SAVE.hasFailed;
	}

	public static bool GetAskForMore()
	{
		return GLOBAL_SAVE.askedForMoreHelp;
	}

	public static void SetAskedForMore()
	{
		GLOBAL_SAVE.askedForMoreHelp = true;
		SaveGame();
	}

	public static bool GetInitGreeting()
	{
		return GLOBAL_SAVE.initialGreeting;
	}

	public static void SetInitGreeting()
	{
		GLOBAL_SAVE.initialGreeting = true;
		SaveGame();
	}

	public static void SetHasRecentlyFailed(bool hasFailed)
	{
		GLOBAL_SAVE.hasFailed = hasFailed;
		SaveGame();
	}

	public static void SaveUniClass(int suspectClass, int closeSuspectClass)
	{
		GLOBAL_SAVE.sclass = suspectClass;
		GLOBAL_SAVE.scclass = closeSuspectClass;
		SaveGame();
	}

	public static void SaveSSSLogin()
	{
		GLOBAL_SAVE.sssl = true;
		SaveGame();
	}

	public static ICollection<int> GetMessages()
	{
		if (GLOBAL_SAVE.messages == null)
		{
			return new List<int>();
		}
		return GLOBAL_SAVE.messages.Distinct().ToList();
	}

	public static void AddMessage(int message)
	{
		if (GLOBAL_SAVE.messages == null)
		{
			GLOBAL_SAVE.messages = new List<int>();
		}
		GLOBAL_SAVE.messages.Add(message);
		SaveGame();
	}

	public static void RemoveMessage(int message)
	{
		if (GLOBAL_SAVE.messages != null)
		{
			GLOBAL_SAVE.messages.Remove(message);
		}
	}

	public static UniversityLevel.SuspectClass GetSuspectClass()
	{
		return (UniversityLevel.SuspectClass)GLOBAL_SAVE.sclass;
	}

	public static UniversityLevel.SuspectClass GetSuspectCloseClass()
	{
		return (UniversityLevel.SuspectClass)GLOBAL_SAVE.scclass;
	}

	public static byte[] EncodeString(string text)
	{
		return Encoding.UTF8.GetBytes(text);
	}

	public static string DecodeString(byte[] bytes)
	{
		return Encoding.UTF8.GetString(bytes);
	}
}
