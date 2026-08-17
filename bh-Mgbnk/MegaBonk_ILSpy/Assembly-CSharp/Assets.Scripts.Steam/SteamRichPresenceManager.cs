using System;
using Assets.Scripts.Actors.Player;
using Assets.Scripts.Managers;
using Assets.Scripts.Utility;
using Cpp2ILInjected;
using Steamworks;
using UnityEngine;

namespace Assets.Scripts.Steam;

public static class SteamRichPresenceManager
{
	public const string LEVEL_KEY = "lvl";

	public const string CHARACTER_KEY = "character";

	public const string MAP_KEY = "map";

	public const string TIME_KEY = "time";

	public const string MENU_STATUS_KEY = "menu_string";

	public const string DISPLAY_KEY = "steam_display";

	public const string TOKEN_MENU = "#Status_AtMainMenu";

	public const string TOKEN_INGAME = "#Status_InGame";

	private static float previousSecond;

	private static int lastSetLevel;

	private static int lastSetStage;

	public static void Init()
	{
		//IL_0255: Expected I, but got O
		//IL_025e: Expected O, but got I4
		//IL_02c8: Expected O, but got I4
		//IL_02de: Expected I, but got O
		//IL_0304: Expected O, but got I4
		//IL_031a: Expected I, but got O
		//IL_0340: Expected O, but got I4
		//IL_0356: Expected I, but got O
		//IL_03a4: Expected O, but got I4
		//IL_03ba: Expected I, but got O
		//IL_03e5: Expected I, but got O
		//IL_03ee: Expected O, but got I4
		Action b = UpdateDisplayInGame;
		Delegate obj = Delegate.Combine(GameManager.A_RunStarted, b);
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
				num = (nint)typeof(Action);
				obj3 = 0;
				obj4 = obj;
				goto IL_043f;
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
				goto IL_0404;
			}
		}
		Action b2 = MainMenuOpened;
		Delegate obj6 = Delegate.Combine(MainMenu.A_MenuOpened, b2);
		if ((object)obj6 == null)
		{
			MainMenu.A_MenuOpened = null;
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
				goto IL_040f;
			}
			MainMenu.A_MenuOpened = (Action)obj7;
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
				goto IL_041f;
			}
		}
		Action b3 = Update;
		Delegate obj9 = Delegate.Combine(SteamManager.A_UpdateComponents, b3);
		if ((object)obj9 == null)
		{
			SteamManager.A_UpdateComponents = null;
			return;
		}
		bool flag8 = (object)obj9.GetType() != typeof(Action);
		Delegate obj10 = null;
		if (!flag8)
		{
			obj10 = obj9;
		}
		bool flag9 = (object)obj10 == null;
		obj3 = 0;
		obj4 = obj9;
		nint num5 = (nint)typeof(Action);
		if (flag9)
		{
			goto IL_042f;
		}
		SteamManager.A_UpdateComponents = (Action)obj10;
		bool flag10 = (object)obj9.GetType() != typeof(Action);
		Delegate obj11 = null;
		if (!flag10)
		{
			obj11 = obj9;
		}
		bool flag11 = (object)obj11 == null;
		num = (nint)typeof(Action);
		obj3 = 0;
		obj4 = obj9;
		if (!flag11)
		{
			return;
		}
		goto IL_043f;
		IL_042f:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_041f;
		IL_040f:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_0404;
		IL_0404:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		return;
		IL_043f:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_042f;
		IL_041f:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_040f;
	}

	private static void MainMenuOpened()
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [183172598]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		SetKeyValue("steam_display", "#Status_AtMainMenu");
		string randomMenuStatus = GetRandomMenuStatus();
		SetKeyValue("menu_string", randomMenuStatus);
	}

	public unsafe static void UpdateDisplayInGame()
	{
		//IL_0114: Expected O, but got Ref
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [183172599]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		SetKeyValue("steam_display", "#Status_InGame");
		string playerLevel = GetPlayerLevel();
		SetKeyValue("lvl", playerLevel);
		MyPlayer instance = MyPlayer.Instance;
		if ((object)MyPlayer.Instance == null || instance.inventory != null)
		{
		}
		object obj = default(object);
		string s = ((Enum)(&obj)).ToString();
		string value = EnumUtility.EnumToReadable(s);
		SetKeyValue("character", value);
		string mapString = GetMapString();
		string value2 = "\ud83c\udfc3" + mapString;
		SetKeyValue("map", value2);
		string time = GetTime();
		SetKeyValue("time", time);
	}

	public static string GetPlayerLevel()
	{
		MyPlayer instance = MyPlayer.Instance;
		if ((object)MyPlayer.Instance == null || instance.inventory == null)
		{
			return "0";
		}
		MyPlayer instance2 = MyPlayer.Instance;
		if ((object)MyPlayer.Instance != null && instance2.inventory != null)
		{
			int characterLevel = instance2.inventory.GetCharacterLevel();
			int num = default(int);
			return num.ToString();
		}
		return (string)(object)new NullReferenceException();
	}

	private static void Update()
	{
		if (!(GameManager.Instance != null))
		{
			return;
		}
		float time = Time.time;
		float num = time - previousSecond;
		if (num < 1f)
		{
			return;
		}
		if (GameManager.Instance != null)
		{
			string time2 = GetTime();
			SetKeyValue("time", time2);
		}
		if (MyPlayer.Instance != null)
		{
			MyPlayer instance = MyPlayer.Instance;
			if (instance.inventory != null)
			{
				MyPlayer instance2 = MyPlayer.Instance;
				int characterLevel = instance2.inventory.GetCharacterLevel();
				if (characterLevel != lastSetLevel)
				{
					lastSetLevel = characterLevel;
					string playerLevel = GetPlayerLevel();
					SetKeyValue("lvl", playerLevel);
				}
			}
		}
		if (MapController.index != lastSetStage)
		{
			lastSetStage = MapController.index;
			string mapString = GetMapString();
			string value = "\ud83c\udfc3" + mapString;
			SetKeyValue("map", value);
		}
		float time3 = Time.time;
		previousSecond = time3;
	}

	private static void UpdateTimer()
	{
		if (GameManager.Instance != null)
		{
			string time = GetTime();
			SetKeyValue("time", time);
		}
	}

	private static void CheckUpdateLevel()
	{
		if (!(MyPlayer.Instance != null))
		{
			return;
		}
		MyPlayer instance = MyPlayer.Instance;
		if (instance.inventory != null)
		{
			MyPlayer instance2 = MyPlayer.Instance;
			int characterLevel = instance2.inventory.GetCharacterLevel();
			if (characterLevel != lastSetLevel)
			{
				lastSetLevel = characterLevel;
				string playerLevel = GetPlayerLevel();
				SetKeyValue("lvl", playerLevel);
			}
		}
	}

	private static void CheckUpdateStage()
	{
		if (MapController.index != lastSetStage)
		{
			lastSetStage = MapController.index;
			string mapString = GetMapString();
			string value = "\ud83c\udfc3" + mapString;
			SetKeyValue("map", value);
		}
	}

	private static void SetKeyValue(string key, string value)
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18317259F]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		if (!SteamFriends.SetRichPresence(key, value))
		{
			string text = "Failed to set rich presence. key " + key + ", value " + value;
		}
	}

	public unsafe static string GetCharacter()
	{
		//IL_0097: Expected O, but got Ref
		MyPlayer instance = MyPlayer.Instance;
		if ((object)MyPlayer.Instance != null && instance.inventory != null && (object)MyPlayer.Instance == null)
		{
			return (string)(object)new NullReferenceException();
		}
		object obj = default(object);
		string s = ((Enum)(&obj)).ToString();
		return EnumUtility.EnumToReadable(s);
	}

	public static ECharacter GetEnumCharacter()
	{
		//IL_0049: Expected I4, but got O
		MyPlayer instance = MyPlayer.Instance;
		if ((object)MyPlayer.Instance != null && instance.inventory != null)
		{
			MyPlayer instance2 = MyPlayer.Instance;
			if ((object)MyPlayer.Instance != null)
			{
				return instance2.character;
			}
			NullReferenceException ex = new NullReferenceException();
			return (ECharacter)ex;
		}
		return CharacterMenu.selectedCharacter;
	}

	public unsafe static string GetMapString()
	{
		//IL_0031: Expected O, but got Ref
		if ((object)MapController._003CcurrentMap_003Ek__BackingField != null)
		{
			object obj = default(object);
			string s = ((Enum)(&obj)).ToString();
			string arg = EnumUtility.EnumToReadable(s);
			Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_value_box\"");
			object arg2 = default(object);
			return $"{arg} {arg2}";
		}
		return (string)(object)new NullReferenceException();
	}

	private static string GetTime()
	{
		float num = MyTime.runTimer / 60f;
		double num2 = Math.Floor(num);
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1802FFEE0");
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_value_box\"");
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvtss2sd xmm0,xmm6\"");
		double num3 = Math.Floor(0.0);
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_value_box\"");
		object arg = default(object);
		object arg2 = default(object);
		return $"{arg}:{arg2:00}";
	}

	public static string GetRandomMenuStatus()
	{
		string[] array = new string[15];
		if (array.Length > 0)
		{
			array[0] = "im bonking";
			if (array.Length > 1)
			{
				array[1] = "help";
				if (array.Length > 2)
				{
					array[2] = "one more run";
					if (array.Length > 3)
					{
						array[3] = "im cooking";
						if (array.Length > 4)
						{
							array[4] = "doing menu things";
							if (array.Length > 5)
							{
								array[5] = "thinking...";
								if (array.Length > 6)
								{
									array[6] = "honk honk";
									if (array.Length > 7)
									{
										array[7] = "oh no";
										if (array.Length > 8)
										{
											array[8] = "oh yes";
											if (array.Length > 9)
											{
												array[9] = "a cry for help";
												if (array.Length > 10)
												{
													array[10] = "brb";
													if (array.Length > 11)
													{
														array[11] = "trust the process";
														if (array.Length > 12)
														{
															array[12] = "hmmm";
															if (array.Length > 13)
															{
																array[13] = "this is the run";
																if (array.Length > 14)
																{
																	array[14] = "let me cook";
																	int num = UnityEngine.Random.Range(0, array.Length);
																	if (num < array.Length)
																	{
																		return array[num];
																	}
																}
															}
														}
													}
												}
											}
										}
									}
								}
							}
						}
					}
				}
			}
		}
		return (string)(object)new IndexOutOfRangeException();
	}

	private static void Refresh()
	{
		bool flag = GameManager.Instance != null;
		if (!flag)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [183172598]");
			if ((nint)0 == (flag ? 1 : 0))
			{
				_ = 1;
			}
			SetKeyValue("steam_display", "#Status_AtMainMenu");
			string randomMenuStatus = GetRandomMenuStatus();
			Cpp2ILHelpers.NoteDecompilerIssue("Invalid instruction: 84 Invalid \"Jump target not found in method: 0x1803EE010\"");
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Invalid instruction: 89 Invalid \"Jump target not found in method: 0x1803EE090\"");
	}

	public static void OnDestroy()
	{
		//IL_0264: Expected I, but got O
		//IL_026d: Expected O, but got I4
		//IL_02d7: Expected O, but got I4
		//IL_02ed: Expected I, but got O
		//IL_0313: Expected O, but got I4
		//IL_0329: Expected I, but got O
		//IL_034f: Expected O, but got I4
		//IL_0365: Expected I, but got O
		//IL_03b3: Expected O, but got I4
		//IL_03c9: Expected I, but got O
		//IL_03f4: Expected I, but got O
		//IL_03fd: Expected O, but got I4
		Action value = UpdateDisplayInGame;
		Delegate obj = Delegate.Remove(GameManager.A_RunStarted, value);
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
			object obj3;
			Delegate obj4;
			if ((object)obj2 == null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
				nint num = (nint)typeof(Action);
				obj3 = 0;
				obj4 = obj;
				goto IL_0453;
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
				goto IL_0418;
			}
		}
		Action value2 = MainMenuOpened;
		Delegate obj6 = Delegate.Remove(MainMenu.A_MenuOpened, value2);
		if ((object)obj6 == null)
		{
			MainMenu.A_MenuOpened = null;
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
			object obj3 = 0;
			Delegate obj4 = obj6;
			nint num3 = (nint)typeof(Action);
			if (flag5)
			{
				goto IL_0423;
			}
			MainMenu.A_MenuOpened = (Action)obj7;
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
				goto IL_0433;
			}
		}
		Action value3 = Update;
		Delegate obj9 = Delegate.Remove(SteamManager.A_UpdateComponents, value3);
		if ((object)obj9 == null)
		{
			SteamManager.A_UpdateComponents = null;
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
			object obj3 = 0;
			Delegate obj4 = obj9;
			nint num5 = (nint)typeof(Action);
			if (flag9)
			{
				goto IL_0443;
			}
			SteamManager.A_UpdateComponents = (Action)obj10;
			bool flag10 = (object)obj9.GetType() != typeof(Action);
			Delegate obj11 = null;
			if (!flag10)
			{
				obj11 = obj9;
			}
			bool flag11 = (object)obj11 == null;
			nint num = (nint)typeof(Action);
			obj3 = 0;
			obj4 = obj9;
			if (flag11)
			{
				goto IL_0453;
			}
		}
		if (SteamManager.initialized)
		{
			SteamFriends.ClearRichPresence();
		}
		return;
		IL_0433:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_0423;
		IL_0418:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		return;
		IL_0453:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_0443;
		IL_0443:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_0433;
		IL_0423:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_0418;
	}
}
