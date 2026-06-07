using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;
using Gh.Tk.Story;
using LitJson;
using Newtonsoft.Json.Linq;

namespace Gh.Tk
{
	[Serializable]
	public class PlayerProfile : IPersistable
	{
		public enum TooltipQuickLockMode
		{
			QuickLockHold = 0,
			QuickLockToggle = 1
		}

		public enum ZoomAndRotateMode
		{
			CentreFocused = 0,
			MouseFocused = 1
		}

		public enum FocusMode
		{
			Raycast = 0,
			Selection = 1
		}

		[Serializable]
		public class AchievementEntry : IPersistable
		{
			public string id;

			public DateTime timestamp;
		}

		private const float SECONDS_BETWEEN_AUTO_SAVES = 30f;

		public List<string> CorruptedFiles;

		private Dictionary<string, UnlockState> _unlockStates;

		private static Dictionary<string, UnlockState> _defaultUnlockStates;

		private List<string> _seenRewards;

		private const string ProfileVersionValuePrefix = "PROFILE_FORMAT_VERSION:";

		private string _fileVersion;

		private const int FILE_VERSION = 2;

		private DataStore _settings;

		[JsonAlias("id", true)]
		private string _id;

		private ulong _createdBySteamId;

		private DateTime _createdAt;

		[JsonAlias("name", true)]
		private string _name;

		private bool _emailPolicyAccepted;

		private bool _privacyPolicyAccepted;

		public const int MaxAutoSavesDefaultValue = 5;

		public const int MaxQuickSavesDefaultValue = 10;

		public const float PatienceMeterVisibilityThresholdDefaultValue = 66f;

		public const int DEFAULT_VOLUME_LEVEL = 75;

		private List<string> _visitedCodexLinks;

		private string _lastLevelSavedOn;

		private List<AchievementEntry> _unlockedAchievementLog;

		[JsonIgnore]
		[IgnoreDataMember]
		private GameStats _playerStats;

		private List<string> _regionAnimationsPlayed;

		[JsonAlias("screenshotFolder", true)]
		private string _screenshotFolder;

		private DataStore _storyData;

		private Dictionary<string, StoryManager.StoryTriggeredLog> _triggeredStories;

		private List<ProfileUnlock> _unlocks;

		[JsonIgnore]
		[IgnoreDataMember]
		private Dictionary<UnlockType, HashSet<string>> _unlockCache;

		private List<string> _propsWaitingToBeUnlocked;

		private List<string> _seenUnlocksInUI;

		private List<string> _unseenImportedIds;

		private List<string> _seenUnlocksInUnlockScreen;

		private GameDifficultySettingsData _gameDifficultySettingsData;

		private DataStore _cameraPresets;

		private static List<string> DefaultAvailableTopics;

		private List<string> _handbookTopics;

		public static EventHandler<EventArgs<string>> HandbookTopicAdded;

		private Dictionary<string, int> _skills;

		private List<string> _seenStarReveals;

		private static FrameCachedValue<int> _secondsPlayedFrameCacheValue;

		internal List<string> _pendingRewardIds;

		internal Dictionary<string, DevCommentaryProfileData> _devCommentaryData;

		public static EventHandler<EventArgs<bool>> FullInnerWallsSettingsChanged;

		public const string PROFILE_FOLDER = "profiles";

		public const string PROFILE_FILEPREFIX = "profile-";

		public const string PROFILE_EXTENSION = "profile";

		private static List<PlayerProfile> _profilesCache;

		[JsonIgnore]
		[IgnoreDataMember]
		private bool _isDirty;

		[JsonIgnore]
		[IgnoreDataMember]
		private float _secondsCounter;

		[JsonIgnore]
		[IgnoreDataMember]
		private bool _isSaving;

		private bool _saveWaitingForPopup;

		[JsonIgnore]
		[IgnoreDataMember]
		public static PlayerProfile Current { get; private set; }

		[JsonIgnore]
		[IgnoreDataMember]
		public Dictionary<string, UnlockState> AllUnlockStates => null;

		[JsonIgnore]
		[IgnoreDataMember]
		public string Id
		{
			get
			{
				return null;
			}
			private set
			{
			}
		}

		[JsonIgnore]
		[IgnoreDataMember]
		public ulong CreatedBySteamId
		{
			get
			{
				return 0uL;
			}
			private set
			{
			}
		}

