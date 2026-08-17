using System;
using System.Collections.Generic;
using System.Linq;
using Assets.Scripts.Steam;
using Assets.Scripts.Steam.LeaderboardsNew;
using Cpp2ILInjected;
using Steamworks;

namespace Assets.Scripts.Menu.Shop.Leaderboards;

public static class LeaderboardUtility
{
	[Serializable]
	private sealed class _003C_003Ec
	{
		public static readonly _003C_003Ec _003C_003E9;

		public static Func<LeaderboardEntry, CSteamID> _003C_003E9__1_0;

		public static Func<LeaderboardEntry, int> _003C_003E9__1_3;

		public static Func<IGrouping<CSteamID, LeaderboardEntry>, LeaderboardEntry> _003C_003E9__1_1;

		public static Comparison<LeaderboardEntry> _003C_003E9__1_2;

		public static Comparison<LeaderboardEntry> _003C_003E9__2_0;

		static _003C_003Ec()
		{
			_003C_003Ec obj = new _003C_003Ec();
			_003C_003E9 = obj;
		}

		internal CSteamID _003CGetEntriesKills_003Eb__1_0(LeaderboardEntry e)
		{
			return (CSteamID)(((object?)e?.leaderboardEntry) ?? ((object)new NullReferenceException()));
		}

		internal LeaderboardEntry _003CGetEntriesKills_003Eb__1_1(IGrouping<CSteamID, LeaderboardEntry> g)
		{
			Func<LeaderboardEntry, int> keySelector = _003C_003E9__1_3;
			if (_003C_003E9__1_3 == null)
			{
				keySelector = (_003C_003E9__1_3 = delegate(LeaderboardEntry e)
				{
					//IL_0038: Expected I4, but got O
					if (e == null)
					{
						NullReferenceException ex = new NullReferenceException();
						return (int)ex;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [e @ rdx (Assets.Scripts.Steam.LeaderboardEntry)+1C]");
					return 0;
				});
			}
			IOrderedEnumerable<LeaderboardEntry> source = Enumerable.OrderByDescending(g, keySelector);
			return (LeaderboardEntry)Enumerable.First((IEnumerable<object>)source);
		}

		internal int _003CGetEntriesKills_003Eb__1_3(LeaderboardEntry e)
		{
			//IL_0038: Expected I4, but got O
			if (e != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [e @ rdx (Assets.Scripts.Steam.LeaderboardEntry)+1C]");
				return 0;
			}
			NullReferenceException ex = new NullReferenceException();
			return (int)ex;
		}

		internal unsafe int _003CGetEntriesKills_003Eb__1_2(LeaderboardEntry a, LeaderboardEntry b)
		{
			//IL_0074: Expected I4, but got O
			//IL_0043: Unknown result type (might be due to invalid IL or missing references)
			//IL_0048: Expected I4, but got Unknown
			if (b != null && a != null)
			{
				int num = b + 28;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [a @ rdx (Assets.Scripts.Steam.LeaderboardEntry)+1C]");
				return ((int*)num)->CompareTo(0);
			}
			NullReferenceException ex = new NullReferenceException();
			return (int)ex;
		}

		internal unsafe int _003CGetFriendsEntries_003Eb__2_0(LeaderboardEntry a, LeaderboardEntry b)
		{
			//IL_0074: Expected I4, but got O
			//IL_0043: Unknown result type (might be due to invalid IL or missing references)
			//IL_0048: Expected I4, but got Unknown
			if (b != null && a != null)
			{
				int num = b + 28;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [a @ rdx (Assets.Scripts.Steam.LeaderboardEntry)+1C]");
				return ((int*)num)->CompareTo(0);
			}
			NullReferenceException ex = new NullReferenceException();
			return (int)ex;
		}
	}

