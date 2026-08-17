using System;
using System.Runtime.CompilerServices;
using Assets.Scripts.Steam;
using Cpp2ILInjected;
using Discord;
using Inventory__Items__Pickups.Xp_and_Levels;
using Steamworks;

namespace Assets.Scripts.Stats___Achievements.Discord;

public static class DiscordRichPresence
{
	private static Activity activity;

	private static long startTime;

	private static bool queuedUpdate;

	public static void Init()
	{
		//IL_035d: Expected I, but got O
		//IL_0366: Expected O, but got I4
		//IL_03d9: Expected O, but got I4
		//IL_03ef: Expected I, but got O
		//IL_0415: Expected O, but got I4
		//IL_042b: Expected I, but got O
		//IL_0451: Expected O, but got I4
		//IL_0467: Expected I, but got O
		//IL_01f2: Expected O, but got I4
		//IL_0246: Expected O, but got I4
		//IL_04dd: Expected O, but got I4
		//IL_04f3: Expected I, but got O
		//IL_0526: Expected I, but got O
		//IL_052f: Expected O, but got I4
		Delegate a_RunStarted = GameManager.A_RunStarted;
		Action action = RunStarted;
		Delegate obj = Delegate.Combine(GameManager.A_RunStarted, action);
		Action action2;
		nint num;
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
				num = (nint)typeof(Action);
				obj3 = 0;
				obj4 = obj;
				goto IL_0580;
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
			nint num2 = (nint)typeof(Action);
			if (flag3)
			{
				goto IL_0545;
			}
		}
		Action b = UpdateInGame;
		Delegate obj6 = Delegate.Combine(GameManager.A_StageStarted, b);
		if ((object)obj6 == null)
		{
			GameManager.A_StageStarted = null;
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
			nint num3 = (nint)typeof(Action);
			if (flag5)
			{
				goto IL_0550;
			}
			GameManager.A_StageStarted = (Action)obj7;
			bool flag6 = (object)obj6.GetType() != typeof(Action);
			Delegate obj8 = null;
			if (!flag6)
			{
				obj8 = obj6;
			}
			bool flag7 = (object)obj8 == null;
			obj3 = 0;
			obj4 = obj6;
			nint num4 = (nint)typeof(Action);
			if (flag7)
			{
				goto IL_0560;
			}
		}
		Action<int> b2 = OnLevelUp;
		Delegate obj9 = Delegate.Combine(PlayerXp.A_LevelUp, b2);
		if ((object)obj9 == null)
		{
			PlayerXp.A_LevelUp = null;
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			Action<int> action3 = default(Action<int>);
			bool flag8 = action3 == null;
			a_RunStarted = (Delegate)(object)typeof(Action<int>);
			action2 = (Action)obj9;
			obj3 = 0;
			obj4 = null;
			if (flag8)
			{
				goto IL_049d;
			}
			PlayerXp.A_LevelUp = action3;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			object obj10 = default(object);
			bool flag9 = obj10 == null;
			a_RunStarted = (Delegate)(object)typeof(Action<int>);
			action2 = (Action)obj9;
			obj3 = 0;
			obj4 = null;
			if (flag9)
			{
				goto IL_04ad;
			}
		}
		a_RunStarted = MainMenu.A_MenuOpened;
		Action action4 = UpdateMainMenu;
		Delegate obj11 = Delegate.Combine(MainMenu.A_MenuOpened, action4);
		if ((object)obj11 == null)
		{
			MainMenu.A_MenuOpened = null;
			return;
		}
		bool flag10 = (object)obj11.GetType() != typeof(Action);
		Delegate obj12 = null;
		if (!flag10)
		{
			obj12 = obj11;
		}
		bool flag11 = (object)obj12 == null;
		action2 = action4;
		obj3 = 0;
		obj4 = obj11;
		nint num5 = (nint)typeof(Action);
		if (flag11)
		{
			goto IL_0570;
		}
		MainMenu.A_MenuOpened = (Action)obj12;
		bool flag12 = (object)obj11.GetType() != typeof(Action);
		Delegate obj13 = null;
		if (!flag12)
		{
			obj13 = obj11;
		}
		bool flag13 = (object)obj13 == null;
		action2 = action4;
		num = (nint)typeof(Action);
		obj3 = 0;
		obj4 = obj11;
		if (!flag13)
		{
			return;
		}
		goto IL_0580;
		IL_0580:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_0570;
		IL_0570:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_04ad;
		IL_0550:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_0545;
		IL_049d:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_0560;
		IL_04ad:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_049d;
		IL_0545:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		return;
		IL_0560:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_0550;
	}

	public static void OnDestroy()
	{
		//IL_035d: Expected I, but got O
		//IL_0366: Expected O, but got I4
		//IL_03d9: Expected O, but got I4
		//IL_03ef: Expected I, but got O
		//IL_0415: Expected O, but got I4
		//IL_042b: Expected I, but got O
		//IL_0451: Expected O, but got I4
		//IL_0467: Expected I, but got O
		//IL_01f2: Expected O, but got I4
		//IL_0246: Expected O, but got I4
		//IL_04dd: Expected O, but got I4
		//IL_04f3: Expected I, but got O
		//IL_0526: Expected I, but got O
		//IL_052f: Expected O, but got I4
		Delegate a_RunStarted = GameManager.A_RunStarted;
		Action action = RunStarted;
		Delegate obj = Delegate.Remove(GameManager.A_RunStarted, action);
		Action action2;
		nint num;
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
				num = (nint)typeof(Action);
				obj3 = 0;
				obj4 = obj;
				goto IL_0580;
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
			nint num2 = (nint)typeof(Action);
			if (flag3)
			{
				goto IL_0545;
			}
		}
		Action value = UpdateInGame;
		Delegate obj6 = Delegate.Remove(GameManager.A_StageStarted, value);
		if ((object)obj6 == null)
		{
			GameManager.A_StageStarted = null;
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
			nint num3 = (nint)typeof(Action);
			if (flag5)
			{
				goto IL_0550;
			}
			GameManager.A_StageStarted = (Action)obj7;
			bool flag6 = (object)obj6.GetType() != typeof(Action);
			Delegate obj8 = null;
			if (!flag6)
			{
				obj8 = obj6;
			}
			bool flag7 = (object)obj8 == null;
			obj3 = 0;
			obj4 = obj6;
			nint num4 = (nint)typeof(Action);
			if (flag7)
			{
				goto IL_0560;
			}
		}
		Action<int> value2 = OnLevelUp;
		Delegate obj9 = Delegate.Remove(PlayerXp.A_LevelUp, value2);
		if ((object)obj9 == null)
		{
			PlayerXp.A_LevelUp = null;
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			Action<int> action3 = default(Action<int>);
			bool flag8 = action3 == null;
			a_RunStarted = (Delegate)(object)typeof(Action<int>);
			action2 = (Action)obj9;
			obj3 = 0;
			obj4 = null;
			if (flag8)
			{
				goto IL_049d;
			}
			PlayerXp.A_LevelUp = action3;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			object obj10 = default(object);
			bool flag9 = obj10 == null;
			a_RunStarted = (Delegate)(object)typeof(Action<int>);
			action2 = (Action)obj9;
			obj3 = 0;
			obj4 = null;
			if (flag9)
			{
				goto IL_04ad;
			}
		}
		a_RunStarted = MainMenu.A_MenuOpened;
		Action action4 = UpdateMainMenu;
		Delegate obj11 = Delegate.Remove(MainMenu.A_MenuOpened, action4);
		if ((object)obj11 == null)
		{
			MainMenu.A_MenuOpened = null;
			return;
		}
		bool flag10 = (object)obj11.GetType() != typeof(Action);
		Delegate obj12 = null;
		if (!flag10)
		{
			obj12 = obj11;
		}
		bool flag11 = (object)obj12 == null;
		action2 = action4;
		obj3 = 0;
		obj4 = obj11;
		nint num5 = (nint)typeof(Action);
		if (flag11)
		{
			goto IL_0570;
		}
		MainMenu.A_MenuOpened = (Action)obj12;
		bool flag12 = (object)obj11.GetType() != typeof(Action);
		Delegate obj13 = null;
		if (!flag12)
		{
			obj13 = obj11;
		}
		bool flag13 = (object)obj13 == null;
		action2 = action4;
		num = (nint)typeof(Action);
		obj3 = 0;
		obj4 = obj11;
		if (!flag13)
		{
			return;
		}
		goto IL_0580;
		IL_0580:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_0570;
		IL_0570:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_04ad;
		IL_0550:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_0545;
		IL_049d:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_0560;
		IL_04ad:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_049d;
		IL_0545:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		return;
		IL_0560:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_0550;
	}

	private static void RunStarted()
	{
		//IL_004a: Expected I8, but got I4
		if (SteamManager.initialized)
		{
			uint serverRealTime = SteamUtils.GetServerRealTime();
			startTime = (int)serverRealTime;
			UpdateInGame();
		}
	}

	private static void OnLevelUp(int level)
	{
		queuedUpdate = true;
	}

	public static void Update()
	{
		if (DiscordManager.Instance != null && queuedUpdate)
		{
			queuedUpdate = false;
			UpdateInGame();
		}
	}

	public unsafe static void UpdateInGame()
	{
		//IL_0008: Expected O, but got Ref
		//IL_02fc: Expected I, but got O
		//IL_03d8: Expected O, but got I
		//IL_03ef: Expected I, but got O
		//IL_0413: Expected I, but got O
		//IL_00d4: Expected I, but got O
		//IL_00f7: Expected I, but got O
		//IL_031a: Expected O, but got Ref
		//IL_0340: Expected I, but got O
		//IL_036a: Expected O, but got I
		//IL_0141: Expected I, but got O
		//IL_039a: Expected O, but got Ref
		//IL_0253: Expected I, but got O
		//IL_02c5: Expected O, but got Ref
		//IL_016b: Expected I, but got O
		//IL_01a1: Expected I, but got O
		//IL_0213: Expected O, but got Ref
		object obj2 = default(object);
		object obj = (object)(&obj2);
		nint num = (nint)typeof(DiscordRichPresence);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v48 @ rax_v3 (Il2CppClass<Assets.Scripts.Stats___Achievements.Discord.DiscordRichPresence>)+B8]");
		object obj3 = (nint)0 + (nint)56;
		obj3 = "megabonk";
		nint num2 = (nint)typeof(DiscordRichPresence);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v59 @ rax_v6 (Il2CppClass<Assets.Scripts.Stats___Achievements.Discord.DiscordRichPresence>)+B8]");
		nint num3 = 0;
		nint num4 = (nint)typeof(DiscordRichPresence);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v66 @ rax_v9 (Il2CppClass<Assets.Scripts.Stats___Achievements.Discord.DiscordRichPresence>)+B8]");
		nint num5 = 0;
		string playerLevel = SteamRichPresenceManager.GetPlayerLevel();
		string character = SteamRichPresenceManager.GetCharacter();
		string mapString = SteamRichPresenceManager.GetMapString();
		string text = "Lvl " + playerLevel + " " + character + " on " + mapString;
		nint num6 = (nint)typeof(DiscordRichPresence);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v335 @ rcx_v24 (Il2CppClass<Assets.Scripts.Stats___Achievements.Discord.DiscordRichPresence>)+B8]");
		nint num7 = 0;
		nint num8 = (nint)typeof(DiscordRichPresence);
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v341 @ r8_v4 (Il2CppClass<Assets.Scripts.Stats___Achievements.Discord.DiscordRichPresence>)+B8]");
		nint num9 = 0;
		_ = startTime;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-59]");
		_ = 0;
		ECharacter enumCharacter = SteamRichPresenceManager.GetEnumCharacter();
		_ = typeof(ECharacter);
		Enum obj4 = (Enum)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 89));
		_ = -1;
		string text2 = obj4.ToString();
		nint num10 = (nint)typeof(DiscordRichPresence);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v384 @ rdx_v20 (Il2CppClass<Assets.Scripts.Stats___Achievements.Discord.DiscordRichPresence>)+B8]");
		nint num11 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v388 @ rdx_v21 (Il2CppStaticFields<Assets.Scripts.Stats___Achievements.Discord.DiscordRichPresence>)+50]");
		if (text2 != (string)0)
		{
			nint num12 = (nint)typeof(DiscordRichPresence);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v445 @ rax_v46 (Il2CppClass<Assets.Scripts.Stats___Achievements.Discord.DiscordRichPresence>)+B8]");
			nint num13 = 0;
			Enum obj5 = (Enum)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 89));
			_ = typeof(ECharacter);
			_ = -1;
			string text3 = obj5.ToString();
			string text4 = text3.ToLower();
			nint num14 = (nint)typeof(DiscordRichPresence);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v468 @ rax_v51 (Il2CppClass<Assets.Scripts.Stats___Achievements.Discord.DiscordRichPresence>)+B8]");
			nint num15 = 0;
			string character2 = SteamRichPresenceManager.GetCharacter();
			nint num16 = (nint)typeof(DiscordRichPresence);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v488 @ rax_v57 (Il2CppClass<Assets.Scripts.Stats___Achievements.Discord.DiscordRichPresence>)+B8]");
			nint num17 = 0;
			_ = DiscordRichPresence.activity;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v489 @ rdx_v30 (Il2CppStaticFields<Assets.Scripts.Stats___Achievements.Discord.DiscordRichPresence>)+10]");
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v489 @ rdx_v30 (Il2CppStaticFields<Assets.Scripts.Stats___Achievements.Discord.DiscordRichPresence>)+20]");
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v489 @ rdx_v30 (Il2CppStaticFields<Assets.Scripts.Stats___Achievements.Discord.DiscordRichPresence>)+30]");
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v489 @ rdx_v30 (Il2CppStaticFields<Assets.Scripts.Stats___Achievements.Discord.DiscordRichPresence>)+40]");
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v489 @ rdx_v30 (Il2CppStaticFields<Assets.Scripts.Stats___Achievements.Discord.DiscordRichPresence>)+50]");
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v489 @ rdx_v30 (Il2CppStaticFields<Assets.Scripts.Stats___Achievements.Discord.DiscordRichPresence>)+60]");
			_ = 0;
			Activity activity = (Activity)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 57));
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v489 @ rdx_v30 (Il2CppStaticFields<Assets.Scripts.Stats___Achievements.Discord.DiscordRichPresence>)+70]");
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v489 @ rdx_v30 (Il2CppStaticFields<Assets.Scripts.Stats___Achievements.Discord.DiscordRichPresence>)+80]");
			_ = 0;
			DiscordManager.Instance.UpdateActivity(activity);
		}
		nint num18 = (nint)typeof(DiscordRichPresence);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v454 @ rax_v41 (Il2CppClass<Assets.Scripts.Stats___Achievements.Discord.DiscordRichPresence>)+B8]");
		nint num19 = 0;
		_ = DiscordRichPresence.activity;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v455 @ rdx_v24 (Il2CppStaticFields<Assets.Scripts.Stats___Achievements.Discord.DiscordRichPresence>)+10]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v455 @ rdx_v24 (Il2CppStaticFields<Assets.Scripts.Stats___Achievements.Discord.DiscordRichPresence>)+20]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v455 @ rdx_v24 (Il2CppStaticFields<Assets.Scripts.Stats___Achievements.Discord.DiscordRichPresence>)+30]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v455 @ rdx_v24 (Il2CppStaticFields<Assets.Scripts.Stats___Achievements.Discord.DiscordRichPresence>)+40]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v455 @ rdx_v24 (Il2CppStaticFields<Assets.Scripts.Stats___Achievements.Discord.DiscordRichPresence>)+50]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v455 @ rdx_v24 (Il2CppStaticFields<Assets.Scripts.Stats___Achievements.Discord.DiscordRichPresence>)+60]");
		_ = 0;
		Activity activity2 = (Activity)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 57));
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v455 @ rdx_v24 (Il2CppStaticFields<Assets.Scripts.Stats___Achievements.Discord.DiscordRichPresence>)+70]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v455 @ rdx_v24 (Il2CppStaticFields<Assets.Scripts.Stats___Achievements.Discord.DiscordRichPresence>)+80]");
		_ = 0;
		DiscordManager.Instance.UpdateActivity(activity2);
	}

	private unsafe static void TryUpdateCharacter(ECharacter character)
	{
		//IL_0083: Expected O, but got Ref
		//IL_0095: Expected I, but got O
		//IL_00bf: Expected O, but got I
		//IL_0013: Expected I, but got O
		//IL_00ea: Expected O, but got Ref
		//IL_003d: Expected I, but got O
		//IL_0074: Expected O, but got Ref
		IntPtr intPtr = default(IntPtr);
		string text = ((Enum)(&intPtr)).ToString();
		nint num = (nint)typeof(DiscordRichPresence);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v56 @ rdx_v3 (Il2CppClass<Assets.Scripts.Stats___Achievements.Discord.DiscordRichPresence>)+B8]");
		nint num2 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v60 @ rdx_v4 (Il2CppStaticFields<Assets.Scripts.Stats___Achievements.Discord.DiscordRichPresence>)+50]");
		if (text != (string)0)
		{
			nint num3 = (nint)typeof(DiscordRichPresence);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v163 @ rax_v8 (Il2CppClass<Assets.Scripts.Stats___Achievements.Discord.DiscordRichPresence>)+B8]");
			nint num4 = 0;
			string text2 = ((Enum)(&intPtr)).ToString();
			string text3 = text2.ToLower();
			nint num5 = (nint)typeof(DiscordRichPresence);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v234 @ rax_v15 (Il2CppClass<Assets.Scripts.Stats___Achievements.Discord.DiscordRichPresence>)+B8]");
			nint num6 = 0;
			string character2 = SteamRichPresenceManager.GetCharacter();
			Activity activity = default(Activity);
			DiscordManager.Instance.UpdateActivity((Activity)(&activity));
		}
	}

	public unsafe static void UpdateMainMenu()
	{
		//IL_0099: Expected I, but got O
		//IL_00cb: Expected I, but got O
		//IL_0013: Expected I, but got O
		//IL_0037: Expected I, but got O
		//IL_005b: Expected I, but got O
		//IL_008a: Expected O, but got Ref
		nint num = (nint)typeof(DiscordRichPresence);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v42 @ rcx_v3 (Il2CppClass<Assets.Scripts.Stats___Achievements.Discord.DiscordRichPresence>)+B8]");
		nint num2 = 0;
		string randomMenuStatus = SteamRichPresenceManager.GetRandomMenuStatus();
		nint num3 = (nint)typeof(DiscordRichPresence);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v54 @ rcx_v8 (Il2CppClass<Assets.Scripts.Stats___Achievements.Discord.DiscordRichPresence>)+B8]");
		nint num4 = 0;
		nint num5 = (nint)typeof(DiscordRichPresence);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v60 @ rax_v8 (Il2CppClass<Assets.Scripts.Stats___Achievements.Discord.DiscordRichPresence>)+B8]");
		nint num6 = 0;
		_ = 0;
		nint num7 = (nint)typeof(DiscordRichPresence);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v62 @ rax_v9 (Il2CppClass<Assets.Scripts.Stats___Achievements.Discord.DiscordRichPresence>)+B8]");
		nint num8 = 0;
		nint num9 = (nint)typeof(DiscordRichPresence);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v67 @ rax_v12 (Il2CppClass<Assets.Scripts.Stats___Achievements.Discord.DiscordRichPresence>)+B8]");
		nint num10 = 0;
		Activity activity = default(Activity);
		DiscordManager.Instance.UpdateActivity((Activity)(&activity));
	}

	static DiscordRichPresence()
	{
		//IL_0023: Expected I, but got O
		//IL_003d: Expected O, but got I4
		nint num = (nint)typeof(DiscordRichPresence);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v49 @ rax_v5 (Il2CppClass<Assets.Scripts.Stats___Achievements.Discord.DiscordRichPresence>)+B8]");
		nint num2 = 0;
		activity = (Activity)0;
		_ = 0;
		_ = 0;
		_ = 0;
		_ = 0;
		_ = 0;
		_ = 0;
		_ = 0;
	}
}
