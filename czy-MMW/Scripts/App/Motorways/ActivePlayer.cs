using System;
using System.Collections.Generic;
using Factory;
using JetBrains.Annotations;
using Motorways.Processes;
using NotificationService.Events;
using com.dinopoloclub.analytics;

namespace Motorways
{
	public class ActivePlayer : IActivePlayer
	{
		[Dependency]
		private AchievementDatabase _achievements;

		private static Diagnostics.Log.Channel Log = Diagnostics.Log.OpenChannel("ActivePlayer");

		private bool _didFailLastSave;

		private bool _hasNotifiedPlayerOfSaveFailure;

		private int _previousVolume;

		private const int DefaultVolumeSetting = 3;

		[Dependency]
		private IPersistentStorageService _storage;

		private Player _player;

		public string Id => Player.Id;

		public bool IsVibrationEnabled
		{
			get
			{
				return UserProfile.IsVibrationEnabled;
			}
			set
			{
				UserProfile.IsVibrationEnabled = value;
			}
		}

		public bool IsColorblindModeEnabled
		{
			get
			{
				return MotorwaysUserProfile.IsColorblindModeEnabled;
			}
			set
			{
				MotorwaysUserProfile.IsColorblindModeEnabled = value;
			}
		}

		public bool IsSkipTransitionsEnabled
		{
			get
			{
				return MotorwaysUserProfile.IsSkipTransitionsEnabled;
			}
			set
			{
				MotorwaysUserProfile.IsSkipTransitionsEnabled = value;
			}
		}

		public AnalyticsService.ConsentState AnalyticsConsentState
		{
			get
			{
				return MotorwaysExtendedUserProfile.AnalyticsConsentState;
			}
			set
			{
				MotorwaysExtendedUserProfile.AnalyticsConsentState = value;
			}
		}

		public bool? FirstSession
		{
			get
			{
				return MotorwaysExtendedUserProfile.IsFirstSession;
			}
			set
			{
				MotorwaysExtendedUserProfile.IsFirstSession = value;
			}
		}

		public bool HasAvatar => _player.HasAvatar;

		public int AvatarColorIndex
		{
			get
			{
				return _player.AvatarColorIndex;
			}
			set
			{
				_player.AvatarColorIndex = value;
			}
		}

		public int AvatarIconIndex
		{
			get
			{
				return _player.AvatarIconIndex;
			}
			set
			{
				_player.AvatarIconIndex = value;
			}
		}

		public bool IsAnyTutorialCompleted => MotorwaysUserProfile.IsAnyTutorialCompleted();

		public LocaleDatabase.LocaleId LocaleId
		{
			get
			{
				return _player.LocaleId;
			}
			set
			{
				_player.LocaleId = value;
			}
		}

		public bool SyncToCloud
		{
			get
			{
				return DeviceSettings.SyncToCloud;
			}
			set
			{
				DeviceSettings.SyncToCloud = value;
			}
		}

		public string ColorfulOption
		{
			get
			{
				return MotorwaysDeviceSettings.ColorfulOption;
			}
			set
			{
				MotorwaysDeviceSettings.ColorfulOption = value;
			}
		}

		public bool IsNightModeEnabled
		{
			get
			{
				return MotorwaysDeviceSettings.IsNightModeEnabled;
			}
			set
			{
				MotorwaysDeviceSettings.IsNightModeEnabled = value;
			}
		}

		public int AntiAliasingLevel
		{
			get
			{
				return MotorwaysDeviceSettings.AntiAliasingLevel;
			}
			set
			{
				MotorwaysDeviceSettings.AntiAliasingLevel = value;
			}
		}

		public int AntiAliasingMSAALevelForUniversalRenderPipeline
		{
			get
			{
				if (MotorwaysDeviceSettings.AntiAliasingLevel >= 0)
				{
					return 1 << MotorwaysDeviceSettings.AntiAliasingLevel;
				}
				return 1;
			}
		}

		public int SelectedDisplay
		{
			get
			{
				return MotorwaysDeviceSettings.SelectedDisplay;
			}
			set
			{
				MotorwaysDeviceSettings.SelectedDisplay = value;
			}
		}

