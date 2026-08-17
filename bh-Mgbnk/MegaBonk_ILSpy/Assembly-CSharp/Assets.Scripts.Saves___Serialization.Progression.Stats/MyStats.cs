using System;
using System.Collections.Generic;
using Assets.Scripts.Saves___Serialization.SaveFiles;
using Assets.Scripts.Utility;
using Cpp2ILInjected;
using Steamworks;
using UnityEngine;

namespace Assets.Scripts.Saves___Serialization.Progression.Stats;

public static class MyStats
{
	private static bool hasUnsavedChanges;

	public static Action<string, MyStat> A_StatUpdated;

	private static float nextSaveTimeReady;

	private static float saveCooldown = 5f;

	public static void Init()
	{
		//IL_028f: Expected O, but got I4
		//IL_02e0: Expected O, but got I4
		//IL_02f6: Expected I, but got O
		//IL_031c: Expected O, but got I4
		//IL_0332: Expected I, but got O
		//IL_0358: Expected O, but got I4
		//IL_036e: Expected I, but got O
		//IL_020b: Expected O, but got I4
		//IL_025f: Expected O, but got I4
		if (SaveManager.loaded)
		{
			hasUnsavedChanges = false;
		}
		Delegate a_SavesLoaded = SaveManager.A_SavesLoaded;
		Action action = OnProgressionLoaded;
		Delegate obj = Delegate.Combine(SaveManager.A_SavesLoaded, action);
		Action action2;
		object obj3;
		Delegate obj4;
		if ((object)obj == null)
		{
			SaveManager.A_SavesLoaded = null;
		}
		else
		{
			bool flag = (object)obj.GetType() != typeof(Action);
			Delegate obj2 = null;
			if (!flag)
			{
				obj2 = obj;
			}
			if ((object)obj2 == null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
				action2 = action;
				obj3 = 0;
				obj4 = obj;
				goto IL_03b4;
			}
			SaveManager.A_SavesLoaded = (Action)obj2;
			bool flag2 = (object)obj.GetType() != typeof(Action);
			Delegate obj5 = null;
			if (!flag2)
			{
				obj5 = obj;
			}
			bool flag3 = (object)obj5 == null;
			obj3 = 0;
			obj4 = obj;
			nint num = (nint)typeof(Action);
			if (flag3)
			{
				goto IL_0413;
			}
		}
		Action b = OnProgressionSaved;
		Delegate obj6 = Delegate.Combine(SaveManager.A_ProgressionSaved, b);
		if ((object)obj6 == null)
		{
			SaveManager.A_ProgressionSaved = null;
		}
		else
		{
			bool flag4 = (object)obj6.GetType() != typeof(Action);
			Delegate obj7 = null;
			if (!flag4)
			{
				obj7 = obj6;
			}
			bool flag5 = (object)obj7 == null;
			obj3 = 0;
			obj4 = obj6;
			nint num2 = (nint)typeof(Action);
			if (flag5)
			{
				goto IL_041e;
			}
			SaveManager.A_ProgressionSaved = (Action)obj7;
			bool flag6 = (object)obj6.GetType() != typeof(Action);
			Delegate obj8 = null;
			if (!flag6)
			{
				obj8 = obj6;
			}
			bool flag7 = (object)obj8 == null;
			obj3 = 0;
			obj4 = obj6;
			nint num3 = (nint)typeof(Action);
			if (flag7)
			{
				goto IL_042e;
			}
		}
		Action<bool> b2 = OnPause;
		Delegate obj9 = Delegate.Combine(MyTime.A_Pause, b2);
		if ((object)obj9 == null)
		{
			MyTime.A_Pause = null;
			return;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
		Action<bool> action3 = default(Action<bool>);
		bool flag8 = action3 == null;
		a_SavesLoaded = (Delegate)(object)typeof(Action<bool>);
		action2 = (Action)obj9;
		obj3 = 0;
		obj4 = null;
		if (flag8)
		{
			goto IL_03a4;
		}
		MyTime.A_Pause = action3;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
		object obj10 = default(object);
		bool flag9 = obj10 == null;
		a_SavesLoaded = (Delegate)(object)typeof(Action<bool>);
		action2 = (Action)obj9;
		obj3 = 0;
		obj4 = null;
		if (!flag9)
		{
			return;
		}
		goto IL_03b4;
		IL_041e:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_0413;
		IL_0413:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		return;
		IL_03b4:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_03a4;
		IL_03a4:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_042e;
		IL_042e:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_041e;
	}

	public static void Cleanup()
	{
		//IL_0276: Expected O, but got I4
		//IL_02bd: Expected O, but got I4
		//IL_02d3: Expected I, but got O
		//IL_02f9: Expected O, but got I4
		//IL_030f: Expected I, but got O
		//IL_0335: Expected O, but got I4
		//IL_034b: Expected I, but got O
		//IL_01f2: Expected O, but got I4
		//IL_0246: Expected O, but got I4
		Delegate a_SavesLoaded = SaveManager.A_SavesLoaded;
		Action action = OnProgressionLoaded;
		Delegate obj = Delegate.Remove(SaveManager.A_SavesLoaded, action);
		Action action2;
		object obj3;
		Delegate obj4;
		if ((object)obj == null)
		{
			SaveManager.A_SavesLoaded = null;
		}
		else
		{
			bool flag = (object)obj.GetType() != typeof(Action);
			Delegate obj2 = null;
			if (!flag)
			{
				obj2 = obj;
			}
			if ((object)obj2 == null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
				action2 = action;
				obj3 = 0;
				obj4 = obj;
				goto IL_0391;
			}
			SaveManager.A_SavesLoaded = (Action)obj2;
			bool flag2 = (object)obj.GetType() != typeof(Action);
			Delegate obj5 = null;
			if (!flag2)
			{
				obj5 = obj;
			}
			bool flag3 = (object)obj5 == null;
			obj3 = 0;
			obj4 = obj;
			nint num = (nint)typeof(Action);
			if (flag3)
			{
				goto IL_03d2;
			}
		}
		Action value = OnProgressionSaved;
		Delegate obj6 = Delegate.Remove(SaveManager.A_ProgressionSaved, value);
		if ((object)obj6 == null)
		{
			SaveManager.A_ProgressionSaved = null;
		}
		else
		{
			bool flag4 = (object)obj6.GetType() != typeof(Action);
			Delegate obj7 = null;
			if (!flag4)
			{
				obj7 = obj6;
			}
			bool flag5 = (object)obj7 == null;
			obj3 = 0;
			obj4 = obj6;
			nint num2 = (nint)typeof(Action);
			if (flag5)
			{
				goto IL_03dd;
			}
			SaveManager.A_ProgressionSaved = (Action)obj7;
			bool flag6 = (object)obj6.GetType() != typeof(Action);
			Delegate obj8 = null;
			if (!flag6)
			{
				obj8 = obj6;
			}
			bool flag7 = (object)obj8 == null;
			obj3 = 0;
			obj4 = obj6;
			nint num3 = (nint)typeof(Action);
			if (flag7)
			{
				goto IL_03ed;
			}
		}
		Action<bool> value2 = OnPause;
		Delegate obj9 = Delegate.Remove(MyTime.A_Pause, value2);
		if ((object)obj9 == null)
		{
			MyTime.A_Pause = null;
			return;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
		Action<bool> action3 = default(Action<bool>);
		bool flag8 = action3 == null;
		a_SavesLoaded = (Delegate)(object)typeof(Action<bool>);
		action2 = (Action)obj9;
		obj3 = 0;
		obj4 = null;
		if (flag8)
		{
			goto IL_0381;
		}
		MyTime.A_Pause = action3;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
		object obj10 = default(object);
		bool flag9 = obj10 == null;
		a_SavesLoaded = (Delegate)(object)typeof(Action<bool>);
		action2 = (Action)obj9;
		obj3 = 0;
		obj4 = null;
		if (!flag9)
		{
			return;
		}
		goto IL_0391;
		IL_0391:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_0381;
		IL_0381:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_03ed;
		IL_03ed:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_03dd;
		IL_03d2:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		return;
		IL_03dd:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_03d2;
	}

	public static void AddValue(EMyStat statName, float value)
	{
		string statString = TrackStats.GetStatString(statName);
		AddValue(statString, value);
	}

	public unsafe static void AddValue(string statName, float value)
	{
		//IL_00c2: Expected F4, but got Ref
		//IL_0105: Expected I, but got O
		//IL_01e6: Invalid comparison between I and F4
		SaveManager saveManager = SaveManager._003CInstance_003Ek__BackingField;
		if ((object)SaveManager._003CInstance_003Ek__BackingField != null)
		{
			StatsSaveFile stats = saveManager.stats;
			if (saveManager.stats != null && stats.stats != null)
			{
				bool flag = ((Dictionary<object, object>)(object)stats.stats).TryGetValue((object)statName, out object value2);
				nint num = (nint)(&value2);
				nint num2 = 0;
				MyStat myStat = default(MyStat);
				if (!flag)
				{
					myStat = new MyStat(null, (nint)(&value2));
					myStat.name = statName;
					myStat.value = 0f;
					((Dictionary<object, object>)(object)stats.stats).Add((object)statName, (object)myStat);
					num = (nint)myStat;
					num2 = 0;
				}
				bool flag2 = myStat == null;
				object obj = myStat;
				if (!flag2)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v224 @ rax_v34 (Assets.Scripts.Saves___Serialization.Progression.Stats.MyStat)+18]");
					float num3 = 0f + value;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v224 @ rax_v34 (Assets.Scripts.Saves___Serialization.Progression.Stats.MyStat)+18]");
					bool flag3 = 0f > num3;
					obj = myStat;
					if (!flag3)
					{
						hasUnsavedChanges = true;
						Action<string, MyStat> a_StatUpdated = A_StatUpdated;
						if (A_StatUpdated != null)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v308 @ rax_v27 (System.Action`2<System.String, Assets.Scripts.Saves___Serialization.Progression.Stats.MyStat>)+18] (should have been resolved before IL gen)");
						}
						return;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_value_box\"");
					throw new NullReferenceException();
				}
			}
		}
		throw new NullReferenceException();
	}

	private static void SetValueInternal(string statName, MyStat stat, float value)
	{
		if (!(stat.value > value))
		{
			stat.value = value;
			hasUnsavedChanges = true;
			Action<string, MyStat> a_StatUpdated = A_StatUpdated;
			if (A_StatUpdated != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v98 @ rax_v18 (System.Action`2<System.String, Assets.Scripts.Saves___Serialization.Progression.Stats.MyStat>)+18] (should have been resolved before IL gen)");
			}
			return;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_value_box\"");
		throw new NullReferenceException();
	}

