using System;
using UnityEngine;

public class LeaderboardTestService : MonoBehaviour, LeaderboardController.ILeaderboardService
{
	public void EventGet(string leaderboardId, int startRank, int count, int? lastScore, string lastPlayerId, Action<LeaderboardEventGetResponseData> callback)
	{
	}

	public void EventPlayer(string leaderboardId, string playerId, Action<LeaderboardEventPlayerResponseData> callback)
	{
	}

	public void SubmitScoreUpdate(string leaderboardId, int score)
	{
	}

	public void EventSubmit(BaseEventController2 eventController, string leaderboardId, Action<LeaderboardEventSubmitResponseData> callback)
	{
	}

	public void LocationGet(string leaderboardId, int startRank, int count, int? lastScore, string lastPlayerId, Action<LeaderboardEventGetResponseData> callback)
	{
	}

	public void LocationPlayer(string leaderboardId, string playerId, Action<LeaderboardEventPlayerResponseData> callback)
	{
	}

	public void LocationSubmit(string leaderboardId, Action<LeaderboardEventSubmitResponseData> callback)
	{
	}

	public void SubmitLocationScore(string leaderboardId, int score)
	{
	}

	public void Create(string leaderboardId, string type, string endDate)
	{
	}

	public bool CanSubmit(BaseEventController2 eventController, string leaderboardId)
	{
		return false;
	}

	public bool CanSubmit(string leaderboardId)
	{
		return false;
	}

	public bool HasSubmitted()
	{
		return false;
	}

	public string? GetPlayerId()
	{
		return null;
	}

	public void ClearProgress()
	{
	}

	public void Parse(string sjson)
	{
	}

	public string Serialize()
	{
		return "";
	}
}
