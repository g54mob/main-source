using System;
using System.Collections.Generic;
using System.Text;
using AOT;
using Steamworks;
using UnityEngine;
using UnityEngine.Events;

[DisallowMultipleComponent]
public class SteamManager : MonoBehaviour
{
	public struct LeaderboardEntry
	{
		public string username;

		public int score;
	}

	protected static bool s_EverInitialized = false;

	protected static SteamManager s_instance;

	protected bool m_bInitialized;

	protected SteamAPIWarningMessageHook_t m_SteamAPIWarningMessageHook;

	private static CallResult<LeaderboardFindResult_t> _findLeaderboardCallback = new CallResult<LeaderboardFindResult_t>();

	public static int scoreToUpload = -1;

	private static CallResult<LeaderboardScoresDownloaded_t> _downloadedScoresCallback = new CallResult<LeaderboardScoresDownloaded_t>();

	public List<LeaderboardEntry> lastDownloadedLeaderboardEntires = new List<LeaderboardEntry>();

	public UnityEvent OnLeaderboardDownloadCallbackComplete = new UnityEvent();

	public static SteamManager Instance
	{
		get
		{
			if (s_instance == null)
			{
				return new GameObject("SteamManager").AddComponent<SteamManager>();
			}
			return s_instance;
		}
	}

	public static bool Initialized => Instance.m_bInitialized;

	[MonoPInvokeCallback(typeof(SteamAPIWarningMessageHook_t))]
	protected static void SteamAPIDebugTextHook(int nSeverity, StringBuilder pchDebugText)
	{
		Debug.LogWarning(pchDebugText);
	}

	[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.SubsystemRegistration)]
	private static void InitOnPlayMode()
	{
		s_EverInitialized = false;
		s_instance = null;
	}

	protected virtual void Awake()
	{
		if (s_instance != null)
		{
			UnityEngine.Object.Destroy(base.gameObject);
			return;
		}
		s_instance = this;
		scoreToUpload = -1;
		if (s_EverInitialized)
		{
			throw new Exception("Tried to Initialize the SteamAPI twice in one session!");
		}
		UnityEngine.Object.DontDestroyOnLoad(base.transform.root.gameObject);
		if (!Packsize.Test())
		{
			Debug.LogError("[Steamworks.NET] Packsize Test returned false, the wrong version of Steamworks.NET is being run in this platform.", this);
		}
		if (!DllCheck.Test())
		{
			Debug.LogError("[Steamworks.NET] DllCheck Test returned false, One or more of the Steamworks binaries seems to be the wrong version.", this);
		}
		try
		{
			if (SteamAPI.RestartAppIfNecessary(AppId_t.Invalid))
			{
				Debug.Log("[Steamworks.NET] Shutting down because RestartAppIfNecessary returned true. Steam will restart the application.");
				Application.Quit();
				return;
			}
		}
		catch (DllNotFoundException ex)
		{
			Debug.Log("[Steamworks.NET] Could not load [lib]steam_api.dll/so/dylib. It's likely not in the correct location. Refer to the README for more details.\n" + ex, this);
			Application.Quit();
			return;
		}
		m_bInitialized = SteamAPI.Init();
		if (!m_bInitialized)
		{
			Debug.Log("[Steamworks.NET] SteamAPI_Init() failed. This is likely the case because the Steam client is not running.", this);
		}
		else
		{
			s_EverInitialized = true;
		}
	}

	protected virtual void OnEnable()
	{
		if (s_instance == null)
		{
			s_instance = this;
		}
		if (m_bInitialized && m_SteamAPIWarningMessageHook == null)
		{
			m_SteamAPIWarningMessageHook = SteamAPIDebugTextHook;
			SteamClient.SetWarningMessageHook(m_SteamAPIWarningMessageHook);
		}
	}

	protected virtual void OnDestroy()
	{
		if (!(s_instance != this))
		{
			s_instance = null;
			if (m_bInitialized)
			{
				SteamAPI.Shutdown();
			}
		}
	}

	protected virtual void Update()
	{
		if (m_bInitialized)
		{
			SteamAPI.RunCallbacks();
		}
	}

	public void UploadHighscore(int _score, string _leaderboardName)
	{
		if (Initialized)
		{
			if (scoreToUpload != -1)
			{
				Debug.LogError("You can't upload multiple scores symultaneously with the current system.");
				return;
			}
			scoreToUpload = _score;
			SteamAPICall_t hAPICall = SteamUserStats.FindOrCreateLeaderboard(_leaderboardName, ELeaderboardSortMethod.k_ELeaderboardSortMethodDescending, ELeaderboardDisplayType.k_ELeaderboardDisplayTypeNumeric);
			_findLeaderboardCallback.Set(hAPICall, OnFindLeaderboardForUploadingScore);
		}
	}

	public void OnFindLeaderboardForUploadingScore(LeaderboardFindResult_t _callback, bool _failure)
	{
		if (_failure)
		{
			scoreToUpload = -1;
			return;
		}
		SteamUserStats.UploadLeaderboardScore(_callback.m_hSteamLeaderboard, ELeaderboardUploadScoreMethod.k_ELeaderboardUploadScoreMethodKeepBest, scoreToUpload, new int[0], 0);
		scoreToUpload = -1;
	}

	public void DownloadFriendsHighscores(string _leaderboardName)
	{
		lastDownloadedLeaderboardEntires.Clear();
		if (Initialized)
		{
			SteamAPICall_t hAPICall = SteamUserStats.FindLeaderboard(_leaderboardName);
			_findLeaderboardCallback.Set(hAPICall, OnFindLeaderboardFodDownloadingFriendsScore);
		}
	}

	public void OnFindLeaderboardFodDownloadingFriendsScore(LeaderboardFindResult_t _callback, bool _failure)
	{
		if (!_failure)
		{
			SteamAPICall_t hAPICall = SteamUserStats.DownloadLeaderboardEntries(_callback.m_hSteamLeaderboard, ELeaderboardDataRequest.k_ELeaderboardDataRequestFriends, 1, 100);
			_downloadedScoresCallback.Set(hAPICall, OnDownloadedScores);
		}
	}

	public void OnDownloadedScores(LeaderboardScoresDownloaded_t _callback, bool _failure)
	{
		if (_failure)
		{
			OnLeaderboardDownloadCallbackComplete.Invoke();
			return;
		}
		SteamUserStats.GetLeaderboardName(_callback.m_hSteamLeaderboard);
		int[] pDetails = new int[0];
		for (int i = 0; i < _callback.m_cEntryCount; i++)
		{
			SteamUserStats.GetDownloadedLeaderboardEntry(_callback.m_hSteamLeaderboardEntries, i, out var pLeaderboardEntry, pDetails, 0);
			LeaderboardEntry item = new LeaderboardEntry
			{
				username = SteamFriends.GetFriendPersonaName(pLeaderboardEntry.m_steamIDUser),
				score = pLeaderboardEntry.m_nScore
			};
			lastDownloadedLeaderboardEntires.Add(item);
		}
		OnLeaderboardDownloadCallbackComplete.Invoke();
	}
}