		[JsonIgnore]
		[IgnoreDataMember]
		public DateTime CreatedAt
		{
			get
			{
				return default(DateTime);
			}
			private set
			{
			}
		}

		[JsonIgnore]
		[IgnoreDataMember]
		public string Name
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		[JsonIgnore]
		[IgnoreDataMember]
		public string EMail
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		[JsonIgnore]
		[IgnoreDataMember]
		public bool EmailPolicyAccepted
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		[JsonIgnore]
		[IgnoreDataMember]
		public bool PrivacyPolicyAccepted
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		[JsonIgnore]
		[IgnoreDataMember]
		public bool EnableDevCommentary
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		[JsonIgnore]
		[IgnoreDataMember]
		public bool FurnitureOcclusionEnabled
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		[JsonIgnore]
		[IgnoreDataMember]
		public bool AutoSaveEveryGameDay
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		[JsonIgnore]
		[IgnoreDataMember]
		public int MaxAutoSaves
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		[JsonIgnore]
		[IgnoreDataMember]
		public int MaxQuickSaves
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		[JsonIgnore]
		[IgnoreDataMember]
		public bool Use12HourClock
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		[JsonIgnore]
		[IgnoreDataMember]
		public float PatienceMeterVisibilityThreshold
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		[JsonIgnore]
		[IgnoreDataMember]
		public bool AutoPauseInBuildMode
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		[JsonIgnore]
		[IgnoreDataMember]
		public bool EnablePlayTimeReminders
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		[JsonIgnore]
		[IgnoreDataMember]
		public bool NoMenuTransitions
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		[JsonIgnore]
		[IgnoreDataMember]
		public bool FxDisableLightningFlashesInStorms
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		[JsonIgnore]
		[IgnoreDataMember]
		public bool FxDisableScreenShakes
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		[JsonIgnore]
		[IgnoreDataMember]
		public bool FxDisableNarrationSentenceHighlights
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		[JsonIgnore]
		[IgnoreDataMember]
		public bool DisableFreeCameraMovementParticles
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		[JsonIgnore]
		[IgnoreDataMember]
		public bool AutoPrioritizeConfirmedGroups
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		[JsonIgnore]
		[IgnoreDataMember]
		public bool EnablePriorityVisuals
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		[JsonIgnore]
		[IgnoreDataMember]
		public bool SkipIntroVideo
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		[JsonIgnore]
		[IgnoreDataMember]
		public int IntroVideoManuallySkipped
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		[JsonIgnore]
		[IgnoreDataMember]
		public bool AutoContinueAfterLoad
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		[JsonIgnore]
		[IgnoreDataMember]
		public bool AutoPauseWhenGameStarts
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		[JsonIgnore]
		[IgnoreDataMember]
		public bool RunGameInBackground
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		[JsonIgnore]
		[IgnoreDataMember]
		public bool EnablePrivacyMode
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		[JsonIgnore]
		[IgnoreDataMember]
		public float TooltipShowDelay
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		[JsonIgnore]
		[IgnoreDataMember]
		public float TooltipHideDelay
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		[JsonIgnore]
		[IgnoreDataMember]
		public float TooltipLockInTime
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		[JsonIgnore]
		[IgnoreDataMember]
		public TooltipQuickLockMode CurrentTooltipQuickLockMode
		{
			get
			{
				return default(TooltipQuickLockMode);
			}
			set
			{
			}
		}

		[JsonIgnore]
		[IgnoreDataMember]
		public ZoomAndRotateMode MouseScrollMode
		{
			get
			{
				return default(ZoomAndRotateMode);
			}
			set
			{
			}
		}

		[JsonIgnore]
		[IgnoreDataMember]
		public bool ShowLanguageWarningAfterStartup { get; set; }

		[JsonIgnore]
		[IgnoreDataMember]
		public ZoomAndRotateMode RotationBehaviour
		{
			get
			{
				return default(ZoomAndRotateMode);
			}
			set
			{
			}
		}