		public bool IsZoomEnabled
		{
			get
			{
				return MotorwaysDeviceSettings.IsZoomEnabled;
			}
			set
			{
				MotorwaysDeviceSettings.IsZoomEnabled = value;
			}
		}

		public int ZoomLevel
		{
			get
			{
				return MotorwaysDeviceSettings.ZoomLevel;
			}
			set
			{
				MotorwaysDeviceSettings.ZoomLevel = value;
			}
		}

		public int PreviousVolumeSetting => _previousVolume;

		public int VolumeSetting
		{
			get
			{
				return MotorwaysDeviceSettings.VolumeSetting;
			}
			set
			{
				_previousVolume = MotorwaysDeviceSettings.VolumeSetting;
				MotorwaysDeviceSettings.VolumeSetting = value;
				if (_previousVolume == 0 && MotorwaysDeviceSettings.VolumeSetting == 0)
				{
					_previousVolume = 3;
				}
			}
		}

		public int Soundscape
		{
			get
			{
				return MotorwaysDeviceSettings.Soundscape;
			}
			set
			{
				MotorwaysDeviceSettings.Soundscape = value;
			}
		}

		public NotificationEvent? LatestNotificationEvent => MotorwaysExtendedUserProfile.LatestNotificationEvent;

		public List<NotificationEvent> NotificationEvents => MotorwaysExtendedUserProfile.NotificationEvents;

		public AchievementStatistics AchievementStatistics => MotorwaysExtendedUserProfile.AchievementStatistics;

		public bool AreMenuMessagesEnabled
		{
			get
			{
				return MotorwaysExtendedUserProfile.AreMenuMessagesEnabled;
			}
			set
			{
				MotorwaysExtendedUserProfile.AreMenuMessagesEnabled = value;
			}
		}

		public bool HasSeenCreativeInGameMessage
		{
			get
			{
				return MotorwaysExtendedUserProfile.CreativeInGameMessageSeen;
			}
			set
			{
				MotorwaysExtendedUserProfile.CreativeInGameMessageSeen = value;
			}
		}

		public bool IsChallengeRemindersEnabledSetting
		{
			get
			{
				return MotorwaysDeviceSettings.IsChallengeRemindersEnabledSetting;
			}
			set
			{
				MotorwaysDeviceSettings.IsChallengeRemindersEnabledSetting = value;
			}
		}

		public bool IsContentRemindersEnabledSetting
		{
			get
			{
				return MotorwaysDeviceSettings.IsContentRemindersEnabledSetting;
			}
			set
			{
				MotorwaysDeviceSettings.IsContentRemindersEnabledSetting = value;
			}
		}

		public bool IsTapDrawEnabled
		{
			get
			{
				return MotorwaysExtendedUserProfile.IsTapDrawEnabled;
			}
			set
			{
				MotorwaysExtendedUserProfile.IsTapDrawEnabled = value;
			}
		}

		public int ControllerSensitivity
		{
			get
			{
				return MotorwaysExtendedUserProfile.ControllerSensitivity;
			}
			set
			{
				MotorwaysExtendedUserProfile.ControllerSensitivity = value;
			}
		}

		public bool IsDrawModeToggleEnabled
		{
			get
			{
				return MotorwaysExtendedUserProfile.IsDrawModeToggleEnabled;
			}
			set
			{
				MotorwaysExtendedUserProfile.IsDrawModeToggleEnabled = value;
			}
		}

		public bool DoesHudStartLocked
		{
			get
			{
				return MotorwaysExtendedUserProfile.DoesHudStartLocked;
			}
			set
			{
				MotorwaysExtendedUserProfile.DoesHudStartLocked = value;
			}
		}

		public bool IsTelemetryEnabled
		{
			get
			{
				return MotorwaysExtendedUserProfile.IsTelemetryEnabled;
			}
			set
			{
				MotorwaysExtendedUserProfile.IsTelemetryEnabled = value;
			}
		}

		public bool HasLocalSavedGame => _player.HasLocalSavedGame;

