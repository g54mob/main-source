using System;
using System.Collections.Generic;
using Dorfromantik;
using Galaxy.Api;
using Helpers;
using UnityEngine;

public class GogLeaderboardManager : MonoBehaviour
{
	private class LeaderboardTypeListeners
	{
		public LeaderboardRetrieveListener leaderboardRetrieveListener;

		public LeaderboardEntriesRetrieveListener leadEntriesRetrieveListener;

		public LeaderboardScoreUpdateListener leadScoreUpdateListener;
	}

	private class LeaderboardRetrieveListener : ILeaderboardRetrieveListener
	{
		public bool retrieved;

		public string leaderboardId;

		public event Action<string> OnLeaderboardRetrieved;

		public override void OnLeaderboardRetrieveSuccess(string name)
		{
			retrieved = true;
			this.OnLeaderboardRetrieved?.Invoke(leaderboardId);
		}

		public override void OnLeaderboardRetrieveFailure(string name, FailureReason failureReason)
		{
		}
	}

	private class LeaderboardEntriesRetrieveListener : GlobalLeaderboardEntriesRetrieveListener
	{
		public LeaderboardType leaderboardType;

		public event Action<int, int, LeaderboardType> OnRankRetrieved;

		public override void OnLeaderboardEntriesRetrieveSuccess(string leaderboardName, uint entryCount)
		{
			//IL_001b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0021: Expected O, but got Unknown
			leaderboardEntries.Clear();
			leaderboardEntries.TrimExcess();
			for (uint num = 0u; num < entryCount; num++)
			{
				GalaxyID val = new GalaxyID();
				uint num2 = 0u;
				int num3 = 0;
				string text = null;
				object[] array = new object[3] { num2, num3, text };
				GalaxyInstance.Stats().GetRequestedLeaderboardEntry(num, ref num2, ref num3, ref val);
				array[0] = num2;
				array[1] = num3;
				array[2] = text;
				leaderboardEntries.Add(array);
				if (leaderboardName != leaderboardType.GetLeaderboardId())
				{
					break;
				}
				this.OnRankRetrieved?.Invoke((int)num2, num3, leaderboardType);
			}
		}

		public override void OnLeaderboardEntriesRetrieveFailure(string leaderboardName, FailureReason failureReason)
		{
		}
	}

	private class LeaderboardScoreUpdateListener : GlobalLeaderboardScoreUpdateListener
	{
		public override void OnLeaderboardScoreUpdateSuccess(string leaderboardName, int score, uint oldRank, uint newRank)
		{
		}

		public override void OnLeaderboardScoreUpdateFailure(string leaderboardName, int score, FailureReason failureReason)
		{
		}
	}

	[SerializeField]
	private RewardSystem rewardSystem;

	[SerializeField]
	private LeaderboardManager leaderboardManager;

	private static List<object[]> leaderboardEntries = new List<object[]>();

	private Dictionary<string, LeaderboardTypeListeners> listeners = new Dictionary<string, LeaderboardTypeListeners>();

	private Dictionary<string, LeaderboardType> leaderboardTypeById = new Dictionary<string, LeaderboardType>();

	public List<object[]> LeaderboardEntries => leaderboardEntries;

	private void OnEnable()
	{
		GalaxyManager.OnSignInSuccessful += InitializeLeaderboard;
	}

	private void InitializeLeaderboard()
	{
		ListenersInit();
		foreach (LeaderboardType allLeaderboard in leaderboardManager.allLeaderboards)
		{
			RequestLeaderboard(allLeaderboard);
		}
	}

	private void InitializeRank(string leaderboardId)
	{
		RequestUserLeaderboardEntry(leaderboardTypeById[leaderboardId]);
		listeners[leaderboardId].leaderboardRetrieveListener.OnLeaderboardRetrieved -= InitializeRank;
	}

	private void ListenersInit()
	{
		foreach (LeaderboardType allLeaderboard in leaderboardManager.allLeaderboards)
		{
			leaderboardTypeById.Add(allLeaderboard.GetLeaderboardId(), allLeaderboard);
			InitLeaderboardListeners(allLeaderboard);
		}
	}

	private void InitLeaderboardListeners(LeaderboardType leaderboardType)
	{
		string leaderboardId = leaderboardType.GetLeaderboardId();
		listeners.Add(leaderboardId, new LeaderboardTypeListeners());
		Listener.Create(ref listeners[leaderboardId].leaderboardRetrieveListener);
		listeners[leaderboardId].leaderboardRetrieveListener.leaderboardId = leaderboardId;
		listeners[leaderboardId].leaderboardRetrieveListener.OnLeaderboardRetrieved += InitializeRank;
		Listener.Create(ref listeners[leaderboardId].leadEntriesRetrieveListener);
		listeners[leaderboardId].leadEntriesRetrieveListener.leaderboardType = leaderboardType;
		listeners[leaderboardId].leadEntriesRetrieveListener.OnRankRetrieved += UpdateRank;
		Listener.Create(ref listeners[leaderboardId].leadScoreUpdateListener);
	}