	public static void SetValueForce(string statName, float value)
	{
		//IL_0080: Expected F4, but got I
		SaveManager saveManager = SaveManager._003CInstance_003Ek__BackingField;
		StatsSaveFile stats = saveManager.stats;
		if (!stats.stats.ContainsKey(statName))
		{
			SaveManager saveManager2 = SaveManager._003CInstance_003Ek__BackingField;
			StatsSaveFile stats2 = saveManager2.stats;
			MyStat myStat = new MyStat(null, 0f);
			myStat.name = statName;
			myStat.value = 0f;
			((Dictionary<object, object>)(object)stats2.stats).Add((object)statName, (object)myStat);
		}
		SaveManager saveManager3 = SaveManager._003CInstance_003Ek__BackingField;
		StatsSaveFile stats3 = saveManager3.stats;
		MyStat myStat2 = stats3.stats.get_Item(statName);
		myStat2.value = value;
		hasUnsavedChanges = true;
		Action<string, MyStat> a_StatUpdated = A_StatUpdated;
		if (A_StatUpdated != null)
		{
			SaveManager saveManager4 = SaveManager._003CInstance_003Ek__BackingField;
			StatsSaveFile stats4 = saveManager4.stats;
			MyStat myStat3 = stats4.stats.get_Item(statName);
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v116 @ rbx_v3 (System.Action`2<System.String, Assets.Scripts.Saves___Serialization.Progression.Stats.MyStat>)+18] (should have been resolved before IL gen)");
		}
	}

	public static bool HasStat(string statName)
	{
		//IL_00ab: Expected I4, but got O
		SaveManager saveManager = SaveManager._003CInstance_003Ek__BackingField;
		if ((object)SaveManager._003CInstance_003Ek__BackingField != null)
		{
			StatsSaveFile stats = saveManager.stats;
			if (saveManager.stats != null && stats.stats != null)
			{
				return stats.stats.ContainsKey(statName);
			}
		}
		NullReferenceException ex = new NullReferenceException();
		return (byte)(int)ex != 0;
	}

	public static float GetStat(string statName)
	{
		//IL_00ae: Expected F4, but got I4
		SaveManager saveManager = SaveManager._003CInstance_003Ek__BackingField;
		StatsSaveFile stats = saveManager.stats;
		if (stats.stats.ContainsKey(statName))
		{
			SaveManager saveManager2 = SaveManager._003CInstance_003Ek__BackingField;
			StatsSaveFile stats2 = saveManager2.stats;
			MyStat myStat = stats2.stats.get_Item(statName);
			return myStat.value;
		}
		return 0f;
	}

	private static void OnProgressionLoaded()
	{
		hasUnsavedChanges = false;
	}

	private static void OnProgressionSaved()
	{
		hasUnsavedChanges = false;
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
				saveManager.SaveStats();
			}
		}
		else
		{
			hasUnsavedChanges = true;
		}
	}

	public unsafe static void SynToSteamStats()
	{
		//IL_007f: Invalid comparison between I4 and F4
		//IL_00a9: Expected F4, but got I4
		SaveManager saveManager = SaveManager._003CInstance_003Ek__BackingField;
		StatsSaveFile stats = saveManager.stats;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180D598D0");
		Dictionary<object, object>.Enumerator enumerator = default(Dictionary<object, object>.Enumerator);
		string text = default(string);
		while (enumerator.MoveNext())
		{
			if (SteamUserStats.GetStat(text, out int pData))
			{
				float stat = GetStat(text);
				if ((float)pData > stat)
				{
					SetValueForce(text, pData);
				}
			}
		}
		((Dictionary<string, MyStat>.Enumerator*)(&enumerator))->Dispose();
	}
}