		public IGameJournalSave LocalSavedGame
		{
			get
			{
				return _player.LocalSavedGame;
			}
			set
			{
				IGameJournalSave localSavedGame = _player.LocalSavedGame;
				if (localSavedGame != null && value == null)
				{
					_storage.Delete(localSavedGame);
				}
				_player.LocalSavedGame = value;
				if (value != null)
				{
					_storage.Store(value, OnSaveCompleted);
				}
			}
		}

		public bool DidFailLastSave => _didFailLastSave;

		public bool HasNotifiedPlayerOfSaveFailure => _hasNotifiedPlayerOfSaveFailure;

		public bool HasForeignSavedGames => _player.HasForeignSavedGames;

		public IEnumerable<IGameJournalSave> ForeignSavedGames => _player.ForeignSavedGames;

		public ILegacyUserProfile UserProfile => _player.UserProfile;

		public IExtendedUserProfile ExtendedUserProfile => _player.ExtendedUserProfile;

		public LegacyMotorwaysUserProfile MotorwaysUserProfile => (LegacyMotorwaysUserProfile)_player.UserProfile;

		public MotorwaysExtendedUserProfile MotorwaysExtendedUserProfile => (MotorwaysExtendedUserProfile)_player.ExtendedUserProfile;

		public IDeviceSettings DeviceSettings => _player.DeviceSettings;

		public MotorwaysDeviceSettings MotorwaysDeviceSettings => (MotorwaysDeviceSettings)_player.DeviceSettings;

		public Player Player => _player;

		public bool HasActivePlayer => _player != null;

		[Dependency]
		public IScope Scope { get; private set; }

		public event Action DataChanged;

		public event Action SavedGamesChanged;

		public event PlayedChangedEventHandler PlayerChanged;

		public bool IsAchievementCompleted(AchievementDefinition achievementDefinition)
		{
			return UserProfile.IsAchievementCompleted(achievementDefinition);
		}

		public void CompleteAchievement(AchievementDefinition achievementDefinition, bool showNotification)
		{
			UserProfile.CompleteAchievement(achievementDefinition, showNotification);
		}

		private void CheckAchievementsRetroactively()
		{
			for (int i = 0; i < _achievements.Count; i++)
			{
				if (_achievements[i] is MotorwaysAchievementDefinition motorwaysAchievementDefinition && motorwaysAchievementDefinition.IsRetroactivelySatisfied(this) && !IsAchievementCompleted(motorwaysAchievementDefinition))
				{
					CompleteAchievement(motorwaysAchievementDefinition, showNotification: false);
				}
			}
		}

		public void CheckLifetimeAchievements()
		{
			for (int i = 0; i < _achievements.Count; i++)
			{
				if (_achievements[i] is MotorwaysAchievementDefinition { Scale: AchievementScale.Lifetime } motorwaysAchievementDefinition && motorwaysAchievementDefinition.IsLifetimeAchievementSatisfied(this) && !IsAchievementCompleted(motorwaysAchievementDefinition))
				{
					CompleteAchievement(motorwaysAchievementDefinition, showNotification: true);
				}
			}
		}

		public bool HasSeenNewContent(string newContentId)
		{
			return ExtendedUserProfile.HasSeenNewContent(newContentId);
		}

		public void SetNewContentSeen(string newContentId)
		{
			ExtendedUserProfile.SetNewContentSeen(newContentId);
		}

		public void ClearNewContentSeen(string specificContent = null)
		{
			ExtendedUserProfile.ClearNewContentSeen(specificContent);
		}

		public GameMode GetSelectedModeForMap(string mapId)
		{
			return ExtendedUserProfile.GetSelectedModeForMap(mapId);
		}

		public void SetSelectedGameMode(string mapName, GameMode gameMode)
		{
			ExtendedUserProfile.SetSelectedGameModeForMap(mapName, gameMode);
		}

		public void SetTutorialTypeComplete(TutorialProgressionProcess.TutorialType completedType)
		{
			MotorwaysUserProfile.SetTutorialTypeComplete(completedType);
			CheckLifetimeAchievements();
		}

		public bool IsTutorialTypeCompleted(TutorialProgressionProcess.TutorialType completedType)
		{
			return MotorwaysUserProfile.IsTutorialTypeCompleted(completedType);
		}

