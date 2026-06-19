using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TH20.EventAwardRemixBadge;
using TH20.EventAwardSilver;
using TH20.EventAwardStar;
using UnityEngine;

namespace TH20
{
	[DontSave]
	public class OnlineMetadataManager : MustCallDestroy, TH20.EventAwardStar.Interface, IGameEventCallback, TH20.EventAwardSilver.Interface, TH20.EventAwardRemixBadge.Interface
	{
		public System.Action OnLatestData;

		private OnlineMetadata _localPlayerData;

		private BaseOnlineDataFile _uploadFile;

		private readonly App _app;

		private List<BaseOnlineDataFile> _dataFiles = new List<BaseOnlineDataFile>();

		private readonly Dictionary<OnlinePlayerID, OnlineMetadata> _dataCache = new Dictionary<OnlinePlayerID, OnlineMetadata>();

		private readonly FileDownloadHelper _fileDownloadHelper;

		private Coroutine _getLatestCoroutine;

		private bool _hasInitialised;

		private const string FileName = "Metadata";

		public OnlineMetadata LocalPlayerData => _localPlayerData;

		public bool LocalPlayerOnlineVisibility
		{
			get
			{
				if (_app.UserPreferences.Game.OnlineVisibility)
				{
					return _app.GameMode.OnlineFeaturesEnabled();
				}
				return false;
			}
		}

		public int DataCacheEntryCount => _dataCache.Count;

		public OnlineMetadataManager(App app, Metagame metagame)
		{
			_app = app;
			_fileDownloadHelper = new FileDownloadHelper();
			if (!_hasInitialised)
			{
				_hasInitialised = true;
				InitDataFiles();
			}
			Preferences.GamePreferences game = _app.UserPreferences.Game;
			game.OnOnlineVisiblityChanged = (Action<bool>)Delegate.Combine(game.OnOnlineVisiblityChanged, new Action<bool>(OnOnlineVisibilityChanged));
			metagame.OnStarAwarded.Add(this);
			metagame.OnRemixBadgeAwarded.Add(this);
			metagame.OnSilverAwarded.Add(this);
			LevelEventsIntermediary levelEventsIntermediary = metagame.LevelEventsIntermediary;
			levelEventsIntermediary.OnEndOfMonthStatsCompiled = (Action<LevelStatsDatabase.MonthStats>)Delegate.Combine(levelEventsIntermediary.OnEndOfMonthStatsCompiled, new Action<LevelStatsDatabase.MonthStats>(OnReceivedMonthEndStats));
			ObjectiveEvents objectiveEvents = metagame.ObjectiveEvents;
			objectiveEvents.OnObjectiveCompleted = (Action<Objective, Objective.CompletionType>)Delegate.Combine(objectiveEvents.OnObjectiveCompleted, new Action<Objective, Objective.CompletionType>(OnObjectiveCompleted));
			App app2 = _app;
			app2.OnLevelLoaded = (Action<Level, bool>)Delegate.Combine(app2.OnLevelLoaded, new Action<Level, bool>(OnLevelLoaded));
		}

		public void InitDataFiles()
		{
			if (!OnlineManager.IsInitializedAndLoggedOn() || !_app.GameMode.OnlineFeaturesEnabled() || OnlineManager.DataFiles == null)
			{
				return;
			}
			_uploadFile = OnlineManager.DataFiles.GetLocalPlayerDataFile(OnlineFileClass.OnlineMetadata, "Metadata", createIfNone: true);
			_dataFiles = OnlineManager.DataFiles.GatherDataFiles(OnlineFileClass.OnlineMetadata, "Metadata", OnlineManager.GetFriendPlayerIDs(), createIfNone: true).Values.ToList();
			BaseOnlineDataFile baseOnlineDataFile = null;
			foreach (BaseOnlineDataFile dataFile in _dataFiles)
			{
				if (dataFile.GetPlayerID() == OnlineManager.GetLocalPlayerID())
				{
					baseOnlineDataFile = dataFile;
					break;
				}
			}
			if (baseOnlineDataFile != null)
			{
				_dataFiles.Remove(baseOnlineDataFile);
			}
			if (_getLatestCoroutine != null)
			{
				OnlineManager.BehaviourToRunCoroutinesOn.StopCoroutine(_getLatestCoroutine);
				_fileDownloadHelper.Reset();
			}
			_getLatestCoroutine = OnlineManager.BehaviourToRunCoroutinesOn.StartCoroutine(GetInitialisationDataCoroutine());
		}

		public void StopGettingLatest()
		{
			if (_getLatestCoroutine != null)
			{
				OnlineManager.BehaviourToRunCoroutinesOn.StopCoroutine(_getLatestCoroutine);
				_fileDownloadHelper.Reset();
				_getLatestCoroutine = null;
			}
		}

