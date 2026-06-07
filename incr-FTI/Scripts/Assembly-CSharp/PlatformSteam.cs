using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Steamworks;
using Steamworks.Data;
using Steamworks.Ugc;
using UnityEngine;

public class PlatformSteam : Platform
{
	public delegate void WorkshopDelegate(string fileId);

	public uint AppId = 2207490u;

	public uint AppIdPlaytest = 2258240u;

	public uint AppIdDemo = 2270260u;

	private bool areStatsStale;

	private float submitStatsCooldown;

	private Dictionary<string, Steamworks.Ugc.Item> workshopItemDictionary;

	private Dictionary<string, Achievement> achievementCache;

	private string tempWorkshopFolder => Path.Combine(Application.persistentDataPath, "WorkshopUpload");

	private string tempThumbnailFolder => Path.Combine(Application.persistentDataPath, "TempThumbnail");

	public override bool Init()
	{
		workshopItemDictionary = new Dictionary<string, Steamworks.Ugc.Item>();
		achievementLocalizationKeys = new Dictionary<AchievementType, string>(new AchievementEqualityComparer());
		achievementIdKeys = new Dictionary<AchievementType, string>(new AchievementEqualityComparer());
		try
		{
			uint appid = AppId;
			string text = Path.Combine(Path.GetFullPath("."), "steam_appid.txt");
			if (File.Exists(text))
			{
				string text2 = Platform.ReadFromFile(text);
				Debug.Log("Read app id: " + text2);
				if (uint.TryParse(text2, out var result))
				{
					appid = result;
				}
			}
			Debug.Log("Attempt init app " + appid);
			if (SteamClient.RestartAppIfNecessary(appid))
			{
				Debug.Log("Steam Client not running, restart app");
				Application.Quit();
			}
			else
			{
				Debug.Log("Steam Client is running");
			}
			SteamClient.Init(appid);
			isPlaytest = (uint)SteamClient.AppId == AppIdPlaytest;
			Debug.Log("Steam Initialized: " + SteamClient.Name + " / " + SteamClient.SteamId.ToString());
			Debug.Log(" File quota remaining: " + SteamRemoteStorage.QuotaRemainingBytes + "/" + SteamRemoteStorage.QuotaBytes);
			Debug.Log("Cloud storage acct: " + SteamRemoteStorage.IsCloudEnabledForAccount + " app: " + SteamRemoteStorage.IsCloudEnabledForApp);
			SteamUserStats.OnAchievementProgress += OnAchievementProgress;
			useAchievements = true;
			SteamUserStats.OnUserStatsStored += OnUserStatsStored;
			SteamUtils.OnGamepadTextInputDismissed += HandleGamepadInput;
			TestMigration();
			return base.Init();
		}
		catch (Exception ex)
		{
			Debug.Log("Couldn't initialize Steam: " + ex.Message);
			return false;
		}
	}

	public override void WipeStatsAndAchievements()
	{
		SteamUserStats.ResetAll(includeAchievements: true);
	}

	public override void ResetStats(bool includeAchievements)
	{
		Debug.Log("Resetting achievements");
		SteamUserStats.ResetAll(includeAchievements);
	}

	private void OnDebugException(Exception e)
	{
	}

	private void OnDebugCallback(CallbackType callbackType, string s, bool b)
	{
	}

	private void OnUserStatsStored(Result result)
	{
	}

	private void OnAchievementProgress(Achievement a, int curProgress, int maxProgress)
	{
	}

	private void Update()
	{
		if (submitStatsCooldown > 0f)
		{
			submitStatsCooldown -= TimeManager.MenuDelta;
		}
		if (areStatsStale && submitStatsCooldown <= 0f)
		{
			areStatsStale = false;
			submitStatsCooldown = 0.5f;
			SteamUserStats.StoreStats();
		}
	}

	public override FileSource GetFileSource()
	{
		if (IsUsingCloud())
		{
			return FileSource.PlatformStorage;
		}
		return FileSource.ApplicationPersistentData;
	}

	public bool IsUsingCloud()
	{
		if (SteamRemoteStorage.IsCloudEnabledForAccount)
		{
			return SteamRemoteStorage.IsCloudEnabledForApp;
		}
		return false;
	}