		[JsonIgnore]
		[IgnoreDataMember]
		public bool IsEdgePanningEnabled
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		[JsonIgnore]
		[IgnoreDataMember]
		public string Language
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		[JsonIgnore]
		[IgnoreDataMember]
		public bool LanguageWasSetByPlayer
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		[JsonIgnore]
		[IgnoreDataMember]
		public string AudioLanguage
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		[JsonIgnore]
		[IgnoreDataMember]
		public string InputActionOverrides
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		[JsonIgnore]
		[IgnoreDataMember]
		public FocusMode FreeCameraFocusMode
		{
			get
			{
				return default(FocusMode);
			}
			set
			{
			}
		}

		[JsonIgnore]
		[IgnoreDataMember]
		public bool AudioNoPooPooSounds
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		[JsonIgnore]
		[IgnoreDataMember]
		public bool AudioMuteNarratorWhenSkippingText
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		[JsonIgnore]
		[IgnoreDataMember]
		public bool SubtitlesEnabled
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		[JsonIgnore]
		[IgnoreDataMember]
		public int NarrationSpeedPercentage
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		[JsonIgnore]
		[IgnoreDataMember]
		public bool UseAiVoiceFallback
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		[JsonIgnore]
		[IgnoreDataMember]
		public IEnumerable<string> VisitedCodexLinks => null;

		[JsonIgnore]
		[IgnoreDataMember]
		public string LastLevelSavedOn
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		[JsonIgnore]
		[IgnoreDataMember]
		public IEnumerable<AchievementEntry> AchievementsUnlocked => null;

		public GameStats PlayerStats
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public GameStats StatsForReport { get; set; }

		public List<GameStats.StatReport> StatReportsInTransit { get; set; }

		public List<string> StatReportsConfirmedProcessed { get; set; }

		[JsonIgnore]
		[IgnoreDataMember]
		public string ScreenshotFolder
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		[JsonIgnore]
		[IgnoreDataMember]
		public bool ShowUIDisabledWarning
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		[JsonIgnore]
		[IgnoreDataMember]
		public Dictionary<string, StoryManager.StoryTriggeredLog> TriggeredStories => null;

		[JsonIgnore]
		[IgnoreDataMember]
		public IEnumerable<ProfileUnlock> AllProfileUnlocks => null;

		[JsonIgnore]
		[IgnoreDataMember]
		public IEnumerable<string> PropsWaitingToBeUnlocked => null;

		public float GlobalGiftBoxUnlockCooldownTimer { get; set; }

		[JsonIgnore]
		[IgnoreDataMember]
		public bool HasSeenPatronAttractionBoard
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public bool DevCommentaryShowTranscript
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public float DevCommentaryFontSize
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public static int SecondsPlayed => 0;

		[JsonIgnore]
		[IgnoreDataMember]
		public DateTime LastCommentaryCompleted
		{
			get
			{
				return default(DateTime);
			}
			set
			{
			}
		}

		[JsonIgnore]
		[IgnoreDataMember]
		public DevCommentaryNodeVisibilityMode DevCommentaryNodeVisibilityMode
		{
			get
			{
				return default(DevCommentaryNodeVisibilityMode);
			}
			set
			{
			}
		}

		[JsonIgnore]
		[IgnoreDataMember]
		public bool FullInnerWalls
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public static bool IsProfileCacheInitialised { get; private set; }

		public static event EventHandler<EventArgs<PlayerProfile>> CurrentProfileChanged
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

		public static event EventHandler RewardsChanged
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

		public static event EventHandler DisableFreeCameraMovementParticlesChanged
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

		public static event EventHandler EnablePriorityVisualsChanged
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

		public static event EventHandler EnablePrivacyModeChanged
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

		public static event EventHandler NarrationSpeedPercentageChanged
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

		public static event EventHandler<EventArgs<string>> CodexLinkVisitedChanged
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

		public static event EventHandler<EventArgs<AchievementEntry>> AchievementUnlockedChanged
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

		public static event EventHandler<EventArgs<ProfileUnlock>> UnlockAdded
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

		public static event EventHandler SkillPointsChanged
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

		public static void TriggerProfileRefresh()
		{
		}

		public static void SetNextValidPlayerProfile()
		{
		}

		public static void SetCurrentProfile(PlayerProfile profile)
		{
		}

		public static PlayerProfile CreateNewProfile(string profileName = null)
		{
			return null;
		}

		protected PlayerProfile()
		{
		}

		protected PlayerProfile(string name)
		{
		}

		private PlayerProfile CloneFast()
		{
			return null;
		}

