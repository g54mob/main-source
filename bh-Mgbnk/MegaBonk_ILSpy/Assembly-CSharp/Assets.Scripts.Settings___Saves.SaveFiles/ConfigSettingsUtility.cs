using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.CompilerServices;
using Assets.Scripts.Saves___Serialization.SaveFiles.Configs.ConfigSettingsTypes;
using Assets.Scripts.Settings___Saves.SaveFiles.ConfigSettingsTypes;
using Assets.Scripts.UI.Localization;
using Cpp2ILInjected;
using Rewired;
using UnityEngine;
using UnityEngine.Localization;
using UnityEngine.Localization.Settings;
using UnityEngine.Localization.Tables;

namespace Assets.Scripts.Settings___Saves.SaveFiles;

public static class ConfigSettingsUtility
{
	public static SettingType GetSettingType(FieldInfo field)
	{
		//IL_022a: Expected I4, but got O
		//IL_0116: Expected O, but got I
		//IL_016f: Expected O, but got I
		//IL_01c8: Expected O, but got I
		if ((object)field != null)
		{
			switch (field.Name)
			{
			case "resolution":
				return SettingType.Resolution;
			case "language":
				return SettingType.Language;
			case "controller":
				return SettingType.ControllerDisplay;
			default:
			{
				Type fieldType = field.FieldType;
				Type typeFromHandle = Type.GetTypeFromHandle((RuntimeTypeHandle)typeof(int[]));
				if (!((object)fieldType).Equals((object)typeFromHandle))
				{
					Type fieldType2 = field.FieldType;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [183185B08]");
					RuntimeTypeHandle handle = (RuntimeTypeHandle)((nint)0 + (nint)32);
					Type typeFromHandle2 = Type.GetTypeFromHandle(handle);
					if (!((object)fieldType2).Equals((object)typeFromHandle2))
					{
						Type fieldType3 = field.FieldType;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [183185B28]");
						RuntimeTypeHandle handle2 = (RuntimeTypeHandle)((nint)0 + (nint)32);
						Type typeFromHandle3 = Type.GetTypeFromHandle(handle2);
						if (!((object)fieldType3).Equals((object)typeFromHandle3))
						{
							Type fieldType4 = field.FieldType;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [183185B58]");
							RuntimeTypeHandle handle3 = (RuntimeTypeHandle)((nint)0 + (nint)32);
							Type typeFromHandle4 = Type.GetTypeFromHandle(handle3);
							bool flag = ((object)fieldType4).Equals((object)typeFromHandle4);
							SettingType result = SettingType.Slider;
							if (!flag)
							{
								result = SettingType.ControlNew;
							}
							return result;
						}
					}
					return SettingType.Enum;
				}
				return SettingType.Control;
			}
			}
		}
		NullReferenceException ex = new NullReferenceException();
		return (SettingType)ex;
	}

