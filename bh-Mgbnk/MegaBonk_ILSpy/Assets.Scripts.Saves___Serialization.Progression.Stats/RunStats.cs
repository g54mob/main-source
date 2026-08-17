using System;
using System.Collections.Generic;
using Assets.Scripts.Actors;
using Assets.Scripts.Actors.Enemies;
using Assets.Scripts.Saves___Serialization.Progression.Achievements;
using Assets.Scripts.Utility;
using Cpp2ILInjected;

namespace Assets.Scripts.Saves___Serialization.Progression.Stats;

public static class RunStats
{
	private static Dictionary<string, float> stats;

	public static Dictionary<string, DamageSource> damageSources;

	public static List<MyAchievement> achievements;

	public static Action<string, float> A_StatChange;

	public static void Init()
	{
		//IL_019d: Expected O, but got I4
		//IL_0210: Expected O, but got I4
		//IL_0226: Expected I, but got O
		//IL_0119: Expected O, but got I4
		//IL_016d: Expected O, but got I4
		Delegate a_RunStarted = GameManager.A_RunStarted;
		Action action = OnNewRun;
		Delegate obj = Delegate.Combine(GameManager.A_RunStarted, action);
		Action action2;
		object obj3;
		Delegate obj4;
		if ((object)obj == null)
		{
			GameManager.A_RunStarted = null;
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
				goto IL_026c;
			}
			GameManager.A_RunStarted = (Action)obj2;
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
				goto IL_027c;
			}
		}
		Action<Enemy, DamageContainer> b = OnEnemyDamaged;
		Delegate obj6 = Delegate.Combine(Enemy.A_Damage, b);
		if ((object)obj6 == null)
		{
			Enemy.A_Damage = null;
			return;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
		Action<Enemy, DamageContainer> action3 = default(Action<Enemy, DamageContainer>);
		bool flag4 = action3 == null;
		a_RunStarted = (Delegate)(object)typeof(Action<Enemy, DamageContainer>);
		action2 = (Action)obj6;
		obj3 = 0;
		obj4 = null;
		if (flag4)
		{
			goto IL_025c;
		}
		Enemy.A_Damage = action3;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
		object obj7 = default(object);
		bool flag5 = obj7 == null;
		a_RunStarted = (Delegate)(object)typeof(Action<Enemy, DamageContainer>);
		action2 = (Action)obj6;
		obj3 = 0;
		obj4 = null;
		if (!flag5)
		{
			return;
		}
		goto IL_026c;
		IL_026c:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_025c;
		IL_027c:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		return;
		IL_025c:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_027c;
	}

	public static void Cleanup()
	{
		//IL_019d: Expected O, but got I4
		//IL_0210: Expected O, but got I4
		//IL_0226: Expected I, but got O
		//IL_0119: Expected O, but got I4
		//IL_016d: Expected O, but got I4
		Delegate a_RunStarted = GameManager.A_RunStarted;
		Action action = OnNewRun;
		Delegate obj = Delegate.Remove(GameManager.A_RunStarted, action);
		Action action2;
		object obj3;
		Delegate obj4;
		if ((object)obj == null)
		{
			GameManager.A_RunStarted = null;
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
				goto IL_026c;
			}
			GameManager.A_RunStarted = (Action)obj2;
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
				goto IL_027c;
			}
		}
		Action<Enemy, DamageContainer> value = OnEnemyDamaged;
		Delegate obj6 = Delegate.Remove(Enemy.A_Damage, value);
		if ((object)obj6 == null)
		{
			Enemy.A_Damage = null;
			return;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
		Action<Enemy, DamageContainer> action3 = default(Action<Enemy, DamageContainer>);
		bool flag4 = action3 == null;
		a_RunStarted = (Delegate)(object)typeof(Action<Enemy, DamageContainer>);
		action2 = (Action)obj6;
		obj3 = 0;
		obj4 = null;
		if (flag4)
		{
			goto IL_025c;
		}
		Enemy.A_Damage = action3;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
		object obj7 = default(object);
		bool flag5 = obj7 == null;
		a_RunStarted = (Delegate)(object)typeof(Action<Enemy, DamageContainer>);
		action2 = (Action)obj6;
		obj3 = 0;
		obj4 = null;
		if (!flag5)
		{
			return;
		}
		goto IL_026c;
		IL_026c:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_025c;
		IL_027c:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		return;
		IL_025c:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_027c;
	}

	private static void OnNewRun()
	{
		//IL_003e: Expected I, but got O
		Dictionary<string, float> dictionary = new Dictionary<string, float>();
		stats = dictionary;
		Dictionary<string, DamageSource> dictionary2 = (Dictionary<string, DamageSource>)(object)new Dictionary<object, object>(64);
		damageSources = dictionary2;
		List<MyAchievement> list = new List<MyAchievement>();
		achievements = list;
		nint num = (nint)typeof(Enemy);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v118 @ rcx_v23 (Il2CppClass<Assets.Scripts.Actors.Enemies.Enemy>)+E4]");
		if ((nint)0 == 0)
		{
			Enemy.deaths = 0;
		}
		else
		{
			Enemy.deaths = 0;
		}
	}

	private static void Reset()
	{
		//IL_0039: Expected I, but got O
		Dictionary<string, float> dictionary = new Dictionary<string, float>();
		stats = dictionary;
		Dictionary<string, DamageSource> dictionary2 = (Dictionary<string, DamageSource>)(object)new Dictionary<object, object>(64);
		damageSources = dictionary2;
		List<MyAchievement> list = new List<MyAchievement>();
		achievements = list;
		nint num = (nint)typeof(Enemy);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v89 @ rcx_v21 (Il2CppClass<Assets.Scripts.Actors.Enemies.Enemy>)+E4]");
		if ((nint)0 == 0)
		{
			Enemy.deaths = 0;
		}
		else
		{
			Enemy.deaths = 0;
		}
	}

	public static void AddValue(EMyStat stat, int value)
	{
		string statString = TrackStats.GetStatString(stat);
		Cpp2ILHelpers.NoteDecompilerIssue("Invalid instruction: 62 Invalid \"Jump target not found in method: 0x1804111B0\"");
	}

	public static int GetStat(EMyStat stat)
	{
		//IL_0026: Expected I4, but got O
		string statString = TrackStats.GetStatString(stat);
		Cpp2ILHelpers.NoteDecompilerIssue("Invalid instruction: 58 Invalid \"Jump target not found in method: 0x180411610\"");
		return (int)statString;
	}

	public static void AddValue(string stat, int value)
	{
		//IL_004a: Expected F4, but got I4
		if (!stats.TryGetValue(stat, out var value2))
		{
			((Dictionary<object, float>)(object)stats).Add((object)stat, 0f);
			value2 = 0f;
		}
		float value3 = 0f + (float)value;
		((Dictionary<object, float>)(object)stats).set_Item((object)stat, value3);
		Action<string, float> a_StatChange = A_StatChange;
		if (A_StatChange != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v240 @ rax_v14 (System.Action`2<System.String, System.Single>)+18] (should have been resolved before IL gen)");
		}
	}

	public static int GetStat(string stat)
	{
		//IL_0074: Expected I4, but got O
		//IL_0056: Expected I4, but got F4
		if (stats != null)
		{
			if (!stats.ContainsKey(stat))
			{
				return 0;
			}
			if (stats != null)
			{
				float num = ((Dictionary<object, float>)(object)stats).get_Item((object)stat);
				return (int)stats.get_Item((string)null);
			}
		}
		NullReferenceException ex = new NullReferenceException();
		return (int)ex;
	}

	public static void AddAchievement(MyAchievement achievement)
	{
		List<object> list = (List<object>)(object)achievements;
		int version = list._version + 1;
		list._version = version;
		object[] items = list._items;
		if (list._size >= items.Length)
		{
			list.AddWithResize((object)achievement);
			return;
		}
		int size = list._size + 1;
		list._size = size;
		int num = default(int);
		items[num] = achievement;
	}

	private unsafe static void OnEnemyDamaged(Enemy enemy, DamageContainer dc)
	{
		//IL_0077: Unknown result type (might be due to invalid IL or missing references)
		//IL_007c: Expected O, but got Unknown
		//IL_0091: Expected F4, but got Ref
		if (!((Dictionary<object, object>)(object)damageSources).TryGetValue((object)dc.damageSource, out object value))
		{
			DamageSource damageSource = new DamageSource(null, (nint)(&value));
			damageSource.damageSource = dc.damageSource;
			damageSource.addedAtTime = MyTime.time;
			((Dictionary<object, object>)(object)damageSources).Add((object)dc.damageSource, (object)damageSource);
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v225 @ rax_v13 (Assets.Scripts.Saves___Serialization.Progression.Stats.DamageSource)+1C]");
		object obj = 0 + dc.damage;
	}

	static RunStats()
	{
		Dictionary<string, float> dictionary = new Dictionary<string, float>();
		stats = dictionary;
		Dictionary<string, DamageSource> dictionary2 = (Dictionary<string, DamageSource>)(object)new Dictionary<object, object>(64);
		damageSources = dictionary2;
		List<MyAchievement> list = new List<MyAchievement>();
		achievements = list;
	}
}