		public bool IsUnlockState(string key, UnlockState state)
		{
			return false;
		}

		public void SetUnlockState(string key, UnlockState state)
		{
		}

		public void ResetUnlocks()
		{
		}

		public bool IsNarratorMuted()
		{
			return false;
		}

		public void RaiseRewardsChanged()
		{
		}

		public bool HasSeenReward(string rewardId)
		{
			return false;
		}

		public void MarkRewardsAsUnpacked(List<GreenbackRewardData> rewards)
		{
		}

		public void MarkRewardsAsSeen(List<GreenbackRewardData> rewards)
		{
		}

		public bool IsCollectibleCardUnlocked(int cardId)
		{
			return false;
		}

		public bool IsCollectibleCardUnpacked(int cardId)
		{
			return false;
		}

		public int GetCollectibleCardAmountUnlocked(int cardId)
		{
			return 0;
		}

		public int GetCollectibleCardAmountPendingUnpack(int cardId)
		{
			return 0;
		}

		public int GetCollectibleCardAmountUnseen(int cardId)
		{
			return 0;
		}

		public int GetCollectibleCardAmountUnpacked(int cardId)
		{
			return 0;
		}

		public bool SetSettingValue<T>(string key, T value)
		{
			return false;
		}

		public T GetSettingValue<T>(string key)
		{
			return default(T);
		}

		public T GetSettingValue<T>(string key, T defaultValue)
		{
			return default(T);
		}

		public bool HasSettingValue(string key)
		{
			return false;
		}

		private static void OnNameChanged(string authorId, string newName)
		{
		}

		public string GetTemplateAuthorName()
		{
			return null;
		}

		public static string GetDisplayNameKey(ZoomAndRotateMode mode)
		{
			return null;
		}

		public static string GetDisplayNameKey(FocusMode mode)
		{
			return null;
		}

		public int GetAudioVolume(string id)
		{
			return 0;
		}

		public void SetAudioVolume(string id, int volume)
		{
		}

		public bool GetMutedState(string id)
		{
			return false;
		}

		public void SetMutedState(string id, bool isMuted)
		{
		}

		public void MarkCodexLinkAsVisited(string linkId)
		{
		}

		public void MarkCodexLinkAsNotVisited(string linkId)
		{
		}

		public bool IsAchievementUnlocked(string achievementId)
		{
			return false;
		}

		public void MarkAchievementAsUnlocked(string achievementId)
		{
		}

		public void ResetAchievements()
		{
		}

		private void _playerStats_CounterChanged(object sender, EventArgs<(string key, int value)> e)
		{
		}

		public bool IsRegionUnlocked(string id)
		{
			return false;
		}

		public void AddUnlockedRegion(string id)
		{
		}

		public bool HasRegionUnlockAnimationPlayed(string id)
		{
			return false;
		}

		public void AddRegionUnlockAnimationPlayed(string id)
		{
		}

		public void ResetRegionData()
		{
		}

		public string GetScreenshotFolderOrDefault()
		{
			return null;
		}

		public string GetDefaultScreenshotFolder()
		{
			return null;
		}

		public DataStore GetStoryDataStore()
		{
			return null;
		}

		private void AddUnlock(string key, UnlockType type, bool forceWriteToProfile = false)
		{
		}

		public HashSet<string> GetProfileUnlockCache(UnlockType unlockType)
		{
			return null;
		}

		protected IEnumerable<string> GetCompiledUnlockCache(UnlockType unlockType)
		{
			return null;
		}

		public bool IsUnlocked(UnlockType type, string key)
		{
			return false;
		}

		private void CountdownGiftBoxCooldown()
		{
		}

		public void AddPropToWaitingToBeUnlockedList(string key)
		{
		}

		public void RemovePropWaitingToBeUnlocked(string key)
		{
		}

		public bool IsPropUnlocked(string key)
		{
			return false;
		}

		public void UnlockProp(string key)
		{
		}

		public List<string> GetSeenUnlocksInUnlockScreen()
		{
			return null;
		}

		public bool IsSeenUnlock(string unlockId)
		{
			return false;
		}

		public bool IsSeenInUnlockScreen(string unlockId)
		{
			return false;
		}

		public bool IsSeenInUI(string key)
		{
			return false;
		}

		public void MarkAsSeenUnlock(string unlockId)
		{
		}