	private void UpdateRank(int newRank, int newScore, LeaderboardType leaderboardType)
	{
		rewardSystem.SetLeaderboardRank(leaderboardType, newRank);
		rewardSystem.SetLocalHighscore(leaderboardType, newScore);
	}

	private void ListenersDispose()
	{
		foreach (KeyValuePair<string, LeaderboardTypeListeners> listener in listeners)
		{
			listener.Value.leaderboardRetrieveListener.OnLeaderboardRetrieved -= InitializeRank;
			Listener.Dispose<LeaderboardRetrieveListener>(ref listener.Value.leaderboardRetrieveListener);
			listener.Value.leadEntriesRetrieveListener.OnRankRetrieved -= UpdateRank;
			Listener.Dispose<LeaderboardEntriesRetrieveListener>(ref listener.Value.leadEntriesRetrieveListener);
			Listener.Dispose<LeaderboardScoreUpdateListener>(ref listener.Value.leadScoreUpdateListener);
		}
	}

	private void Start()
	{
		rewardSystem.OnLeaderboardUpdateRequested += RequestUserLeaderboardEntry;
		rewardSystem.OnNewHighscoreSet += SetLeaderboardScore;
	}

	private void OnDestroy()
	{
		ListenersDispose();
		GalaxyManager.OnSignInSuccessful -= InitializeLeaderboard;
		rewardSystem.OnLeaderboardUpdateRequested -= RequestUserLeaderboardEntry;
		rewardSystem.OnNewHighscoreSet -= SetLeaderboardScore;
	}

	public void RequestLeaderboard(LeaderboardType leaderboardType)
	{
		if (!GalaxyManager.Instance.IsSignedIn(silent: true))
		{
			Debug.LogError("GalaxyManager is not initialized");
			return;
		}
		try
		{
			string leaderboardId = leaderboardType.GetLeaderboardId();
			GalaxyInstance.Stats().FindOrCreateLeaderboard(leaderboardId, leaderboardType.GetDisplayName(), (LeaderboardSortMethod)2, (LeaderboardDisplayType)1, (ILeaderboardRetrieveListener)(object)listeners[leaderboardId].leaderboardRetrieveListener);
			GalaxyInstance.Stats().RequestLeaderboards();
		}
		catch (Error)
		{
		}
	}

	public void RequestUserLeaderboardEntry(LeaderboardType leaderboardType)
	{
		string leaderboardId = leaderboardType.GetLeaderboardId();
		if (!leaderboardTypeById.ContainsKey(leaderboardId))
		{
			leaderboardTypeById.Add(leaderboardId, leaderboardType);
		}
		if (!listeners.ContainsKey(leaderboardId))
		{
			InitLeaderboardListeners(leaderboardType);
			RequestLeaderboard(leaderboardType);
			return;
		}
		try
		{
			(new GalaxyID[1])[0] = GalaxyInstance.User().GetGalaxyID();
			RequestLeaderboardEntriesAroundUser(leaderboardId, 0u, 0u, GalaxyInstance.User().GetGalaxyID());
		}
		catch (Exception)
		{
		}
	}

	public void SetLeaderboardScore(LeaderboardType leaderboardType, int score, bool forceUpdate)
	{
		string leaderboardId = leaderboardType.GetLeaderboardId();
		if (!leaderboardTypeById.ContainsKey(leaderboardId))
		{
			leaderboardTypeById.Add(leaderboardId, leaderboardType);
		}
		if (!listeners.ContainsKey(leaderboardId))
		{
			InitLeaderboardListeners(leaderboardType);
			RequestLeaderboard(leaderboardType);
			return;
		}
		try
		{
			GalaxyInstance.Stats().SetLeaderboardScore(leaderboardId, score, forceUpdate, (ILeaderboardScoreUpdateListener)(object)listeners[leaderboardId].leadScoreUpdateListener);
		}
		catch (Error)
		{
		}
	}

	public void RequestLeaderboardEntriesGlobal(string leaderboardName, uint rangeStart, uint rangeEnd)
	{
		try
		{
			GalaxyInstance.Stats().RequestLeaderboardEntriesGlobal(leaderboardName, rangeStart, rangeEnd);
		}
		catch (Error)
		{
		}
	}

	public void RequestLeaderboardEntriesAroundUser(string leaderboardId, uint countBefore, uint countAfter, GalaxyID userID)
	{
		try
		{
			GalaxyInstance.Stats().RequestLeaderboardEntriesAroundUser(leaderboardId, countBefore, countAfter, userID, (ILeaderboardEntriesRetrieveListener)(object)listeners[leaderboardId].leadEntriesRetrieveListener);
		}
		catch (Error)
		{
		}
	}
}
