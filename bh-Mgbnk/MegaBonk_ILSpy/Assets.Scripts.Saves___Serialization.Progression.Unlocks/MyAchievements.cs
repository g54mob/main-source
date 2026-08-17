using System;
using System.Collections.Generic;
using System.Linq;
using Assets.Scripts._Data.Progression;
using Assets.Scripts._Data.ShopItems;
using Assets.Scripts.Saves___Serialization.Progression.Achievements;
using Assets.Scripts.Saves___Serialization.Progression.Stats;
using Assets.Scripts.Saves___Serialization.SaveFiles;
using Assets.Scripts.Utility;
using Cpp2ILInjected;
using Steamworks;
using UnityEngine;

namespace Assets.Scripts.Saves___Serialization.Progression.Unlocks;

public static class MyAchievements
{
	[Serializable]
	private sealed class _003C_003Ec
	{
		public static readonly _003C_003Ec _003C_003E9;

		public static Func<MyAchievement, bool> _003C_003E9__45_1;

		public static Func<MyAchievement, bool> _003C_003E9__45_2;

		static _003C_003Ec()
		{
			_003C_003Ec obj = new _003C_003Ec();
			_003C_003E9 = obj;
		}

		internal bool _003CGetAchievementTypeProgress_003Eb__45_1(MyAchievement a)
		{
			//IL_002f: Expected I4, but got O
			if ((object)a != null)
			{
				return IsUnlocked(a.internalName);
			}
			NullReferenceException ex = new NullReferenceException();
			return (byte)(int)ex != 0;
		}

		internal bool _003CGetAchievementTypeProgress_003Eb__45_2(MyAchievement a)
		{
			//IL_00ed: Expected I4, but got O
			if ((object)a != null)
			{
				bool flag = IsUnlocked(a.internalName);
				if (!flag)
				{
					return flag;
				}
				SaveManager saveManager = SaveManager._003CInstance_003Ek__BackingField;
				if ((object)SaveManager._003CInstance_003Ek__BackingField != null)
				{
					ProgressionSaveFile progression = saveManager.progression;
					if (saveManager.progression != null && progression.claimedAchievements != null)
					{
						bool flag2 = ((HashSet<object>)(object)progression.claimedAchievements).Contains((object)a.internalName);
						return (byte)((flag2 ? 1u : 0u) ^ 1u) != 0;
					}
				}
			}
			NullReferenceException ex = new NullReferenceException();
			return (byte)(int)ex != 0;
		}
	}

	private sealed class _003C_003Ec__DisplayClass45_0
	{
		public EAchievementType achievementType;

		internal bool _003CGetAchievementTypeProgress_003Eb__0(MyAchievement a)
		{
			//IL_008b: Expected I4, but got O
			if ((object)a != null)
			{
				if (a.achievementType == achievementType && a.isEnabled)
				{
					return a.IsVisible();
				}
				return false;
			}
			NullReferenceException ex = new NullReferenceException();
			return (byte)(int)ex != 0;
		}
	}

	public static bool testUnlockEverything = false;

	private static bool hasUnsavedChanges;

	public static Action<MyAchievement> A_Unlocked;

	public static Action<string> A_TryUnlock;

	private static Dictionary<string, List<MyAchievement>> statTrackers;

	private static bool startedTracking;

	public static int fakeCharacters;

	public static int fakeWeapons;

	public static int fakeItems;

	public static int fakeMaps;

	public static int fakeTomes;

	public static int fakeAchievements;

	private static HashSet<MyStat> queuedStatNames;

	private static float statTrackersCooldown;

	private static float nextStatTrackersCheck;

	private static float nextSaveTimeReady;

	private static float saveCooldown;

	public static bool IsTestUnlockEverything()
	{
		return false;
	}

