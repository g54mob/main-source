using System;
using System.Collections.Generic;
using Assets.Scripts.Saves___Serialization.Progression.Stats;
using Assets.Scripts.Utility;
using Cpp2ILInjected;
using Steamworks;
using UnityEngine;

namespace Assets.Scripts.Steam;

public static class SteamStatsManager
{
	public static bool areStatsReady = false;

	private static Callback<UserStatsReceived_t> m_UserStatsReceived;

	private static bool hasQueuedUpload;

	private static float uploadReadyAtTime;

	private static float uploadCooldown = 60f;

	private static Dictionary<string, int> cachedStatUpdates;

	private static float setCachedStatsInterval;

	private static float nextSetCachedStatsTime;

	private static bool hasChanges;

	public static void Init()
	{
		//IL_04c0: Expected O, but got I4
		//IL_050c: Expected O, but got I4
		//IL_0522: Expected I, but got O
		//IL_0548: Expected O, but got I4
		//IL_055e: Expected I, but got O
		//IL_0584: Expected O, but got I4
		//IL_059a: Expected I, but got O
		//IL_05c0: Expected O, but got I4
		//IL_05d6: Expected I, but got O
		//IL_05fc: Expected O, but got I4
		//IL_0612: Expected I, but got O
		//IL_0638: Expected O, but got I4
		//IL_064e: Expected I, but got O
		//IL_0674: Expected O, but got I4
		//IL_068a: Expected I, but got O
		//IL_0402: Expected O, but got I4
		//IL_0456: Expected O, but got I4
		if (SteamManager.initialized)
		{
			bool flag = SteamUserStats.RequestCurrentStats();
		}
		Delegate a_UpdateComponents = SteamManager.A_UpdateComponents;
		Action action = Update;
		Delegate obj = Delegate.Combine(SteamManager.A_UpdateComponents, action);
		if ((object)obj == null)
		{
			SteamManager.A_UpdateComponents = null;
		}
		else
		{
			bool flag2 = (object)obj.GetType() != typeof(Action);
			Delegate obj2 = null;
			if (!flag2)
			{
				obj2 = obj;
			}
			object obj3;
			Delegate obj4;
			if ((object)obj2 == null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
				Action action2 = action;
				obj3 = 0;
				obj4 = obj;
				goto IL_06d0;
			}
			SteamManager.A_UpdateComponents = (Action)obj2;
			bool flag3 = (object)obj.GetType() != typeof(Action);
			Delegate obj5 = null;
			if (!flag3)
			{
				obj5 = obj;
			}
			bool flag4 = (object)obj5 == null;
			obj3 = 0;
			obj4 = obj;
			nint num = (nint)typeof(Action);
			if (flag4)
			{
				goto IL_06ea;
			}
		}
		Action b = RequestStats;
		Delegate obj6 = Delegate.Combine(SteamManager.A_Initialized, b);
		if ((object)obj6 == null)
		{
			SteamManager.A_Initialized = null;
		}
		else
		{
			bool flag5 = (object)obj6.GetType() != typeof(Action);
			Delegate obj7 = null;
			if (!flag5)
			{
				obj7 = obj6;
			}
			bool flag6 = (object)obj7 == null;
			object obj3 = 0;
			Delegate obj4 = obj6;
			nint num2 = (nint)typeof(Action);
			if (flag6)
			{
				goto IL_06f5;
			}
			SteamManager.A_Initialized = (Action)obj7;
			bool flag7 = (object)obj6.GetType() != typeof(Action);
			Delegate obj8 = null;
			if (!flag7)
			{
				obj8 = obj6;
			}
			bool flag8 = (object)obj8 == null;
			obj3 = 0;
			obj4 = obj6;
			nint num3 = (nint)typeof(Action);
			if (flag8)
			{
				goto IL_0705;
			}
		}
		Action b2 = QueueUpload;
		Delegate obj9 = Delegate.Combine(GameManager.A_GameOver, b2);
		if ((object)obj9 == null)
		{
			GameManager.A_GameOver = null;
		}
		else
		{
			bool flag9 = (object)obj9.GetType() != typeof(Action);
			Delegate obj10 = null;
			if (!flag9)
			{
				obj10 = obj9;
			}
			bool flag10 = (object)obj10 == null;
			object obj3 = 0;
			Delegate obj4 = obj9;
			nint num4 = (nint)typeof(Action);
			if (flag10)
			{
				goto IL_0715;
			}
			GameManager.A_GameOver = (Action)obj10;
			bool flag11 = (object)obj9.GetType() != typeof(Action);
			Delegate obj11 = null;
			if (!flag11)
			{
				obj11 = obj9;
			}
			bool flag12 = (object)obj11 == null;
			obj3 = 0;
			obj4 = obj9;
			nint num5 = (nint)typeof(Action);
			if (flag12)
			{
				goto IL_0725;
			}
		}
		Action b3 = QueueUpload;
		Delegate obj12 = Delegate.Combine(MainMenu.A_MenuOpened, b3);
		if ((object)obj12 == null)
		{
			MainMenu.A_MenuOpened = null;
		}
		else
		{
			bool flag13 = (object)obj12.GetType() != typeof(Action);
			Delegate obj13 = null;
			if (!flag13)
			{
				obj13 = obj12;
			}
			bool flag14 = (object)obj13 == null;
			object obj3 = 0;
			Delegate obj4 = obj12;
			nint num6 = (nint)typeof(Action);
			if (flag14)
			{
				goto IL_0735;
			}
			MainMenu.A_MenuOpened = (Action)obj13;
			bool flag15 = (object)obj12.GetType() != typeof(Action);
			Delegate obj14 = null;
			if (!flag15)
			{
				obj14 = obj12;
			}
			bool flag16 = (object)obj14 == null;
			obj3 = 0;
			obj4 = obj12;
			nint num7 = (nint)typeof(Action);
			if (flag16)
			{
				goto IL_0745;
			}
		}
		Action<string, MyStat> b4 = OnStatUpdated;
		Delegate obj15 = Delegate.Combine(MyStats.A_StatUpdated, b4);
		if ((object)obj15 == null)
		{
			MyStats.A_StatUpdated = null;
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			Action<string, MyStat> action3 = default(Action<string, MyStat>);
			bool flag17 = action3 == null;
			Action action2 = (Action)obj15;
			object obj3 = 0;
			Delegate obj4 = null;
			a_UpdateComponents = (Delegate)(object)typeof(Action<string, MyStat>);
			if (flag17)
			{
				goto IL_06c0;
			}
			MyStats.A_StatUpdated = action3;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			object obj16 = default(object);
			bool flag18 = obj16 == null;
			action2 = (Action)obj15;
			obj3 = 0;
			obj4 = null;
			a_UpdateComponents = (Delegate)(object)typeof(Action<string, MyStat>);
			if (flag18)
			{
				goto IL_06d0;
			}
		}
		Callback<UserStatsReceived_t>.DispatchDelegate func = OnUserStatsReceived;
		Callback<UserStatsReceived_t> userStatsReceived = Callback<UserStatsReceived_t>.Create(func);
		m_UserStatsReceived = userStatsReceived;
		return;
		IL_06d0:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_06c0;
		IL_06f5:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_06ea;
		IL_06ea:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		return;
		IL_06c0:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_0745;
		IL_0745:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_0735;
		IL_0705:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_06f5;
		IL_0735:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_0725;
		IL_0725:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_0715;
		IL_0715:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_0705;
	}