	public override List<FileMetadata> CloudFiles(FileType fileType)
	{
		GameUtility.PlatformDebug("Cloud storage acct: " + SteamRemoteStorage.IsCloudEnabledForAccount + " app: " + SteamRemoteStorage.IsCloudEnabledForApp);
		List<FileMetadata> list = new List<FileMetadata>();
		foreach (string file in SteamRemoteStorage.Files)
		{
			GameUtility.PlatformDebug("remote cloudRootedPath " + file);
			bool flag = false;
			string text = FileManager.FolderForType(fileType);
			if (Path.GetDirectoryName(file) == text)
			{
				flag = true;
			}
			if (flag)
			{
				FileMetadata fileMetadata = new FileMetadata(file, FileSource.PlatformStorage, fileType);
				fileMetadata.dateLastWritten = SteamRemoteStorage.FileTime(file);
				list.Add(fileMetadata);
			}
		}
		return list;
	}

	public static DateTime UnixTimeStampToDateTime(long unixTimeStamp)
	{
		return new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc).AddSeconds(unixTimeStamp).ToLocalTime();
	}

	public bool CloudFileExists(string cloudRootedPath)
	{
		return SteamRemoteStorage.FileExists(cloudRootedPath);
	}

	public override void WriteToPlatformFiles(string fileNameAndExtension, FileType fileType, string fileString)
	{
		if (IsUsingCloud())
		{
			string parentDirectoryPath = FileManager.FolderForType(fileType);
			WriteToCloud(fileNameAndExtension, parentDirectoryPath, fileString);
		}
		else
		{
			base.WriteToPlatformFiles(fileNameAndExtension, fileType, fileString);
		}
	}

	public void WriteToCloud(string fileNameAndExtension, string parentDirectoryPath, string fileString)
	{
		byte[] bytes = Encoding.UTF8.GetBytes(fileString);
		if (parentDirectoryPath == null)
		{
			if (SteamRemoteStorage.FileWrite(fileNameAndExtension, bytes))
			{
				return;
			}
		}
		else if (SteamRemoteStorage.FileWrite(PlatformPathCombine(parentDirectoryPath, fileNameAndExtension), bytes))
		{
			return;
		}
		Debug.LogError("UNABLE TO SAVE");
	}

	public override FileMetadata CreateNamedFileMetadata(string fileNameWithExtension, FileType fileType)
	{
		return CreatePlatformFileMetadata(fileNameWithExtension, fileType);
	}

	public FileMetadata CreatePlatformFileMetadata(string fileNameWithExtension, FileType fileType)
	{
		FileSource fileSource = FileSource.PlatformStorage;
		string a = FileManager.FolderForType(fileType);
		string text = PlatformPathCombine(a, fileNameWithExtension);
		FileMetadata fileMetadata = new FileMetadata(fileNameWithExtension, fileSource, fileType);
		string platformRootedPath = text;
		fileMetadata.platformRootedPath = platformRootedPath;
		return fileMetadata;
	}

	public override LoadResultStatus TryGetFileContents(FileMetadata file, out string fileContents)
	{
		GameUtility.PlatformDebug("Trying to load " + file.platformRootedPath + " exists? " + CloudFileExists(file.platformRootedPath) + " using cloud? " + IsUsingCloud());
		if (file.fileSource == FileSource.PlatformStorage && IsUsingCloud())
		{
			if (CloudFileExists(file.platformRootedPath))
			{
				fileContents = ReadFromCloudStorage(file.platformRootedPath);
				return LoadResultStatus.OK;
			}
			fileContents = null;
			return LoadResultStatus.NoSaveFileFound;
		}
		GameUtility.PlatformDebug("Failed to load " + file.platformRootedPath + ", cloud file does not exist");
		return base.TryGetFileContents(file, out fileContents);
	}

	public string ReadFromCloudStorage(string cloudRootedPath)
	{
		GameUtility.PlatformDebug(" Remote storage file exists? " + SteamRemoteStorage.FileExists(cloudRootedPath));
		if (SteamRemoteStorage.FileExists(cloudRootedPath))
		{
			byte[] bytes = SteamRemoteStorage.FileRead(cloudRootedPath);
			return Encoding.UTF8.GetString(bytes);
		}
		return null;
	}

	public override void DeleteFile(FileMetadata fileMetadata)
	{
		if (fileMetadata.fileSource == FileSource.PlatformStorage && !string.IsNullOrEmpty(fileMetadata.platformRootedPath))
		{
			SteamRemoteStorage.FileDelete(fileMetadata.platformRootedPath);
			fileMetadata.platformRootedPath = string.Empty;
		}
		else
		{
			base.DeleteFile(fileMetadata);
		}
	}

	public override UserLanguage GetUserLanguage()
	{
		return SteamApps.GameLanguage switch
		{
			"english" => UserLanguage.DefaultEnglish, 
			"german" => UserLanguage.German, 
			"russian" => UserLanguage.Russian, 
			"french" => UserLanguage.French, 
			"schinese" => UserLanguage.SimplifiedChinese, 
			"tchinese" => UserLanguage.TraditionalChinese, 
			"polish" => UserLanguage.Polish, 
			"japanese" => UserLanguage.Japanese, 
			"brazilian" => UserLanguage.PortugueseBrazilian, 
			"portuguese" => UserLanguage.PortugueseEuropean, 
			"spanish" => UserLanguage.Spanish, 
			"dutch" => UserLanguage.Dutch, 
			"swedish" => UserLanguage.Swedish, 
			"czech" => UserLanguage.Czech, 
			"ukrainian" => UserLanguage.Ukrainian, 
			"turkish" => UserLanguage.Turkish, 
			"italian" => UserLanguage.Italian, 
			_ => UserLanguage.DefaultEnglish, 
		};
	}

	public override bool HasEarned(AchievementType t)
	{
		if (TryGetAchievement(t, out var result))
		{
			return result.State;
		}
		return false;
	}

	public bool TryGetAchievement(AchievementType type, out Achievement result)
	{
		result = default(Achievement);
		if (achievementCache == null)
		{
			if (!SteamUserStats.Achievements.Any())
			{
				return false;
			}
			achievementCache = new Dictionary<string, Achievement>();
			foreach (Achievement achievement in SteamUserStats.Achievements)
			{
				achievementCache[achievement.Identifier] = achievement;
			}
		}
		string text = IdentifierForAchievement(type);
		if (text == null)
		{
			return false;
		}
		if (achievementCache.TryGetValue(text, out result))
		{
			return true;
		}
		return false;
	}

	public override void EarnAchievement(AchievementType type)
	{
		if (TryGetAchievement(type, out var result) && !result.State)
		{
			result.Trigger();
			areStatsStale = true;
		}
	}

	protected override string IdentifierForStat(StatType statType)
	{
		return statType.ToString();
	}

	public override int GetStatInt(StatType statType)
	{
		return SteamUserStats.GetStatInt(CachedStatIdentifier(statType));
	}

	public override float GetStatFloat(StatType statType)
	{
		return SteamUserStats.GetStatFloat(CachedStatIdentifier(statType));
	}

	public override void SetStat(StatType statType, float setValue)
	{
		SteamUserStats.SetStat(CachedStatIdentifier(statType), setValue);
		areStatsStale = true;
	}

	public override void SetStat(StatType statType, int setValue)
	{
		SteamUserStats.SetStat(CachedStatIdentifier(statType), setValue);
		areStatsStale = true;
	}

	public override void AddStat(StatType statType, int incrementValue)
	{
		SteamUserStats.AddStat(CachedStatIdentifier(statType), incrementValue);
		areStatsStale = true;
	}

	private string CachedName(AchievementType achievementType)
	{
		if (achievementLocalizationKeys.TryGetValue(achievementType, out var value))
		{
			return value;
		}
		value = achievementType.ToString();
		achievementLocalizationKeys[achievementType] = value;
		return value;
	}

	private void OnApplicationQuit()
	{
		Debug.Log("Shutting down Steam Client");
		SteamUserStats.OnUserStatsStored -= OnUserStatsStored;
		SteamUtils.OnGamepadTextInputDismissed -= HandleGamepadInput;
		SteamUserStats.OnAchievementProgress -= OnAchievementProgress;
		SteamClient.Shutdown();
		SteamClient.RunCallbacks();
	}

	public async void DeleteFileAsync(PublishedFileId fileId)
	{
		await SteamUGC.DeleteFileAsync(fileId);
	}

	public void HandleGamepadInput(bool result)
	{
	}

	public bool IsSteamDeck()
	{
		return SteamUtils.IsRunningOnSteamDeck;
	}

	public override bool AlwaysShowKeyboard()
	{
		return IsSteamDeck();
	}

	public override void TryShowGamepadTextInput(bool multiLine, string header, string initialText)
	{
		ShowTextInput(multiLine, header, initialText);
	}

	public void ShowTextInput(bool multiLine, string description, string existingText)
	{
		GamepadTextInputLineMode lineInputMode = (multiLine ? GamepadTextInputLineMode.MultipleLines : GamepadTextInputLineMode.SingleLine);
		int maxChars = int.MaxValue;
		SteamUtils.ShowGamepadTextInput(GamepadTextInputMode.Normal, lineInputMode, description, maxChars, existingText);
	}

	public void ShowFloatingTextInput()
	{
	}

	public void PrintControllers()
	{
		foreach (Controller controller2 in SteamInput.Controllers)
		{
			Controller controller = controller2;
			Debug.Log("Found controller:" + controller.ToString() + " InputType:" + controller2.InputType);
			_ = string.Empty;
		}
	}

	public void GetGlyph()
	{
		string action = "hi";
		SteamInput.GetDigitalActionGlyph(default(Controller), action);
		SteamInput.GetPngActionGlyph(default(Controller), action, GlyphSize.Medium);
	}

	public override bool IsInKeyboardMode()
	{
		if (SteamUtils.IsRunningOnSteamDeck || SteamUtils.IsSteamInBigPictureMode)
		{
			return false;
		}
		return true;
	}

	public override void PerformFinalUploads()
	{
		SteamUserStats.StoreStats();
	}

	public override string DisplayLabel()
	{
		if ((uint)SteamClient.AppId == AppId)
		{
			return "Steam - Full";
		}
		if ((uint)SteamClient.AppId == AppIdDemo)
		{
			return "Steam - Demo";
		}
		if (isPlaytest)
		{
			return "Steam - Playtest";
		}
		return "Steam - " + SteamClient.AppId.ToString();
	}

	public void TestMigration()
	{
		bool flag = !SteamRemoteStorage.Files.Any();
		bool flag2 = false;
		GameUtility.PlatformDebug("Num cloud files: " + SteamRemoteStorage.Files.Count() + " attempt? " + flag);
		if (!flag)
		{
			return;
		}
		string path = FileManager.FolderForType(FileType.SaveFile);
		string directoryFullPath = Path.Combine(Application.persistentDataPath, path);
		if (!TryMigration(directoryFullPath) || flag2)
		{
			string directoryName = Path.GetDirectoryName(Application.persistentDataPath);
			if (directoryName != null)
			{
				string directoryFullPath2 = Path.Combine(Path.Combine(directoryName, "Factory Town Idle Demo"), path);
				TryMigration(directoryFullPath2);
			}
		}
	}

	private bool TryMigration(string directoryFullPath)
	{
		GameUtility.PlatformDebug("TryMigration search " + directoryFullPath);
		DirectoryInfo directoryInfo = new DirectoryInfo(directoryFullPath);
		if (directoryInfo.Exists)
		{
			GameUtility.PlatformDebug("...TryMigration found local files!");
			FileInfo[] files = directoryInfo.GetFiles();
			FileInfo[] array = files;
			foreach (FileInfo fileInfo in array)
			{
				if (fileInfo.Extension == ".idlesav")
				{
					GameUtility.PlatformDebug("Found local file Info: " + fileInfo.Name);
					GameUtility.PlatformDebug("Found local file Info fullName: " + fileInfo.FullName);
					string fileString = Platform.ReadFromFile(fileInfo.FullName);
					string text = fileInfo.Name;
					WriteToPlatformFiles(text, FileType.SaveFile, fileString);
					GameUtility.PlatformDebug("Migrated " + text + " from " + fileInfo.FullName + " to Cloud Storage");
				}
			}
			return files.Length != 0;
		}
		GameUtility.PlatformDebug("...no such directory");
		return false;
	}

	public override string PlatformPathCombine(string a, string b)
	{
		return a + "/" + b;
	}

	public void OpenGamePageURL(string url)
	{
		SteamFriends.OpenWebOverlay(url, modal: true);
	}
}
