using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;
using Battle;
using SaveData;
using UI;
using UnityEngine;

namespace Libs
{
	public static class PseudoPlayerPrefs
	{
		public record RecordItem(int index, eWriterId writerId, int ascensionLevel, eClearState clearState, int lastWave, eLuggage[] usedUnits, DateTime playEndDate, string version, string filePath, eChallengeId challengeId, int score, bool isEndless)
		{
			[CompilerGenerated]
			protected virtual Type EqualityContract
			{
				[CompilerGenerated]
				get
				{
					return null;
				}
			}

			public int index { get; set; }

			public eWriterId writerId { get; set; }

			public int ascensionLevel { get; set; }

			public eClearState clearState { get; set; }

			public int lastWave { get; set; }

			public eLuggage[] usedUnits { get; set; }

			public DateTime playEndDate { get; set; }

			public string version { get; set; }

			public string filePath { get; set; }

			public eChallengeId challengeId { get; set; }

			public int score { get; set; }

			public bool isEndless { get; set; }

			[CompilerGenerated]
			public override string ToString()
			{
				return null;
			}

			[CompilerGenerated]
			protected virtual bool PrintMembers(StringBuilder builder)
			{
				return false;
			}

			[CompilerGenerated]
			public virtual bool Equals(RecordItem? other)
			{
				return false;
			}

			[CompilerGenerated]
			protected RecordItem(RecordItem original)
			{
			}

			[CompilerGenerated]
			public void Deconstruct(out int index, out eWriterId writerId, out int ascensionLevel, out eClearState clearState, out int lastWave, out eLuggage[] usedUnits, out DateTime playEndDate, out string version, out string filePath, out eChallengeId challengeId, out int score, out bool isEndless)
			{
				index = default(int);
				writerId = default(eWriterId);
				ascensionLevel = default(int);
				clearState = default(eClearState);
				lastWave = default(int);
				usedUnits = null;
				playEndDate = default(DateTime);
				version = null;
				filePath = null;
				challengeId = default(eChallengeId);
				score = default(int);
				isEndless = default(bool);
			}
		}

		private static readonly int historySize;

		public static readonly int profileSize;

		private static readonly int recordSize;

		private static readonly int recordChallengeSize;

		private static readonly int recordFavoriteSize;

		private static readonly int recordChallengeFavoriteSize;

		private static readonly string HistoryAutoSaveFileNameFormat;

		private static readonly Regex HistoryAutoSaveFileNameRegex;

		private static readonly Regex ChallengeRecordFileNameRegex;

		private static Dictionary<string, string> Cache;

		private static Dictionary<string, string> CacheLocal;

		private static VersionData _versionData;

		private static int _profileNumber;

		private static readonly string SelectedProfile;

		private static string _saveRoot;

		private static readonly string HistoryRoot;

		private static readonly string zipExtension;

		public const string RecordChallengePrefix = "challenge";

		private static readonly string ScreenShotFileName;

		private static readonly string ScreenShotLargeFileName;

		private static string justBeforeSaveRecordFileName;

		private static readonly string PlayLogFavorite;

		public static int recordLengthMax => 0;

		public static int recordChallengeLengthMax => 0;

		public static int recordFavoriteLengthMax => 0;

		public static int recordChallengeFavoriteLengthMax => 0;

		private static string SaveDirPostFix => null;

		private static string ProfileNumberStr => null;

		public static bool IsWriteOk => false;

		public static bool IsReadOk => false;

		private static string SaveRootDefault => null;

		private static string GetSaveRootDemo => null;

		private static string SaveDirInFix => null;

		public static bool ExistsDemoVerSaveData => false;

		public static string DemoVerSaveDataFullPath => null;

		private static void InitProfile()
		{
		}

		public static void ChangeProfile(int number)
		{
		}

		public static int GetProfileNumber()
		{
			return 0;
		}

		private static string GetSpecificProfileNumberStr(int profileNumber = -1)
		{
			return null;
		}

		public static VersionData LoadVersionData()
		{
			return null;
		}

		public static void SetVersionData()
		{
		}

		private static string ConstructSavePath(string parentDir, string name)
		{
			return null;
		}

		private static string GetFullPath(string path)
		{
			return null;
		}

		private static void CreateDirectory(string dirName)
		{
		}

		private static void DeleteDirectory(string dirName)
		{
		}

		private static bool DirectoryExists(string filePath)
		{
			return false;
		}

		private static string[] GetDirectoryFiles(string dirPath, string searchPattern)
		{
			return null;
		}

		private static void MoveDirectory(string dirPath, string newDirPath)
		{
		}

		private static string LoadTextFile(string filePath)
		{
			return null;
		}

		private static byte[] LoadBinaryFile(string filePath)
		{
			return null;
		}

		private static void SaveTextFile(string filePath, string json)
		{
		}

		private static void SaveBinaryFile(string filePath, byte[] data)
		{
		}

		public static bool FileExists(string filePath)
		{
			return false;
		}

		public static bool RecordExists(string filePath)
		{
			return false;
		}

		private static void DeleteFile(string filePath)
		{
		}

		private static string GetLastWriteTime(string filePath, string format)
		{
			return null;
		}

		private static string GetSaveRootDir()
		{
			return null;
		}

		private static string GetHistoryRootDir()
		{
			return null;
		}

		public static string GetSaveDir()
		{
			return null;
		}

