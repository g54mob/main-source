using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Gh.Tk;
using ICSharpCode.SharpZipLib.Zip;
using LitJson;
using Newtonsoft.Json.Linq;
using UnityEngine;
using UnityEngine.Scripting;

namespace Gh
{
	[InitializeOnGameStarted]
	public class SaveLoadManager : SingletonMonoBehaviour<SaveLoadManager>
	{
		public class SaveGameHeader
		{
			[JsonIgnore]
			private bool _profileIdSet;

			[JsonIgnore]
			private string _profileId;

			public string Id { get; set; }

			public string AuthorGreenbackUserHash { get; set; }

			public string SlotName { get; set; }

			public string Level { get; set; }

			public string LevelSceneOverride { get; set; }

			public string ScenarioId { get; set; }

			public bool IsFreeplay { get; set; }

			public int FileVersion { get; set; }

			public string GameVersion { get; set; }

			public bool HasErrorOccured { get; set; }

			public DateTime TimeStamp { get; set; }

			[JsonIgnore]
			public string TimeAgo => null;

			public string TavernId { get; set; }

			public string TavernName { get; set; }

			public int TavernMoney { get; set; }

			public float TavernStarRating { get; set; }

			public int TavernApproval { get; set; }

			public int TavernDay { get; set; }

			public int TavernDayOfWeek { get; set; }

			public int TavernHour { get; set; }

			public int TavernMinute { get; set; }

			public List<string> TavernSituationTags { get; set; }

			public string FileName { get; set; }

			public string FilePath { get; set; }

			public string ShareCode { get; set; }

			[JsonIgnore]
			public Texture2D Screenshot { get; set; }

			public static SaveGameHeader CreateFromObject(JsonData saveGameHeaderObj, string sourceFilePath = null)
			{
				return null;
			}

			public string GetProfileId()
			{
				return null;
			}
		}

		public class SaveGame
		{
			public Dictionary<string, object> Data { get; set; }
		}

		public class StaticDataSource : IStaticDataSource
		{
			private readonly byte[] _data;

			public StaticDataSource(byte[] data)
			{
			}

			public Stream GetSource()
			{
				return null;
			}
		}

		private struct GameDateTime
		{
			public readonly int day;

			public readonly int hour;

			public readonly int minute;

			public readonly double minuteFraction;

			private GameDateTime(int day, int hour, int minute, double minuteFraction)
			{
				this.day = 0;
				this.hour = 0;
				this.minute = 0;
				this.minuteFraction = 0.0;
			}

			public static GameDateTime FromTimestamp(double timestamp, int dayLength)
			{
				return default(GameDateTime);
			}

			public double ToTimestamp(int dayLength)
			{
				return 0.0;
			}
		}

		[StructLayout((LayoutKind)3)]
		[CompilerGenerated]
		private struct _003C_003Ec__DisplayClass43_0
		{
			public Action onFinishedCallback;
		}

		[CompilerGenerated]
		private sealed class _003C_003Ec__DisplayClass44_0
		{
			public float oldTimeScale;

			public Action onFinishedCallback;

			internal void _003CSaveRoutineInternal_003Eb__1()
			{
			}
		}

		[CompilerGenerated]
		private sealed class _003CAutoSaveIntervalCoroutine_003Ed__17 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public SaveLoadManager _003C_003E4__this;

			object IEnumerator<object>.Current
			{
				[DebuggerHidden]
				get
				{
					return null;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return null;
				}
			}

			[DebuggerHidden]
			public _003CAutoSaveIntervalCoroutine_003Ed__17(int _003C_003E1__state)
			{
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
			}

			private bool MoveNext()
			{
				return false;
			}

			bool IEnumerator.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				return this.MoveNext();
			}