	public unsafe static List<LeaderboardEntry> GetEntriesKills(bool isGlobal, bool isWeekly, int numToShow)
	{
		if (isWeekly)
		{
		}
		SteamLeaderboardNew leaderboardKillsAllTime = SteamLeaderboardsManagerNew.leaderboardKillsAllTime;
		List<LeaderboardEntry> list;
		if (isGlobal)
		{
			if (SteamLeaderboardsManagerNew.leaderboardKillsAllTime != null)
			{
				list = GetEntriesKills(leaderboardKillsAllTime.globalEntries, leaderboardKillsAllTime.friendsEntries, numToShow);
				goto IL_01ef;
			}
		}
		else
		{
			list = new List<LeaderboardEntry>();
			if (SteamLeaderboardsManagerNew.leaderboardKillsAllTime != null)
			{
				if (numToShow <= 0)
				{
					goto IL_01ef;
				}
				List<object> friendsEntries = (List<object>)(object)leaderboardKillsAllTime.friendsEntries;
				int num = 0;
				while (true)
				{
					Comparison<object> comparison = (Comparison<object>)_003C_003Ec._003C_003E9__2_0;
					if (_003C_003Ec._003C_003E9__2_0 == null)
					{
						comparison = (Comparison<object>)(_003C_003Ec._003C_003E9__2_0 = delegate(LeaderboardEntry a, LeaderboardEntry b)
						{
							//IL_0074: Expected I4, but got O
							//IL_0043: Unknown result type (might be due to invalid IL or missing references)
							//IL_0048: Expected I4, but got Unknown
							if (b == null || a == null)
							{
								NullReferenceException ex = new NullReferenceException();
								return (int)ex;
							}
							int num2 = b + 28;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [a @ rdx (Assets.Scripts.Steam.LeaderboardEntry)+1C]");
							return ((int*)num2)->CompareTo(0);
						});
					}
					if (leaderboardKillsAllTime.friendsEntries == null)
					{
						break;
					}
					((List<object>)(object)leaderboardKillsAllTime.friendsEntries).Sort(comparison);
					if (num < friendsEntries._size)
					{
						LeaderboardEntry item = leaderboardKillsAllTime.friendsEntries.get_Item(num);
						if (list == null)
						{
							break;
						}
						list.Add(item);
						num++;
						if (num < numToShow)
						{
							continue;
						}
					}
					goto IL_01ef;
				}
			}
		}
		return (List<LeaderboardEntry>)(object)new NullReferenceException();
		IL_01ef:
		return list;
	}

