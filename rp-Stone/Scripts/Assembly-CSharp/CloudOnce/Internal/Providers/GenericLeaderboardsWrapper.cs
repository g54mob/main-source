using System;
using CloudOnce.Internal.Utils;
using UnityEngine.SocialPlatforms;

namespace CloudOnce.Internal.Providers
{
	public class GenericLeaderboardsWrapper
	{
		public void SubmitScore(string leaderboardId, long score, Action<CloudRequestResult<bool>> onComplete = null)
		{
			CloudOnceUtils.LeaderboardUtils.SubmitScore(leaderboardId, score, onComplete);
		}

		public void ShowOverlay(string leaderboardID = "")
		{
			CloudOnceUtils.LeaderboardUtils.ShowOverlay(leaderboardID);
		}

		public void LoadScores(string leaderboardID, Action<IScore[]> callback)
		{
			CloudOnceUtils.LeaderboardUtils.LoadScores(leaderboardID, callback);
		}
	}
}