		public void MarkAsUnseenImported(string unseenImportedId)
		{
		}

		public void MarkAsSeenImported(string seenImportedId)
		{
		}

		public void MarkAsSeenInUI(string id)
		{
		}

		public List<string> GetUnseenUnlockedProps()
		{
			return null;
		}

		public List<string> GetUnseenImported()
		{
			return null;
		}

		public bool IsZoneUnlocked(string key)
		{
			return false;
		}

		public void UnlockZone(string key)
		{
		}

		public bool IsScheduleItemUnlocked(string key)
		{
			return false;
		}

		public void UnlockScheduleItem(string key)
		{
		}

		public bool IsRatingCategoryUnlocked(string key)
		{
			return false;
		}

		public void UnlockRatingCategory(string key)
		{
		}

		public bool IsWeaponUnlocked(string key)
		{
			return false;
		}

		public void UnlockWeapon(string key)
		{
		}

		public bool IsCraftProcessUnlocked(string key)
		{
			return false;
		}

		public void UnlockCraftProcess(string key)
		{
		}

		public bool IsTraitUnlocked(string key)
		{
			return false;
		}

		public void UnlockTrait(string key)
		{
		}

		public bool IsGameItemUnlocked(string key)
		{
			return false;
		}

		public void UnlockGameItem(string key)
		{
		}

		public bool IsBaseScenarioCompleted(string tavernLevelId)
		{
			return false;
		}

		public bool IsTavernLevelUnlocked(string key)
		{
			return false;
		}

		public void UnlockTavernLevel(string key)
		{
		}

		public GameDifficultySettingsData GetDefaultGameDifficultySettings()
		{
			return null;
		}

		public DirectorsToolbar3DUIView.CameraPresetData GetCameraPresetData(string key)
		{
			return null;
		}

		public void SetCameraPresetData(string key, DirectorsToolbar3DUIView.CameraPresetData data)
		{
		}

		public List<string> GetAvailableHandbookTopics()
		{
			return null;
		}

		public void AddHandbookTopic(string topicCodexId, string scrollTo = null, bool announceTopic = false)
		{
		}

		public void ResetHandbookTopics()
		{
		}

		public void ResetSkills()
		{
		}

		public int GetSkill(string skill)
		{
			return 0;
		}

		public void SetSkill(string skill, int value)
		{
		}

		public int GetRemainingSkillPoints()
		{
			return 0;
		}

		public bool IsSeenStarReveal(string unlockId)
		{
			return false;
		}

		public void MarkAsSeenStarReveal(string unlockId)
		{
		}

		public static string MigrateProfileJson(string profileId, string json)
		{
			return null;
		}

		private static int ExtractVersion(string json)
		{
			return 0;
		}

		protected static void SetFileVersion(JObject obj, int version)
		{
		}

		protected static string MigrateFrom0To1(string json, ref int version)
		{
			return null;
		}

		protected static string MigrationFrom1To2(string json, ref int version)
		{
			return null;
		}

		public static string GetProfileFolderPath(string profileId)
		{
			return null;
		}

		public static string GetProfileFilePath(string profileId)
		{
			return null;
		}

		public string GetProfileFolderPath()
		{
			return null;
		}

		public string GetProfileFilePath()
		{
			return null;
		}

		public static void DeleteProfile(PlayerProfile profile)
		{
		}

		private static string WriteProfileData(PlayerProfile profile, Action<Exception> onException)
		{
			return null;
		}

		public static IEnumerable<PlayerProfile> GetAllPlayerProfiles()
		{
			return null;
		}

		public static void InitPlayerProfilesCache()
		{
		}

		public static PlayerProfile GetPlayerProfileFromProfileId(string profileId)
		{
			return null;
		}

		public static PlayerProfile GetPlayerProfileFromPath(string profilePath)
		{
			return null;
		}

		public static bool DoesProfileExist(string profileId)
		{
			return false;
		}

		public void MarkDirty()
		{
		}

		public void UpdateTick()
		{
		}

		public void SaveAsync()
		{
		}

		public void Save()
		{
		}

		private void SaveInternal(bool isOnBackgroundThread = false)
		{
		}

		public static void LoadPlayerProfile()
		{
		}

		private static bool TryRestoreBackUpProfile(string profileId)
		{
			return false;
		}
	}
}
