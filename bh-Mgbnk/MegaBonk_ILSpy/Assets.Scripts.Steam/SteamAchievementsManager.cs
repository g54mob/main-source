using System;
using System.Collections.Generic;
using Assets.Scripts.Saves___Serialization.Progression.Achievements;
using Assets.Scripts.Saves___Serialization.Progression.Unlocks;
using Cpp2ILInjected;
using Steamworks;
using UnityEngine;

namespace Assets.Scripts.Steam;

public static class SteamAchievementsManager
{
	public static bool ENABLED = true;

	private static bool hasQueuedUpload;

	private static float uploadAtTime;

	public static void Init()
	{
		//IL_0179: Expected I, but got O
		//IL_018a: Expected O, but got I4
		//IL_008a: Expected I, but got O
		//IL_009b: Expected O, but got I4
		//IL_01e4: Expected I, but got O
		//IL_01f5: Expected O, but got I4
		//IL_020b: Expected I, but got O
		//IL_0231: Expected I, but got O
		//IL_0242: Expected O, but got I4
		//IL_0258: Expected I, but got O
		Action<string> b = TryUnlockAchievement;
		Delegate obj = Delegate.Combine(MyAchievements.A_TryUnlock, b);
		nint num;
		Delegate obj2;
		object obj3;
		Delegate obj4;
		nint num2;
		if ((object)obj == null)
		{
			MyAchievements.A_TryUnlock = (Action<string>)obj;
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			Action<string> action = default(Action<string>);
			if (action == null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
				num = (nint)typeof(Action<string>);
				obj2 = obj;
				obj3 = 0;
				obj4 = null;
				goto IL_029e;
			}
			MyAchievements.A_TryUnlock = action;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			object obj5 = default(object);
			bool flag = obj5 == null;
			num2 = (nint)typeof(Action<string>);
			obj2 = obj;
			obj3 = 0;
			obj4 = null;
			if (flag)
			{
				goto IL_0199;
			}
		}
		Action action2 = Update;
		Delegate obj6 = Delegate.Combine(SteamManager.A_UpdateComponents, action2);
		if ((object)obj6 == null)
		{
			SteamManager.A_UpdateComponents = null;
			return;
		}
		bool flag2 = (object)obj6.GetType() != typeof(Action);
		Delegate obj7 = null;
		if (!flag2)
		{
			obj7 = obj6;
		}
		bool flag3 = (object)obj7 == null;
		num2 = (nint)SteamManager.A_UpdateComponents;
		obj2 = action2;
		obj3 = 0;
		obj4 = obj6;
		nint num3 = (nint)typeof(Action);
		if (flag3)
		{
			goto IL_028e;
		}
		SteamManager.A_UpdateComponents = (Action)obj7;
		bool flag4 = (object)obj6.GetType() != typeof(Action);
		Delegate obj8 = null;
		if (!flag4)
		{
			obj8 = obj6;
		}
		bool flag5 = (object)obj8 == null;
		num = (nint)SteamManager.A_UpdateComponents;
		obj2 = action2;
		obj3 = 0;
		obj4 = obj6;
		nint num4 = (nint)typeof(Action);
		if (!flag5)
		{
			return;
		}
		goto IL_029e;
		IL_028e:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_0199;
		IL_0199:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		return;
		IL_029e:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		num2 = num;
		goto IL_028e;
	}

	public static void OnDestroy()
	{
		//IL_0179: Expected I, but got O
		//IL_018a: Expected O, but got I4
		//IL_008a: Expected I, but got O
		//IL_009b: Expected O, but got I4
		//IL_01e4: Expected I, but got O
		//IL_01f5: Expected O, but got I4
		//IL_020b: Expected I, but got O
		//IL_0231: Expected I, but got O
		//IL_0242: Expected O, but got I4
		//IL_0258: Expected I, but got O
		Action<string> value = TryUnlockAchievement;
		Delegate obj = Delegate.Remove(MyAchievements.A_TryUnlock, value);
		nint num;
		Delegate obj2;
		object obj3;
		Delegate obj4;
		nint num2;
		if ((object)obj == null)
		{
			MyAchievements.A_TryUnlock = (Action<string>)obj;
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			Action<string> action = default(Action<string>);
			if (action == null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
				num = (nint)typeof(Action<string>);
				obj2 = obj;
				obj3 = 0;
				obj4 = null;
				goto IL_029e;
			}
			MyAchievements.A_TryUnlock = action;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			object obj5 = default(object);
			bool flag = obj5 == null;
			num2 = (nint)typeof(Action<string>);
			obj2 = obj;
			obj3 = 0;
			obj4 = null;
			if (flag)
			{
				goto IL_0199;
			}
		}
		Action action2 = Update;
		Delegate obj6 = Delegate.Remove(SteamManager.A_UpdateComponents, action2);
		if ((object)obj6 == null)
		{
			SteamManager.A_UpdateComponents = null;
			return;
		}
		bool flag2 = (object)obj6.GetType() != typeof(Action);
		Delegate obj7 = null;
		if (!flag2)
		{
			obj7 = obj6;
		}
		bool flag3 = (object)obj7 == null;
		num2 = (nint)SteamManager.A_UpdateComponents;
		obj2 = action2;
		obj3 = 0;
		obj4 = obj6;
		nint num3 = (nint)typeof(Action);
		if (flag3)
		{
			goto IL_028e;
		}
		SteamManager.A_UpdateComponents = (Action)obj7;
		bool flag4 = (object)obj6.GetType() != typeof(Action);
		Delegate obj8 = null;
		if (!flag4)
		{
			obj8 = obj6;
		}
		bool flag5 = (object)obj8 == null;
		num = (nint)SteamManager.A_UpdateComponents;
		obj2 = action2;
		obj3 = 0;
		obj4 = obj6;
		nint num4 = (nint)typeof(Action);
		if (!flag5)
		{
			return;
		}
		goto IL_029e;
		IL_028e:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_0199;
		IL_0199:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		return;
		IL_029e:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		num2 = num;
		goto IL_028e;
	}

	private static void Update()
	{
		if (ENABLED && hasQueuedUpload)
		{
			float time = Time.time;
			if (time > uploadAtTime)
			{
				hasQueuedUpload = false;
				bool flag = SteamUserStats.StoreStats();
			}
		}
	}

	public static void TryUnlockAchievement(string achievementKey)
	{
		if (ENABLED && SteamUserStats.GetAchievement(achievementKey, out var pbAchieved) && !pbAchieved && SteamUserStats.SetAchievement(achievementKey))
		{
			float time = Time.time;
			float num = time + 5f;
			uploadAtTime = num;
			hasQueuedUpload = true;
		}
	}

	private static void QueueUpload()
	{
		float time = Time.time;
		float num = time + 5f;
		uploadAtTime = num;
		hasQueuedUpload = true;
	}

	private static void TryUploadAchievements()
	{
		bool flag = SteamUserStats.StoreStats();
	}

	public static void CheckAchievements()
	{
		DataManager instance = DataManager.Instance;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @181126F30");
		List<object>.Enumerator enumerator = default(List<object>.Enumerator);
		MyAchievement myAchievement = default(MyAchievement);
		while (true)
		{
			if (enumerator.MoveNext())
			{
				if (MyAchievements.IsUnlocked(myAchievement))
				{
					if ((object)myAchievement == null)
					{
						break;
					}
					TryUnlockAchievement(myAchievement.internalName);
				}
				continue;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1803321E0");
			return;
		}
		throw new NullReferenceException();
	}
}
