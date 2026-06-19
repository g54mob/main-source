using System.Collections.Generic;
using FullInspector;

namespace TH20
{
	public class OnlineChallengeViewRecord : MustCallDestroy
	{
		public Dictionary<string, uint> TimeLastViewed = new Dictionary<string, uint>();

		[DontSave]
		private Metagame _metagame;

		public OnlineChallengeViewRecord(Metagame metagame)
		{
			_metagame = metagame;
		}

		public void RestoreFromSave(Metagame metagame)
		{
			_metagame = metagame;
		}

		public override void Destroy()
		{
			base.Destroy();
		}

		public void LogView(string uniqueID)
		{
			if (OnlineManager.IsInitializedAndLoggedOn() && uniqueID != null)
			{
				TimeLastViewed[uniqueID] = OnlineManager.GetServerTime();
			}
		}

		public int GetNumUnseenEventsForOnlineChallengeInLevel(LevelConfig levelConfig)
		{
			if (!OnlineManager.IsInitializedAndLoggedOn())
			{
				return 0;
			}
			int num = 0;
			foreach (SharedInstance<ObjectiveDefinition> onlineChallenge in levelConfig.GetLevelScriptConfig().OnlineChallenges)
			{
				if (onlineChallenge.Instance is OnlineChallengeDefinition { LeaderboardName: var leaderboardName })
				{
					num += GetNumUnseenEventsForOnlineChallenge(leaderboardName);
				}
			}
			return num;
		}

		public int GetNumUnseenEventsForOnlineChallengeInLevelForOnlinePlayerId(LevelConfig levelConfig, OnlinePlayerID onlinePlayerID)
		{
			if (!OnlineManager.IsInitializedAndLoggedOn())
			{
				return 0;
			}
			int num = 0;
			foreach (SharedInstance<ObjectiveDefinition> onlineChallenge in levelConfig.GetLevelScriptConfig().OnlineChallenges)
			{
				if (onlineChallenge.Instance is OnlineChallengeDefinition { LeaderboardName: { } leaderboardName })
				{
					_metagame.OnlineChallengeViewRecord.TimeLastViewed.TryGetValue(leaderboardName, out var value);
					num = (HasUnseenEventForOnlineChallengeForOnlinePlayerId(leaderboardName, onlinePlayerID, value) ? (num + 1) : num);
				}
			}
			return num;
		}

		public int GetNumUnseenEventsForOnlineChallenge(string uniqueObjectiveID)
		{
			if (!OnlineManager.IsInitializedAndLoggedOn())
			{
				return 0;
			}
			if (_metagame == null || _metagame.OnlineChallengeViewRecord == null || uniqueObjectiveID == null)
			{
				return 0;
			}
			int num = 0;
			_metagame.OnlineChallengeViewRecord.TimeLastViewed.TryGetValue(uniqueObjectiveID, out var value);
			foreach (KeyValuePair<OnlinePlayerID, OnlineMetadata> item in _metagame.OnlineMetadataManager.GetMetadataCache())
			{
				if (HasUnseenEventForOnlineChallengeForOnlinePlayerId(uniqueObjectiveID, item.Key, value))
				{
					num++;
				}
			}
			return num;
		}

		public bool HasUnseenEventForOnlineChallengeForOnlinePlayerId(string uniqueObjectiveID, OnlinePlayerID onlinePlayerID, uint lastViewTime = 0u)
		{
			if (!OnlineManager.IsInitializedAndLoggedOn())
			{
				return false;
			}
			if (OnlineManager.IsUserBlocked(onlinePlayerID))
			{
				return false;
			}
			if (_metagame == null || _metagame.OnlineChallengeViewRecord == null)
			{
				return false;
			}
			OnlineMetadata onlineMetadata = _metagame.OnlineMetadataManager.GetOnlineMetadata(onlinePlayerID);
			if (onlineMetadata == null)
			{
				return false;
			}
			if (!onlineMetadata.GetChallengeScore(uniqueObjectiveID, out var score))
			{
				return false;
			}
			if (lastViewTime == 0 || !_metagame.OnlineChallengeViewRecord.TimeLastViewed.TryGetValue(uniqueObjectiveID, out lastViewTime))
			{
				return true;
			}
			if (score.TimeStamp <= lastViewTime)
			{
				return false;
			}
			return true;
		}
	}
}