	public static void Init()
	{
		//IL_040a: Expected I, but got O
		//IL_041b: Expected O, but got I4
		//IL_0091: Expected I, but got O
		//IL_00a2: Expected O, but got I4
		//IL_049d: Expected I, but got O
		//IL_04ae: Expected O, but got I4
		//IL_04c4: Expected I, but got O
		//IL_04ea: Expected I, but got O
		//IL_04fb: Expected O, but got I4
		//IL_0511: Expected I, but got O
		//IL_0537: Expected I, but got O
		//IL_0548: Expected O, but got I4
		//IL_055e: Expected I, but got O
		//IL_0248: Expected I, but got O
		//IL_0584: Expected I, but got O
		//IL_0595: Expected O, but got I4
		//IL_05ab: Expected I, but got O
		//IL_05d9: Expected O, but got I4
		//IL_05ef: Expected I, but got O
		//IL_061d: Expected O, but got I4
		//IL_0633: Expected I, but got O
		//IL_0378: Expected I, but got O
		//IL_0389: Expected O, but got I4
		//IL_03cc: Expected I, but got O
		//IL_03dd: Expected O, but got I4
		TryStartStatTracking();
		Action<string, MyStat> b = OnStatUpdated;
		Delegate obj = Delegate.Combine(MyStats.A_StatUpdated, b);
		nint num;
		Delegate obj2;
		object obj3;
		Delegate obj4;
		nint num2;
		if ((object)obj == null)
		{
			MyStats.A_StatUpdated = null;
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			Action<string, MyStat> action = default(Action<string, MyStat>);
			if (action == null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
				num = (nint)typeof(Action<string, MyStat>);
				obj2 = obj;
				obj3 = 0;
				obj4 = null;
				goto IL_0679;
			}
			MyStats.A_StatUpdated = action;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			object obj5 = default(object);
			bool flag = obj5 == null;
			num2 = (nint)typeof(Action<string, MyStat>);
			obj2 = obj;
			obj3 = 0;
			obj4 = null;
			if (flag)
			{
				goto IL_0452;
			}
		}
		Action action2 = OnProgressionSaved;
		Delegate obj6 = Delegate.Combine(SaveManager.A_ProgressionSaved, action2);
		if ((object)obj6 == null)
		{
			SaveManager.A_ProgressionSaved = null;
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
			num2 = (nint)SaveManager.A_ProgressionSaved;
			obj2 = action2;
			obj3 = 0;
			obj4 = obj6;
			nint num3 = (nint)typeof(Action);
			if (flag3)
			{
				goto IL_0689;
			}
			SaveManager.A_ProgressionSaved = (Action)obj7;
			bool flag4 = (object)obj6.GetType() != typeof(Action);
			Delegate obj8 = null;
			if (!flag4)
			{
				obj8 = obj6;
			}
			bool flag5 = (object)obj8 == null;
			num2 = (nint)SaveManager.A_ProgressionSaved;
			obj2 = action2;
			obj3 = 0;
			obj4 = obj6;
			nint num4 = (nint)typeof(Action);
			if (flag5)
			{
				goto IL_0699;
			}
		}
		Action action3 = OnProgressionLoaded;
		Delegate obj9 = Delegate.Combine(SaveManager.A_SavesLoaded, action3);
		if ((object)obj9 == null)
		{
			SaveManager.A_SavesLoaded = null;
		}
		else
		{
			bool flag6 = (object)obj9.GetType() != typeof(Action);
			Delegate obj10 = null;
			if (!flag6)
			{
				obj10 = obj9;
			}
			bool flag7 = (object)obj10 == null;
			num = (nint)SaveManager.A_SavesLoaded;
			obj2 = action3;
			obj3 = 0;
			obj4 = obj9;
			nint num5 = (nint)typeof(Action);
			if (flag7)
			{
				goto IL_06a9;
			}
			SaveManager.A_SavesLoaded = (Action)obj10;
			bool flag8 = (object)obj9.GetType() != typeof(Action);
			Delegate obj11 = null;
			if (!flag8)
			{
				obj11 = obj9;
			}
			bool flag9 = (object)obj11 == null;
			num = (nint)SaveManager.A_SavesLoaded;
			obj2 = action3;
			obj3 = 0;
			obj4 = obj9;
			nint num6 = (nint)typeof(Action);
			if (flag9)
			{
				goto IL_06c1;
			}
		}
		num = (nint)DataManager.A_DataLoaded;
		Action action4 = OnDataLoaded;
		Delegate obj12 = Delegate.Combine(DataManager.A_DataLoaded, action4);
		if ((object)obj12 == null)
		{
			DataManager.A_DataLoaded = null;
		}
		else
		{
			bool flag10 = (object)obj12.GetType() != typeof(Action);
			Delegate obj13 = null;
			if (!flag10)
			{
				obj13 = obj12;
			}
			bool flag11 = (object)obj13 == null;
			obj2 = action4;
			obj3 = 0;
			obj4 = obj12;
			nint num7 = (nint)typeof(Action);
			if (flag11)
			{
				goto IL_06d1;
			}
			DataManager.A_DataLoaded = (Action)obj13;
			bool flag12 = (object)obj12.GetType() != typeof(Action);
			Delegate obj14 = null;
			if (!flag12)
			{
				obj14 = obj12;
			}
			bool flag13 = (object)obj14 == null;
			obj2 = action4;
			obj3 = 0;
			obj4 = obj12;
			nint num8 = (nint)typeof(Action);
			if (flag13)
			{
				goto IL_06e1;
			}
		}
		Action<bool> b2 = OnPause;
		Delegate obj15 = Delegate.Combine(MyTime.A_Pause, b2);
		if ((object)obj15 == null)
		{
			MyTime.A_Pause = null;
			return;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
		Action<bool> action5 = default(Action<bool>);
		bool flag14 = action5 == null;
		num = (nint)typeof(Action<bool>);
		obj2 = obj15;
		obj3 = 0;
		obj4 = null;
		if (flag14)
		{
			goto IL_0669;
		}
		MyTime.A_Pause = action5;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
		object obj16 = default(object);
		bool flag15 = obj16 == null;
		num = (nint)typeof(Action<bool>);
		obj2 = obj15;
		obj3 = 0;
		obj4 = null;
		if (!flag15)
		{
			return;
		}
		goto IL_0679;
		IL_0699:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_0689;
		IL_06c1:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_06a9;
		IL_06a9:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		num2 = num;
		goto IL_0699;
		IL_06d1:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_06c1;
		IL_0669:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_06e1;
		IL_0679:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_0669;
		IL_0689:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_0452;
		IL_0452:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		return;
		IL_06e1:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_06d1;
	}

	public static void Cleanup()
	{
		//IL_0400: Expected I, but got O
		//IL_0411: Expected O, but got I4
		//IL_0087: Expected I, but got O
		//IL_0098: Expected O, but got I4
		//IL_046b: Expected I, but got O
		//IL_047c: Expected O, but got I4
		//IL_0492: Expected I, but got O
		//IL_04b8: Expected I, but got O
		//IL_04c9: Expected O, but got I4
		//IL_04df: Expected I, but got O
		//IL_0505: Expected I, but got O
		//IL_0516: Expected O, but got I4
		//IL_052c: Expected I, but got O
		//IL_023e: Expected I, but got O
		//IL_0552: Expected I, but got O
		//IL_0563: Expected O, but got I4
		//IL_0579: Expected I, but got O
		//IL_05a7: Expected O, but got I4
		//IL_05bd: Expected I, but got O
		//IL_05eb: Expected O, but got I4
		//IL_0601: Expected I, but got O
		//IL_036e: Expected I, but got O
		//IL_037f: Expected O, but got I4
		//IL_03c2: Expected I, but got O
		//IL_03d3: Expected O, but got I4
		Action<string, MyStat> value = OnStatUpdated;
		Delegate obj = Delegate.Remove(MyStats.A_StatUpdated, value);
		nint num;
		Delegate obj2;
		object obj3;
		Delegate obj4;
		nint num2;
		if ((object)obj == null)
		{
			MyStats.A_StatUpdated = null;
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			Action<string, MyStat> action = default(Action<string, MyStat>);
			if (action == null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
				num = (nint)typeof(Action<string, MyStat>);
				obj2 = obj;
				obj3 = 0;
				obj4 = null;
				goto IL_0647;
			}
			MyStats.A_StatUpdated = action;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			object obj5 = default(object);
			bool flag = obj5 == null;
			num2 = (nint)typeof(Action<string, MyStat>);
			obj2 = obj;
			obj3 = 0;
			obj4 = null;
			if (flag)
			{
				goto IL_0420;
			}
		}
		Action action2 = OnProgressionSaved;
		Delegate obj6 = Delegate.Remove(SaveManager.A_ProgressionSaved, action2);
		if ((object)obj6 == null)
		{
			SaveManager.A_ProgressionSaved = null;
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
			num2 = (nint)SaveManager.A_ProgressionSaved;
			obj2 = action2;
			obj3 = 0;
			obj4 = obj6;
			nint num3 = (nint)typeof(Action);
			if (flag3)
			{
				goto IL_067f;
			}
			SaveManager.A_ProgressionSaved = (Action)obj7;
			bool flag4 = (object)obj6.GetType() != typeof(Action);
			Delegate obj8 = null;
			if (!flag4)
			{
				obj8 = obj6;
			}
			bool flag5 = (object)obj8 == null;
			num2 = (nint)SaveManager.A_ProgressionSaved;
			obj2 = action2;
			obj3 = 0;
			obj4 = obj6;
			nint num4 = (nint)typeof(Action);
			if (flag5)
			{
				goto IL_068f;
			}
		}
		Action action3 = OnProgressionLoaded;
		Delegate obj9 = Delegate.Remove(SaveManager.A_SavesLoaded, action3);
		if ((object)obj9 == null)
		{
			SaveManager.A_SavesLoaded = null;
		}
		else
		{
			bool flag6 = (object)obj9.GetType() != typeof(Action);
			Delegate obj10 = null;
			if (!flag6)
			{
				obj10 = obj9;
			}
			bool flag7 = (object)obj10 == null;
			num = (nint)SaveManager.A_SavesLoaded;
			obj2 = action3;
			obj3 = 0;
			obj4 = obj9;
			nint num5 = (nint)typeof(Action);
			if (flag7)
			{
				goto IL_069f;
			}
			SaveManager.A_SavesLoaded = (Action)obj10;
			bool flag8 = (object)obj9.GetType() != typeof(Action);
			Delegate obj11 = null;
			if (!flag8)
			{
				obj11 = obj9;
			}
			bool flag9 = (object)obj11 == null;
			num = (nint)SaveManager.A_SavesLoaded;
			obj2 = action3;
			obj3 = 0;
			obj4 = obj9;
			nint num6 = (nint)typeof(Action);
			if (flag9)
			{
				goto IL_06b7;
			}
		}
		num = (nint)DataManager.A_DataLoaded;
		Action action4 = OnDataLoaded;
		Delegate obj12 = Delegate.Remove(DataManager.A_DataLoaded, action4);
		if ((object)obj12 == null)
		{
			DataManager.A_DataLoaded = null;
		}
		else
		{
			bool flag10 = (object)obj12.GetType() != typeof(Action);
			Delegate obj13 = null;
			if (!flag10)
			{
				obj13 = obj12;
			}
			bool flag11 = (object)obj13 == null;
			obj2 = action4;
			obj3 = 0;
			obj4 = obj12;
			nint num7 = (nint)typeof(Action);
			if (flag11)
			{
				goto IL_06c7;
			}
			DataManager.A_DataLoaded = (Action)obj13;
			bool flag12 = (object)obj12.GetType() != typeof(Action);
			Delegate obj14 = null;
			if (!flag12)
			{
				obj14 = obj12;
			}
			bool flag13 = (object)obj14 == null;
			obj2 = action4;
			obj3 = 0;
			obj4 = obj12;
			nint num8 = (nint)typeof(Action);
			if (flag13)
			{
				goto IL_06d7;
			}
		}
		Action<bool> value2 = OnPause;
		Delegate obj15 = Delegate.Remove(MyTime.A_Pause, value2);
		if ((object)obj15 == null)
		{
			MyTime.A_Pause = null;
			return;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
		Action<bool> action5 = default(Action<bool>);
		bool flag14 = action5 == null;
		num = (nint)typeof(Action<bool>);
		obj2 = obj15;
		obj3 = 0;
		obj4 = null;
		if (flag14)
		{
			goto IL_0637;
		}
		MyTime.A_Pause = action5;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
		object obj16 = default(object);
		bool flag15 = obj16 == null;
		num = (nint)typeof(Action<bool>);
		obj2 = obj15;
		obj3 = 0;
		obj4 = null;
		if (!flag15)
		{
			return;
		}
		goto IL_0647;
		IL_068f:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_067f;
		IL_06b7:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_069f;
		IL_069f:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		num2 = num;
		goto IL_068f;
		IL_06c7:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_06b7;
		IL_0637:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_06d7;
		IL_0647:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_0637;
		IL_067f:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_0420;
		IL_0420:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		return;
		IL_06d7:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_06c7;
	}

	private unsafe static void TryStartStatTracking()
	{
		//IL_00b7: Invalid comparison between F4 and I4
		//IL_0149: Expected O, but got I
		//IL_017b: Expected O, but got I
		//IL_01c1: Expected O, but got I4
		//IL_01e6: Expected O, but got I4
		if (!(DataManager.Instance != null) || !SaveManager.loaded || startedTracking)
		{
			return;
		}
		startedTracking = true;
		DataManager instance = DataManager.Instance;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @181126F30");
		nint num = 0;
		List<object>.Enumerator enumerator = default(List<object>.Enumerator);
		MyAchievement myAchievement = default(MyAchievement);
		object obj = default(object);
		while (true)
		{
			if (enumerator.MoveNext())
			{
				MyAchievement myAchievement2;
				if (!IsUnlocked(myAchievement))
				{
					if (!string.IsNullOrEmpty(myAchievement.statName))
					{
						string statName = myAchievement.statName;
						float stat = MyStats.GetStat(myAchievement.statName);
						if (!(stat < (float)myAchievement.targetValue))
						{
							statName = myAchievement.internalName;
							bool flag = TryUnlock(myAchievement.internalName);
						}
					}
				}
				else
				{
					bool flag2 = (object)myAchievement == null;
					myAchievement2 = myAchievement;
					if (flag2)
					{
						throw new NullReferenceException();
					}
				}
				if (string.IsNullOrEmpty(myAchievement.statName))
				{
					continue;
				}
				((Dictionary<string, List<MyAchievement>>)null).Add((string)null, (List<MyAchievement>)num);
				bool flag3 = obj == null;
				myAchievement2 = null;
				if (!flag3)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v666 @ rax_v42+30]");
					myAchievement2 = (MyAchievement)0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v666 @ rax_v42+30]");
					if ((nint)0 != 0)
					{
						bool flag4 = !myAchievement2.isEnabled;
						myAchievement2 = (MyAchievement)myAchievement2.isEnabled;
						if (!flag4)
						{
							bool flag5 = ((HashSet<object>)myAchievement2.isEnabled).Contains(myAchievement.internalName);
							num = 0;
							if (flag5)
							{
								continue;
							}
							string statName = myAchievement.statName;
							bool flag6 = statTrackers == null;
							myAchievement2 = (MyAchievement)(object)statTrackers;
							if (!flag6)
							{
								if (!statTrackers.ContainsKey(myAchievement.statName))
								{
									List<MyAchievement> value = new List<MyAchievement>();
									if (statTrackers == null)
									{
										break;
									}
									((Dictionary<object, object>)(object)statTrackers).Add((object)myAchievement.statName, (object)value);
								}
								bool flag7 = statTrackers == null;
								myAchievement2 = (MyAchievement)(object)statTrackers;
								if (!flag7)
								{
									List<MyAchievement> list = statTrackers.get_Item(statName);
									bool flag8 = list == null;
									myAchievement2 = (MyAchievement)(object)statTrackers;
									if (!flag8)
									{
										list.Add(myAchievement);
										num = 0;
										continue;
									}
									throw new NullReferenceException();
								}
								throw new NullReferenceException();
							}
							throw new NullReferenceException();
						}
						throw new NullReferenceException();
					}
					throw new NullReferenceException();
				}
				throw new NullReferenceException();
			}
			((List<MyAchievement>.Enumerator*)(&enumerator))->Dispose();
			return;
		}
		throw new NullReferenceException();
	}

	public static bool TryUnlock(string unlockName)
	{
		//IL_0199: Expected I4, but got O
		//IL_0162: Expected O, but got I
		SaveManager saveManager = SaveManager._003CInstance_003Ek__BackingField;
		if ((object)SaveManager._003CInstance_003Ek__BackingField != null)
		{
			ProgressionSaveFile progression = saveManager.progression;
			if (saveManager.progression != null && progression.achievements != null)
			{
				if (((HashSet<object>)(object)progression.achievements).Contains((object)unlockName))
				{
					goto IL_0185;
				}
				if ((object)DataManager.Instance != null)
				{
					MyAchievement achievement = DataManager.Instance.GetAchievement(unlockName);
					if (!(achievement != null))
					{
						goto IL_0185;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1803311C0");
					object obj = default(object);
					if (obj != null)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v128 @ rax_v19+30]");
						if ((nint)0 != 0)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v128 @ rax_v19+30]");
							((ProgressionSaveFile)0).CompleteAchievement(achievement);
							hasUnsavedChanges = true;
							Action<string> a_TryUnlock = A_TryUnlock;
							if (A_TryUnlock != null)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v320 @ r9_v1 (System.Action`1<System.String>)+18] (should have been resolved before IL gen)");
							}
							Action<MyAchievement> a_Unlocked = A_Unlocked;
							if (A_Unlocked != null)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v190 @ r9_v2 (System.Action`1<Assets.Scripts.Saves___Serialization.Progression.Achievements.MyAchievement>)+18] (should have been resolved before IL gen)");
							}
							return true;
						}
					}
				}
			}
		}
		NullReferenceException ex = new NullReferenceException();
		return (byte)(int)ex != 0;
		IL_0185:
		return false;
	}

	private static bool AreAchievementsDisabled()
	{
		return false;
	}

	private static void OnStatUpdated(string statName, MyStat stat)
	{
		if (statTrackers.ContainsKey(statName))
		{
			bool flag = queuedStatNames.Add(stat);
		}
	}

	public unsafe static void Update()
	{
		//IL_00ad: Expected O, but got I
		//IL_039b: Expected O, but got Ref
		//IL_01e8: Expected O, but got I
		//IL_018c: Expected O, but got I
		//IL_0253: Expected O, but got I
		HashSet<MyStat> hashSet = queuedStatNames;
		if (hashSet._count <= 0)
		{
			return;
		}
		float time = Time.time;
		if (!(time > nextStatTrackersCheck))
		{
			return;
		}
		float time2 = Time.time;
		float num = time2 + statTrackersCooldown;
		nextStatTrackersCheck = num;
		List<object> list = Enumerable.ToList((IEnumerable<object>)queuedStatNames);
		queuedStatNames.Clear();
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @181126F30");
		List<object>.Enumerator enumerator = default(List<object>.Enumerator);
		object obj = default(object);
		List<object>.Enumerator enumerator2 = default(List<object>.Enumerator);
		MyAchievement myAchievement = default(MyAchievement);
		while (true)
		{
			if (enumerator.MoveNext())
			{
				List<MyAchievement> list2 = new List<MyAchievement>();
				if (obj == null)
				{
					break;
				}
				if (statTrackers != null)
				{
					Dictionary<string, List<MyAchievement>> dictionary = statTrackers;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v402 @ stack_-A0+10]");
					List<MyAchievement> list3 = dictionary.get_Item((string)0);
					if (list3 != null)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @181126F30");
						while (enumerator2.MoveNext())
						{
							if ((object)myAchievement != null)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v402 @ stack_-A0+18]");
								if ((nint)0 >= (nint)myAchievement.targetValue)
								{
									bool flag = TryUnlock(myAchievement.internalName);
									list2.Add(myAchievement);
								}
								continue;
							}
							throw new NullReferenceException();
						}
						((List<MyAchievement>.Enumerator*)(&enumerator2))->Dispose();
						bool flag2 = list2 == null;
						List<MyAchievement> list4 = (List<MyAchievement>)(&enumerator2);
						if (!flag2)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @181126F30");
							while (enumerator2.MoveNext())
							{
								Dictionary<string, List<MyAchievement>> dictionary2 = statTrackers;
								if (statTrackers != null)
								{
									Dictionary<string, List<MyAchievement>> dictionary3 = statTrackers;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v402 @ stack_-A0+10]");
									List<MyAchievement> list5 = dictionary3.get_Item((string)0);
									if (list5 != null)
									{
										bool flag3 = ((List<object>)(object)list5).Remove((object)myAchievement);
										continue;
									}
									throw new NullReferenceException();
								}
								throw new NullReferenceException();
							}
							((List<MyAchievement>.Enumerator*)(&enumerator2))->Dispose();
							if (statTrackers != null)
							{
								Dictionary<string, List<MyAchievement>> dictionary4 = statTrackers;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v402 @ stack_-A0+10]");
								List<MyAchievement> list6 = dictionary4.get_Item((string)0);
								bool flag4 = list6 == null;
								Dictionary<string, List<MyAchievement>> dictionary2 = statTrackers;
								if (!flag4)
								{
									if (list6._size == 0)
									{
										bool flag5 = statTrackers == null;
										dictionary2 = statTrackers;
										if (flag5)
										{
											throw new NullReferenceException();
										}
										Dictionary<string, List<MyAchievement>> dictionary5 = statTrackers;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v402 @ stack_-A0+10]");
										bool flag6 = ((Dictionary<object, object>)(object)dictionary5).Remove((object)0);
									}
									continue;
								}
								throw new NullReferenceException();
							}
							throw new NullReferenceException();
						}
						throw new NullReferenceException();
					}
					throw new NullReferenceException();
				}
				throw new NullReferenceException();
			}
			((List<MyStat>.Enumerator*)(&enumerator))->Dispose();
			return;
		}
		throw new NullReferenceException();
	}

	public static bool IsAchievementDone(string achName)
	{
		//IL_00b0: Expected I4, but got O
		SaveManager saveManager = SaveManager._003CInstance_003Ek__BackingField;
		if ((object)SaveManager._003CInstance_003Ek__BackingField != null)
		{
			ProgressionSaveFile progression = saveManager.progression;
			if (saveManager.progression != null && progression.achievements != null)
			{
				return ((HashSet<object>)(object)progression.achievements).Contains((object)achName);
			}
		}
		NullReferenceException ex = new NullReferenceException();
		return (byte)(int)ex != 0;
	}

	public static bool CheckAchievementValue(string achievementName, int value)
	{
		//IL_016d: Expected I4, but got O
		//IL_00f4: Expected O, but got I4
		//IL_010e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0113: Expected I4, but got Unknown
		//IL_0092: Invalid comparison between F4 and I4
		string text;
		if ((object)DataManager.Instance != null)
		{
			MyAchievement achievement = DataManager.Instance.GetAchievement(achievementName);
			if (!(achievement != null))
			{
				text = "Achievement is null... ach: ";
				goto IL_018b;
			}
			if ((object)achievement != null)
			{
				if (achievement.targetValue == 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 0000000180404C25h\"");
					if (achievement.targetValueFloat == 0f && string.IsNullOrEmpty(achievement.targetValueString))
					{
						text = "Achievement isn't tracking value... ach: ";
						goto IL_018b;
					}
				}
				object obj = value - achievement.targetValue;
				int num = value ^ achievement.targetValue;
				int num2 = value ^ obj;
				int num3 = num & num2;
				bool flag = num3 < 0;
				bool flag2 = (nint)obj < 0;
				return flag2 == flag;
			}
		}
		NullReferenceException ex = new NullReferenceException();
		return (byte)(int)ex != 0;
		IL_018b:
		string text2 = text + achievementName;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1803321E0");
		return false;
	}

	public static int GetAchievementTargetValue(string achName)
	{
		//IL_004c: Expected I4, but got O
		if ((object)DataManager.Instance != null)
		{
			MyAchievement achievement = DataManager.Instance.GetAchievement(achName);
			if ((object)achievement != null)
			{
				return achievement.targetValue;
			}
		}
		NullReferenceException ex = new NullReferenceException();
		return (int)ex;
	}

	public static float GetAchievementTargetValueFloat(string achName)
	{
		MyAchievement achievement = DataManager.Instance.GetAchievement(achName);
		return achievement.targetValueFloat;
	}

	public unsafe static bool IsUnlocked(UnlockableBase unlockable, out string requirementsString)
	{
		//IL_04d5: Expected I4, but got O
		//IL_018d: Expected I, but got O
		//IL_0350: Expected I, but got O
		//IL_03cb: Expected I, but got O
		ref string reference = ref *(string*)"";
		UnlockableBase unlockableRequirement;
		bool result;
		if (unlockable.isEnabled)
		{
			reference = ref *(string*)"";
			MyAchievement unlockRequirement = unlockable.GetUnlockRequirement();
			unlockableRequirement = unlockable.GetUnlockableRequirement();
			bool flag = unlockRequirement != null;
			bool flag2 = !flag;
			result = true;
			if (flag2)
			{
				goto IL_0224;
			}
			string text = MyColorUtility.requirementCompletedColor;
			bool flag3 = IsUnlocked(unlockRequirement);
			result = true;
			if (!flag3)
			{
				text = MyColorUtility.requirementMissingColor;
				result = false;
			}
			string[] array = new string[6];
			if (array.Length > 0)
			{
				array[0] = requirementsString;
				if (array.Length > 1)
				{
					array[1] = "<color=";
					if (array.Length > 2)
					{
						array[2] = text;
						if (array.Length > 3)
						{
							array[3] = ">* ";
							nint num = (nint)unlockRequirement;
							Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v721 @ rax_v66 (Il2CppClass<UnityEngine.Object>)+198] (should have been resolved before IL gen)");
							if (array.Length > 4)
							{
								object obj = default(object);
								array[4] = (string)obj;
								if (array.Length > 5)
								{
									array[5] = "\n";
									string text2 = string.Concat(array);
									reference = ref *(string*)text2;
									goto IL_0224;
								}
							}
						}
					}
				}
			}
			goto IL_04c7;
		}
		reference = ref *(string*)"Available in the full release";
		return false;
		IL_045d:
		return result;
		IL_04c7:
		IndexOutOfRangeException ex = new IndexOutOfRangeException();
		return (byte)(int)ex != 0;
		IL_0224:
		if (!(unlockableRequirement != null))
		{
			goto IL_045d;
		}
		string text3 = MyColorUtility.requirementCompletedColor;
		if (!IsPurchased(unlockableRequirement))
		{
			text3 = MyColorUtility.requirementMissingColor;
			result = false;
		}
		string[] array2 = new string[8];
		if (array2.Length > 0)
		{
			array2[0] = requirementsString;
			if (array2.Length > 1)
			{
				array2[1] = "<color=";
				if (array2.Length > 2)
				{
					array2[2] = text3;
					if (array2.Length > 3)
					{
						array2[3] = ">* Purchase ";
						nint num2 = (nint)unlockableRequirement;
						Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v730 @ rax_v36 (Il2CppClass<UnityEngine.Object>)+1E8] (should have been resolved before IL gen)");
						if (array2.Length > 4)
						{
							object obj2 = default(object);
							array2[4] = (string)obj2;
							if (array2.Length > 5)
							{
								array2[5] = " - ";
								nint num3 = (nint)unlockableRequirement;
								Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v740 @ rax_v40 (Il2CppClass<UnityEngine.Object>)+188] (should have been resolved before IL gen)");
								if (array2.Length > 6)
								{
									object obj3 = default(object);
									array2[6] = (string)obj3;
									if (array2.Length > 7)
									{
										array2[7] = "\n";
										string text4 = string.Concat(array2);
										reference = ref *(string*)text4;
										goto IL_045d;
									}
								}
							}
						}
					}
				}
			}
		}
		goto IL_04c7;
	}

	public static bool IsUnlocked(MyAchievement myAchievement)
	{
		//IL_0078: Expected I4, but got O
		if (myAchievement != null)
		{
			if ((object)myAchievement == null)
			{
				NullReferenceException ex = new NullReferenceException();
				return (byte)(int)ex != 0;
			}
			if (myAchievement.isEnabled)
			{
				return IsUnlocked(myAchievement.internalName);
			}
		}
		return true;
	}

	public static bool IsUnlockedInternalNameAch(string achName)
	{
		return IsUnlocked(achName);
	}

	private static bool IsUnlocked(string unlockName)
	{
		//IL_00b0: Expected I4, but got O
		SaveManager saveManager = SaveManager._003CInstance_003Ek__BackingField;
		if ((object)SaveManager._003CInstance_003Ek__BackingField != null)
		{
			ProgressionSaveFile progression = saveManager.progression;
			if (saveManager.progression != null && progression.achievements != null)
			{
				return ((HashSet<object>)(object)progression.achievements).Contains((object)unlockName);
			}
		}
		NullReferenceException ex = new NullReferenceException();
		return (byte)(int)ex != 0;
	}

	public static bool IsPurchased(UnlockableBase unlockable)
	{
		//IL_0143: Expected I4, but got O
		//IL_004b: Expected I, but got O
		//IL_00b4: Expected O, but got I
		//IL_0120: Expected O, but got I
		if (unlockable != null)
		{
			if ((object)unlockable != null)
			{
				nint num = (nint)unlockable;
				int price = unlockable.GetPrice();
				if (price <= 0)
				{
					return true;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1803311C0");
				object obj = default(object);
				if (obj != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v112 @ rax_v12+30]");
					object obj2 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v112 @ rax_v12+30]");
					if ((nint)0 != 0)
					{
						object internalName = unlockable.GetInternalName();
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v116 @ rcx_v9+38]");
						if ((nint)0 != 0)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v116 @ rcx_v9+38]");
							return ((HashSet<object>)0).Contains(internalName);
						}
					}
				}
			}
			NullReferenceException ex = new NullReferenceException();
			return (byte)(int)ex != 0;
		}
		return false;
	}

	public static bool IsAvailable(UnlockableBase unlockable)
	{
		//IL_0252: Expected I4, but got O
		//IL_009c: Expected I, but got O
		//IL_00ac: Expected O, but got I
		//IL_00d4: Expected O, but got I4
		//IL_0116: Expected O, but got I4
		//IL_0124: Expected O, but got I4
		//IL_01a5: Expected O, but got I
		//IL_0211: Expected O, but got I
		if (IsPurchased(unlockable))
		{
			bool flag = unlockable == null;
			if (!flag)
			{
				if ((object)unlockable == null)
				{
					goto IL_0244;
				}
				if (unlockable.isEnabled != flag)
				{
					nint num = (nint)unlockable;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v281 @ rax_v13 (Il2CppClass<Assets.Scripts.Saves___Serialization.Progression.Achievements.UnlockableBase>)+1B0]");
					UnityEngine.Object obj = (UnityEngine.Object)0;
					int price = unlockable.GetPrice();
					bool flag2 = price <= 0;
					object obj2 = 0;
					object obj3;
					UnityEngine.Object obj4;
					if (!flag2)
					{
						MyAchievement unlockRequirement = unlockable.GetUnlockRequirement();
						bool flag3 = unlockRequirement == null;
						bool flag4 = !flag3;
						obj2 = 0;
						obj = null;
						obj3 = 0;
						obj4 = null;
						if (flag4)
						{
							goto IL_016e;
						}
					}
					bool flag5 = !unlockable.canAlwaysToggle;
					obj3 = obj2;
					obj4 = obj;
					if (!flag5)
					{
						goto IL_016e;
					}
					goto IL_0228;
				}
			}
		}
		goto IL_023e;
		IL_0244:
		NullReferenceException ex = new NullReferenceException();
		return (byte)(int)ex != 0;
		IL_023e:
		return false;
		IL_016e:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1803311C0");
		object obj5 = default(object);
		if (obj5 != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v245 @ rax_v21+30]");
			object obj6 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v245 @ rax_v21+30]");
			if ((nint)0 != 0)
			{
				object internalName = unlockable.GetInternalName();
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v248 @ rcx_v18+40]");
				if ((nint)0 != 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v248 @ rcx_v18+40]");
					if (!((HashSet<object>)0).Contains(internalName))
					{
						goto IL_0228;
					}
					goto IL_023e;
				}
			}
		}
		goto IL_0244;
		IL_0228:
		string requirementsString;
		return IsUnlocked(unlockable, out requirementsString);
	}

	public static bool IsActivated(UnlockableBase unlockable)
	{
		//IL_0212: Expected I4, but got O
		//IL_006c: Expected I, but got O
		//IL_007c: Expected O, but got I
		//IL_00a4: Expected O, but got I4
		//IL_00eb: Expected O, but got I4
		//IL_00f9: Expected O, but got I4
		//IL_0175: Expected O, but got I
		//IL_01e1: Expected O, but got I
		bool flag = unlockable == null;
		if (!flag)
		{
			if ((object)unlockable == null)
			{
				goto IL_0204;
			}
			if (unlockable.isEnabled != flag)
			{
				nint num = (nint)unlockable;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v209 @ rax_v8 (Il2CppClass<Assets.Scripts.Saves___Serialization.Progression.Achievements.UnlockableBase>)+1B0]");
				UnityEngine.Object obj = (UnityEngine.Object)0;
				int price = unlockable.GetPrice();
				bool flag2 = price <= 0;
				object obj2 = 0;
				UnityEngine.Object obj3;
				object obj4;
				if (!flag2)
				{
					MyAchievement unlockRequirement = unlockable.GetUnlockRequirement();
					bool flag3 = unlockRequirement == null;
					bool flag4 = !flag3;
					obj = null;
					obj2 = 0;
					obj3 = null;
					obj4 = 0;
					if (flag4)
					{
						goto IL_013e;
					}
				}
				bool flag5 = !unlockable.canAlwaysToggle;
				obj3 = obj;
				obj4 = obj2;
				if (!flag5)
				{
					goto IL_013e;
				}
				return true;
			}
		}
		return false;
		IL_0204:
		NullReferenceException ex = new NullReferenceException();
		return (byte)(int)ex != 0;
		IL_013e:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1803311C0");
		object obj5 = default(object);
		if (obj5 != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v120 @ rax_v12+30]");
			object obj6 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v120 @ rax_v12+30]");
			if ((nint)0 != 0)
			{
				object internalName = unlockable.GetInternalName();
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v124 @ rcx_v10+40]");
				if ((nint)0 != 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v124 @ rcx_v10+40]");
					bool flag6 = ((HashSet<object>)0).Contains(internalName);
					return (byte)((flag6 ? 1u : 0u) ^ 1u) != 0;
				}
			}
		}
		goto IL_0204;
	}

	public static bool CanToggleActivation(UnlockableBase unlockable)
	{
		//IL_0284: Expected I4, but got O
		//IL_0168: Expected I, but got O
		//IL_0170: Expected I, but got O
		//IL_0180: Expected O, but got I
		//IL_01f4: Expected I, but got O
		//IL_0204: Expected O, but got I
		//IL_01bc: Expected O, but got I
		//IL_0240: Expected O, but got I
		if (!(unlockable != null))
		{
			goto IL_0270;
		}
		SaveManager saveManager = SaveManager._003CInstance_003Ek__BackingField;
		if ((object)SaveManager._003CInstance_003Ek__BackingField != null)
		{
			ProgressionSaveFile progression = saveManager.progression;
			if (saveManager.progression != null && progression.shopItems != null)
			{
				int num = progression.shopItems.get_Item(EShopItem.Toggler);
				if (num > 0)
				{
					if ((object)unlockable == null)
					{
						goto IL_0276;
					}
					if (unlockable.canAlwaysToggle)
					{
						goto IL_026a;
					}
					int price = unlockable.GetPrice();
					if (price > 0)
					{
						MyAchievement unlockRequirement = unlockable.GetUnlockRequirement();
						if (unlockRequirement != null)
						{
							nint num2 = (nint)typeof(CharacterData);
							nint num3 = (nint)unlockable;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v83 @ rdx_v9 (Il2CppClass<CharacterData>)+130]");
							object obj = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v88 @ r8_v7 (Il2CppClass<Assets.Scripts.Saves___Serialization.Progression.Achievements.UnlockableBase>)+130]");
							nint num4 = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v83 @ rdx_v9 (Il2CppClass<CharacterData>)+130]");
							if (num4 >= 0)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v88 @ r8_v7 (Il2CppClass<Assets.Scripts.Saves___Serialization.Progression.Achievements.UnlockableBase>)+C8]");
								object obj2 = 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v93 @ rax_v26+FFFFFFF8+v358 @ rax_v22*8]");
								if (0 == (nint)typeof(CharacterData))
								{
									goto IL_0270;
								}
							}
							nint num5 = (nint)typeof(HatData);
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v84 @ rdx_v10 (Il2CppClass<HatData>)+130]");
							object obj3 = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v88 @ r8_v7 (Il2CppClass<Assets.Scripts.Saves___Serialization.Progression.Achievements.UnlockableBase>)+130]");
							nint num6 = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v84 @ rdx_v10 (Il2CppClass<HatData>)+130]");
							if (num6 >= 0)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v88 @ r8_v7 (Il2CppClass<Assets.Scripts.Saves___Serialization.Progression.Achievements.UnlockableBase>)+C8]");
								object obj4 = 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v94 @ rax_v25+FFFFFFF8+v328 @ rax_v24*8]");
								if (0 == (nint)typeof(HatData))
								{
									goto IL_0270;
								}
							}
							goto IL_026a;
						}
					}
				}
				goto IL_0270;
			}
		}
		goto IL_0276;
		IL_026a:
		return true;
		IL_0270:
		return false;
		IL_0276:
		NullReferenceException ex = new NullReferenceException();
		return (byte)(int)ex != 0;
	}

	private static void OnProgressionSaved()
	{
		hasUnsavedChanges = false;
	}

	private static void OnProgressionLoaded()
	{
		TryStartStatTracking();
	}

	private static void OnDataLoaded()
	{
		TryStartStatTracking();
	}

	private static void OnPause(bool paused)
	{
		float time = Time.time;
		if (!(nextSaveTimeReady > time))
		{
			if (paused && hasUnsavedChanges)
			{
				float time2 = Time.time;
				float num = time2 + saveCooldown;
				nextSaveTimeReady = num;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1803311C0");
				SaveManager saveManager = default(SaveManager);
				saveManager.SaveProgression();
			}
		}
		else
		{
			hasUnsavedChanges = true;
		}
	}

	public static int NumCompletedAchievements()
	{
		//IL_00a7: Expected I4, but got O
		SaveManager saveManager = SaveManager._003CInstance_003Ek__BackingField;
		if ((object)SaveManager._003CInstance_003Ek__BackingField != null)
		{
			ProgressionSaveFile progression = saveManager.progression;
			if (saveManager.progression != null)
			{
				HashSet<string> achievements = progression.achievements;
				if (progression.achievements != null)
				{
					return achievements._count;
				}
			}
		}
		NullReferenceException ex = new NullReferenceException();
		return (int)ex;
	}

	public static int NumTotalAchievements()
	{
		//IL_0144: Expected I4, but got O
		DataManager instance = DataManager.Instance;
		bool flag = (object)DataManager.Instance == null;
		int num = 0;
		int num2 = 0;
		int num3 = 0;
		if (!flag)
		{
			while (true)
			{
				List<MyAchievement> unsortedAchievements = instance.unsortedAchievements;
				if (instance.unsortedAchievements == null)
				{
					break;
				}
				if (num3 < unsortedAchievements._size)
				{
					DataManager instance2 = DataManager.Instance;
					if ((object)DataManager.Instance == null || instance2.unsortedAchievements == null)
					{
						break;
					}
					MyAchievement myAchievement = instance2.unsortedAchievements.get_Item(num);
					if ((object)myAchievement == null)
					{
						break;
					}
					if (myAchievement.isEnabled && !myAchievement.IsHiddenInMenus())
					{
						num2++;
					}
					num++;
					instance = DataManager.Instance;
					if ((object)DataManager.Instance == null)
					{
						break;
					}
					num3 = num;
					continue;
				}
				return num2;
			}
		}
		NullReferenceException ex = new NullReferenceException();
		return (int)ex;
	}

	public static bool AreAllQuestsCompleted()
	{
		//IL_0247: Expected I4, but got O
		//IL_0281: Expected O, but got I4
		//IL_01d2: Unknown result type (might be due to invalid IL or missing references)
		//IL_01d7: Expected O, but got Unknown
		//IL_01e4: Unknown result type (might be due to invalid IL or missing references)
		//IL_01e9: Expected I4, but got Unknown
		//IL_01f6: Unknown result type (might be due to invalid IL or missing references)
		//IL_01fb: Expected I4, but got Unknown
		//IL_01ae: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b3: Expected O, but got Unknown
		SaveManager saveManager = SaveManager._003CInstance_003Ek__BackingField;
		if ((object)SaveManager._003CInstance_003Ek__BackingField != null)
		{
			ProgressionSaveFile progression = saveManager.progression;
			if (saveManager.progression != null)
			{
				HashSet<string> achievements = progression.achievements;
				if (progression.achievements != null)
				{
					DataManager instance = DataManager.Instance;
					bool flag = (object)DataManager.Instance == null;
					int num = 0;
					object obj = 0;
					int num2 = 0;
					if (!flag)
					{
						while (true)
						{
							List<MyAchievement> unsortedAchievements = instance.unsortedAchievements;
							if (instance.unsortedAchievements == null)
							{
								break;
							}
							if (num2 < unsortedAchievements._size)
							{
								DataManager instance2 = DataManager.Instance;
								if ((object)DataManager.Instance == null || instance2.unsortedAchievements == null)
								{
									break;
								}
								MyAchievement myAchievement = instance2.unsortedAchievements.get_Item(num);
								if ((object)myAchievement == null)
								{
									break;
								}
								if (myAchievement.isEnabled && !myAchievement.IsHiddenInMenus())
								{
									obj++;
								}
								num++;
								instance = DataManager.Instance;
								if ((object)DataManager.Instance == null)
								{
									break;
								}
								num2 = num;
								continue;
							}
							object obj2 = achievements._count - obj;
							int num3 = achievements._count ^ obj;
							int num4 = achievements._count ^ obj2;
							int num5 = num3 & num4;
							bool flag2 = num5 < 0;
							bool flag3 = (nint)obj2 < 0;
							return flag3 == flag2;
						}
					}
				}
			}
		}
		NullReferenceException ex = new NullReferenceException();
		return (byte)(int)ex != 0;
	}

	public unsafe static void SyncToSteamAchievements()
	{
		//IL_0047: Expected O, but got I
		//IL_0095: Expected O, but got I
		DataManager instance = DataManager.Instance;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @181126F30");
		List<object>.Enumerator enumerator = default(List<object>.Enumerator);
		object obj = default(object);
		while (true)
		{
			if (enumerator.MoveNext())
			{
				if (obj == null)
				{
					break;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v118 @ stack_-30+30]");
				if (SteamUserStats.GetAchievement((string)0, out var pbAchieved) && pbAchieved)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v118 @ stack_-30+30]");
					bool flag = TryUnlock((string)0);
				}
				continue;
			}
			((List<MyAchievement>.Enumerator*)(&enumerator))->Dispose();
			return;
		}
		throw new NullReferenceException();
	}

	public unsafe static void GetAchievementTypeProgress(EAchievementType achievementType, out int completed, out int total, out int unclaimed)
	{
		_003C_003Ec__DisplayClass45_0 CS_0024_003C_003E8__locals2 = new _003C_003Ec__DisplayClass45_0();
		CS_0024_003C_003E8__locals2.achievementType = achievementType;
		DataManager instance = DataManager.Instance;
		Func<MyAchievement, bool> predicate = delegate(MyAchievement a)
		{
			//IL_008b: Expected I4, but got O
			if ((object)a == null)
			{
				NullReferenceException ex = new NullReferenceException();
				return (byte)(int)ex != 0;
			}
			return a.achievementType == CS_0024_003C_003E8__locals2.achievementType && a.isEnabled && a.IsVisible();
		};
		IEnumerable<MyAchievement> source = Enumerable.Where(instance.unsortedAchievements, predicate);
		List<object> list = Enumerable.ToList((IEnumerable<object>)source);
		ref int reference = ref *(int*)list._size;
		Func<object, bool> predicate2 = (Func<object, bool>)_003C_003Ec._003C_003E9__45_1;
		if (_003C_003Ec._003C_003E9__45_1 == null)
		{
			predicate2 = (Func<object, bool>)(_003C_003Ec._003C_003E9__45_1 = delegate(MyAchievement a)
			{
				//IL_002f: Expected I4, but got O
				if ((object)a == null)
				{
					NullReferenceException ex = new NullReferenceException();
					return (byte)(int)ex != 0;
				}
				return IsUnlocked(a.internalName);
			});
		}
		int num = Enumerable.Count(list, predicate2);
		ref int reference2 = ref *(int*)num;
		Func<object, bool> predicate3 = (Func<object, bool>)_003C_003Ec._003C_003E9__45_2;
		if (_003C_003Ec._003C_003E9__45_2 == null)
		{
			predicate3 = (Func<object, bool>)(_003C_003Ec._003C_003E9__45_2 = delegate(MyAchievement a)
			{
				//IL_00ed: Expected I4, but got O
				if ((object)a != null)
				{
					bool flag = IsUnlocked(a.internalName);
					if (!flag)
					{
						return flag;
					}
					SaveManager saveManager = SaveManager._003CInstance_003Ek__BackingField;
					if ((object)SaveManager._003CInstance_003Ek__BackingField != null)
					{
						ProgressionSaveFile progression = saveManager.progression;
						if (saveManager.progression != null && progression.claimedAchievements != null)
						{
							bool flag2 = ((HashSet<object>)(object)progression.claimedAchievements).Contains((object)a.internalName);
							return (byte)((flag2 ? 1u : 0u) ^ 1u) != 0;
						}
					}
				}
				NullReferenceException ex = new NullReferenceException();
				return (byte)(int)ex != 0;
			});
		}
		int num2 = Enumerable.Count(list, predicate3);
		ref int reference3 = ref *(int*)num2;
	}

	static MyAchievements()
	{
		Dictionary<string, List<MyAchievement>> dictionary = new Dictionary<string, List<MyAchievement>>();
		statTrackers = dictionary;
		fakeCharacters = 0;
		fakeWeapons = 0;
		fakeItems = 0;
		fakeMaps = 0;
		fakeTomes = 0;
		fakeAchievements = 0;
		HashSet<MyStat> hashSet = (HashSet<MyStat>)(object)new HashSet<object>();
		queuedStatNames = hashSet;
		statTrackersCooldown = 1f;
		saveCooldown = 5f;
	}
}
