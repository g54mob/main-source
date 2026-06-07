using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Steamworks;
using UnityEngine;

public class LeaderboardManager : Singleton<LeaderboardManager>
{
	public enum eLeaderBoardUploadStatus
	{
		NONE = 0,
		FIND_LEADERBOARD = 1,
		UPLOAD_SCORE = 2,
		SUCCESS = 3,
		FAILED = 4
	}

	[Serializable]
	public class LeaderboardUploadData
	{
		public string ExtraLeaderboardName;

		public int mainValue;

		public int[] extraParams;
	}

	public enum eLeaderboardDownloadStatus
	{
		NONE = 0,
		FIND_LEADERBOARD = 1,
		DOWNLOAD_ENTRIES = 2,
		SUCCESS = 3,
		FAILED = 4
	}

	[CompilerGenerated]
	private sealed class _003CDownloadLeaderboard_Steam_003Ed__42 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public LeaderboardManager _003C_003E4__this;

		public string fullLeaderboardName;

		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return null;
			}
		}

		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return null;
			}
		}

		[DebuggerHidden]
		public _003CDownloadLeaderboard_Steam_003Ed__42(int _003C_003E1__state)
		{
		}

		[DebuggerHidden]
		void IDisposable.Dispose()
		{
		}

		private bool MoveNext()
		{
			return false;
		}

		bool IEnumerator.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			return this.MoveNext();
		}

		[DebuggerHidden]
		void IEnumerator.Reset()
		{
		}
	}

	[CompilerGenerated]
	private sealed class _003CUploadLeaderboard_Steam_003Ed__16 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public LeaderboardManager _003C_003E4__this;

		public string leaderboardName;

		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return null;
			}
		}

		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return null;
			}
		}

		[DebuggerHidden]
		public _003CUploadLeaderboard_Steam_003Ed__16(int _003C_003E1__state)
		{
		}

		[DebuggerHidden]
		void IDisposable.Dispose()
		{
		}

		private bool MoveNext()
		{
			return false;
		}

		bool IEnumerator.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			return this.MoveNext();
		}

		[DebuggerHidden]
		void IEnumerator.Reset()
		{
		}
	}

	private LeaderboardUploadData currentLeaderboardData;

	private eLeaderBoardUploadStatus uploadStatus;

	private SteamLeaderboard_t currentUploadLeaderboard;

	private Texture2D pendingScreenshotTexture;

	private const string kUploadScreenshotFileName = "leaderboard_shot.png";

	protected Callback<AvatarImageLoaded_t> m_AvatarImageLoaded;

	private LeaderboardData leaderboardData;

	private eLeaderboardDownloadStatus downloadStatus;

	private List<LeaderboardEntry_t> leaderboardEntries;

	private LeaderboardEntry_t userEntry;

	private Dictionary<CSteamID, Texture2D> playerAvatars;

	private Dictionary<ulong, int> ugcHandleToEntryIndex;

	private Action<List<LeaderboardEntry_t>> onLeaderboardDownloadedCallback;

	private Action onLeaderboardDownloadFailCallback;

	private Action<int, Texture2D> onPlayerAvatarDownloadedCallback;

	private Action<int, Texture2D> onEntryScreenshotDownloadedCallback;

	private int leaderBoardUIID;

	private int rangeStart;

	private int rangeEnd;

	private int extraParamCount;

	public LeaderboardData LeaderboardData => null;

	private void Start()
	{
	}

	public string GetFullLeaderboardName(eLeaderboardType leaderboardType, string extraLeaderBoardName, bool doIncludeVersion = true)
	{
		return null;
	}

	public string GetFullLeaderboardName(string leaderboardName, string extraLeaderBoardName, bool doIncludeVersion = true)
	{
		return null;
	}

	public Coroutine UploadLeaderboard(string leaderboardName, string extraLeaderBoardName, int mainValue, params int[] extraParams)
	{
		return null;
	}

	public Coroutine UploadLeaderboard(eLeaderboardType leaderboardType, string extraLeaderBoardName, int mainValue, params int[] extraParams)
	{
		return null;
	}

	public Coroutine UploadLeaderboard(string leaderboardName, string extraLeaderBoardName, int mainValue, Texture2D screenshotTexture, params int[] extraParams)
	{
		return null;
	}

	public Coroutine UploadLeaderboard(eLeaderboardType leaderboardType, string extraLeaderBoardName, int mainValue, Texture2D screenshotTexture, params int[] extraParams)
	{
		return null;
	}

	public Coroutine UploadLeaderboard(string leaderboardName, int mainValue, Texture2D screenshotTexture, params int[] extraParams)
	{
		return null;
	}

	[IteratorStateMachine(typeof(_003CUploadLeaderboard_Steam_003Ed__16))]
	private IEnumerator UploadLeaderboard_Steam(string leaderboardName, int mainValue, params int[] extraParams)
	{
		return null;
	}

	private void OnLeaderboardFindResult(LeaderboardFindResult_t result, bool bIOFailure)
	{
	}

	private void OnLeaderboardScoreUploaded(LeaderboardScoreUploaded_t result, bool bIOFailure)
	{
	}

	private void TryUploadScreenshotAndAttach(SteamLeaderboard_t leaderboard, Texture2D screenshot)
	{
	}

	public void ClearLeaderboardCallback(int leaderBoardUIID)
	{
	}

	public Coroutine DownloadLeaderboard(int leaderBoardUIID, string leaderboardName, string extraLeaderBoardName, int rangeStart = 0, int rangeEnd = 9, int extraParamCount = 0, Action<List<LeaderboardEntry_t>> callback = null, Action onLeaderboardDownloadFailCallback = null, Action<int, Texture2D> onPlayerAvatarDownloaded = null, Action<int, Texture2D> onEntryScreenshotDownloaded = null)
	{
		return null;
	}

	public Coroutine DownloadLeaderboard(int leaderBoardUIID, eLeaderboardType leaderboardType, string extraLeaderBoardName, int rangeStart = 0, int rangeEnd = 9, int extraParamCount = 0, Action<List<LeaderboardEntry_t>> callback = null, Action onLeaderboardDownloadFailCallback = null, Action<int, Texture2D> onPlayerAvatarDownloaded = null, Action<int, Texture2D> onEntryScreenshotDownloaded = null)
	{
		return null;
	}

	private IEnumerator DownloadLeaderboard_Steam(eLeaderboardType leaderboardType, string extraLeaderBoardName)
	{
		return null;
	}

	private IEnumerator DownloadLeaderboard_Steam(string leaderboardName, string extraLeaderBoardName)
	{
		return null;
	}

	[IteratorStateMachine(typeof(_003CDownloadLeaderboard_Steam_003Ed__42))]
	private IEnumerator DownloadLeaderboard_Steam(string fullLeaderboardName)
	{
		return null;
	}

	private void OnLeaderboardFindForDownloadResult(LeaderboardFindResult_t result, bool bIOFailure)
	{
	}

	private void OnLeaderboardScoresDownloaded(LeaderboardScoresDownloaded_t result, bool bIOFailure)
	{
	}

	private void OnUserLeaderboardScoreDownloaded(LeaderboardScoresDownloaded_t result, bool bIOFailure)
	{
	}

	public void DownloadUGC(UGCHandle_t ugcHandle)
	{
	}

	private void OnUGCDownloaded(RemoteStorageDownloadUGCResult_t result, bool bIOFailure)
	{
	}

	private void GetPlayerAvatar(CSteamID steamID, Action<int, Texture2D> callback)
	{
	}

	public static Texture2D GetSteamImageAsTexture2D(int iImage)
	{
		return null;
	}

	private void OnAvatarImageLoaded(AvatarImageLoaded_t data)
	{
	}

	public Texture2D GetPlayerAvatarTexture(CSteamID steamID)
	{
		return null;
	}
}
