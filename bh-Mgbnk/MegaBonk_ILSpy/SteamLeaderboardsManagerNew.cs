using System;
using System.Collections.Generic;
using Assets.Scripts.Steam;
using Assets.Scripts.Steam.LeaderboardsNew;
using Cpp2ILInjected;
using Steamworks;

public static class SteamLeaderboardsManagerNew
{
	private sealed class _003C_003Ec__DisplayClass27_0
	{
		public CallResult<LeaderboardScoresDownloaded_t> callResult;

		internal unsafe void _003CDownloadLeaderboardEntries_003Eb__0(LeaderboardScoresDownloaded_t param, bool failure)
		{
			//IL_0096: Expected O, but got Ref
			if (!failure && (object)param.m_hSteamLeaderboard != null)
			{
				string leaderboardName = SteamUserStats.GetLeaderboardName(param.m_hSteamLeaderboard);
				if (lbNameToLeaderboard.ContainsKey(leaderboardName))
				{
					SteamLeaderboardNew steamLeaderboardNew = lbNameToLeaderboard.get_Item(leaderboardName);
					SteamLeaderboard_t steamLeaderboard_t = default(SteamLeaderboard_t);
					steamLeaderboardNew.OnDownloadResults(leaderboardName, (LeaderboardScoresDownloaded_t)(&steamLeaderboard_t));
				}
			}
			if (callResult != null)
			{
				callResult.Dispose();
			}
		}
	}

	public const string lbVersion = "v2";

	public const string killsLb = "kills";

	public const string killsLbWeekly = "kills_weekly";

	public const string friendsLb = "friends";

	public static SteamLeaderboardNew leaderboardKillsAllTime;

	public static SteamLeaderboardNew leaderboardKillsWeekly;

	public static SteamLeaderboardNew leaderboardBannedPlayers;

	private static List<SteamLeaderboardNew> leaderboardNames;

	private static Dictionary<string, SteamLeaderboardNew> lbNameToLeaderboard;

	public static HashSet<ulong> cheaters;

	private static Dictionary<string, CallResult<LeaderboardFindResult_t>> leaderboardFindResults;

	private static Dictionary<string, CallResult<LeaderboardScoresDownloaded_t>> leaderboardScoresDownloadedResults;

	private static Dictionary<string, CallResult<LeaderboardScoresDownloaded_t>> leaderboardScoresDownloadedLocalResults;

	private static Dictionary<string, CallResult<LeaderboardScoreUploaded_t>> leaderboardScoreUploadResults;

	public static Action A_CheatersUpdated;

	private static bool initialized;

	private static Queue<LeaderboardUploadQueued> uploadQueue;

	private static bool isLeaderboardUploadInProgress;

	private static DateTime currentUploadStartTime;

	private static float uploadTimeoutSeconds;

	public static Action<string, int> A_LeaderboardScoreUploaded;