		private static string GetSaveSpecificDir(int profileNumber)
		{
			return null;
		}

		private static string GetSaveTmpDir()
		{
			return null;
		}

		private static string GetSaveBackupDir()
		{
			return null;
		}

		private static string GetSaveLocalDir()
		{
			return null;
		}

		private static string GetSaveLocalTmpDir()
		{
			return null;
		}

		private static string GetSaveLocalBackupDir()
		{
			return null;
		}

		private static string GetRecordRootDir()
		{
			return null;
		}

		private static string GetRecordDir()
		{
			return null;
		}

		private static string HistoryDir(string dirName)
		{
			return null;
		}

		private static string SaveFilePath(string key)
		{
			return null;
		}

		private static string SaveSpecificFilePath(string key, int profileNumber)
		{
			return null;
		}

		private static string SaveLocalFilePath(string key)
		{
			return null;
		}

		private static string SaveTmpFilePath(string key)
		{
			return null;
		}

		private static string SaveLocalTmpFilePath(string key)
		{
			return null;
		}

		private static string SaveBackupFilePath(string key)
		{
			return null;
		}

		private static string HistoryFilePath(string dirName, string key)
		{
			return null;
		}

		private static string RecordFilePath(string dirName, string key)
		{
			return null;
		}

		private static string RecordScreenShotPath(string dirName)
		{
			return null;
		}

		private static string RecordZipPath(string key)
		{
			return null;
		}

		public static void ClearJustBeforeSaveRecordFileName()
		{
		}

		public static (string, string) GetSaveDriveInfo()
		{
			return default((string, string));
		}

		private static string ToHumanReadableSize(long fileSize)
		{
			return null;
		}

		public static void Init()
		{
		}

		private static void InitializeLocalSaveData()
		{
		}

		private static void InitializeSaveData()
		{
		}

		public static bool HasKey(string key, bool neverLoad = false)
		{
			return false;
		}

		public static bool HasKeyLocal(string key)
		{
			return false;
		}

		private static void LoadKey(string key)
		{
		}

		private static string LoadKeyDirect(string key)
		{
			return null;
		}

		private static void LoadKeyLocal(string key)
		{
		}

		public static bool Save(bool history = false)
		{
			return false;
		}

		private static void SaveLastResortFile(string key, string encryptedText)
		{
		}

		public static void PreserveImportantFiles(string key)
		{
		}

		public static bool SaveLocal()
		{
			return false;
		}

		[Conditional("SHAPED_DE_NEVER_DEFINED_SYMBOL")]
		public static void UseHistory(string historyDir)
		{
		}

		public static void SetString(string key, string value, Version inGameVersion = null, bool neverLoad = false)
		{
		}

		public static void SetStringLocal(string key, string value)
		{
		}

		public static string GetString(string key, string defaultValue)
		{
			return null;
		}

		public static string GetStringLocal(string key, string defaultValue)
		{
			return null;
		}

		public static string GetString(string key)
		{
			return null;
		}

		public static string GetStringLocal(string key)
		{
			return null;
		}

		public static string GetStringDirectSpecificProfile(string key, int profileNumber)
		{
			return null;
		}

		public static string GetLastUpdateDirectSpecificProfile(string key, int profileNumber)
		{
			return null;
		}

		public static bool DeleteKey(string key)
		{
			return false;
		}

		public static bool DeleteKeyLocal(string key)
		{
			return false;
		}

		private static string GetPlayLogFavoriteFileNameWithProfile(int profileNumber = -1)
		{
			return null;
		}

		public static PlayLogDialog.PlayLogFavorite GetFavorite()
		{
			return null;
		}

		public static List<string> GetFavoriteList(bool isChallenge)
		{
			return null;
		}

		public static void SetFavorite(PlayLogDialog.PlayLogFavorite playLogFavorite)
		{
		}

		public static void RefleshFavoriteList(ref PlayLogDialog.PlayLogFavorite playLogFavorite)
		{
		}

		public static bool SetFavorite(ref PlayLogDialog.PlayLogFavorite playLogFavorite, string path)
		{
			return false;
		}

		private static string GetRecordKeyString(string filePath, string key)
		{
			return null;
		}

		public static string GetInGameJson(string path)
		{
			return null;
		}

		public static Texture2D GetScreenShot(string path)
		{
			return null;
		}

		public static Texture2D GetScreenShotLarge(string path)
		{
			return null;
		}

		public static List<RecordItem> GetRecordList(int skip, int take, bool isChallengeMode = false, List<string> favoriteList = null)
		{
			return null;
		}

		private static eLuggage[] GetSallyCountTop3(List<WaveLog> historyList)
		{
			return null;
		}

		private static eLuggage[] GetDamageCountTop3(List<WaveLog> historyList)
		{
			return null;
		}

		public static int GetRecordCount(bool isChallengeMode = false, List<string> favoriteList = null)
		{
			return 0;
		}

		public static bool SaveRecord(string key, string dataJson, Texture2D screenshot, bool isChallengeMode = false)
		{
			return false;
		}

		public static bool SaveScreenShot(Texture2D screenshot)
		{
			return false;
		}

		public static void DeleteAllRecord()
		{
		}

		private static void SaveScreenShot(string dir, Texture2D screenshot)
		{
		}

		public static int GetPageContentsCountMax(bool isChallenge, bool isFavorite)
		{
			return 0;
		}
	}
}
