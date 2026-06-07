using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using UnityEngine;

public class Platform : MonoBehaviour
{
	private static Platform _instance;

	protected Dictionary<AchievementType, string> achievementLocalizationKeys;

	protected Dictionary<AchievementType, string> achievementIdKeys;

	protected readonly Dictionary<StatType, string> statKeys = new Dictionary<StatType, string>(new StatEqualityComparer());

	public Dictionary<AchievementType, StatType> associatedFloatStats;

	public Dictionary<AchievementType, StatType> associatedIntStats;

	public static bool isOfflineMode;

	public bool useAchievements;

	protected bool isReady;

	[NonSerialized]
	public bool isPlaytest;

	public static Platform Instance => _instance;

	public bool IsReady => isReady;

	protected virtual void Awake()
	{
		_instance = this;
		UnityEngine.Object.DontDestroyOnLoad(base.gameObject);
	}

	public virtual bool Init()
	{
		associatedFloatStats = new Dictionary<AchievementType, StatType>(new AchievementEqualityComparer());
		associatedFloatStats[AchievementType.NumbersGoUp] = StatType.MaxRateXP;
		associatedFloatStats[AchievementType.HarvestTree] = StatType.MaxRateWoodHarvest;
		associatedFloatStats[AchievementType.IdleTime1] = StatType.IdleHoursEarned;
		associatedIntStats = new Dictionary<AchievementType, StatType>(new AchievementEqualityComparer());
		associatedIntStats[AchievementType.MakeBerries] = StatType.NumBerries;
		associatedIntStats[AchievementType.MakeBook] = StatType.NumBooks;
		associatedIntStats[AchievementType.MakeCake] = StatType.NumCakes;
		associatedIntStats[AchievementType.MakeCrown] = StatType.NumCrowns;
		associatedIntStats[AchievementType.MakeEgg] = StatType.NumEggs;
		associatedIntStats[AchievementType.MakeFire] = StatType.NumFire;
		associatedIntStats[AchievementType.MakeSandwich] = StatType.NumSandwiches;
		associatedIntStats[AchievementType.MakeMagicHat] = StatType.NumMagicHats;
		associatedIntStats[AchievementType.MakeMagicPotion] = StatType.NumMagicPotions;
		associatedIntStats[AchievementType.MakeRailTile] = StatType.NumRailTiles;
		associatedIntStats[AchievementType.MakeRefinedSugar] = StatType.NumSugar;
		associatedIntStats[AchievementType.MakeWarmCoat] = StatType.NumWarmCoats;
		associatedIntStats[AchievementType.MakeAppleJam] = StatType.NumAppleJam;
		associatedIntStats[AchievementType.MakePearJuice] = StatType.NumPearJuice;
		associatedIntStats[AchievementType.Wells] = StatType.NumWells;
		associatedIntStats[AchievementType.QuestCoins1] = StatType.NumQuestCoins;
		associatedIntStats[AchievementType.Quests1] = StatType.NumQuestsCompleted;
		isReady = true;
		return true;
	}

	public virtual void WriteToPlatformFiles(string fileNameAndExtension, FileType fileType, string fileString)
	{
		string persistentLocalDirectory = FileManager.GetPersistentLocalDirectory(fileType);
		WriteToDirectory(fileNameAndExtension, persistentLocalDirectory, fileString);
	}

	public static string ReadFromFile(string fullPath)
	{
		StreamReader streamReader = new StreamReader(fullPath);
		string result = streamReader.ReadToEnd();
		streamReader.Close();
		return result;
	}

	public void WriteToDirectory(string fileNameAndExtension, string rootedDirectory, string fileString)
	{
		string text = PlatformPathCombine(rootedDirectory, fileNameAndExtension);
		StreamWriter streamWriter = new StreamWriter(text, append: false);
		streamWriter.Write(fileString);
		streamWriter.Close();
		GameUtility.PlatformDebug("Wrote file: " + text + " length: " + fileString.Length);
	}

