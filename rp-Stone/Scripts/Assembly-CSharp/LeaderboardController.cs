using System;
using UnityEngine;

public class LeaderboardController : MonoBehaviour
{
	public interface ILeaderboardService
	{
		void EventGet(string leaderboardId, int startRank, int count, int? lastScore, string lastPlayerId, Action<LeaderboardEventGetResponseData> callback);

		void EventPlayer(string leaderboardId, string playerId, Action<LeaderboardEventPlayerResponseData> callback);

		void SubmitScoreUpdate(string leaderboardId, int score);

		void EventSubmit(BaseEventController2 eventController, string leaderboardId, Action<LeaderboardEventSubmitResponseData> callback);

		void LocationGet(string leaderboardId, int startRank, int count, int? lastScore, string lastPlayerId, Action<LeaderboardEventGetResponseData> callback);

		void LocationPlayer(string leaderboardId, string playerId, Action<LeaderboardEventPlayerResponseData> callback);

		void LocationSubmit(string leaderboardId, Action<LeaderboardEventSubmitResponseData> callback);

		void SubmitLocationScore(string leaderboardId, int score);

		void Create(string leaderboardId, string type, string endDate);

		bool CanSubmit(BaseEventController2 eventController, string leaderboardId);

		bool CanSubmit(string leaderboardId);

		bool HasSubmitted();

		string? GetPlayerId();

		void ClearProgress();

		void Parse(string sjson);

		string Serialize();
	}

	public static ILeaderboardService singleton { get; private set; }

	private void Awake()
	{
		singleton = base.gameObject.GetComponent<LeaderboardProductionService>();
	}
}