		public override void Destroy()
		{
			if (_getLatestCoroutine != null)
			{
				OnlineManager.BehaviourToRunCoroutinesOn.StopCoroutine(_getLatestCoroutine);
			}
			Preferences.GamePreferences game = _app.UserPreferences.Game;
			game.OnOnlineVisiblityChanged = (Action<bool>)Delegate.Remove(game.OnOnlineVisiblityChanged, new Action<bool>(OnOnlineVisibilityChanged));
			_app.Metagame.OnStarAwarded.Remove(this);
			_app.Metagame.OnRemixBadgeAwarded.Remove(this);
			_app.Metagame.OnSilverAwarded.Remove(this);
			LevelEventsIntermediary levelEventsIntermediary = _app.Metagame.LevelEventsIntermediary;
			levelEventsIntermediary.OnEndOfMonthStatsCompiled = (Action<LevelStatsDatabase.MonthStats>)Delegate.Remove(levelEventsIntermediary.OnEndOfMonthStatsCompiled, new Action<LevelStatsDatabase.MonthStats>(OnReceivedMonthEndStats));
			ObjectiveEvents objectiveEvents = _app.Metagame.ObjectiveEvents;
			objectiveEvents.OnObjectiveCompleted = (Action<Objective, Objective.CompletionType>)Delegate.Remove(objectiveEvents.OnObjectiveCompleted, new Action<Objective, Objective.CompletionType>(OnObjectiveCompleted));
			App app = _app;
			app.OnLevelLoaded = (Action<Level, bool>)Delegate.Remove(app.OnLevelLoaded, new Action<Level, bool>(OnLevelLoaded));
			_fileDownloadHelper.Destroy();
			base.Destroy();
		}

		public void OnStarAwardedEvent(MetagameHospitalRecord.StarIndex starIndex, LevelConfig levelConfig, bool debug)
		{
			if (_localPlayerData != null)
			{
				_localPlayerData.LogStarProgress(levelConfig, starIndex);
				_localPlayerData.SetStat(Enum.GetName(typeof(CareerStatsManager.Type), CareerStatsManager.Type.TotalStars), _app.Metagame.TotalStars());
			}
		}

		public void OnRemixBadgeAwardedEvent(LevelConfig levelConfig, bool debug)
		{
			if (_localPlayerData != null)
			{
				_localPlayerData.LogRemixBadgeAwarded(levelConfig);
				_localPlayerData.SetStat(Enum.GetName(typeof(CareerStatsManager.Type), CareerStatsManager.Type.TotalRemixBadges), _app.Metagame.TotalRemixBadges());
			}
		}

		public void OnSilverAwardedEvent(int amount)
		{
			if (_localPlayerData != null && _app?.Metagame != null)
			{
				_localPlayerData.SetStat(Enum.GetName(typeof(CareerStatsManager.Type), CareerStatsManager.Type.TotalSilverEarned), _app.Metagame.TotalSilverCumulative());
			}
		}

		private void OnObjectiveCompleted(Objective objective, Objective.CompletionType completionType)
		{
			if (_localPlayerData != null && objective is OnlineChallengeObjective onlineChallengeObjective && completionType == Objective.CompletionType.Successful && onlineChallengeObjective.Definition.IsHiScore)
			{
				_localPlayerData.LogOnlineChallengeScore(onlineChallengeObjective.ObjectiveUniqueID, onlineChallengeObjective.CurrentHiScore, onlineChallengeObjective.PlayerList);
			}
		}

		private void OnReceivedMonthEndStats(LevelStatsDatabase.MonthStats stats)
		{
			if (_localPlayerData != null)
			{
				_localPlayerData.SetStat(Enum.GetName(typeof(CareerStatsManager.Type), CareerStatsManager.Type.TotalFoundationValue), _app.Metagame.TotalFoundationValue());
				if (_app.Level != null)
				{
					_localPlayerData.SetStat($"{_app.Level.Config.UniqueId}_HospitalValue", stats.HospitalValue);
					_localPlayerData.SetStat($"{_app.Level.Config.UniqueId}_PrestigeLevel", stats.HospitalLevel);
					_localPlayerData.SetStat($"{_app.Level.Config.UniqueId}_StaffMorale", (int)stats.StaffMorale);
					_localPlayerData.SetStat($"{_app.Level.Config.UniqueId}_Balance", stats.Balance);
				}
			}
		}

		private void OnLevelLoaded(Level level, bool loadedFromSave)
		{
			if (_localPlayerData != null)
			{
				_localPlayerData.LogLastPlayedLevel(level.Config);
			}
		}

		public void SetLocalPlayerStat(string statName, int value)
		{
			if (_localPlayerData != null)
			{
				_localPlayerData.SetStat(statName, value);
			}
		}

