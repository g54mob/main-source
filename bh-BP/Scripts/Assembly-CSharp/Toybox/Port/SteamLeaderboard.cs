using System;
using System.Collections.Generic;
using System.Threading;
using Steamworks;
using UnityEngine;

namespace Toybox.Port
{
	public class SteamLeaderboard : IPlatformLeaderboard
	{
		private SteamLeaderboard_t[] _lbs;

		private string _pendingLBId;

		private LBFilter _pendingLBFilt;

		private List<CallResult<LeaderboardScoreUploaded_t>> _lbUploadResult;

		private CallResult<LeaderboardScoresDownloaded_t> _lbDownloadResult;

		private Callback<AvatarImageLoaded_t> _avatarImageLoaded;

		private SteamLeaderboardEntries_t _lbEntries;

		private Action<List<LBEntry>, string> _lbDownloadCallback;

		private Dictionary<string, SteamLeaderboard_t> _customFoundLbs;

		private static Timer timer1;

		~SteamLeaderboard()
		{
		}

		private void OnSteamManagerInitialize()
		{
		}

		public static void InitLBCallbackTimer()
		{
		}

		private static void timer1_Tick(object state)
		{
		}

		private CallResult<LeaderboardScoreUploaded_t> GetOrCreateUploadCallResult()
		{
			return null;
		}

		public void PostScore(LBType t, int score, int[] extraData = null)
		{
		}

		public void PostScore(string lbID, int score, int[] extraData = null, LBSortDir sortMethod = LBSortDir.kAscending, LBDisplayType displayType = LBDisplayType.kNumeric)
		{
		}

		public int GetNumLBEntries(LBType t)
		{
			return 0;
		}

		public int GetNumLBEntries(string lbID)
		{
			return 0;
		}

		public void FetchLBEntries(LBType t, LBFilter filt, int rangeStart, int rangeEnd, Action<List<LBEntry>, LBType> callback)
		{
		}

		public void FetchLBEntries(string lbID, LBFilter filt, int rangeStart, int rangeEnd, Action<List<LBEntry>, string> callback)
		{
		}

		private void OnLeaderboardUploadResult(LeaderboardScoreUploaded_t pCallback, bool failure)
		{
		}

		private void OnLeaderboardFindResult(int idx, LeaderboardFindResult_t pCallback, bool failure)
		{
		}

		private void OnLeaderboardScoresDownloaded(LeaderboardScoresDownloaded_t pCallback, bool bIOFailure)
		{
		}

		public Texture2D GetSteamImageAsTexture2D(int iImage)
		{
			return null;
		}

		private void OnAvatarImageLoaded(AvatarImageLoaded_t pCallback)
		{
		}
	}
}