	public virtual LoadResultStatus TryGetFileContents(FileMetadata file, out string fileContents)
	{
		GameUtility.PlatformDebug("Get File Contents for displayName:" + file.displayName + " full:" + file.platformRootedPath + "'");
		if (File.Exists(file.platformRootedPath))
		{
			fileContents = ReadFromFile(file.platformRootedPath);
			return LoadResultStatus.OK;
		}
		GameUtility.PlatformDebug("No save file found");
		fileContents = null;
		return LoadResultStatus.NoSaveFileFound;
	}

	public LoadResultStatus TryLoadSaveFileFromPath(FileMetadata file)
	{
		string fileContents;
		LoadResultStatus loadResultStatus = TryGetFileContents(file, out fileContents);
		if (loadResultStatus == LoadResultStatus.OK)
		{
			return FileManager.TryPushToGameState(file, fileContents);
		}
		return loadResultStatus;
	}

	public virtual void EarnAchievement(AchievementType type)
	{
	}

	public virtual int GetStatInt(StatType statType)
	{
		return PlayerPrefs.GetInt(CachedStatIdentifier(statType));
	}

	public virtual float GetStatFloat(StatType statType)
	{
		return PlayerPrefs.GetFloat(CachedStatIdentifier(statType));
	}

	public virtual void WipeStatsAndAchievements()
	{
	}

	public virtual void SetStat(StatType statType, float setValue)
	{
		string key = CachedStatIdentifier(statType);
		float statFloat = GetStatFloat(statType);
		if (setValue > statFloat)
		{
			PlayerPrefs.SetFloat(key, setValue);
		}
	}

	public virtual void SetStat(StatType statType, int setValue)
	{
		string key = CachedStatIdentifier(statType);
		int statInt = GetStatInt(statType);
		if (setValue > statInt)
		{
			PlayerPrefs.SetInt(key, setValue);
		}
	}

	public virtual void AddStat(StatType statType, int incrementValue)
	{
		int statInt = GetStatInt(statType);
		SetStat(statType, statInt + incrementValue);
	}

	public virtual void ResetStats(bool includeAchievements)
	{
	}

	public virtual UserLanguage GetUserLanguage()
	{
		return UserLanguage.DefaultEnglish;
	}

	public virtual FileSource GetFileSource()
	{
		return FileSource.ApplicationPersistentData;
	}

	public virtual List<FileMetadata> CloudFiles(FileType fileType)
	{
		return null;
	}

	public static List<FileMetadata> PersistentLocalFiles(FileType fileType)
	{
		List<FileMetadata> list = new List<FileMetadata>();
		string persistentLocalDirectory = FileManager.GetPersistentLocalDirectory(fileType);
		LoadPersistentLocalFileMetadata(list, persistentLocalDirectory, fileType, ".idlesav", FileSource.ApplicationPersistentData);
		return list;
	}

	private static void LoadPersistentLocalFileMetadata(List<FileMetadata> target, string directoryPath, FileType fileType, string extension, FileSource fileSource)
	{
		DirectoryInfo directoryInfo = new DirectoryInfo(directoryPath);
		if (directoryInfo.Exists)
		{
			FileInfo[] files = directoryInfo.GetFiles("*" + extension);
			for (int i = 0; i < files.Length; i++)
			{
				FileMetadata item = new FileMetadata(files[i], fileSource, fileType);
				target.Add(item);
			}
		}
	}

	public FileMetadata CreateFileMetadata(int slotIndex, int townIndex)
	{
		string fileNameWithExtension = FileManager.FileNameForSlotAndTown(slotIndex, townIndex);
		return CreateNamedFileMetadata(fileNameWithExtension, FileType.SaveFile);
	}

	public virtual FileMetadata CreateNamedFileMetadata(string fileNameWithExtension, FileType fileType)
	{
		return CreateApplicationFileMetadata(fileNameWithExtension, fileType);
	}

	public FileMetadata CreateApplicationFileMetadata(string fileNameWithExtension, FileType fileType)
	{
		FileSource fileSource = FileSource.ApplicationPersistentData;
		string persistentLocalDirectory = FileManager.GetPersistentLocalDirectory(fileType);
		return new FileMetadata(PlatformPathCombine(persistentLocalDirectory, fileNameWithExtension), fileSource, fileType);
	}