		public void Update()
		{
			if (_localPlayerData != null)
			{
				_localPlayerData.Update();
			}
		}

		public void Upload(bool immediately = false)
		{
			if (_localPlayerData != null)
			{
				_localPlayerData.Upload(immediately);
			}
		}

		public OnlineMetadata GetOnlineMetadata(OnlinePlayerID onlinePlayerID)
		{
			if (_dataCache.TryGetValue(onlinePlayerID, out var value))
			{
				return value;
			}
			return null;
		}

		public Dictionary<OnlinePlayerID, OnlineMetadata> GetMetadataCache()
		{
			return _dataCache;
		}

		private void OnOnlineVisibilityChanged(bool visibility)
		{
			if (OnlineManager.IsInitializedAndLoggedOn() && _app.GameMode.OnlineFeaturesEnabled() && _localPlayerData != null)
			{
				_localPlayerData.SetIsVisible(visibility);
			}
		}

		public void GetLatestData()
		{
			if (OnlineManager.IsInitializedAndLoggedOn() && _app.GameMode.OnlineFeaturesEnabled() && _getLatestCoroutine == null)
			{
				_getLatestCoroutine = OnlineManager.BehaviourToRunCoroutinesOn.StartCoroutine(GetFriendsLatestDataCoroutine());
			}
		}

		private IEnumerator GetInitialisationDataCoroutine()
		{
			OnlinePlayerID localPlayerID = OnlineManager.GetLocalPlayerID();
			if (_localPlayerData == null)
			{
				_localPlayerData = new OnlineMetadata();
			}
			if (localPlayerID != OnlinePlayerID.Nil)
			{
				_fileDownloadHelper.Download(OnlineManager.DataFiles.GetFriendDataFile(OnlineFileClass.CollaborativePortfolio, "Metadata", OnlineManager.GetLocalPlayerID(), createIfNone: true));
				while (_fileDownloadHelper.IsDownloading)
				{
					yield return null;
				}
				foreach (BaseOnlineDataFile successfulDownloadResult in _fileDownloadHelper.SuccessfulDownloadResults)
				{
					if (successfulDownloadResult.GetLastDownloadResult() != DownloadResult.FileNotFound && successfulDownloadResult.Deserialize<OnlineMetadata>(out var obj) == EOnlineResult.EOnlineResultOk && obj != null)
					{
						_localPlayerData = obj;
						break;
					}
				}
			}
			_localPlayerData.LinkUploadFile(_uploadFile);
			_localPlayerData.SetIsVisible(LocalPlayerOnlineVisibility);
			if (_app != null && _app.Metagame != null)
			{
				string name = Enum.GetName(typeof(CareerStatsManager.Type), CareerStatsManager.Type.TotalStars);
				_localPlayerData.SetStat(name, _app.Metagame.TotalStars());
				name = Enum.GetName(typeof(CareerStatsManager.Type), CareerStatsManager.Type.TotalFoundationValue);
				_localPlayerData.SetStat(name, _app.Metagame.TotalFoundationValue());
				name = Enum.GetName(typeof(CareerStatsManager.Type), CareerStatsManager.Type.TotalSilverEarned);
				_localPlayerData.SetStat(name, _app.Metagame.TotalSilverCumulative());
				name = Enum.GetName(typeof(CareerStatsManager.Type), CareerStatsManager.Type.TotalRemixBadges);
				_localPlayerData.SetStat(name, _app.Metagame.TotalRemixBadges());
			}
			_localPlayerData.Upload();
			yield return GetFriendsLatestDataCoroutine();
		}

		private IEnumerator GetFriendsLatestDataCoroutine()
		{
			List<OnlinePlayerID> friendPlayerIDs = OnlineManager.GetFriendPlayerIDs();
			if (friendPlayerIDs != null && friendPlayerIDs.Count > 0)
			{
				_dataFiles = OnlineManager.DataFiles.GatherDataFiles(OnlineFileClass.OnlineMetadata, "Metadata", friendPlayerIDs, createIfNone: true).Values.ToList();
				_fileDownloadHelper.Download(_dataFiles);
				while (_fileDownloadHelper.IsDownloading)
				{
					yield return null;
				}
				foreach (BaseOnlineDataFile successfulDownloadResult in _fileDownloadHelper.SuccessfulDownloadResults)
				{
					if (successfulDownloadResult.GetLastDownloadResult() != DownloadResult.FileNotFound && successfulDownloadResult.Deserialize<OnlineMetadata>(out var obj) == EOnlineResult.EOnlineResultOk && obj != null)
					{
						_dataCache[successfulDownloadResult.GetPlayerID()] = obj;
					}
				}
			}
			OnLatestData.InvokeSafe();
			_getLatestCoroutine = null;
		}
	}
}
