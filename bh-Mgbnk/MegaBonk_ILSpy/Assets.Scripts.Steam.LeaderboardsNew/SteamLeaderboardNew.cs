using System;
using System.Collections.Generic;
using Cpp2ILInjected;
using Steamworks;

namespace Assets.Scripts.Steam.LeaderboardsNew;

public class SteamLeaderboardNew
{
	public string lbName;

	public string lbNameFriends;

	public SteamLeaderboard_t lbHandle;

	public SteamLeaderboard_t lbHandleFriends;

	public List<LeaderboardEntry> globalEntries;

	public List<LeaderboardEntry> friendsEntries;

	public LeaderboardEntry localEntry;

	public int localEntryRankFriends;

	public static Action<SteamLeaderboardNew> A_LeaderboardReady;

	private bool isSingleBoard;

	public bool scanForLegit;

	private int leaderboardEntriesPerRequest;

	private int currentIndex;

	private int numEntriesGlobal;

	private int numEntriesFriends;

	private int numDesiredGlobalEntries;

	private bool hasFriends;

	private bool hasGlobal;

	public SteamLeaderboardNew(string name, bool singleBoard = false, int entriesPerRequest = 200, int desiredNumEntries = 150, bool scanForLegit = true)
	{
		List<LeaderboardEntry> list = new List<LeaderboardEntry>();
		globalEntries = list;
		List<LeaderboardEntry> list2 = new List<LeaderboardEntry>();
		friendsEntries = list2;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1803321E0");
		int num = default(int);
		numDesiredGlobalEntries = num;
		bool flag = default(bool);
		this.scanForLegit = flag;
		isSingleBoard = singleBoard;
		leaderboardEntriesPerRequest = entriesPerRequest;
		if (singleBoard)
		{
			lbName = name;
			return;
		}
		string text = "v2_" + name;
		lbName = text;
		string text2 = "v2_" + name + "_friends";
		lbNameFriends = text2;
	}