	private unsafe static List<LeaderboardEntry> GetEntriesKills(List<LeaderboardEntry> globalEntries, List<LeaderboardEntry> friendsEntries, int numToShow)
	{
		//IL_03b4: Expected I, but got O
		//IL_040e: Expected I, but got O
		//IL_0468: Expected I, but got O
		//IL_00f5: Expected I4, but got O
		//IL_026f: Expected I4, but got O
		//IL_0142: Expected I4, but got O
		//IL_018d: Expected I4, but got O
		//IL_02fa: Unknown result type (might be due to invalid IL or missing references)
		//IL_02ff: Expected O, but got Unknown
		//IL_01e7: Expected I8, but got O
		List<LeaderboardEntry> list = new List<LeaderboardEntry>();
		List<LeaderboardEntry> list2 = new List<LeaderboardEntry>();
		list2._002Ector();
		if (list2 != null)
		{
			((List<object>)(object)list2).AddRange((IEnumerable<object>)globalEntries);
			((List<object>)(object)list2).AddRange((IEnumerable<object>)friendsEntries);
			HashSet<LeaderboardEntry> hashSet = (HashSet<LeaderboardEntry>)(object)new HashSet<object>(friendsEntries);
			Func<LeaderboardEntry, CSteamID> keySelector = _003C_003Ec._003C_003E9__1_0;
			nint num = default(nint);
			if (_003C_003Ec._003C_003E9__1_0 == null)
			{
				Func<LeaderboardEntry, CSteamID> func = (_003C_003Ec._003C_003E9__1_0 = (LeaderboardEntry e) => (CSteamID)(((object?)e?.leaderboardEntry) ?? ((object)new NullReferenceException())));
				num = unchecked((nint)null);
				keySelector = func;
			}
			IEnumerable<IGrouping<CSteamID, LeaderboardEntry>> source = Enumerable.GroupBy(list2, keySelector);
			Func<IGrouping<CSteamID, LeaderboardEntry>, LeaderboardEntry> selector = _003C_003Ec._003C_003E9__1_1;
			if (_003C_003Ec._003C_003E9__1_1 == null)
			{
				Func<IGrouping<CSteamID, LeaderboardEntry>, LeaderboardEntry> func2 = (_003C_003Ec._003C_003E9__1_1 = delegate(IGrouping<CSteamID, LeaderboardEntry> g)
				{
					Func<LeaderboardEntry, int> keySelector2 = _003C_003Ec._003C_003E9__1_3;
					if (_003C_003Ec._003C_003E9__1_3 == null)
					{
						keySelector2 = (_003C_003Ec._003C_003E9__1_3 = delegate(LeaderboardEntry e)
						{
							//IL_0038: Expected I4, but got O
							if (e == null)
							{
								NullReferenceException ex = new NullReferenceException();
								return (int)ex;
							}
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [e @ rdx (Assets.Scripts.Steam.LeaderboardEntry)+1C]");
							return 0;
						});
					}
					IOrderedEnumerable<LeaderboardEntry> source3 = Enumerable.OrderByDescending(g, keySelector2);
					return (LeaderboardEntry)Enumerable.First((IEnumerable<object>)source3);
				});
				num = unchecked((nint)null);
				selector = func2;
			}
			IEnumerable<LeaderboardEntry> source2 = Enumerable.Select(source, selector);
			List<object> list3 = Enumerable.ToList((IEnumerable<object>)source2);
			Comparison<object> comparison = (Comparison<object>)_003C_003Ec._003C_003E9__1_2;
			if (_003C_003Ec._003C_003E9__1_2 == null)
			{
				Comparison<LeaderboardEntry> comparison2 = (_003C_003Ec._003C_003E9__1_2 = delegate(LeaderboardEntry a, LeaderboardEntry b)
				{
					//IL_0074: Expected I4, but got O
					//IL_0043: Unknown result type (might be due to invalid IL or missing references)
					//IL_0048: Expected I4, but got Unknown
					if (b == null || a == null)
					{
						NullReferenceException ex = new NullReferenceException();
						return (int)ex;
					}
					int num5 = b + 28;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [a @ rdx (Assets.Scripts.Steam.LeaderboardEntry)+1C]");
					return ((int*)num5)->CompareTo(0);
				});
				num = unchecked((nint)null);
				comparison = (Comparison<object>)comparison2;
			}
			if (list3 != null)
			{
				list3.Sort(comparison);
				string text = null;
				string text2 = null;
				LeaderboardEntry_t leaderboardEntry_t = default(LeaderboardEntry_t);
				int num2 = default(int);
				string text3 = default(string);
				LeaderboardEntry_t leaderboardEntry_t2 = default(LeaderboardEntry_t);
				while (true)
				{
					string text4;
					LeaderboardEntry_t leaderboardEntry_t3;
					int num3;
					LeaderboardEntry_t leaderboardEntry_t4;
					nint num4;
					Comparison<object> comparison3;
					if ((nint)text < list3._size)
					{
						LeaderboardEntry item = ((List<LeaderboardEntry>)(object)list3).get_Item((int)text2);
						if (hashSet == null)
						{
							break;
						}
						if (!((HashSet<object>)(object)hashSet).Contains((object)item))
						{
							LeaderboardEntry leaderboardEntry = ((List<LeaderboardEntry>)(object)list3).get_Item((int)text2);
							if (leaderboardEntry == null)
							{
								break;
							}
							leaderboardEntry_t = leaderboardEntry.leaderboardEntry;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v123 @ rax_v36 (Assets.Scripts.Steam.LeaderboardEntry)+1C]");
							num2 = 0;
							LeaderboardEntry leaderboardEntry2 = ((List<LeaderboardEntry>)(object)list3).get_Item((int)text2);
							if (leaderboardEntry2 == null)
							{
								break;
							}
							comparison = (Comparison<object>)(object)leaderboardEntry2.details;
							LeaderboardEntry_t leaderboardEntry3 = leaderboardEntry.leaderboardEntry;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v123 @ rax_v36 (Assets.Scripts.Steam.LeaderboardEntry)+1C]");
							bool flag = Assets.Scripts.Steam.Leaderboards.CanShowScore((ulong)(long)leaderboardEntry3, 0, leaderboardEntry2.details, out var s);
							bool flag2 = !flag;
							text3 = null;
							leaderboardEntry_t2 = leaderboardEntry.leaderboardEntry;
							num = (nint)(&s);
							text4 = null;
							leaderboardEntry_t3 = leaderboardEntry.leaderboardEntry;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v123 @ rax_v36 (Assets.Scripts.Steam.LeaderboardEntry)+1C]");
							num3 = 0;
							leaderboardEntry_t4 = leaderboardEntry.leaderboardEntry;
							num4 = (nint)(&s);
							comparison3 = (Comparison<object>)(object)leaderboardEntry2.details;
							if (flag2)
							{
								goto IL_02f1;
							}
						}
						LeaderboardEntry item2 = ((List<LeaderboardEntry>)(object)list3).get_Item((int)text2);
						if (list == null)
						{
							break;
						}
						list.Add(item2);
						bool flag3 = list._size >= numToShow;
						text4 = text3;
						leaderboardEntry_t3 = leaderboardEntry_t2;
						num3 = num2;
						leaderboardEntry_t4 = leaderboardEntry_t;
						num4 = num;
						comparison3 = comparison;
						if (!flag3)
						{
							goto IL_02f1;
						}
					}
					return list;
					IL_02f1:
					text2++;
					text3 = text4;
					leaderboardEntry_t2 = leaderboardEntry_t3;
					num2 = num3;
					leaderboardEntry_t = leaderboardEntry_t4;
					num = num4;
					comparison = comparison3;
					text = text2;
				}
			}
		}
		return (List<LeaderboardEntry>)(object)new NullReferenceException();
	}

	private unsafe static List<LeaderboardEntry> GetFriendsEntries(SteamLeaderboardNew leaderboard, int numToShow)
	{
		List<LeaderboardEntry> list = new List<LeaderboardEntry>();
		if (leaderboard != null)
		{
			if (numToShow <= 0)
			{
				goto IL_0107;
			}
			List<object> friendsEntries = (List<object>)(object)leaderboard.friendsEntries;
			int num = 0;
			while (true)
			{
				Comparison<object> comparison = (Comparison<object>)_003C_003Ec._003C_003E9__2_0;
				if (_003C_003Ec._003C_003E9__2_0 == null)
				{
					comparison = (Comparison<object>)(_003C_003Ec._003C_003E9__2_0 = delegate(LeaderboardEntry a, LeaderboardEntry b)
					{
						//IL_0074: Expected I4, but got O
						//IL_0043: Unknown result type (might be due to invalid IL or missing references)
						//IL_0048: Expected I4, but got Unknown
						if (b == null || a == null)
						{
							NullReferenceException ex = new NullReferenceException();
							return (int)ex;
						}
						int num2 = b + 28;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [a @ rdx (Assets.Scripts.Steam.LeaderboardEntry)+1C]");
						return ((int*)num2)->CompareTo(0);
					});
				}
				if (leaderboard.friendsEntries == null)
				{
					break;
				}
				((List<object>)(object)leaderboard.friendsEntries).Sort(comparison);
				if (num < friendsEntries._size)
				{
					LeaderboardEntry item = leaderboard.friendsEntries.get_Item(num);
					if (list == null)
					{
						break;
					}
					list.Add(item);
					num++;
					if (num < numToShow)
					{
						continue;
					}
				}
				goto IL_0107;
			}
		}
		return (List<LeaderboardEntry>)(object)new NullReferenceException();
		IL_0107:
		return list;
	}
}