	public virtual void DeleteFile(FileMetadata fileMetadata)
	{
		string platformRootedPath = fileMetadata.platformRootedPath;
		Debug.Log("exists " + platformRootedPath + "?" + File.Exists(platformRootedPath));
		if (File.Exists(platformRootedPath))
		{
			File.Delete(platformRootedPath);
		}
	}

	public virtual bool HasEarned(AchievementType t)
	{
		return false;
	}

	protected string IdentifierForAchievement(AchievementType type)
	{
		if (achievementIdKeys.TryGetValue(type, out var value))
		{
			return value;
		}
		value = type.ToString();
		achievementIdKeys[type] = value;
		return value;
	}

	protected virtual string IdentifierForStat(StatType statType)
	{
		return "Stat" + statType;
	}

	protected string CachedStatIdentifier(StatType statType)
	{
		if (statKeys.TryGetValue(statType, out var value))
		{
			return value;
		}
		value = IdentifierForStat(statType);
		statKeys[statType] = value;
		return value;
	}

	public virtual void TryShowGamepadTextInput(bool multiLine, string header, string initialText)
	{
	}

	public virtual bool AlwaysShowKeyboard()
	{
		return false;
	}

	public virtual bool IsInKeyboardMode()
	{
		return true;
	}

	public virtual void PerformFinalUploads()
	{
	}

	public static void TakeScreenshot()
	{
		string path = ScreenshotDirectory();
		string text = "Screenshot";
		if (!string.IsNullOrEmpty(GameManager.Instance.overrideFileName))
		{
			text = GameManager.Instance.overrideFileName;
		}
		int num = 0;
		while (File.Exists(Path.Combine(path, text + "_" + num + ".png")))
		{
			num++;
		}
		string text2 = text + "_" + num + ".png";
		string text3 = Path.Combine(path, text2);
		ScreenCapture.CaptureScreenshot(text3);
		Debug.Log("Saved as " + text3);
		Instance.StartCoroutine(Instance.ShowScreenshotConfirm(text2, 0.5f));
	}

	public IEnumerator ShowScreenshotConfirm(string fileName, float delayTime)
	{
		yield return new WaitForSeconds(delayTime);
		OpenScreenshotFolder();
	}

	public static string ScreenshotDirectory()
	{
		string text = Path.Combine(Application.persistentDataPath, "Screenshots");
		if (!Directory.Exists(text))
		{
			Directory.CreateDirectory(text);
		}
		return text;
	}

	public static void OpenScreenshotFolder()
	{
		Application.OpenURL(ScreenshotDirectory());
	}

	public virtual string DisplayLabel()
	{
		return "Standalone - Demo";
	}

	public FileMetadata NextAvailableFileMetadata(string prefix, FileSource source, FileType fileType)
	{
		int num = 1;
		string text;
		while (true)
		{
			text = FileManager.AddExtension(prefix + num.ToString(CultureInfo.InvariantCulture), fileType);
			if (!FileExists(text, source, fileType, out var _))
			{
				break;
			}
			num++;
		}
		if (source == FileSource.PlatformStorage && this is PlatformSteam platformSteam)
		{
			return platformSteam.CreatePlatformFileMetadata(text, fileType);
		}
		return CreateApplicationFileMetadata(text, fileType);
	}

	public virtual string PlatformPathCombine(string a, string b)
	{
		return Path.Combine(a, b);
	}

	public bool FileExists(string nameWithExtension, FileSource source, FileType fileType, out FileMetadata resultMetadata)
	{
		if (source == FileSource.PlatformStorage && this is PlatformSteam platformSteam)
		{
			string text = PlatformPathCombine(FileManager.FolderForType(fileType), nameWithExtension);
			List<FileMetadata> list = CloudFiles(fileType);
			if (list != null)
			{
				foreach (FileMetadata item in list)
				{
					if (item.platformRootedPath == text)
					{
						resultMetadata = platformSteam.CreatePlatformFileMetadata(nameWithExtension, fileType);
						return true;
					}
				}
			}
			resultMetadata = null;
			return false;
		}
		if (File.Exists(PlatformPathCombine(FileManager.GetPersistentLocalDirectory(fileType), nameWithExtension)))
		{
			resultMetadata = CreateApplicationFileMetadata(nameWithExtension, fileType);
			return true;
		}
		resultMetadata = null;
		return false;
	}
}