		public MotorwaysCityStatistics GetCityStatisticsForCity(string cityId, GameMode mode, bool createIfNecessary = false)
		{
			return MotorwaysUserProfile.GetCityStatisticsForCity(cityId, mode, createIfNecessary);
		}

		[NotNull]
		public MotorwaysTimedChallengeScore GetChallengeScore(MapChallenge.ChallengeType challengeType, int expiry)
		{
			return MotorwaysExtendedUserProfile.GetChallengeScore(challengeType, expiry);
		}

		public CityChallengeStatistics GetCityChallengeScore(string cityId, GameMode mode, int challengeIndex, bool createIfEmpty = true)
		{
			return MotorwaysExtendedUserProfile.GetCityChallengeScore(cityId, mode, challengeIndex, createIfEmpty);
		}

		public IEnumerable<CityChallengeStatistics> GetCityChallengeScores(string cityId, GameMode mode)
		{
			return MotorwaysExtendedUserProfile.GetCityChallengeScores(cityId, mode);
		}

		public void RecordGameStatistics(IGameStatistics gameStatistics)
		{
			MotorwaysUserProfile.RecordGameStatistics(gameStatistics);
			MotorwaysExtendedUserProfile.RecordGameStatistics(gameStatistics);
		}

		public Dictionary<string, string> GetDeviceControlMapping(string deviceName)
		{
			return DeviceSettings.GetDeviceControlMapping(deviceName);
		}

		public void SetDeviceControlMappings(string deviceName, Dictionary<string, string> deviceControlMappings)
		{
			DeviceSettings.SetDeviceControlMappings(deviceName, deviceControlMappings);
		}

		public void AddGameNotificationEvent(NotificationEvent notificationEvent)
		{
			MotorwaysExtendedUserProfile.AddGameNotificationEvent(notificationEvent);
		}

		public void UpdateGameNotificationEventWithId(int id, NotificationEvent updatedNotificationEvent)
		{
			MotorwaysExtendedUserProfile.UpdateGameNotificationEventWithId(id, updatedNotificationEvent);
		}

		public void RemoveAllNotificationEvents()
		{
			MotorwaysExtendedUserProfile.RemoveAllGameNotificationsEvents();
		}

		public void NotifyPlayerOfSaveFailure()
		{
			_hasNotifiedPlayerOfSaveFailure = true;
		}

		public void AddForeignSavedGame(IGameJournalSave newForeignSavedGame)
		{
			_player.AddForeignSavedGame(newForeignSavedGame);
			this.SavedGamesChanged?.Invoke();
		}

		public IGameJournalSave GetForeignSavedGame(string gameId)
		{
			return _player.GetForeignSavedGame(gameId);
		}

		public void RemoveSavedGame(IGameJournalSave savedGame)
		{
			_player.RemoveSavedGame(savedGame);
			this.SavedGamesChanged?.Invoke();
		}

		public void Touch()
		{
			Log.Info("Touching player {0}.", _player.Id);
			_player.DeviceSettings.LastPlayedUtcTime = DateTime.UtcNow;
		}

		public void ActivatePlayer(Player newActivePlayer)
		{
			Log.Info("Activating player {0}.", newActivePlayer.Id);
			Player player = _player;
			if (player != null)
			{
				player.DataChanged -= OnDataChanged;
				player.SavedGamesChanged -= OnSavedGamesChanged;
			}
			_player = newActivePlayer;
			_player.DataChanged += OnDataChanged;
			_player.SavedGamesChanged += OnSavedGamesChanged;
			this.PlayerChanged?.Invoke(player, newActivePlayer);
			this.DataChanged?.Invoke();
			this.SavedGamesChanged?.Invoke();
			CheckAchievementsRetroactively();
			Touch();
		}

		private void OnSaveCompleted(StoreOperationResult result)
		{
			if (result == StoreOperationResult.Failed)
			{
				_didFailLastSave = true;
				_hasNotifiedPlayerOfSaveFailure = false;
			}
		}

		private void OnDataChanged()
		{
			this.DataChanged?.Invoke();
		}

		private void OnSavedGamesChanged()
		{
			this.SavedGamesChanged?.Invoke();
		}
	}
}