			[DebuggerHidden]
			void IEnumerator.Reset()
			{
			}
		}

		[CompilerGenerated]
		private sealed class _003CLoadInternal_003Ed__78 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public object save;

			public SaveLoadManager _003C_003E4__this;

			public bool isNewGame;

			public string levelName;

			private IEnumerator _003Cenumerator_003E5__2;

			object IEnumerator<object>.Current
			{
				[DebuggerHidden]
				get
				{
					return null;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return null;
				}
			}

			[DebuggerHidden]
			public _003CLoadInternal_003Ed__78(int _003C_003E1__state)
			{
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
			}

			private bool MoveNext()
			{
				return false;
			}

			bool IEnumerator.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				return this.MoveNext();
			}

			[DebuggerHidden]
			void IEnumerator.Reset()
			{
			}
		}

		[CompilerGenerated]
		private sealed class _003CLoadSaveData_003Ed__84 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public SaveLoadManager _003C_003E4__this;

			public JsonData saveGame;

			private bool _003Cfinished_003E5__2;

			private JsonData _003Cdata_003E5__3;

			private JsonData _003Centities_003E5__4;

			object IEnumerator<object>.Current
			{
				[DebuggerHidden]
				get
				{
					return null;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return null;
				}
			}

			[DebuggerHidden]
			public _003CLoadSaveData_003Ed__84(int _003C_003E1__state)
			{
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
			}

			private bool MoveNext()
			{
				return false;
			}

			bool IEnumerator.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				return this.MoveNext();
			}

			private void _003C_003Em__Finally1()
			{
			}

			[DebuggerHidden]
			void IEnumerator.Reset()
			{
			}
		}

		[CompilerGenerated]
		private sealed class _003CSaveRoutine_003Ed__43 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public Action onFinishedCallback;

			public SaveLoadManager _003C_003E4__this;

			public string slotName;

			private _003C_003Ec__DisplayClass43_0 _003C_003E8__1;

			private IEnumerator _003CsaveRoutine_003E5__2;

			object IEnumerator<object>.Current
			{
				[DebuggerHidden]
				get
				{
					return null;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return null;
				}
			}

			[DebuggerHidden]
			public _003CSaveRoutine_003Ed__43(int _003C_003E1__state)
			{
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
			}

			private bool MoveNext()
			{
				return false;
			}

			bool IEnumerator.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				return this.MoveNext();
			}

			[DebuggerHidden]
			void IEnumerator.Reset()
			{
			}
		}

		[CompilerGenerated]
		private sealed class _003CSaveRoutineInternal_003Ed__44 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public Action onFinishedCallback;

			private _003C_003Ec__DisplayClass44_0 _003C_003E8__1;

			public SaveLoadManager _003C_003E4__this;

			public string slotName;

			object IEnumerator<object>.Current
			{
				[DebuggerHidden]
				get
				{
					return null;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return null;
				}
			}

			[DebuggerHidden]
			public _003CSaveRoutineInternal_003Ed__44(int _003C_003E1__state)
			{
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
			}

			private bool MoveNext()
			{
				return false;
			}

			bool IEnumerator.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				return this.MoveNext();
			}

			[DebuggerHidden]
			void IEnumerator.Reset()
			{
			}
		}

		[CompilerGenerated]
		private sealed class _003CStartLevelInternal_003Ed__79 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public string levelName;

			public SaveLoadManager _003C_003E4__this;

			public string sceneOverride;

			public bool isNewGame;

			private IEnumerator _003Cenumerator_003E5__2;

			object IEnumerator<object>.Current
			{
				[DebuggerHidden]
				get
				{
					return null;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return null;
				}
			}

			[DebuggerHidden]
			public _003CStartLevelInternal_003Ed__79(int _003C_003E1__state)
			{
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
			}

			private bool MoveNext()
			{
				return false;
			}

			bool IEnumerator.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				return this.MoveNext();
			}

			[DebuggerHidden]
			void IEnumerator.Reset()
			{
			}
		}

		public static int FILEVERSION;

		public const string TYPEHINTINGFIELD = "__Type";

		public const string HIERARCHY = "_hierarchy";

		public static readonly string SaveNumberPrefixKey;

		private static readonly string QuickSaveNumberPrefixKey;

		public static readonly string AutosaveSlotNameKey;

		private static readonly string AutosaveIntervalSlotNameKey;

		public static Dictionary<ReferencableLookupKey, object> referenceableObjects;

		private int _minutesSinceLastAutoSave;

		private static readonly Dictionary<string, string> _typeHintingAliases;

		private Action _actionOnLateUpdate;

		private static Dictionary<string, Func<bool>> _situationTags;

		private string _loadError;

		public List<GameItem> GameItems;

		public List<Action> LateRestoreCalls;

		public List<Action> RestoreHierarchyCalls;

		private bool _isLoading;

		private const string STARTING_SPEED_KEY = "startingSpeed";

		private int _startingSpeed;

		private const string SAVEHEADER_FILENAME = "meta";

		private const string SAVEDATA_FILENAME = "content";

		private const string SERIALIZED_FILE_EXTENSION = "json";

		private const string SCREENSHOT_FILENAME = "screenshot";

		private const string SCREENSHOT_EXTENSION = "jpg";

		public const string ZIPFILE_EXTENSION = "tavern";

		public const string MAIN_SHARE_CODE_PREFIX = "TK";

		private static string[] _shareCodePrefixes;

		private const int _shareCodeHashLength = 8;

		private const string SAVEHEADERCACHE_BASEFILENAME = "tk_saveheaders.cache";

		public static List<SaveGameHeader> SaveHeadersCache;

		private static bool _isSaveHeaderCacheDirty;

		private (int from, int to, Action<int> method)[] _postLoadMigrationMethods;

		private (int from, int to, Action<SaveGameHeader, JObject> method)[] _methods;

		private const int _minSupportedFileVersion = 10;

		private int _loadedFileVersion;

		public bool IsLoading
		{
			get
			{
				return false;
			}
			private set
			{
			}
		}

		public bool IsSaving { get; private set; }

		public bool HasErrorOccured { get; set; }

		public SaveGameHeader LastLoadAttempted { get; set; }

		public float LastSavedGameTime { get; private set; }

		private static string SAVEHEADER_FULLFILENAME => null;

		public static event EventHandler PreSaveEvent
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public static event EventHandler PreLoadEvent
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public static event EventHandler PostLoadEvent
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public static event EventHandler PostSavedEvent
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public static event EventHandler PreFirstUpdateAfterLoadingEvent
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public static event EventHandler LoadingAborted
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public static event EventHandler SaveHeaderCacheUpdated
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		[Preserve]
		private static void OnGameStarted()
		{
		}

		public static void InitializeJsonMapper()
		{
		}

		protected SaveLoadManager()
		{
		}

		public override void Awake()
		{
		}

		public void AutoSave(Action onComplete = null)
		{
		}

		[IteratorStateMachine(typeof(_003CAutoSaveIntervalCoroutine_003Ed__17))]
		private IEnumerator AutoSaveIntervalCoroutine()
		{
			return null;
		}

		private static void ExportPersistable<T>(JsonWriter writer, T value) where T : IPersistable
		{
		}

		public static Type GetTypeFromTypeHintingString(string typeString)
		{
			return null;
		}

		private static object ImportPersistable(JsonData data)
		{
			return null;
		}

		public void DeleteAllSavesForTavern(string tavernId)
		{
		}

		private void LateUpdate()
		{
		}

		public bool IsSavingAllowedInSlot(string slotName, out string errorMessage)
		{
			errorMessage = null;
			return false;
		}

		public bool IsPlayerSavingAllowed(out string errorMessage)
		{
			errorMessage = null;
			return false;
		}

		public void Save(string slotName, Action onComplete = null)
		{
		}

		public void SaveForFeedback(Action<Stream> onStreamReadyCallback, Action onError)
		{
		}

		private SaveGameHeader CreateSaveHeader(string slotName)
		{
			return null;
		}

		private SaveGame CreateSaveData()
		{
			return null;
		}

		private static void SetupSituationTags()
		{
		}

		public static void AddSituationTag(string tag, Func<bool> tagDecider)
		{
		}

		private List<string> GetSituationTags()
		{
			return null;
		}

		private byte[] CreateScreenshot()
		{
			return null;
		}

		[IteratorStateMachine(typeof(_003CSaveRoutine_003Ed__43))]
		private IEnumerator SaveRoutine(string slotName, Action onFinishedCallback)
		{
			return null;
		}

		[IteratorStateMachine(typeof(_003CSaveRoutineInternal_003Ed__44))]
		private IEnumerator SaveRoutineInternal(string slotName, Action onFinishedCallback)
		{
			return null;
		}

		private object[] SaveLevelStaticObjects()
		{
			return null;
		}

		private static object[] SaveEntities()
		{
			return null;
		}

		public static void LoadScreenshotsIntoCardsAsync(IEnumerable<SaveGameCard3DUIView> cards)
		{
		}

		[IteratorStateMachine(typeof(_003CLoadInternal_003Ed__78))]
		private IEnumerator LoadInternal(object save, bool isNewGame, string levelName = null)
		{
			return null;
		}

		[IteratorStateMachine(typeof(_003CStartLevelInternal_003Ed__79))]
		private IEnumerator StartLevelInternal(string levelName, string sceneOverride, bool isNewGame)
		{
			return null;
		}

		public void StartLevel(string levelName, string scenarioId)
		{
		}

		public void Load(SaveGameHeader header, bool isNewGame = false, string levelName = null, Action postLateRestoreCallback = null)
		{
		}

		public void Load(object save, List<string> loadingScreenTags = null, bool isNewGame = false, string levelName = null, Action postLateRestoreCallback = null)
		{
		}

		private void AbortLoading(Exception ex = null)
		{
		}

		[IteratorStateMachine(typeof(_003CLoadSaveData_003Ed__84))]
		private IEnumerator LoadSaveData(JsonData saveGame)
		{
			return null;
		}

		private void RecalculateIngredientRecipes()
		{
		}

		private static void ReCalculateRecipe(IngredientTemplate ingredient)
		{
		}

		private void RestoreLevelStaticObjects(JsonData data)
		{
		}

		private void RestoreReferences(bool disableLogging = false, JsonData save = null)
		{
		}

		private IEnumerable<ILevelStaticObject> GetLevelStaticObjects()
		{
			return null;
		}

		private void ClearScene()
		{
		}

		private void RestoreEntity(JsonData data)
		{
		}

		public string GetNextSaveSlotName(string prefix)
		{
			return null;
		}

		public int GetNextSaveSlotNumber(string prefix)
		{
			return 0;
		}

		public void LoadRecentSave()
		{
		}

		public void Save(string label, int maxNumberedSlotsForLabel, Action onComplete = null)
		{
		}

		public void QuickSave()
		{
		}

		private void InitControls()
		{
		}

		private void ApplyStartingSpeed()
		{
		}

		public void CleanUpOlderSaves(int maxAgeDays = 7, int minSavePerTavern = 5)
		{
		}

		public SaveGameHeader GetMostRecentSave(string tavernId)
		{
			return null;
		}

		public SaveGameHeader GetMostRecentSaveForCurrentTavern()
		{
			return null;
		}

		public static void DeleteSaveFile(string filePath)
		{
		}

		public static bool WriteSaveToProfile(SaveGameHeader saveHeader, SaveGame saveGameData, byte[] screenshot)
		{
			return false;
		}

		public static (SaveGameHeader, string) ReadSaveFile(string filePath, Platform.StorageLocation storageLocation = Platform.StorageLocation.RemotePreferred)
		{
			return default((SaveGameHeader, string));
		}

		public static (SaveGameHeader, string) UnpackSaveFileData(Stream stream)
		{
			return default((SaveGameHeader, string));
		}

		public static bool ValidateShareCode(string shareCode)
		{
			return false;
		}

		public static void AttachShareCode(string shareCode, SaveGameHeader header)
		{
		}

		public static void ApplySaveHeaderToSaveFile(SaveGameHeader header)
		{
		}

		public static void LoadScreenshotForHeader(SaveGameHeader header)
		{
		}

		public static void LoadScreenshotForHeader(SaveGameHeader header, Stream fileStream)
		{
		}

		public static void LoadScreenshotForHeader(SaveGameHeader header, ZipFile zipFile)
		{
		}

		public static byte[] ExtractScreenshot(Stream stream)
		{
			return null;
		}

		public static byte[] ExtractScreenshot(ZipFile zipFile)
		{
			return null;
		}

		public static SaveGameHeader GetSaveGameHeader(string relativeFilePath)
		{
			return null;
		}

		private static List<string> GetValidSavePathsForProfile(PlayerProfile profile)
		{
			return null;
		}

		public static string ImportLocalSave(string absoluteFilePath, string profileId, string importedFileNameSuffix)
		{
			return null;
		}

		public static void MarkAsCorruptedFile(string filePath)
		{
		}

		public static void MarkSaveHeaderCacheDirty()
		{
		}

		public static IEnumerable<SaveGameHeader> GetSaveHeadersForProfile(string profileId)
		{
			return null;
		}

		public static IEnumerable<SaveGameHeader> GetSaveHeadersForCurrentProfile()
		{
			return null;
		}

		public static IEnumerable<SaveGameHeader> GetSaveHeaderForCurrentProfile(string levelId, string tavernId = null)
		{
			return null;
		}

		public static string GetSaveHeaderCacheFilePath(string profileId)
		{
			return null;
		}

		public static void LoadSaveHeaderCache(PlayerProfile profile, Action onComplete)
		{
		}

		private static void RefreshSaveHeaderCache(PlayerProfile playerProfile, Action onComplete)
		{
		}

		private static void WriteSaveGameHeaderCache(string profileId)
		{
		}

		private static void AddSaveToCache(SaveGameHeader header)
		{
		}

		private static bool ValidateSaveHeadersCache(PlayerProfile profile)
		{
			return false;
		}

		private void UpdateSaveHeaderCache()
		{
		}

		private static void CompressFilesToStream(Stream writeStream, params (string name, byte[] data)[] files)
		{
		}

		private static void CompressToStream(string entryName, byte[] bytes, ZipOutputStream zipStream)
		{
		}

		private static JsonData ExtractJsonFromZipFile(string zipEntryFileName, ZipFile zipFile)
		{
			return null;
		}

		private static string ExtractTextFromZipFile(string zipEntryFileName, ZipFile zipFile)
		{
			return null;
		}

		private static byte[] ExtractBytesFromZipFile(string zipEntryFileName, ZipFile zipFile)
		{
			return null;
		}

		private Action<int> GetPostLoadMigrationMethod(int from, int to)
		{
			return null;
		}

		private Action<SaveGameHeader, JObject> GetMigrationMethod(int from, int to)
		{
			return null;
		}

		private string MigrateSaveFile(SaveGameHeader header, string json)
		{
			return null;
		}

		[MigrateSaveFile(10, 11)]
		[Preserve]
		private void MigrateFrom10To11(SaveGameHeader header, JObject json)
		{
		}

		private JObject FindStaffDataWithId(JObject data, int id)
		{
			return null;
		}

		[MigrateSaveFile(11, 12)]
		[Preserve]
		private void MigrateFrom11To12(SaveGameHeader header, JObject json)
		{
		}

		[MigrateSaveFile(12, 13)]
		[Preserve]
		private void MigrateFrom12To13(SaveGameHeader header, JObject json)
		{
		}

		[MigrateSaveFile(13, 14)]
		[Preserve]
		private void MigrateFrom13To14(SaveGameHeader header, JObject json)
		{
		}

		private JObject GetGameItemWithId(JObject data, int id)
		{
			return null;
		}

		private static void RemoveAiComponents(JObject json, string[] typesToRemove)
		{
		}

		[MigrateSaveFile(14, 15)]
		[Preserve]
		private void MigrateFrom14To15(SaveGameHeader header, JObject json)
		{
		}

		[MigrateSaveFile(15, 16)]
		[Preserve]
		private void MigrateFrom15To16(SaveGameHeader header, JObject json)
		{
		}

		private static void RemoveGameItemTemplates(JObject json, string[] templatesToRemove)
		{
		}

		[MigrateSaveFile(16, 17)]
		[Preserve]
		private void MigrateFrom16To17(SaveGameHeader header, JObject json)
		{
		}

		[MigrateSaveFile(17, 18)]
		[Preserve]
		private void MigrateFrom17To18(SaveGameHeader header, JObject json)
		{
		}

		[MigrateSaveFile(18, 19)]
		[Preserve]
		private void MigrateFrom18To19(SaveGameHeader header, JObject json)
		{
		}

		[PostLoadMigrateSaveFile(18, 19)]
		[Preserve]
		private void PostLoadMigrateFrom18To19(int fileVersion)
		{
		}

		[MigrateSaveFile(19, 20)]
		[Preserve]
		private void MigrateFrom19To20(SaveGameHeader header, JObject json)
		{
		}

		[MigrateSaveFile(20, 21)]
		[Preserve]
		private void MigrateFrom20To21(SaveGameHeader header, JObject json)
		{
		}

		[MigrateSaveFile(21, 22)]
		[Preserve]
		private void MigrateFrom21To22(SaveGameHeader header, JObject json)
		{
		}

		[MigrateSaveFile(22, 23)]
		[Preserve]
		private void MigrateFrom22To23(SaveGameHeader header, JObject json)
		{
		}

		[PostLoadMigrateSaveFile(22, 23)]
		[Preserve]
		private void PostLoadMigrateFrom22To23(int fileVersion)
		{
		}

		[MigrateSaveFile(23, 24)]
		[Preserve]
		private void MigrateFrom23To24(SaveGameHeader header, JObject json)
		{
		}

		[MigrateSaveFile(24, 25)]
		[Preserve]
		private void MigrateFrom24To25(SaveGameHeader header, JObject json)
		{
		}

		[MigrateSaveFile(25, 26)]
		[Preserve]
		private void MigrateFrom25To26(SaveGameHeader header, JObject json)
		{
		}

		[MigrateSaveFile(26, 27)]
		[Preserve]
		private void MigrateFrom26To27(SaveGameHeader header, JObject json)
		{
		}

		[PostLoadMigrateSaveFile(26, 27)]
		[Preserve]
		private void PostLoadMigrateFrom26To27(int fileVersion)
		{
		}

		[MigrateSaveFile(27, 28)]
		[Preserve]
		private void MigrateFrom27To28(SaveGameHeader header, JObject json)
		{
		}

		[MigrateSaveFile(28, 29)]
		[Preserve]
		private void MigrateFrom28To29(SaveGameHeader header, JObject json)
		{
		}

		[PostLoadMigrateSaveFile(28, 29)]
		[Preserve]
		private void PostLoadMigrateFrom28To29(int fileVersion)
		{
		}

		[MigrateSaveFile(29, 30)]
		[Preserve]
		private void MigrateFrom29To30(SaveGameHeader header, JObject json)
		{
		}

		[MigrateSaveFile(30, 31)]
		[Preserve]
		private void MigrateFrom30To31(SaveGameHeader header, JObject json)
		{
		}

		[MigrateSaveFile(31, 32)]
		[Preserve]
		private void MigrateFrom31To32(SaveGameHeader header, JObject json)
		{
		}

		[MigrateSaveFile(32, 33)]
		[Preserve]
		private void MigrateFrom32To33(SaveGameHeader header, JObject json)
		{
		}

		[MigrateSaveFile(33, 34)]
		[Preserve]
		private void MigrateFrom33To34(SaveGameHeader header, JObject json)
		{
		}

		[MigrateSaveFile(34, 35)]
		[Preserve]
		private void MigrateFrom34To35(SaveGameHeader header, JObject json)
		{
		}

		[MigrateSaveFile(35, 36)]
		[Preserve]
		private void MigrateFrom35To36(SaveGameHeader header, JObject json)
		{
		}

		[MigrateSaveFile(36, 37)]
		[Preserve]
		private void MigrateFrom36To37(SaveGameHeader header, JObject json)
		{
		}

		private void ChangeSecondsPerGameDay(JObject data, int oldDayLength, int newDayLength)
		{
		}

		[MigrateSaveFile(37, 38)]
		[Preserve]
		private void MigrateFrom37To38(SaveGameHeader header, JObject json)
		{
		}

		private void ReplaceJsonExactQuotedStrings(JObject jsonObject, (string old, string @new)[] replaceTuples)
		{
		}

		private void ReplaceRawJsonText(JObject jsonObject, (string old, string @new)[] replaceTuples)
		{
		}

		[MigrateSaveFile(38, 39)]
		[Preserve]
		private void MigrateFrom38To39(SaveGameHeader header, JObject json)
		{
		}

		[MigrateSaveFile(39, 40)]
		[Preserve]
		private void MigrateFrom39To40(SaveGameHeader header, JObject json)
		{
		}

		[MigrateSaveFile(40, 41)]
		[Preserve]
		private void MigrateFrom40To41(SaveGameHeader header, JObject json)
		{
		}

		[MigrateSaveFile(41, 42)]
		[Preserve]
		private void MigrateFrom41To42(SaveGameHeader header, JObject json)
		{
		}

		[MigrateSaveFile(42, 43)]
		[Preserve]
		private void MigrateFrom42To43(SaveGameHeader header, JObject json)
		{
		}

		[MigrateSaveFile(43, 44)]
		[Preserve]
		private void MigrateFrom43To44(SaveGameHeader header, JObject json)
		{
		}

		private static void RemoveGameEventType(string typeName, JObject json)
		{
		}

		[MigrateSaveFile(44, 45)]
		[Preserve]
		private void MigrateFrom44To45(SaveGameHeader header, JObject json)
		{
		}

		[PostLoadMigrateSaveFile(44, 45)]
		[Preserve]
		private void PostLoadMigrateFrom44To45(int fileVersion)
		{
		}

		[MigrateSaveFile(45, 46)]
		[Preserve]
		private void MigrateFrom45To46(SaveGameHeader header, JObject json)
		{
		}

		[PostLoadMigrateSaveFile(45, 46)]
		[Preserve]
		private void PostLoadMigrateFrom45To46(int fileVersion)
		{
		}

		private void TryCompleteActiveStory(string id)
		{
		}

		[MigrateSaveFile(46, 47)]
		[Preserve]
		private void MigrateFrom46To47(SaveGameHeader header, JObject json)
		{
		}

		[PostLoadMigrateSaveFile(46, 47)]
		[Preserve]
		private void PostLoadMigrateFrom46To47(int fileVersion)
		{
		}

		[PostLoadMigrateSaveFile(19, 20)]
		[Preserve]
		private void PostLoadMigrateFrom19To20(int fileVersion)
		{
		}

		[MigrateSaveFile(47, 48)]
		[Preserve]
		private void MigrateFrom47To48(SaveGameHeader header, JObject json)
		{
		}

		[PostLoadMigrateSaveFile(47, 48)]
		[Preserve]
		private void PostLoadMigrateFrom47To48(int fileVersion)
		{
		}
	}
}