	public void SetHandle(SteamLeaderboard_t handle, string lb)
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1831725BB]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		if (!lb.Contains("friends"))
		{
			lbHandle = handle;
		}
		else
		{
			lbHandleFriends = handle;
		}
	}

	private bool IsFriendsLb(string lb)
	{
		//IL_0058: Expected I4, but got O
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1831725BB]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		if (lb != null)
		{
			return lb.Contains("friends");
		}
		NullReferenceException ex = new NullReferenceException();
		return (byte)(int)ex != 0;
	}

	public bool IsReadyToDownloadEntries()
	{
		if (isSingleBoard)
		{
			if ((object)lbHandle != null)
			{
				return true;
			}
		}
		else if ((object)lbHandle != null)
		{
			bool flag = (nint)lbHandleFriends < 0;
			bool flag2 = (object)lbHandleFriends == null;
			bool flag3 = !flag;
			bool flag4 = !flag2;
			return flag4 & flag3;
		}
		return false;
	}

	public bool IsReadyToDisplay()
	{
		if (!hasGlobal)
		{
			return false;
		}
		return hasFriends;
	}

	public int GetTotalEntries(string lb)
	{
		//IL_006f: Expected I4, but got O
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1831725BB]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		if (lb != null)
		{
			if (!lb.Contains("friends"))
			{
				return numEntriesGlobal;
			}
			return numEntriesFriends;
		}
		NullReferenceException ex = new NullReferenceException();
		return (int)ex;
	}

	public void Refresh()
	{
		List<LeaderboardEntry> list = new List<LeaderboardEntry>();
		friendsEntries = list;
		List<LeaderboardEntry> list2 = new List<LeaderboardEntry>();
		globalEntries = list2;
		currentIndex = 0;
		hasFriends = false;
		localEntry = null;
		localEntryRankFriends = 0;
		numEntriesGlobal = 0;
		RequestGlobalEntries();
		if (!isSingleBoard)
		{
			int rangeEnd = default(int);
			SteamLeaderboardsManagerNew.DownloadLeaderboardEntries(lbNameFriends, lbHandleFriends, ELeaderboardDataRequest.k_ELeaderboardDataRequestFriends, 0, rangeEnd);
		}
	}

	private void RequestGlobalEntries()
	{
		//IL_0035: Expected O, but got I4
		//IL_003f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0044: Expected I4, but got Unknown
		int rangeEnd = default(int);
		SteamLeaderboardsManagerNew.DownloadLeaderboardEntries(lbName, lbHandle, ELeaderboardDataRequest.k_ELeaderboardDataRequestGlobal, currentIndex, rangeEnd);
		object obj = currentIndex + 1;
		int num = obj + leaderboardEntriesPerRequest;
		currentIndex = num;
	}

	public unsafe void OnDownloadResults(string lbNameDownloaded, LeaderboardScoresDownloaded_t param)
	{
		//IL_0071: Expected O, but got Ref
		//IL_007c: Expected O, but got Ref
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1831725BE]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		object obj = default(object);
		if (lbNameDownloaded != lbName)
		{
			if (!(lbNameDownloaded == lbNameFriends))
			{
				string text = "OnDownloadResults called with unknown lbName: " + lbNameDownloaded;
			}
			else
			{
				OnDownloadResultsFriends((LeaderboardScoresDownloaded_t)(&obj));
			}
		}
		else
		{
			OnDownloadResultsGlobal((LeaderboardScoresDownloaded_t)(&obj));
		}
	}

	private unsafe void OnDownloadResultsGlobal(LeaderboardScoresDownloaded_t param)
	{
		//IL_0025: Expected O, but got I4
		//IL_0054: Expected I4, but got O
		//IL_0071: Expected O, but got Ref
		//IL_00f8: Expected O, but got I4
		//IL_009a: Expected I8, but got O
		//IL_01fb: Expected O, but got I4
		//IL_0205: Unknown result type (might be due to invalid IL or missing references)
		//IL_020a: Expected I4, but got Unknown
		//IL_0147: Unknown result type (might be due to invalid IL or missing references)
		//IL_014c: Expected O, but got Unknown
		int leaderboardEntryCount = SteamUserStats.GetLeaderboardEntryCount(lbHandle);
		numEntriesGlobal = leaderboardEntryCount;
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_value_box\"");
		object arg = default(object);
		string text = $"[{lbName}] OnDownloadResults, total entries: {arg}";
		bool flag = param.m_cEntryCount <= 0;
		SteamLeaderboard_t steamLeaderboard_t = (SteamLeaderboard_t)0;
		string text2 = null;
		int num = default(int);
		if (!flag)
		{
			SteamLeaderboardEntries_t hSteamLeaderboardEntries = default(SteamLeaderboardEntries_t);
			int score = default(int);
			do
			{
				int[] array = new int[Leaderboards.numMaxDeatils];
				steamLeaderboard_t = param.m_hSteamLeaderboard;
				bool downloadedLeaderboardEntry = SteamUserStats.GetDownloadedLeaderboardEntry(hSteamLeaderboardEntries, (int)text2, out var pLeaderboardEntry, array, num);
				bool flag2 = !scanForLegit;
				int[] details = (int[])(&pLeaderboardEntry);
				if (!flag2)
				{
					bool flag3 = Leaderboards.CanShowScore((ulong)(long)pLeaderboardEntry, score, array, out var _);
					bool flag4 = !scanForLegit;
					details = array;
					if (!flag4)
					{
						bool flag5 = !flag3;
						details = array;
						if (flag5)
						{
							goto IL_013e;
						}
					}
				}
				LeaderboardEntry leaderboardEntry = new LeaderboardEntry((LeaderboardEntry_t)0, details);
				leaderboardEntry.leaderboardEntry = pLeaderboardEntry;
				leaderboardEntry.details = array;
				_ = 0;
				globalEntries.Add(leaderboardEntry);
				goto IL_013e;
				IL_013e:
				text2++;
			}
			while ((nint)text2 < param.m_cEntryCount);
		}
		if (param.m_cEntryCount >= leaderboardEntriesPerRequest)
		{
			List<LeaderboardEntry> list = globalEntries;
			if (list._size < numDesiredGlobalEntries)
			{
				SteamLeaderboardsManagerNew.DownloadLeaderboardEntries(lbName, lbHandle, ELeaderboardDataRequest.k_ELeaderboardDataRequestGlobal, currentIndex, num);
				object obj = currentIndex + 1;
				int num2 = obj + leaderboardEntriesPerRequest;
				currentIndex = num2;
				return;
			}
		}
		string text3 = "[" + lbName + "] No more entries to request";
		hasGlobal = true;
		if ((isSingleBoard && hasGlobal) || (hasFriends && hasGlobal))
		{
			Action<SteamLeaderboardNew> a_LeaderboardReady = A_LeaderboardReady;
			if (A_LeaderboardReady != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v508 @ rax_v29 (System.Action`1<Assets.Scripts.Steam.LeaderboardsNew.SteamLeaderboardNew>)+18] (should have been resolved before IL gen)");
			}
		}
	}

	private unsafe void OnDownloadResultsFriends(LeaderboardScoresDownloaded_t param)
	{
		//IL_01d7: Expected O, but got I4
		//IL_0089: Expected O, but got Ref
		//IL_0089: Expected O, but got I4
		//IL_0035: Expected O, but got Ref
		//IL_0035: Expected O, but got I4
		int leaderboardEntryCount = SteamUserStats.GetLeaderboardEntryCount(lbHandleFriends);
		numEntriesFriends = leaderboardEntryCount;
		bool flag = param.m_cEntryCount <= 0;
		SteamLeaderboard_t steamLeaderboard_t = (SteamLeaderboard_t)0;
		int num = 0;
		if (!flag)
		{
			SteamLeaderboardEntries_t hSteamLeaderboardEntries = default(SteamLeaderboardEntries_t);
			int cDetailsMax = default(int);
			do
			{
				int[] array = new int[Leaderboards.numMaxDeatils];
				steamLeaderboard_t = param.m_hSteamLeaderboard;
				bool downloadedLeaderboardEntry = SteamUserStats.GetDownloadedLeaderboardEntry(hSteamLeaderboardEntries, num, out var pLeaderboardEntry, array, cDetailsMax);
				LeaderboardEntry item;
				List<LeaderboardEntry> list;
				if ((long)pLeaderboardEntry != (long)SteamManager.steamId)
				{
					LeaderboardEntry leaderboardEntry = new LeaderboardEntry((LeaderboardEntry_t)0, (int[])(&pLeaderboardEntry));
					leaderboardEntry.leaderboardEntry = pLeaderboardEntry;
					leaderboardEntry.details = array;
					_ = 0;
					item = leaderboardEntry;
					list = friendsEntries;
				}
				else
				{
					LeaderboardEntry leaderboardEntry2 = new LeaderboardEntry((LeaderboardEntry_t)0, (int[])(&pLeaderboardEntry));
					leaderboardEntry2.leaderboardEntry = pLeaderboardEntry;
					leaderboardEntry2.details = array;
					_ = 0;
					localEntry = leaderboardEntry2;
					list = friendsEntries;
					int num2 = num + 1;
					localEntryRankFriends = num2;
					item = localEntry;
				}
				list.Add(item);
				num++;
			}
			while (num < param.m_cEntryCount);
		}
		hasFriends = true;
		if ((isSingleBoard && hasGlobal) || (hasFriends && hasGlobal))
		{
			Action<SteamLeaderboardNew> a_LeaderboardReady = A_LeaderboardReady;
			if (A_LeaderboardReady != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v271 @ rax_v29 (System.Action`1<Assets.Scripts.Steam.LeaderboardsNew.SteamLeaderboardNew>)+18] (should have been resolved before IL gen)");
			}
		}
	}

	private void CheckIfLeaderboardsAreReady()
	{
		if ((isSingleBoard && hasGlobal) || (hasFriends && hasGlobal))
		{
			Action<SteamLeaderboardNew> a_LeaderboardReady = A_LeaderboardReady;
			if (A_LeaderboardReady != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v92 @ rax_v4 (System.Action`1<Assets.Scripts.Steam.LeaderboardsNew.SteamLeaderboardNew>)+18] (should have been resolved before IL gen)");
			}
		}
	}

	public unsafe void OnDownloadResultsLocal(string lbNameDownloaded, LeaderboardScoresDownloaded_t param)
	{
		//IL_0040: Expected O, but got Ref
		//IL_0040: Expected O, but got I4
		if (param.m_cEntryCount > 0)
		{
			int num = 0;
			SteamLeaderboardEntries_t hSteamLeaderboardEntries = default(SteamLeaderboardEntries_t);
			int cDetailsMax = default(int);
			do
			{
				int[] array = new int[Leaderboards.numMaxDeatils];
				bool downloadedLeaderboardEntry = SteamUserStats.GetDownloadedLeaderboardEntry(hSteamLeaderboardEntries, num, out var pLeaderboardEntry, array, cDetailsMax);
				LeaderboardEntry leaderboardEntry = new LeaderboardEntry((LeaderboardEntry_t)0, (int[])(&pLeaderboardEntry));
				leaderboardEntry.leaderboardEntry = pLeaderboardEntry;
				leaderboardEntry.details = array;
				_ = 0;
				localEntry = leaderboardEntry;
				num++;
			}
			while (num < param.m_cEntryCount);
		}
	}
}
