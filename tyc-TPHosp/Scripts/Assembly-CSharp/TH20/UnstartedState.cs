#define LOG_LEVEL_VERBOSE
using System;
using System.Collections.Generic;

namespace TH20
{
	public class UnstartedState : OnlineChallengeState
	{
		private Dictionary<OnlinePlayerID, BaseOnlineDataFile> _cachedDataFiles;

		private const float TimeBetweenCheck = 30f;

		private float _elapsedTime;

		public override void ConnectionEstablished()
		{
			if (!_connectionEstablished)
			{
				Enter();
			}
		}

		public override void Enter()
		{
			if (!OnlineManager.IsInitializedAndLoggedOn())
			{
				return;
			}
			_connectionEstablished = true;
			_cachedDataFiles = OnlineManager.DataFiles.GatherDataFiles(OnlineFileClass.OnlineChallenge, Owner.ObjectiveUniqueID, OnlineManager.GetFriendPlayerIDs(), createIfNone: true);
			foreach (KeyValuePair<OnlinePlayerID, BaseOnlineDataFile> cachedDataFile in _cachedDataFiles)
			{
				BaseOnlineDataFile value = cachedDataFile.Value;
				value.OnFileDownloadFinished = (Action<BaseOnlineDataFile, DownloadResult, EOnlineResult>)Delegate.Combine(value.OnFileDownloadFinished, new Action<BaseOnlineDataFile, DownloadResult, EOnlineResult>(OnFileDownloaded));
				value.Download(forceTry: true);
			}
		}

		private void OnFileDownloaded(BaseOnlineDataFile file, DownloadResult result, EOnlineResult onlineResult)
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
					Logging.Error(LogChannels.Online, "Received Online Challenge data for {0} (Unstarted) for {1} - but the SteamID embedded in the data does not match ({2})", Owner.Definition.NameLocalised, playerInfo.DisplayName, obj.PlayerID);
				}
				Owner.SetData(file.GetPlayerID(), obj);
				Owner.FriendDataCache[obj.PlayerID] = obj;
				Owner.Level.ObjectiveEvents.OnFriendDataUpdated.InvokeSafe(Owner, file.GetPlayerID(), obj);
			}
		}

		public override void Update(float timeDelta)
		{
			if (OnlineManager.IsInitializedAndLoggedOn() && Owner.Level.LevelScriptManager.ActiveOnlineChallenge == null)
			{
				_elapsedTime += timeDelta;
				if (_elapsedTime >= 30f)
				{
					RequestFriendData();
					_elapsedTime = 0f;
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

		public override void Exit()
		{
			if (!_connectionEstablished || !OnlineManager.IsInitializedAndLoggedOn())
			{
				return;
			}
			foreach (KeyValuePair<OnlinePlayerID, BaseOnlineDataFile> cachedDataFile in _cachedDataFiles)
			{
				BaseOnlineDataFile value = cachedDataFile.Value;
				value.OnFileDownloadFinished = (Action<BaseOnlineDataFile, DownloadResult, EOnlineResult>)Delegate.Remove(value.OnFileDownloadFinished, new Action<BaseOnlineDataFile, DownloadResult, EOnlineResult>(OnFileDownloaded));
			}
		}
	}
}
