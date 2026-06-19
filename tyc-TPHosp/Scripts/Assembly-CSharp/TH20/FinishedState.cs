#define LOG_LEVEL_VERBOSE
using System;
using System.Collections.Generic;
using System.Linq;

namespace TH20
{
	public class FinishedState : OnlineChallengeState
	{
		private Dictionary<OnlinePlayerID, BaseOnlineDataFile> _cachedDataFiles;

		private Dictionary<OnlinePlayerID, BaseOnlineDataFile> _cachedScreenshotDataFiles;

		private const float TimeBetweenDataCheck = 10f;

		private const float TimeBetweenScreenshotCheck = 10f;

		private float _elapsedTime;

		private float _elapsedTimeScreenshot;

		private bool _screenshotsEnabled;

		public override void ConnectionEstablished()
		{
			if (!_connectionEstablished)
			{
				Enter();
			}
		}

		public override void Enter()
		{
			LogPlayerHospitalStatusData();
			if (!OnlineManager.IsInitializedAndLoggedOn())
			{
				return;
			}
			_connectionEstablished = true;
			Owner.LocalPlayerObjectiveData.PlayerID = OnlineManager.GetLocalPlayerID();
			_cachedDataFiles = OnlineManager.DataFiles.GatherDataFiles(OnlineFileClass.OnlineChallenge, Owner.ObjectiveUniqueID, Owner.PlayerList, createIfNone: true);
			foreach (KeyValuePair<OnlinePlayerID, BaseOnlineDataFile> cachedDataFile in _cachedDataFiles)
			{
				BaseOnlineDataFile value = cachedDataFile.Value;
				value.OnFileDownloadFinished = (Action<BaseOnlineDataFile, DownloadResult, EOnlineResult>)Delegate.Combine(value.OnFileDownloadFinished, new Action<BaseOnlineDataFile, DownloadResult, EOnlineResult>(OnFileDownloadFinished));
				value.Download(forceTry: true);
			}
			OnlineManager.DataFiles.WriteFile(OnlineFileClass.OnlineChallenge, Owner.ObjectiveUniqueID, Owner.LocalPlayerObjectiveData);
			_screenshotsEnabled = PlatformFeatureSupport.IsFeatureSupported(PlatformFeatureSupport.FeatureType.OnlineChallengeScreenshots);
			if (!_screenshotsEnabled)
			{
				return;
			}
			_cachedScreenshotDataFiles = OnlineManager.DataFiles.GatherDataFiles(OnlineFileClass.OnlineChallengeScreenshot, Owner.ObjectiveScreenshotUniqueID, Owner.PlayerList, createIfNone: true);
			foreach (KeyValuePair<OnlinePlayerID, BaseOnlineDataFile> cachedScreenshotDataFile in _cachedScreenshotDataFiles)
			{
				BaseOnlineDataFile value2 = cachedScreenshotDataFile.Value;
				value2.OnFileDownloadFinished = (Action<BaseOnlineDataFile, DownloadResult, EOnlineResult>)Delegate.Combine(value2.OnFileDownloadFinished, new Action<BaseOnlineDataFile, DownloadResult, EOnlineResult>(OnFileScreenshotDownloadFinished));
			}
		}

		public override void Exit()
		{
			if (!_connectionEstablished || !OnlineManager.IsInitializedAndLoggedOn())
			{
				return;
			}
			foreach (KeyValuePair<OnlinePlayerID, BaseOnlineDataFile> cachedDataFile in _cachedDataFiles)
			{
				BaseOnlineDataFile value = cachedDataFile.Value;
				value.OnFileDownloadFinished = (Action<BaseOnlineDataFile, DownloadResult, EOnlineResult>)Delegate.Remove(value.OnFileDownloadFinished, new Action<BaseOnlineDataFile, DownloadResult, EOnlineResult>(OnFileDownloadFinished));
			}
			if (!_screenshotsEnabled)
			{
				return;
			}
			foreach (KeyValuePair<OnlinePlayerID, BaseOnlineDataFile> cachedScreenshotDataFile in _cachedScreenshotDataFiles)
			{
				BaseOnlineDataFile value2 = cachedScreenshotDataFile.Value;
				value2.OnFileDownloadFinished = (Action<BaseOnlineDataFile, DownloadResult, EOnlineResult>)Delegate.Remove(value2.OnFileDownloadFinished, new Action<BaseOnlineDataFile, DownloadResult, EOnlineResult>(OnFileScreenshotDownloadFinished));
			}
		}

		private void OnFileDownloadFinished(BaseOnlineDataFile file, DownloadResult result, EOnlineResult onlineResult)
		{
			switch (result)
			{
			case DownloadResult.FileNotUpdated:
				if (Owner.FriendDataCache.ContainsKey(file.GetPlayerID()))
				{
					return;
				}
				break;
			default:
				return;
			case DownloadResult.FileUpdated:
				break;
			}
			if (file.Deserialize<OnlineChallengeData>(out var obj) == EOnlineResult.EOnlineResultOk)
			{
				OnlinePlayerInfo playerInfo = OnlineManager.GetPlayerInfo(file.GetPlayerID());
				if (file.GetPlayerID() != obj.PlayerID)
				{
					Logging.Warning(LogChannels.Online, "Received Online Challenge data for {0} (Finished) for {1} - but the SteamID embedded in the data does not match ({2})", Owner.Definition.NameLocalised, playerInfo.DisplayName, obj.PlayerID);
				}
				else
				{
					Owner.SetData(file.GetPlayerID(), obj);
				}
			}
		}