	public static void OnDestroy()
	{
		//IL_0428: Expected O, but got I4
		//IL_046f: Expected O, but got I4
		//IL_0485: Expected I, but got O
		//IL_04ab: Expected O, but got I4
		//IL_04c1: Expected I, but got O
		//IL_04e7: Expected O, but got I4
		//IL_04fd: Expected I, but got O
		//IL_0523: Expected O, but got I4
		//IL_0539: Expected I, but got O
		//IL_055f: Expected O, but got I4
		//IL_0575: Expected I, but got O
		//IL_059b: Expected O, but got I4
		//IL_05b1: Expected I, but got O
		//IL_05d7: Expected O, but got I4
		//IL_05ed: Expected I, but got O
		//IL_03a4: Expected O, but got I4
		//IL_03f8: Expected O, but got I4
		Delegate a_UpdateComponents = SteamManager.A_UpdateComponents;
		Action action = Update;
		Delegate obj = Delegate.Remove(SteamManager.A_UpdateComponents, action);
		Action action2;
		object obj3;
		Delegate obj4;
		if ((object)obj == null)
		{
			SteamManager.A_UpdateComponents = null;
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
				goto IL_0633;
			}
			SteamManager.A_UpdateComponents = (Action)obj2;
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
				goto IL_0674;
			}
		}
		Action value = RequestStats;
		Delegate obj6 = Delegate.Remove(SteamManager.A_Initialized, value);
		if ((object)obj6 == null)
		{
			SteamManager.A_Initialized = null;
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
				goto IL_067f;
			}
			SteamManager.A_Initialized = (Action)obj7;
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
				goto IL_068f;
			}
		}
		Action value2 = QueueUpload;
		Delegate obj9 = Delegate.Remove(GameManager.A_GameOver, value2);
		if ((object)obj9 == null)
		{
			GameManager.A_GameOver = null;
		}
		else
		{
			bool flag8 = (object)obj9.GetType() != typeof(Action);
			Delegate obj10 = null;
			if (!flag8)
			{
				obj10 = obj9;
			}
			bool flag9 = (object)obj10 == null;
			obj3 = 0;
			obj4 = obj9;
			nint num4 = (nint)typeof(Action);
			if (flag9)
			{
				goto IL_069f;
			}
			GameManager.A_GameOver = (Action)obj10;
			bool flag10 = (object)obj9.GetType() != typeof(Action);
			Delegate obj11 = null;
			if (!flag10)
			{
				obj11 = obj9;
			}
			bool flag11 = (object)obj11 == null;
			obj3 = 0;
			obj4 = obj9;
			nint num5 = (nint)typeof(Action);
			if (flag11)
			{
				goto IL_06af;
			}
		}
		Action value3 = QueueUpload;
		Delegate obj12 = Delegate.Remove(MainMenu.A_MenuOpened, value3);
		if ((object)obj12 == null)
		{
			MainMenu.A_MenuOpened = null;
		}
		else
		{
			bool flag12 = (object)obj12.GetType() != typeof(Action);
			Delegate obj13 = null;
			if (!flag12)
			{
				obj13 = obj12;
			}
			bool flag13 = (object)obj13 == null;
			obj3 = 0;
			obj4 = obj12;
			nint num6 = (nint)typeof(Action);
			if (flag13)
			{
				goto IL_06bf;
			}
			MainMenu.A_MenuOpened = (Action)obj13;
			bool flag14 = (object)obj12.GetType() != typeof(Action);
			Delegate obj14 = null;
			if (!flag14)
			{
				obj14 = obj12;
			}
			bool flag15 = (object)obj14 == null;
			obj3 = 0;
			obj4 = obj12;
			nint num7 = (nint)typeof(Action);
			if (flag15)
			{
				goto IL_06cf;
			}
		}
		Action<string, MyStat> value4 = OnStatUpdated;
		Delegate obj15 = Delegate.Remove(MyStats.A_StatUpdated, value4);
		if ((object)obj15 == null)
		{
			MyStats.A_StatUpdated = null;
			return;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
		Action<string, MyStat> action3 = default(Action<string, MyStat>);
		bool flag16 = action3 == null;
		a_UpdateComponents = (Delegate)(object)typeof(Action<string, MyStat>);
		action2 = (Action)obj15;
		obj3 = 0;
		obj4 = null;
		if (flag16)
		{
			goto IL_0623;
		}
		MyStats.A_StatUpdated = action3;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
		object obj16 = default(object);
		bool flag17 = obj16 == null;
		a_UpdateComponents = (Delegate)(object)typeof(Action<string, MyStat>);
		action2 = (Action)obj15;
		obj3 = 0;
		obj4 = null;
		if (!flag17)
		{
			return;
		}
		goto IL_0633;
		IL_0674:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		return;
		IL_0623:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_06cf;
		IL_06cf:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_06bf;
		IL_068f:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_067f;
		IL_06bf:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_06af;
		IL_06af:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_069f;
		IL_069f:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_068f;
		IL_067f:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_0674;
		IL_0633:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_0623;
	}

	public static void RequestStats()
	{
		bool flag = SteamUserStats.RequestCurrentStats();
	}

	private static void QueueUpload()
	{
		if (hasChanges)
		{
			hasQueuedUpload = true;
		}
	}

	private static void Update()
	{
		float time = Time.time;
		if (time > nextSetCachedStatsTime)
		{
			SetCachedStats();
			float time2 = Time.time;
			float num = time2 + setCachedStatsInterval;
			nextSetCachedStatsTime = num;
		}
		if (!hasQueuedUpload)
		{
			return;
		}
		float time3 = Time.time;
		if (!(time3 > uploadReadyAtTime) || !hasChanges)
		{
			return;
		}
		float time4 = Time.time;
		if (!(uploadReadyAtTime > time4) && (!(GameManager.Instance != null) || MyTime.paused))
		{
			float time5 = Time.time;
			float num2 = time5 + uploadCooldown;
			uploadReadyAtTime = num2;
			if (!areStatsReady)
			{
				bool flag = SteamUserStats.RequestCurrentStats();
				return;
			}
			hasChanges = false;
			hasQueuedUpload = false;
			bool flag2 = SteamUserStats.StoreStats();
		}
	}

	private static void TryUploadStats()
	{
		if (!hasChanges)
		{
			return;
		}
		float time = Time.time;
		if (!(uploadReadyAtTime > time) && (!(GameManager.Instance != null) || MyTime.paused))
		{
			float time2 = Time.time;
			float num = time2 + uploadCooldown;
			uploadReadyAtTime = num;
			if (!areStatsReady)
			{
				bool flag = SteamUserStats.RequestCurrentStats();
				return;
			}
			hasChanges = false;
			hasQueuedUpload = false;
			bool flag2 = SteamUserStats.StoreStats();
		}
	}

	private static void OnStatUpdated(string arg1, MyStat arg2)
	{
		//IL_01ea: Expected I, but got O
		//IL_01a3: Expected I4, but got F8
		if (arg2 == null)
		{
			return;
		}
		nint num = (nint)typeof(Math);
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"comisd xmm6,xmm0\"");
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v105 @ rcx_v4 (Il2CppClass<System.Math>)+E4]");
		double num2;
		int num4 = default(int);
		int value;
		if ((nint)0 >= (nint)0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1802FD990");
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"ucomisd xmm0,xmm1\"");
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 00000001803EF26Eh\"");
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v105 @ rcx_v4 (Il2CppClass<System.Math>)+E4]");
			if ((nint)0 != 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"addsd xmm6,xmm1\"");
				num2 = Math.Floor(arg2.value);
				goto IL_019b;
			}
			int num3 = num4 & 1;
			bool flag = num3 == 0;
			value = num4;
			if (!flag)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"addsd xmm6,qword ptr [18262EC98h]\"");
				value = num4;
			}
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1802FD990");
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"ucomisd xmm0,qword ptr [18262ED10h]\"");
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 00000001803EF2A6h\"");
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v105 @ rcx_v4 (Il2CppClass<System.Math>)+E4]");
			if ((nint)0 != 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"subsd xmm6,qword ptr [18262EC90h]\"");
				num2 = Math.Ceiling(arg2.value);
				goto IL_019b;
			}
			int num5 = num4 & 1;
			bool flag2 = num5 == 0;
			value = num4;
			if (!flag2)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"subsd xmm6,qword ptr [18262EC98h]\"");
				value = num4;
			}
		}
		goto IL_01a8;
		IL_019b:
		value = (int)num2;
		goto IL_01a8;
		IL_01a8:
		((Dictionary<object, int>)(object)cachedStatUpdates).set_Item((object)arg1, value);
	}

	private static void SetCachedStats()
	{
		if (!areStatsReady)
		{
			return;
		}
		if (cachedStatUpdates != null)
		{
			int count = cachedStatUpdates.Count;
			if (count <= 0)
			{
				return;
			}
			if (cachedStatUpdates != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180D598D0");
				Dictionary<string, int>.Enumerator enumerator = default(Dictionary<string, int>.Enumerator);
				string pchName = default(string);
				int nData = default(int);
				while (enumerator.MoveNext())
				{
					bool flag = SteamUserStats.SetStat(pchName, nData);
				}
				enumerator.Dispose();
				if (cachedStatUpdates != null)
				{
					cachedStatUpdates.Clear();
					hasChanges = true;
					return;
				}
			}
		}
		throw new NullReferenceException();
	}

	private unsafe static void OnUserStatsReceived(UserStatsReceived_t param)
	{
		//IL_0043: Expected O, but got Ref
		object obj = default(object);
		if ((long)obj == (long)SteamManager.steamId && param.m_nGameID == (ulong)(long)SteamManager.APP_ID)
		{
			if (param.m_eResult == EResult.k_EResultOK)
			{
				areStatsReady = true;
				SteamAchievementsManager.CheckAchievements();
			}
			else
			{
				ulong num = default(ulong);
				string text = ((Enum)(&num)).ToString();
				string text2 = "Failed to get steam stats: " + text;
			}
		}
	}

	static SteamStatsManager()
	{
		Dictionary<string, int> dictionary = new Dictionary<string, int>();
		cachedStatUpdates = dictionary;
		setCachedStatsInterval = 1f;
		hasChanges = false;
	}
}
