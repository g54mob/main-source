using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Assets.Scripts.Menu.Shop.Leaderboards;
using Assets.Scripts.Steam;
using Assets.Scripts.Steam.LeaderboardsNew;
using Cpp2ILInjected;
using Steamworks;
using TMPro;
using UnityEngine;

public class LeaderboardUiNew : MonoBehaviour
{
	public GameObject lbPrefab;

	private List<LeaderboardEntryUi> leaderboardEntries;

	public GameObject buffering;

	public ButtonNavigationSelectionOnly leaderboardTypeButtons;

	private static int lastSelectedTypeIndex;

	public TextMeshProUGUI t_reset;

	private SteamLeaderboardNew leaderboard = SteamLeaderboardsManagerNew.leaderboardKillsWeekly;

	private int numEntriesToShow = 10;

	private bool isWeekly = true;

	private bool isGlobal;

	private void Awake()
	{
		//IL_02cd: Expected I, but got O
		//IL_02de: Expected O, but got I4
		//IL_008a: Expected I, but got O
		//IL_009b: Expected O, but got I4
		//IL_035b: Expected I, but got O
		//IL_036c: Expected O, but got I4
		//IL_0382: Expected I, but got O
		//IL_0183: Expected I, but got O
		//IL_0194: Expected O, but got I4
		//IL_03a8: Expected I, but got O
		//IL_03b9: Expected O, but got I4
		//IL_022f: Expected I, but got O
		//IL_0240: Expected O, but got I4
		//IL_028f: Expected I, but got O
		//IL_02a0: Expected O, but got I4
		Action<SteamLeaderboardNew> b = OnLeaderboardReady;
		Delegate obj = Delegate.Combine(SteamLeaderboardNew.A_LeaderboardReady, b);
		nint num;
		Delegate obj2;
		object obj3;
		Delegate obj4;
		nint num2;
		if ((object)obj == null)
		{
			SteamLeaderboardNew.A_LeaderboardReady = (Action<SteamLeaderboardNew>)obj;
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			Action<SteamLeaderboardNew> action = default(Action<SteamLeaderboardNew>);
			if (action == null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
				num = (nint)typeof(Action<SteamLeaderboardNew>);
				obj2 = obj;
				obj3 = 0;
				obj4 = null;
				goto IL_03fc;
			}
			SteamLeaderboardNew.A_LeaderboardReady = action;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			object obj5 = default(object);
			bool flag = obj5 == null;
			num2 = (nint)typeof(Action<SteamLeaderboardNew>);
			obj2 = obj;
			obj3 = 0;
			obj4 = null;
			if (flag)
			{
				goto IL_0310;
			}
		}
		Action action2 = Refresh;
		Delegate obj6 = Delegate.Combine(SteamLeaderboardsManagerNew.A_CheatersUpdated, action2);
		NullReferenceException typeFromHandle;
		if ((object)obj6 == null)
		{
			SteamLeaderboardsManagerNew.A_CheatersUpdated = null;
		}
		else
		{
			bool flag2 = (object)obj6.GetType() != typeof(Action);
			Delegate obj7 = null;
			if (!flag2)
			{
				obj7 = obj6;
			}
			bool flag3 = (object)obj7 == null;
			num2 = (nint)SteamLeaderboardsManagerNew.A_CheatersUpdated;
			obj2 = action2;
			obj3 = 0;
			obj4 = obj6;
			nint num3 = (nint)typeof(Action);
			if (flag3)
			{
				goto IL_0414;
			}
			SteamLeaderboardsManagerNew.A_CheatersUpdated = (Action)obj7;
			bool flag4 = (object)obj6.GetType() != typeof(Action);
			Delegate obj8 = null;
			if (!flag4)
			{
				obj8 = obj6;
			}
			bool flag5 = (object)obj8 == null;
			num = (nint)SteamLeaderboardsManagerNew.A_CheatersUpdated;
			obj2 = action2;
			obj3 = 0;
			obj4 = obj6;
			typeFromHandle = (NullReferenceException)(object)typeof(Action);
			if (flag5)
			{
				goto IL_0424;
			}
		}
		ButtonNavigationSelectionOnly buttonNavigationSelectionOnly = leaderboardTypeButtons;
		bool flag6 = (object)leaderboardTypeButtons == null;
		num = (nint)SteamLeaderboardsManagerNew.A_CheatersUpdated;
		obj2 = action2;
		obj3 = 0;
		obj4 = obj6;
		if (flag6)
		{
			goto IL_03dd;
		}
		Action<int> b2 = OnLeaderboardTypeSelected;
		Delegate obj9 = Delegate.Combine(buttonNavigationSelectionOnly.A_ButtonSelected, b2);
		if ((object)obj9 == null)
		{
			buttonNavigationSelectionOnly.A_ButtonSelected = (Action<int>)obj9;
			return;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
		Action<int> action3 = default(Action<int>);
		bool flag7 = action3 == null;
		num = (nint)typeof(Action<int>);
		obj2 = obj9;
		obj3 = 0;
		obj4 = null;
		Delegate obj10 = obj9;
		if (flag7)
		{
			goto IL_03ec;
		}
		buttonNavigationSelectionOnly.A_ButtonSelected = action3;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
		object obj11 = default(object);
		bool flag8 = obj11 == null;
		num = (nint)typeof(Action<int>);
		obj2 = obj9;
		obj3 = 0;
		obj4 = null;
		if (!flag8)
		{
			return;
		}
		goto IL_03fc;
		IL_03fc:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		obj10 = obj2;
		goto IL_03ec;
		IL_03ec:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_03dd;
		IL_03dd:
		typeFromHandle = new NullReferenceException();
		goto IL_0424;
		IL_0310:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		return;
		IL_0414:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_0310;
		IL_0424:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		num2 = num;
		goto IL_0414;
	}

	private void OnDestroy()
	{
		//IL_02cd: Expected I, but got O
		//IL_02de: Expected O, but got I4
		//IL_008a: Expected I, but got O
		//IL_009b: Expected O, but got I4
		//IL_035b: Expected I, but got O
		//IL_036c: Expected O, but got I4
		//IL_0382: Expected I, but got O
		//IL_0183: Expected I, but got O
		//IL_0194: Expected O, but got I4
		//IL_03a8: Expected I, but got O
		//IL_03b9: Expected O, but got I4
		//IL_022f: Expected I, but got O
		//IL_0240: Expected O, but got I4
		//IL_028f: Expected I, but got O
		//IL_02a0: Expected O, but got I4
		Action<SteamLeaderboardNew> value = OnLeaderboardReady;
		Delegate obj = Delegate.Remove(SteamLeaderboardNew.A_LeaderboardReady, value);
		nint num;
		Delegate obj2;
		object obj3;
		Delegate obj4;
		nint num2;
		if ((object)obj == null)
		{
			SteamLeaderboardNew.A_LeaderboardReady = (Action<SteamLeaderboardNew>)obj;
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			Action<SteamLeaderboardNew> action = default(Action<SteamLeaderboardNew>);
			if (action == null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
				num = (nint)typeof(Action<SteamLeaderboardNew>);
				obj2 = obj;
				obj3 = 0;
				obj4 = null;
				goto IL_03fc;
			}
			SteamLeaderboardNew.A_LeaderboardReady = action;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			object obj5 = default(object);
			bool flag = obj5 == null;
			num2 = (nint)typeof(Action<SteamLeaderboardNew>);
			obj2 = obj;
			obj3 = 0;
			obj4 = null;
			if (flag)
			{
				goto IL_0310;
			}
		}
		Action action2 = Refresh;
		Delegate obj6 = Delegate.Remove(SteamLeaderboardsManagerNew.A_CheatersUpdated, action2);
		NullReferenceException typeFromHandle;
		if ((object)obj6 == null)
		{
			SteamLeaderboardsManagerNew.A_CheatersUpdated = null;
		}
		else
		{
			bool flag2 = (object)obj6.GetType() != typeof(Action);
			Delegate obj7 = null;
			if (!flag2)
			{
				obj7 = obj6;
			}
			bool flag3 = (object)obj7 == null;
			num2 = (nint)SteamLeaderboardsManagerNew.A_CheatersUpdated;
			obj2 = action2;
			obj3 = 0;
			obj4 = obj6;
			nint num3 = (nint)typeof(Action);
			if (flag3)
			{
				goto IL_0414;
			}
			SteamLeaderboardsManagerNew.A_CheatersUpdated = (Action)obj7;
			bool flag4 = (object)obj6.GetType() != typeof(Action);
			Delegate obj8 = null;
			if (!flag4)
			{
				obj8 = obj6;
			}
			bool flag5 = (object)obj8 == null;
			num = (nint)SteamLeaderboardsManagerNew.A_CheatersUpdated;
			obj2 = action2;
			obj3 = 0;
			obj4 = obj6;
			typeFromHandle = (NullReferenceException)(object)typeof(Action);
			if (flag5)
			{
				goto IL_0424;
			}
		}
		ButtonNavigationSelectionOnly buttonNavigationSelectionOnly = leaderboardTypeButtons;
		bool flag6 = (object)leaderboardTypeButtons == null;
		num = (nint)SteamLeaderboardsManagerNew.A_CheatersUpdated;
		obj2 = action2;
		obj3 = 0;
		obj4 = obj6;
		if (flag6)
		{
			goto IL_03dd;
		}
		Action<int> value2 = OnLeaderboardTypeSelected;
		Delegate obj9 = Delegate.Remove(buttonNavigationSelectionOnly.A_ButtonSelected, value2);
		if ((object)obj9 == null)
		{
			buttonNavigationSelectionOnly.A_ButtonSelected = (Action<int>)obj9;
			return;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
		Action<int> action3 = default(Action<int>);
		bool flag7 = action3 == null;
		num = (nint)typeof(Action<int>);
		obj2 = obj9;
		obj3 = 0;
		obj4 = null;
		Delegate obj10 = obj9;
		if (flag7)
		{
			goto IL_03ec;
		}
		buttonNavigationSelectionOnly.A_ButtonSelected = action3;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
		object obj11 = default(object);
		bool flag8 = obj11 == null;
		num = (nint)typeof(Action<int>);
		obj2 = obj9;
		obj3 = 0;
		obj4 = null;
		if (!flag8)
		{
			return;
		}
		goto IL_03fc;
		IL_03fc:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		obj10 = obj2;
		goto IL_03ec;
		IL_03ec:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_03dd;
		IL_03dd:
		typeFromHandle = new NullReferenceException();
		goto IL_0424;
		IL_0310:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		return;
		IL_0414:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_0310;
		IL_0424:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		num2 = num;
		goto IL_0414;
	}

	private unsafe void TryInit()
	{
		//IL_0094: Expected O, but got I4
		//IL_00af: Expected O, but got I4
		//IL_02a3: Expected O, but got I4
		//IL_02be: Unknown result type (might be due to invalid IL or missing references)
		//IL_02c3: Expected O, but got Unknown
		//IL_02d1: Unknown result type (might be due to invalid IL or missing references)
		//IL_02d6: Expected O, but got Unknown
		//IL_02e6: Expected O, but got I4
		if (leaderboardEntries != null)
		{
			return;
		}
		List<LeaderboardEntryUi> list = new List<LeaderboardEntryUi>();
		leaderboardEntries = list;
		GameObject gameObject = lbPrefab;
		if ((object)lbPrefab != null)
		{
			LeaderboardEntryUi component = lbPrefab.GetComponent<LeaderboardEntryUi>();
			if (leaderboardEntries != null)
			{
				leaderboardEntries.Add(component);
				object obj = numEntriesToShow - 1;
				bool flag = (nint)obj <= 0;
				object obj2 = 0;
				gameObject = (GameObject)(object)leaderboardEntries;
				if (flag)
				{
					goto IL_0302;
				}
				while (true)
				{
					gameObject = lbPrefab;
					if ((object)lbPrefab == null)
					{
						break;
					}
					List<object> list2 = (List<object>)(object)leaderboardEntries;
					Transform transform = lbPrefab.transform;
					if ((object)transform == null)
					{
						break;
					}
					Transform parent = transform.parent;
					GameObject gameObject2 = UnityEngine.Object.Instantiate(lbPrefab, parent);
					if ((object)gameObject2 == null)
					{
						break;
					}
					LeaderboardEntryUi component2 = gameObject2.GetComponent<LeaderboardEntryUi>();
					bool flag2 = leaderboardEntries == null;
					gameObject = gameObject2;
					if (flag2)
					{
						break;
					}
					int version = list2._version + 1;
					list2._version = version;
					gameObject = (GameObject)(object)list2._items;
					if (list2._items == null)
					{
						break;
					}
					int size = list2._size;
					int size2 = list2._size;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v423 @ rcx_v9 (UnityEngine.GameObject)+18]");
					if ((nint)size2 >= (nint)0)
					{
						((List<object>)(object)leaderboardEntries).AddWithResize((object)component2);
						gameObject = (GameObject)(object)leaderboardEntries;
					}
					else
					{
						int size3 = list2._size + 1;
						list2._size = size3;
						int size4 = list2._size;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v423 @ rcx_v9 (UnityEngine.GameObject)+18]");
						if ((nint)size4 >= (nint)0)
						{
							throw new IndexOutOfRangeException();
						}
						object obj3 = list2._size * 8;
						object obj4 = (object)list2._items + obj3;
						gameObject = (GameObject)(obj4 + 32);
					}
					obj2++;
					object obj5 = numEntriesToShow - 1;
					if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj2) < System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj5))
					{
						continue;
					}
					goto IL_0302;
				}
			}
		}
		goto IL_04bd;
		IL_04b1:
		Refresh();
		return;
		IL_0557:
		GameObject gameObject3;
		bool active;
		gameObject3.SetActive(active);
		goto IL_04b1;
		IL_0302:
		if (leaderboardEntries != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @181126F30");
			List<object>.Enumerator enumerator = default(List<object>.Enumerator);
			Component component3 = default(Component);
			while (enumerator.MoveNext())
			{
				if ((object)component3 != null)
				{
					GameObject gameObject4 = component3.gameObject;
					if ((object)gameObject4 != null)
					{
						gameObject4.SetActive(value: false);
						continue;
					}
					throw new NullReferenceException();
				}
				throw new NullReferenceException();
			}
			((List<LeaderboardEntryUi>.Enumerator*)(&enumerator))->Dispose();
			if ((object)buffering != null)
			{
				buffering.SetActive(value: true);
				if (lastSelectedTypeIndex != 0)
				{
					if (lastSelectedTypeIndex != 1)
					{
						goto IL_04b1;
					}
					isWeekly = false;
					if ((object)t_reset != null)
					{
						gameObject3 = t_reset.gameObject;
						if ((object)gameObject3 != null)
						{
							active = false;
							goto IL_0557;
						}
					}
				}
				else
				{
					isWeekly = true;
					if ((object)t_reset != null)
					{
						gameObject3 = t_reset.gameObject;
						if ((object)gameObject3 != null)
						{
							active = true;
							goto IL_0557;
						}
					}
				}
			}
		}
		goto IL_04bd;
		IL_04bd:
		throw new NullReferenceException();
	}

	private void Start()
	{
		TryInit();
	}

	private void OnLeaderboardReady(SteamLeaderboardNew leaderboardReady)
	{
		if (leaderboardReady == leaderboard)
		{
			Refresh();
		}
	}

	private unsafe void Refresh()
	{
		//IL_01d2: Expected I8, but got O
		//IL_024d: Expected O, but got I4
		//IL_025f: Expected I4, but got O
		//IL_0292: Expected I4, but got O
		//IL_02ca: Expected I4, but got O
		//IL_0552: Unknown result type (might be due to invalid IL or missing references)
		//IL_0557: Expected O, but got Unknown
		//IL_031e: Expected O, but got I4
		//IL_0353: Expected O, but got I4
		//IL_03f0: Expected I4, but got O
		//IL_0436: Expected O, but got I4
		TryInit();
		if (leaderboardEntries != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @181126F30");
			List<object>.Enumerator enumerator = default(List<object>.Enumerator);
			Component component = default(Component);
			while (enumerator.MoveNext())
			{
				if ((object)component != null)
				{
					GameObject gameObject = component.gameObject;
					if ((object)gameObject != null)
					{
						gameObject.SetActive(value: false);
						continue;
					}
					throw new NullReferenceException();
				}
				throw new NullReferenceException();
			}
			((List<LeaderboardEntryUi>.Enumerator*)(&enumerator))->Dispose();
			if (leaderboard == null || !leaderboard.IsReadyToDisplay())
			{
				return;
			}
			List<LeaderboardEntry> entriesKills = LeaderboardUtility.GetEntriesKills(isGlobal, isWeekly, numEntriesToShow);
			SteamLeaderboardNew steamLeaderboardNew = leaderboard;
			if (leaderboard != null && entriesKills != null)
			{
				LeaderboardEntry localEntry = steamLeaderboardNew.localEntry;
				LeaderboardEntry leaderboardEntry = entriesKills.get_Item(0);
				if (leaderboardEntry != null)
				{
					LeaderboardEntry leaderboardEntry2 = entriesKills.get_Item(0);
					if (leaderboardEntry2 != null)
					{
						LeaderboardEntry leaderboardEntry3 = entriesKills.get_Item(0);
						if (leaderboardEntry3 != null)
						{
							LeaderboardEntry_t leaderboardEntry4 = leaderboardEntry.leaderboardEntry;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v141 @ rax_v18 (Assets.Scripts.Steam.LeaderboardEntry)+1C]");
							bool flag = Leaderboards.CanShowScore((ulong)(long)leaderboardEntry4, 0, leaderboardEntry3.details, out var _);
							LeaderboardEntry leaderboardEntry5 = entriesKills.get_Item(0);
							if (leaderboardEntry5 != null)
							{
								string friendPersonaName = SteamFriends.GetFriendPersonaName((CSteamID)leaderboardEntry5.leaderboardEntry);
								if (numEntriesToShow > 0)
								{
									string text = null;
									object obj = 0;
									while ((nint)text < entriesKills._size)
									{
										LeaderboardEntry leaderboardEntry6 = entriesKills.get_Item((int)text);
										if (leaderboardEntries != null)
										{
											LeaderboardEntryUi leaderboardEntryUi = leaderboardEntries.get_Item((int)text);
											if ((object)leaderboardEntryUi != null)
											{
												leaderboardEntryUi.Set(leaderboardEntry6, (int)text);
												if (leaderboardEntry6 != null)
												{
													CSteamID steamID = SteamUser.GetSteamID();
													if ((object)leaderboardEntry6.leaderboardEntry == (object)steamID)
													{
														obj = 1;
													}
													if (steamLeaderboardNew.localEntry != null && obj == null)
													{
														object obj2 = numEntriesToShow - 1;
														if (text == obj2)
														{
															SteamLeaderboardNew steamLeaderboardNew2 = leaderboard;
															if (leaderboard != null)
															{
																int rankIndex;
																if ((isGlobal ? 1 : 0) != (nint)obj)
																{
																	Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v82 @ r13_v7 (Assets.Scripts.Steam.LeaderboardEntry)+18]");
																	rankIndex = 0;
																}
																else
																{
																	rankIndex = steamLeaderboardNew2.localEntryRankFriends;
																}
																if (leaderboardEntries != null)
																{
																	LeaderboardEntryUi leaderboardEntryUi2 = leaderboardEntries.get_Item((int)text);
																	if ((object)leaderboardEntryUi2 != null)
																	{
																		leaderboardEntryUi2.Set(steamLeaderboardNew.localEntry, rankIndex);
																		obj = 1;
																		goto IL_0549;
																	}
																}
															}
															goto IL_0495;
														}
													}
													goto IL_0549;
												}
											}
										}
										goto IL_0495;
										IL_0549:
										text++;
										if ((nint)text >= numEntriesToShow)
										{
											break;
										}
									}
								}
								if ((object)buffering != null)
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1815336B0");
									GameObject gameObject2 = default(GameObject);
									if ((object)gameObject2 != null)
									{
										gameObject2.SetActive(value: false);
										return;
									}
								}
							}
						}
					}
				}
			}
		}
		goto IL_0495;
		IL_0495:
		throw new NullReferenceException();
	}

	private void OnLeaderboardTypeSelected(int index)
	{
		GameObject gameObject;
		bool active;
		if (index != 0)
		{
			if (index != 1)
			{
				goto IL_00a1;
			}
			isWeekly = false;
			gameObject = t_reset.gameObject;
			active = false;
		}
		else
		{
			isWeekly = true;
			gameObject = t_reset.gameObject;
			active = true;
		}
		gameObject.SetActive(active);
		goto IL_00a1;
		IL_00a1:
		Cpp2ILHelpers.NoteDecompilerIssue("Invalid instruction: 90 Invalid \"Jump target not found in method: 0x18056C130\"");
		throw new NullReferenceException();
	}
}