		private void OnFileScreenshotDownloadFinished(BaseOnlineDataFile file, DownloadResult result, EOnlineResult onlineResult)
		{
			switch (result)
			{
			case DownloadResult.FileNotUpdated:
				if (Owner.FriendDataCache.ContainsKey(file.GetPlayerID()))
				{
					return;
				}
				break;
			default:
				return;
			case DownloadResult.FileUpdated:
				break;
			}
			if (file.Deserialize<OnlineScreenshotData>(out var obj) == EOnlineResult.EOnlineResultOk)
			{
				OnlineManager.GetPlayerInfo(file.GetPlayerID());
				Owner.SetScreenshotData(file.GetPlayerID(), obj);
			}
		}

		public override void Update(float timeDelta)
		{
			if (!OnlineManager.IsInitializedAndLoggedOn())
			{
				return;
			}
			_elapsedTime += timeDelta;
			if (_elapsedTime >= 10f)
			{
				RequestFriendData();
				_elapsedTime = 0f;
			}
			if (_screenshotsEnabled)
			{
				_elapsedTimeScreenshot += timeDelta;
				if (_elapsedTimeScreenshot >= 10f)
				{
					RequestFriendScreenshotData();
					_elapsedTimeScreenshot = 0f;
				}
			}
		}

		private void RequestFriendData()
		{
			if (_cachedDataFiles == null || _cachedDataFiles.Count == 0 || !OnlineManager.IsInitializedAndLoggedOn())
			{
				return;
			}
			foreach (KeyValuePair<OnlinePlayerID, BaseOnlineDataFile> cachedDataFile in _cachedDataFiles)
			{
				cachedDataFile.Value?.Download();
			}
		}

		private void RequestFriendScreenshotData()
		{
			if (!_screenshotsEnabled)
			{
				return;
			}
			foreach (KeyValuePair<OnlinePlayerID, BaseOnlineDataFile> cachedScreenshotDataFile in _cachedScreenshotDataFiles)
			{
				cachedScreenshotDataFile.Value?.Download();
			}
		}

		public override void OnTimelineUpdated(int day)
		{
			foreach (KeyValuePair<OnlinePlayerID, OnlineChallengeObjective.PlayerInfo> item in Owner.PlayerInfoDictionary)
			{
				if (!(item.Value.ChallengeData is OnlineChallengeData onlineChallengeData))
				{
					continue;
				}
				foreach (OnlineChallengeEvent item2 in onlineChallengeData.GetEventsForDay(day, excludeScores: true))
				{
					Level.ObjectiveEvents.OnEventReceived.InvokeSafe(Owner, item.Key, item2);
				}
			}
		}

		private void LogPlayerHospitalStatusData()
		{
			OnlineChallengeEventHospitalStatus onlineChallengeEventHospitalStatus = new OnlineChallengeEventHospitalStatus();
			onlineChallengeEventHospitalStatus.Day = Owner.DaysElapsed;
			onlineChallengeEventHospitalStatus.Type = OnlineChallengeEvent.Event.ObjectiveStatus;
			onlineChallengeEventHospitalStatus.DoctorCount = Level.CharacterManager.StaffMembers.Count((Staff staff) => staff.Definition._type == StaffDefinition.Type.Doctor);
			onlineChallengeEventHospitalStatus.NurseCount = Level.CharacterManager.StaffMembers.Count((Staff staff) => staff.Definition._type == StaffDefinition.Type.Nurse);
			onlineChallengeEventHospitalStatus.JanitorCount = Level.CharacterManager.StaffMembers.Count((Staff staff) => staff.Definition._type == StaffDefinition.Type.Janitor);
			onlineChallengeEventHospitalStatus.AssistantCount = Level.CharacterManager.StaffMembers.Count((Staff staff) => staff.Definition._type == StaffDefinition.Type.Assistant);
			onlineChallengeEventHospitalStatus.PatientCount = Level.CharacterManager.Patients.Count;
			onlineChallengeEventHospitalStatus.Reputation = Level.ReputationTracker.OverallReputation;
			onlineChallengeEventHospitalStatus.PrestigeLevel = Level.PrestigeTracker.Level;
			onlineChallengeEventHospitalStatus.PrestigeProgress = Level.PrestigeTracker.Progress;
			onlineChallengeEventHospitalStatus.Balance = Level.FinanceManager.Balance;
			onlineChallengeEventHospitalStatus.FoundationValue = Level.Metagame.TotalFoundationValue();
			onlineChallengeEventHospitalStatus.FoundationShareValue = (int)Level.Metagame.GetShareValue();
			onlineChallengeEventHospitalStatus.FoundationStars = Level.Metagame.TotalStars();
			onlineChallengeEventHospitalStatus.FoundationSilver = Level.Metagame.TotalSilverCumulative();
			Owner.LocalPlayerObjectiveData.LogEvent(onlineChallengeEventHospitalStatus);
			Level.ObjectiveEvents.OnLocalPlayerDataUpdated.InvokeSafe(Owner, Owner.LocalPlayerObjectiveData);
		}
	}
}
