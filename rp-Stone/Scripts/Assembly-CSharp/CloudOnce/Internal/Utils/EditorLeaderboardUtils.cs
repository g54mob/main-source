using System;
using UnityEngine;
using UnityEngine.SocialPlatforms;

namespace CloudOnce.Internal.Utils
{
	public class EditorLeaderboardUtils : ILeaderboardUtils
	{
		public void SubmitScore(string id, long score, Action<CloudRequestResult<bool>> onComplete, string internalID = "")
		{
			if (string.IsNullOrEmpty(id))
			{
				ReportError($"Can't submit score to {internalID} leaderboard. Platform ID is null or empty!", onComplete);
			}
			else
			{
				CloudOnceUtils.SafeInvoke(onComplete, new CloudRequestResult<bool>(result: true));
			}
		}

		public void ShowOverlay(string id = "", string internalID = "")
		{
			Debug.LogWarning("Leaderboards overlay is not supported in the Unity Editor.");
		}

		public void LoadScores(string leaderboardID, Action<IScore[]> callback)
		{
			Debug.LogWarning("Leaderboards overlay is not supported in the Unity Editor.");
			CloudOnceUtils.SafeInvoke(callback, new IScore[0]);
		}

		private static void ReportError(string errorMessage, Action<CloudRequestResult<bool>> callbackAction)
		{
			CloudOnceUtils.SafeInvoke(callbackAction, new CloudRequestResult<bool>(result: false, errorMessage));
		}
	}
}