	public static string CheckSettingName(string settingName)
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1831725CB]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		if (settingName == "controller_sensitivity" || !(settingName != "pause_on_controller_disconnect"))
		{
			return settingName;
		}
		if (settingName != null)
		{
			string text = settingName.Replace("controller_", "");
			if (text != null)
			{
				return text.Replace("keyboard_", "");
			}
		}
		return (string)(object)new NullReferenceException();
	}

	public static string GetSettingDescription(string settingName)
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1831725CC]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1831725D5]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		if (settingName != null)
		{
			char c = settingName.get_Chars(0);
			char c2 = char.ToUpper(c);
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1814478A0");
			string text = settingName.Replace("_", " ");
			if (text != null)
			{
				string text2 = text.Substring(1);
				string text4 = default(string);
				string text3 = text4 + text2;
				return "Configure " + text3;
			}
		}
		return (string)(object)new NullReferenceException();
	}

	public static string[] GetSettingValues(string settingName)
	{
		//IL_0812: Expected I, but got O
		//IL_0645: Expected O, but got I
		//IL_07be: Expected I, but got O
		//IL_0637: Expected I, but got O
		//IL_07ff: Expected I, but got O
		//IL_06b9: Expected I, but got O
		//IL_0577: Expected I, but got O
		//IL_04d5: Expected I, but got O
		//IL_016e: Expected I, but got O
		//IL_05d9: Expected I, but got O
		//IL_01d0: Expected I, but got O
		//IL_00aa: Expected I, but got O
		//IL_010c: Expected I, but got O
		//IL_02b2: Expected I, but got O
		//IL_033d: Expected O, but got I4
		//IL_02ea: Expected O, but got I
		//IL_02f3: Expected O, but got I4
		//IL_0301: Unknown result type (might be due to invalid IL or missing references)
		//IL_0306: Expected O, but got Unknown
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1804BF510");
		object obj = default(object);
		nint num;
		ILocalesProvider availableLocales;
		string text;
		object obj2;
		if ((long)obj > 2400797266L)
		{
			if ((long)obj > 3119462523L)
			{
				if ((long)obj > 3582686958L)
				{
					if ((long)obj == 3738149635L)
					{
						if (settingName == "grass_quality")
						{
							num = (nint)typeof(GrassQuality);
							goto IL_063c;
						}
					}
					else if ((long)obj == 3840843484L && settingName == "bloom")
					{
						num = (nint)typeof(Bloom);
						goto IL_063c;
					}
				}
				else if ((long)obj == 3394781895L)
				{
					if (settingName == "shadow_quality")
					{
						num = (nint)typeof(ShadowQuality);
						goto IL_063c;
					}
				}
				else if ((long)obj == 3582686958L && settingName == "anti_aliasing")
				{
					num = (nint)typeof(AntiAliasing);
					goto IL_063c;
				}
			}
			else if ((long)obj > 2942216506L)
			{
				if ((long)obj == 3026529409L)
				{
					if (settingName == "controller")
					{
						return GetControllers();
					}
				}
				else if ((long)obj == 3119462523L && settingName == "language")
				{
					availableLocales = LocalizationSettings.AvailableLocales;
					if (availableLocales != null)
					{
						nint num2 = (nint)availableLocales;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v652 @ r10_v2 (Il2CppClass<UnityEngine.Localization.Settings.ILocalesProvider>)+12E]");
						if ((nint)0 >= (nint)0)
						{
							goto IL_032a;
						}
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v652 @ r10_v2 (Il2CppClass<UnityEngine.Localization.Settings.ILocalesProvider>)+B0]");
						obj2 = 0;
						object obj3 = 0;
						while (true)
						{
							object obj4 = obj3 + obj3;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v751 @ r8_v14+v809 @ rax_v45*8]");
							if (0 != (nint)typeof(ILocalesProvider))
							{
								obj3++;
								object obj5 = obj3;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v652 @ r10_v2 (Il2CppClass<UnityEngine.Localization.Settings.ILocalesProvider>)+12E]");
								if ((nint)obj5 < 0)
								{
									continue;
								}
								goto IL_032a;
							}
							break;
						}
						goto IL_0342;
					}
					goto IL_0870;
				}
			}
			else if ((long)obj == 2539662121L)
			{
				if (settingName == "target_monitor")
				{
					return GetMonitorNames();
				}
			}
			else if ((long)obj == 2942216506L && settingName == "controller_type")
			{
				num = (nint)typeof(EControllerType);
				goto IL_063c;
			}
		}
		else if ((nint)obj > 1516116007)
		{
			if ((nint)obj > 1755353376)
			{
				if ((long)obj == 2206693122L)
				{
					if (settingName == "texture_quality")
					{
						num = (nint)typeof(TextureQuality);
						goto IL_063c;
					}
				}
				else if ((long)obj == 2400797266L && settingName == "fullscreen_mode")
				{
					num = (nint)typeof(FullScreenMode);
					goto IL_063c;
				}
			}
			else if ((nint)obj == 1562258959)
			{
				if (settingName == "enemy_targeting_mode")
				{
					num = (nint)typeof(EEnemyTargetingMode);
					goto IL_063c;
				}
			}
			else if ((nint)obj == 1755353376 && settingName == "shadow_resolution")
			{
				num = (nint)typeof(ShadowResolution);
				goto IL_063c;
			}
		}
		else if ((nint)obj > 241741775)
		{
			if ((nint)obj == 488725647)
			{
				if (settingName == "resolution")
				{
					return GetResolutionNames();
				}
			}
			else if ((nint)obj == 1516116007)
			{
				text = "warning_color";
				goto IL_08d9;
			}
		}
		else if ((nint)obj == 116977766)
		{
			if (settingName == "vsync")
			{
				num = (nint)typeof(VSync);
				goto IL_063c;
			}
		}
		else if ((nint)obj == 241741775)
		{
			text = "hp_bar_color";
			goto IL_08d9;
		}
		goto IL_0804;
		IL_08d9:
		if (settingName == text)
		{
			num = (nint)typeof(EHpBarColor);
			goto IL_063c;
		}
		goto IL_0804;
		IL_0342:
		List<Locale> locales = availableLocales.Locales;
		if (locales != null)
		{
			string[] array = new string[locales._size];
			int num3 = 0;
			int num4 = 0;
			while (true)
			{
				if (num3 < locales._size)
				{
					Locale locale = locales.get_Item(num4);
					if ((object)locale == null || array == null)
					{
						break;
					}
					array[num4] = (string)locale.m_Identifier;
					num4++;
					num3 = num4;
					continue;
				}
				return array;
			}
		}
		goto IL_0870;
		IL_032a:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18026F510");
		obj2 = 0;
		goto IL_0342;
		IL_063c:
		Type typeFromHandle = Type.GetTypeFromHandle((RuntimeTypeHandle)num);
		return Enum.GetNames(typeFromHandle);
		IL_0870:
		return (string[])(object)new NullReferenceException();
		IL_0804:
		num = (nint)typeof(BoolSetting);
		goto IL_063c;
	}

	public static bool GetSliderWholeNumbers(string settingName)
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1831725CE]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		if (settingName != "fov" && settingName != "fps_limit" && settingName != "input_delay" && settingName != "max_splits" && settingName != "num_tomes")
		{
			bool flag = settingName == "auto_select_after_level";
			bool flag2 = !flag;
			return !flag2;
		}
		return true;
	}

	public unsafe static void GetSliderRange(string settingName, out float min, out float max)
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1831725CF]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		ref float reference = ref *(float*)null;
		ref float reference2 = ref *(float*)1092616192;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1804BF510");
		object obj = default(object);
		string text;
		if ((long)obj > 2931535181L)
		{
			if ((long)obj > 3278063179L)
			{
				if ((long)obj > 3421771688L)
				{
					if ((long)obj == 3837641168L)
					{
						if (settingName == "minimap_size")
						{
							reference = ref *(float*)1056964608;
							reference2 = ref *(float*)1073741824;
						}
						return;
					}
					if ((long)obj == 4081817468L)
					{
						if (settingName == "camera_distance")
						{
							reference = ref *(float*)null;
							reference2 = ref *(float*)1084227584;
						}
						return;
					}
					if ((long)obj != 4094074503L)
					{
						return;
					}
					text = "game_sfx";
				}
				else if ((long)obj == 3299869303L)
				{
					text = "look_smoothing";
				}
				else
				{
					if ((long)obj != 3421771688L)
					{
						return;
					}
					text = "crosshair_alpha";
				}
			}
			else if ((long)obj > 2996456135L)
			{
				if ((long)obj == 3078805355L)
				{
					if (settingName == "input_delay")
					{
						reference2 = ref *(float*)1086324736;
					}
					return;
				}
				if ((long)obj != 3147452822L)
				{
					if ((long)obj == 3278063179L && settingName == "auto_select_after_level")
					{
						reference = ref *(float*)1092616192;
						reference2 = ref *(float*)1142292480;
					}
					return;
				}
				text = "master_volume";
			}
			else
			{
				if ((long)obj == 2968750556L)
				{
					if (settingName == "fov")
					{
						reference = ref *(float*)1114636288;
						reference2 = ref *(float*)1124859904;
					}
					return;
				}
				if ((long)obj != 2996456135L)
				{
					return;
				}
				text = "crosshair_height";
			}
		}
		else if ((nint)obj > 1894656452)
		{
			if ((long)obj > 2563466029L)
			{
				if ((long)obj == 2677821396L)
				{
					text = "music";
				}
				else if ((long)obj == 2735796537L)
				{
					text = "random_enemy_targeting";
				}
				else
				{
					if ((long)obj != 2931535181L)
					{
						return;
					}
					text = "ambience";
				}
			}
			else
			{
				if ((nint)obj != 1924803052)
				{
					if ((long)obj == 2563466029L && settingName == "crosshair_size")
					{
						reference = ref *(float*)1048576000;
						reference2 = ref *(float*)1073741824;
					}
					return;
				}
				text = "controller_vibration";
			}
		}
		else if ((nint)obj > 1547907707)
		{
			if ((nint)obj == 1551578485)
			{
				if (settingName == "particle_opacity")
				{
					reference = ref *(float*)null;
					goto IL_0663;
				}
				return;
			}
			if ((nint)obj != 1762831070)
			{
				if ((nint)obj == 1894656452 && settingName == "fps_limit")
				{
					reference = ref *(float*)1106247680;
					reference2 = ref *(float*)1133903872;
				}
				return;
			}
			text = "xp_and_gold";
		}
		else
		{
			if ((nint)obj != 164617456)
			{
				if ((nint)obj == 1547907707 && settingName == "ui")
				{
					goto IL_0663;
				}
				return;
			}
			text = "difficulty";
		}
		if (!(settingName == text))
		{
			return;
		}
		goto IL_0663;
		IL_0663:
		reference2 = ref *(float*)1065353216;
	}

	private static string[] GetResolutionNames()
	{
		//IL_000e: Expected O, but got I4
		//IL_0017: Expected O, but got I4
		//IL_0046: Unknown result type (might be due to invalid IL or missing references)
		//IL_004b: Expected O, but got Unknown
		//IL_00a9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ae: Expected O, but got Unknown
		//IL_0168: Unknown result type (might be due to invalid IL or missing references)
		//IL_016d: Expected O, but got Unknown
		//IL_01f8: Unknown result type (might be due to invalid IL or missing references)
		//IL_01fd: Expected O, but got Unknown
		//IL_0205: Expected I, but got O
		Resolution[] myResolutions = GetMyResolutions();
		List<string> list = new List<string>();
		object obj = 0;
		object obj2 = 0;
		object arg = default(object);
		object obj9 = default(object);
		object obj11 = default(object);
		object obj13 = default(object);
		int num2 = default(int);
		while (true)
		{
			if ((nint)obj2 < myResolutions.Length)
			{
				if ((nint)obj >= myResolutions.Length)
				{
					break;
				}
				object obj3 = obj + 2;
				object obj4 = obj3 << 4;
				object obj5 = obj4 + (object)myResolutions;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1809DD6D0");
				Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_value_box\"");
				if ((nint)obj >= myResolutions.Length)
				{
					break;
				}
				object obj6 = obj + 2;
				object obj7 = obj6 << 4;
				object obj8 = obj7 + (object)myResolutions;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1809DB5A0");
				Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_value_box\"");
				string text = $"{arg}x{obj9}";
				int version = list._version + 1;
				list._version = version;
				string[] items = list._items;
				nint num;
				string text2;
				object obj10;
				object obj12;
				if (list._size >= items.Length)
				{
					((List<object>)(object)list).AddWithResize((object)text);
					obj++;
					num = 0;
					text2 = text;
					obj10 = obj11;
					obj12 = obj13;
					obj2 = obj;
					continue;
				}
				int size = list._size + 1;
				list._size = size;
				if (list._size >= items.Length)
				{
					break;
				}
				items[num2] = text;
				obj++;
				num = (nint)obj9;
				text2 = text;
				obj10 = obj11;
				obj12 = obj13;
				obj2 = obj;
				continue;
			}
			return list.ToArray();
		}
		return (string[])(object)new IndexOutOfRangeException();
	}

	private static string[] GetLanguageNames()
	{
		//IL_000d: Expected I, but got O
		//IL_0098: Expected O, but got I4
		//IL_0045: Expected O, but got I
		//IL_004e: Expected O, but got I4
		//IL_005c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0061: Expected O, but got Unknown
		ILocalesProvider availableLocales = LocalizationSettings.AvailableLocales;
		nint num = (nint)availableLocales;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v49 @ r10_v3 (Il2CppClass<UnityEngine.Localization.Settings.ILocalesProvider>)+12E]");
		if ((nint)0 >= (nint)0)
		{
			goto IL_0085;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v49 @ r10_v3 (Il2CppClass<UnityEngine.Localization.Settings.ILocalesProvider>)+B0]");
		object obj = 0;
		object obj2 = 0;
		while (true)
		{
			object obj3 = obj2 + obj2;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v69 @ r8_v3+v133 @ rax_v24*8]");
			if (0 != (nint)typeof(ILocalesProvider))
			{
				obj2++;
				object obj4 = obj2;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v49 @ r10_v3 (Il2CppClass<UnityEngine.Localization.Settings.ILocalesProvider>)+12E]");
				if ((nint)obj4 < 0)
				{
					continue;
				}
				goto IL_0085;
			}
			break;
		}
		goto IL_009d;
		IL_009d:
		List<Locale> locales = availableLocales.Locales;
		string[] array = new string[locales._size];
		int num2 = 0;
		int num3 = 0;
		while (true)
		{
			if (num3 < locales._size)
			{
				Locale locale = locales.get_Item(num2);
				if (num2 >= array.Length)
				{
					break;
				}
				array[num2] = (string)locale.m_Identifier;
				num2++;
				num3 = num2;
				continue;
			}
			return array;
		}
		return (string[])(object)new IndexOutOfRangeException();
		IL_0085:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18026F510");
		obj = 0;
		goto IL_009d;
	}

	public unsafe static Resolution[] GetMyResolutions()
	{
		//IL_001d: Expected O, but got I4
		//IL_0026: Expected O, but got I4
		//IL_007f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0084: Expected O, but got Unknown
		//IL_00c9: Expected O, but got Ref
		//IL_0198: Expected O, but got I
		//IL_01b7: Expected O, but got Ref
		//IL_0227: Expected O, but got I
		//IL_01fe: Expected O, but got Ref
		//IL_0207: Unknown result type (might be due to invalid IL or missing references)
		//IL_020c: Expected O, but got Unknown
		//IL_0271: Expected O, but got I
		//IL_0320: Unknown result type (might be due to invalid IL or missing references)
		//IL_0325: Expected O, but got Unknown
		Resolution[] resolutions = Screen.resolutions;
		List<Resolution> list = new List<Resolution>();
		bool flag = resolutions == null;
		object obj = 0;
		object obj2 = 0;
		if (!flag)
		{
			List<Resolution>.Enumerator enumerator = default(List<Resolution>.Enumerator);
			object obj5 = default(object);
			object obj6 = default(object);
			object obj7 = default(object);
			object obj8 = default(object);
			object obj9 = default(object);
			List<Resolution>.Enumerator enumerator2 = default(List<Resolution>.Enumerator);
			while (true)
			{
				if ((nint)obj2 < resolutions.Length)
				{
					if ((nint)obj2 < resolutions.Length)
					{
						object obj3 = obj2 + 2;
						object obj4 = obj3 + obj3;
						if (list == null)
						{
							break;
						}
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @181126FB0");
						Resolution resolution = (Resolution)System.Runtime.CompilerServices.Unsafe.AsPointer(ref resolutions[obj2]);
						while (enumerator.MoveNext())
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1809DD6D0");
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1809DD6D0");
							bool flag2 = obj5 != obj6;
							obj = obj7;
							if (flag2)
							{
								continue;
							}
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1809DB5A0");
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1809DB5A0");
							bool flag3 = obj8 != obj9;
							obj = obj7;
							if (flag3)
							{
								continue;
							}
							goto IL_014e;
						}
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1803321E0");
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v48 @ rax_v3 (System.Collections.Generic.List`1<UnityEngine.Resolution>)+1C]");
						_ = (nint)0 + (nint)1;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v48 @ rax_v3 (System.Collections.Generic.List`1<UnityEngine.Resolution>)+10]");
						object obj10 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v48 @ rax_v3 (System.Collections.Generic.List`1<UnityEngine.Resolution>)+10]");
						bool flag4 = (nint)0 == 0;
						List<Resolution> list2 = (List<Resolution>)(&enumerator);
						if (flag4)
						{
							break;
						}
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v48 @ rax_v3 (System.Collections.Generic.List`1<UnityEngine.Resolution>)+18]");
						nint num = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v188 @ rdx_v11+18]");
						if (num >= 0)
						{
							list.AddWithResize((Resolution)(&enumerator2));
							obj2++;
							continue;
						}
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v48 @ rax_v3 (System.Collections.Generic.List`1<UnityEngine.Resolution>)+18]");
						object obj11 = (nint)0 + (nint)1;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v48 @ rax_v3 (System.Collections.Generic.List`1<UnityEngine.Resolution>)+18]");
						nint num2 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v188 @ rdx_v11+18]");
						if (num2 < 0)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v48 @ rax_v3 (System.Collections.Generic.List`1<UnityEngine.Resolution>)+18]");
							object obj12 = (nint)0 + (nint)2;
							object obj13 = obj12 + obj12;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v43 @ rax_v2 (UnityEngine.Resolution[])+v190 @ rax_v14*8]");
							_ = 0;
							goto IL_0317;
						}
					}
					return (Resolution[])(object)new IndexOutOfRangeException();
				}
				if (list == null)
				{
					break;
				}
				return list.ToArray();
				IL_0317:
				obj2++;
				continue;
				IL_014e:
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1803321E0");
				obj = obj7;
				goto IL_0317;
			}
		}
		throw new NullReferenceException();
	}

	public unsafe static string[] GetControllers()
	{
		//IL_015d: Expected O, but got Ref
		//IL_02ee: Expected O, but got I4
		//IL_0309: Unknown result type (might be due to invalid IL or missing references)
		//IL_030e: Expected O, but got Unknown
		List<string> list = new List<string>();
		bool flag = list == null;
		List<string> list2 = list;
		if (!flag)
		{
			int version = list._version + 1;
			list._version = version;
			list2 = (List<string>)(object)list._items;
			if (list._items != null)
			{
				if (list._size >= list2._size)
				{
					((List<object>)(object)list).AddWithResize((object)"None");
				}
				else
				{
					int size = list._size + 1;
					list._size = size;
					if (list._size >= list2._size)
					{
						throw new IndexOutOfRangeException();
					}
				}
				ReInput.ControllerHelper controllers = ReInput.controllers;
				bool flag2 = controllers == null;
				list2 = null;
				if (!flag2)
				{
					IList<Joystick> joysticks = controllers.Joysticks;
					bool flag3 = joysticks == null;
					list2 = (List<string>)(object)controllers;
					if (!flag3)
					{
						IEnumerator<Joystick> enumerator = joysticks.GetEnumerator();
						IEnumerator enumerator2 = default(IEnumerator);
						object obj = (object)(&enumerator2);
						list2 = (List<string>)joysticks;
						while (true)
						{
							if (enumerator2 != null)
							{
								if (enumerator2.MoveNext())
								{
									bool flag4 = enumerator2 == null;
									list2 = (List<string>)enumerator2;
									if (!flag4)
									{
										Joystick current = ((IEnumerator<Joystick>)enumerator2).Current;
										bool flag5 = current == null;
										list2 = (List<string>)enumerator2;
										if (!flag5)
										{
											string name = current.name;
											int version2 = list._version + 1;
											list._version = version2;
											list2 = (List<string>)(object)list._items;
											if (list._items != null)
											{
												if (list._size >= list2._size)
												{
													((List<object>)(object)list).AddWithResize((object)name);
													list2 = list;
													continue;
												}
												int size2 = list._size + 1;
												list._size = size2;
												if (list._size < list2._size)
												{
													object obj2 = list._size * 8;
													object obj3 = (object)list._items + obj2;
													list2 = (List<string>)(obj3 + 32);
													continue;
												}
												throw new IndexOutOfRangeException();
											}
											throw new NullReferenceException();
										}
										throw new NullReferenceException();
									}
									throw new NullReferenceException();
								}
								if (obj != null)
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002530");
								}
								break;
							}
							throw new NullReferenceException();
						}
						return list.ToArray();
					}
				}
			}
		}
		throw new NullReferenceException();
	}

	public unsafe static bool AreResolutionSame(Resolution r1, Resolution r2)
	{
		//IL_006d: Expected O, but got I4
		int width = ((Resolution*)r1)->width;
		int width2 = ((Resolution*)r2)->width;
		if (width != width2)
		{
			return false;
		}
		int height = ((Resolution*)r1)->height;
		int height2 = ((Resolution*)r2)->height;
		object obj = height - height2;
		return obj == null;
	}

	private unsafe static string[] GetMonitorNames()
	{
		//IL_020d: Expected O, but got Ref
		//IL_0065: Expected O, but got Ref
		List<DisplayInfo> list = new List<DisplayInfo>();
		Screen.GetDisplayLayout(list);
		List<string> list2 = new List<string>();
		bool flag = list == null;
		List<string> list3 = list2;
		if (!flag)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18116F0F0");
			nint num = 0;
			List<DisplayInfo>.Enumerator enumerator = default(List<DisplayInfo>.Enumerator);
			object item = default(object);
			while (enumerator.MoveNext())
			{
				bool flag2 = list2 == null;
				list3 = (List<string>)(&enumerator);
				if (!flag2)
				{
					int version = list2._version + 1;
					list2._version = version;
					list3 = (List<string>)(object)list2._items;
					if (list2._items != null)
					{
						num = list2._size;
						if (list2._size >= list3._size)
						{
							((List<object>)(object)list2).AddWithResize(item);
							num = 0;
							continue;
						}
						int size = list2._size + 1;
						list2._size = size;
						if (list2._size < list3._size)
						{
							continue;
						}
						throw new IndexOutOfRangeException();
					}
					throw new NullReferenceException();
				}
				throw new NullReferenceException();
			}
			enumerator.Dispose();
			bool flag3 = list2 == null;
			list3 = (List<string>)(&enumerator);
			if (!flag3)
			{
				return list2.ToArray();
			}
		}
		throw new NullReferenceException();
	}

	public static string SettingNameToReadable(string s)
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1831725D5]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		if (s != null)
		{
			char c = s.get_Chars(0);
			char c2 = char.ToUpper(c);
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1814478A0");
			string text = s.Replace("_", " ");
			if (text != null)
			{
				string text2 = text.Substring(1);
				string text3 = default(string);
				return text3 + text2;
			}
		}
		return (string)(object)new NullReferenceException();
	}

	public static string SettingNameToReadable(string s, CFSettings cfSettings)
	{
		//IL_00bb: Expected I, but got O
		//IL_00c3: Expected I, but got O
		//IL_00d3: Expected O, but got I
		//IL_0173: Expected I, but got O
		//IL_0183: Expected O, but got I
		//IL_0211: Expected I, but got O
		//IL_0221: Expected O, but got I
		//IL_010f: Expected O, but got I
		//IL_02af: Expected I, but got O
		//IL_02bf: Expected O, but got I
		//IL_01bf: Expected O, but got I
		//IL_034d: Expected I, but got O
		//IL_035d: Expected O, but got I
		//IL_025d: Expected O, but got I
		//IL_02fb: Expected O, but got I
		//IL_0399: Expected O, but got I
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1831725CB]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		bool flag = s != "controller_sensitivity";
		string text = s;
		if (flag)
		{
			bool flag2 = s != "pause_on_controller_disconnect";
			text = s;
			if (flag2)
			{
				if (s != null)
				{
					string text2 = s.Replace("controller_", "");
					if (text2 != null)
					{
						string text3 = text2.Replace("keyboard_", "");
						text = text3;
						goto IL_04c4;
					}
				}
				goto IL_048e;
			}
		}
		goto IL_04c4;
		IL_04e1:
		string table;
		string key;
		LocalizedString localizedStringReference = LocalizationUtility.GetLocalizedStringReference(table, key);
		if (localizedStringReference != null)
		{
			return localizedStringReference.GetLocalizedString();
		}
		goto IL_048e;
		IL_04c4:
		if (cfSettings != null)
		{
			nint num = (nint)typeof(CFGameSettings);
			nint num2 = (nint)cfSettings;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v136 @ rax_v14 (Il2CppClass<Assets.Scripts.Settings___Saves.SaveFiles.CFGameSettings>)+130]");
			object obj = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v137 @ r8_v8 (Il2CppClass<Assets.Scripts.Settings___Saves.SaveFiles.CFSettings>)+130]");
			nint num3 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v136 @ rax_v14 (Il2CppClass<Assets.Scripts.Settings___Saves.SaveFiles.CFGameSettings>)+130]");
			if (num3 >= 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v137 @ r8_v8 (Il2CppClass<Assets.Scripts.Settings___Saves.SaveFiles.CFSettings>)+C8]");
				object obj2 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v216 @ rcx_v28+FFFFFFF8+v138 @ rcx_v13*8]");
				if (0 == (nint)typeof(CFGameSettings))
				{
					key = text;
					table = "SettingsGame";
					goto IL_04e1;
				}
			}
			nint num4 = (nint)typeof(CFVideoSettings);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v241 @ rdx_v13 (Il2CppClass<Assets.Scripts.Settings___Saves.SaveFiles.CFVideoSettings>)+130]");
			object obj3 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v137 @ r8_v8 (Il2CppClass<Assets.Scripts.Settings___Saves.SaveFiles.CFSettings>)+130]");
			nint num5 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v241 @ rdx_v13 (Il2CppClass<Assets.Scripts.Settings___Saves.SaveFiles.CFVideoSettings>)+130]");
			if (num5 >= 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v137 @ r8_v8 (Il2CppClass<Assets.Scripts.Settings___Saves.SaveFiles.CFSettings>)+C8]");
				object obj4 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v324 @ rax_v28+FFFFFFF8+v242 @ rax_v18*8]");
				if (0 == (nint)typeof(CFVideoSettings))
				{
					key = text;
					table = "SettingsVideo";
					goto IL_04e1;
				}
			}
			nint num6 = (nint)typeof(CFControlSettings);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v349 @ rdx_v14 (Il2CppClass<Assets.Scripts.Settings___Saves.SaveFiles.CFControlSettings>)+130]");
			object obj5 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v137 @ r8_v8 (Il2CppClass<Assets.Scripts.Settings___Saves.SaveFiles.CFSettings>)+130]");
			nint num7 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v349 @ rdx_v14 (Il2CppClass<Assets.Scripts.Settings___Saves.SaveFiles.CFControlSettings>)+130]");
			if (num7 >= 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v137 @ r8_v8 (Il2CppClass<Assets.Scripts.Settings___Saves.SaveFiles.CFSettings>)+C8]");
				object obj6 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v386 @ rax_v27+FFFFFFF8+v350 @ rax_v20*8]");
				if (0 == (nint)typeof(CFControlSettings))
				{
					key = text;
					table = "SettingsControls";
					goto IL_04e1;
				}
			}
			nint num8 = (nint)typeof(CFAudioSettings);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v438 @ rdx_v15 (Il2CppClass<Assets.Scripts.Settings___Saves.SaveFiles.ConfigSettingsTypes.CFAudioSettings>)+130]");
			object obj7 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v137 @ r8_v8 (Il2CppClass<Assets.Scripts.Settings___Saves.SaveFiles.CFSettings>)+130]");
			nint num9 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v438 @ rdx_v15 (Il2CppClass<Assets.Scripts.Settings___Saves.SaveFiles.ConfigSettingsTypes.CFAudioSettings>)+130]");
			if (num9 >= 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v137 @ r8_v8 (Il2CppClass<Assets.Scripts.Settings___Saves.SaveFiles.CFSettings>)+C8]");
				object obj8 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v387 @ rax_v26+FFFFFFF8+v439 @ rax_v22*8]");
				if (0 == (nint)typeof(CFAudioSettings))
				{
					key = text;
					table = "SettingsAudio";
					goto IL_04e1;
				}
			}
			nint num10 = (nint)typeof(CFVisualsSettings);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v153 @ rdx_v16 (Il2CppClass<Assets.Scripts.Saves___Serialization.SaveFiles.Configs.ConfigSettingsTypes.CFVisualsSettings>)+130]");
			object obj9 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v137 @ r8_v8 (Il2CppClass<Assets.Scripts.Settings___Saves.SaveFiles.CFSettings>)+130]");
			nint num11 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v153 @ rdx_v16 (Il2CppClass<Assets.Scripts.Saves___Serialization.SaveFiles.Configs.ConfigSettingsTypes.CFVisualsSettings>)+130]");
			if (num11 >= 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v137 @ r8_v8 (Il2CppClass<Assets.Scripts.Settings___Saves.SaveFiles.CFSettings>)+C8]");
				object obj10 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v156 @ rax_v25+FFFFFFF8+v155 @ rax_v24*8]");
				if (0 == (nint)typeof(CFVisualsSettings))
				{
					key = text;
					table = "SettingsVisuals";
					goto IL_04e1;
				}
			}
		}
		if (text != null)
		{
			char c = text.get_Chars(0);
			char c2 = char.ToUpper(c);
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1814478A0");
			string text4 = text.Replace("_", " ");
			if (text4 != null)
			{
				string text5 = text4.Substring(1);
				string text6 = default(string);
				return text6 + text5;
			}
		}
		goto IL_048e;
		IL_048e:
		return (string)(object)new NullReferenceException();
	}

	public unsafe static string GetSettingEnumLocalized(string settingEnumValue)
	{
		//IL_006c: Expected O, but got Ref
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1831725D7]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		LocalizedStringDatabase stringDatabase = LocalizationSettings.StringDatabase;
		TableReference tableReference = "SettingEnums";
		if (stringDatabase != null)
		{
			object obj = default(object);
			DetailedLocalizationTable<StringTableEntry> table = stringDatabase.GetTable((TableReference)(&obj));
			UnityEngine.Object obj2;
			StringTableEntry stringTableEntry;
			if ((object)table != null)
			{
				StringTableEntry entry = table.GetEntry(settingEnumValue);
				obj2 = table;
				stringTableEntry = entry;
			}
			else
			{
				obj2 = null;
				stringTableEntry = null;
			}
			if (obj2 != null && stringTableEntry != null)
			{
				string value = stringTableEntry.Value;
				if (!string.IsNullOrEmpty(value))
				{
					LocalizedString localizedStringReference = LocalizationUtility.GetLocalizedStringReference("SettingEnums", settingEnumValue);
					if (localizedStringReference != null)
					{
						return localizedStringReference.GetLocalizedString();
					}
					goto IL_01b6;
				}
			}
			string languageName = LocalizationUtility.GetLanguageName(settingEnumValue);
			bool flag = string.IsNullOrEmpty(languageName);
			bool flag2 = !flag;
			string result = languageName;
			if (!flag2)
			{
				result = settingEnumValue;
			}
			return result;
		}
		goto IL_01b6;
		IL_01b6:
		return (string)(object)new NullReferenceException();
	}

	public static float GetSliderIncrement(string settingName)
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1831725D8]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		if (settingName == "sensitivity" || settingName == "controller_sensitivity")
		{
			return 0.01f;
		}
		return -1f;
	}
}