	public unsafe static void Init()
	{
		//IL_0552: Expected I, but got O
		//IL_0380: Expected O, but got I
		//IL_0023: Expected I, but got O
		//IL_002c: Expected I, but got O
		//IL_004a: Expected O, but got I
		//IL_0065: Expected O, but got I
		//IL_006e: Expected I, but got O
		//IL_0087: Expected I, but got O
		//IL_00a7: Expected O, but got I
		//IL_00cb: Expected I, but got O
		//IL_00ea: Expected O, but got I
		//IL_00f8: Expected O, but got Ref
		//IL_03c6: Expected O, but got Ref
		//IL_0254: Expected I, but got O
		//IL_0457: Expected O, but got I
		//IL_0126: Expected O, but got Ref
		//IL_02aa: Expected I, but got O
		//IL_0469: Expected O, but got I
		//IL_014a: Expected O, but got I
		//IL_0164: Expected O, but got I
		//IL_0184: Expected O, but got Ref
		//IL_03ed: Expected I, but got O
		//IL_01b5: Expected O, but got I
		//IL_01c6: Expected O, but got I
		//IL_04af: Expected I, but got O
		//IL_04ce: Expected I, but got O
		//IL_01dc: Expected O, but got I
		//IL_0571: Expected O, but got I
		//IL_050a: Expected I, but got O
		//IL_0588: Expected O, but got I
		//IL_0591: Expected I, but got O
		initialized = true;
		object obj = leaderboardBannedPlayers;
		bool flag = leaderboardBannedPlayers == null;
		nint num = (nint)typeof(SteamLeaderboardsManagerNew);
		object obj2;
		if (!flag)
		{
			bool flag2 = lbNameToLeaderboard == null;
			num = (nint)typeof(SteamLeaderboardsManagerNew);
			nint num2 = (nint)lbNameToLeaderboard;
			if (!flag2)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v146 @ rdx_v9 (System.Object)+10]");
				obj = 0;
				Dictionary<string, SteamLeaderboardNew> dictionary = lbNameToLeaderboard;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v146 @ rdx_v9 (System.Object)+10]");
				((Dictionary<object, object>)(object)dictionary).set_Item((object)0, (object)leaderboardBannedPlayers);
				num2 = (nint)leaderboardBannedPlayers;
				bool flag3 = leaderboardBannedPlayers == null;
				num = (nint)leaderboardBannedPlayers;
				if (!flag3)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v88 @ rcx_v14 (Il2CppMethodInfo)+10]");
					FindLeaderboard((string)0);
					obj = leaderboardNames;
					bool flag4 = leaderboardNames == null;
					num = (nint)leaderboardBannedPlayers;
					if (!flag4)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @181126F30");
						obj2 = 0;
						List<object>.Enumerator enumerator = default(List<object>.Enumerator);
						object obj3 = default(object);
						Action<SteamLeaderboardNew> action = default(Action<SteamLeaderboardNew>);
						object obj7 = default(object);
						nint num3;
						while (true)
						{
							if (enumerator.MoveNext())
							{
								Dictionary<object, object> dictionary2 = (Dictionary<object, object>)(&enumerator);
								bool flag5 = obj3 == null;
								object obj4 = obj3;
								List<SteamLeaderboardNew>.Enumerator enumerator2 = (List<SteamLeaderboardNew>.Enumerator)(&enumerator);
								num3 = 0;
								if (!flag5)
								{
									dictionary2 = (Dictionary<object, object>)(object)lbNameToLeaderboard;
									bool flag6 = lbNameToLeaderboard == null;
									obj4 = obj3;
									enumerator2 = (List<SteamLeaderboardNew>.Enumerator)(&enumerator);
									num3 = 0;
									if (!flag6)
									{
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v276 @ stack_-30 (System.Object)+10]");
										obj = 0;
										Dictionary<string, SteamLeaderboardNew> dictionary3 = lbNameToLeaderboard;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v276 @ stack_-30 (System.Object)+10]");
										((Dictionary<object, object>)(object)dictionary3).set_Item((object)0, obj3);
										bool flag7 = lbNameToLeaderboard == null;
										obj4 = obj3;
										enumerator2 = (List<SteamLeaderboardNew>.Enumerator)(&enumerator);
										obj2 = obj3;
										if (flag7)
										{
											break;
										}
										Dictionary<string, SteamLeaderboardNew> dictionary4 = lbNameToLeaderboard;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v276 @ stack_-30 (System.Object)+18]");
										((Dictionary<object, object>)(object)dictionary4).set_Item((object)0, obj3);
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v276 @ stack_-30 (System.Object)+10]");
										FindLeaderboard((string)0);
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v276 @ stack_-30 (System.Object)+18]");
										FindLeaderboard((string)0);
										obj2 = obj3;
										continue;
									}
									throw new NullReferenceException();
								}
								throw new NullReferenceException();
							}
							((List<SteamLeaderboardNew>.Enumerator*)(&enumerator))->Dispose();
							Action<SteamLeaderboardNew> b = OnLeaderboardReady;
							Delegate obj5 = Delegate.Combine(SteamLeaderboardNew.A_LeaderboardReady, b);
							nint num4;
							Delegate obj6;
							if ((object)obj5 == null)
							{
								SteamLeaderboardNew.A_LeaderboardReady = null;
							}
							else
							{
								((Dictionary<string, SteamLeaderboardNew>)(object)obj5).set_Item((string)(object)typeof(Action<SteamLeaderboardNew>), (SteamLeaderboardNew)null);
								bool flag8 = action == null;
								num4 = (nint)typeof(Action<SteamLeaderboardNew>);
								obj6 = obj5;
								obj2 = null;
								if (flag8)
								{
									goto IL_0446;
								}
								SteamLeaderboardNew.A_LeaderboardReady = action;
								((Dictionary<string, SteamLeaderboardNew>)(object)obj5).set_Item((string)(object)typeof(Action<SteamLeaderboardNew>), (SteamLeaderboardNew)null);
								bool flag9 = obj7 == null;
								num4 = (nint)typeof(Action<SteamLeaderboardNew>);
								obj6 = obj5;
								obj2 = null;
								if (flag9)
								{
									goto IL_0458;
								}
							}
							Action action2 = Update;
							Delegate obj8 = Delegate.Combine(SteamManager.A_UpdateComponents, action2);
							if ((object)obj8 == null)
							{
								SteamManager.A_UpdateComponents = null;
								return;
							}
							bool flag10 = (object)obj8.GetType() != typeof(Action);
							object obj9 = null;
							if (!flag10)
							{
								obj9 = obj8;
							}
							bool flag11 = obj9 == null;
							num4 = (nint)SteamManager.A_UpdateComponents;
							obj6 = action2;
							obj2 = obj8;
							nint num5 = (nint)typeof(Action);
							if (!flag11)
							{
								SteamManager.A_UpdateComponents = (Action)obj9;
								bool flag12 = (object)obj8.GetType() != typeof(Action);
								object obj10 = null;
								if (!flag12)
								{
									obj10 = obj8;
								}
								bool flag13 = obj10 == null;
								object obj4 = SteamManager.A_UpdateComponents;
								List<SteamLeaderboardNew>.Enumerator enumerator2 = (List<SteamLeaderboardNew>.Enumerator)action2;
								num3 = (nint)typeof(Action);
								obj2 = obj8;
								if (!flag13)
								{
									return;
								}
								((Dictionary<string, SteamLeaderboardNew>)obj2).set_Item((string)num3, (SteamLeaderboardNew)obj2);
								num4 = (nint)obj4;
								obj6 = (Delegate)enumerator2;
							}
							((Dictionary<string, SteamLeaderboardNew>)obj2).set_Item((string)num5, (SteamLeaderboardNew)obj2);
							goto IL_0458;
							IL_0458:
							((Dictionary<string, SteamLeaderboardNew>)(object)obj6).set_Item((string)num4, (SteamLeaderboardNew)obj2);
							goto IL_0446;
							IL_0446:
							((Dictionary<string, SteamLeaderboardNew>)(object)obj6).set_Item((string)num4, (SteamLeaderboardNew)obj2);
							return;
						}
						num3 = (nint)obj;
						throw new NullReferenceException();
					}
				}
			}
		}
		obj2 = num;
		throw new NullReferenceException();
	}

	public unsafe static void OnDestroy()
	{
		//IL_05f2: Expected O, but got I4
		//IL_0030: Expected O, but got I4
		//IL_0618: Expected O, but got Ref
		//IL_00ad: Expected O, but got Ref
		//IL_0655: Expected O, but got Ref
		//IL_0140: Expected O, but got Ref
		//IL_0692: Expected O, but got Ref
		//IL_01d3: Expected O, but got Ref
		//IL_0293: Expected I, but got O
		//IL_029c: Expected O, but got I4
		//IL_02b9: Expected I, but got O
		//IL_02f7: Expected I, but got O
		//IL_0300: Expected O, but got I4
		//IL_031d: Expected I, but got O
		//IL_037c: Expected I, but got O
		//IL_0548: Expected I, but got O
		//IL_0551: Expected O, but got I4
		//IL_0571: Expected I, but got O
		//IL_057f: Expected I, but got O
		//IL_0392: Expected I, but got O
		//IL_03a0: Expected O, but got I
		//IL_03c1: Expected I, but got O
		//IL_05a5: Expected O, but got I4
		//IL_05c5: Expected I, but got O
		//IL_06d0: Expected O, but got I
		//IL_06d4: Expected I, but got O
		//IL_06de: Expected I, but got O
		//IL_03d7: Expected I, but got O
		bool flag = leaderboardFindResults == null;
		CallResult<LeaderboardFindResult_t> callResult = null;
		Dictionary<string, CallResult<LeaderboardFindResult_t>>.ValueCollection.Enumerator enumerator = (Dictionary<string, CallResult<LeaderboardFindResult_t>>.ValueCollection.Enumerator)0;
		if (!flag)
		{
			Dictionary<string, CallResult<LeaderboardFindResult_t>>.ValueCollection values = leaderboardFindResults.Values;
			bool flag2 = values == null;
			callResult = null;
			enumerator = (Dictionary<string, CallResult<LeaderboardFindResult_t>>.ValueCollection.Enumerator)0;
			if (!flag2)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AEBE00");
				Dictionary<string, CallResult<LeaderboardFindResult_t>>.ValueCollection.Enumerator enumerator2 = default(Dictionary<string, CallResult<LeaderboardFindResult_t>>.ValueCollection.Enumerator);
				CallResult<LeaderboardFindResult_t> callResult2 = default(CallResult<LeaderboardFindResult_t>);
				while (enumerator2.MoveNext())
				{
					callResult2?.Dispose();
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1803321E0");
				bool flag3 = leaderboardScoresDownloadedResults == null;
				Action action = (Action)(&enumerator2);
				callResult = callResult2;
				Dictionary<string, CallResult<LeaderboardFindResult_t>>.ValueCollection.Enumerator enumerator3 = default(Dictionary<string, CallResult<LeaderboardFindResult_t>>.ValueCollection.Enumerator);
				enumerator = enumerator3;
				nint num = 0;
				if (!flag3)
				{
					Dictionary<string, CallResult<LeaderboardScoresDownloaded_t>>.ValueCollection values2 = leaderboardScoresDownloadedResults.Values;
					bool flag4 = values2 == null;
					action = (Action)(&enumerator2);
					callResult = callResult2;
					enumerator = enumerator3;
					num = 0;
					if (!flag4)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AEBE00");
						Dictionary<string, CallResult<LeaderboardScoresDownloaded_t>>.ValueCollection.Enumerator enumerator4 = default(Dictionary<string, CallResult<LeaderboardScoresDownloaded_t>>.ValueCollection.Enumerator);
						while (enumerator4.MoveNext())
						{
							((CallResult<LeaderboardScoresDownloaded_t>)(object)callResult2)?.Dispose();
						}
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1803321E0");
						bool flag5 = leaderboardScoresDownloadedLocalResults == null;
						action = (Action)(&enumerator4);
						callResult = callResult2;
						Dictionary<string, CallResult<LeaderboardScoresDownloaded_t>>.ValueCollection.Enumerator enumerator5 = default(Dictionary<string, CallResult<LeaderboardScoresDownloaded_t>>.ValueCollection.Enumerator);
						enumerator = (Dictionary<string, CallResult<LeaderboardFindResult_t>>.ValueCollection.Enumerator)enumerator5;
						num = 0;
						if (!flag5)
						{
							Dictionary<string, CallResult<LeaderboardScoresDownloaded_t>>.ValueCollection values3 = leaderboardScoresDownloadedLocalResults.Values;
							bool flag6 = values3 == null;
							action = (Action)(&enumerator4);
							callResult = callResult2;
							enumerator = (Dictionary<string, CallResult<LeaderboardFindResult_t>>.ValueCollection.Enumerator)enumerator5;
							num = 0;
							if (!flag6)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AEBE00");
								Dictionary<string, CallResult<LeaderboardScoresDownloaded_t>>.ValueCollection.Enumerator enumerator6 = default(Dictionary<string, CallResult<LeaderboardScoresDownloaded_t>>.ValueCollection.Enumerator);
								while (enumerator6.MoveNext())
								{
									((CallResult<LeaderboardScoresDownloaded_t>)(object)callResult2)?.Dispose();
								}
								Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1803321E0");
								bool flag7 = leaderboardScoreUploadResults == null;
								action = (Action)(&enumerator6);
								callResult = callResult2;
								Dictionary<string, CallResult<LeaderboardScoresDownloaded_t>>.ValueCollection.Enumerator enumerator7 = default(Dictionary<string, CallResult<LeaderboardScoresDownloaded_t>>.ValueCollection.Enumerator);
								enumerator = (Dictionary<string, CallResult<LeaderboardFindResult_t>>.ValueCollection.Enumerator)enumerator7;
								num = 0;
								if (!flag7)
								{
									Dictionary<string, CallResult<LeaderboardScoreUploaded_t>>.ValueCollection values4 = leaderboardScoreUploadResults.Values;
									bool flag8 = values4 == null;
									action = (Action)(&enumerator6);
									callResult = callResult2;
									enumerator = (Dictionary<string, CallResult<LeaderboardFindResult_t>>.ValueCollection.Enumerator)enumerator7;
									num = 0;
									if (!flag8)
									{
										Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AEBE00");
										Dictionary<string, CallResult<LeaderboardScoreUploaded_t>>.ValueCollection.Enumerator enumerator8 = default(Dictionary<string, CallResult<LeaderboardScoreUploaded_t>>.ValueCollection.Enumerator);
										while (enumerator8.MoveNext())
										{
											((CallResult<LeaderboardScoreUploaded_t>)(object)callResult2)?.Dispose();
										}
										Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1803321E0");
										Action<SteamLeaderboardNew> value = OnLeaderboardReady;
										Delegate obj = Delegate.Remove(SteamLeaderboardNew.A_LeaderboardReady, value);
										Dictionary<string, CallResult<LeaderboardScoreUploaded_t>>.ValueCollection.Enumerator enumerator9 = default(Dictionary<string, CallResult<LeaderboardScoreUploaded_t>>.ValueCollection.Enumerator);
										object obj2;
										nint num2;
										if ((object)obj == null)
										{
											SteamLeaderboardNew.A_LeaderboardReady = null;
										}
										else
										{
											Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
											Action<SteamLeaderboardNew> action2 = default(Action<SteamLeaderboardNew>);
											bool flag9 = action2 == null;
											num2 = (nint)typeof(Action<SteamLeaderboardNew>);
											obj2 = 0;
											action = (Action)obj;
											callResult = callResult2;
											enumerator = (Dictionary<string, CallResult<LeaderboardFindResult_t>>.ValueCollection.Enumerator)enumerator9;
											num = unchecked((nint)null);
											if (flag9)
											{
												goto IL_04ed;
											}
											SteamLeaderboardNew.A_LeaderboardReady = action2;
											Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
											object obj3 = default(object);
											bool flag10 = obj3 == null;
											num2 = (nint)typeof(Action<SteamLeaderboardNew>);
											obj2 = 0;
											action = (Action)obj;
											callResult = callResult2;
											enumerator = (Dictionary<string, CallResult<LeaderboardFindResult_t>>.ValueCollection.Enumerator)enumerator9;
											num = unchecked((nint)null);
											if (flag10)
											{
												goto IL_04f8;
											}
										}
										Action action3 = Update;
										Delegate obj4 = Delegate.Remove(SteamManager.A_UpdateComponents, action3);
										if ((object)obj4 == null)
										{
											SteamManager.A_UpdateComponents = null;
											return;
										}
										bool flag11 = (object)obj4.GetType() != typeof(Action);
										nint num3 = unchecked((nint)null);
										if (!flag11)
										{
											num3 = (nint)obj4;
										}
										bool flag12 = num3 == 0;
										num2 = (nint)SteamManager.A_UpdateComponents;
										obj2 = 0;
										action = action3;
										callResult = callResult2;
										enumerator = (Dictionary<string, CallResult<LeaderboardFindResult_t>>.ValueCollection.Enumerator)enumerator9;
										num = (nint)obj4;
										nint num4 = (nint)typeof(Action);
										if (!flag12)
										{
											SteamManager.A_UpdateComponents = (Action)num3;
											bool flag13 = (object)obj4.GetType() != typeof(Action);
											nint num5 = unchecked((nint)null);
											if (!flag13)
											{
												num5 = (nint)obj4;
											}
											bool flag14 = num5 == 0;
											obj2 = 0;
											action = action3;
											callResult = callResult2;
											enumerator = (Dictionary<string, CallResult<LeaderboardFindResult_t>>.ValueCollection.Enumerator)enumerator9;
											num = (nint)obj4;
											if (!flag14)
											{
												return;
											}
											num4 = (nint)((Dictionary<string, CallResult<LeaderboardFindResult_t>>.ValueCollection)num).GetEnumerator();
											num2 = (nint)SteamManager.A_UpdateComponents;
										}
										Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
										goto IL_04f8;
									}
								}
							}
						}
					}
				}
			}
		}
		throw new NullReferenceException();
		IL_04ed:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		return;
		IL_04f8:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_04ed;
	}

	private static void Update()
	{
		CheckUploadQueue();
	}

	public static void MenuOpened()
	{
		SteamLeaderboardNew steamLeaderboardNew = leaderboardKillsWeekly;
		TryRefreshLeaderboard(steamLeaderboardNew.lbName);
		SteamLeaderboardNew steamLeaderboardNew2 = leaderboardKillsAllTime;
		TryRefreshLeaderboard(steamLeaderboardNew2.lbName);
		SteamLeaderboardNew steamLeaderboardNew3 = leaderboardBannedPlayers;
		TryRefreshLeaderboard(steamLeaderboardNew3.lbName);
	}

	public static void QueueLeaderboardUpload(string leaderboardName, int score, int[] details, bool isFriendsLb)
	{
		bool isFriends = default(bool);
		LeaderboardUploadQueued item = new LeaderboardUploadQueued(leaderboardName, score, details, isFriends);
		((Queue<object>)(object)uploadQueue).Enqueue((object)item);
	}

	private static void CheckUploadQueue()
	{
		//IL_0133: Expected I, but got O
		//IL_009d: Expected O, but got I
		//IL_009d: Expected O, but got I
		if (!isLeaderboardUploadInProgress)
		{
			Queue<LeaderboardUploadQueued> queue = uploadQueue;
			if (queue._size > 0)
			{
				object obj = ((Queue<object>)(object)uploadQueue).Dequeue();
				isLeaderboardUploadInProgress = true;
				DateTime utcNow = DateTime.UtcNow;
				currentUploadStartTime = utcNow;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v287 @ rax_v26 (System.Object)+10]");
				nint num = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v287 @ rax_v26 (System.Object)+18]");
				nint num2 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v287 @ rax_v26 (System.Object)+20]");
				nint num3 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v287 @ rax_v26 (System.Object)+28]");
				UploadLeaderboardScore((string)num, (int)num2, (int[])num3, isFriendsLb: false);
			}
		}
		else
		{
			DateTime utcNow2 = DateTime.UtcNow;
			TimeSpan timeSpan = utcNow2 - currentUploadStartTime;
			nint num4 = (nint)typeof(TimeSpan);
			TimeSpan timeSpan2 = default(TimeSpan);
			double totalSeconds = timeSpan2.TotalSeconds;
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"comisd xmm0,xmm1\"");
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v284 @ rcx_v9 (Il2CppClass<System.TimeSpan>)+E4]");
			if ((nint)0 > (nint)0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1803321E0");
				isLeaderboardUploadInProgress = false;
			}
		}
	}

	public static void FindLeaderboard(string leaderboardName)
	{
		SteamAPICall_t hAPICall = SteamUserStats.FindLeaderboard(leaderboardName);
		CallResult<LeaderboardFindResult_t>.APIDispatchDelegate func = OnLeaderboardFindResult;
		CallResult<LeaderboardFindResult_t> callResult = CallResult<LeaderboardFindResult_t>.Create(func);
		callResult.Set(hAPICall);
		((Dictionary<object, object>)(object)leaderboardFindResults).set_Item((object)leaderboardName, (object)callResult);
	}

	public unsafe static void DownloadLeaderboardEntries(string lbName, SteamLeaderboard_t handle, ELeaderboardDataRequest dataRequest, int rangeStart, int rangeEnd)
	{
		_003C_003Ec__DisplayClass27_0 CS_0024_003C_003E8__locals5 = new _003C_003Ec__DisplayClass27_0();
		if (lbNameToLeaderboard.ContainsKey(lbName))
		{
			int nRangeEnd = default(int);
			SteamAPICall_t hAPICall = SteamUserStats.DownloadLeaderboardEntries(handle, dataRequest, rangeStart, nRangeEnd);
			CS_0024_003C_003E8__locals5.callResult = null;
			CallResult<LeaderboardScoresDownloaded_t>.APIDispatchDelegate func = delegate(LeaderboardScoresDownloaded_t param, bool failure)
			{
				//IL_0096: Expected O, but got Ref
				if (!failure && (object)param.m_hSteamLeaderboard != null)
				{
					string leaderboardName = SteamUserStats.GetLeaderboardName(param.m_hSteamLeaderboard);
					if (lbNameToLeaderboard.ContainsKey(leaderboardName))
					{
						SteamLeaderboardNew steamLeaderboardNew = lbNameToLeaderboard.get_Item(leaderboardName);
						SteamLeaderboard_t steamLeaderboard_t = default(SteamLeaderboard_t);
						steamLeaderboardNew.OnDownloadResults(leaderboardName, (LeaderboardScoresDownloaded_t)(&steamLeaderboard_t));
					}
				}
				if (CS_0024_003C_003E8__locals5.callResult != null)
				{
					CS_0024_003C_003E8__locals5.callResult.Dispose();
				}
			};
			CallResult<LeaderboardScoresDownloaded_t> callResult = CallResult<LeaderboardScoresDownloaded_t>.Create(func);
			CS_0024_003C_003E8__locals5.callResult = callResult;
			CS_0024_003C_003E8__locals5.callResult.Set(hAPICall);
			Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_value_box\"");
			Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_value_box\"");
			object arg = default(object);
			object arg2 = default(object);
			string text = $"Requested {lbName} entries from {arg} to {arg2}";
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1803321E0");
		}
		else
		{
			string text2 = "Couldn't find lb: " + lbName;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1803321E0");
		}
	}

	public static void DownloadLeaderboardEntryLocal(string lbName, SteamLeaderboard_t handle)
	{
		if (lbNameToLeaderboard.ContainsKey(lbName))
		{
			CSteamID[] array = new CSteamID[1];
			CSteamID steamID = SteamUser.GetSteamID();
			SteamAPICall_t hAPICall = SteamUserStats.DownloadLeaderboardEntriesForUsers(handle, array, array.Length);
			CallResult<LeaderboardScoresDownloaded_t>.APIDispatchDelegate func = LeaderboardScoresDownloadedLocal;
			CallResult<LeaderboardScoresDownloaded_t> callResult = CallResult<LeaderboardScoresDownloaded_t>.Create(func);
			callResult.Set(hAPICall);
			((Dictionary<object, object>)(object)leaderboardScoresDownloadedLocalResults).set_Item((object)lbName, (object)callResult);
		}
		else
		{
			string text = "Couldn't find lb: " + lbName;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1803321E0");
		}
	}

	public static void UploadLeaderboardScore(string leaderboardName, int score, int[] details, bool isFriendsLb)
	{
		//IL_0137: Expected O, but got I
		if (initialized)
		{
			if (lbNameToLeaderboard.ContainsKey(leaderboardName))
			{
				SteamLeaderboardNew steamLeaderboardNew = lbNameToLeaderboard.get_Item(leaderboardName);
				if (steamLeaderboardNew != null && steamLeaderboardNew.IsReadyToDisplay())
				{
					if (steamLeaderboardNew.localEntry != null)
					{
						LeaderboardEntry localEntry = steamLeaderboardNew.localEntry;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v405 @ rax_v40 (Assets.Scripts.Steam.LeaderboardEntry)+1C]");
						if ((nint)0 > (nint)score)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1803321E0");
							goto IL_01d8;
						}
					}
					string text = "Uploading leaderboard score to: " + leaderboardName;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1803321E0");
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v309 @ rax_v21 (Assets.Scripts.Steam.LeaderboardsNew.SteamLeaderboardNew)+20+isFriendsLb @ r9 (System.Boolean)*8]");
					int cScoreDetailsCount = default(int);
					SteamAPICall_t hAPICall = SteamUserStats.UploadLeaderboardScore((SteamLeaderboard_t)0, ELeaderboardUploadScoreMethod.k_ELeaderboardUploadScoreMethodKeepBest, score, details, cScoreDetailsCount);
					CallResult<LeaderboardScoreUploaded_t>.APIDispatchDelegate func = LeaderboardScoreUploaded;
					CallResult<LeaderboardScoreUploaded_t> callResult = CallResult<LeaderboardScoreUploaded_t>.Create(func);
					callResult.Set(hAPICall);
					((Dictionary<object, object>)(object)leaderboardScoreUploadResults).set_Item((object)leaderboardName, (object)callResult);
					return;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1803321E0");
			}
			else
			{
				string text2 = "Can't upload score to leaderboard " + leaderboardName + " because it doesn't exist";
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1803321E0");
			}
			goto IL_01d8;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1803321E0");
		return;
		IL_01d8:
		isLeaderboardUploadInProgress = false;
	}

	private static void TryRefreshLeaderboard(string lbName)
	{
		if (initialized)
		{
			SteamLeaderboardNew steamLeaderboardNew = lbNameToLeaderboard.get_Item(lbName);
			if (steamLeaderboardNew.IsReadyToDownloadEntries())
			{
				SteamLeaderboardNew steamLeaderboardNew2 = lbNameToLeaderboard.get_Item(lbName);
				steamLeaderboardNew2.Refresh();
			}
		}
	}

	public static SteamLeaderboardNew GetLeaderboard(string lbName)
	{
		if (lbNameToLeaderboard != null)
		{
			if (!lbNameToLeaderboard.ContainsKey(lbName))
			{
				return null;
			}
			if (lbNameToLeaderboard != null)
			{
				return lbNameToLeaderboard.get_Item(lbName);
			}
		}
		return (SteamLeaderboardNew)(object)new NullReferenceException();
	}

	public static bool IsCheater(ulong steamid)
	{
		//IL_002a: Expected I4, but got O
		if (cheaters != null)
		{
			return cheaters.Contains(steamid);
		}
		NullReferenceException ex = new NullReferenceException();
		return (byte)(int)ex != 0;
	}

	private unsafe static void OnLeaderboardReady(SteamLeaderboardNew leaderboard)
	{
		//IL_0022: Expected O, but got Ref
		//IL_005b: Expected I8, but got I
		if (leaderboard != leaderboardBannedPlayers)
		{
			return;
		}
		List<object>.Enumerator enumerator = (List<object>.Enumerator)leaderboardBannedPlayers;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @181126F30");
		List<object>.Enumerator enumerator2 = default(List<object>.Enumerator);
		object obj = default(object);
		while (true)
		{
			if (enumerator2.MoveNext())
			{
				List<object>.Enumerator enumerator3 = (List<object>.Enumerator)(&enumerator2);
				if (obj == null)
				{
					break;
				}
				if (cheaters != null)
				{
					HashSet<ulong> hashSet = cheaters;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v262 @ stack_-30+10]");
					bool flag = hashSet.Add(0uL);
					continue;
				}
				throw new NullReferenceException();
			}
			((List<LeaderboardEntry>.Enumerator*)(&enumerator2))->Dispose();
			Action a_CheatersUpdated = A_CheatersUpdated;
			if (A_CheatersUpdated != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v93.invoke_impl (System.IntPtr) (should have been resolved before IL gen)");
			}
			return;
		}
		throw new NullReferenceException();
	}

	private static void OnLeaderboardFindResult(LeaderboardFindResult_t param, bool bioFailure)
	{
		if (!bioFailure && (uint)param.m_bLeaderboardFound != (bioFailure ? 1u : 0u))
		{
			string leaderboardName = SteamUserStats.GetLeaderboardName(param.m_hSteamLeaderboard);
			if (lbNameToLeaderboard.ContainsKey(leaderboardName))
			{
				SteamLeaderboardNew steamLeaderboardNew = lbNameToLeaderboard.get_Item(leaderboardName);
				steamLeaderboardNew.SetHandle(param.m_hSteamLeaderboard, leaderboardName);
				CallResult<LeaderboardFindResult_t> callResult = leaderboardFindResults.get_Item(leaderboardName);
				callResult.Dispose();
				((Dictionary<object, object>)(object)leaderboardFindResults).set_Item((object)leaderboardName, (object)null);
				TryRefreshLeaderboard(leaderboardName);
				return;
			}
			string text = "Found unknown leaderboard: " + leaderboardName;
			string text2 = text;
		}
		else
		{
			string text2 = "Error when finding leaderboard";
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1803321E0");
	}

	private unsafe static void LeaderboardScoresDownloadedLocal(LeaderboardScoresDownloaded_t param, bool biofailure)
	{
		//IL_0096: Expected O, but got Ref
		bool flag = default(bool);
		if (!flag && (object)param.m_hSteamLeaderboard != null)
		{
			string leaderboardName = SteamUserStats.GetLeaderboardName(param.m_hSteamLeaderboard);
			if (lbNameToLeaderboard.ContainsKey(leaderboardName))
			{
				SteamLeaderboardNew steamLeaderboardNew = lbNameToLeaderboard.get_Item(leaderboardName);
				SteamLeaderboard_t steamLeaderboard_t = default(SteamLeaderboard_t);
				steamLeaderboardNew.OnDownloadResultsLocal(leaderboardName, (LeaderboardScoresDownloaded_t)(&steamLeaderboard_t));
				CallResult<LeaderboardScoresDownloaded_t> callResult = leaderboardScoresDownloadedLocalResults.get_Item(leaderboardName);
				callResult.Dispose();
				((Dictionary<object, object>)(object)leaderboardScoresDownloadedLocalResults).set_Item((object)leaderboardName, (object)null);
				return;
			}
			string text = "Couldn't find lb: " + leaderboardName;
		}
		else
		{
			bool flag2 = default(bool);
			string text2 = flag2.ToString();
			string text3 = ((ulong*)param)->ToString();
			string text = "Error when receiving LOCAL leaderboard scores\nbiofailure: " + text2 + "\nm_hSteamLeaderboard: " + text3 + "\n";
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1803321E0");
	}

	private static void LeaderboardScoreUploaded(LeaderboardScoreUploaded_t param, bool biofailure)
	{
		isLeaderboardUploadInProgress = false;
		if (!biofailure)
		{
			SteamLeaderboard_t hSteamLeaderboard = default(SteamLeaderboard_t);
			string leaderboardName = SteamUserStats.GetLeaderboardName(hSteamLeaderboard);
			if (param.m_bSuccess == 1 && param.m_bScoreChanged == 1)
			{
				Action<string, int> a_LeaderboardScoreUploaded = A_LeaderboardScoreUploaded;
				if (A_LeaderboardScoreUploaded != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v109 @ rax_v21 (System.Action`2<System.String, System.Int32>)+18] (should have been resolved before IL gen)");
				}
			}
			string leaderboardName2 = SteamUserStats.GetLeaderboardName(hSteamLeaderboard);
			CallResult<LeaderboardScoreUploaded_t> callResult = leaderboardScoreUploadResults.get_Item(leaderboardName2);
			callResult.Dispose();
			string leaderboardName3 = SteamUserStats.GetLeaderboardName(hSteamLeaderboard);
			((Dictionary<object, object>)(object)leaderboardScoreUploadResults).set_Item((object)leaderboardName3, (object)null);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1803321E0");
		}
	}

	static SteamLeaderboardsManagerNew()
	{
		int desiredNumEntries = default(int);
		bool scanForLegit = default(bool);
		SteamLeaderboardNew steamLeaderboardNew = new SteamLeaderboardNew("kills", singleBoard: false, 200, desiredNumEntries, scanForLegit);
		leaderboardKillsAllTime = steamLeaderboardNew;
		SteamLeaderboardNew steamLeaderboardNew2 = new SteamLeaderboardNew("kills_weekly", singleBoard: false, 200, desiredNumEntries, scanForLegit);
		leaderboardKillsWeekly = steamLeaderboardNew2;
		SteamLeaderboardNew steamLeaderboardNew3 = new SteamLeaderboardNew("banned_players", singleBoard: true, 1000, desiredNumEntries, scanForLegit);
		leaderboardBannedPlayers = steamLeaderboardNew3;
		List<SteamLeaderboardNew> list = new List<SteamLeaderboardNew>();
		SteamLeaderboardNew[] items = list._items;
		int version = list._version + 1;
		list._version = version;
		int size = list._size;
		if (list._size >= items.Length)
		{
			((List<object>)(object)list).AddWithResize((object)leaderboardKillsAllTime);
		}
		else
		{
			int size2 = list._size + 1;
			list._size = size2;
			items[size] = leaderboardKillsAllTime;
		}
		SteamLeaderboardNew[] items2 = list._items;
		int version2 = list._version + 1;
		list._version = version2;
		int size3 = list._size;
		if (list._size >= items2.Length)
		{
			((List<object>)(object)list).AddWithResize((object)leaderboardKillsWeekly);
		}
		else
		{
			int size4 = list._size + 1;
			list._size = size4;
			items2[size3] = leaderboardKillsWeekly;
		}
		leaderboardNames = list;
		Dictionary<string, SteamLeaderboardNew> dictionary = new Dictionary<string, SteamLeaderboardNew>();
		lbNameToLeaderboard = dictionary;
		HashSet<ulong> hashSet = new HashSet<ulong>();
		cheaters = hashSet;
		Dictionary<string, CallResult<LeaderboardFindResult_t>> dictionary2 = new Dictionary<string, CallResult<LeaderboardFindResult_t>>();
		leaderboardFindResults = dictionary2;
		Dictionary<string, CallResult<LeaderboardScoresDownloaded_t>> dictionary3 = new Dictionary<string, CallResult<LeaderboardScoresDownloaded_t>>();
		leaderboardScoresDownloadedResults = dictionary3;
		Dictionary<string, CallResult<LeaderboardScoresDownloaded_t>> dictionary4 = new Dictionary<string, CallResult<LeaderboardScoresDownloaded_t>>();
		leaderboardScoresDownloadedLocalResults = dictionary4;
		Dictionary<string, CallResult<LeaderboardScoreUploaded_t>> dictionary5 = new Dictionary<string, CallResult<LeaderboardScoreUploaded_t>>();
		leaderboardScoreUploadResults = dictionary5;
		Queue<LeaderboardUploadQueued> queue = new Queue<LeaderboardUploadQueued>();
		uploadQueue = queue;
		isLeaderboardUploadInProgress = false;
		uploadTimeoutSeconds = 10f;
	}
}
